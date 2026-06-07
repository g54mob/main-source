using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour, ISavable
{
	[SerializeField]
	[Savable("resourceData", false, false)]
	protected ResourceData resourceData;

	[Savable("currentConveyorBeltIdx", true, false)]
	private int currentConveyorBeltIdx;

	[Savable("traveledDistance", true, false)]
	private float traveledDistance;

	public ResourceData ResourceData => resourceData;

	public int CurrentConveyorBeltIdx
	{
		get
		{
			return currentConveyorBeltIdx;
		}
		set
		{
			currentConveyorBeltIdx = value;
		}
	}

	public float TraveledDistance
	{
		get
		{
			return traveledDistance;
		}
		set
		{
			traveledDistance = value;
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
