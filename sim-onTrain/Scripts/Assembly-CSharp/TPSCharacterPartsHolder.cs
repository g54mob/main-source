using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TPSCharacterPartsHolder : MonoBehaviour
{
	public List<GameObject> tpsParts = new List<GameObject>();

	public GameObject basePart;

	private void Start()
	{
		if (!GetComponentInParent<TsPlayerNetworkHelper>().isLocalPlayer)
		{
			foreach (GameObject tpsPart in tpsParts)
			{
				tpsPart.SetActive(value: true);
			}
			return;
		}
		DisableTPSParts();
	}

	public void EnableTPSParts()
	{
		foreach (GameObject tpsPart in tpsParts)
		{
			SkinnedMeshRenderer[] componentsInChildren = tpsPart.GetComponentsInChildren<SkinnedMeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].shadowCastingMode = ShadowCastingMode.On;
			}
		}
	}

	public void DisableTPSParts()
	{
		foreach (GameObject tpsPart in tpsParts)
		{
			SkinnedMeshRenderer[] componentsInChildren = tpsPart.GetComponentsInChildren<SkinnedMeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].shadowCastingMode = ShadowCastingMode.ShadowsOnly;
			}
		}
	}

	public void DisableTpsBase()
	{
		if (!(basePart == null))
		{
			SkinnedMeshRenderer[] componentsInChildren = basePart.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
			MeshRenderer[] componentsInChildren2 = basePart.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].enabled = false;
			}
		}
	}

	public void EnableTpsBase()
	{
		if (!(basePart == null))
		{
			SkinnedMeshRenderer[] componentsInChildren = basePart.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = true;
			}
			MeshRenderer[] componentsInChildren2 = basePart.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].enabled = true;
			}
		}
	}
}
