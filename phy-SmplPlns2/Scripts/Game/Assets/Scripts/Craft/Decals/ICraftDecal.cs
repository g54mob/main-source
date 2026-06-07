using System;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Craft.Decals
{
	public interface ICraftDecal
	{
		Vector3 CraftPosition { get; set; }

		Quaternion CraftRotation { get; set; }

		CraftDecalType DecalType { get; }

		float Opacity { get; set; }

		int RenderPriority { get; set; }

		Vector3 Size { get; set; }

		PartTargetingData PartTargeting { get; }

		Color TintColor { get; set; }

		event EventHandler<EventArgs> DecalPropertiesChanged;

		void OnUpdate(Transform transform);

		void SetDirty();
	}
}
