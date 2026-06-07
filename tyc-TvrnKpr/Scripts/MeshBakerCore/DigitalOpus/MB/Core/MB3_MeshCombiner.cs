using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public abstract class MB3_MeshCombiner : MB_IMeshBakerSettings, IDisposable
	{
		public enum MeshCombiningStatus
		{
			preAddDeleteOrUpdate = 0,
			readyForApply = 1
		}

		public delegate void GenerateUV2Delegate(Mesh m, float hardAngle, float packMargin);

		public class MBBlendShapeKey
		{
			public GameObject gameObject;

			public int blendShapeIndexInSrc;

			public MBBlendShapeKey(GameObject srcSkinnedMeshRenderGameObject, int blendShapeIndexInSource)
			{
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		public class MBBlendShapeValue
		{
			public GameObject combinedMeshGameObject;

			public int blendShapeIndex;
		}

		[SerializeField]
		protected MeshCombiningStatus _bakeStatus;

		[SerializeField]
		protected MB2_ValidationLevel _validationLevel;

		[SerializeField]
		protected string _name;

		[SerializeField]
		protected MB2_TextureBakeResults _textureBakeResults;

		[SerializeField]
		protected GameObject _resultSceneObject;

		[SerializeField]
		protected Renderer _targetRenderer;

		[SerializeField]
		protected MB2_LogLevel _LOG_LEVEL;

		[SerializeField]
		protected UnityEngine.Object _settingsHolder;

		[SerializeField]
		protected MB2_OutputOptions _outputOption;

		[SerializeField]
		protected MB_RenderType _renderType;

		[SerializeField]
		protected MB2_LightmapOptions _lightmapOption;

		[SerializeField]
		protected bool _doNorm;

		[SerializeField]
		protected bool _doTan;

		[SerializeField]
		protected bool _doCol;

		[SerializeField]
		protected bool _doUV;

		[SerializeField]
		protected bool _doUV3;

		[SerializeField]
		protected bool _doUV4;

		[SerializeField]
		protected bool _doUV5;

		[SerializeField]
		protected bool _doUV6;

		[SerializeField]
		protected bool _doUV7;

		[SerializeField]
		protected bool _doUV8;

		[SerializeField]
		protected bool _doBlendShapes;

		[FormerlySerializedAs("_recenterVertsToBoundsCenter")]
		[SerializeField]
		protected MB_MeshPivotLocation _pivotLocationType;

		[SerializeField]
		protected Vector3 _pivotLocation;

		[SerializeField]
		protected bool _clearBuffersAfterBake;

		[SerializeField]
		public bool _optimizeAfterBake;

		[SerializeField]
		[FormerlySerializedAs("uv2UnwrappingParamsHardAngle")]
		protected float _uv2UnwrappingParamsHardAngle;

		[SerializeField]
		[FormerlySerializedAs("uv2UnwrappingParamsPackMargin")]
		protected float _uv2UnwrappingParamsPackMargin;

		[SerializeField]
		protected bool _smrNoExtraBonesWhenCombiningMeshRenderers;

		[SerializeField]
		protected bool _smrMergeBlendShapesWithSameNames;

		[SerializeField]
		protected UnityEngine.Object _assignToMeshCustomizer;

		[SerializeField]
		protected MB_MeshCombineAPIType _meshAPItoUse;

		protected bool _usingTemporaryTextureBakeResult;

		private bool _disposed;

		public static bool EVAL_VERSION => false;

		public virtual MeshCombiningStatus bakeStatus => default(MeshCombiningStatus);

		public virtual MB2_ValidationLevel validationLevel
		{
			get
			{
				return default(MB2_ValidationLevel);
			}
			set
			{
			}
		}

		public string name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual MB2_TextureBakeResults textureBakeResults
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual GameObject resultSceneObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual Renderer targetRenderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual MB2_LogLevel LOG_LEVEL
		{
			get
			{
				return default(MB2_LogLevel);
			}
			set
			{
			}
		}

		public MB_IMeshBakerSettings settings => null;

		public virtual MB_IMeshBakerSettingsHolder settingsHolder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual MB2_OutputOptions outputOption
		{
			get
			{
				return default(MB2_OutputOptions);
			}
			set
			{
			}
		}

		public virtual MB_RenderType renderType
		{
			get
			{
				return default(MB_RenderType);
			}
			set
			{
			}
		}

		public virtual MB2_LightmapOptions lightmapOption
		{
			get
			{
				return default(MB2_LightmapOptions);
			}
			set
			{
			}
		}

		public virtual bool doNorm
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doTan
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doCol
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doUV
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doUV1
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doUV3
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doUV4
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doUV5
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doUV6
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doUV7
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doUV8
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool doBlendShapes
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual MB_MeshPivotLocation pivotLocationType
		{
			get
			{
				return default(MB_MeshPivotLocation);
			}
			set
			{
			}
		}

		public virtual Vector3 pivotLocation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public virtual bool clearBuffersAfterBake
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool optimizeAfterBake
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float uv2UnwrappingParamsHardAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float uv2UnwrappingParamsPackMargin
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool smrNoExtraBonesWhenCombiningMeshRenderers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool smrMergeBlendShapesWithSameNames
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IAssignToMeshCustomizer assignToMeshCustomizer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MB_MeshCombineAPIType meshAPI
		{
			get
			{
				return default(MB_MeshCombineAPIType);
			}
			set
			{
			}
		}

		public virtual bool doUV2()
		{
			return false;
		}

		public virtual void DisposeRuntimeCreated()
		{
		}

		public void Dispose()
		{
		}

		public bool IsDisposed()
		{
			return false;
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public abstract int GetLightmapIndex();

		public abstract void ClearBuffers();

		public abstract void ClearMesh();

		public abstract void ClearMesh(MB2_EditorMethodsInterface editorMethods);

		internal abstract void _DisposeRuntimeCreated();

		public abstract void DestroyMesh();

		public abstract void DestroyMeshEditor(MB2_EditorMethodsInterface editorMethods);

		public abstract List<GameObject> GetObjectsInCombined();

		public abstract int GetNumObjectsInCombined();

		public virtual bool Apply()
		{
			return false;
		}

		public abstract bool Apply(GenerateUV2Delegate uv2GenerationMethod);

		public abstract bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool uv5, bool uv6, bool uv7, bool uv8, bool colors, bool bones = false, bool blendShapeFlag = false, GenerateUV2Delegate uv2GenerationMethod = null);

		public abstract bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapeFlag = false, GenerateUV2Delegate uv2GenerationMethod = null);

		public virtual bool UpdateGameObjects(GameObject[] gos)
		{
			return false;
		}

		public virtual bool UpdateGameObjects(GameObject[] gos, bool updateBounds)
		{
			return false;
		}

		public abstract bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateColors, bool updateSkinningInfo);

		public abstract bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo);

		public abstract bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource = true);

		public abstract bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource);

		public abstract bool CombinedMeshContains(GameObject go);

		public abstract void UpdateSkinnedMeshApproximateBounds();

		public abstract void UpdateSkinnedMeshApproximateBoundsFromBones();

		public abstract void CheckIntegrity();

		public abstract void UpdateSkinnedMeshApproximateBoundsFromBounds();

		public static void UpdateSkinnedMeshApproximateBoundsFromBonesStatic(Transform[] bs, SkinnedMeshRenderer smr)
		{
		}

		public static void UpdateSkinnedMeshApproximateBoundsFromBoundsStatic(List<GameObject> objectsInCombined, SkinnedMeshRenderer smr)
		{
		}

		protected virtual bool _CreateTemporaryTextrueBakeResult(GameObject[] gos, List<Material> matsOnTargetRenderer)
		{
			return false;
		}

		public abstract List<Material> GetMaterialsOnTargetRenderer();
	}
}
