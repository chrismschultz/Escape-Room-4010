using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHidden : MonoBehaviour
{
	[SerializeField] GameObject lamp;
	MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
		mesh = GetComponent<MeshRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
		CheckHidden();
    }

	void CheckHidden()
	{
		if (lamp.activeSelf)
		{
			mesh.enabled = true;
		}
	}
}
