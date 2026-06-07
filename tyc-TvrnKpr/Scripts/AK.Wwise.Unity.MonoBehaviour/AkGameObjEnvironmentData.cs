using System.Collections.Generic;
using UnityEngine;

public class AkGameObjEnvironmentData
{
	private readonly List<AkEnvironment> activeEnvironments;

	private readonly List<AkEnvironment> activeEnvironmentsFromPortals;

	private readonly List<AkEnvironmentPortal> activePortals;

	private readonly AkAuxSendArray auxSendValues;

	private Vector3 lastPosition;

	private bool hasEnvironmentListChanged;

	private bool hasActivePortalListChanged;

	private bool hasSentZero;

	private void AddHighestPriorityEnvironmentsFromPortals(Vector3 position)
	{
	}

	private void AddHighestPriorityEnvironments(Vector3 position)
	{
	}

	public void UpdateAuxSend(GameObject gameObject, Vector3 position)
	{
	}

	private void TryAddEnvironment(AkEnvironment env)
	{
	}

	private void RemoveEnvironment(AkEnvironment env)
	{
	}

	public void AddAkEnvironment(Collider environmentCollider, Collider gameObjectCollider)
	{
	}

	private bool AkEnvironmentBelongsToActivePortals(AkEnvironment env)
	{
		return false;
	}

	public void RemoveAkEnvironment(Collider environmentCollider, Collider gameObjectCollider)
	{
	}
}
