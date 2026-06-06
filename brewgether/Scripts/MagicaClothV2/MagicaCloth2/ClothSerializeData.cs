using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class ClothSerializeData : IDataValidate, IValid, ITransform
	{
		public enum PaintMode
		{
			Manual = 0,
			[InspectorName("Texture Fixed(RD) Move(GR) Ignore(BK)")]
			Texture_Fixed_Move = 1,
			[InspectorName("Texture Fixed(RD) Move(GR) Limit(BL) Ignore(BK)")]
			Texture_Fixed_Move_Limit = 2
		}

		private class TempBuffer
		{
			private ClothProcess.ClothType clothType;

			private List<Renderer> sourceRenderers;

			private ClothMeshWriteMode meshWriteMode;

			private PaintMode paintMode;

			private List<Texture2D> paintMaps;

			private int paintMapUvChannel;

			private List<Transform> rootBones;

			private RenderSetupData.BoneConnectionMode connectionMode;

			private float rotationalInterpolation;

			private float rootRotation;

			private ClothUpdateMode updateMode;

			private ClothDisableMode disableMode;

			private float animationPoseRatio;

			private ReductionSettings reductionSetting;

			private CustomSkinningSettings customSkinningSetting;

			private NormalAlignmentSettings normalAlignmentSetting;

			private ClothNormalAxis normalAxis;

			private List<ColliderComponent> colliderList;

			private List<Transform> collisionBones;

			private MagicaCloth synchronization;

			private float stablizationTimeAfterReset;

			private float blendWeight;

			private CullingSettings cullingSetting;

			private Transform anchor;

			private float anchorInertia;

			internal TempBuffer(ClothSerializeData sdata)
			{
			}

			internal void Push(ClothSerializeData sdata)
			{
			}

			internal void Pop(ClothSerializeData sdata)
			{
			}
		}

		public ClothProcess.ClothType clothType;

		public List<Renderer> sourceRenderers;

		public ClothMeshWriteMode meshWriteMode;

		public PaintMode paintMode;

		public List<Texture2D> paintMaps;

		[Range(0f, 7f)]
		public int paintMapUvChannel;

		public List<Transform> rootBones;

		public RenderSetupData.BoneConnectionMode connectionMode;

		[Range(0f, 1f)]
		public float rotationalInterpolation;

		[Range(0f, 1f)]
		public float rootRotation;

		public ClothUpdateMode updateMode;

		public ClothDisableMode disableMode;

		[Range(0f, 1f)]
		public float animationPoseRatio;

		public ReductionSettings reductionSetting;

		public CustomSkinningSettings customSkinningSetting;

		public NormalAlignmentSettings normalAlignmentSetting;

		public CullingSettings cullingSettings;

		public ClothNormalAxis normalAxis;

		[Range(0f, 10f)]
		public float gravity;

		public float3 gravityDirection;

		[Range(0f, 1f)]
		public float gravityFalloff;

		[Range(0f, 1f)]
		public float stablizationTimeAfterReset;

		[Range(0f, 1f)]
		public float blendWeight;

		public CurveSerializeData damping;

		public CurveSerializeData radius;

		public InertiaConstraint.SerializeData inertiaConstraint;

		public TetherConstraint.SerializeData tetherConstraint;

		public DistanceConstraint.SerializeData distanceConstraint;

		public TriangleBendingConstraint.SerializeData triangleBendingConstraint;

		public AngleConstraint.RestorationSerializeData angleRestorationConstraint;

		public AngleConstraint.LimitSerializeData angleLimitConstraint;

		public MotionConstraint.SerializeData motionConstraint;

		public ColliderCollisionConstraint.SerializeData colliderCollisionConstraint;

		public SelfCollisionConstraint.SerializeData selfCollisionConstraint;

		public WindSettings wind;

		public SpringConstraint.SerializeData springConstraint;

		private ResultCode verificationResult;

		public Define.Result VerificationResult => default(Define.Result);

		public bool IsValid()
		{
			return false;
		}

		public void DataValidate()
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public ClothParameters GetClothParameters()
		{
			return default(ClothParameters);
		}

		public string ExportJson()
		{
			return null;
		}

		public bool ImportJson(string json)
		{
			return false;
		}

		public void Import(ClothSerializeData sdata, bool deepCopy = false)
		{
		}

		public void Import(MagicaCloth src, bool deepCopy = false)
		{
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}

		public bool IsBoneSpring()
		{
			return false;
		}

		public int GetUvChannel()
		{
			return 0;
		}
	}
}
