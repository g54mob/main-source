using FIMSpace.FOptimizing;
using UnityEngine;

public sealed class ScrLOD_Terrain : ScrLOD_Base
{
	[SerializeField]
	private LODI_Terrain settings;

	public override ILODInstance GetLODInstance()
	{
		return settings;
	}

	public ScrLOD_Terrain()
	{
		settings = new LODI_Terrain();
	}

	public override ScrLOD_Base GetScrLODInstance()
	{
		return ScriptableObject.CreateInstance<ScrLOD_Terrain>();
	}

	public override ScrLOD_Base CreateNewScrCopy()
	{
		ScrLOD_Terrain scrLOD_Terrain = ScriptableObject.CreateInstance<ScrLOD_Terrain>();
		scrLOD_Terrain.settings = settings.GetCopy() as LODI_Terrain;
		return scrLOD_Terrain;
	}

	public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
	{
		Terrain terrain = target as Terrain;
		if (!terrain)
		{
			terrain = target.GetComponentInChildren<Terrain>();
		}
		if ((bool)terrain && !optimizer.ContainsComponent(terrain))
		{
			return new ScriptableLODsController(optimizer, terrain, -1, "Terrain", this);
		}
		return null;
	}
}
