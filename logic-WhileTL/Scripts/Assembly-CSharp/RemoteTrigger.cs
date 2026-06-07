using System;
using Unity.Components.Events;
using UnityEngine;

public class RemoteTrigger : MonoBehaviour
{
	public Action<Collider> OnTriggerEntered;

	private void OnTriggerEnter(Collider other)
	{
		EventHelper.Invoke(OnTriggerEntered, other);
	}
}
