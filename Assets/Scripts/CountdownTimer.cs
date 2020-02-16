using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
	[SerializeField] Text text;
	[SerializeField] float mainTimer;

	float timer;
	public bool gameOver = false;
	float minutes;
	float seconds;

    // Start is called before the first frame update
    void Start()
    {
		timer = mainTimer;
		StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private IEnumerator Countdown()
	{
		while (timer > 0.0f)
		{
			yield return new WaitForSeconds(1);
			if(timer <= 60.0f)
			{
				text.color = Color.red;
			}
			timer -= 1;
			minutes = (int)timer / 60;
			seconds = (int)timer % 60;
			text.text = minutes.ToString() + ":" + (seconds < 10 ? "0" + seconds.ToString() : seconds.ToString());
		}
	
		gameOver = true;
		text.text = "0:00";
		timer = 0.0f;
	}
}
