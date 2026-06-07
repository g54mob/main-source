using System;
using System.Collections.Generic;

namespace UMA
{
	[Serializable]
	public class UMAPredefinedDNA
	{
		public List<DnaValue> PreloadValues;

		public int Count => 0;

		public void RemoveDNA(string Name)
		{
		}

		public bool ContainsName(string Name)
		{
			return false;
		}

		public void AddRange(UMAPredefinedDNA newDNA)
		{
		}

		public void AddDNA(string Name, float Value)
		{
		}

		public void Clear()
		{
		}

		public float GetValue(string Name)
		{
			return 0f;
		}

		public UMAPredefinedDNA Clone()
		{
			return null;
		}
	}
}
