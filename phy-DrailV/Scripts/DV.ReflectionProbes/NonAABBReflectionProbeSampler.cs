using UnityEngine;

[DisallowMultipleComponent]
public class NonAABBReflectionProbeSampler : MonoBehaviour
{
	private NonAABBReflectionProbeContainer currentArea;

	private Collider currentAreaCollider;

	private Transform anchorOverride;

	private void OnTriggerEnter(Collider other)
	{
		NonAABBReflectionProbeContainer component = other.GetComponent<NonAABBReflectionProbeContainer>();
		if ((bool)component && !(component == currentArea))
		{
			currentArea = component;
			currentAreaCollider = other;
			OverrideRenderersAnchors(on: true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if ((bool)currentArea && !GetComponent<Rigidbody>().isKinematic && other == currentAreaCollider)
		{
			OverrideRenderersAnchors(on: false);
			currentArea = null;
			currentAreaCollider = null;
		}
	}

	private void OverrideRenderersAnchors(bool on)
	{
		if (on)
		{
			if (!anchorOverride)
			{
				GameObject gameObject = new GameObject(base.name + " - reflection probe anchor override");
				anchorOverride = gameObject.transform;
			}
			anchorOverride.SetParent(currentArea.GetProbesParent());
		}
		else if ((bool)anchorOverride)
		{
			Object.Destroy(anchorOverride.gameObject);
			anchorOverride = null;
		}
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].probeAnchor = (on ? anchorOverride : null);
		}
	}

	private void Update()
	{
		if ((bool)currentArea)
		{
			anchorOverride.localPosition = currentArea.transform.InverseTransformPoint(base.transform.position);
		}
	}

	private void OnDestroy()
	{
		if (anchorOverride != null)
		{
			Object.Destroy(anchorOverride.gameObject);
		}
	}

	private void OnDrawGizmos()
	{
		if ((bool)currentArea && (bool)anchorOverride)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(anchorOverride.position, 0.1f);
		}
	}
}
