using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Scripts.Tools
{
	public static class NativeMeshTools
	{
		private static class NativeMethods
		{
			[DllImport("SR2Native", EntryPoint = "Rendering_CompletePendingAsyncMeshUpdates")]
			public static extern IntPtr CompletePendingAsyncMeshUpdates();

			[DllImport("SR2Native", EntryPoint = "Rendering_CompletePendingAsyncMeshUpdatesImmediately")]
			public static extern void CompletePendingAsyncMeshUpdatesImmediately();

			[DllImport("SR2Native", EntryPoint = "Rendering_UpdateMesh")]
			public static extern int UpdateMesh(IntPtr vertexBufferHandle, int vertexCount, IntPtr sourceVertices, IntPtr sourceNormals, IntPtr sourceColors, IntPtr sourceUVs);

			[DllImport("SR2Native", EntryPoint = "Rendering_UpdateMeshAsync")]
			public static extern int UpdateMeshAsync(IntPtr vertexBufferHandle, int vertexCount, IntPtr sourceVertices, IntPtr sourceNormals, IntPtr sourceColors, IntPtr sourceUVs);
		}

		public static void CompletePendingAsyncMeshUpdates()
		{
			GL.IssuePluginEvent(NativeMethods.CompletePendingAsyncMeshUpdates(), 0);
		}

		public static void CompletePendingAsyncMeshUpdatesImmediately()
		{
			NativeMethods.CompletePendingAsyncMeshUpdatesImmediately();
		}

		public static void UpdateMesh(IntPtr vertexBufferHandle, int vertexCount, Vector3[] sourceVertices, Vector3[] sourceNormals, Color[] sourceColors, Vector2[] sourceUVs)
		{
			GCHandle gCHandle = GCHandle.Alloc(sourceVertices, GCHandleType.Pinned);
			GCHandle gCHandle2 = GCHandle.Alloc(sourceNormals, GCHandleType.Pinned);
			GCHandle gCHandle3 = GCHandle.Alloc(sourceColors, GCHandleType.Pinned);
			GCHandle gCHandle4 = GCHandle.Alloc(sourceUVs, GCHandleType.Pinned);
			NativeMethods.UpdateMesh(vertexBufferHandle, vertexCount, gCHandle.AddrOfPinnedObject(), gCHandle2.AddrOfPinnedObject(), gCHandle3.AddrOfPinnedObject(), gCHandle4.AddrOfPinnedObject());
			gCHandle.Free();
			gCHandle2.Free();
			gCHandle3.Free();
			gCHandle4.Free();
		}

		public static void UpdateMeshAsync(IntPtr vertexBufferHandle, int vertexCount, Vector3[] sourceVertices, Vector3[] sourceNormals, Color[] sourceColors, Vector2[] sourceUVs)
		{
			GCHandle gCHandle = GCHandle.Alloc(sourceVertices, GCHandleType.Pinned);
			GCHandle gCHandle2 = GCHandle.Alloc(sourceNormals, GCHandleType.Pinned);
			GCHandle gCHandle3 = GCHandle.Alloc(sourceColors, GCHandleType.Pinned);
			GCHandle gCHandle4 = GCHandle.Alloc(sourceUVs, GCHandleType.Pinned);
			NativeMethods.UpdateMeshAsync(vertexBufferHandle, vertexCount, gCHandle.AddrOfPinnedObject(), gCHandle2.AddrOfPinnedObject(), gCHandle3.AddrOfPinnedObject(), gCHandle4.AddrOfPinnedObject());
			gCHandle.Free();
			gCHandle2.Free();
			gCHandle3.Free();
			gCHandle4.Free();
		}
	}
}
