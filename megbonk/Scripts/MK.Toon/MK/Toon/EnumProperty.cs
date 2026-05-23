using System;
using UnityEngine;

namespace MK.Toon
{
	public class EnumProperty<T> : Property<T> where T : Enum
	{
		public EnumProperty(Uniform uniform, params string[] keywords)
			: base((Uniform)null, (string[])null)
		{
		}

		public override T GetValue(Material material)
		{
			return default(T);
		}

		public override void SetValue(Material material, T value)
		{
		}
	}
}
