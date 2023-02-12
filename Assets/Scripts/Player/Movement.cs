using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class Movement : MonoBehaviour
    {
        public float[] partsPos;
        int posIndex = 1;
        public float speed = 5f;
        Animator anim;
        public float jumpForce;
        Rigidbody rb;
        public Transform groundCheck;
        public LayerMask groundLayer;
        public float rollTime;

        private void Start()
        {
            anim = Player.instance.model.GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            bool isGrounded = Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
            anim.SetFloat("Speed", 1);
            speed += 0.05f * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.A))
            {
                Left();
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                Right();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
            {
                Roll();
            }

            transform.position += Vector3.right * speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, partsPos[posIndex]), Time.deltaTime * speed);
        }

        void Jump()
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
           // transform.position += new Vector3(0, jumpForce, 0) * Time.deltaTime;
            anim.SetBool("isJumping", true);
        }

        void Roll()
        {
            Player.instance.normalCollider.enabled = false;
            Player.instance.rollCollider.enabled = true;
            anim.SetBool("isRolling", true);
            StartCoroutine(RollTime());
        }

        IEnumerator RollTime()
        {
            yield return new WaitForSeconds(rollTime);
            anim.SetBool("isRolling", false);
            Player.instance.rollCollider.enabled = false;
            Player.instance.normalCollider.enabled = true;
        }

        public void OnLanding()
        {
            anim.SetBool("isJumping", false);
        }

        void Left()
        {
            posIndex--;
            if(posIndex < 0)
            {
                posIndex = 0;
            }
            anim.SetTrigger("Left");
        }

        void Right()
        {
            posIndex++;
            if(posIndex >partsPos.Length - 1)
            {
                posIndex = partsPos.Length - 1;
            }
            anim.SetTrigger("Right");
        }

    }
}
