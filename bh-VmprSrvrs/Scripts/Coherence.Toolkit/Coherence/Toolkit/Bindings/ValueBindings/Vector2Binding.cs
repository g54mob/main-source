using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class Vector2Binding : ValueBinding<Vector2>
	{
		public override Vector2 Value
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		protected Vector2Binding()
		{
		}

		public Vector2Binding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override Vector2 ClampToRange(in Vector2 value, long minRange, long maxRange)
		{
			return default(Vector2);
		}

		protected override bool DiffersFrom(Vector2 first, Vector2 second)
		{
			return false;
		}

		protected override Vector2 GetCompressedValue(Vector2 value)
		{
			return default(Vector2);
		}
	}
}
