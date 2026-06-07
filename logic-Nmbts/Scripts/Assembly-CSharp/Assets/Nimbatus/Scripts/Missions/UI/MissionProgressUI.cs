using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions.UI
{
	public class MissionProgressUI : SerializedMonoBehaviour
	{
		public tk2dSprite TargetSprite;

		public Dictionary<Vector2, tk2dSprite> Sprites;

		public void Init(int completedCount, int maxCount)
		{
			Vector2 key = new Vector2(completedCount, maxCount);
			tk2dSprite value;
			if (Sprites.TryGetValue(key, out value))
			{
				TargetSprite.SetSprite(value.spriteId);
			}
		}
	}
}
