using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mandragora.AnimationTools
{
	[Serializable]
	public class AnimationDataAsset : ScriptableObject
	{
		public List<Animation> animations;

		[HideInInspector]
		public SpritesPool spritesPool;

		[HideInInspector]
		public int pixelsPerUnits;

		[HideInInspector]
		public bool isEditorMode;

		public void Clone(AnimationDataAsset copy)
		{
			animations.Clear();
			for (int i = 0; i < copy.animations.Count; i++)
			{
				animations.Add(copy.animations[i]);
			}
			spritesPool = copy.spritesPool;
			pixelsPerUnits = copy.pixelsPerUnits;
			isEditorMode = copy.isEditorMode;
		}
	}
}
