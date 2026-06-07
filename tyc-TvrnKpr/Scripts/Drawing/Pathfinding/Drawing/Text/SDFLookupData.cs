using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Pathfinding.Drawing.Text
{
	internal struct SDFLookupData
	{
		public NativeArray<SDFCharacter> characters;

		private Dictionary<char, int> lookup;

		public Material material;

		public const ushort Newline = 65535;

		public SDFLookupData(SDFFont font)
		{
			characters = default(NativeArray<SDFCharacter>);
			lookup = null;
			material = null;
		}

		public int GetIndex(char c)
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
