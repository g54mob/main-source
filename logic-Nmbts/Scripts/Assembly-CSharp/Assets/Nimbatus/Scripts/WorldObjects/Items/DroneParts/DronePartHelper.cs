using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public static class DronePartHelper
	{
		public static List<T> GetAllChildParts<T>(this DronePart part) where T : DronePart
		{
			if (part == null)
			{
				return new List<T>();
			}
			List<T> list = part.Children.OfType<T>().ToList();
			foreach (DronePart child in part.Children)
			{
				list.AddRange(child.GetAllChildParts<T>());
			}
			return list;
		}

		public static List<T> GetAllChildParts<T>(this DronePartData part) where T : DronePartData
		{
			if (part == null)
			{
				return new List<T>();
			}
			List<T> list = part.Children.OfType<T>().ToList();
			foreach (DronePartData child in part.Children)
			{
				list.AddRange(child.GetAllChildParts<T>());
			}
			return list;
		}

		public static int GetNumberOfDroneParts<T>(this DronePart part) where T : DronePart
		{
			if (part == null)
			{
				return 0;
			}
			int num = 0;
			if (part is T && !(part is RootDronePart))
			{
				num = 1;
			}
			return num + part.Children.ToList().Sum((DronePart child) => child.GetNumberOfDroneParts<T>());
		}

		public static int GetNumberOfDroneParts(this DronePart part, Func<DronePart, bool> selector)
		{
			if (part == null)
			{
				return 0;
			}
			int num = 0;
			if (selector(part) && !(part is RootDronePart))
			{
				num = 1;
			}
			return num + part.Children.ToList().Sum((DronePart child) => child.GetNumberOfDroneParts(selector));
		}

		public static int GetNumberOfDroneParts(this DronePartData part, Func<DronePartData, bool> selector)
		{
			if (part == null)
			{
				return 0;
			}
			int num = 0;
			if (selector == null || selector(part))
			{
				num = 1;
			}
			return num + part.Children.ToList().Sum((DronePartData child) => child.GetNumberOfDroneParts(selector));
		}

		public static float GetDroneRadius(this DronePart part, RootDronePart root)
		{
			if (part == null || root == null)
			{
				return 0f;
			}
			float num = Vector2.Distance(part.transform.position, root.transform.position);
			if (part.Children.Any())
			{
				float b = part.Children.ToList().Max((DronePart c) => c.GetDroneRadius(root));
				return Mathf.Max(num, b);
			}
			return num;
		}

		public static Vector3 GetCenterOfMass(this DronePart part)
		{
			if (part == null)
			{
				return Vector3.zero;
			}
			part.Rigidbody.ResetCenterOfMass();
			Vector3 seed = part.Rigidbody.worldCenterOfMass * part.Rigidbody.mass;
			return part.Children.Aggregate(seed, (Vector3 current, DronePart child) => current + child.GetCenterOfMass());
		}

		public static float GetMass(this DronePart part)
		{
			if (part == null)
			{
				return 0f;
			}
			return part.Rigidbody.mass + part.Children.ToList().Sum((DronePart child) => child.GetMass());
		}
	}
}
