using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBody : MonoBehaviour
{
	[SerializeField] Rigidbody[] bookBodies;
	[SerializeField] CheckForMove check;
    // Start is called before the first frame update
    void Start()
    {
		bookBodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (check.allMoved)
		{
			foreach(Rigidbody r in bookBodies)
			{
				r.isKinematic = false;
			}
		}
		if (check.shelfInPlace)
		{
			foreach (Rigidbody r in bookBodies)
			{
				r.isKinematic = true;
			}
		}
    }
}
