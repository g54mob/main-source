using System.Collections.Generic;
using UnityEngine;

namespace LaundryBear.PlatformServices
{
	public abstract class ChangeForPlatform<T> : MonoBehaviour, IEqualityComparer<Platform>
	{
		[SerializeField]
		protected SerializableDictionary<Platform, T> m_platformData;

		public ChangeForPlatform()
		{
			m_platformData = new SerializableDictionary<Platform, T>(this);
		}

		protected bool GetPlatformSpecificObject(Platform platform, out T obj)
		{
			foreach (KeyValuePair<Platform, T> platformDatum in m_platformData)
			{
				if (Equals(platformDatum.Key, platform))
				{
					obj = platformDatum.Value;
					return true;
				}
			}
			obj = default(T);
			return false;
		}

		public bool Equals(Platform x, Platform y)
		{
			return (x | y) > Platform.None;
		}

		public int GetHashCode(Platform obj)
		{
			return (int)obj;
		}
	}
}
