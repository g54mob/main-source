using System;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public abstract class MixerTransition<TMixer, TParameter> : ManualMixerTransition<TMixer>, ICopyable<MixerTransition<TMixer, TParameter>> where TMixer : MixerState<TParameter>
	{
		[SerializeField]
		private TParameter[] _Thresholds;

		public const string ThresholdsField = "_Thresholds";

		[SerializeField]
		private TParameter _DefaultParameter;

		public const string DefaultParameterField = "_DefaultParameter";

		public ref TParameter[] Thresholds => ref _Thresholds;

		public ref TParameter DefaultParameter => ref _DefaultParameter;

		public override void InitializeState()
		{
			base.InitializeState();
			base.State.SetThresholds(_Thresholds);
			base.State.Parameter = _DefaultParameter;
		}

		public virtual void CopyFrom(MixerTransition<TMixer, TParameter> copyFrom)
		{
			CopyFrom((ManualMixerTransition<TMixer>)copyFrom);
			if (copyFrom == null)
			{
				_DefaultParameter = default(TParameter);
				_Thresholds = null;
			}
			else
			{
				_DefaultParameter = copyFrom._DefaultParameter;
				AnimancerUtilities.CopyExactArray(copyFrom._Thresholds, ref _Thresholds);
			}
		}
	}
}
