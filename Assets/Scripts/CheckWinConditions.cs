using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWinConditions : MonoBehaviour
{
	[SerializeField] GameObject canvas;
	[SerializeField] Text text;
	[SerializeField] Rotate archRotate;
	[SerializeField] CountdownTimer timer;
    // Start is called before the first frame update
    void Start()
    {
		canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (timer.gameOver)
		{
			canvas.SetActive(true);
			if (archRotate.win)
			{
				text.color = Color.green;
				text.text = "You Win!";
			}
			else
			{
				text.color = Color.red;
				text.text = "You Lose!";
			}
		}
    }
}
