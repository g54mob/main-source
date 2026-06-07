using System;
using UnityEngine;

namespace Animancer
{
	public class Float3ControllerState : ControllerState
	{
		public new interface ITransition : ITransition<Float3ControllerState>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		private ParameterID _ParameterXID;

		private ParameterID _ParameterYID;

		private ParameterID _ParameterZID;

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

		public ParameterID ParameterZID
		{
			get
			{
				return _ParameterZID;
			}
			set
			{
				_ParameterZID = value;
			}
		}

		public float ParameterZ
		{
			get
			{
				return base.Playable.GetFloat(_ParameterZID.Hash);
			}
			set
			{
				base.Playable.SetFloat(_ParameterZID.Hash, value);
			}
		}

		public Vector3 Parameter
		{
			get
			{
				return new Vector3(ParameterX, ParameterY, ParameterZ);
			}
			set
			{
				ParameterX = value.x;
				ParameterY = value.y;
				ParameterZ = value.z;
			}
		}

		public override int ParameterCount => 3;

		public Float3ControllerState(RuntimeAnimatorController controller, ParameterID parameterX, ParameterID parameterY, ParameterID parameterZ, params ActionOnStop[] actionsOnStop)
			: base(controller, actionsOnStop)
		{
			_ParameterXID = parameterX;
			_ParameterYID = parameterY;
			_ParameterZID = parameterZ;
		}

		public Float3ControllerState(RuntimeAnimatorController controller, ParameterID parameterX, ParameterID parameterY, ParameterID parameterZ)
			: this(controller, parameterX, parameterY, parameterZ, null)
		{
		}

		public override int GetParameterHash(int index)
		{
			return index switch
			{
				0 => _ParameterXID, 
				1 => _ParameterYID, 
				2 => _ParameterZID, 
				_ => throw new ArgumentOutOfRangeException("index"), 
			};
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			Float3ControllerState float3ControllerState = new Float3ControllerState(base.Controller, _ParameterXID, _ParameterYID, _ParameterZID);
			float3ControllerState.SetNewCloneRoot(root);
			((ICopyable<ControllerState>)float3ControllerState).CopyFrom((ControllerState)this);
			return float3ControllerState;
		}
	}
}
