using System;
using FluffyUnderware.Curvy.ThirdParty.LibTessDotNet;
using FluffyUnderware.DevTools;
using ToolBuddy.Pooling.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Build/Volume Caps", ModuleName = "Volume Caps", Description = "Build volume caps")]
	[HelpURL("https://curvyeditor.com/doclink/cgbuildvolumecaps")]
	public class BuildVolumeCaps : CGModule
	{
		[InputSlotInfo(new Type[] { typeof(CGVolume) })]
		[HideInInspector]
		public CGModuleInputSlot InVolume;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGVolume) }, Optional = true, Array = true)]
		public CGModuleInputSlot InVolumeHoles;

		[HideInInspector]
		[OutputSlotInfo(typeof(CGVMesh), Array = true)]
		public CGModuleOutputSlot OutVMesh;

		[SerializeField]
		[Tab("General")]
		private CGYesNoAuto m_StartCap;

		[SerializeField]
		private CGYesNoAuto m_EndCap;

		[SerializeField]
		[FormerlySerializedAs("m_ReverseNormals")]
		private bool m_ReverseTriOrder;

		[SerializeField]
		private bool m_GenerateUV;

		[SerializeField]
		private bool m_GenerateUV2;

		[Tab("Start Cap")]
		[Inline]
		[SerializeField]
		private CGMaterialSettings m_StartMaterialSettings;

		[Label("Material", null)]
		[SerializeField]
		private Material m_StartMaterial;

		[Tab("End Cap")]
		[SerializeField]
		private bool m_CloneStartCap;

		[AsGroup(null, Invisible = true)]
		[GroupCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private CGMaterialSettings m_EndMaterialSettings;

		[SerializeField]
		[Group("Default/End Cap")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Label("Material", null)]
		private Material m_EndMaterial;

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

		public CGYesNoAuto StartCap
		{
			get
			{
				return default(CGYesNoAuto);
			}
			set
			{
			}
		}

		public Material StartMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CGMaterialSettings StartMaterialSettings => null;

		public CGYesNoAuto EndCap
		{
			get
			{
				return default(CGYesNoAuto);
			}
			set
			{
			}
		}

		public bool CloneStartCap
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CGMaterialSettings EndMaterialSettings => null;

		public Material EndMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		public override void Reset()
		{
		}

		public override void Refresh()
		{
		}

		private static Matrix4x4 getMatrix(CGVolume vol, int index, bool inverse)
		{
			return default(Matrix4x4);
		}

		private static void flipTris(SubArray<int> indices, int start, int end)
		{
		}

		private static SubArray<Vector3> applyMatrix(SubArray<Vector3> vt, Matrix4x4 matrix, out Bounds bounds)
		{
			bounds = default(Bounds);
			return default(SubArray<Vector3>);
		}

		private static ContourVertex[] make2DSegment(CGVolume vol, int segmentIndex)
		{
			return null;
		}

		private static void applyUV(SubArray<Vector3> vts, SubArray<Vector2> uvArray, int index, int count, CGMaterialSettings mat, Bounds bounds)
		{
		}

		private static void applyUV2(SubArray<Vector3> vertice, SubArray<Vector2> uv2Array, int index, int count, Bounds bounds)
		{
		}
	}
}
