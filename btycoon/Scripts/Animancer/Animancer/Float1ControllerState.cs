using UnityEngine;

namespace Animancer
{
	public class Float1ControllerState : ControllerState
	{
		public new interface ITransition : ITransition<Float1ControllerState>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		private ParameterID _ParameterID;

		public new ParameterID ParameterID
		{
			get
			{
				return _ParameterID;
			}
			set
			{
				_ParameterID = value;
			}
		}

		public float Parameter
		{
			get
			{
				return base.Playable.GetFloat(_ParameterID.Hash);
			}
			set
			{
				base.Playable.SetFloat(_ParameterID.Hash, value);
			}
		}

		public override int ParameterCount => 1;

		public Float1ControllerState(RuntimeAnimatorController controller, ParameterID parameter, params ActionOnStop[] actionsOnStop)
			: base(controller, actionsOnStop)
		{
			_ParameterID = parameter;
		}

		public Float1ControllerState(RuntimeAnimatorController controller, ParameterID parameter)
			: this(controller, parameter, null)
		{
		}

		public override int GetParameterHash(int index)
		{
			return _ParameterID;
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			Float1ControllerState float1ControllerState = new Float1ControllerState(base.Controller, _ParameterID);
			float1ControllerState.SetNewCloneRoot(root);
			((ICopyable<ControllerState>)float1ControllerState).CopyFrom((ControllerState)this);
			return float1ControllerState;
		}
	}
}
