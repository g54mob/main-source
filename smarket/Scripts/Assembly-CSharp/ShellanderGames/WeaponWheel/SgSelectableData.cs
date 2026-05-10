using System;
using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	[Serializable]
	public class SgSelectableData
	{
		[Tooltip("Default/dehighlighted color")]
		public Color color;

		[Tooltip("Obsolete/deprecated, use highlight animations instead")]
		public Color highlightColor;

		[Tooltip("Highlight/dehighlight tween animations")]
		public SgHighlightAnimationData[] highlightAnimations;

		[Tooltip("Select tween animations")]
		public SgAnimationData[] selectAnimations;

		public virtual Texture2D GetFillTexture()
		{
			return null;
		}

		public static void Copy(SgSelectableData from, ref SgSelectableData to)
		{
		}

		private static T[] CopyAnimations<T>(T[] from, T[] to) where T : SgAnimationData
		{
			return null;
		}

		public void PreventZeroAlpha()
		{
		}

		private void PreventZeroAlpha(ref Color color)
		{
		}
	}
}
