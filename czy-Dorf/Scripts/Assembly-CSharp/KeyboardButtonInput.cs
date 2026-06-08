using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class KeyboardButtonInput : MonoBehaviour
{
	[SerializeField]
	private KeyCode inputKey;

	[SerializeField]
	private bool repeatInvokingWhileHeldDown;

	[SerializeField]
	private float repeatedInvokingDelay = 0.5f;

	[FormerlySerializedAs("onInputButtonPressed")]
	[SerializeField]
	private UnityEvent OnInputButtonDown;

	[SerializeField]
	private UnityEvent OnInputButton;

	[SerializeField]
	private UnityEvent OnInputButtonUp;

	[SerializeField]
	private List<KeyCode> invertKeys;

	[SerializeField]
	private UnityEvent OnInvertedInputButtonDown;

	private float heldTimer;

	private void Update()
	{
		if (Input.GetKeyDown(inputKey))
		{
			heldTimer = 0f;
			InvokeInputButtonDown();
		}
		if (Input.GetKey(inputKey))
		{
			heldTimer += Time.deltaTime;
			if (repeatInvokingWhileHeldDown && heldTimer >= repeatedInvokingDelay)
			{
				heldTimer -= repeatedInvokingDelay;
				InvokeInputButtonDown();
			}
			OnInputButton?.Invoke();
		}
		if (Input.GetKeyUp(inputKey))
		{
			OnInputButtonUp?.Invoke();
		}
	}

	private void InvokeInputButtonDown()
	{
		bool flag = false;
		foreach (KeyCode invertKey in invertKeys)
		{
			if (Input.GetKey(invertKey))
			{
				flag = true;
			}
		}
		if (flag)
		{
			OnInvertedInputButtonDown?.Invoke();
		}
		else
		{
			OnInputButtonDown?.Invoke();
		}
	}

	private int InvertedKeyCount()
	{
		return invertKeys.Count;
	}
}
