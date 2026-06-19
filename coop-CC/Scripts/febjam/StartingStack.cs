using System.Collections.Generic;
using Aggro.Core;
using Mirror;
using UnityEngine;

public class StartingStack : EntityBehaviourBase
{
	private static List<Grabbable> _children = new List<Grabbable>();

	protected override void OnEntityStart()
	{
		if (!NetworkServer.active)
		{
			return;
		}
		_children.Clear();
		GetComponentsInChildren(_children);
		if (_children.Count <= 0)
		{
			return;
		}
		_children.Sort((Grabbable x, Grabbable y) => x.entity.transform.position.y.CompareTo(y.entity.transform.position.y));
		Grabbable grabbable = _children[0];
		Transform parent = base.entity.transform.parent;
		Quaternion localRotation = base.entity.transform.localRotation;
		Vector3 vector = base.entity.transform.position + Vector3.up * 0.5f;
		for (int num = 0; num < _children.Count; num++)
		{
			Grabbable grabbable2 = _children[num];
			grabbable2.entity.transform.position = vector + Vector3.up * num;
			grabbable2.entity.transform.localRotation = localRotation;
			grabbable2.entity.transform.SetParent(parent);
			if (num > 0)
			{
				if (grabbable.CanAddToStack(grabbable2))
				{
					grabbable.ServerAddToStack(grabbable2);
				}
				else
				{
					Debug.LogWarning("Cannot add to stack!");
				}
			}
		}
	}
}
