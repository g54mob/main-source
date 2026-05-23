using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

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

		internal readonly List<int> cachedTextIds = new List<int>();

		internal readonly List<UnityEngine.Object> cachedAssets = new List<UnityEngine.Object>();

		internal readonly List<DisposableMesh> cachedMeshes = new List<DisposableMesh>();

		internal readonly List<ShapeDrawCall> drawCalls = new List<ShapeDrawCall>();

		public RenderPassEvent camEvt;

		internal static bool IsAddingDrawCommandsToBuffer => drawCommandWriteNestLevel > 0;

		internal static DrawCommand CurrentWritingCommandBuffer => cBuffersWriting.Peek();

		static DrawCommand()
		{
			cBuffersWriting = new Stack<DrawCommand>();
			cBuffersRendering = new Dictionary<Camera, List<DrawCommand>>();
			SceneManager.sceneUnloaded += delegate
			{
				FlushNullCameras();
			};
		}

		public static void ClearAllCommands()
		{
			FlushNullCameras();
			foreach (List<DrawCommand> value in cBuffersRendering.Values)
			{
				value.ForEach(delegate(DrawCommand cmd)
				{
					cmd.Clear();
				});
				value.Clear();
			}
			cBuffersRendering.Clear();
		}

		public static void FlushNullCameras()
		{
			foreach (KeyValuePair<Camera, List<DrawCommand>> item in cBuffersRendering.Where((KeyValuePair<Camera, List<DrawCommand>> kvp) => kvp.Key == null).ToList())
			{
				item.Value.ForEach(delegate(DrawCommand cmd)
				{
					cmd.Clear();
				});
				cBuffersRendering.Remove(item.Key);
			}
		}

		private static void RegisterCommand(DrawCommand cmd)
		{
			if (!cBuffersRendering.TryGetValue(cmd.cam, out var value))
			{
				cBuffersRendering.Add(cmd.cam, value = new List<DrawCommand>());
			}
			value.Add(cmd);
		}

		internal static void OnCommandRendered(DrawCommand cmd)
		{
			cmd.hasRendered = true;
			if (cBuffersRendering.TryGetValue(cmd.cam, out var value))
			{
				cmd.Clear();
				value.Remove(cmd);
			}
			else
			{
				Debug.LogError($"Tried to remove unlisted draw command {cmd.id}");
			}
		}

		internal DrawCommand Initialize(Camera cam, RenderPassEvent cameraEvent = RenderPassEvent.BeforeRenderingPostProcessing)
		{
			this.cam = cam;
			id = bufferID++;
			hasValidCamera = cam != null;
			if (!hasValidCamera)
			{
				Debug.LogWarning("null camera passed into DrawCommand, nothing will be drawn");
			}
			camEvt = cameraEvent;
			cBuffersWriting.Push(this);
			drawCommandWriteNestLevel++;
			pushPopState = ShapesConfig.Instance.pushPopStateInDrawCommands;
			if (pushPopState)
			{
				Draw.Push();
			}
			return this;
		}

		internal void AppendToBuffer(CommandBuffer cmd)
		{
			foreach (ShapeDrawCall drawCall in drawCalls)
			{
				drawCall.AddToCommandBuffer(cmd);
			}
		}

		private void Clear()
		{
			CleanupCachedAssetsAndMeshes();
			hasRendered = false;
			for (int i = 0; i < drawCalls.Count; i++)
			{
				drawCalls[i].Cleanup();
			}
			drawCalls.Clear();
			ObjectPool<DrawCommand>.Free(this);
		}

		private void CleanupCachedAssetsAndMeshes()
		{
			foreach (int cachedTextId in cachedTextIds)
			{
				ShapesTextPool.Instance.ReleaseElement(cachedTextId);
			}
			cachedTextIds.Clear();
			foreach (UnityEngine.Object cachedAsset in cachedAssets)
			{
				cachedAsset.DestroyBranched();
			}
			cachedAssets.Clear();
			foreach (DisposableMesh cachedMesh in cachedMeshes)
			{
				cachedMesh.ReleaseFromCommand(this);
			}
			cachedMeshes.Clear();
		}

		public void Dispose()
		{
			if (IMDrawer.metaMpbPrevious != null && IMDrawer.metaMpbPrevious.HasContent)
			{
				drawCalls.Add(IMDrawer.metaMpbPrevious.ExtractDrawCall());
			}
			if (hasValidCamera)
			{
				RegisterCommand(this);
			}
			drawCommandWriteNestLevel--;
			cBuffersWriting.Pop();
			if (pushPopState)
			{
				Draw.Pop();
			}
		}
	}
}
