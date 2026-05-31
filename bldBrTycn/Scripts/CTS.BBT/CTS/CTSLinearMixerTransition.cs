using System;
using Animancer;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class CTSLinearMixerTransition : LinearMixerTransition, ICTSTransition
	{
		[SerializeField]
		private string _parameterKey = "Parameter";

		public bool ApplyRootMotion { get; set; }

		[field: SerializeField]
		public ELayer Layer { get; set; }

		[field: SerializeField]
		public EEndEvent EndEvent { get; set; }

		public int ParameterKey { get; set; }

		public override LinearMixerState CreateState()
		{
			ParameterKey = Animator.StringToHash(_parameterKey);
			return base.CreateState();
		}

		public override void Apply(AnimancerState state)
		{
			base.Apply(state);
			state.Root.Component.Animator.applyRootMotion = ApplyRootMotion;
		}

		public ITransition GetTransition()
		{
			return this;
		}
	}
}
