using JBooth.MicroSplat;
using UnityEngine;

public class AssignMicroSplatToAll : MonoBehaviour
{
	public Material material;

	public MicroSplatKeywords keywords;

	public MicroSplatPropData propData;

	[InspectorButton("Assign", true, true)]
	public bool assign;

	private void Assign()
	{
		Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
		foreach (Terrain terrain in componentsInChildren)
		{
			MicroSplatTerrain microSplatTerrain = terrain.GetComponent<MicroSplatTerrain>();
			if (microSplatTerrain == null)
			{
				microSplatTerrain = terrain.gameObject.AddComponent<MicroSplatTerrain>();
			}
			microSplatTerrain.templateMaterial = material;
			microSplatTerrain.propData = propData;
			microSplatTerrain.keywordSO = keywords;
		}
	}
}
