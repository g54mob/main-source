using System;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public class Float2ControllerTransition : ControllerTransition<Float2ControllerState>, Float2ControllerState.ITransition, ITransition<Float2ControllerState>, ITransition, IHasKey, IPolymorphic, ICopyable<Float2ControllerTransition>
	{
		[SerializeField]
		private string _ParameterNameX;

		[SerializeField]
		private string _ParameterNameY;

		public ref string ParameterNameX => ref _ParameterNameX;

		public ref string ParameterNameY => ref _ParameterNameY;

		public Float2ControllerTransition()
		{
		}

		public Float2ControllerTransition(RuntimeAnimatorController controller, string parameterNameX, string parameterNameY)
		{
			base.Controller = controller;
			_ParameterNameX = parameterNameX;
			_ParameterNameY = parameterNameY;
		}

		public override Float2ControllerState CreateState()
		{
			return base.State = new Float2ControllerState(base.Controller, _ParameterNameX, _ParameterNameY, base.ActionsOnStop);
		}

		public virtual void CopyFrom(Float2ControllerTransition copyFrom)
		{
			CopyFrom((ControllerTransition<Float2ControllerState>)copyFrom);
			if (copyFrom == null)
			{
				_ParameterNameX = null;
				_ParameterNameY = null;
			}
			else
			{
				_ParameterNameX = copyFrom._ParameterNameX;
				_ParameterNameY = copyFrom._ParameterNameY;
			}
		}
	}
}
