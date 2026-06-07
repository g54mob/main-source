using System;
using UnityEngine.Scripting;

namespace SQLite
{
	[AttributeUsage(AttributeTargets.Property)]
	public class AutoIncrementAttribute : UnityEngine.Scripting.PreserveAttribute
	{
	}
}
