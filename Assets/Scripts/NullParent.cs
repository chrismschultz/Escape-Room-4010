using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullParent : MonoBehaviour
{
	Transform[] books;
    // Start is called before the first frame update
    void Start()
    {
		books = GetComponentsInChildren<Transform>();
		foreach(Transform book in books)
		{
			book.parent = null;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
