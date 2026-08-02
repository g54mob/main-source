using System;

namespace Polarith.AI.Move
{
	[Serializable]
	public class FleeNavMesh : SeekNavMesh
	{
		protected override float inversion => -1f;
	}
}
