using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Dictionaries")]
	public class GetDictionaryElement<T> : ActionTask
	{
		[BlackboardOnly]
		[RequiredField]
		public BBParameter<Dictionary<string, T>> dictionary;

		public BBParameter<string> key;

		[BlackboardOnly]
		public BBParameter<T> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
