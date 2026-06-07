using System;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionDesk : MonoBehaviour
{
	[NonSerialized]
	public uint[] QueueSave;

	[NonSerialized]
	public List<Actor> Queue = new List<Actor>();

	public Furniture Furn;

	public bool Active
	{
		get
		{
			return Furn.GetInteractionPoint(InteractionPoint.ActionType.Use, true).UsedBy != null;
		}
	}

	private void Start()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.ReceptionDesks.Add(this);
		}
	}

	private void OnDestroy()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.ReceptionDesks.Remove(this);
		}
	}
}
