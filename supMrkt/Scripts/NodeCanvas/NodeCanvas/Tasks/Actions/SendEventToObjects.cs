using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
	[Description("Send a Graph Event to multiple gameobjects which should have a GraphOwner component attached.")]
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
	[Category("✫ Utility")]
	[Description("Send a Graph Event to multiple gameobjects which should have a GraphOwner component attached.")]
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
