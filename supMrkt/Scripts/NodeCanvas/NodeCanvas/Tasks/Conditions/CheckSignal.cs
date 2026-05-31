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
		private Dictionary<string, BBObjectParameter> argumentsMap;

		protected override string info => null;

		protected override string OnInit()
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void OnSignalInvoke(Transform sender, Transform receiver, bool isGlobal, params object[] args)
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
