using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtController : MonoBehaviour
{
	[SerializeField] Transform rightControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 direction = rightControl.position - transform.position;
		direction.x = 0;
		Quaternion targetRot = Quaternion.LookRotation(direction,Vector3.up);
		transform.localRotation = targetRot;

		
    }
}
