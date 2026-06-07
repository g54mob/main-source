using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	internal class Armature : Dictionary<string, Transform>
	{
		public Armature(Character character, Transform transform)
		{
			GatherBones(character, transform);
		}

		public Transform Get(string name)
		{
			if (!ContainsKey(name))
			{
				return null;
			}
			return base[name];
		}

		private void GatherBones(Character character, Transform transform)
		{
			if (!(character != null) || !character.Props.HasInstance(transform.gameObject))
			{
				if (ContainsKey(transform.name))
				{
					Remove(transform.name);
				}
				Add(transform.name, transform);
				int childCount = transform.childCount;
				for (int i = 0; i < childCount; i++)
				{
					GatherBones(character, transform.GetChild(i));
				}
			}
		}
	}
}
