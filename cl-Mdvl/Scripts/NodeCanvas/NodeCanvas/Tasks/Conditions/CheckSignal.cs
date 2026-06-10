using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Utility")]
	[Description("Check for an invoked Signal with agent as the target. If Signal was invoked as global, then the target does not matter.")]
	public class CheckSignal : ConditionTask<Transform>
	{
		public BBParameter<SignalDefinition> signalDefinition;

		[SerializeField]
		private Dictionary<string, BBObjectParameter> argumentsMap = new Dictionary<string, BBObjectParameter>();

		protected override string info => signalDefinition.ToString();

		protected override string OnInit()
		{
			if (signalDefinition.isNoneOrNull)
			{
				return "Missing Definition";
			}
			return null;
		}

		protected override void OnEnable()
		{
			signalDefinition.value.onInvoke -= OnSignalInvoke;
			signalDefinition.value.onInvoke += OnSignalInvoke;
		}

		protected override void OnDisable()
		{
			signalDefinition.value.onInvoke -= OnSignalInvoke;
		}

		private void OnSignalInvoke(Transform sender, Transform receiver, bool isGlobal, params object[] args)
		{
			if (receiver == base.agent || isGlobal)
			{
				SignalDefinition value = signalDefinition.value;
				for (int i = 0; i < args.Length; i++)
				{
					argumentsMap[value.parameters[i].ID].value = args[i];
				}
				YieldReturn(value: true);
			}
		}

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
