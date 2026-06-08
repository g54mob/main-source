using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	public class DisposableMesh : IDisposable
	{
		private static int activeMeshCount;

		protected Mesh mesh;

		protected bool meshDirty;

		protected bool hasData;

		private bool hasMesh;

		private bool disposeWhenFullyReleased;

		internal List<DrawCommand> usedByCommands;

		public static int ActiveMeshCount => activeMeshCount;

		protected void EnsureMeshExists()
		{
			if (!hasData)
			{
				Debug.LogError("Mesh requested, but there's no data to generate a mesh from");
			}
			else if (!hasMesh || mesh == null)
			{
				mesh = new Mesh
				{
					hideFlags = HideFlags.DontSave
				};
				activeMeshCount++;
				hasMesh = true;
			}
		}

		internal void RegisterToCommandBuffer(DrawCommand cmd)
		{
			if (usedByCommands == null)
			{
				usedByCommands = ListPool<DrawCommand>.Alloc();
				Add();
			}
			else if (!usedByCommands.Contains(cmd))
			{
				Add();
			}
			void Add()
			{
				usedByCommands.Add(cmd);
				cmd.cachedMeshes.Add(this);
			}
		}

		internal void ReleaseFromCommand(DrawCommand cmd)
		{
			usedByCommands.Remove(cmd);
			if (usedByCommands.Count == 0 && disposeWhenFullyReleased)
			{
				Dispose();
			}
		}

		public void Dispose()
		{
			disposeWhenFullyReleased = true;
			bool flag = usedByCommands != null;
			if (flag && usedByCommands.Count == 0)
			{
				ListPool<DrawCommand>.Free(usedByCommands);
				usedByCommands = null;
				flag = false;
			}
			if (hasMesh && !flag)
			{
				mesh.DestroyBranched();
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
			if (!hasData)
			{
				outMesh = null;
				return false;
			}
			if (!hasMesh)
			{
				EnsureMeshExists();
				updateMesh();
				meshDirty = false;
			}
			else if (meshDirty)
			{
				updateMesh();
				meshDirty = false;
			}
			outMesh = mesh;
			return hasMesh;
		}
	}
}
