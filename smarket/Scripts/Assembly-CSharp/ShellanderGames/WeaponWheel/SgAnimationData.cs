using System;
using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	[Serializable]
	public class SgAnimationData
	{
		public bool animateColor;

		[Tooltip("Animate scale and affect children")]
		public bool animateScale;

		[Tooltip("Animate a rect transform's size")]
		public bool animateSize;

		[Tooltip("Color to animate to, requires animateColor=true")]
		public Color color;

		[Tooltip("Scale to animate to, requires animateScale=true or animateSize=true")]
		public Vector2 scale;

		public float duration;

		public static SgAnimationData Create()
		{
			return null;
		}

		public virtual void Copy(SgAnimationData from)
		{
		}
	}
}
