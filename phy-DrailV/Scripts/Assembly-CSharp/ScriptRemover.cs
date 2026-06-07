using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScriptRemover : MonoBehaviour
{
	public enum StripLODsApproach
	{
		Remove = 0,
		KeepExisting = 1,
		KeepOnlyLOD0 = 2
	}

	public GameObject parentToStrip;

	public bool stripMonoBehaviors = true;

	public bool stripColliders = true;

	public bool stripParticleSystems = true;

	public bool stripAnimators = true;

	public bool stripJoints = true;

	public bool disableGravity = true;

	public bool deleteDisabledObjects = true;

	public bool deleteEmptyInvisibleObjects = true;

	public bool deleteLabels = true;

	public StripLODsApproach stripLODsApproach;

	[InspectorButton("StripNow", true, true)]
	public bool strip;

	private void StripNow()
	{
		Strip(parentToStrip, stripMonoBehaviors, stripColliders, stripParticleSystems, stripAnimators, stripJoints, disableGravity, deleteDisabledObjects, deleteEmptyInvisibleObjects, deleteLabels, stripLODsApproach);
	}

	public static void Strip(GameObject go, bool stripMonoBehaviors = true, bool stripColliders = true, bool stripParticleSystems = true, bool stripAnimators = true, bool stripJoints = true, bool disableGravity = true, bool deleteDisabledObjects = true, bool deleteEmptyInvisibleObjects = true, bool deleteLabels = true, StripLODsApproach stripLODsApproach = StripLODsApproach.Remove)
	{
		if (go == null)
		{
			return;
		}
		if (!go.activeSelf && deleteDisabledObjects)
		{
			Object.DestroyImmediate(go);
			return;
		}
		for (int num = go.transform.childCount - 1; num >= 0; num--)
		{
			Strip(go.transform.GetChild(num).gameObject, stripMonoBehaviors, stripColliders, stripParticleSystems, stripAnimators, stripJoints, disableGravity, deleteDisabledObjects, deleteEmptyInvisibleObjects, deleteLabels, stripLODsApproach);
		}
		List<Object> list = new List<Object>();
		if (stripMonoBehaviors)
		{
			list.AddRange(go.GetComponents<MonoBehaviour>());
			list = list.Where((Object t) => !(t is TMP_Text)).ToList();
		}
		if (stripColliders)
		{
			list.AddRange(go.GetComponents<Collider>());
		}
		if (stripAnimators)
		{
			list.AddRange(go.GetComponents<Animator>());
		}
		if (stripParticleSystems)
		{
			list.AddRange(go.GetComponents<ParticleSystem>());
			list.AddRange(go.GetComponents<ParticleSystemRenderer>());
		}
		if (stripJoints)
		{
			list.AddRange(go.GetComponents<HingeJoint>());
		}
		if (disableGravity)
		{
			list.AddRange(go.GetComponents<Rigidbody>());
		}
		GameObject[] array = (from t in go.GetComponents<TMP_Text>()
			select t.gameObject).ToArray();
		foreach (Object item in list)
		{
			Object.DestroyImmediate(item);
		}
		for (int num2 = 10; num2 > 0; num2--)
		{
			List<Object> list2 = list.Where((Object obj) => obj != null).ToList();
			if (list2.Count == 0)
			{
				break;
			}
			Debug.Log($"Retrying removal of {list2.Count} components");
			foreach (Object item2 in list2)
			{
				Object.DestroyImmediate(item2);
			}
		}
		if (deleteEmptyInvisibleObjects)
		{
			Renderer component = go.GetComponent<Renderer>();
			if (go.transform.childCount == 0 && (component == null || !component.enabled))
			{
				Object.DestroyImmediate(go);
			}
		}
		if (deleteLabels && go != null)
		{
			foreach (GameObject gameObject in array)
			{
				if (gameObject != null)
				{
					Object.DestroyImmediate(gameObject);
				}
			}
		}
		if (!(go != null))
		{
			return;
		}
		LODGroup component2 = go.GetComponent<LODGroup>();
		if (!(component2 != null))
		{
			return;
		}
		LOD[] lODs = component2.GetLODs();
		switch (stripLODsApproach)
		{
		case StripLODsApproach.Remove:
			CleanLOD0RenderersAndRemoveTheRest(lODs);
			Object.DestroyImmediate(component2);
			break;
		case StripLODsApproach.KeepExisting:
		{
			for (int num4 = 0; num4 < lODs.Length; num4++)
			{
				lODs[num4].renderers = lODs[num4].renderers.Where((Renderer t) => t != null).ToArray();
			}
			component2.SetLODs(lODs);
			break;
		}
		case StripLODsApproach.KeepOnlyLOD0:
		{
			Renderer[] renderers = CleanLOD0RenderersAndRemoveTheRest(lODs);
			lODs[0].renderers = renderers;
			LOD[] array2 = new LOD[1] { lODs[0] };
			array2[0].screenRelativeTransitionHeight = 0.01f;
			component2.SetLODs(array2);
			break;
		}
		default:
			Debug.LogError($"Unexpected Strip LODs approcah: {stripLODsApproach}. Skipping.");
			break;
		}
		Renderer[] CleanLOD0RenderersAndRemoveTheRest(LOD[] lodsToClean)
		{
			Renderer[] array3 = lodsToClean[0].renderers.Where((Renderer r) => r != null).Distinct().ToArray();
			List<Renderer> list3 = new List<Renderer>();
			for (int num5 = 1; num5 < lodsToClean.Length; num5++)
			{
				list3.AddRange(lodsToClean[num5].renderers.Where((Renderer r) => r != null).Distinct().Except(array3));
			}
			for (int num6 = 0; num6 < list3.Count; num6++)
			{
				Renderer renderer = list3[num6];
				if (renderer != null)
				{
					Object.DestroyImmediate(renderer.gameObject);
				}
			}
			return array3;
		}
	}
}
