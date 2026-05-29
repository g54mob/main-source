using System;
using UnityEngine;

namespace Placemaker.Modules
{
	[Serializable]
	public struct OrientedModule
	{
		public ushort moduleIndex;

		[SerializeField]
		private byte flags;

		public static readonly OrientedModule empty;

		public int orientation
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool isDecor
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool isEmpty
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool operator ==(OrientedModule a, OrientedModule b)
		{
			return false;
		}

		public static bool operator !=(OrientedModule a, OrientedModule b)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
