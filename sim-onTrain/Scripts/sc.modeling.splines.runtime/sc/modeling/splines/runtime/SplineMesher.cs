using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.Splines;

namespace sc.modeling.splines.runtime
{
	[ExecuteInEditMode]
	[AddComponentMenu("Splines/Spline Mesher")]
	[HelpURL("https://staggart.xyz/sm-docs/")]
	[SelectionBase]
	public class SplineMesher : MonoBehaviour
	{
		[Serializable]
		public class Cap
		{
			public enum Position
			{
				Start = 0,
				End = 1
			}

			public readonly Position position;

			[Tooltip("The source object to use. An instance of this will be spawned. It may be destroyed and recreated under certain conditions, so manual changes may be lost.")]
			public GameObject prefab;

			[SerializeField]
			private GameObject previousPrefab;

			[Tooltip("Positional offset, relative to the curve's tangent")]
			public Vector3 offset;

			[Tooltip("Shifts the object along the spline curve by this many units")]
			[Min(0f)]
			public float shift;

			[Tooltip("Align the object's forward direction to the tangent and roll of the spline")]
			public bool align = true;

			[Tooltip("Rotation in degrees, added to the object's rotation")]
			public Vector3 rotation;

			[Tooltip("Factor in the scale configured under the Deforming section, as well as scale data points created in the editor.")]
			public bool matchScale = true;

			public Vector3 scale = Vector3.one;

			public GameObject[] instances = Array.Empty<GameObject>();

			public int InstanceCount => instances.Length;

			public Cap(Position position)
			{
				this.position = position;
			}

			public bool HasPrefabChanged()
			{
				if (!prefab)
				{
					return true;
				}
				if (prefab != previousPrefab)
				{
					previousPrefab = prefab;
					return true;
				}
				return false;
			}

			public bool RequiresRespawn()
			{
				if (!HasNoInstances() && !HasPrefabChanged())
				{
					return HasMissingInstances();
				}
				return true;
			}

			public bool HasNoInstances()
			{
				return InstanceCount == 0;
			}

			public bool HasMissingInstances()
			{
				for (int i = 0; i < instances.Length; i++)
				{
					if (!instances[i])
					{
						return true;
					}
				}
				return false;
			}

			public void DestroyInstances()
			{
				for (int i = 0; i < instances.Length; i++)
				{
					if ((bool)instances[i])
					{
						DestroyInstance(instances[i]);
					}
				}
			}

			private static void DestroyInstance(UnityEngine.Object obj)
			{
				UnityEngine.Object.Destroy(obj);
			}

			public void Respawn(int splineCount, Transform parent)
			{
				DestroyInstances();
				if (!prefab)
				{
					instances = Array.Empty<GameObject>();
					return;
				}
				instances = new GameObject[splineCount];
				for (int i = 0; i < instances.Length; i++)
				{
					GameObject gameObject = InstantiatePrefab(prefab);
					gameObject.transform.SetParent(parent);
					instances[i] = gameObject;
					previousPrefab = prefab;
				}
			}

			private GameObject InstantiatePrefab(UnityEngine.Object source)
			{
				bool flag = false;
				GameObject gameObject = null;
				if (!flag)
				{
					gameObject = UnityEngine.Object.Instantiate(source) as GameObject;
				}
				if (gameObject == null)
				{
					Debug.LogError($"Failed to spawn cap instance. Was the prefab source as scene object and deleted? Source is prefab: {flag}");
				}
				return gameObject;
			}

