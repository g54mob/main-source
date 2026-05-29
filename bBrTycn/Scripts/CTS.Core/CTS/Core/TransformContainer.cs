using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public class TransformContainer<T> where T : Component
	{
		public Transform transform { get; }

		public List<T> List { get; } = new List<T>();

		public int childCount => List.Count;

		public static implicit operator Transform(TransformContainer<T> container)
		{
			return container.transform;
		}

		public T GetChild(int index)
		{
			return List[index];
		}

		public TransformContainer(Transform transform)
		{
			this.transform = transform;
		}

		public void AddChild(T component)
		{
			component.transform.SetParent(transform);
			if (!List.Contains(component))
			{
				List.Add(component);
			}
		}

		public void RemoveChild(T component)
		{
			List.Remove(component);
		}
	}
}
