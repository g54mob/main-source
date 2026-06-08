using System;
using UnityEngine;

namespace Shapes
{
	public class DisposableMesh : IDisposable
	{
		private static int activeMeshCount;

		protected Mesh mesh;

		protected bool meshDirty;

		private bool hasMesh;

		public static int ActiveMeshCount => activeMeshCount;

		protected void EnsureMeshExists()
		{
			if (!hasMesh || mesh == null)
			{
				mesh = new Mesh
				{
					hideFlags = HideFlags.DontSave
				};
				activeMeshCount++;
				hasMesh = true;
			}
		}

		public void Dispose()
		{
			if (hasMesh)
			{
				if (DrawCommand.IsAddingDrawCommandsToBuffer)
				{
					DrawCommand.CurrentWritingCommandBuffer.cachedAssets.Add(mesh);
				}
				else
				{
					mesh.DestroyBranched();
				}
				activeMeshCount--;
				hasMesh = false;
			}
		}

		protected void ClearMesh()
		{
			if (hasMesh)
			{
				mesh.Clear();
			}
		}

		protected virtual bool ExternallyDirty()
		{
			return false;
		}

		protected virtual void UpdateMesh()
		{
		}

		protected bool EnsureMeshIsReadyToRender(out Mesh outMesh, Action updateMesh)
		{
			if (!hasMesh)
			{
				outMesh = null;
				return false;
			}
			updateMesh();
			outMesh = mesh;
			return hasMesh;
		}
	}
}
