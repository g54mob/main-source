using System;
using FractureField.Prestige;
using UnityEngine;

namespace FractureField.Quarry.UI
{
	[Serializable]
	public class QuarryBackgroundSettings
	{
		[Header("Identification")]
		[Tooltip("Unique name for this background variant")]
		public string backgroundName;

		[Tooltip("The prestige layer this background belongs to (None = base backgrounds)")]
		public PrestigeLayerType prestigeLayer;

		[Header("Visual Settings")]
		[Tooltip("The sprite to display for this background")]
		public Sprite backgroundSprite;

		[Tooltip("Aspect ratio for the AspectRatioFitter component")]
		public float aspectRatio;

		[Header("Layout Settings")]
		[Tooltip("Top offset for the RectTransform (centered stretch)")]
		public float topOffset;

		[Tooltip("Bottom offset for the RectTransform (centered stretch)")]
		public float bottomOffset;

		[Header("Quarry Bounds")]
		[Tooltip("PolygonCollider2D defining the quarry bounds for this background")]
		public PolygonCollider2D boundsCollider;
	}
}
