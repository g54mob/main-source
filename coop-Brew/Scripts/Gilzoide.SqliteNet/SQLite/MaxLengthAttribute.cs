using System;
using UnityEngine.Scripting;

namespace SQLite
{
	[AttributeUsage(AttributeTargets.Property)]
	public class MaxLengthAttribute : UnityEngine.Scripting.PreserveAttribute
	{
		public int Value { get; private set; }

		public MaxLengthAttribute(int length)
		{
		}
	}
}
