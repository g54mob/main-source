using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Utility")]
	[Description("Invoke a defined Signal with agent as the target and optionally global.")]
	public class InvokeSignal : ActionTask<Transform>
	{
		public BBParameter<SignalDefinition> signalDefinition;

		public bool global;

		[SerializeField]
		private Dictionary<string, BBObjectParameter> argumentsMap = new Dictionary<string, BBObjectParameter>();

		private object[] args;

		protected override string info => signalDefinition.ToString();

		protected override string OnInit()
		{
			if (signalDefinition.isNoneOrNull)
			{
				return "Missing Definition";
			}
			args = new object[argumentsMap.Count];
			return null;
		}

		protected override void OnExecute()
		{
			SignalDefinition value = signalDefinition.value;
			for (int i = 0; i < value.parameters.Count; i++)
			{
				args[i] = argumentsMap[value.parameters[i].ID].value;
			}
			value.Invoke(base.agent, base.agent, global, args);
			EndAction();
		}
	}
}
