using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using ModApi.Common.Events;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftBuilderDebug
	{
		public static void FindMissingColliders(CraftScript craftScript)
		{
			Collider[] initialColliders = craftScript.GetComponentsInChildren<Collider>();
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				Collider[] componentsInChildren = craftScript.GetComponentsInChildren<Collider>();
				IEnumerable<Collider> colliders = initialColliders.Except(componentsInChildren);
				IEnumerable<Collider> colliders2 = componentsInChildren.Except(initialColliders);
				PrintColliderList("Removed", colliders);
				PrintColliderList("Added", colliders2);
			});
		}

		public static string GetColliderName(Collider collider)
		{
			PartScript componentInParent = collider.GetComponentInParent<PartScript>();
			return string.Format(componentInParent.BodyScript.GameObject.name + "." + componentInParent.gameObject.name + "." + collider.gameObject.name);
		}

		private static void PrintColliderList(string name, IEnumerable<Collider> colliders)
		{
			string text = name + "\n";
			foreach (Collider collider in colliders)
			{
				text = text + GetColliderName(collider) + "\n";
			}
			Debug.Log(text);
		}
	}
}
