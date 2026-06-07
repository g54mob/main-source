using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	public class DrawCommand : IDisposable
	{
		private static int bufferID;

		private static int drawCommandWriteNestLevel;

		private static Stack<DrawCommand> cBuffersWriting;

		internal static Dictionary<Camera, List<DrawCommand>> cBuffersRendering;

		private bool hasValidCamera;

		internal bool hasRendered;

		internal int id;

		private bool pushPopState;

		private Camera cam;

		internal readonly List<int> cachedTextIds;

		internal readonly List<UnityEngine.Object> cachedAssets;

		internal readonly List<DisposableMesh> cachedMeshes;

		internal readonly List<ShapeDrawCall> drawCalls;

		private CameraEvent camEvt;

		private CommandBuffer cmdBuf;

		internal static bool IsAddingDrawCommandsToBuffer => false;

		internal static DrawCommand CurrentWritingCommandBuffer => null;

		static DrawCommand()
		{
		}

		public static void ClearAllCommands()
		{
		}

		public static void FlushNullCameras()
		{
		}

		private static void RegisterCommand(DrawCommand cmd)
		{
		}

		private static void OnPostRenderBuiltInRP(Camera cam)
		{
		}

		internal DrawCommand Initialize(Camera cam, CameraEvent cameraEvent = CameraEvent.BeforeImageEffects)
		{
			return null;
		}

		internal void AppendToBuffer(CommandBuffer cmd)
		{
		}

		private void Clear()
		{
		}

		private void CleanupCachedAssetsAndMeshes()
		{
		}

		public void Dispose()
		{
		}

		private bool CheckIfRenderIsDone()
		{
			return false;
		}

		private void AddToCamera()
		{
		}

		private void RemoveFromCamera()
		{
		}
	}
}
