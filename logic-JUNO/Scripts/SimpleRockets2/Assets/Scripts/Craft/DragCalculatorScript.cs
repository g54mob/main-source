using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft
{
	public class DragCalculatorScript : MonoBehaviour
	{
		public class DragResult
		{
			public Drag TotalDrag { get; set; }

			public DragResult()
			{
				TotalDrag = new Drag();
			}
		}

		private static class ShaderPropertyIds
		{
			public static readonly int PartGroupId = Shader.PropertyToID("_PartGroupId");

			public static readonly int PartId = Shader.PropertyToID("_PartId");
		}

		private class DragCalculation
		{
			public struct RendererWrapper
			{
				public readonly bool CalculateDrag;

				public readonly int Id;

				public readonly IRendererMaterialMap RenderMap;

				public RendererWrapper(IRendererMaterialMap renderMap, bool calculateDrag, int id)
				{
					RenderMap = renderMap;
					CalculateDrag = calculateDrag;
					Id = id;
				}
			}

			public readonly Dictionary<int, BodyData> BodyLookup;

			public readonly Dictionary<int, IPartGroupScript> PartGroupLookup;

			public readonly Dictionary<int, PartData> PartLookup;

			public int MaxPartGroupId;

			public int MinPartGroupId;

			public IPartGroupScript[] PartGroupFastLookup;

			public DragResult DragResult { get; private set; }

			public Bounds LocalBounds { get; set; }

			public Transform ReferenceTransform { get; set; }

			public List<RendererWrapper> Renderers { get; private set; }

			public DragCalculation()
			{
				Renderers = new List<RendererWrapper>();
				BodyLookup = new Dictionary<int, BodyData>();
				PartLookup = new Dictionary<int, PartData>();
				PartGroupLookup = new Dictionary<int, IPartGroupScript>();
				DragResult = new DragResult();
				MaxPartGroupId = int.MinValue;
				MinPartGroupId = int.MaxValue;
			}
		}

		private class DragJob
		{
			private static long _currentId;

			public AsyncGPUReadbackRequest AsyncRequest { get; set; }

			public Drag.DragDirection Direction { get; set; }

			public float Distance { get; set; }

			public long Id { get; set; }

			public NativeArray<Color32> Pixels { get; set; }

			public Transform ReferenceTransform { get; set; }

			public float Size { get; set; }

			public int TextureIndex { get; set; }

			public Vector3 Up { get; set; }

			public DragJob(Drag.DragDirection dragDirection, Vector3 up, float size, float distance, Transform referenceTransform, int textureIndex)
			{
				Id = _currentId++;
				Direction = dragDirection;
				Up = up;
				Size = size;
				Distance = distance;
				ReferenceTransform = referenceTransform;
				TextureIndex = textureIndex;
				TextureIndex = 0;
			}

			public void SaveToFile()
			{
				Texture2D texture2D = new Texture2D(256, 256, TextureFormat.RGBA32, mipChain: false, linear: true);
				texture2D.LoadRawTextureData(Pixels);
				byte[] bytes = texture2D.EncodeToPNG();
				FileInfo fileInfo = new FileInfo($"C:\\Temp\\DragRenders\\{Id}.png");
				if (!fileInfo.Directory.Exists)
				{
					fileInfo.Directory.Create();
				}
				File.WriteAllBytes(fileInfo.FullName, bytes);
			}
		}

		private const int DragTempLayer = 2;

		private const int TextureSize = 256;

		[SerializeField]
		private bool _asynchronousGpuReadback;

		private Queue<DragJob> _asyncJobQueue;

		private Camera _camera;

		private Material _dragMaterial;

		private Stack<Material> _dragMaterialPool;

		[SerializeField]
		private Shader _dragShader;

		private RenderTexture[] _renderTextures;

		private Texture2D _resultTexture;

		public DragQueue Queue { get; private set; }

		public void CalculateDrag(IBodyScript bodyScript, Action<DragResult> callback)
		{
			List<BodyData> list = new List<BodyData>();
			if (bodyScript.IsDebris || bodyScript.Disconnected)
			{
				foreach (PartData part in bodyScript.PartIsland.Parts)
				{
					BodyData data = part.PartScript.BodyScript.Data;
					if (!list.Contains(data))
					{
						list.Add(data);
					}
				}
			}
			else
			{
				foreach (BodyData body in bodyScript.CraftScript.Data.Assembly.Bodies)
				{
					if (!body.BodyScript.IsDebris && !body.BodyScript.Disconnected)
					{
						list.Add(body);
					}
				}
			}
			List<BodyData> dragBodies = new List<BodyData>(1) { bodyScript.Data };
			StartCoroutine(CalculateDragCoroutine(bodyScript.Transform, list, dragBodies, callback));
		}

		public void CalculateDrag(ICraftScript craftScript)
		{
			if (Game.InDesignerScene)
			{
				IReadOnlyList<BodyData> bodies = craftScript.Data.Assembly.Bodies;
				IEnumerator enumerator = CalculateDragCoroutine(craftScript.Transform, bodies, bodies, delegate
				{
				});
				while (enumerator.MoveNext())
				{
				}
			}
			else
			{
				Debug.LogError("CalculateDrag(ICraftScript craftScript) should only be called from the designer.");
			}
		}

		protected virtual void Awake()
		{
			_camera = GetComponent<Camera>();
			_camera.enabled = false;
			Queue = new DragQueue(this);
			_dragMaterial = new Material(_dragShader);
			_dragMaterialPool = new Stack<Material>();
			_renderTextures = new RenderTexture[6];
			_asyncJobQueue = new Queue<DragJob>(6);
			_asynchronousGpuReadback = SystemInfo.supportsAsyncGPUReadback;
		}

		protected virtual void OnDestroy()
		{
			if (_resultTexture != null)
			{
				UnityEngine.Object.Destroy(_resultTexture);
				_resultTexture = null;
			}
			if (_renderTextures != null)
			{
				for (int i = 0; i < _renderTextures.Length; i++)
				{
					if (_renderTextures[i] != null)
					{
						UnityEngine.Object.Destroy(_renderTextures[i]);
						_renderTextures[i] = null;
					}
				}
			}
			if (_dragMaterial != null)
			{
				UnityEngine.Object.Destroy(_dragMaterial);
			}
			while (_dragMaterialPool.Count > 0)
			{
				UnityEngine.Object.Destroy(_dragMaterialPool.Pop());
			}
		}

		protected virtual void Update()
		{
			Queue.Update();
		}

		private static Color CreateIdColor(int id)
		{
			id++;
			byte g = (byte)(id >> 8);
			byte b = (byte)id;
			return new Color32(0, g, b, 0);
		}

		private static int ExtractIdFromColor(Color32 c)
		{
			return (c.g << 8) + c.b - 1;
		}

		private static DragCalculation InitializeDragCalculation(Transform referenceTransform, IEnumerable<BodyData> allBodies, IEnumerable<BodyData> dragBodies)
		{
			bool inFlightScene = Game.InFlightScene;
			DragCalculation dragCalculation = new DragCalculation();
			Vector3? vector = null;
			foreach (BodyData dragBody in dragBodies)
			{
				dragCalculation.BodyLookup.Add(dragBody.Id, dragBody);
				foreach (PartData part in dragBody.Parts)
				{
					if (!vector.HasValue)
					{
						vector = part.PartScript.Transform.position;
					}
					dragCalculation.PartLookup[part.Id] = part;
				}
				if (!inFlightScene)
				{
					continue;
				}
				foreach (IPartGroupScript partGroup in dragBody.BodyScript.PartGroups)
				{
					if (dragCalculation.PartGroupLookup.ContainsKey(partGroup.Id))
					{
						if (dragCalculation.PartGroupLookup[partGroup.Id] != partGroup)
						{
							Debug.LogError($"More than one part group with ID '{partGroup.Id}' was found when trying to calculate drag.");
						}
						continue;
					}
					dragCalculation.PartGroupLookup.Add(partGroup.Id, partGroup);
					if (partGroup.Id < dragCalculation.MinPartGroupId)
					{
						dragCalculation.MinPartGroupId = partGroup.Id;
					}
					if (partGroup.Id > dragCalculation.MaxPartGroupId)
					{
						dragCalculation.MaxPartGroupId = partGroup.Id;
					}
				}
			}
			if (dragCalculation.PartGroupLookup.Count > 0)
			{
				dragCalculation.PartGroupFastLookup = new IPartGroupScript[1 + dragCalculation.MaxPartGroupId - dragCalculation.MinPartGroupId];
				foreach (KeyValuePair<int, IPartGroupScript> item in dragCalculation.PartGroupLookup)
				{
					dragCalculation.PartGroupFastLookup[item.Key - dragCalculation.MinPartGroupId] = item.Value;
				}
			}
			Vector3 center = (vector.HasValue ? vector.Value : Vector3.zero);
			Bounds bounds = new Bounds(center, default(Vector3));
			dragCalculation.ReferenceTransform = referenceTransform;
			foreach (BodyData allBody in allBodies)
			{
				bool flag = dragCalculation.BodyLookup.ContainsKey(allBody.Id);
				if (inFlightScene)
				{
					foreach (IPartGroupScript partGroup2 in allBody.BodyScript.PartGroups)
					{
						int id = partGroup2.Id;
						IRendererMaterialMap partGroupRenderer = partGroup2.PartGroupRenderer;
						if (partGroupRenderer != null)
						{
							dragCalculation.Renderers.Add(new DragCalculation.RendererWrapper(partGroupRenderer, flag, id));
							if (flag)
							{
								bounds = Utilities.ExpandBounds(bounds, partGroupRenderer.Renderer.bounds);
							}
						}
						foreach (PartData part2 in partGroup2.Data.Parts)
						{
							if (!part2.Config.IncludeInDrag)
							{
								continue;
							}
							foreach (IRendererMaterialMap rendererMap in part2.PartScript.PartMaterialScript.RendererMaps)
							{
								if (!rendererMap.ExcludeFromDragModel && rendererMap.Renderer.gameObject.activeInHierarchy && rendererMap.Renderer.enabled)
								{
									dragCalculation.Renderers.Add(new DragCalculation.RendererWrapper(rendererMap, flag, id));
									if (flag)
									{
										bounds = Utilities.ExpandBounds(bounds, rendererMap.Renderer.bounds);
									}
								}
							}
						}
					}
					continue;
				}
				foreach (PartData part3 in allBody.Parts)
				{
					if (!part3.Config.IncludeInDrag)
					{
						continue;
					}
					foreach (IRendererMaterialMap rendererMap2 in part3.PartScript.PartMaterialScript.RendererMaps)
					{
						if (!rendererMap2.ExcludeFromDragModel && rendererMap2.Renderer.gameObject.activeInHierarchy && rendererMap2.Renderer.enabled)
						{
							dragCalculation.Renderers.Add(new DragCalculation.RendererWrapper(rendererMap2, flag, part3.Id));
							if (flag)
							{
								bounds = Utilities.ExpandBounds(bounds, rendererMap2.Renderer.bounds);
							}
						}
					}
				}
			}
			dragCalculation.LocalBounds = Utilities.ConvertWorldAabbToLocalAabb(bounds, referenceTransform);
			return dragCalculation;
		}

		private IEnumerator CalculateDragCoroutine(Transform referenceTransform, IReadOnlyList<BodyData> allBodies, IReadOnlyList<BodyData> dragBodies, Action<DragResult> callback)
		{
			if (dragBodies.Count == 0)
			{
				callback(null);
				yield break;
			}
			DragResult dragResult = null;
			try
			{
				DragCalculation dragCalculation = InitializeDragCalculation(referenceTransform, allBodies, dragBodies);
				Vector3 size = dragCalculation.LocalBounds.size;
				if (size.sqrMagnitude != 0f)
				{
					_camera.nearClipPlane = 10f;
					_camera.farClipPlane = 5000f;
					_camera.cullingMask = 4;
					_camera.SetReplacementShader(_dragShader, null);
					bool flag = _asynchronousGpuReadback && Game.InFlightScene;
					DragJob[] jobs = new DragJob[6]
					{
						new DragJob(Drag.DragDirection.Forward, referenceTransform.up, Mathf.Max(size.x, size.y), size.z * 2f, referenceTransform, flag ? 0 : 0),
						new DragJob(Drag.DragDirection.Backward, referenceTransform.up, Mathf.Max(size.x, size.y), size.z * 2f, referenceTransform, flag ? 1 : 0),
						new DragJob(Drag.DragDirection.Rightward, referenceTransform.up, Mathf.Max(size.z, size.y), size.x * 2f, referenceTransform, flag ? 2 : 0),
						new DragJob(Drag.DragDirection.Leftward, referenceTransform.up, Mathf.Max(size.z, size.y), size.x * 2f, referenceTransform, flag ? 3 : 0),
						new DragJob(Drag.DragDirection.Upward, referenceTransform.right, Mathf.Max(size.x, size.z), size.y * 2f, referenceTransform, flag ? 4 : 0),
						new DragJob(Drag.DragDirection.Downward, referenceTransform.right, Mathf.Max(size.x, size.z), size.y * 2f, referenceTransform, flag ? 5 : 0)
					};
					if (flag)
					{
						int currentJob = 0;
						while (currentJob < jobs.Length || _asyncJobQueue.Count > 0)
						{
							yield return new WaitForEndOfFrame();
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
									dragJob2.AsyncRequest = AsyncGPUReadback.Request(_camera.targetTexture);
									_asyncJobQueue.Enqueue(dragJob2);
								}
							}
						}
					}
					else
					{
						DragJob[] array = jobs;
						foreach (DragJob job in array)
						{
							yield return new WaitForEndOfFrame();
							if (job.ReferenceTransform != null)
							{
								RenderAndProcessDrag(dragCalculation, job);
							}
						}
					}
				}
				else
				{
					foreach (PartData value in dragCalculation.PartLookup.Values)
					{
						value.PartDrag.ClearDrag();
					}
				}
				dragResult = dragCalculation.DragResult;
			}
			finally
			{
				callback(dragResult);
			}
		}

		private RenderTexture GetRenderTexture(int index)
		{
			RenderTexture renderTexture = _renderTextures[index];
			if (renderTexture == null || !renderTexture.IsCreated())
			{
				renderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
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
				Debug.LogError("Async GPU Readback Error");
			}
			else if (dragJob.AsyncRequest.done)
			{
				_asyncJobQueue.Dequeue();
				dragJob.Pixels = dragJob.AsyncRequest.GetData<Color32>();
				return dragJob;
			}
			return null;
		}

		private void ProcessDragResults(DragCalculation dragCalculation, DragJob job)
		{
			float num = 1.5258789E-05f * (job.Size * job.Size);
			float num2 = 0f;
			List<int> list = null;
			List<int> list2 = null;
			NativeArray<Color32> pixels = job.Pixels;
			Drag.DragDirection direction = job.Direction;
			foreach (PartData value2 in dragCalculation.PartLookup.Values)
			{
				value2.PartDrag.ClearDrag(job.Direction);
			}
			if (Game.InFlightScene)
			{
				int length = pixels.Length;
				for (int i = 0; i < length; i++)
				{
					Color32 color = pixels[i];
					int num3 = (color.g << 8) + color.b - 1;
					if (num3 < 0)
					{
						continue;
					}
					float num4 = (float)(int)color.r * 0.003921569f;
					IPartGroupScript partGroupScript = ((num3 >= dragCalculation.MinPartGroupId && num3 <= dragCalculation.MaxPartGroupId) ? dragCalculation.PartGroupFastLookup[num3 - dragCalculation.MinPartGroupId] : null);
					if (partGroupScript != null)
					{
						int a = color.a;
						List<PartData> parts = partGroupScript.Data.Parts;
						if (parts.Count > a)
						{
							PartData partData = parts[a];
							float num5 = num * num4 * partData.DragScale;
							partData.PartDrag.AddDrag(direction, num5, Vector3.zero, num);
							num2 += num5;
						}
						else if (!(list ?? (list = new List<int>())).Contains(a))
						{
							list.Add(a);
							if (partGroupScript.GameObject.activeSelf)
							{
								Debug.Log($"Could not find part '{a}' in part group '{num3}' with drag {num4}");
							}
						}
					}
					else if (!(list2 ?? (list2 = new List<int>())).Contains(num3))
					{
						list2.Add(num3);
						Debug.Log($"Could not find part group '{num3}' with drag '{num4}'");
					}
				}
			}
			else
			{
				int length2 = pixels.Length;
				for (int j = 0; j < length2; j++)
				{
					Color32 color2 = pixels[j];
					int num6 = (color2.g << 8) + color2.b - 1;
					if (num6 >= 0)
					{
						float num7 = (float)(int)color2.r * 0.003921569f;
						PartData value = null;
						if (dragCalculation.PartLookup.TryGetValue(num6, out value))
						{
							float num8 = num * num7 * value.DragScale;
							value.PartDrag.AddDrag(direction, num8, Vector3.zero, num);
							num2 += num8;
						}
						else if (!(list ?? (list = new List<int>())).Contains(num6))
						{
							list.Add(num6);
							Debug.Log($"Could not find part '{num6}' with drag {num7}");
						}
					}
				}
			}
			dragCalculation.DragResult.TotalDrag.SetDrag(direction, num2, 0f);
		}

		private void RenderAndProcessDrag(DragCalculation dragCalculation, DragJob job)
		{
			RenderDrag(dragCalculation, job);
			if (_resultTexture == null)
			{
				_resultTexture = new Texture2D(256, 256, TextureFormat.RGBA32, mipChain: false, linear: true);
				_resultTexture.filterMode = FilterMode.Point;
				_resultTexture.name = "Drag Calculator Texture";
			}
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = _camera.targetTexture;
			_resultTexture.ReadPixels(_camera.pixelRect, 0, 0, recalculateMipMaps: false);
			RenderTexture.active = active;
			job.Pixels = _resultTexture.GetRawTextureData<Color32>();
			ProcessDragResults(dragCalculation, job);
		}

		private void RenderDrag(DragCalculation dragCalculation, DragJob job)
		{
			bool inFlightScene = Game.InFlightScene;
			_camera.targetTexture = GetRenderTexture(job.TextureIndex);
			foreach (DragCalculation.RendererWrapper renderer in dragCalculation.Renderers)
			{
				Material material = ((_dragMaterialPool.Count > 0) ? _dragMaterialPool.Pop() : UnityEngine.Object.Instantiate(_dragMaterial));
				material.SetColor(inFlightScene ? ShaderPropertyIds.PartGroupId : ShaderPropertyIds.PartId, CreateIdColor(renderer.CalculateDrag ? renderer.Id : (-1)));
				renderer.RenderMap.StartTempRender(2, material);
			}
			Vector3 vector = dragCalculation.ReferenceTransform.TransformPoint(dragCalculation.LocalBounds.center);
			Vector3 vector2 = dragCalculation.ReferenceTransform.TransformDirection(Drag.DragDirectionToVector3(job.Direction));
			base.transform.position = vector + vector2 * 2500f;
			base.transform.rotation = Quaternion.LookRotation(-vector2, job.Up);
			_camera.orthographicSize = job.Size / 2f;
			_camera.Render();
			foreach (DragCalculation.RendererWrapper renderer2 in dragCalculation.Renderers)
			{
				Material sharedMaterial = renderer2.RenderMap.Renderer.sharedMaterial;
				_dragMaterialPool.Push(sharedMaterial);
				renderer2.RenderMap.EndTempRender();
			}
		}
	}
}
