using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class ListPrefabsAttribute : PropertyAttribute
	{
		public Type[] requiredComponents { get; set; }

		public ListPrefabsAttribute(params Type[] components)
		{
		}
	}
}
