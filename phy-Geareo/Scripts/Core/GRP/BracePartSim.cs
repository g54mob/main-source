using UnityEngine;

namespace GRP
{
	public class BracePartSim : PartSim<BracePart>
	{
		public BoxShape braceShape;

		public Transform box;

		public BraceLine line;

		public Renderer[] renderers;

		public MaterialPropertyBlock[] materialBlocks;

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		protected override void Begin()
		{
		}
	}
}
