using System.Collections.Generic;
using Loxodon.Framework.ObjectPool;
using UnityEngine;

namespace Loxodon.Framework.Examples
{
	public class ObjectPoolExample : MonoBehaviour
	{
		public GameObject template;

		private IObjectPool<GameObject> pool;

		private List<GameObject> list;

		private List<Color> colors;

		private void Start()
		{
			CubeObjectFactory factory = new CubeObjectFactory(template, base.transform);
			pool = new ObjectPool<GameObject>(factory, 10, 20);
			list = new List<GameObject>();
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
				GameObject gameObject = pool.Allocate();
				gameObject.GetComponent<MeshRenderer>().material.color = GetColor();
				gameObject.transform.position = GetPosition();
				gameObject.name = $"Cube {list.Count}";
				gameObject.SetActive(value: true);
				list.Add(gameObject);
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
				GameObject obj = list[index];
				list.RemoveAt(index);
				obj.GetComponent<IPooledObject>().Free();
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
