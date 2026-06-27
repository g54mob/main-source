using System;
using UnityEngine;

namespace Mandragora.AnimationTools
{
	[Serializable]
	public class AnimationObjectArray
	{
		public AnimationObject[] animationObjects;

		private AnimationPlayer player = new AnimationPlayer();

		public AnimationPlayer Player
		{
			get
			{
				if (animationObjects.Length != 0 && animationObjects[0] != null)
				{
					player = animationObjects[0].Player;
					player.clones = new AnimationObject[animationObjects.Length - 1];
					for (int i = 0; i < player.clones.Length; i++)
					{
						player.clones[i] = animationObjects[i + 1];
					}
				}
				return player;
			}
		}

		public AnimationObjectArray()
		{
		}

		public AnimationObjectArray(AnimationObject[] array)
		{
			animationObjects = array;
		}

		public void SetShader(Shader shader)
		{
			AnimationObject[] array = animationObjects;
			foreach (AnimationObject animationObject in array)
			{
				if (animationObject != null)
				{
					animationObject.SetShader(shader);
				}
			}
		}
	}
}
