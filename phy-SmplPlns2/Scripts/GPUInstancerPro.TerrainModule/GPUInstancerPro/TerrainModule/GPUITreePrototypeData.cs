using System;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	[Serializable]
	public class GPUITreePrototypeData : GPUIPrototypeData, IGPUIParameterBufferData
	{
		[SerializeField]
		public bool isApplyRotation = true;

		[SerializeField]
		public bool isApplyPrefabScale = true;

		[SerializeField]
		public bool isApplyHeight = true;

		internal GraphicsBuffer _treeInstanceDataBuffer;

		public GPUITreePrototypeData()
		{
		}

		public GPUITreePrototypeData(TreePrototype treePrototype)
		{
		}

		public override bool Initialize(GPUIPrototype prototype)
		{
			return base.Initialize(prototype);
		}

		public override void ReleaseBuffers()
		{
			base.ReleaseBuffers();
			if (_treeInstanceDataBuffer != null)
			{
				_treeInstanceDataBuffer.Release();
			}
		}
	}
}
