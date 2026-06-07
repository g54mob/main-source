using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class SwitchType : PropertyAttribute
	{
		public Type ParentType { get; private set; }

		public SwitchType(Type parentType)
		{
		}
	}
}
