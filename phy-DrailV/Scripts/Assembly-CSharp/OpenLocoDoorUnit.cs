using System.Collections.Generic;
using Bolt;
using DV.CabControls.Spec;
using DV.Openables;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(BoxCollider))]
[UnitTitle("Open a door")]
[UnitCategory("Trains")]
[UnitSubtitle("Wait for player to open any doors on the loco")]
public class OpenLocoDoorUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public List<OpenableControl> Doors;

		public OpenableControl ClosestDoor;

		public Lever ClosestLever;
	}

	protected override string DoneFieldName => "Opened";

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		Context context2 = (Context)context;
		if (context2.ClosestLever != null && context2.ClosestLever.interactionPoint != null)
		{
			return context2.ClosestLever.interactionPoint.gameObject;
		}
		return null;
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.Doors = new List<OpenableControl>();
		OpenableControl[] componentsInChildren = PlayerManager.Car.loadedExternalInteractables.GetComponentsInChildren<OpenableControl>();
		foreach (OpenableControl openableControl in componentsInChildren)
		{
			if (openableControl.gameObject.name.ToLower().Contains("door"))
			{
				context.Doors.Add(openableControl);
			}
		}
		context.ClosestDoor = GetClosest(context.Doors);
		context.ClosestLever = (context.ClosestDoor ? context.ClosestDoor.GetComponent<Lever>() : null);
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		if (PlayerManager.Car == null)
		{
			Debug.LogWarning("Not on a car currently, can't wait for door opening, continuing immediately");
			return true;
		}
		if (PlayerManager.Car.loadedExternalInteractables == null)
		{
			Debug.LogWarning("External interactables not loaded, can't wait for door opening, continuing immediately");
			return true;
		}
		return ((Context)context).Doors.Count == 0;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		OpenableControl closest = GetClosest(context2.Doors);
		if (closest != context2.ClosestDoor)
		{
			context2.ClosestDoor = closest;
			context2.ClosestLever = context2.ClosestDoor.GetComponent<Lever>();
			if (!silent)
			{
				UpdateMessage(flow, context);
			}
		}
		return context2.ClosestDoor.IsOpen;
	}

	private static OpenableControl GetClosest(List<OpenableControl> list)
	{
		if (list.Count == 0)
		{
			return null;
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		Vector3 vector = PlayerManager.PlayerTransform.position;
		float num = float.PositiveInfinity;
		int index = 0;
		for (int i = 0; i < list.Count; i++)
		{
			Transform transform = list[i].transform;
			Lever component = list[i].GetComponent<Lever>();
			if (component != null && component.interactionPoint != null)
			{
				transform = component.interactionPoint;
			}
			float sqrMagnitude = (transform.transform.position - vector).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				index = i;
			}
		}
		return list[index];
	}
}
