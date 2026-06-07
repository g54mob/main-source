using System;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Obsolete]
	public class CheckUnityObject : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<UnityEngine.Object> valueA;

		public BBParameter<UnityEngine.Object> valueB;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
