using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{

    public Animator PlayerAnim;

	public Rigidbody PlayerRigid;

	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;

	public bool Joging;

	public Transform PlayerTrans;

	

	

	void FixedUpdate(){

		if(Input.GetKey(KeyCode.W)){

			PlayerRigid.velocity = transform.forward * w_speed * Time.deltaTime;

		}

		if(Input.GetKey(KeyCode.S)){

			PlayerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;

		}

	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.W)){

			PlayerAnim.SetTrigger("Jog");

			PlayerAnim.ResetTrigger("Stand");

			Joging = true;

			//steps1.SetActive(true);

		}

		if(Input.GetKeyUp(KeyCode.W)){

			PlayerAnim.ResetTrigger("Jog");

			PlayerAnim.SetTrigger("Stand");

			Joging = false;

			//steps1.SetActive(false);

		}

		if(Input.GetKeyDown(KeyCode.S)){

			PlayerAnim.SetTrigger("Jogback");

			PlayerAnim.ResetTrigger("Stand");

			//steps1.SetActive(true);

		}

		if(Input.GetKeyUp(KeyCode.S)){

			PlayerAnim.ResetTrigger("Jogback");

			PlayerAnim.SetTrigger("Stand");

			//steps1.SetActive(false);

		}

		if(Input.GetKey(KeyCode.A)){

			PlayerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);

		}

		if(Input.GetKey(KeyCode.D)){

			PlayerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);

		}

		if(Joging == true){				

			if(Input.GetKeyDown(KeyCode.LeftShift)){

				//steps1.SetActive(false);

				//steps2.SetActive(true);

				w_speed = w_speed + rn_speed;

				PlayerAnim.SetTrigger("Sprint");

				PlayerAnim.ResetTrigger("Jog");

			}

			if(Input.GetKeyUp(KeyCode.LeftShift)){

				//steps1.SetActive(true);

				//steps2.SetActive(false);

				w_speed = olw_speed;

				PlayerAnim.ResetTrigger("Sprint");

				PlayerAnim.SetTrigger("Jog");

			}

		}

	}

}




public class camLookat : MonoBehaviour

{

    public Transform Player, cameraTrans;

	

	void Update(){

		cameraTrans.LookAt(Player);

	}

}