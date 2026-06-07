using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SendEventToObjects : ActionTask
	{
		[RequiredField]
		public BBParameter<List<GameObject>> targetObjects;

		[RequiredField]
		public BBParameter<string> eventName;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
	public class SendEventToObjects<T> : ActionTask
	{
		[RequiredField]
		public BBParameter<List<GameObject>> targetObjects;

		[RequiredField]
		public BBParameter<string> eventName;

		public BBParameter<T> eventValue;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
