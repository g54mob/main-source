using System;
using System.Collections.Generic;
using Loxodon.Framework.ObjectPool;
using UnityEngine;

namespace Loxodon.Framework.Examples
{
	public class MixedObjectPoolExample : MonoBehaviour
	{
		public class CubeMixedObjectFactory : UnityMixedGameObjectFactoryBase
		{
			private GameObject template;

			private Transform parent;

			public CubeMixedObjectFactory(GameObject template, Transform parent)
			{
				this.template = template;
				this.parent = parent;
			}

			protected override GameObject Create(string typeName)
			{
				Debug.LogFormat("Create a cube.");
				GameObject gameObject = UnityEngine.Object.Instantiate(template, parent);
				gameObject.GetComponent<MeshRenderer>().material.color = GetColor(typeName);
				return gameObject;
			}

			protected Color GetColor(string typeName)
			{
				if (typeName.Equals("red"))
				{
					return Color.red;
				}
				if (typeName.Equals("green"))
				{
					return Color.green;
				}
				if (typeName.Equals("blue"))
				{
					return Color.blue;
				}
				throw new NotSupportedException("Unsupported type:" + typeName);
			}

			public override void Reset(string typeName, GameObject obj)
			{
				obj.SetActive(value: false);
				obj.name = $"Cube {typeName}-Idle";
				obj.transform.position = Vector3.zero;
				obj.transform.rotation = Quaternion.Euler(Vector3.zero);
			}

			public override void Destroy(string typeName, GameObject obj)
			{
				base.Destroy(typeName, obj);
				Debug.LogFormat("Destroy a cube.");
			}
		}

		public GameObject template;

		private IMixedObjectPool<GameObject> pool;

		private Dictionary<string, List<GameObject>> dict;

		private void Start()
		{
			CubeMixedObjectFactory factory = new CubeMixedObjectFactory(template, base.transform);
			pool = new MixedObjectPool<GameObject>(factory, 5);
			dict = new Dictionary<string, List<GameObject>>();
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
			if (GUI.Button(new Rect(50f, num + num4++ * (num3 + num5), num2, num3), "Add(red)"))
			{
				Add("red", 1);
			}
			if (GUI.Button(new Rect(50f, num + num4++ * (num3 + num5), num2, num3), "Add(green)"))
			{
				Add("green", 1);
			}
			if (GUI.Button(new Rect(50f, num + num4++ * (num3 + num5), num2, num3), "Add(blue)"))
			{
				Add("blue", 1);
			}
			if (GUI.Button(new Rect(50f, num + num4++ * (num3 + num5), num2, num3), "Delete(red)"))
			{
				Delete("red", 1);
			}
			if (GUI.Button(new Rect(50f, num + num4++ * (num3 + num5), num2, num3), "Delete(green)"))
			{
				Delete("green", 1);
			}
			if (GUI.Button(new Rect(50f, num + num4++ * (num3 + num5), num2, num3), "Delete(blue)"))
			{
				Delete("blue", 1);
			}
		}

		protected void Add(string typeName, int count)
		{
			if (!dict.TryGetValue(typeName, out var value))
			{
				value = new List<GameObject>();
				dict.Add(typeName, value);
			}
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = pool.Allocate(typeName);
				gameObject.transform.position = GetPosition();
				gameObject.name = $"Cube {typeName}-{value.Count}";
				gameObject.SetActive(value: true);
				value.Add(gameObject);
			}
		}

		protected void Delete(string typeName, int count)
		{
			if (!dict.TryGetValue(typeName, out var value) || value.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				if (value.Count <= 0)
				{
					break;
				}
				int index = value.Count - 1;
				GameObject obj = value[index];
				value.RemoveAt(index);
				obj.GetComponent<IPooledObject>().Free();
			}
		}

		protected Vector3 GetPosition()
		{
			float x = UnityEngine.Random.Range(-10, 10);
			float y = UnityEngine.Random.Range(-5, 5);
			float z = UnityEngine.Random.Range(-10, 10);
			return new Vector3(x, y, z);
		}
	}
}
