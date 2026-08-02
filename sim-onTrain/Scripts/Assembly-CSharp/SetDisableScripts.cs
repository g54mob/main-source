using Mirror;
using UnityEngine;

public class SetDisableScripts : NetworkBehaviour
{
	private enum CheckCondition
	{
		isServer = 0,
		isLocalPlayer = 1
	}

	[SerializeField]
	private MonoBehaviour[] scripts;

	[SerializeField]
	private AudioListener listener;

	[SerializeField]
	private CharacterController controller;

	[SerializeField]
	private GameObject[] gameObjects;

	[SerializeField]
	private GameObject[] destroyObjects;

	[SerializeField]
	private CheckCondition condition;

	[SerializeField]
	private bool conditionBool;

	private void Start()
	{
		switch (condition)
		{
		case CheckCondition.isServer:
			IsServerCheck();
			break;
		case CheckCondition.isLocalPlayer:
			IsLocalPlayerChek();
			break;
		}
	}

	private void IsLocalPlayerChek()
	{
		if (base.isLocalPlayer != conditionBool)
		{
			return;
		}
		if (listener != null)
		{
			listener.enabled = false;
		}
		if (controller != null)
		{
			controller.enabled = false;
		}
		for (int i = 0; i < scripts.Length; i++)
		{
			if (!(scripts[i] == null))
			{
				scripts[i].enabled = false;
			}
		}
		GameObject[] array = gameObjects;
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject == null))
			{
				gameObject.SetActive(value: false);
			}
		}
		array = destroyObjects;
		foreach (GameObject gameObject2 in array)
		{
			if (!(gameObject2 == null))
			{
				Object.Destroy(gameObject2);
			}
		}
	}

	private void IsServerCheck()
	{
		if (base.isServer != conditionBool)
		{
			return;
		}
		for (int i = 0; i < scripts.Length; i++)
		{
			if (!(scripts[i] == null))
			{
				scripts[i].enabled = false;
			}
		}
		GameObject[] array = gameObjects;
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject == null))
			{
				gameObject.SetActive(value: false);
			}
		}
		array = destroyObjects;
		foreach (GameObject gameObject2 in array)
		{
			if (!(gameObject2 == null))
			{
				Object.Destroy(gameObject2);
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
