using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetInstantiate : PropertyGetGameObject
	{
		public bool usePooling;

		public int size = 5;

		public bool hasDuration;

		public float duration = 10f;

		public PropertyGetInstantiate()
			: base(new GetGameObjectInstance())
		{
		}

		public PropertyGetInstantiate(PropertyTypeGetGameObject defaultType)
			: base(defaultType)
		{
		}

		public override GameObject Get(GameObject target)
		{
			return Get(new Args(target));
		}

		public override GameObject Get(Args args)
		{
			return Get(args, Vector3.zero);
		}

		public GameObject Get(Args args, Vector3 position)
		{
			return Get(args, position, Quaternion.identity);
		}

		public GameObject Get(Args args, Vector3 position, Quaternion rotation)
		{
			return Get(args, position, rotation, null);
		}

		public GameObject Get(Args args, Vector3 position, Quaternion rotation, Transform parent)
		{
			GameObject gameObject = base.Get(args);
			GameObject gameObject2 = null;
			if (gameObject == null)
			{
				return null;
			}
			if (usePooling)
			{
				gameObject2 = Singleton<PoolManager>.Instance.Pick(gameObject, position, rotation, size, hasDuration ? duration : (-1f));
				if (parent != null)
				{
					gameObject2.transform.SetParent(parent);
				}
			}
			else
			{
				gameObject2 = UnityEngine.Object.Instantiate(gameObject, position, rotation, parent);
			}
			return gameObject2;
		}

		public GameObject Get(GameObject target, Vector3 position)
		{
			return Get(new Args(target), position);
		}

		public GameObject Get(GameObject target, Vector3 position, Quaternion rotation)
		{
			return Get(new Args(target), position, rotation);
		}

		public GameObject Get(GameObject target, Vector3 position, Quaternion rotation, Transform parent)
		{
			return Get(new Args(target), position, rotation, parent);
		}
	}
}
