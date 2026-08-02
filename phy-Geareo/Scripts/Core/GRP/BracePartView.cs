using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class BracePartView : PartView<BracePartViewable>
	{
		public Transform box;

		public BraceLine line;

		public Transform right;

		public Transform left;

		public Transform top;

		public Transform bottom;

		public Transform forward;

		public Transform back;

		public Renderer[] renderers;

		public MaterialPropertyBlock[] materialBlocks;

		public BracePartView currentConn { get; private set; }

		protected override void OnViewCreated()
		{
		}

		protected override void OnViewClose()
		{
		}

		protected override void OnRender()
		{
		}

		private void Render()
		{
		}

		public List<PartView> GetNeighbors()
		{
			return null;
		}
	}
}
