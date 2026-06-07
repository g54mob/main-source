using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public class EnumMaskFieldAttribute : PropertyAttribute
	{
		public Type EnumType { get; private set; }

		private EnumMaskFieldAttribute()
		{
		}

		public EnumMaskFieldAttribute(Type type)
		{
		}
	}
}
