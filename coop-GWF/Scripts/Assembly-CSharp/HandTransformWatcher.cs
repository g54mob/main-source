using System;
using Mirror;
using UnityEngine;

public class HandTransformWatcher : NetworkBehaviour
{
	[Header("Event Callbacks")]
	public Action OnChildrenChanged;

	private void OnTransformChildrenChanged()
	{
		OnChildrenChanged?.Invoke();
	}

	public override bool Weaved()
	{
		return true;
	}
}
