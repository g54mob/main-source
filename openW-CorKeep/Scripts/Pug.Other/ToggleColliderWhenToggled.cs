using System.Collections.Generic;
using UnityEngine;

public class ToggleColliderWhenToggled : MonoBehaviour
{
	public List<Collider> colliders = new List<Collider>();

	private void OnEnable()
	{
		foreach (Collider collider in colliders)
		{
			collider.enabled = true;
		}
	}

	private void OnDisable()
	{
		foreach (Collider collider in colliders)
		{
			collider.enabled = false;
		}
	}
}
