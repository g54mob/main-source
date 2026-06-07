using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Assets.Scripts.Craft.Parts;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft
{
	[BurstCompile(CompileSynchronously = true)]
	public class DragCalculatorScript : MonoBehaviour
	{
		private readonly struct DragRenderer
		{
			public Mesh Mesh { get; }

			public Renderer Renderer { get; }

			public DragRenderer(Renderer renderer, Mesh mesh)
			{
				Renderer = renderer;
				Mesh = mesh;
			}
		}

		public class DragQueue
		{
			private DragCalculatorScript _dragCalculator;

			private bool _processing;

			private Queue<BodyScript> _queue;

			public bool Processing
			{
				get
				{
					if (!_processing)
					{
						return _queue.Count > 0;
					}
					return true;
				}
			}

			public DragQueue(DragCalculatorScript dragCalculator)
			{
				_dragCalculator = dragCalculator;
				_queue = new Queue<BodyScript>();
			}

			public void AddBody(BodyScript bodyScript)
			{
				if (!_queue.Contains(bodyScript))
				{
					_queue.Enqueue(bodyScript);
				}
			}

			public void ClearBodies(AircraftScript aircraft)
			{
				Queue<BodyScript> value;
				using (QueuePool<BodyScript>.Get(out value))
				{
					while (_queue.Count > 0)
					{
						BodyScript bodyScript = _queue.Dequeue();
						if (bodyScript != null && bodyScript.Aircraft != aircraft)
						{
							value.Enqueue(bodyScript);
						}
					}
					while (value.Count > 0)
					{
						BodyScript bodyScript2 = value.Dequeue();
						if (bodyScript2 != null)
						{
							_queue.Enqueue(bodyScript2);
						}
					}
				}
			}

			public void Update()
			{
				if (_processing || _queue.Count <= 0)
				{
					return;
				}
				BodyScript bodyScript = _queue.Dequeue();
				if (!(bodyScript != null) || !bodyScript.gameObject.activeInHierarchy)
				{
					return;
				}
				_processing = true;
				try
				{
					_dragCalculator.CalculateDrag(bodyScript, delegate
					{
						OnComplete(bodyScript);
					});
				}
				catch (Exception message)
				{
					_processing = false;
					Debug.LogError(message);
				}
			}

			private void OnComplete(BodyScript bodyScript)
			{
				try
				{
					if (bodyScript != null)
					{
						bodyScript.CalculateDrag();
					}
				}
				finally
				{
					_processing = false;
				}
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker ClearDrag = new ProfilerMarker("DragCalculatorScript.ClearDrag");

			public static readonly ProfilerMarker DragGpuReadback = new ProfilerMarker("Drag GPU Readback");

			public static readonly ProfilerMarker ProcessDragResults = new ProfilerMarker("DragCalculatorScript.ProcessDragResults");

			public static readonly ProfilerMarker RenderAndProcessDrag = new ProfilerMarker("DragCalculatorScript.RenderAndProcessDrag");

			public static readonly ProfilerMarker RenderDrag = new ProfilerMarker("DragCalculatorScript.RenderDrag");
		}

		private class DragCalculation
		{
			public bool Async { get; set; }

			public AircraftScript DesignerCraft { get; set; }

			public PartDrag.DragDirection? Direction { get; set; }

			public List<PartData> DragParts { get; }

			public List<DragRenderer> DragRenderers { get; }

			public string JobName { get; set; }

			public int MaxPartId { get; set; }

			public List<PartData> NoDragParts { get; }

			public List<DragRenderer> OcclusionRenderers { get; }

			public Transform ReferenceTransform { get; set; }

			public DragCalculation()
			{
				DragParts = new List<PartData>();
				DragRenderers = new List<DragRenderer>();
				OcclusionRenderers = new List<DragRenderer>();
				NoDragParts = new List<PartData>();
			}

			public void Clear()
			{
				JobName = null;
				ReferenceTransform = null;
				Direction = null;
				MaxPartId = 0;
				DragParts.Clear();
				DragRenderers.Clear();
				OcclusionRenderers.Clear();
				NoDragParts.Clear();
			}
		}

		private class DragJob
		{
			private static long _currentId;

			public AsyncGPUReadbackRequest AsyncRequest { get; set; }

			public Vector3 Center { get; set; }

			public PartDrag.DragDirection Direction { get; set; }

			public float Distance { get; set; }

			public long Id { get; set; }

			public string JobName { get; set; }

			public NativeArray<Color32> Pixels { get; set; }

			public Transform ReferenceTransform { get; set; }

			public float Size { get; set; }

			public int TextureIndex { get; set; }

			public Vector3 Up { get; set; }

			public DragJob(PartDrag.DragDirection dragDirection, Vector3 up, Vector3 center, float size, float distance, Transform referenceTransform, int textureIndex, string jobName)
			{
				Id = _currentId++;
				Direction = dragDirection;
				Up = up;
				Center = center;
				Size = size;
				Distance = distance;
				ReferenceTransform = referenceTransform;
				TextureIndex = textureIndex;
				JobName = jobName;
			}

			public void SaveToFile()
			{
				Texture2D texture2D = new Texture2D(256, 256, TextureFormat.RGBA32, mipChain: false, linear: true);
				texture2D.LoadRawTextureData(Pixels);
				byte[] bytes = texture2D.EncodeToPNG();
				UnityEngine.Object.Destroy(texture2D);
				FileInfo fileInfo = new FileInfo($"C:\\Temp\\DragRenders\\{JobName ?? Id.ToString()} - {Direction}.png");
				if (!fileInfo.Directory.Exists)
				{
					fileInfo.Directory.Create();
				}
				File.WriteAllBytes(fileInfo.FullName, bytes);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void _003CProcessDragResults_003Eg__GetDragData_007C28_0_000054B9_0024PostfixBurstDelegate([ReadOnly][NoAlias] Color32* pixels, [WriteOnly][NoAlias] int* partIds, [WriteOnly][NoAlias] float* pixelDrag, float dragPerPixel, int pixelCount);

		internal static class _003CProcessDragResults_003Eg__GetDragData_007C28_0_000054B9_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<_003CProcessDragResults_003Eg__GetDragData_007C28_0_000054B9_0024PostfixBurstDelegate>(GetDragData).Value;
				}
				P_0 = Pointer;
				[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
				[MonoPInvokeCallback(typeof(Assets_002EScripts_002ECraft_002E_003CProcessDragResults_003Eg__GetDragData_007C28_0_000054B9_0024PostfixBurstDelegate))]
				static unsafe void GetDragData([ReadOnly][NoAlias] Color32* pixels, [WriteOnly][NoAlias] int* partIds, [WriteOnly][NoAlias] float* pixelDrag, float dragPerPixel, int pixelCount)
				{
					Invoke(pixels, partIds, pixelDrag, dragPerPixel, pixelCount);
				}
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke([ReadOnly][NoAlias] Color32* pixels, [WriteOnly][NoAlias] int* partIds, [WriteOnly][NoAlias] float* pixelDrag, float dragPerPixel, int pixelCount)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<Color32*, int*, float*, float, int, void>)functionPointer)(pixels, partIds, pixelDrag, dragPerPixel, pixelCount);
						return;
					}
				}
				_003CProcessDragResults_003Eg__GetDragData_007C28_0_0024BurstManaged(pixels, partIds, pixelDrag, dragPerPixel, pixelCount);
			}
		}

		private const int TextureSize = 256;

		private Queue<DragJob> _asyncJobQueue;

		private Camera _camera;

		private Stack<DragCalculation> _dragCalculationPool;

		private Material _partDragMaterial;

		private Material _partDragOcclusionMaterial;

		private RenderTexture[] _renderTextures;

		private Texture2D _resultTexture;

		public DragQueue Queue { get; private set; }

		public static float ApplyCraftLevelDragEffects(AircraftScript craftScript, PartDrag.DragDirection direction, float totalDrag)
		{
			float drag = craftScript.Aircraft.CraftDrag.StreamlineFactor.GetDrag(direction);
			totalDrag *= drag;
			float num = craftScript.Aircraft.CraftDrag.StreamlineFactor.CalculateSkinDrag();
			totalDrag += num;
			return totalDrag;
		}

		public void CalculateDrag(BodyScript bodyScript, Action onCompleteCallback)
		{
			DragCalculation dragCalculation = GetDragCalculationFromPool();
			onCompleteCallback = (Action)Delegate.Combine(onCompleteCallback, (Action)delegate
			{
				ReturnDragCalculationToPool(dragCalculation);
			});
			dragCalculation.ReferenceTransform = bodyScript.transform;
			dragCalculation.Direction = null;
			dragCalculation.Async = true;
			dragCalculation.JobName = $"Body {bodyScript.Id}";
			Queue<PartData> value;
			using (QueuePool<PartData>.Get(out value))
			{
				HashSet<int> value2;
				using (CollectionPool<HashSet<int>, int>.Get(out value2))
				{
					HashSet<int> value3;
					using (CollectionPool<HashSet<int>, int>.Get(out value3))
					{
						foreach (PartGroupScript partGroup2 in bodyScript.PartGroups)
						{
							value3.Add(partGroup2.Id);
							if (partGroup2.Mesh != null && partGroup2.Renderer.gameObject.activeInHierarchy)
							{
								dragCalculation.DragRenderers.Add(new DragRenderer(partGroup2.Renderer, partGroup2.Mesh));
							}
							foreach (PartScript part2 in partGroup2.Parts)
							{
								PartData part = part2.Part;
								int id = part.Id;
								value2.Add(id);
								value.Enqueue(part);
								if (part.DragType == PartDragType.None)
								{
									dragCalculation.NoDragParts.Add(part);
									continue;
								}
								dragCalculation.DragParts.Add(part);
								if (id > dragCalculation.MaxPartId)
								{
									dragCalculation.MaxPartId = id;
								}
								foreach (PartMaterialScript.RendererMaterialMap rendererMap in part2.PartMaterialScript.RendererMaps)
								{
									if (!(rendererMap.Renderer == null) && rendererMap.Renderer.gameObject.activeInHierarchy)
									{
										if (rendererMap.DragType == PartDragType.Standard)
										{
											dragCalculation.DragRenderers.Add(new DragRenderer(rendererMap.Renderer, rendererMap.Mesh));
										}
										else if (rendererMap.DragType == PartDragType.OccludeOnly)
										{
											dragCalculation.OcclusionRenderers.Add(new DragRenderer(rendererMap.Renderer, rendererMap.Mesh));
										}
									}
								}
							}
						}
						while (value.Count > 0)
						{
							PartData partData = value.Dequeue();
							foreach (PartConnection partConnection in partData.PartConnections)
							{
								PartData otherPart = partConnection.GetOtherPart(partData);
								if (!value2.Add(otherPart.Id))
								{
									continue;
								}
								value.Enqueue(otherPart);
								PartGroupScript partGroup = otherPart.PartScript.PartGroup;
								if (value3.Add(partGroup.Id) && partGroup.Mesh != null && partGroup.Renderer.gameObject.activeInHierarchy)
								{
									dragCalculation.OcclusionRenderers.Add(new DragRenderer(partGroup.Renderer, partGroup.Mesh));
								}
								foreach (PartMaterialScript.RendererMaterialMap rendererMap2 in otherPart.PartScript.PartMaterialScript.RendererMaps)
								{
									if (rendererMap2.DragType != PartDragType.None && rendererMap2.Renderer != null && rendererMap2.Renderer.gameObject.activeInHierarchy)
									{
										dragCalculation.OcclusionRenderers.Add(new DragRenderer(rendererMap2.Renderer, rendererMap2.Mesh));
									}
								}
							}
						}
						StartCoroutine(CalculateDragCoroutine(dragCalculation, onCompleteCallback));
					}
				}
			}
		}

		public void CalculateDragInDesigner(AircraftScript craftScript, PartDrag.DragDirection direction, out float dragCount)
		{
			CalculateDragInDesigner(craftScript);
			float num = 0f;
			foreach (PartData part in craftScript.Parts)
			{
				if (part.DragType == PartDragType.Standard || part.DragType == PartDragType.OccludeOnly)
				{
					num += part.PartDrag.GetDrag(direction);
				}
			}
			_ = num / 0.001f;
			dragCount = ApplyCraftLevelDragEffects(craftScript, direction, num) / 0.001f;
		}

		public void CalculateDragInDesigner(AircraftScript craftScript)
		{
			if (craftScript.LoadContext != CraftLoadContext.Designer)
			{
				Debug.LogError("CalculateDragInDesigner should only be called from the designer.");
			}
			DragCalculation dragCalculation = GetDragCalculationFromPool();
			Action onCompleteCallback = delegate
			{
				ReturnDragCalculationToPool(dragCalculation);
			};
			dragCalculation.DesignerCraft = craftScript;
			dragCalculation.ReferenceTransform = craftScript.transform;
			dragCalculation.Direction = null;
			dragCalculation.Async = false;
			dragCalculation.JobName = "Designer Craft";
			foreach (PartData part in craftScript.Aircraft.Assembly.Parts)
			{
				if (part.DragType == PartDragType.None)
				{
					dragCalculation.NoDragParts.Add(part);
					continue;
				}
				dragCalculation.DragParts.Add(part);
				if (part.Id > dragCalculation.MaxPartId)
				{
					dragCalculation.MaxPartId = part.Id;
				}
				foreach (PartMaterialScript.RendererMaterialMap rendererMap in part.PartScript.PartMaterialScript.RendererMaps)
				{
					if (rendererMap.Renderer.gameObject.activeInHierarchy && (rendererMap.DragType == PartDragType.Standard || rendererMap.DragType == PartDragType.OccludeOnly))
					{
						dragCalculation.DragRenderers.Add(new DragRenderer(rendererMap.Renderer, rendererMap.Mesh));
					}
				}
			}
			IEnumerator enumerator3 = CalculateDragCoroutine(dragCalculation, onCompleteCallback);
			while (enumerator3.MoveNext())
			{
			}
			CalculateCraftStreamlineFactor(craftScript);
		}

		public void OnCraftDestroyed(AircraftScript craft)
		{
			Queue?.ClearBodies(craft);
		}

		protected virtual void Awake()
		{
			Queue = new DragQueue(this);
			_dragCalculationPool = new Stack<DragCalculation>();
			_renderTextures = new RenderTexture[6];
			_asyncJobQueue = new Queue<DragJob>();
			_partDragMaterial = Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/PartDrag");
			_partDragOcclusionMaterial = Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/PartDragOcclusion");
			_camera = base.gameObject.AddComponent<Camera>();
			_camera.enabled = false;
			_camera.orthographic = true;
			_camera.clearFlags = CameraClearFlags.Color;
			_camera.backgroundColor = Color.black;
			_camera.cullingMask = 0;
		}

		protected virtual void OnDestroy()
		{
			if (_resultTexture != null)
			{
				UnityEngine.Object.Destroy(_resultTexture);
				_resultTexture = null;
			}
			if (_renderTextures == null)
			{
				return;
			}
			for (int i = 0; i < _renderTextures.Length; i++)
			{
				if (_renderTextures[i] != null)
				{
					UnityEngine.Object.Destroy(_renderTextures[i]);
				}
				_renderTextures[i] = null;
			}
		}

		protected virtual void Update()
		{
			Queue.Update();
		}

		private static void CalculateCraftStreamlineFactor(AircraftScript craftScript)
		{
			float num = Mathf.Max(craftScript.Aircraft.CraftDrag.StreamlineFactor.TotalArea, 0.001f);
			foreach (PartDrag.DragDirection value2 in Enum.GetValues(typeof(PartDrag.DragDirection)))
			{
				float area = craftScript.Aircraft.CraftDrag.StreamlineFactor.GetArea(value2);
				float value = Mathf.Clamp(area / num * 6f, 0.15f, 1f);
				craftScript.Aircraft.CraftDrag.StreamlineFactor.SetDrag(value2, value, area);
			}
		}

		private IEnumerator CalculateDragCoroutine(DragCalculation dragCalculation, Action onCompleteCallback)
		{
			try
			{
				ClearDrag(dragCalculation.NoDragParts);
				if (dragCalculation.DragParts.Count == 0)
				{
					yield break;
				}
				Bounds bounds = CalculateLocalSpaceBounds(dragCalculation);
				Vector3 size = bounds.size;
				Vector3 center = bounds.center;
				if (Mathf.Approximately(size.sqrMagnitude, 0f))
				{
					ClearDrag(dragCalculation.DragParts);
					yield break;
				}
				int jobCount = 0;
				DragJob[] jobs = new DragJob[dragCalculation.Direction.HasValue ? 1 : 6];
				Transform referenceTransform = dragCalculation.ReferenceTransform;
				AddJob(PartDrag.DragDirection.Forward, ref jobCount, jobs, referenceTransform.up, center, Mathf.Max(size.x, size.y), size.z * 2f, dragCalculation);
				AddJob(PartDrag.DragDirection.Backward, ref jobCount, jobs, referenceTransform.up, center, Mathf.Max(size.x, size.y), size.z * 2f, dragCalculation);
				AddJob(PartDrag.DragDirection.Rightward, ref jobCount, jobs, referenceTransform.up, center, Mathf.Max(size.z, size.y), size.x * 2f, dragCalculation);
				AddJob(PartDrag.DragDirection.Leftward, ref jobCount, jobs, referenceTransform.up, center, Mathf.Max(size.z, size.y), size.x * 2f, dragCalculation);
				AddJob(PartDrag.DragDirection.Upward, ref jobCount, jobs, referenceTransform.right, center, Mathf.Max(size.x, size.z), size.y * 2f, dragCalculation);
				AddJob(PartDrag.DragDirection.Downward, ref jobCount, jobs, referenceTransform.right, center, Mathf.Max(size.x, size.z), size.y * 2f, dragCalculation);
				if (dragCalculation.Async)
				{
					int currentJob = 0;
					while (currentJob < jobs.Length || _asyncJobQueue.Count > 0)
					{
						yield return new WaitForEndOfFrame();
						if (dragCalculation.ReferenceTransform == null || !dragCalculation.ReferenceTransform.gameObject.activeInHierarchy)
						{
							_asyncJobQueue.Clear();
							break;
						}
						DragJob dragJob = ProcessAsyncReadbackQueue();
						if (dragJob != null)
						{
							while (dragJob != null)
							{
								if (dragJob.ReferenceTransform != null)
								{
									ProcessDragResults(dragCalculation, dragJob);
								}
								dragJob = ProcessAsyncReadbackQueue();
							}
						}
						else if (currentJob < jobs.Length)
						{
							DragJob dragJob2 = jobs[currentJob++];
							if (dragJob2.ReferenceTransform != null)
							{
								RenderDrag(dragCalculation, dragJob2);
								RenderTexture renderTexture = GetRenderTexture(dragJob2.TextureIndex);
								dragJob2.AsyncRequest = AsyncGPUReadback.Request(renderTexture);
								_asyncJobQueue.Enqueue(dragJob2);
							}
						}
					}
					yield break;
				}
				DragJob[] array = jobs;
				foreach (DragJob job in array)
				{
					yield return new WaitForEndOfFrame();
					if (dragCalculation.ReferenceTransform == null || !dragCalculation.ReferenceTransform.gameObject.activeInHierarchy)
					{
						break;
					}
					if (job.ReferenceTransform != null)
					{
						RenderAndProcessDrag(dragCalculation, job);
					}
				}
			}
			finally
			{
				onCompleteCallback?.Invoke();
			}
			static void AddJob(PartDrag.DragDirection dir, ref int reference, DragJob[] array2, Vector3 up, Vector3 center2, float size2, float distance, DragCalculation dragCalc)
			{
				if ((dragCalc.Direction ?? dir) == dir)
				{
					array2[reference] = new DragJob(dir, up, center2, size2, distance, dragCalc.ReferenceTransform, dragCalc.Async ? reference : 0, dragCalc.JobName);
					reference++;
				}
			}
		}

		private Bounds CalculateLocalSpaceBounds(DragCalculation dragCalculation)
		{
			return Utilities.ConvertWorldAabbToLocalAabb(CalculateWorldSpaceBounds(dragCalculation), dragCalculation.ReferenceTransform);
		}

		private Bounds CalculateWorldSpaceBounds(DragCalculation dragCalculation)
		{
			if (dragCalculation.DragRenderers.Count == 0)
			{
				return new Bounds(Vector3.zero, Vector3.zero);
			}
			Bounds bounds = dragCalculation.DragRenderers[0].Renderer.bounds;
			List<DragRenderer> dragRenderers = dragCalculation.DragRenderers;
			for (int i = 1; i < dragRenderers.Count; i++)
			{
				bounds = Utilities.ExpandBounds(bounds, dragRenderers[i].Renderer.bounds);
			}
			return bounds;
		}

		private void ClearDrag(List<PartData> parts)
		{
			using (Profile.ClearDrag.Auto())
			{
				foreach (PartData part in parts)
				{
					part.PartDrag.ClearDrag();
				}
			}
		}

		private DragCalculation GetDragCalculationFromPool()
		{
			if (_dragCalculationPool.Count > 0)
			{
				return _dragCalculationPool.Pop();
			}
			return new DragCalculation();
		}

		private RenderTexture GetRenderTexture(int index)
		{
			RenderTexture renderTexture = _renderTextures[index];
			if (renderTexture == null || !renderTexture.IsCreated())
			{
				renderTexture = new RenderTexture(256, 256, 32, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				renderTexture.filterMode = FilterMode.Point;
				renderTexture.antiAliasing = 1;
				renderTexture.anisoLevel = 1;
				renderTexture.name = $"Drag Render Texture {index}";
				_renderTextures[index] = renderTexture;
			}
			return renderTexture;
		}

		private DragJob ProcessAsyncReadbackQueue()
		{
			if (_asyncJobQueue.Count == 0)
			{
				return null;
			}
			DragJob dragJob = _asyncJobQueue.Peek();
			if (dragJob.AsyncRequest.hasError)
			{
				_asyncJobQueue.Dequeue();
				Debug.LogError($"{Time.frameCount}: Async GPU Readback Error");
			}
			else if (dragJob.AsyncRequest.done)
			{
				_asyncJobQueue.Dequeue();
				dragJob.Pixels = dragJob.AsyncRequest.GetData<Color32>();
				return dragJob;
			}
			return null;
		}

		private unsafe void ProcessDragResults(DragCalculation dragCalculation, DragJob job)
		{
			using (Profile.ProcessDragResults.Auto())
			{
				PartDrag.DragDirection direction = job.Direction;
				NativeArray<Color32> pixels = job.Pixels;
				int length = pixels.Length;
				float num = 1.5258789E-05f * (job.Size * job.Size);
				foreach (PartData dragPart in dragCalculation.DragParts)
				{
					dragPart.PartDrag.DragScale = dragPart.DragScale;
					dragPart.PartDrag.ClearDrag(job.Direction);
				}
				using NativeArray<int> nativeArray = new NativeArray<int>(length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				using NativeArray<float> nativeArray2 = new NativeArray<float>(length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				Color32* unsafeBufferPointerWithoutChecks = (Color32*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(pixels);
				int* unsafeBufferPointerWithoutChecks2 = (int*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray);
				float* unsafeBufferPointerWithoutChecks3 = (float*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray2);
				GetDragData(unsafeBufferPointerWithoutChecks, unsafeBufferPointerWithoutChecks2, unsafeBufferPointerWithoutChecks3, num, length);
				int maxPartId = dragCalculation.MaxPartId;
				using NativeArray<int> nativeArray3 = new NativeArray<int>(maxPartId + 1, Allocator.Temp);
				int* unsafeBufferPointerWithoutChecks4 = (int*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray3);
				List<PartData> dragParts = dragCalculation.DragParts;
				PartData[] internalArray = dragParts.GetInternalArray();
				for (int i = 0; i < dragParts.Count; i++)
				{
					unsafeBufferPointerWithoutChecks4[internalArray[i].Id] = i + 1;
				}
				HashSet<int> value;
				using (CollectionPool<HashSet<int>, int>.Get(out value))
				{
					float num2 = 0f;
					for (int j = 0; j < length; j++)
					{
						int num3 = unsafeBufferPointerWithoutChecks2[j];
						if (num3 > 0 && num3 <= maxPartId)
						{
							int num4 = unsafeBufferPointerWithoutChecks4[num3] - 1;
							PartData partData = ((num4 < 0) ? null : internalArray[num4]);
							if (partData != null)
							{
								float value2 = unsafeBufferPointerWithoutChecks3[j];
								partData.PartDrag.AddDrag(direction, value2, null, num);
								num2 += num;
							}
							else if (value.Add(num3))
							{
								Debug.Log($"Could not find part '{num3}' with drag {unsafeBufferPointerWithoutChecks3[j]}");
							}
						}
					}
					if (dragCalculation.DesignerCraft != null)
					{
						dragCalculation.DesignerCraft.Aircraft.CraftDrag.StreamlineFactor.SetDrag(direction, 0f, num2);
					}
				}
			}
			[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
			[MonoPInvokeCallback(typeof(Assets_002EScripts_002ECraft_002E_003CProcessDragResults_003Eg__GetDragData_007C28_0_000054B9_0024PostfixBurstDelegate))]
			static unsafe void GetDragData([ReadOnly][NoAlias] Color32* pixels2, [WriteOnly][NoAlias] int* partIds, [WriteOnly][NoAlias] float* pixelDrag, float dragPerPixel, int pixelCount)
			{
				_003CProcessDragResults_003Eg__GetDragData_007C28_0_000054B9_0024BurstDirectCall.Invoke(pixels2, partIds, pixelDrag, dragPerPixel, pixelCount);
			}
		}

		private void RenderAndProcessDrag(DragCalculation dragCalculation, DragJob job)
		{
			using (Profile.RenderAndProcessDrag.Auto())
			{
				RenderDrag(dragCalculation, job);
				if (_resultTexture == null)
				{
					_resultTexture = new Texture2D(256, 256, TextureFormat.RGBA32, mipChain: false, linear: true);
					_resultTexture.filterMode = FilterMode.Point;
					_resultTexture.name = "Drag Calculator Texture";
				}
				using (Profile.DragGpuReadback.Auto())
				{
					RenderTexture active = RenderTexture.active;
					RenderTexture.active = GetRenderTexture(job.TextureIndex);
					_resultTexture.ReadPixels(_camera.pixelRect, 0, 0, recalculateMipMaps: false);
					RenderTexture.active = active;
				}
				job.Pixels = _resultTexture.GetRawTextureData<Color32>();
				ProcessDragResults(dragCalculation, job);
			}
		}

		private void RenderDrag(DragCalculation dragCalculation, DragJob job)
		{
			using (Profile.RenderDrag.Auto())
			{
				Vector3 vector = dragCalculation.ReferenceTransform.TransformPoint(job.Center);
				Vector3 vector2 = dragCalculation.ReferenceTransform.TransformDirection(PartDrag.DragDirectionToVector3(job.Direction));
				_camera.transform.SetPositionAndRotation(vector + vector2 * 2500f, Quaternion.LookRotation(-vector2, job.Up));
				RenderTexture renderTexture = GetRenderTexture(job.TextureIndex);
				_camera.aspect = 1f;
				_camera.nearClipPlane = 10f;
				_camera.farClipPlane = 5000f;
				_camera.orthographicSize = job.Size / 2f;
				Matrix4x4 worldToCameraMatrix = _camera.worldToCameraMatrix;
				Matrix4x4 projectionMatrix = _camera.projectionMatrix;
				CommandBuffer commandBuffer = CommandBufferPool.Get("Part Drag Render");
				commandBuffer.SetRenderTarget(new RenderTargetIdentifier(renderTexture));
				commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.black);
				commandBuffer.SetViewProjectionMatrices(worldToCameraMatrix, projectionMatrix);
				commandBuffer.BeginSample("Draw Part Drag Renderers");
				Material partDragMaterial = _partDragMaterial;
				foreach (DragRenderer dragRenderer in dragCalculation.DragRenderers)
				{
					Renderer renderer = dragRenderer.Renderer;
					Mesh mesh = dragRenderer.Mesh;
					for (int i = 0; i < mesh.subMeshCount; i++)
					{
						commandBuffer.DrawRenderer(renderer, partDragMaterial, i, -1);
					}
				}
				commandBuffer.EndSample("Draw Part Drag Renderers");
				commandBuffer.BeginSample("Draw Part Drag Occlusion Renderers");
				partDragMaterial = _partDragOcclusionMaterial;
				foreach (DragRenderer occlusionRenderer in dragCalculation.OcclusionRenderers)
				{
					Renderer renderer2 = occlusionRenderer.Renderer;
					Mesh mesh2 = occlusionRenderer.Mesh;
					for (int j = 0; j < mesh2.subMeshCount; j++)
					{
						commandBuffer.DrawRenderer(renderer2, partDragMaterial, j, -1);
					}
				}
				commandBuffer.EndSample("Draw Part Drag Occlusion Renderers");
				Graphics.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
			}
		}

		private void ReturnDragCalculationToPool(DragCalculation dragCalculation)
		{
			dragCalculation.Clear();
			_dragCalculationPool.Push(dragCalculation);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CompilerGenerated]
		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		internal unsafe static void _003CProcessDragResults_003Eg__GetDragData_007C28_0_0024BurstManaged([ReadOnly][NoAlias] Color32* pixels, [WriteOnly][NoAlias] int* partIds, [WriteOnly][NoAlias] float* pixelDrag, float dragPerPixel, int pixelCount)
		{
			for (int i = 0; i < pixelCount; i++)
			{
				Color32 color = pixels[i];
				partIds[i] = (color.b << 8) + color.g;
				pixelDrag[i] = (float)(int)color.r * 0.003921569f * dragPerPixel;
			}
		}
	}
}
