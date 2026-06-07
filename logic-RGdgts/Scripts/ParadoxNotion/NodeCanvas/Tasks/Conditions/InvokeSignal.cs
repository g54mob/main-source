using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class InvokeSignal : ActionTask<Transform>
	{
		public BBParameter<SignalDefinition> signalDefinition;

		public bool global;

		[SerializeField]
		private Dictionary<string, BBObjectParameter> argumentsMap;

		private object[] args;

		protected override string info => null;

		protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
		}
	}
}
