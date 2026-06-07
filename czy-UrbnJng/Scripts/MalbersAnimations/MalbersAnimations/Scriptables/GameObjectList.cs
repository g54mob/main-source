using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Game Object List", order = 3000)]
	public class GameObjectList : GameObjectVar
	{
		public List<GameObject> list;

		private readonly System.Random Random = new System.Random();

		public override GameObject Value
		{
			get
			{
				return GetValue();
			}
			set
			{
				list.Add(value);
			}
		}

		public virtual GameObject GetValue()
		{
			int index = Random.Next(list.Count);
			return list[index];
		}
	}
}
