using UnityEngine;

public abstract class Rune_BuffGridCommon : ARune
{
	private GameObject obj_BuffGrid;

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void PlacementPreviewProc()
	{
	}

	private void CreateBuffGrid(bool isPreview = false)
	{
	}

	protected abstract string GetBuffGridPrefabName();
}
