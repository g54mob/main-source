using System;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public class Float1ControllerTransition : ControllerTransition<Float1ControllerState>, Float1ControllerState.ITransition, ITransition<Float1ControllerState>, ITransition, IHasKey, IPolymorphic, ICopyable<Float1ControllerTransition>
	{
		[SerializeField]
		private string _ParameterName;

		public ref string ParameterName => ref _ParameterName;

		public Float1ControllerTransition()
		{
		}

		public Float1ControllerTransition(RuntimeAnimatorController controller, string parameterName)
		{
			base.Controller = controller;
			_ParameterName = parameterName;
		}

		public override Float1ControllerState CreateState()
		{
			return base.State = new Float1ControllerState(base.Controller, _ParameterName, base.ActionsOnStop);
		}

		public virtual void CopyFrom(Float1ControllerTransition copyFrom)
		{
			CopyFrom((ControllerTransition<Float1ControllerState>)copyFrom);
			if (copyFrom == null)
			{
				_ParameterName = null;
			}
			else
			{
				_ParameterName = copyFrom._ParameterName;
			}
		}
	}
}
