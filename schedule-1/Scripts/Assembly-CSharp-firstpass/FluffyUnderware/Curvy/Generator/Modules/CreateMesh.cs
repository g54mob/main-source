using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Create/Mesh", ModuleName = "Create Mesh")]
	[HelpURL("https://curvyeditor.com/doclink/cgcreatemesh")]
	public class CreateMesh : ResourceExportingModule, ISerializationCallbackReceiver
	{
		private const string DefaultTag = "Untagged";

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGVMesh) }, Array = true, Name = "VMesh")]
		public CGModuleInputSlot InVMeshArray;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGSpots) }, Array = true, Name = "Spots", Optional = true)]
		public CGModuleInputSlot InSpots;

		[SerializeField]
		[CGResourceCollectionManager("Mesh", ShowCount = true)]
		private CGMeshResourceCollection m_MeshResources;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Tooltip("Merge meshes")]
		[Tab("General")]
		[SerializeField]
		private bool m_Combine;

		[Tooltip("Warning: this operation is Editor only (not available in builds) and CPU intensive.\nWhen combining multiple meshes, the UV2s are by default kept as is. Use this option to recompute them by uwrapping the combined mesh.")]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool unwrapUV2;

		[Tooltip("When Combine is true, combine only meshes sharing the same index\nIs used only if Spots are provided")]
		[SerializeField]
		private bool m_GroupMeshes;

		[SerializeField]
		[Tooltip("If true, the generated mesh will have normals")]
		private bool includeNormals;

		[Tooltip("If true, the generated mesh will have tangents")]
		[SerializeField]
		private bool includeTangents;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[HideInInspector]
		[SerializeField]
		private CGYesNoAuto m_AddNormals;

		[HideInInspector]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private CGYesNoAuto m_AddTangents;

		[HideInInspector]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private bool m_AddUV2;

		[SerializeField]
		[Tooltip("If enabled, meshes will have the Static flag set, and will not be generated/updated in Play Mode")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool m_MakeStatic;

		[Tooltip("The Layer of the created game object")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[Layer(null, null)]
		private int m_Layer;

		[Tag(null, null)]
		[SerializeField]
		[Tooltip("The Tag of the created game object")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private string m_Tag;

		[Tab("Renderer")]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool m_RendererEnabled;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private ShadowCastingMode m_CastShadows;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool m_ReceiveShadows;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private LightProbeUsage m_LightProbeUsage;

		[HideInInspector]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool m_UseLightProbes;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private ReflectionProbeUsage m_ReflectionProbes;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private Transform m_AnchorOverride;

		[Tab("Collider")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private CGColliderEnum m_Collider;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool m_Convex;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool m_IsTrigger;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Tooltip("Options used to enable or disable certain features in Collider mesh cooking. See Unity's MeshCollider.cookingOptions for more details")]
		[EnumFlag(null, null)]
		[SerializeField]
		private MeshColliderCookingOptions m_CookingOptions;

		[SerializeField]
		[Label("Auto Update", null)]
		private bool m_AutoUpdateColliders;

		[SerializeField]
		private PhysicMaterial m_Material;

		private readonly CGSpotComparer cgSpotComparer;

		public bool Combine
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UnwrapUV2
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool GroupMeshes
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeNormals
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeTangents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use IncludeNormals instead")]
		public CGYesNoAuto AddNormals
		{
			get
			{
				return default(CGYesNoAuto);
			}
			set
			{
			}
		}

		[Obsolete("Use IncludeTangents instead")]
		[UsedImplicitly]
		public CGYesNoAuto AddTangents
		{
			get
			{
				return default(CGYesNoAuto);
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("UV2 is now always added")]
		public bool AddUV2
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int Layer
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string Tag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool MakeStatic
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RendererEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ShadowCastingMode CastShadows
		{
			get
			{
				return default(ShadowCastingMode);
			}
			set
			{
			}
		}

		public bool ReceiveShadows
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseLightProbes
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LightProbeUsage LightProbeUsage
		{
			get
			{
				return default(LightProbeUsage);
			}
			set
			{
			}
		}

		public ReflectionProbeUsage ReflectionProbes
		{
			get
			{
				return default(ReflectionProbeUsage);
			}
			set
			{
			}
		}

		public Transform AnchorOverride
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CGColliderEnum Collider
		{
			get
			{
				return default(CGColliderEnum);
			}
			set
			{
			}
		}

		public bool AutoUpdateColliders
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Convex
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsTrigger
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MeshColliderCookingOptions CookingOptions
		{
			get
			{
				return default(MeshColliderCookingOptions);
			}
			set
			{
			}
		}

		public PhysicMaterial Material
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Member is set to become editor only. Contact support if you need it outside of Editor")]
		public CGMeshResourceCollection Meshes => null;

		[Obsolete("Member is set to become editor only. Contact support if you need it outside of Editor")]
		public int MeshCount => 0;

		[Obsolete("Member is set to become editor only. Contact support if you need it outside of Editor")]
		public int VertexCount { get; private set; }

		private bool CanGroupMeshes => false;

		private bool CanModifyStaticFlag => false;

		private bool CanUpdate => false;

		private bool EnableIsTrigger => false;

		public override void Reset()
		{
		}

		public override bool DeleteAllOutputManagedResources()
		{
			return false;
		}

		[Obsolete("Use DeleteAllOutputManagedResources instead")]
		[UsedImplicitly]
		public void Clear()
		{
		}

		public override void Refresh()
		{
		}

		public void UpdateColliders()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		private void CreateMeshes(List<CGVMesh> vMeshes, bool combine, [NotNull] List<CGMeshResource> createdMeshes)
		{
		}

		private void CreateSpotMeshes(List<CGVMesh> vMeshes, SubArray<CGSpot> spots, bool combine, bool spotsIsACopy, [NotNull] List<CGMeshResource> createdMeshes)
		{
		}

		private CGMeshResource WriteVMeshToMesh(CGVMesh vmesh, List<CGMeshResource> cgMeshResources)
		{
			return null;
		}

		private CGMeshResource GetNewMesh(int currentMeshCount)
		{
			return null;
		}

		private static SubArray<CGSpot>? ToOneDimensionalArray(List<CGSpots> spotsList, out bool arrayIsCopy)
		{
			arrayIsCopy = default(bool);
			return null;
		}

		[System.Diagnostics.Conditional("CURVY_SANITY_CHECKS_PRIVATE")]
		private void ValidateMesh(Mesh mesh)
		{
		}

		protected override void ResetOnEnable()
		{
		}

		public void SaveToAsset()
		{
		}

		public void SaveToSceneAndAsset()
		{
		}

		protected override GameObject SaveResourceToScene(Component managedResource, Transform newParent)
		{
			return null;
		}
	}
}
