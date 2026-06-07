using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider))]
public class NonAABBReflectionProbeContainer : MonoBehaviour
{
	private const float PROBES_Y_OFFSET = -500f;

	private const int IGNORE_RAYCAST_LAYER = 2;

	private Transform probesParent;

	private void Awake()
	{
		Collider component = GetComponent<Collider>();
		if (component == null)
		{
			Debug.LogError("NonAABBReflectionProbeContainer doesn't have a trigger collider", base.gameObject);
			return;
		}
		if (!component.isTrigger)
		{
			Debug.LogWarning("NonAABBReflectionProbeContainer collider isn't marked as trigger, will be set automatically", base.gameObject);
			component.isTrigger = true;
		}
		component.gameObject.layer = 2;
		GetProbesParent();
	}

	public Transform GetProbesParent()
	{
		if (!Application.isPlaying)
		{
			Debug.LogError("NonAABBReflectionProbeContainer only works in play mode", this);
			return null;
		}
		if (probesParent == null)
		{
			GameObject gameObject = new GameObject(base.transform.root.name + " [reflection probes]");
			probesParent = gameObject.transform;
			probesParent.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			while (base.transform.childCount > 0)
			{
				base.transform.GetChild(0).SetParent(gameObject.transform, worldPositionStays: true);
			}
			probesParent.Translate(0f, -500f, 0f);
			probesParent.localRotation = Quaternion.identity;
		}
		return probesParent;
	}

	private void FitBoxCollider()
	{
		if (Application.isPlaying)
		{
			Debug.LogError("Not supported in play mode");
			return;
		}
		BoxCollider component = GetComponent<BoxCollider>();
		if (component == null)
		{
			Debug.Log("There's no BoxCollider, aborting", this);
			return;
		}
		ReflectionProbe[] componentsInChildren = GetComponentsInChildren<ReflectionProbe>();
		if (componentsInChildren.Length == 0)
		{
			Debug.Log("There are reflection probes, aborting", this);
			return;
		}
		Bounds bounds = BoundsUtil.Merged(componentsInChildren.Select((ReflectionProbe p) => p.bounds).ToList());
		component.center = bounds.center;
		component.size = bounds.size;
	}
}
