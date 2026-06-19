using System;

namespace TMPEffects.Tags
{
	public readonly struct TMPEffectTagTuple : IEquatable<TMPEffectTagTuple>
	{
		public readonly TMPEffectTag Tag;

		public readonly TMPEffectTagIndices Indices;

		public TMPEffectTagTuple(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			Tag = null;
			Indices = default(TMPEffectTagIndices);
		}

		public bool Equals(TMPEffectTagTuple other)
		{
			return false;
		}
	}
}
