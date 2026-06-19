using System.Collections.Generic;
using UnityEngine;

public class LiquidController : MonoBehaviour
{
	public List<LiquidInfo> liquids = new List<LiquidInfo>();

	public RoomCustomizationObject puddleObject;

	public RoomCustomizationObject smallPuddleObject;

	public GameObject splashParticles;

	public GameObject dripParticles;

	private void Awake()
	{
		for (int i = 0; i < liquids.Count; i++)
		{
			liquids[i].InitColors();
		}
	}

	public LiquidInfo GetLiquidForType(LiquidType liquidType)
	{
		for (int i = 0; i < liquids.Count; i++)
		{
			if (liquids[i].liquidType == liquidType)
			{
				return liquids[i];
			}
		}
		Debug.LogError("No liquid entry found for LiquidType: " + liquidType);
		return null;
	}
}
