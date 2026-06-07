using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object")]
	public abstract class PropertyTypeGetGameObject : TPropertyTypeGet<GameObject>
	{
		public virtual T Get<T>(Args args) where T : Component
		{
			GameObject gameObject = Get(args);
			if (!(gameObject != null))
			{
				return null;
			}
			return gameObject.Get<T>();
		}

		public virtual T Get<T>(GameObject target) where T : Component
		{
			return Get<T>(new Args(target));
		}

		public virtual T Get<T>(Component component) where T : Component
		{
			return Get<T>(new Args(component));
		}
	}
}
