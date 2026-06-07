using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public static class CycleTargets
	{
		private const float INFINITY = 9999f;

		public static void Closest(Character character)
		{
			Targets targets = character.Combat.Targets;
			List<GameObject> list = targets.List;
			float num = 9999f;
			GameObject primary = null;
			foreach (GameObject item in list)
			{
				Vector3 position = item.transform.position;
				float num2 = Vector3.Distance(character.transform.position, position);
				if (!(num2 >= num))
				{
					num = num2;
					primary = item;
				}
			}
			targets.Primary = primary;
		}

		public static void Direction(Character character, Camera camera, Vector2 direction)
		{
			if (camera == null || direction.sqrMagnitude <= 0f)
			{
				return;
			}
			Targets targets = character.Combat.Targets;
			List<GameObject> list = targets.List;
			Vector3 position = camera.transform.TransformPoint(Vector3.forward);
			Vector3 vector = camera.WorldToScreenPoint(position);
			float val = 9999f;
			GameObject gameObject = null;
			foreach (GameObject item in list)
			{
				if (!(item == targets.Primary))
				{
					float num = Vector2.Angle(camera.WorldToScreenPoint(item.transform.position) - vector, direction);
					if (!(num >= Math.Min(val, 90f)))
					{
						val = num;
						gameObject = item;
					}
				}
			}
			if (gameObject != null)
			{
				targets.Primary = gameObject;
			}
		}

		public static void Next(Character character)
		{
			Targets targets = character.Combat.Targets;
			List<GameObject> list = targets.List;
			if (targets.Primary == null)
			{
				if (list.Count == 0)
				{
					return;
				}
				targets.Primary = list[0];
			}
			if (list.Count != 0)
			{
				int num = list.IndexOf(targets.Primary);
				if (num < 0)
				{
					targets.Primary = list[0];
					return;
				}
				int index = ((++num < list.Count) ? num : 0);
				targets.Primary = list[index];
			}
		}

		public static void Previous(Character character)
		{
			Targets targets = character.Combat.Targets;
			List<GameObject> list = targets.List;
			if (targets.Primary == null)
			{
				if (list.Count == 0)
				{
					return;
				}
				targets.Primary = list[0];
			}
			if (list.Count != 0)
			{
				int num = list.IndexOf(targets.Primary);
				if (num < 0)
				{
					targets.Primary = list[0];
					return;
				}
				int index = ((--num < 0) ? (list.Count - 1) : num);
				targets.Primary = list[index];
			}
		}
	}
}
