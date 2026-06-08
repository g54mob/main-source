using System;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CViewDirectory : ISharedComponentData, IEquatable<CViewDirectory>
	{
		public AssetDirectory Directory;

		public Transform UIContainer;

		public Bounds UIBounds;

		public Camera UICamera;

		public bool Equals(CViewDirectory other)
		{
			if (object.Equals(Directory, other.Directory) && object.Equals(UIContainer, other.UIContainer) && UIBounds.Equals(other.UIBounds))
			{
				return UICamera.Equals(other.UICamera);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is CViewDirectory other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((((((Directory != null) ? Directory.GetHashCode() : 0) * 397) ^ ((UIContainer != null) ? UIContainer.GetHashCode() : 0)) * 397) ^ UIBounds.GetHashCode()) * 397) ^ UICamera.GetHashCode();
		}

		public static bool operator ==(CViewDirectory left, CViewDirectory right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(CViewDirectory left, CViewDirectory right)
		{
			return !left.Equals(right);
		}
	}
}
