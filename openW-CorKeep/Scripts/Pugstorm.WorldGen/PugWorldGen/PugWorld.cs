using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace PugWorldGen
{
	public abstract class PugWorld : ScriptableObject
	{
		public abstract class DebugMarker
		{
			public Vector2 position;

			public Color color;

			public string label;
		}

		public class DebugPoint : DebugMarker
		{
			public float size;
		}

		public class DebugRect : DebugMarker
		{
			public Vector2 size;
		}

		public class DebugLine : DebugMarker
		{
			public Vector2 endPosition;
		}

		public class DebugCircle : DebugMarker
		{
			public float radius;
		}

		public const int MAX_AREA_SIZE = 1024;

		public static PugWorld activeWorld;

		public static WorldParameters activeWorldParameters;

		[Min(1f)]
		public static int areaRequestsPerFrame = 1;

		public static bool roundPosition = true;

		[SerializeField]
		private Shader m_shader;

		[SerializeField]
		private ComputeShader m_computeShader;

		[SerializeField]
		private WorldParameters m_defaultParameters;

		private static readonly Dictionary<byte, List<AreaRequest>> s_areaRequests = new Dictionary<byte, List<AreaRequest>>();

		private static readonly List<AreaCompletionRequest> s_areaCompletionRequests = new List<AreaCompletionRequest>();

		private static Material s_material;

		private static int s_areaRequestCounter;

		private static readonly List<PointCompletionRequest> s_pointCompletionRequests = new List<PointCompletionRequest>();

		private static int s_pointRequestCounter;

		public static readonly List<DebugMarker> debugMarkers = new List<DebugMarker>();

		public static int currentAreaRequestCount => s_areaRequests.Count;

		[Obsolete("currentRequestCount is obsolete. Use currentAreaRequestCount instead.")]
		public static int currentRequestCount => currentAreaRequestCount;

		public static Shader shader
		{
			get
			{
				if (!(activeWorld != null))
				{
					return null;
				}
				return activeWorld.m_shader;
			}
		}

		public static float tileSize
		{
			get
			{
				if (!(activeWorld != null))
				{
					return 1f;
				}
				return activeWorld.GetTileSizeInternal();
			}
		}

		public static Color explorerBackgroundColor
		{
			get
			{
				if (!(activeWorld != null))
				{
					return Color.gray;
				}
				return activeWorld.GetExplorerBackgroundColorInternal();
			}
		}

		public static bool canDrawAreas => s_material != null;

		public static event Action<byte, int, Vector2, Vector2, NativeArray<Color32>, Vector2Int> onAreaRequestComplete;

		public static event Action<int, NativeArray<Color32>, int> onPointsRequestComplete;

		protected abstract float GetTileSizeInternal();

		protected abstract Color GetExplorerBackgroundColorInternal();

		public static int RequestArea(Vector2 position, Vector2 size, OutputType outputType, byte channel = 0, byte downscale = 1)
		{
			InitializeLazy();
			if (downscale < 1)
			{
				downscale = 1;
			}
			int num = Mathf.CeilToInt(size.x / tileSize / (float)(int)downscale);
			int num2 = Mathf.CeilToInt(size.y / tileSize / (float)(int)downscale);
			if (num < 1 || num2 < 1)
			{
				Debug.LogError("Area request parameters would result in an invalid area size, discarding.");
				return -1;
			}
			if (num > 1024 || num2 > 1024)
			{
				Debug.LogError("Area request parameters would result in an area larger than " + 1024 + ", discarding.");
				return -1;
			}
			if (!s_areaRequests.TryGetValue(channel, out var value))
			{
				value = new List<AreaRequest>();
				s_areaRequests.Add(channel, value);
			}
			value.Add(new AreaRequest
			{
				channel = channel,
				position = position,
				size = size,
				dataSize = new Vector2Int(num, num2),
				rt = RenderTexture.GetTemporary(num, num2, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear),
				outputType = outputType,
				index = s_areaRequestCounter
			});
			return s_areaRequestCounter++;
		}

		public static int RequestPoints(NativeArray<Vector2> points, int count)
		{
			InitializeLazy();
			ComputeAndAddCompletionRequest(new PointRequest
			{
				points = points,
				count = count,
				index = s_pointRequestCounter
			});
			return s_pointRequestCounter++;
		}

		public static int RequestPoints(NativeArray<Vector2> points)
		{
			return RequestPoints(points, points.Length);
		}

		public static bool UnrequestArea(int index, byte channel = 0)
		{
			if (!s_areaRequests.TryGetValue(channel, out var value))
			{
				return false;
			}
			for (int i = 0; i < value.Count; i++)
			{
				AreaRequest areaRequest = value[i];
				if (areaRequest.index == index)
				{
					RenderTexture.ReleaseTemporary(areaRequest.rt);
					value.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		public static void Process()
		{
			ProcessAreaRequests(areaRequestsPerFrame);
			ProcessReadbackRequests();
			ComputeBufferPool.Process();
		}

		[Obsolete("ProcessAreaRequests is obsolete. Call Process instead.")]
		public static void ProcessAreaRequests()
		{
			Process();
		}

		public static void CompleteAreaRequests()
		{
			ProcessAreaRequests(-1);
			foreach (AreaCompletionRequest s_areaCompletionRequest in s_areaCompletionRequests)
			{
				s_areaCompletionRequest.gpuReadback.WaitForCompletion();
			}
			s_areaCompletionRequests.Clear();
			foreach (PointCompletionRequest s_pointCompletionRequest in s_pointCompletionRequests)
			{
				s_pointCompletionRequest.gpuReadback.WaitForCompletion();
			}
			s_pointCompletionRequests.Clear();
			ProcessReadbackRequests();
		}

		public static void ClearAreaRequests()
		{
			s_areaRequests.Clear();
		}

		public static void DrawArea(RenderTexture dst, Vector2 position, Vector2 size, OutputType outputType)
		{
			InitializeLazy();
			if (s_material == null)
			{
				Debug.LogError("Unable to draw area: Material was null");
				return;
			}
			s_material.SetVector(ShaderIDs.Area, new Vector4(position.x, position.y, size.x, size.y));
			s_material.SetFloat(ShaderIDs.RoundPosition, roundPosition ? 1 : 0);
			s_material.SetFloat(ShaderIDs.TileSize, tileSize);
			if (outputType == OutputType.Color)
			{
				s_material.EnableKeyword("COLORIZE_OUTPUT");
			}
			else
			{
				s_material.DisableKeyword("COLORIZE_OUTPUT");
			}
			WorldParameters worldParameters = (activeWorldParameters ? activeWorldParameters : (activeWorld ? activeWorld.m_defaultParameters : null));
			if (worldParameters != null)
			{
				worldParameters.SetShaderProperties(s_material);
			}
			RenderTexture active = RenderTexture.active;
			Graphics.Blit(Texture2D.blackTexture, dst, s_material);
			RenderTexture.active = active;
		}

		public static void ComputePoints(NativeArray<Vector2> points, int count, ComputeBuffer outputBuffer)
		{
			ComputeShader computeShader = (activeWorld ? activeWorld.m_computeShader : null);
			WorldParameters worldParameters = (activeWorldParameters ? activeWorldParameters : (activeWorld ? activeWorld.m_defaultParameters : null));
			if (worldParameters != null)
			{
				worldParameters.SetShaderProperties(computeShader);
			}
			ComputeBuffer computeBuffer = ComputeBufferPool.Get(count, 8);
			computeBuffer.SetData(points);
			computeShader.SetBuffer(0, "_PositionBuffer", computeBuffer);
			computeShader.SetBuffer(0, "_DataBuffer", outputBuffer);
			computeShader.SetInt("_Count", count);
			computeShader.Dispatch(0, Mathf.CeilToInt((float)count / 16f), 1, 1);
			ComputeBufferPool.Return(computeBuffer);
		}

		public static void Release()
		{
			ComputeBufferPool.Release();
		}

		private static void InitializeLazy()
		{
			if (shader != null)
			{
				if (s_material == null)
				{
					s_material = new Material(shader);
				}
				if (s_material.shader != shader)
				{
					s_material.shader = shader;
				}
			}
		}

		private static void ProcessAreaRequests(int maxCount)
		{
			if (shader == null)
			{
				Debug.LogError("Unable to process area requests: Shader was null");
				s_areaRequests.Clear();
				return;
			}
			if (!SystemInfo.supportsAsyncGPUReadback)
			{
				Debug.LogError("Unable to process area requests: System does not support Async GPU Readback");
				s_areaRequests.Clear();
				return;
			}
			InitializeLazy();
			foreach (KeyValuePair<byte, List<AreaRequest>> s_areaRequest in s_areaRequests)
			{
				List<AreaRequest> value = s_areaRequest.Value;
				int num = value.Count;
				if (maxCount > -1)
				{
					num = Mathf.Min(num, maxCount);
				}
				for (int i = 0; i < num; i++)
				{
					DrawAndAddCompletionRequest(value[i]);
				}
				value.RemoveRange(0, num);
			}
		}

		private static void DrawAndAddCompletionRequest(AreaRequest areaRequest)
		{
			DrawArea(areaRequest.rt, areaRequest.position, areaRequest.size, areaRequest.outputType);
			AddAreaCompletionRequest(areaRequest);
		}

		private static void AddAreaCompletionRequest(AreaRequest areaRequest)
		{
			s_areaCompletionRequests.Add(new AreaCompletionRequest
			{
				channel = areaRequest.channel,
				index = areaRequest.index,
				position = areaRequest.position,
				size = areaRequest.size,
				dataSize = areaRequest.dataSize,
				rt = areaRequest.rt,
				gpuReadback = AsyncGPUReadback.Request(areaRequest.rt)
			});
		}

		private static void ComputeAndAddCompletionRequest(PointRequest pointRequest)
		{
			ComputeBuffer computeBuffer = ComputeBufferPool.Get(pointRequest.count, 4);
			ComputePoints(pointRequest.points, pointRequest.count, computeBuffer);
			AddPointCompletionRequest(pointRequest, computeBuffer);
		}

		private static void AddPointCompletionRequest(PointRequest pointRequest, ComputeBuffer buffer)
		{
			s_pointCompletionRequests.Add(new PointCompletionRequest
			{
				index = pointRequest.index,
				buffer = buffer,
				count = pointRequest.count,
				gpuReadback = AsyncGPUReadback.Request(buffer, pointRequest.count * buffer.stride, 0)
			});
		}

		private static void ProcessReadbackRequests()
		{
			int num = 0;
			while (num < s_areaCompletionRequests.Count)
			{
				AreaCompletionRequest areaCompletionRequest = s_areaCompletionRequests[num];
				if (!areaCompletionRequest.gpuReadback.done)
				{
					num++;
					continue;
				}
				s_areaCompletionRequests.RemoveAt(num);
				RenderTexture.ReleaseTemporary(areaCompletionRequest.rt);
				if (areaCompletionRequest.gpuReadback.hasError)
				{
					Debug.LogError("Unable to process area completion request: GPU readback error");
					continue;
				}
				try
				{
					PugWorld.onAreaRequestComplete?.Invoke(areaCompletionRequest.channel, areaCompletionRequest.index, areaCompletionRequest.position, areaCompletionRequest.size, areaCompletionRequest.gpuReadback.GetData<Color32>(), areaCompletionRequest.dataSize);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			int num2 = 0;
			while (num2 < s_pointCompletionRequests.Count)
			{
				PointCompletionRequest pointCompletionRequest = s_pointCompletionRequests[num2];
				if (!pointCompletionRequest.gpuReadback.done)
				{
					num2++;
					continue;
				}
				s_pointCompletionRequests.RemoveAt(num2);
				ComputeBufferPool.Return(pointCompletionRequest.buffer);
				if (pointCompletionRequest.gpuReadback.hasError)
				{
					Debug.LogError("Unable to process point completion request: GPU readback error");
					continue;
				}
				try
				{
					PugWorld.onPointsRequestComplete?.Invoke(pointCompletionRequest.index, pointCompletionRequest.gpuReadback.GetData<Color32>(), pointCompletionRequest.count);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
				}
			}
		}

		public static T AddDebugMarker<T>() where T : DebugMarker, new()
		{
			T val = new T();
			debugMarkers.Add(val);
			return val;
		}

		public static void AddDebugMarker<T>(out T marker) where T : DebugMarker, new()
		{
			marker = new T();
			debugMarkers.Add(marker);
		}

		public static DebugPoint AddDebugPoint(Vector2 position, float size, Color color, string label)
		{
			DebugPoint debugPoint = new DebugPoint
			{
				position = position,
				size = size,
				color = color,
				label = label
			};
			debugMarkers.Add(debugPoint);
			return debugPoint;
		}

		public static DebugPoint AddDebugPoint(Vector2 position, float size, Color color)
		{
			return AddDebugPoint(position, size, color, null);
		}

		public static DebugRect AddDebugRect(Vector2 position, Vector2 size, Color color, string label)
		{
			DebugRect debugRect = new DebugRect
			{
				position = position,
				size = size,
				color = color,
				label = label
			};
			debugMarkers.Add(debugRect);
			return debugRect;
		}

		public static DebugRect AddDebugRect(Vector2 position, Vector2 size, Color color)
		{
			return AddDebugRect(position, size, color, null);
		}

		public static DebugLine AddDebugLine(Vector2 position, Vector2 endPosition, Color color, string label)
		{
			DebugLine debugLine = new DebugLine
			{
				position = position,
				endPosition = endPosition,
				color = color,
				label = label
			};
			debugMarkers.Add(debugLine);
			return debugLine;
		}

		public static DebugLine AddDebugLine(Vector2 position, Vector2 endPosition, Color color)
		{
			return AddDebugLine(position, endPosition, color, null);
		}

		public static DebugCircle AddDebugCircle(Vector2 position, float radius, Color color, string label)
		{
			DebugCircle debugCircle = new DebugCircle
			{
				position = position,
				radius = radius,
				color = color,
				label = label
			};
			debugMarkers.Add(debugCircle);
			return debugCircle;
		}

		public static DebugCircle AddDebugCircle(Vector2 position, float radius, Color color)
		{
			return AddDebugCircle(position, radius, color, null);
		}

		public static void RemoveDebugMarker(DebugMarker marker)
		{
			debugMarkers.Remove(marker);
		}

		public static bool TryRemoveDebugMarker(DebugMarker marker)
		{
			int num = debugMarkers.IndexOf(marker);
			if (num >= 0)
			{
				debugMarkers.RemoveAt(num);
				return true;
			}
			return false;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void ClearDebugMarkers()
		{
			debugMarkers.Clear();
		}

		public static void DrawDebugMarkers(float pointSizeMultiplier)
		{
			for (int i = 0; i < debugMarkers.Count; i++)
			{
				DebugMarker debugMarker = debugMarkers[i];
				if (debugMarker is DebugPoint debugPoint)
				{
					DrawQuad(debugPoint.position, debugPoint.color, Vector2.one * debugPoint.size * pointSizeMultiplier);
				}
				else if (debugMarker is DebugRect debugRect)
				{
					DrawQuad(debugRect.position, debugRect.color, debugRect.size);
				}
				else if (debugMarker is DebugLine debugLine)
				{
					DrawLine(debugLine.position, debugLine.endPosition, debugLine.color);
				}
				else if (debugMarker is DebugCircle { position: var position, radius: var radius } debugCircle)
				{
					for (int j = 0; j < 32; j++)
					{
						float f = ((float)j + 0f) / 32f * 2f * MathF.PI;
						float f2 = ((float)j + 1f) / 32f * 2f * MathF.PI;
						DrawLine(new Vector2(position.x + Mathf.Cos(f) * radius, position.y + Mathf.Sin(f) * radius), new Vector2(position.x + Mathf.Cos(f2) * radius, position.y + Mathf.Sin(f2) * radius), debugCircle.color);
					}
				}
			}
		}

		public static void DrawDebugMarkerLabels(Matrix4x4 view, Matrix4x4 proj, float viewportAspect)
		{
			Matrix4x4 matrix4x = proj * view;
			for (int i = 0; i < debugMarkers.Count; i++)
			{
				DebugMarker debugMarker = debugMarkers[i];
				if (!string.IsNullOrEmpty(debugMarker.label))
				{
					Vector3 vector = matrix4x.MultiplyPoint(debugMarker.position);
					vector.x = vector.x * 0.5f + 0.5f;
					vector.y = (0f - vector.y) * 0.5f + 0.5f;
					Rect position = new Rect(vector.x * (float)Screen.width - 10f, vector.y * (float)Screen.width / viewportAspect - 10f, 100f, 50f);
					if (vector.x > 0f && vector.x < 1f && vector.y > 0f && vector.y < 1f)
					{
						GUI.Label(position, debugMarker.label);
					}
				}
			}
		}

		private static void DrawLine(Vector2 p1, Vector2 p2, Color color)
		{
			GL.Begin(1);
			GL.Color(color);
			GL.Vertex(p1);
			GL.Vertex(p2);
			GL.End();
		}

		private static void DrawQuad(Vector2 p, Color color, Vector2 size)
		{
			GL.Begin(7);
			GL.Color(color);
			GL.Vertex3(p.x - size.x, p.y - size.y, 0f);
			GL.Vertex3(p.x - size.x, p.y + size.y, 0f);
			GL.Vertex3(p.x + size.x, p.y + size.y, 0f);
			GL.Vertex3(p.x + size.x, p.y - size.y, 0f);
			GL.End();
		}
	}
}
