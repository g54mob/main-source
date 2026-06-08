using UnityEngine;

namespace GRP
{
	public class ConfigEntry : ScriptableObject
	{
		public virtual void SetConfig(Object obj)
		{
		}
	}
	public class ConfigEntry<T> : ConfigEntry where T : Object
	{
		public T config;

		public override void SetConfig(Object obj)
		{
		}

		public static implicit operator T(ConfigEntry<T> entry)
		{
			return null;
		}
	}
}
