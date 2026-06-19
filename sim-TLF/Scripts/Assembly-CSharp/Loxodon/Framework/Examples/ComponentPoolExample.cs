using System.Collections.Generic;
using Loxodon.Framework.ObjectPool;
using UnityEngine;

namespace Loxodon.Framework.Examples
{
	public class ComponentPoolExample : MonoBehaviour
	{
		public GameObject template;

		private IObjectPool<MeshRenderer> pool;

		private List<MeshRenderer> list;

		private List<Color> colors;

		private void Start()
		{
			CubeObjectFactory2 factory = new CubeObjectFactory2(template, base.transform);
			pool = new ObjectPool<MeshRenderer>(factory, 10, 20);
			list = new List<MeshRenderer>();
			colors = new List<Color>
			{
				Color.black,
				Color.blue,
				Color.red,
				Color.yellow,
				Color.white,
				Color.green
			};
			Add(10);
		}

		private void OnDestroy()
		{
			if (pool != null)
			{
				pool.Dispose();
				pool = null;
			}
		}

		private void OnGUI()
		{
			int num = 50;
			int num2 = 100;
			int num3 = 60;
			int num4 = 0;
			int num5 = 10;
			if (GUI.Button(new Rect(50f, num + num4++ * (num3 + num5), num2, num3), "Add"))
			{
				Add(1);
			}
			if (GUI.Button(new Rect(50f, num + num4++ * (num3 + num5), num2, num3), "Delete"))
			{
				Delete(1);
			}
		}

		protected void Add(int count)
		{
			for (int i = 0; i < count; i++)
			{
				MeshRenderer meshRenderer = pool.Allocate();
				meshRenderer.material.color = GetColor();
				meshRenderer.transform.position = GetPosition();
				meshRenderer.name = $"Cube {list.Count}";
				meshRenderer.gameObject.SetActive(value: true);
				list.Add(meshRenderer);
			}
		}

		protected void Delete(int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (list.Count <= 0)
				{
					break;
				}
				int index = list.Count - 1;
				MeshRenderer meshRenderer = list[index];
				list.RemoveAt(index);
				meshRenderer.GetComponent<IPooledObject>().Free();
			}
		}

		protected Color GetColor()
		{
			int index = Random.Range(0, colors.Count);
			return colors[index];
		}

		protected Vector3 GetPosition()
		{
			float x = Random.Range(-10, 10);
			float y = Random.Range(-5, 5);
			float z = Random.Range(-10, 10);
			return new Vector3(x, y, z);
		}
	}
}
