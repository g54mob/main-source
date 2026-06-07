using System;
using UnityEngine;
using UnityEngine.UI;

public class ControlsKeyGrabberPanel : MonoBehaviour
{
	public ControlsManager controlsManager;

	public Text newBindingText;

	public Text duplicateBindingText;

	[NonSerialized]
	public KeyCode caughtKey;

	[NonSerialized]
	public KeyCode caughtModifier;

	public void ApplyKeyBinding()
	{
	}

	public void CancelKeyBinding()
	{
	}

	public void EraseKeyBinding()
	{
	}

	private void OnGUI()
	{
	}
}
