using System.Collections.Generic;
using UnityEngine;

public class SegmentDisplayModule : Module
{
	public enum Commands
	{
		UpdateVisuals = 1
	}

	public SpriteRenderer ledLightRenderer;

	public int groupsCount;

	public int segmentsCount;

	private Material ledLightMaterial;

	private Texture2D statusTexture;

	private ModuleProperty statesProperty;

	private ModuleProperty colorsProperty;

	private Dictionary<int, HashSet<int>> digits;

	public override void AllocResources()
	{
	}

	public override void DeallocResources()
	{
	}

	protected override void OnSetupFinished()
	{
	}

	public override void ApplyPermanentStorage(Storage storage, Storage permanentOnlyStorage = null)
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	private void SetupStatesProperties()
	{
	}

	protected override void UpdateVisuals()
	{
	}

	public void ShowDigit_Script(int groupIndex, int digit)
	{
	}

	public void SetDigitColor_Script(int groupIndex, Color color)
	{
	}
}
