using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace KitchenData
{
	public abstract class KitchenObject : SerializedScriptableObject
	{
		public static List<(KitchenObject, DateTime)> Timers = new List<(KitchenObject, DateTime)>();

		public static DateTime Start = DateTime.Now;

		protected override void OnAfterDeserialize()
		{
			Timers.Add((this, DateTime.Now));
		}
	}
}
