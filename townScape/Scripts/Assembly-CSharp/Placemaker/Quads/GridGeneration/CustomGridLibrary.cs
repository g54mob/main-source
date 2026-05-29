using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Quads.GridGeneration
{
	[CreateAssetMenu]
	public class CustomGridLibrary : ScriptableObject
	{
		[SerializeField]
		public List<CustomGridPatch> allCustomPatches;

		public List<byte> genericPatches;

		public List<byte> straightPatches;

		public List<byte> centroidPatches;

		public List<byte> centroidCurvePatches;

		public CustomGridPatch GetRandom(List<byte> list, ref Unity.Mathematics.Random random)
		{
			return null;
		}
	}
}
