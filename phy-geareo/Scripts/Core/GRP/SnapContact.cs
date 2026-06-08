using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class SnapContact : PoolObject
	{
		public Renderer visual;

		public SnapResult result;

		public SnapContactColorField[] colorFields;

		private SnapContactMode lastMode;

		private MaterialPropertyBlock[] materialBlocks;

		protected override void OnCreated()
		{
		}

		public void SetMaterial(SnapContactMode mode)
		{
		}
	}
}
