using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class ScriptActivator : MonoBehaviour
{
	public KeyCode key;

	public List<MonoBehaviour> mono = new List<MonoBehaviour>();

	private void Start()
	{
	}

	private void Update()
	{
		if (!Input.GetKeyDown(key))
		{
			return;
		}
		foreach (MonoBehaviour item in mono)
		{
			if (item.gameObject.TryGetComponent<SplineFollower>(out var component))
			{
				component.follow = !component.follow;
			}
			else
			{
				item.enabled = !item.enabled;
			}
		}
	}
}
