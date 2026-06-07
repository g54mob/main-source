using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
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
