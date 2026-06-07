using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class Vector3Binding : ValueBinding<Vector3>
	{
		public override Vector3 Value
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		protected Vector3Binding()
		{
		}

		public Vector3Binding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override Vector3 ClampToRange(in Vector3 value, long minRange, long maxRange)
		{
			return default(Vector3);
		}

		protected override bool DiffersFrom(Vector3 first, Vector3 second)
		{
			return false;
		}

		protected override Vector3 GetCompressedValue(Vector3 value)
		{
			return default(Vector3);
		}
	}
}
