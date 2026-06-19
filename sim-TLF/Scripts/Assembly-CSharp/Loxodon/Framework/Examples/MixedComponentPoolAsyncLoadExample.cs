using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loxodon.Framework.ObjectPool;
using UnityEngine;

namespace Loxodon.Framework.Examples
{
	public class MixedComponentPoolAsyncLoadExample : MonoBehaviour
	{
		public class PooledCube : MonoBehaviour, IPooledObject
		{
			public Color color;

			public IMixedObjectPool<PooledCube> pool;

			public string typeName;

			public bool IsLoaded;

			private GameObject child;

			public async Task<GameObject> LoadAsync()
			{
				if (IsLoaded)
				{
					return child;
				}
				GameObject original = (GameObject)(await Resources.LoadAsync<GameObject>("Cube/Cube"));
				child = UnityEngine.Object.Instantiate(original, base.transform);
				child.GetComponent<MeshRenderer>().material.color = color;
				IsLoaded = true;
				return child;
			}

			public void Free()
			{
				if (pool != null)
				{
					pool.Free(typeName, this);
				}
			}
		}

		public class CubeMixedObjectFactory : IMixedObjectFactory<PooledCube>
		{
			private Transform parent;

			public CubeMixedObjectFactory(Transform parent)
			{
				this.parent = parent;
			}

			public PooledCube Create(IMixedObjectPool<PooledCube> pool, string typeName)
			{
				Debug.LogFormat("Create a cube.");
				GameObject gameObject = new GameObject($"Cube {typeName}-Idle");
				gameObject.transform.SetParent(parent);
				PooledCube pooledCube = gameObject.AddComponent<PooledCube>();
				pooledCube.pool = pool;
				pooledCube.typeName = typeName;
				pooledCube.color = GetColor(typeName);
				return pooledCube;
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

			public virtual void Reset(string typeName, PooledCube obj)
			{
				obj.gameObject.SetActive(value: false);
				obj.gameObject.name = $"Cube {typeName}-Idle";
				obj.gameObject.transform.position = Vector3.zero;
				obj.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
			}

			public virtual void Destroy(string typeName, PooledCube obj)
			{
				UnityEngine.Object.Destroy(obj.gameObject);
				Debug.LogFormat("Destroy a cube.");
			}

			public virtual bool Validate(string typeName, PooledCube obj)
			{
				return true;
			}
		}

		private IMixedObjectPool<PooledCube> pool;

		private Dictionary<string, List<PooledCube>> dict;

		private void Start()
		{
			CubeMixedObjectFactory factory = new CubeMixedObjectFactory(base.transform);
			pool = new MixedObjectPool<PooledCube>(factory, 5);
			dict = new Dictionary<string, List<PooledCube>>();
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

		protected async Task Add(string typeName, int count)
		{
			if (!dict.TryGetValue(typeName, out var list))
			{
				list = new List<PooledCube>();
				dict.Add(typeName, list);
			}
			for (int i = 0; i < count; i++)
			{
				PooledCube cube = pool.Allocate(typeName);
				if (!cube.IsLoaded)
				{
					await cube.LoadAsync();
				}
				cube.gameObject.transform.position = GetPosition();
				cube.gameObject.name = $"Cube {typeName}-{list.Count}";
				cube.gameObject.SetActive(value: true);
				list.Add(cube);
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
				PooledCube pooledCube = value[index];
				value.RemoveAt(index);
				pooledCube.Free();
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
