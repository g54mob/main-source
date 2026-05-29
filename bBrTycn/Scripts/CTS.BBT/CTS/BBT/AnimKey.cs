using System;
using UnityEngine;

namespace CTS.BBT
{
	[Serializable]
	public struct AnimKey
	{
		public int Id;

		public static implicit operator int(AnimKey key)
		{
			return key.Id;
		}

		public AnimKey(int id)
		{
			Id = id;
		}

		public AnimKey(string name)
		{
			Id = Animator.StringToHash(name);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override string ToString()
		{
			return Id.ToString();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is int))
			{
				if (obj is AnimKey animKey)
				{
					return Id.Equals(animKey.Id);
				}
				return false;
			}
			return Id.Equals(obj);
		}
	}
}
