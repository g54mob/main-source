using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class FloatBinding : ValueBinding<float>
	{
		public override float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected FloatBinding()
		{
		}

		public FloatBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override float ClampToRange(in float value, long minRange, long maxRange)
		{
			return 0f;
		}

		protected override bool DiffersFrom(float first, float second)
		{
			return false;
		}

		protected override float GetCompressedValue(float value)
		{
			return 0f;
		}

		internal static float ClampValueToRange(in float value, long minRange, long maxRange)
		{
			return 0f;
		}
	}
}
