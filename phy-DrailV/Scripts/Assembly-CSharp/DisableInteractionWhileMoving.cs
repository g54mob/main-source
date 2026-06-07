using System.Collections;
using DV.CabControls;
using UnityEngine;

public class DisableInteractionWhileMoving : MonoBehaviour
{
	private const float WAIT_DURATION = 0.5f;

	private const float SPEED_THRESHOLD = 3f;

	private ControlImplBase control;

	private Collider[] colliders;

	private Vector3 prevPos;

	private bool wasDisabledByThisScript;

	private void Awake()
	{
		colliders = GetComponentsInChildren<Collider>();
		if (colliders.Length == 0)
		{
			Debug.Log("DisableInteractionWhileMoving couldn't find any colliders, destroying self", this);
			Object.Destroy(this);
		}
	}

	private void OnEnable()
	{
		StartCoroutine(Check());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private IEnumerator Check()
	{
		if (control == null)
		{
			for (int safety = 0; safety < 10; safety++)
			{
				control = GetComponent<ControlImplBase>();
				if (control != null)
				{
					break;
				}
				yield return null;
			}
		}
		if (control == null)
		{
			Debug.LogError("DisableInteractionWhileMoving couldn't find control, destroying self", this);
			Object.Destroy(this);
			yield break;
		}
		prevPos = base.transform.position;
		WaitForSeconds wait = WaitFor.Seconds(0.5f);
		while (true)
		{
			float num = Vector3.Distance(prevPos, base.transform.position) / 0.5f * 3.6f;
			if (num > 3f && colliders[0].enabled)
			{
				wasDisabledByThisScript = true;
				Toggle(on: false);
			}
			else if (num < 3f && !colliders[0].enabled && wasDisabledByThisScript)
			{
				wasDisabledByThisScript = false;
				Toggle(on: true);
			}
			prevPos = base.transform.position;
			yield return wait;
		}
	}

	private void Toggle(bool on)
	{
		Collider[] array = colliders;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = on;
		}
	}
}
