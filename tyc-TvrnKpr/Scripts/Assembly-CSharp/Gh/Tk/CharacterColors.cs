using System;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class CharacterColors : IEquatable<CharacterColors>
	{
		public Color hair;

		public Color skin;

		public Color secondarySkin;

		public bool AreAnyNotSet()
		{
			return false;
		}

		public bool Equals(CharacterColors other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
