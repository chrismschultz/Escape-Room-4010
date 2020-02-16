using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForMove : MonoBehaviour
{
	[SerializeField] Moved[] moveArray;
	public bool allMoved = false;
	public bool shelfInPlace = false;
	[SerializeField] float speed;
	
	// Start is called before the first frame update
	void Start()
    {
		moveArray = GetComponentsInChildren<Moved>();
    }

    // Update is called once per frame
    void Update()
    {
		CanMove();
		if (allMoved)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(0.838f, transform.position.y, transform.position.z), Time.deltaTime * speed);
			if(transform.position.x == 0.838f)
			{
				shelfInPlace = true;
			}
		}
    }

	void CanMove()
	{
		bool temp = true;
		foreach(Moved m in moveArray)
		{
			if (!m.inPlace)
			{
				temp = false;
			}
		}
		if (temp)
		{
			allMoved = true;
		}
	}
}