			public void ApplyTransform(SplineMesher splineMesher)
			{
				for (int i = 0; i < instances.Length; i++)
				{
					Transform transform = instances[i].transform;
					float num = (float)position;
					float num2 = splineMesher.splineContainer.Splines[i].CalculateLength(splineMesher.splineContainer.transform.localToWorldMatrix);
					float num3 = shift;
					if (position == Position.Start)
					{
						num3 += splineMesher.settings.distribution.trimStart;
					}
					else if (position == Position.End)
					{
						num3 += splineMesher.settings.distribution.trimEnd;
					}
					float num4 = num3 / num2;
					if (position == Position.End)
					{
						num4 = 0f - num4;
					}
					num += num4;
					num = Mathf.Clamp(num, 0.0001f, 0.9999f);
					splineMesher.splineContainer.Splines[i].Evaluate(num, out var float5, out var tangent, out var upVector);
					tangent = splineMesher.splineContainer.transform.rotation * tangent;
					upVector = splineMesher.splineContainer.transform.rotation * upVector;
					if (position == Position.Start)
					{
						tangent = -tangent;
					}
					float3 float6 = math.normalize(tangent);
					float3 float7 = math.cross(float6, upVector);
					Quaternion quaternion2 = Quaternion.identity;
					if (align)
					{
						quaternion2 = Quaternion.LookRotation(float6, upVector);
						quaternion2 = splineMesher.SampleRollRotation(splineMesher.splineContainer.Splines[i], float6, num * num2, i) * quaternion2;
						if (position == Position.End || (position == Position.Start && scale.z < 0f))
						{
							float7 = -float7;
						}
						_ = splineMesher.settings.deforming.ignoreKnotRotation;
					}
					float5 += float7 * (offset.x - splineMesher.settings.deforming.curveOffset.x);
					float5 += upVector * (offset.y - splineMesher.settings.deforming.curveOffset.y);
					float5 += float6 * offset.z;
					float5.x += splineMesher.settings.deforming.pivotOffset.x;
					float5.y += splineMesher.settings.deforming.pivotOffset.y;
					float5 = splineMesher.splineContainer.transform.TransformPoint(float5);
					if (splineMesher.settings.conforming.enable && SplineMeshGenerator.PerformConforming(float5, splineMesher.settings.conforming, 1f, out var hitPosition, out var hitNormal))
					{
						float5.y = hitPosition.y + offset.y;
						if (splineMesher.settings.conforming.align && align)
						{
							quaternion2 = quaternion.LookRotation(float6, hitNormal);
						}
					}
					quaternion2 *= Quaternion.Euler(rotation);
					Vector3 localScale = scale;
					if (matchScale)
					{
						localScale.x *= splineMesher.settings.deforming.scale.x;
						localScale.y *= splineMesher.settings.deforming.scale.y;
						localScale.z *= splineMesher.settings.deforming.scale.z;
						float3 float8 = splineMesher.SampleScale(num * num2, i);
						localScale.x *= float8.x;
						localScale.y *= float8.y;
					}
					transform.localScale = localScale;
					transform.SetPositionAndRotation(float5, quaternion2);
					transform.hideFlags = HideFlags.NotEditable;
				}
			}
		}

		[Flags]
		public enum RebuildTriggers
		{
			[InspectorName("Via scripting")]
			None = 0,
			[InspectorName("On Spline Change")]
			OnSplineChanged = 1,
			OnSplineAdded = 2,
			OnSplineRemoved = 4,
			[InspectorName("On Start()")]
			OnStart = 8,
			OnUIChange = 0x10,
			OnTransformChange = 0x20
		}

		public delegate void Action(SplineMesher instance);

		[Serializable]
		public class RebuildEvent : UnityEvent
		{
		}

		public enum SplineChangeReaction
		{
			[InspectorName("During Changes")]
			During = 0,
			[InspectorName("After Changes")]
			WhenDone = 1
		}

		[Serializable]
		public struct VertexColorChannel
		{
			public struct LerpVertexColorData : IInterpolator<VertexColorChannel>
			{
				private readonly float baseValue;

				public LerpVertexColorData(float baseValue)
				{
					this.baseValue = baseValue;
				}

				public VertexColorChannel Interpolate(VertexColorChannel a, VertexColorChannel b, float t)
				{
					float a2 = BlendVertexColorChannel(a, baseValue);
					float b2 = BlendVertexColorChannel(b, baseValue);
					return Mathf.Lerp(a2, b2, t);
				}
			}

			public float value;

			public bool blend;

			public static implicit operator float(VertexColorChannel value)
			{
				return value.value;
			}

			public static implicit operator VertexColorChannel(float value)
			{
				return new VertexColorChannel
				{
					value = value
				};
			}
		}

		public struct Float3Interpolator : IInterpolator<float3>
		{
			public Settings.InterpolationType mode;

