using System;
using UnityEngine.Scripting;

namespace SQLite
{
	[AttributeUsage(AttributeTargets.Property)]
	public class PrimaryKeyAttribute : UnityEngine.Scripting.PreserveAttribute
	{
	}
}
