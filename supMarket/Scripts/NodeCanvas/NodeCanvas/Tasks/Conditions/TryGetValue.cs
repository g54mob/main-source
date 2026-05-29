using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard/Dictionaries")]
	public class TryGetValue<T> : ConditionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<Dictionary<string, T>> targetDictionary;

		[RequiredField]
		public BBParameter<string> key;

		[BlackboardOnly]
		public BBParameter<T> saveValueAs;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
