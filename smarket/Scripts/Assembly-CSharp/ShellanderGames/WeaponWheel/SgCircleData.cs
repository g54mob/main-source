using System;
using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	[Serializable]
	public class SgCircleData
	{
		[Tooltip("It's important to mark the main content as main using the checkbox to align the content graphics properly. There can only be one.")]
		public bool isMain;

		[Tooltip("Outer diameter (circle size).")]
		public float diameter;

		public float thickness;

		public SgPatternSelectableData colors;

		[Tooltip("If you want unique colors for each slice.")]
		public SgOverridingSliceSelectableData[] overridingSliceColors;

		[Tooltip("If you want unique circle sprites for this circle.")]
		public SgCircleSpriteData overridingSprites;

		[HideInInspector]
		public bool isFoldedOut;

		public float Circumference => 0f;

		public float HoleDiameter => 0f;

		public float Radius => 0f;

		public float CenterRadius => 0f;

		public float InvertedThickness => 0f;

		public float Scale => 0f;

		public float Offset => 0f;

		public SgSelectableData GetOverridingSelectableData(int sliceIndex)
		{
			return null;
		}
	}
}