			public float3 Interpolate(float3 a, float3 b, float t)
			{
				if (mode == Settings.InterpolationType.Linear)
				{
					return math.lerp(a, b, t);
				}
				if (mode == Settings.InterpolationType.EaseInEaseOut)
				{
					return math.lerp(a, b, EaseInOut());
				}
				return a;
				float EaseInOut()
				{
					float num = 2f * t * t;
					if (t > 0.5f)
					{
						num = 4f * t - num - 1f;
					}
					return num;
				}
			}
		}

		public Cap startCap = new Cap(Cap.Position.Start);

		public Cap endCap = new Cap(Cap.Position.End);

		public const string VERSION = "1.2.9";

		public const string kPackageRoot = "Packages/com.staggartcreations.splinemesher";

		public Mesh sourceMesh;

		[Tooltip("The axis of the mesh that's considered to its forward direction.\n\nConventionally, the Z-axis is forward. If you have to change this it's strongly recommend to fix the mesh's orientation instead!")]
		public Vector3 rotation;

		[Tooltip("The GameObject to which a Mesh Filter component may be added. The output mesh will be assigned here.")]
		public GameObject outputObject;

		[Obsolete("Set the Rebuild Trigger flag \"On Start\" instead", false)]
		public bool rebuildOnStart;

		[Tooltip("Control which sort of events cause the mesh to be regenerated.\n\nFor instance when the spline changes (default), or on the component's Start() function.\n\nIf none are selected you need to call the Rebuild() function through script.")]
		public RebuildTriggers rebuildTriggers = RebuildTriggers.OnSplineChanged | RebuildTriggers.OnSplineAdded | RebuildTriggers.OnSplineRemoved | RebuildTriggers.OnUIChange | RebuildTriggers.OnTransformChange;

		[SerializeField]
		private MeshCollider meshCollider;

		public Settings settings = new Settings();

		[HideInInspector]
		public RebuildEvent onPreRebuild;

		[HideInInspector]
		public RebuildEvent onPostRebuild;

		[SerializeField]
		[FormerlySerializedAs("meshFilter")]
		private MeshFilter m_meshFilter;

		private Mesh inputMesh;

		private Mesh outputMesh;

		private Mesh outputCollisionMesh;

		public SplineContainer splineContainer;

		[SerializeField]
		[HideInInspector]
		private int splineCount;

		[Tooltip("Determines when a change to the spline should be detected. Using the After Changes option for complex set ups to improve performance.")]
		public SplineChangeReaction splineChangeMode;

		public List<SplineData<float3>> scaleData = new List<SplineData<float3>>();

		public List<SplineData<float>> rollData = new List<SplineData<float>>();

		public List<SplineData<VertexColorChannel>> vertexColorRedData = new List<SplineData<VertexColorChannel>>();

		public List<SplineData<VertexColorChannel>> vertexColorGreenData = new List<SplineData<VertexColorChannel>>();

		public List<SplineData<VertexColorChannel>> vertexColorBlueData = new List<SplineData<VertexColorChannel>>();

		public List<SplineData<VertexColorChannel>> vertexColorAlphaData = new List<SplineData<VertexColorChannel>>();

		public static Float3Interpolator scaleInterpolator;

		private Spline lastEditedSpline;

		private int lastEditedSplineIndex = -1;

		public float debounceTime = 0.1f;

		private float lastChangeTime = -1f;

		private bool isTrackingChanges;

		private Coroutine debounceCoroutine;

		public MeshFilter meshFilter
		{
			get
			{
				return m_meshFilter;
			}
			private set
			{
				m_meshFilter = value;
			}
		}

		public static event Action onPreRebuildMesh;

		public static event Action onPostRebuildMesh;

		private void SetColliderStates(bool startState, bool endState, out bool startDisabled, out bool endDisabled)
		{
			startDisabled = SetStateCollider(startCap, startState);
			endDisabled = SetStateCollider(endCap, endState);
		}

		private static bool SetStateCollider(Cap cap, bool state)
		{
			bool result = false;
			if (cap.instances.Length != 0)
			{
				for (int i = 0; i < cap.instances.Length; i++)
				{
					if (!cap.instances[i])
					{
						continue;
					}
					Collider[] componentsInChildren = cap.instances[i].gameObject.GetComponentsInChildren<Collider>(includeInactive: false);
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (componentsInChildren[j].enabled != state)
						{
							componentsInChildren[j].enabled = state;
							result = true;
						}
					}
				}
			}
			return result;
		}

