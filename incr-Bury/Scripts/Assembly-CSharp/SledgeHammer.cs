using System.Collections.Generic;
using UnityEngine;

public class SledgeHammer : MonoBehaviour
{
	[SerializeField]
	private Renderer ourRend;

	[SerializeField]
	private List<Material> hammerHeadMats;

	[SerializeField]
	private Renderer[] eyelid_Rends;

	public void SetHammerMaterialFromTier()
	{
		Material[] materials = ourRend.materials;
		materials[0] = hammerHeadMats[PlayerStats.Singleton.SledgeHammer_Tier];
		ourRend.materials = materials;
		Renderer[] array = eyelid_Rends;
		foreach (Renderer obj in array)
		{
			Material material = obj.material;
			material = hammerHeadMats[PlayerStats.Singleton.SledgeHammer_Tier];
			obj.material = material;
		}
	}

	public List<Material> GetHammerMaterialList()
	{
		return hammerHeadMats;
	}
}
