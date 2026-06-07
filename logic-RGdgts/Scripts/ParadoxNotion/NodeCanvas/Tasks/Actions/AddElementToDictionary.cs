using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class AddElementToDictionary<T> : ActionTask
	{
		[BlackboardOnly]
		[RequiredField]
		public BBParameter<Dictionary<string, T>> dictionary;

		public BBParameter<string> key;

		public BBParameter<T> value;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
