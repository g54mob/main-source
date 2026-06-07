using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	internal class CheckStaticCSharpEvent
	{
		[SerializeField]
		public Type targetType;

		[SerializeField]
		public string eventName;
	}
	internal class CheckStaticCSharpEvent<T>
	{
		[SerializeField]
		public Type targetType;

		[SerializeField]
		public string eventName;
	}
}