		public void DetachCaps()
		{
			DetachCap(startCap);
			DetachCap(endCap);
			void DetachCap(Cap cap)
			{
				int num = cap.instances.Length;
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						if ((bool)cap.instances[i])
						{
							cap.instances[i].transform.parent = base.transform.parent;
						}
					}
					cap.instances = Array.Empty<GameObject>();
					cap.prefab = null;
				}
			}
		}

		private void Reset()
		{
			meshFilter = GetComponent<MeshFilter>();
			if ((bool)meshFilter)
			{
				outputObject = meshFilter.gameObject;
			}
			splineContainer = GetComponentInParent<SplineContainer>();
		}

		private void Start()
		{
			if (rebuildTriggers.HasFlag(RebuildTriggers.OnStart))
			{
				Rebuild();
			}
		}

		private void OnEnable()
		{
			SubscribeSplineCallbacks();
		}

		private void OnDisable()
		{
			UnsubscribeSplineCallbacks();
		}

		private void SubscribeSplineCallbacks()
		{
			SplineContainer.SplineAdded += OnSplineAdded;
			SplineContainer.SplineRemoved += OnSplineRemoved;
			Spline.Changed += OnSplineChanged;
		}

		private void UnsubscribeSplineCallbacks()
		{
			SplineContainer.SplineAdded -= OnSplineAdded;
			SplineContainer.SplineRemoved -= OnSplineRemoved;
			Spline.Changed -= OnSplineChanged;
		}

		public void UpdateCaps()
		{
			if ((bool)splineContainer)
			{
				bool num = splineContainer.Splines.Count != splineCount;
				if (num || startCap.RequiresRespawn())
				{
					startCap.Respawn(splineCount, base.transform);
				}
				if (num || endCap.RequiresRespawn())
				{
					endCap.Respawn(splineCount, base.transform);
				}
				bool flag = false;
				if (settings.conforming.enable && (bool)meshCollider && meshCollider.enabled)
				{
					meshCollider.enabled = false;
					flag = true;
				}
				SetColliderStates(startState: false, endState: false, out var startDisabled, out var endDisabled);
				startCap.ApplyTransform(this);
				endCap.ApplyTransform(this);
				SetColliderStates(startDisabled, endDisabled, out var _, out var _);
				if (flag)
				{
					meshCollider.enabled = true;
				}
			}
		}

		public void ValidateOutput()
		{
			if (!outputObject)
			{
				return;
			}
			if (!meshFilter)
			{
				meshFilter = outputObject.GetComponent<MeshFilter>();
			}
			if (!meshFilter)
			{
				meshFilter = outputObject.AddComponent<MeshFilter>();
				if (!outputObject.GetComponent<MeshRenderer>())
				{
					outputObject.AddComponent<MeshRenderer>();
				}
			}
		}

		public void Rebuild()
		{
			if (!splineContainer || !outputObject)
			{
				return;
			}
			bool flag = !settings.collision.enable || !settings.collision.colliderOnly;
			meshFilter = outputObject.GetComponent<MeshFilter>();
			if (flag && !meshFilter)
			{
				return;
			}
			SplineMesher.onPreRebuildMesh?.Invoke(this);
			onPreRebuild?.Invoke();
			ValidateData();
			if (!sourceMesh)
			{
				return;
			}
			if (Application.isPlaying && !sourceMesh.isReadable)
			{
				throw new Exception("[Spline Mesher] To use this at runtime, the mesh \"" + sourceMesh.name + "\" requires the Read/Write option enabled in its import settings. For procedurally created geometry, use \"Mesh.UploadMeshData(false)\"");
			}
			inputMesh = SplineMeshGenerator.TransformMesh(sourceMesh, rotation, settings.deforming.scale.x < 0f, settings.deforming.scale.y < 0f);
			if (flag)
			{
				int num;
				if (settings.collision.enable)
				{
					num = (((bool)meshCollider) ? 1 : 0);
					if (num != 0)
					{
						meshCollider.enabled = false;
					}
				}
				else
				{
					num = 0;
				}
				SetColliderStates(startState: false, endState: false, out var startDisabled, out var endDisabled);
				if ((bool)outputMesh)
				{
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(outputMesh);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(outputMesh);
					}
				}
				outputMesh = new Mesh();
				SplineMeshGenerator.CreateMesh(ref outputMesh, splineContainer, inputMesh, outputObject.transform.worldToLocalMatrix, settings, scaleData, rollData, vertexColorRedData, vertexColorGreenData, vertexColorBlueData, vertexColorAlphaData);
				meshFilter.mesh = outputMesh;
				SetColliderStates(startDisabled, endDisabled, out var _, out var _);
				if (num != 0)
				{
					meshCollider.enabled = true;
				}
			}
			else if ((bool)meshFilter && (bool)meshFilter.sharedMesh)
			{
				meshFilter.mesh = null;
			}
			CreateCollider();
			SplineMesher.onPostRebuildMesh?.Invoke(this);
			onPostRebuild?.Invoke();
		}

		private void CreateCollider()
		{
			if (!splineContainer)
			{
				return;
			}
			if (settings.collision.enable)
			{
				if (!meshCollider)
				{
					meshCollider = outputObject.GetComponent<MeshCollider>();
				}
				if (!meshCollider)
				{
					meshCollider = outputObject.AddComponent<MeshCollider>();
				}
				Mesh mesh = settings.collision.collisionMesh;
				if (settings.collision.type == Settings.ColliderType.Box)
				{
					mesh = SplineMeshGenerator.CreateBoundsMesh(inputMesh, settings.collision.boxSubdivisions);
				}
				else if ((bool)settings.collision.collisionMesh)
				{
					mesh = SplineMeshGenerator.TransformMesh(settings.collision.collisionMesh, rotation, settings.deforming.scale.x < 0f, settings.deforming.scale.y < 0f);
				}
				if ((bool)mesh && meshCollider.enabled)
				{
					meshCollider.enabled = false;
					SetColliderStates(startState: false, endState: false, out var startDisabled, out var endDisabled);
					if ((bool)outputCollisionMesh)
					{
						if (Application.isPlaying)
						{
							UnityEngine.Object.Destroy(outputCollisionMesh);
						}
						else
						{
							UnityEngine.Object.DestroyImmediate(outputCollisionMesh);
						}
					}
					outputCollisionMesh = new Mesh();
					SplineMeshGenerator.CreateMesh(ref outputCollisionMesh, splineContainer, mesh, meshCollider.transform.worldToLocalMatrix, settings, scaleData, rollData);
					meshCollider.sharedMesh = outputCollisionMesh;
					meshCollider.sharedMesh.name += " Collider";
					SetColliderStates(startDisabled, endDisabled, out var _, out var _);
					meshCollider.enabled = true;
				}
				else
				{
					meshCollider.sharedMesh = null;
				}
			}
			else if ((bool)meshCollider)
			{
				UnityEngine.Object.DestroyImmediate(meshCollider);
			}
		}

		public void ListenForTransformChanges()
		{
			if (rebuildTriggers.HasFlag(RebuildTriggers.OnTransformChange) && Time.frameCount % 2 == 0)
			{
				bool flag = false;
				if ((bool)splineContainer)
				{
					flag |= splineContainer.transform.hasChanged;
					splineContainer.transform.hasChanged = false;
				}
				if ((bool)outputObject)
				{
					flag |= outputObject.transform.hasChanged;
					outputObject.transform.hasChanged = false;
				}
				if (flag)
				{
					Rebuild();
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			ListenForTransformChanges();
		}

		public float GetLastRebuildTime()
		{
			return 0f;
		}

		private static float BlendVertexColorChannel(VertexColorChannel data, float baseValue)
		{
			float num = baseValue;
			if (data.blend)
			{
				return num + data.value;
			}
			return data.value;
		}

		private void OnSplineChanged(Spline spline, int knotIndex, SplineModification modificationType)
		{
			if (!splineContainer || !rebuildTriggers.HasFlag(RebuildTriggers.OnSplineChanged))
			{
				return;
			}
			int num = Array.IndexOf(splineContainer.Splines.ToArray(), spline);
			if (num < 0)
			{
				return;
			}
			splineCount = splineContainer.Splines.Count;
			lastEditedSpline = spline;
			lastEditedSplineIndex = num;
			if (splineChangeMode == SplineChangeReaction.WhenDone)
			{
				lastChangeTime = Time.realtimeSinceStartup;
				if (Application.isPlaying)
				{
					if (debounceCoroutine != null)
					{
						StopCoroutine(debounceCoroutine);
					}
					debounceCoroutine = StartCoroutine(DebounceCoroutine());
				}
				else if (!isTrackingChanges)
				{
					isTrackingChanges = true;
				}
			}
			else if (splineChangeMode == SplineChangeReaction.During)
			{
				ExecuteAfterSplineChanges();
			}
		}

		private void EditorUpdate()
		{
			if (isTrackingChanges && Time.realtimeSinceStartup - lastChangeTime >= debounceTime)
			{
				ExecuteAfterSplineChanges();
				isTrackingChanges = false;
			}
		}

		private IEnumerator DebounceCoroutine()
		{
			yield return new WaitForSeconds(debounceTime);
			ExecuteAfterSplineChanges();
		}

		private void ExecuteAfterSplineChanges()
		{
			if (lastEditedSplineIndex >= 0)
			{
				Rebuild();
				UpdateCaps();
			}
		}

		private void OnSplineAdded(SplineContainer container, int index)
		{
			if ((bool)splineContainer && rebuildTriggers.HasFlag(RebuildTriggers.OnSplineAdded) && container.GetHashCode() == splineContainer.GetHashCode())
			{
				splineCount = splineContainer.Splines.Count;
				Rebuild();
			}
		}

		private void OnSplineRemoved(SplineContainer container, int index)
		{
			if ((bool)splineContainer && rebuildTriggers.HasFlag(RebuildTriggers.OnSplineRemoved) && !(container != splineContainer))
			{
				splineCount = splineContainer.Splines.Count;
				if (index < scaleData.Count)
				{
					scaleData.RemoveAt(index);
				}
				if (index < rollData.Count)
				{
					rollData.RemoveAt(index);
				}
				if (index < vertexColorRedData.Count)
				{
					vertexColorRedData.RemoveAt(index);
				}
				if (index < vertexColorGreenData.Count)
				{
					vertexColorGreenData.RemoveAt(index);
				}
				if (index < vertexColorBlueData.Count)
				{
					vertexColorBlueData.RemoveAt(index);
				}
				if (index < vertexColorAlphaData.Count)
				{
					vertexColorAlphaData.RemoveAt(index);
				}
				Rebuild();
			}
		}

		public void ResetScaleData()
		{
			if ((bool)splineContainer)
			{
				scaleData.Clear();
				ValidateData();
				Rebuild();
			}
		}

		public void ResetRollData()
		{
			if ((bool)splineContainer)
			{
				rollData.Clear();
				ValidateData();
				Rebuild();
			}
		}

		public void ResetVertexColorData()
		{
			if ((bool)splineContainer)
			{
				vertexColorRedData.Clear();
				vertexColorGreenData.Clear();
				vertexColorBlueData.Clear();
				vertexColorAlphaData.Clear();
				ValidateData();
				Rebuild();
			}
		}

		public void ReverseSpline()
		{
			if ((bool)splineContainer)
			{
				for (int i = 0; i < splineContainer.Splines.Count; i++)
				{
					SplineUtility.ReverseFlow(splineContainer.Splines[i]);
				}
			}
		}

		public void ValidateData()
		{
			if ((bool)splineContainer)
			{
				splineCount = splineContainer.Splines.Count;
				ValidateScaleData();
				ValidateRollData();
				ValidateVertexColorData(ref vertexColorRedData);
				ValidateVertexColorData(ref vertexColorGreenData);
				ValidateVertexColorData(ref vertexColorBlueData);
				ValidateVertexColorData(ref vertexColorAlphaData);
			}
		}

		private void ValidateScaleData()
		{
			if (scaleData.Count < splineCount)
			{
				int num = splineCount - scaleData.Count;
				for (int i = 0; i < num; i++)
				{
					SplineData<float3> splineData = new SplineData<float3>();
					splineData.DefaultValue = Vector3.one;
					splineData.PathIndexUnit = settings.deforming.scalePathIndexUnit;
					scaleData.Add(splineData);
				}
			}
			for (int j = 0; j < scaleData.Count; j++)
			{
				if (scaleData[j].PathIndexUnit != settings.deforming.scalePathIndexUnit)
				{
					ConvertIndexUnit(splineContainer.Splines[j], ref scaleData, j, settings.deforming.scalePathIndexUnit);
				}
			}
		}

		private void ValidateRollData()
		{
			if (rollData.Count < splineCount)
			{
				int num = splineCount - rollData.Count;
				for (int i = 0; i < num; i++)
				{
					SplineData<float> splineData = new SplineData<float>();
					splineData.DefaultValue = 0f;
					splineData.PathIndexUnit = settings.deforming.rollPathIndexUnit;
					rollData.Add(splineData);
				}
			}
			for (int j = 0; j < rollData.Count; j++)
			{
				if (rollData[j].PathIndexUnit != settings.deforming.rollPathIndexUnit)
				{
					ConvertIndexUnit(splineContainer.Splines[j], ref rollData, j, settings.deforming.rollPathIndexUnit);
				}
			}
		}

		private void ConvertIndexUnit<T>(ISpline spline, ref List<SplineData<T>> data, int index, PathIndexUnit targetUnit)
		{
			for (int i = 0; i < data[index].Count; i++)
			{
				data[index].ConvertPathUnit(spline, targetUnit);
			}
			data[index].PathIndexUnit = targetUnit;
		}

		private void ValidateVertexColorData(ref List<SplineData<VertexColorChannel>> channel)
		{
			int num = splineCount - channel.Count;
			for (int i = 0; i < num; i++)
			{
				SplineData<VertexColorChannel> splineData = new SplineData<VertexColorChannel>();
				splineData.DefaultValue = new VertexColorChannel
				{
					value = 0f,
					blend = true
				};
				splineData.PathIndexUnit = settings.color.pathIndexUnit;
				channel.Add(splineData);
			}
			for (int j = 0; j < channel.Count; j++)
			{
				if (channel[j].PathIndexUnit != settings.color.pathIndexUnit)
				{
					ConvertIndexUnit(splineContainer.Splines[j], ref channel, j, settings.color.pathIndexUnit);
				}
			}
		}

		public float3 SampleScale(float distance, int splineIndex)
		{
			float3 result = 1f;
			if (scaleData != null)
			{
				scaleInterpolator.mode = settings.deforming.scaleInterpolation;
				if (scaleData[splineIndex].Count > 0)
				{
					result = scaleData[splineIndex].Evaluate(splineContainer.Splines[splineIndex], distance, scaleData[splineIndex].PathIndexUnit, scaleInterpolator);
				}
			}
			return result;
		}

		public Quaternion SampleRollRotation(ISpline spline, Vector3 forward, float distance, int splineIndex)
		{
			float num = ((settings.deforming.rollFrequency > 0f) ? (settings.deforming.rollFrequency * distance) : 1f);
			float num2 = settings.deforming.rollAngle * num;
			if (rollData != null && rollData[splineIndex].Count > 0)
			{
				num2 += rollData[splineIndex].Evaluate(spline, splineContainer.Splines[splineIndex].ConvertIndexUnit(distance, PathIndexUnit.Distance, settings.deforming.rollPathIndexUnit), settings.deforming.rollPathIndexUnit, SplineMeshGenerator.FloatInterpolator);
			}
			return Quaternion.AngleAxis(0f - num2, forward);
		}

		public float3 SampleScale(Vector3 worldPosition)
		{
			Vector3 vector = splineContainer.transform.InverseTransformPoint(worldPosition);
			int num = 0;
			SplineUtility.GetNearestPoint(splineContainer.Splines[num], vector, out var _, out var t, 2);
			float distance = splineContainer.Splines[num].ConvertIndexUnit(t, PathIndexUnit.Normalized, scaleData[num].PathIndexUnit);
			return SampleScale(distance, num);
		}

		[Obsolete("Use the native SplineUtility.FitSplineToPoints function instead.")]
		public void CreateSplineFromPoints(Vector3[] positions, bool smooth)
		{
		}
	}
}
