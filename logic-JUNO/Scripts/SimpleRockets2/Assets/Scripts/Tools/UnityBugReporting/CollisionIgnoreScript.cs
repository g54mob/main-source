using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.UnityBugReporting
{
	public class CollisionIgnoreScript : MonoBehaviour
	{
		public GameObject PartA;

		public GameObject PartB;

		public string ColliderNameA;

		public string ColliderNameB;

		public static CollisionIgnoreScript Create(GameObject obj, GameObject partA, GameObject partB, string colliderNameA, string colliderNameB)
		{
			CollisionIgnoreScript collisionIgnoreScript = obj.AddComponent<CollisionIgnoreScript>();
			collisionIgnoreScript.PartA = partA;
			collisionIgnoreScript.PartB = partB;
			collisionIgnoreScript.ColliderNameA = colliderNameA;
			collisionIgnoreScript.ColliderNameB = colliderNameB;
			return collisionIgnoreScript;
		}

		private void ApplyPartCollision()
		{
			if (PartA == null || PartB == null)
			{
				return;
			}
			List<Collider> list = new List<Collider>();
			List<Collider> list2 = new List<Collider>();
			PartA.GetComponentsInChildren(includeInactive: false, list);
			PartB.GetComponentsInChildren(includeInactive: false, list2);
			string text = ColliderNameA ?? string.Empty;
			if (text != string.Empty)
			{
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (list[num].name != text)
					{
						list.RemoveAt(num);
					}
				}
			}
			string text2 = ColliderNameB ?? string.Empty;
			if (text2 != string.Empty)
			{
				for (int num2 = list2.Count - 1; num2 >= 0; num2--)
				{
					if (list2[num2].name != text2)
					{
						list2.RemoveAt(num2);
					}
				}
			}
			if (list.Count == 0 || list2.Count == 0)
			{
				string text3 = "part '" + PartA.name + "' (" + ColliderNameA + ")";
				string text4 = "part '" + PartB.name + "' (" + ColliderNameB + ")";
				string text5 = $"Found {list.Count} for part {text3} and {list2.Count} for part {text4}.";
				Debug.LogWarning("Could not disable collision between part " + text3 + " and part " + text4 + ". " + text5, this);
			}
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list2.Count; j++)
				{
					string text6 = "part '" + PartA.name + "' (" + list[i].name + ")";
					string text7 = "part '" + PartB.name + "' (" + list2[j].name + ")";
					Debug.Log("Ignoring collision between " + text6 + " and " + text7, list[i]);
					Debug.Log("Ignoring collision between " + text6 + " and " + text7, list2[j]);
					Physics.IgnoreCollision(list[i], list2[j], ignore: true);
				}
			}
		}

		private void Start()
		{
			ApplyPartCollision();
		}
	}
}
