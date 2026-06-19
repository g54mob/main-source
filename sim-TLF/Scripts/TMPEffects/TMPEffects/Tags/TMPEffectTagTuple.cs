using System;

namespace TMPEffects.Tags
{
	public readonly struct TMPEffectTagTuple : IEquatable<TMPEffectTagTuple>
	{
		public readonly TMPEffectTag Tag;

		public readonly TMPEffectTagIndices Indices;

		public TMPEffectTagTuple(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			Tag = tag;
			Indices = indices;
		}

		public bool Equals(TMPEffectTagTuple other)
		{
			if (Tag.Equals(other.Tag))
			{
				return Indices.Equals(other.Indices);
			}
			return false;
		}
	}
}
