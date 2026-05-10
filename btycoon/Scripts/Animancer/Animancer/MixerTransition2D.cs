using System;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public class MixerTransition2D : MixerTransition<MixerState<Vector2>, Vector2>, ManualMixerState.ITransition2D, ITransition<MixerState<Vector2>>, ITransition, IHasKey, IPolymorphic, ICopyable<MixerTransition2D>
	{
		public enum MixerType
		{
			Cartesian = 0,
			Directional = 1
		}

		[SerializeField]
		private MixerType _Type;

		public ref MixerType Type => ref _Type;

		public override MixerState<Vector2> CreateState()
		{
			switch (_Type)
			{
			case MixerType.Cartesian:
				base.State = new CartesianMixerState();
				break;
			case MixerType.Directional:
				base.State = new DirectionalMixerState();
				break;
			default:
				throw new ArgumentOutOfRangeException("_Type");
			}
			InitializeState();
			return base.State;
		}

		public virtual void CopyFrom(MixerTransition2D copyFrom)
		{
			CopyFrom((MixerTransition<MixerState<Vector2>, Vector2>)copyFrom);
			if (copyFrom == null)
			{
				_Type = MixerType.Cartesian;
			}
			else
			{
				_Type = copyFrom._Type;
			}
		}
	}
}
