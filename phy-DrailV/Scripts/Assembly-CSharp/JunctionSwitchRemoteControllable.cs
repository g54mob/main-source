using System;
using System.Collections.Generic;
using DV.Common;
using DV.Highlighting;
using DV.Hovering;
using DV.Signs;
using DV.Utils;
using UnityEngine;

[RequireComponent(typeof(VisualSwitch))]
public class JunctionSwitchRemoteControllable : RemoteControllable
{
	[SerializeField]
	private HighlightTag switchHighlightTag;

	private bool isVR;

	public VisualSwitch VisualSwitch { get; private set; }

	public string IdLong
	{
		get
		{
			if (!(VisualSwitch != null))
			{
				return string.Empty;
			}
			return VisualSwitch.junction.junctionData.junctionIdLong;
		}
	}

	public JunctionSignHover SignHover { get; private set; }

	private void Start()
	{
		VisualSwitch = GetComponent<VisualSwitch>();
		if (VisualSwitch == null)
		{
			throw new Exception("Missing VisualSwitch component");
		}
		isVR = VRManager.IsVREnabled();
		if (!isVR)
		{
			SignHover = base.gameObject.AddComponent<JunctionSignHover>();
			SignHover.signTypes = new List<SignDisplayInstance> { default(SignDisplayInstance) };
			VisualSwitch.junction.Switched += delegate
			{
				UpdateSignHover();
			};
			UpdateSignHover();
		}
	}

	public bool IsBehind(Transform otherTransform)
	{
		return Vector3.Dot(otherTransform.position - base.transform.position, base.transform.forward) < 0f;
	}

	public bool IsPointingLeft()
	{
		return VisualSwitch.junction.selectedBranch == 0;
	}

	private void UpdateSignHover()
	{
		if (!isVR)
		{
			JunctionSignHover component = GetComponent<JunctionSignHover>();
			component.signTypes[0] = new SignDisplayInstance
			{
				prefab = Sign.Config.GetSignReference(IsPointingLeft() ? SignType.JunctionLeft : SignType.JunctionRight).uiDisplayElement.gameObject
			};
			(NonVRHoverManager.HoverType, object) currentlyHovered = SingletonBehaviour<NonVRHoverManager>.Instance.CurrentlyHovered;
			if (currentlyHovered.Item1 == NonVRHoverManager.HoverType.Sign && currentlyHovered.Item2 as SignHover == component)
			{
				component.Unhovered();
				component.Hovered();
			}
		}
	}

	public override void HandleThumbpad(Vector2 axis)
	{
		VisualSwitch.Switch();
	}

	public void ToggleHighlight(bool on)
	{
		SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on, switchHighlightTag, AGeneralHighlighter.HighlightType.Sign, useObstructedMaterial: false);
	}
}
