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

		public static Dictionary<Camera, List<DrawCommand>> cBuffersRendering;

		public bool hasValidCamera;

		public readonly string name;

		public readonly Camera cam;

		public List<UnityEngine.Object> cachedAssets = new List<UnityEngine.Object>();

		internal List<ShapeDrawCall> drawCalls = new List<ShapeDrawCall>();

		public readonly RenderPassEvent camEvt;

		internal static bool IsAddingDrawCommandsToBuffer => drawCommandWriteNestLevel > 0;

		internal static DrawCommand CurrentWritingCommandBuffer => cBuffersWriting.Peek();

		private ShapeDrawCall PrevDrawCall
		{
			get
			{
				if (drawCalls.Count <= 0)
				{
					return null;
				}
				return drawCalls[drawCalls.Count - 1];
			}
		}

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
			if (cBuffersRendering.TryGetValue(cmd.cam, out var value))
			{
				cmd.Clear();
				value.Remove(cmd);
			}
			else
			{
				Debug.LogError("Tried to remove unlisted draw command " + cmd.name);
			}
		}

		internal DrawCommand(Camera cam, RenderPassEvent cameraEvent = RenderPassEvent.BeforeRenderingPostProcessing)
		{
			this.cam = cam;
			hasValidCamera = cam != null;
			if (!hasValidCamera)
			{
				Debug.LogWarning("null camera passed into DrawCommand, nothing will be drawn");
			}
			camEvt = cameraEvent;
			name = "Shapes Draw Command " + bufferID++;
			cBuffersWriting.Push(this);
			drawCommandWriteNestLevel++;
		}

		public void AppendToBuffer(CommandBuffer cmd)
		{
			foreach (ShapeDrawCall drawCall in drawCalls)
			{
				drawCall.AddToCommandBuffer(cmd);
			}
		}

		private void Clear()
		{
			CleanupCachedAssets();
		}

		private void CleanupCachedAssets()
		{
			foreach (UnityEngine.Object cachedAsset in cachedAssets)
			{
				cachedAsset.DestroyBranched();
			}
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
		}
	}
}
