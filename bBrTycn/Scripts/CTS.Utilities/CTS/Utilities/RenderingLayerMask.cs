using System;
using UnityEngine;

namespace CTS.Utilities
{
	[Serializable]
	public struct RenderingLayerMask : IEquatable<RenderingLayerMask>, IEquatable<uint>
	{
		[SerializeField]
		private uint _mask;

		public static implicit operator uint(RenderingLayerMask mask)
		{
			return mask._mask;
		}

		public static implicit operator RenderingLayerMask(uint value)
		{
			return new RenderingLayerMask
			{
				_mask = value
			};
		}

		public bool Equals(RenderingLayerMask other)
		{
			return _mask == other._mask;
		}

		public bool Equals(uint other)
		{
			return _mask == other;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RenderingLayerMask other))
			{
				if (obj is uint other2)
				{
					return Equals(other2);
				}
				return base.Equals(obj);
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return _mask.GetHashCode();
		}
	}
}
