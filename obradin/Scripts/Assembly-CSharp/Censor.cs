using UnityEngine;

public class Censor
{
	public static bool HasMermaids(string momentId)
	{
		return momentId.Contains("-laun-") || momentId.EndsWith("-mate3");
	}

	public static void CensorMermaids(MomentLogic momentLogic, Texture2D mermaidCensoredTexture)
	{
		if (mermaidCensoredTexture == null || !HasMermaids(momentLogic.id))
		{
			return;
		}
		for (int i = 0; i < momentLogic.transform.childCount; i++)
		{
			Transform child = momentLogic.transform.GetChild(i);
			if (child.name != "ship")
			{
				FindMermaidsAndReplaceTexture(child, mermaidCensoredTexture);
			}
		}
	}

	private static void FindMermaidsAndReplaceTexture(Transform target, Texture mermaidCensoredTexture)
	{
		if (target.name == "crew_mermaid1" || target.name == "crew_mermaid2" || target.name == "crew_mermaid3")
		{
			MeshRenderer component = target.GetComponent<MeshRenderer>();
			if (component != null)
			{
				ReplaceTexture(component, mermaidCensoredTexture);
			}
		}
		else
		{
			for (int i = 0; i < target.childCount; i++)
			{
				FindMermaidsAndReplaceTexture(target.GetChild(i), mermaidCensoredTexture);
			}
		}
	}

	private static void ReplaceTexture(MeshRenderer meshRenderer, Texture mermaidCensoredTexture)
	{
		Material[] materials = meshRenderer.materials;
		foreach (Material material in materials)
		{
			if (!(material.mainTexture == null) && material.name.StartsWith("mermaid") && material.name.Contains("mat_human") && (!(material.mainTexture.name != "mermaid1") || !(material.mainTexture.name != "mermaid2") || !(material.mainTexture.name != "mermaid3")))
			{
				Debug.LogFormat("Censoring mermaid: {0}", meshRenderer.name);
				material.mainTexture = mermaidCensoredTexture;
			}
		}
	}
}
