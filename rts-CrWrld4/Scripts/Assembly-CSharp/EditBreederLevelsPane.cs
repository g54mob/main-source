using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBreederLevelsPane : MonoBehaviour
{
	public EditTerrain editTerrain;

	public static List<World.BreederStruct> BREEDER_TYPES;

	public Dropdown dropdown;

	public BreederCreeperSettings breederCreeperSettings;

	public BreederACSettings breederACSettings;

	public FlipBreederSettings breederFlipSettings;

	public AbsorberSettings absorptionSettings;

	public ShatteredLandSettings shatteredLandSettings;

	[NonSerialized]
	public byte slot;

	private void Awake()
	{
	}

	public void Show(int slot)
	{
	}

	public void OnSetType()
	{
	}

	public void OnDefault()
	{
	}
}
