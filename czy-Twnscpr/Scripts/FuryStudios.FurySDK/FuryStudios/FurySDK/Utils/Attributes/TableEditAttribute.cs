using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class TableEditAttribute : PropertyAttribute
	{
		public Type Owner { get; private set; }

		public string[] FieldNames { get; private set; }

		public TableEditAttribute(Type owner, string fieldName)
		{
		}
	}
}
