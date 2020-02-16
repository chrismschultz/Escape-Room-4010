using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

	[SerializeField] RightControl controller;
	[SerializeField] MoveDown moveScript;
	[SerializeField] float scalar;
	[SerializeField] Animator targetAnim;
	[SerializeField] Button button;
	[SerializeField] CountdownTimer timer;

	public bool win;
    // Start is called before the first frame update
    void Start()
    {
		win = false;   
    }

    // Update is called once per frame
    void Update()
    {
		if (button.active)
		{
			transform.Rotate(Vector3.up, controller.outputValue * scalar * Time.deltaTime);
			if (transform.localRotation.y > 360)
			{
				transform.Rotate(Vector3.up, -360);
			}

			if (transform.localRotation.y < 0)
			{
				transform.Rotate(Vector3.up, 360);
			}

			if (Mathf.Abs(transform.localRotation.eulerAngles.y - 90) < 3 || Mathf.Abs(transform.localRotation.eulerAngles.y - 270) < 3)
			{
				if (moveScript.open)
				{
					targetAnim.SetTrigger("Victory");

					win = true;
					timer.gameOver = true;
				}
			}
		}
    }
}
