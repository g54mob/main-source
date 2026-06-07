using System;
using UnityEngine;
using UnityEngine.Events;

public class DialogueMenu : MonoBehaviour
{
	public RectTransform selectObj;

	public RectTransform[] targets;

	private int curSelection;

	public UnityEvent[] onItemSelect;

	public AudioSource switchSFX;

	public AudioSource pickSFX;

	public AudioSource exitSFX;

	private void OnEnable()
	{
		curSelection = 0;
	}

	private void Update()
	{
		if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Interact"))) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Fire1"))
		{
			onItemSelect[curSelection].Invoke();
			if (curSelection == targets.Length - 1)
			{
				exitSFX.Play();
			}
			else
			{
				pickSFX.Play();
			}
		}
		if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Left"))))
		{
			if (curSelection == 0)
			{
				return;
			}
			curSelection--;
			switchSFX.Play();
		}
		if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Right"))))
		{
			if (curSelection == targets.Length - 1)
			{
				return;
			}
			curSelection++;
			switchSFX.Play();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			onItemSelect[targets.Length - 1].Invoke();
			exitSFX.Play();
		}
		selectObj.position = Vector3.Lerp(selectObj.position, targets[curSelection].position, Time.deltaTime * 25f);
	}

	public KeyCode ConvertStringToKeyCode(string keyName)
	{
		return (KeyCode)Enum.Parse(typeof(KeyCode), keyName, ignoreCase: true);
	}
}
