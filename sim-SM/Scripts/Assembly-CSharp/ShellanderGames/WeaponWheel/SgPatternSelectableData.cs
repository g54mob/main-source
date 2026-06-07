using System;
using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	[Serializable]
	public class SgPatternSelectableData : SgSelectableData
	{
		[Tooltip("Fill circle with texture")]
		public Texture2D fillTexture;

		public float textureScale;

		public float textureRotation;

		public float textureOffset;

		public override Texture2D GetFillTexture()
		{
			return null;
		}
	}
}
