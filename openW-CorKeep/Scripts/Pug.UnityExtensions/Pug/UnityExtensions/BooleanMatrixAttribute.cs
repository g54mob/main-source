using System;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public class BooleanMatrixAttribute : PropertyAttribute
	{
		public readonly string[] labels;

		public BooleanMatrixAttribute()
			: this(new string[0])
		{
		}

		public BooleanMatrixAttribute(string[] labels)
		{
			this.labels = labels;
		}

		public BooleanMatrixAttribute(Type enumType)
			: this(Enum.GetNames(enumType))
		{
		}
	}
}
