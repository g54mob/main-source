using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cgbuildvolumemesh")]
	[ModuleInfo("Build/Volume Mesh", ModuleName = "Volume Mesh", Description = "Build a volume mesh")]
	public class BuildVolumeMesh : CGModule
	{
		private const float DefaultUnscalingOrigin = 0.5f;

		private const int DefaultSplitLength = 100;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGVolume) })]
		public CGModuleInputSlot InVolume;

		[HideInInspector]
		[OutputSlotInfo(typeof(CGVMesh), Array = true)]
		public CGModuleOutputSlot OutVMesh;

		[Tab("General")]
		[FieldAction("CBAddMaterial", ActionAttribute.ActionEnum.Callback)]
		[SerializeField]
		[FormerlySerializedAs("m_ReverseNormals")]
		private bool m_ReverseTriOrder;

		[SerializeField]
		[Section("Default/General/UV", true, false, 100)]
		private bool m_GenerateUV;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Tooltip("When set to true, and if the input Shape Extrusion module is set to apply scaling, the U coordinate of the generated mesh will be modified to compensate that scaling.\nOnly the X component of the scaling is taken into consideration.\nThe unscaling works best on volumes with flat shapes.")]
		[SerializeField]
		private bool unscaleU;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Tooltip("When unscaling the U coordinate, this field defines what is the scaling origin.\n0.5 gives usually the best results, but you might need to set it to a different value, usually between 0 and 1")]
		[SerializeField]
		private float unscalingOrigin;

		[SerializeField]
		private bool m_GenerateUV2;

		[Tooltip("Split the mesh into submeshes")]
		[Section("Default/General/Split", true, false, 100)]
		[SerializeField]
		private bool m_Split;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Positive(MinValue = 1f)]
		[SerializeField]
		private float m_SplitLength;

		[Tooltip("Is ignored when Split or Generate UV2 is false.\nIf enabled, UV2s of a split mesh will be computed as in Curvy versions prior to 8.0.0, which had a bug: all the split submeshes used the full range of UV2 coordinates, instead of keeping the same UV2s from the unsplit mesh.")]
		[Group("Default/General/Backward Compatibility", Expanded = false)]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool splitUV2;

		[HideInInspector]
		[SerializeField]
		private List<CGMaterialSettingsEx> m_MaterialSettings;

		[SerializeField]
		[HideInInspector]
		private Material[] m_Material;

		public bool GenerateUV
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool GenerateUV2
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UnscaleU
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float UnscalingOrigin
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool ReverseTriOrder
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Split
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float SplitLength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool SplitUV2
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use MaterialSettings (with the correct number of Ts) instead")]
		public List<CGMaterialSettingsEx> MaterialSetttings => null;

		public List<CGMaterialSettingsEx> MaterialSettings => null;

		public int MaterialCount => 0;

		private bool IsSplitUV2Togglable => false;

		protected override void Awake()
		{
		}

		public override void Reset()
		{
		}

		public override void Refresh()
		{
		}

		public int AddMaterial()
		{
			return 0;
		}

		public void RemoveMaterial(int index)
		{
		}

		public void SetMaterial(int index, Material mat)
		{
		}

		public Material GetMaterial(int index)
		{
			return null;
		}

		private void build([NotNull] CGVMesh vmesh, CGVolume vol, IntRegion subset, List<SamplePointsMaterialGroupCollection> materialIdGroups)
		{
		}

		private static void prepareSubMeshes([NotNull] CGVMesh vmesh, List<SamplePointsMaterialGroupCollection> groupsBySubMeshes, int extrusions, ref Material[] materials)
		{
		}

		private void createMaterialGroupUV(CGVMesh vmesh, CGVolume volume, SamplePointsMaterialGroup materialGroup, int matIndex, float aspectCorrectionV, float aspectCorrectionU, int sample, int baseVertex)
		{
		}

		private void createMaterialGroupUV2(CGVMesh vmesh, CGVolume volume, SamplePointsMaterialGroup materialGroup, int sample, int baseVertex)
		{
		}

		private static void createPatchTriangles(int[] triangles, ref int triIdx, int curVTIndex, int patchSize, int crossSize, bool reverse)
		{
		}

		private List<SamplePointsMaterialGroupCollection> getMaterialIDGroups(CGVolume volume)
		{
			return null;
		}

		private bool validateMaterialIndex(int index)
		{
			return false;
		}
	}
}
