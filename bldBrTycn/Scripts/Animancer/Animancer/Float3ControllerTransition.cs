using System;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public class Float3ControllerTransition : ControllerTransition<Float3ControllerState>, Float3ControllerState.ITransition, ITransition<Float3ControllerState>, ITransition, IHasKey, IPolymorphic, ICopyable<Float3ControllerTransition>
	{
		[SerializeField]
		private string _ParameterNameX;

		[SerializeField]
		private string _ParameterNameY;

		[SerializeField]
		private string _ParameterNameZ;

		public ref string ParameterNameX => ref _ParameterNameX;

		public ref string ParameterNameY => ref _ParameterNameY;

		public ref string ParameterNameZ => ref _ParameterNameZ;

		public Float3ControllerTransition()
		{
		}

		public Float3ControllerTransition(RuntimeAnimatorController controller, string parameterNameX, string parameterNameY, string parameterNameZ)
		{
			base.Controller = controller;
			_ParameterNameX = parameterNameX;
			_ParameterNameY = parameterNameY;
			_ParameterNameZ = parameterNameZ;
		}

		public override Float3ControllerState CreateState()
		{
			return base.State = new Float3ControllerState(base.Controller, _ParameterNameX, _ParameterNameY, _ParameterNameZ, base.ActionsOnStop);
		}

		public virtual void CopyFrom(Float3ControllerTransition copyFrom)
		{
			CopyFrom((ControllerTransition<Float3ControllerState>)copyFrom);
			if (copyFrom == null)
			{
				_ParameterNameX = null;
				_ParameterNameY = null;
				_ParameterNameZ = null;
			}
			else
			{
				_ParameterNameX = copyFrom._ParameterNameX;
				_ParameterNameY = copyFrom._ParameterNameY;
				_ParameterNameZ = copyFrom._ParameterNameZ;
			}
		}
	}
}
