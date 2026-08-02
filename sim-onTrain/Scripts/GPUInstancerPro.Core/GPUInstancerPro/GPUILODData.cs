using System;
using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	[Serializable]
	public class GPUILODData : IGPUIDisposable, IDisposable
	{
		public GPUIRendererData[] rendererDataArray;

		[NonSerialized]
		private List<GraphicsBuffer.IndirectDrawIndexedArgs> _commandBufferArgs;

		public int Length
		{
			get
			{
				if (rendererDataArray != null)
				{
					return rendererDataArray.Length;
				}
				return 0;
			}
		}

		public GPUIRendererData this[int index]
		{
			get
			{
				return rendererDataArray[index];
			}
			set
			{
				rendererDataArray[index] = value;
			}
		}

		public GPUILODData()
		{
			rendererDataArray = new GPUIRendererData[0];
		}

		public void Add(GPUIRendererData renderer)
		{
			if (rendererDataArray == null)
			{
				rendererDataArray = new GPUIRendererData[1];
				rendererDataArray[0] = renderer;
			}
			else
			{
				Array.Resize(ref rendererDataArray, Length + 1);
				rendererDataArray[Length - 1] = renderer;
			}
		}

		public void ReleaseBuffers()
		{
		}

		public void Dispose()
		{
			for (int i = 0; i < Length; i++)
			{
				this[i].Dispose();
			}
		}

		public bool IsShadowCasting()
		{
			for (int i = 0; i < Length; i++)
			{
				if (rendererDataArray[i].IsShadowCasting)
				{
					return true;
				}
			}
			return false;
		}

		internal void CreateCommandBufferArgs()
		{
			if (_commandBufferArgs == null)
			{
				_commandBufferArgs = new List<GraphicsBuffer.IndirectDrawIndexedArgs>();
			}
			else
			{
				_commandBufferArgs.Clear();
			}
			for (int i = 0; i < Length; i++)
			{
				GPUIRendererData gPUIRendererData = this[i];
				if (!(gPUIRendererData.rendererMesh != null))
				{
					continue;
				}
				int subMeshCount = gPUIRendererData.rendererMesh.subMeshCount;
				for (int j = 0; j < gPUIRendererData.rendererMaterials.Length; j++)
				{
					int num = j;
					if (subMeshCount <= num)
					{
						num = subMeshCount - 1;
					}
					_commandBufferArgs.Add(new GraphicsBuffer.IndirectDrawIndexedArgs
					{
						baseVertexIndex = gPUIRendererData.rendererMesh.GetBaseVertex(num),
						indexCountPerInstance = gPUIRendererData.rendererMesh.GetIndexCount(num),
						startIndex = gPUIRendererData.rendererMesh.GetIndexStart(num),
						instanceCount = 0u,
						startInstance = 0u
					});
				}
			}
		}

		internal List<GraphicsBuffer.IndirectDrawIndexedArgs> GetCommandBufferArgs()
		{
			if (_commandBufferArgs == null)
			{
				CreateCommandBufferArgs();
			}
			return _commandBufferArgs;
		}
	}
}
