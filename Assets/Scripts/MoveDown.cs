using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

	[SerializeField] Button button;
	[SerializeField] RightControl controller;
	[SerializeField] float scalar;
	public bool open;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (button.active)
		{
			transform.Translate(Vector3.up * Mathf.Abs(controller.outputValue) * scalar * Time.deltaTime);
			if(transform.position.y >= 3.8)
			{
				open = true;
			}
		}
	}
}
