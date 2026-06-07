using System;
using UnityEngine.Scripting;

namespace SQLite
{
	[AttributeUsage(AttributeTargets.Property)]
	public class NotNullAttribute : UnityEngine.Scripting.PreserveAttribute
	{
	}
}
