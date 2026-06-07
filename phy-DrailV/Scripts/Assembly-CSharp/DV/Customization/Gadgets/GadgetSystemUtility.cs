using System;
using System.Collections.Generic;
using System.Linq;
using DV.CabControls;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Customization.Gadgets
{
	public class GadgetSystemUtility : SingletonBehaviour<GadgetSystemUtility>
	{
		public readonly struct HighlightMesh
		{
			public readonly Mesh mesh;

			public readonly Matrix4x4 localMatrix;

			public HighlightMesh(MeshFilter mf, Transform root)
			{
				mesh = mf.sharedMesh;
				localMatrix = root.worldToLocalMatrix * mf.transform.localToWorldMatrix;
			}
		}

		private struct WireDisplayData
		{
			public Vector3 from;

			public Vector3 to;

			public WireHighlightMode highlight;

			public WireDisplayData(Vector3 from, Vector3 to, WireHighlightMode highlight)
			{
				this.from = from;
				this.to = to;
				this.highlight = highlight;
			}
		}

		public const float BOUNDS_INFLATION = 0.005f;

		public const float GADGET_DEPTH_OFFSET_HACK = 0.08f;

		public const Layers.DVLayerMask GadgetPlacementQueryLayerMask = Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Interactable | Layers.DVLayerMask.Gadget_Mesh_Placing;

		public const Layers.DVLayerMask GadgetPlacementValidLayerMask = Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Gadget_Mesh_Placing;

		public const Layers.DVLayerMask GadgetInteractionLayerMask = Layers.DVLayerMask.Interactable;

		public static readonly Color COLOR_HIGHLIGHT_BAD = new Color(1f, 0f, 0f, 0.1f);

		public static readonly Color COLOR_HIGHLIGHT_MAYBE = new Color(0.9f, 0.85f, 0f, 0.1f);

		public static readonly Color COLOR_HIGHLIGHT_GOOD = new Color(0f, 0.85f, 0f, 0.1f);

		public static readonly Color COLOR_HIGHLIGHT_NOT_YET = new Color(0f, 0.65f, 1f, 0.1f);

		public static readonly Color COLOR_HIGHLIGHT_WIRING = new Color(0.5f, 0f, 1f, 0.1f);

		public static readonly Color COLOR_HIGHLIGHT_EDIT = new Color(0.5f, 1f, 1f, 0.1f);

		private static readonly int materialColorID = Shader.PropertyToID("_Color");

		private static Material material;

		[SerializeField]
		[Header("Highlights")]
		private Material boundsMaterial;

		[SerializeField]
		private Mesh boundsMesh;

		[SerializeField]
		private LayerMask boundsRenderLayer;

		[SerializeField]
		[Header("Linkage Materials")]
		private Material linkExists;

		[SerializeField]
		private Material linkSeeking;

		[SerializeField]
		private Material linkValid;

		[SerializeField]
		private Material linkCancel;

		[Header("Audio")]
		[SerializeField]
		private AudioClip soundOnGadgetPlaced;

		[SerializeField]
		private AudioClip soundOnGadgetRemoved;

		[SerializeField]
		private AudioClip soundOnMountUntaped;

		[SerializeField]
		[Header("Settings")]
		private float linkLineWidth = 0.05f;

		private readonly List<LineRenderer> lineRenderers = new List<LineRenderer>();

		private readonly List<WireDisplayData> wireDisplayData = new List<WireDisplayData>();

		private ItemPlacerNonVr itemPlacer;

		public static bool AllowGadgetPlacement
		{
			get
			{
				if (SingletonBehaviour<GadgetSystemUtility>.Instance.itemPlacer == null || !SingletonBehaviour<GadgetSystemUtility>.Instance.itemPlacer.Processing)
				{
					return !SingletonBehaviour<ScreenspaceMouse>.Instance.on;
				}
				return false;
			}
		}

		public AudioClip SoundOnGadgetPlaced => soundOnGadgetPlaced;

		public AudioClip SoundOnGadgetRemoved => soundOnGadgetRemoved;

		public AudioClip SoundOnMountUntaped => soundOnMountUntaped;

		public string[] AllowedGadgetNames { get; set; }

		public GameObject[] AllowedGadgetInstances { get; set; }

		public Collider[] AllowedPlacement { get; set; }

		public bool StrictPlacementMode { get; set; }

		public float DotProductLimit { get; set; } = 1f;

		public GadgetBase[] AllowedWiring { get; set; }

		public GadgetBase[] AllowedSoldering { get; set; }

		public new static string AllowAutoCreate()
		{
			return null;
		}

		public static void DrawBounds(Vector3 position, Quaternion rotation, Vector3 center, Vector3 size, Color color)
		{
			if (material == null)
			{
				material = new Material(SingletonBehaviour<GadgetSystemUtility>.Instance.boundsMaterial);
			}
			material.SetColor(materialColorID, color);
			size += new Vector3(0.005f, 0.005f, 0.005f);
			Graphics.DrawMesh(SingletonBehaviour<GadgetSystemUtility>.Instance.boundsMesh, Matrix4x4.TRS(position + rotation * center, rotation, size), material, SingletonBehaviour<GadgetSystemUtility>.Instance.boundsRenderLayer);
		}

		public static void DrawHighlight(Vector3 position, Quaternion rotation, HighlightMesh[] meshes, Color color)
		{
			if (material == null)
			{
				material = new Material(SingletonBehaviour<GadgetSystemUtility>.Instance.boundsMaterial);
			}
			material.SetColor(materialColorID, color);
			for (int i = 0; i < meshes.Length; i++)
			{
				Graphics.DrawMesh(meshes[i].mesh, Matrix4x4.TRS(position, rotation, Vector3.one * 1.01f) * meshes[i].localMatrix, material, SingletonBehaviour<GadgetSystemUtility>.Instance.boundsRenderLayer);
			}
		}

		public static void HoverHapticFeedback(GameObject hoveredBy)
		{
			if (!VRManager.IsVREnabled() || hoveredBy == null)
			{
				return;
			}
			VRTK_InteractableObject component = hoveredBy.GetComponent<VRTK_InteractableObject>();
			if (!(component == null))
			{
				GameObject grabbingObject = component.GetGrabbingObject();
				if (!(grabbingObject == null))
				{
					HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(grabbingObject), HapticIntensityType.Weak);
				}
			}
		}

		public static HighlightMesh[] GenerateHighlightMeshes(Transform root, bool includeInactive)
		{
			if (root == null)
			{
				Debug.LogError("[GadgetSystemUtility]: Root reference missing, unable to generate highlight meshes.");
				return Array.Empty<HighlightMesh>();
			}
			MeshFilter[] componentsInChildren = root.GetComponentsInChildren<MeshFilter>(includeInactive);
			return GenerateHighlightMeshes(root, componentsInChildren);
		}

		public static HighlightMesh[] GenerateHighlightMeshes(Transform root, MeshFilter[] meshFilters)
		{
			if (root == null)
			{
				Debug.LogError("[GadgetSystemUtility]: Root reference missing, unable to generate highlight meshes.");
				return Array.Empty<HighlightMesh>();
			}
			if (meshFilters == null)
			{
				Debug.LogError("[GadgetSystemUtility]: MeshFilters reference missing, unable to generate highlight meshes.");
				return Array.Empty<HighlightMesh>();
			}
			HighlightMesh[] array = new HighlightMesh[meshFilters.Length];
			for (int i = 0; i < meshFilters.Length; i++)
			{
				array[i] = new HighlightMesh(meshFilters[i], root);
			}
			return array;
		}

		internal static void ScheduleWireDraw(Vector3 a, Vector3 b, WireHighlightMode highlight)
		{
			SingletonBehaviour<GadgetSystemUtility>.Instance.wireDisplayData.Add(new WireDisplayData(a, b, highlight));
		}

		protected override void Awake()
		{
			base.Awake();
			PlayerManager.PlayerChanged += PlayerChanged;
			PlayerChanged();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			PlayerManager.PlayerChanged -= PlayerChanged;
		}

		private void LateUpdate()
		{
			UpdateWireDisplay();
		}

		private void UpdateWireDisplay()
		{
			while (lineRenderers.Count < this.wireDisplayData.Count)
			{
				GameObject obj = new GameObject($"[wire link renderer i{lineRenderers.Count}]");
				obj.transform.parent = base.transform;
				LineRenderer lineRenderer = obj.AddComponent<LineRenderer>();
				lineRenderer.positionCount = 2;
				lineRenderer.useWorldSpace = true;
				lineRenderer.widthMultiplier = linkLineWidth;
				lineRenderer.textureMode = LineTextureMode.Tile;
				lineRenderer.sortingOrder = 128;
				lineRenderer.generateLightingData = true;
				lineRenderers.Add(lineRenderer);
			}
			for (int i = 0; i < this.wireDisplayData.Count; i++)
			{
				WireDisplayData wireDisplayData = this.wireDisplayData[i];
				lineRenderers[i].SetPosition(0, wireDisplayData.from);
				lineRenderers[i].SetPosition(1, wireDisplayData.to);
				Material sharedMaterial = linkExists;
				switch (wireDisplayData.highlight)
				{
				case WireHighlightMode.Seek:
					sharedMaterial = linkSeeking;
					break;
				case WireHighlightMode.Valid:
					sharedMaterial = linkValid;
					break;
				case WireHighlightMode.Remove:
					sharedMaterial = linkCancel;
					break;
				}
				lineRenderers[i].sharedMaterial = sharedMaterial;
				lineRenderers[i].enabled = true;
			}
			for (int j = this.wireDisplayData.Count; j < lineRenderers.Count; j++)
			{
				lineRenderers[j].enabled = false;
			}
			this.wireDisplayData.Clear();
		}

		private void PlayerChanged()
		{
			if (PlayerManager.PlayerTransform == null)
			{
				itemPlacer = null;
			}
			else
			{
				itemPlacer = PlayerManager.PlayerTransform.GetComponentInChildren<ItemPlacerNonVr>();
			}
		}

		public bool CheckGadgetAgainstRestrictions(ItemBase gadget)
		{
			if (AllowedGadgetInstances != null && !AllowedGadgetInstances.Contains(gadget.gameObject))
			{
				return false;
			}
			if (AllowedGadgetNames == null)
			{
				return true;
			}
			return AllowedGadgetNames.Contains(gadget.InventorySpecs.ItemPrefabName);
		}

		public bool CheckPlacementAgainstRestrictions(Vector3 targetPosition, Vector3 targetNormal)
		{
			if (AllowedPlacement != null)
			{
				Collider[] allowedPlacement = AllowedPlacement;
				foreach (Collider collider in allowedPlacement)
				{
					if (collider.ClosestPoint(targetPosition) == targetPosition && Vector3.Dot(collider.transform.up, targetNormal) <= DotProductLimit)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		public bool CheckWiringAgainstRestrictions(GadgetBase gadget)
		{
			if (AllowedWiring == null || AllowedWiring.Length == 0)
			{
				return true;
			}
			return AllowedWiring.Contains(gadget);
		}

		public bool CheckSolderingAgainstRestrictions(GadgetBase gadget)
		{
			if (AllowedSoldering == null)
			{
				return true;
			}
			return AllowedSoldering.Contains(gadget);
		}
	}
}
