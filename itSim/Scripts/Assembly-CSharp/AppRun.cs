using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppRun : MonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Component")]
	public ComputerStation computerStation;

	public AppBase AppBase;

	[Header("Sound Effect")]
	public AudioSource audioSource;

	public AudioClip systemFileErrorSound;

	[Header("UI")]
	public TMP_InputField comandField;

	[Header("Comands")]
	public List<RunCommandBase> RunCommandBase;

	[HideInInspector]
	public bool isOpen;

	public void _Update()
	{
	}

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void EnterComand()
	{
	}

	private void RunComand(string cmd)
	{
	}
}
