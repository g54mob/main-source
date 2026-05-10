using System;
using UnityEngine;

namespace Animancer
{
	public class Float2ControllerState : ControllerState
	{
		public new interface ITransition : ITransition<Float2ControllerState>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		private ParameterID _ParameterXID;

		private ParameterID _ParameterYID;

		public ParameterID ParameterXID
		{
			get
			{
				return _ParameterXID;
			}
			set
			{
				_ParameterXID = value;
			}
		}

		public float ParameterX
		{
			get
			{
				return base.Playable.GetFloat(_ParameterXID.Hash);
			}
			set
			{
				base.Playable.SetFloat(_ParameterXID.Hash, value);
			}
		}

		public ParameterID ParameterYID
		{
			get
			{
				return _ParameterYID;
			}
			set
			{
				_ParameterYID = value;
			}
		}

		public float ParameterY
		{
			get
			{
				return base.Playable.GetFloat(_ParameterYID.Hash);
			}
			set
			{
				base.Playable.SetFloat(_ParameterYID.Hash, value);
			}
		}

		public Vector2 Parameter
		{
			get
			{
				return new Vector2(ParameterX, ParameterY);
			}
			set
			{
				ParameterX = value.x;
				ParameterY = value.y;
			}
		}

		public override int ParameterCount => 2;

		public Float2ControllerState(RuntimeAnimatorController controller, ParameterID parameterX, ParameterID parameterY, params ActionOnStop[] actionsOnStop)
			: base(controller, actionsOnStop)
		{
			_ParameterXID = parameterX;
			_ParameterYID = parameterY;
		}

		public Float2ControllerState(RuntimeAnimatorController controller, ParameterID parameterX, ParameterID parameterY)
			: this(controller, parameterX, parameterY, null)
		{
		}

		public override int GetParameterHash(int index)
		{
			return index switch
			{
				0 => _ParameterXID, 
				1 => _ParameterYID, 
				_ => throw new ArgumentOutOfRangeException("index"), 
			};
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			Float2ControllerState float2ControllerState = new Float2ControllerState(base.Controller, _ParameterXID, _ParameterYID);
			float2ControllerState.SetNewCloneRoot(root);
			((ICopyable<ControllerState>)float2ControllerState).CopyFrom((ControllerState)this);
			return float2ControllerState;
		}
	}
}
