using System.Collections.Generic;
using System.Linq;
using DV;
using DV.CabControls;
using DV.Highlighting;
using DV.Utils;
using UnityEngine;

public class HighlightNearbyItems : SingletonBehaviour<HighlightNearbyItems>
{
	protected const float duration = 0.8f;

	protected const float radius = 12f;

	protected float currentPingTimer;

	protected int layerMask;

	protected List<Renderer> currentlyHighlighted = new List<Renderer>();

	private bool isVR;

	protected override void Awake()
	{
		base.Awake();
		isVR = VRManager.IsVREnabled();
		layerMask = (Layers.DVLayerMask.Interactable | Layers.DVLayerMask.World_Item).ToInt();
	}

	public void Ping()
	{
		if (GamePreferences.Get<bool>(Preferences.HighlightItems))
		{
			Clear();
			FindNearbyRenderers();
			if (currentlyHighlighted.Count != 0)
			{
				Highlight();
				currentPingTimer = 0.8f;
				base.enabled = true;
			}
		}
	}

	protected void Highlight()
	{
		foreach (Renderer item in currentlyHighlighted)
		{
			SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: true, item, AGeneralHighlighter.HighlightType.Item, useObstructedMaterial: false);
		}
	}

	protected void ClearHighlight()
	{
		foreach (Renderer item in currentlyHighlighted)
		{
			SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: false, item, AGeneralHighlighter.HighlightType.Item, useObstructedMaterial: false);
		}
		currentlyHighlighted.Clear();
	}

	private void Clear()
	{
		currentlyHighlighted.RemoveAll((Renderer t) => t == null);
		ClearHighlight();
		currentlyHighlighted.Clear();
		currentPingTimer = 0f;
	}

	private void FindNearbyRenderers()
	{
		currentlyHighlighted.Clear();
		Transform reference = GetReference();
		if (!reference)
		{
			return;
		}
		foreach (MonoBehaviour item in (from obj in Physics.OverlapSphere(reference.position, 12f, layerMask).Select(GetGrabbableComponent)
			where obj != null
			select obj).Distinct())
		{
			AddRenderersOf(item, currentlyHighlighted);
		}
	}

	private MonoBehaviour GetGrabbableComponent(Collider col)
	{
		if (isVR)
		{
			Telegrabbable componentInParent = col.GetComponentInParent<Telegrabbable>();
			if (!componentInParent || !componentInParent.IsTelegrabAllowed(PlayerManager.PlayerTransform.position) || !componentInParent.ShouldHighlightWhenNearby)
			{
				return null;
			}
			return componentInParent;
		}
		return col.GetComponentInParent<ItemBase>();
	}

	private void AddRenderersOf(MonoBehaviour obj, List<Renderer> results)
	{
		HighlightTag componentInChildren = obj.GetComponentInChildren<HighlightTag>();
		if ((bool)componentInChildren && (componentInChildren.overrideDistance == 0f || Vector3.Magnitude(GetReference().position - obj.transform.position) < componentInChildren.overrideDistance))
		{
			results.AddRange(componentInChildren.renderers);
			return;
		}
		Renderer componentInChildren2 = obj.GetComponentInChildren<Renderer>();
		if (!(componentInChildren2 == null))
		{
			results.Add(componentInChildren2);
		}
	}

	private Transform GetReference()
	{
		return PlayerManager.PlayerTransform;
	}

	private void Update()
	{
		currentPingTimer -= Time.deltaTime;
		if (currentPingTimer < 0f)
		{
			Clear();
			base.enabled = false;
		}
	}
}
