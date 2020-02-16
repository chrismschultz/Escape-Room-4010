using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	Animator anim;
	[SerializeField] Button otherButton;
	public bool active;
	
    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void Toggle(bool callPartner)
	{
		//otherButton.active = false;
		active = !active;
		anim.SetBool("Active", active);
		if (callPartner)
		{
			otherButton.SendMessage("Toggle", false);
		}
	}
}
