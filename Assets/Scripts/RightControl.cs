using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightControl : MonoBehaviour
{
	[SerializeField] float length;
	[SerializeField] float speed;
	[SerializeField] float buttonSpeed;
	[SerializeField] Animator anim1, anim2, anim3;
	[SerializeField] GameObject lamp;
	[SerializeField] GameObject handleR, handleL;
	[SerializeField] Transform turningObject;
	[SerializeField] Transform arch;
	[SerializeField] CountdownTimer timer;
	[SerializeField] Rotate archRotate;
	float startRot;
	public int outputValue;
	bool canOpen1, canOpen2 = true;
	public Transform grabbedObject;
	float grabDistance;
	bool grabbed = false;
	Moved moved;
	public Material mat;
	Color color;
    // Start is called before the first frame update
    void Start()
    {
		color = mat.color;
	}

    // Update is called once per frame
    void Update()
    {
		if (!timer.gameOver)
		{
			Selector();
			Grab();
		}
		else
		{
			if (!archRotate.win)
			{
				print("You Lose");
			}
			else
			{
				print("You Win!");
			}
		}
    }

	void Grab()
	{
		if (SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
		{
			if (!grabbed)
			{
				RaycastHit hit;

				if (Physics.Raycast(transform.position, transform.forward, out hit, length))
				{
					
					if (hit.collider.tag == "Books")
					{
						
						grabbed = true;
						if (grabbedObject == null)
						{
							grabDistance = Vector3.Distance(transform.position, hit.transform.position);
							
							grabbedObject = hit.transform;
						}
					}
					else if(hit.collider.tag == "MiscBooks")
					{
						grabbed = true;
						if (grabbedObject == null)
						{
							grabDistance = Vector3.Distance(transform.position, hit.transform.position);
							
							grabbedObject = hit.transform;
						}
					}
					else if(hit.collider.tag == "HandleR")
					{
						if (canOpen2)
						{
							
							anim2.Play("right");
						}
						else
						{
							
							anim2.Play("rightR");
						}
						canOpen2 = !canOpen2;
					}
					else if(hit.collider.tag == "HandleL")
					{
						if (canOpen1)
						{
							
							anim1.Play("left");
						}
						else
						{
							
							anim1.Play("leftR");
						}
						canOpen1 = !canOpen1;
					}
					else if(hit.collider.tag == "LampButton")
					{
						anim3.Play("button");
						lamp.SetActive(true);
					}
					else if(hit.collider.tag == "Wheel")
					{
						grabbed = true;
						grabbedObject = hit.transform;
						//grabbedObject.rotation = turningObject.rotation;
						//startRot = grabbedObject.rotation.y;

					}
					else if(hit.collider.tag == "Button")
					{
						hit.transform.SendMessage("Toggle", true);
					}
				}
			}
			else
			{
				grabbed = false;
				if(grabbedObject != null && grabbedObject.tag == "MiscBooks")
				{
					grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
				}
				grabbedObject = null;
				outputValue = 0;
			}
			
		}



		if (grabbed)
		{
			
			if (grabbedObject != null)
			{
				if (grabbedObject.tag == "Books")
				{
					moved = grabbedObject.GetComponent<Moved>();
					if (!moved.inPlace)
					{
						float initial = grabbedObject.position.z;

						grabbedObject.position = new Vector3(grabbedObject.position.x, grabbedObject.position.y, transform.position.z + (-grabDistance));
						
						if (grabbedObject.localPosition.z > -0.2f)
						{
							moved.inPlace = true;
						}
					}
				}
				else if(grabbedObject.tag == "MiscBooks")
				{
					grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
					grabbedObject.position = transform.position + (transform.forward * grabDistance);
				}
				else if(grabbedObject.tag == "Wheel")
				{
					float archRot;
					
					//grabbedObject.Rotate(Vector3.up, turningObject.rotation.y - startRot);
					grabbedObject.rotation = turningObject.rotation;
					if(grabbedObject.rotation.x < 0)
					{
						archRot = grabbedObject.rotation.x + 360;
					}
					else
					{
						archRot = grabbedObject.rotation.x;
					}

					if (Mathf.Abs(archRot - startRot) > .1 * Time.deltaTime)
					{

						if (archRot > startRot)
						{
							outputValue = 1;
						}
						else if (archRot < startRot)
						{
							outputValue = -1;
						}
						else
						{
							outputValue = 0;
						}
					}
					else
					{
						outputValue = 0;
					}
					startRot = archRot;
				
					// grabbedObject.rotation = (Quaternion.Euler(new Vector3(0, startRot - turningObject.rotation.y, 0)));
					// startRot = grabbedObject.rotation.y;

				}
				
				
			}
		}

	}

	void Selector()
	{
		RaycastHit hit;
		GameObject grabbed;
		Material tempMat;

		if (Physics.Raycast(transform.position, transform.forward, out hit, length))
		{
			if (hit.collider.tag == "HandleR")
			{
				hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
			}

			if (hit.collider.tag == "HandleL")
			{
				hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
			}

			if(hit.collider.tag == "Books")
			{
		
			}

			if(hit.collider.tag == "MiscBooks")
			{

			}
		}
		else
		{
			handleL.GetComponent<MeshRenderer>().material.color = mat.color;
			handleR.GetComponent<MeshRenderer>().material.color = mat.color;
		}
	}
}
