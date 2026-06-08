using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	[DisallowMultipleComponent]
	public abstract class ShapeRenderer : MonoBehaviour
	{
		private bool initializedComponents;

		private MeshRenderer rnd;

		private MeshFilter mf;

		private int meshOwnerID;

		private MaterialPropertyBlock mpb;

		private Material[] instancedMaterials;

		[NonSerialized]
		public bool meshOutOfDate = true;

		[SerializeField]
		private ShapesBlendMode blendMode = ShapesBlendMode.Transparent;

		[SerializeField]
		private ScaleMode scaleMode;

		[SerializeField]
		[ShapesColorField(true)]
		protected Color color = Color.white;

		[SerializeField]
		protected DetailLevel detailLevel = DetailLevel.Medium;

		public static readonly CompareFunction DEFAULT_ZTEST = CompareFunction.LessEqual;

		public static readonly float DEFAULT_ZOFS_FACTOR = 0f;

		public static readonly int DEFAULT_ZOFS_UNITS = 0;

		[SerializeField]
		private CompareFunction zTest = DEFAULT_ZTEST;

		[SerializeField]
		private float zOffsetFactor = DEFAULT_ZOFS_FACTOR;

		[SerializeField]
		private int zOffsetUnits = DEFAULT_ZOFS_UNITS;

		public static readonly CompareFunction DEFAULT_STENCIL_COMP = CompareFunction.Always;

		public static readonly StencilOp DEFAULT_STENCIL_OP = StencilOp.Keep;

		public static readonly byte DEFAULT_STENCIL_REF_ID = 0;

		public static readonly byte DEFAULT_STENCIL_MASK = byte.MaxValue;

		[SerializeField]
		private CompareFunction stencilComp = DEFAULT_STENCIL_COMP;

		[SerializeField]
		private StencilOp stencilOpPass = DEFAULT_STENCIL_OP;

		[SerializeField]
		private byte stencilRefID = DEFAULT_STENCIL_REF_ID;

		[SerializeField]
		private byte stencilReadMask = DEFAULT_STENCIL_MASK;

		[SerializeField]
		private byte stencilWriteMask = DEFAULT_STENCIL_MASK;

		private MaterialPropertyBlock Mpb => mpb ?? (mpb = new MaterialPropertyBlock());

		public bool IsUsingUniqueMaterials => !IsInstanced;

		public Mesh Mesh
		{
			get
			{
				return mf.sharedMesh;
			}
			private set
			{
				mf.sharedMesh = value;
			}
		}

		public int SortingLayerID
		{
			get
			{
				bool created;
				return MakeSureComponentExists(ref rnd, out created).sortingLayerID;
			}
			set
			{
				MakeSureComponentExists(ref rnd, out var _).sortingLayerID = value;
			}
		}

		public int SortingOrder
		{
			get
			{
				bool created;
				return MakeSureComponentExists(ref rnd, out created).sortingOrder;
			}
			set
			{
				MakeSureComponentExists(ref rnd, out var _).sortingOrder = value;
			}
		}

		public string SortingLayerName => SortingLayer.IDToName(SortingLayerID);

		public ShapesBlendMode BlendMode
		{
			get
			{
				return blendMode;
			}
			set
			{
				blendMode = value;
				UpdateMaterial();
			}
		}

		public ScaleMode ScaleMode
		{
			get
			{
				return scaleMode;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propScaleMode, (int)(scaleMode = value));
			}
		}

		public virtual Color Color
		{
			get
			{
				return color;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColor, color = value);
			}
		}

		public virtual DetailLevel DetailLevel
		{
			get
			{
				return detailLevel;
			}
			set
			{
				detailLevel = value;
				UpdateMesh(force: true);
			}
		}

		private bool IsInstanced
		{
			get
			{
				if (UsingDefaultZTests)
				{
					return UsingDefaultStencil;
				}
				return false;
			}
		}

		private bool UsingDefaultZTests
		{
			get
			{
				if (zTest == DEFAULT_ZTEST && zOffsetFactor == DEFAULT_ZOFS_FACTOR)
				{
					return zOffsetUnits == DEFAULT_ZOFS_UNITS;
				}
				return false;
			}
		}

		public CompareFunction ZTest
		{
			get
			{
				return zTest;
			}
			set
			{
				SetIntOnAllInstancedMaterials(ShapesMaterialUtils.propZTest, (int)(zTest = value));
			}
		}

		public float ZOffsetFactor
		{
			get
			{
				return zOffsetFactor;
			}
			set
			{
				SetFloatOnAllInstancedMaterials(ShapesMaterialUtils.propZOffsetFactor, zOffsetFactor = value);
			}
		}

		public int ZOffsetUnits
		{
			get
			{
				return zOffsetUnits;
			}
			set
			{
				SetIntOnAllInstancedMaterials(ShapesMaterialUtils.propZOffsetUnits, zOffsetUnits = value);
			}
		}

		private bool UsingDefaultStencil
		{
			get
			{
				if (stencilComp == DEFAULT_STENCIL_COMP && stencilOpPass == DEFAULT_STENCIL_OP && stencilRefID == DEFAULT_STENCIL_REF_ID && stencilReadMask == DEFAULT_STENCIL_MASK)
				{
					return stencilWriteMask == DEFAULT_STENCIL_MASK;
				}
				return false;
			}
		}

		public CompareFunction StencilComp
		{
			get
			{
				return stencilComp;
			}
			set
			{
				SetIntOnAllInstancedMaterials(ShapesMaterialUtils.propStencilComp, (int)(stencilComp = value));
			}
		}

		public StencilOp StencilOpPass
		{
			get
			{
				return stencilOpPass;
			}
			set
			{
				SetIntOnAllInstancedMaterials(ShapesMaterialUtils.propStencilOpPass, (int)(stencilOpPass = value));
			}
		}

		public byte StencilRefID
		{
			get
			{
				return stencilRefID;
			}
			set
			{
				SetIntOnAllInstancedMaterials(ShapesMaterialUtils.propStencilID, stencilRefID = value);
			}
		}

		public byte StencilReadMask
		{
			get
			{
				return stencilReadMask;
			}
			set
			{
				SetIntOnAllInstancedMaterials(ShapesMaterialUtils.propStencilReadMask, stencilReadMask = value);
			}
		}

		public byte StencilWriteMask
		{
			get
			{
				return stencilWriteMask;
			}
			set
			{
				SetIntOnAllInstancedMaterials(ShapesMaterialUtils.propStencilWriteMask, stencilWriteMask = value);
			}
		}

		private bool HasGeneratedOrCopyOfMesh
		{
			get
			{
				if (MeshUpdateMode != MeshUpdateMode.SelfGenerated)
				{
					return MeshUpdateMode == MeshUpdateMode.UseAssetCopy;
				}
				return true;
			}
		}

		protected virtual MeshUpdateMode MeshUpdateMode => MeshUpdateMode.UseAsset;

		public virtual bool HasScaleModes => true;

		public virtual bool HasDetailLevels => true;

		protected virtual bool UseCamOnPreCull => false;

		private T MakeSureComponentExists<T>(ref T field, out bool created) where T : Component
		{
			if (field == null)
			{
				field = GetComponent<T>();
				if (field == null)
				{
					field = base.gameObject.AddComponent<T>();
					created = true;
				}
				field.hideFlags = HideFlags.HideInInspector;
			}
			created = false;
			return field;
		}

		private void VerifyComponents()
		{
			if (!initializedComponents)
			{
				initializedComponents = true;
				MakeSureComponentExists(ref mf, out var _);
				MakeSureComponentExists(ref rnd, out var created2);
				if (created2)
				{
					rnd.receiveShadows = false;
					rnd.shadowCastingMode = ShadowCastingMode.Off;
					rnd.lightProbeUsage = LightProbeUsage.Off;
					rnd.reflectionProbeUsage = ReflectionProbeUsage.Off;
				}
			}
		}

		public virtual void Awake()
		{
			VerifyComponents();
			UpdateMaterial();
			UpdateMesh();
			UpdateAllMaterialProperties();
		}

		public virtual void OnEnable()
		{
			UpdateMesh();
			rnd.enabled = true;
			if (UseCamOnPreCull)
			{
				SubscribeCamPreCull();
			}
		}

		private void OnDisable()
		{
			if (rnd != null)
			{
				rnd.enabled = false;
			}
			if (UseCamOnPreCull)
			{
				UnsubscribeCamPreCull();
			}
		}

		private void OnPreCamCullWithCam(Camera cam)
		{
			CamOnPreCull();
		}

		private void OnPreCamCullWithCam(ScriptableRenderContext ctx, Camera cam)
		{
			CamOnPreCull();
		}

		private void SubscribeCamPreCull()
		{
			if (UnityInfo.UsingSRP)
			{
				RenderPipelineManager.beginCameraRendering += OnPreCamCullWithCam;
			}
			else
			{
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(OnPreCamCullWithCam));
			}
		}

		private void UnsubscribeCamPreCull()
		{
			if (UnityInfo.UsingSRP)
			{
				RenderPipelineManager.beginCameraRendering -= OnPreCamCullWithCam;
			}
			else
			{
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnPreCamCullWithCam));
			}
		}

		private void Reset()
		{
			UpdateAllMaterialProperties();
			UpdateMesh(force: true);
		}

		private void OnDestroy()
		{
			if (HasGeneratedOrCopyOfMesh && Mesh != null)
			{
				UnityEngine.Object.DestroyImmediate(Mesh);
			}
			this.TryDestroyInOnDestroy(rnd);
			this.TryDestroyInOnDestroy(mf);
			TryDestroyInstancedMaterials(inOnDestroy: true);
		}

		protected virtual void DrawGizmos(bool selected)
		{
		}

		private void OnDrawGizmos()
		{
			DrawGizmos(selected: false);
		}

		private void OnDrawGizmosSelected()
		{
			DrawGizmos(selected: true);
		}

		protected abstract void SetAllMaterialProperties();

		protected virtual void ShapeClampRanges()
		{
		}

		protected abstract Material[] GetMaterials();

		protected abstract Bounds GetBounds();

		protected virtual void GenerateMesh()
		{
		}

		protected virtual Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.QuadMesh[HasDetailLevels ? 2 : 0];
		}

		protected virtual void CamOnPreCull()
		{
		}

		private void UpdateMeshBounds()
		{
			Mesh.bounds = GetBounds();
		}

		private void TryDestroyInstancedMaterials(bool inOnDestroy = false)
		{
			if (instancedMaterials == null)
			{
				return;
			}
			for (int i = 0; i < instancedMaterials.Length; i++)
			{
				if (instancedMaterials[i] != null)
				{
					if (inOnDestroy)
					{
						this.TryDestroyInOnDestroy(instancedMaterials[i]);
					}
					else
					{
						instancedMaterials[i].DestroyBranched();
					}
				}
			}
		}

		private void MakeSureMaterialInstancesAreGood(Material[] sourceMats)
		{
			if (instancedMaterials == null)
			{
				PopulateAll();
				return;
			}
			if (instancedMaterials.Length != sourceMats.Length)
			{
				TryDestroyInstancedMaterials();
				PopulateAll();
				return;
			}
			for (int i = 0; i < sourceMats.Length; i++)
			{
				if (instancedMaterials[i] == null)
				{
					instancedMaterials[i] = InstantiateMaterial(i);
				}
				else if (instancedMaterials[i].shader != sourceMats[i].shader)
				{
					instancedMaterials[i].DestroyBranched();
					instancedMaterials[i] = InstantiateMaterial(i);
				}
				else
				{
					instancedMaterials[i].shaderKeywords = sourceMats[i].shaderKeywords;
				}
			}
			Material InstantiateMaterial(int index)
			{
				return new Material(sourceMats[index])
				{
					name = sourceMats[index].name + " (instance)"
				};
			}
			void PopulateAll()
			{
				instancedMaterials = new Material[sourceMats.Length];
				for (int j = 0; j < sourceMats.Length; j++)
				{
					instancedMaterials[j] = InstantiateMaterial(j);
				}
			}
		}

		protected void UpdateMaterial()
		{
			Material[] materials = GetMaterials();
			if (IsUsingUniqueMaterials)
			{
				MakeSureMaterialInstancesAreGood(materials);
				materials = instancedMaterials;
			}
			VerifyComponents();
			rnd.sharedMaterials = materials;
		}

		public void UpdateMesh(bool force = false)
		{
			MeshUpdateMode meshUpdateMode = MeshUpdateMode;
			if (meshUpdateMode == MeshUpdateMode.UseAsset && (Mesh == null || Mesh != GetInitialMeshAsset()))
			{
				Mesh = GetInitialMeshAsset();
				return;
			}
			int instanceID = base.gameObject.GetInstanceID();
			if (Mesh == null || meshOwnerID != instanceID)
			{
				meshOwnerID = instanceID;
				switch (meshUpdateMode)
				{
				case MeshUpdateMode.UseAssetCopy:
					Mesh = UnityEngine.Object.Instantiate(GetInitialMeshAsset());
					Mesh.hideFlags = HideFlags.HideAndDontSave;
					Mesh.MarkDynamic();
					break;
				case MeshUpdateMode.SelfGenerated:
					Mesh = new Mesh
					{
						hideFlags = HideFlags.HideAndDontSave
					};
					Mesh.MarkDynamic();
					GenerateMesh();
					break;
				}
			}
			else if (force && meshUpdateMode == MeshUpdateMode.SelfGenerated)
			{
				GenerateMesh();
			}
		}

		public Bounds GetWorldBounds()
		{
			Bounds bounds = GetBounds();
			Vector3 vector = Vector3.one * float.MaxValue;
			Vector3 vector2 = Vector3.one * float.MinValue;
			Transform transform = base.transform;
			for (int i = -1; i <= 1; i += 2)
			{
				for (int j = -1; j <= 1; j += 2)
				{
					for (int k = -1; k <= 1; k += 2)
					{
						Vector3 rhs = transform.TransformPoint(bounds.center + Vector3.Scale(bounds.extents, new Vector3(i, j, k)));
						vector = Vector3.Min(vector, rhs);
						vector2 = Vector3.Max(vector2, rhs);
					}
				}
			}
			return new Bounds((vector2 + vector) / 2f, vector2 - vector);
		}

		private void OnDidApplyAnimationProperties()
		{
			UpdateAllMaterialProperties();
		}

		private void SetIntOnAllInstancedMaterials(int property, int value)
		{
			if (IsUsingUniqueMaterials)
			{
				UpdateMaterial();
				Material[] array = instancedMaterials;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetInt(property, value);
				}
			}
		}

		private void SetFloatOnAllInstancedMaterials(int property, float value)
		{
			if (IsUsingUniqueMaterials)
			{
				UpdateMaterial();
				Material[] array = instancedMaterials;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetFloat(property, value);
				}
			}
		}

		public void UpdateAllMaterialProperties()
		{
			if (!base.gameObject.scene.IsValid())
			{
				return;
			}
			UpdateMaterial();
			if (IsUsingUniqueMaterials)
			{
				Material[] array = instancedMaterials;
				foreach (Material obj in array)
				{
					obj.SetInt(ShapesMaterialUtils.propZTest, (int)zTest);
					obj.SetFloat(ShapesMaterialUtils.propZOffsetFactor, zOffsetFactor);
					obj.SetInt(ShapesMaterialUtils.propZOffsetUnits, zOffsetUnits);
					obj.SetInt(ShapesMaterialUtils.propStencilComp, (int)stencilComp);
					obj.SetInt(ShapesMaterialUtils.propStencilOpPass, (int)stencilOpPass);
					obj.SetInt(ShapesMaterialUtils.propStencilID, stencilRefID);
					obj.SetInt(ShapesMaterialUtils.propStencilReadMask, stencilReadMask);
					obj.SetInt(ShapesMaterialUtils.propStencilWriteMask, stencilWriteMask);
				}
			}
			SetColor(ShapesMaterialUtils.propColor, color);
			if (HasScaleModes)
			{
				SetInt(ShapesMaterialUtils.propScaleMode, (int)scaleMode);
			}
			SetAllMaterialProperties();
			ApplyProperties();
		}

		protected void ApplyProperties()
		{
			VerifyComponents();
			rnd.SetPropertyBlock(Mpb);
			if (MeshUpdateMode == MeshUpdateMode.UseAssetCopy)
			{
				UpdateMeshBounds();
			}
		}

		protected void SetAllDashValues(DashStyle style, bool dashed, bool matchSpacingToSize, float thickness, bool setType, bool now)
		{
			float netAbsoluteSize = style.GetNetAbsoluteSize(dashed, thickness);
			if (dashed)
			{
				SetFloat(ShapesMaterialUtils.propDashSpacing, GetNetDashSpacing(style, dashed: true, matchSpacingToSize, thickness));
				SetFloat(ShapesMaterialUtils.propDashOffset, style.offset);
				SetInt(ShapesMaterialUtils.propDashSpace, (int)style.space);
				SetInt(ShapesMaterialUtils.propDashSnap, (int)style.snap);
				if (setType)
				{
					SetInt(ShapesMaterialUtils.propDashType, (int)style.type);
					if (style.type.HasModifier())
					{
						SetFloat(ShapesMaterialUtils.propDashShapeModifier, style.shapeModifier);
					}
				}
			}
			if (now)
			{
				SetFloatNow(ShapesMaterialUtils.propDashSize, netAbsoluteSize);
			}
			else
			{
				SetFloat(ShapesMaterialUtils.propDashSize, netAbsoluteSize);
			}
		}

		protected float GetNetDashSpacing(DashStyle style, bool dashed, bool matchSpacingToSize, float thickness)
		{
			if (matchSpacingToSize && style.space == DashSpace.FixedCount)
			{
				return 0.5f;
			}
			if (!matchSpacingToSize)
			{
				return style.GetNetAbsoluteSpacing(dashed, thickness);
			}
			return style.GetNetAbsoluteSize(dashed, thickness);
		}

		protected void SetColor(int prop, Color value)
		{
			if (ShapeGroup.shapeGroupsInScene > 0)
			{
				ShapeGroup[] componentsInParent = GetComponentsInParent<ShapeGroup>();
				if (componentsInParent != null)
				{
					foreach (ShapeGroup item in componentsInParent.Where((ShapeGroup g) => g.IsEnabled))
					{
						value *= item.Color;
					}
				}
			}
			Mpb.SetColor(prop, value);
		}

		protected void SetFloat(int prop, float value)
		{
			Mpb.SetFloat(prop, value);
		}

		protected void SetInt(int prop, int value)
		{
			Mpb.SetInt(prop, value);
		}

		protected void SetVector3(int prop, Vector3 value)
		{
			Mpb.SetVector(prop, value);
		}

		protected void SetVector4(int prop, Vector4 value)
		{
			Mpb.SetVector(prop, value);
		}

		protected void SetColorNow(int prop, Color value)
		{
			SetColor(prop, value);
			ApplyProperties();
		}

		protected void SetFloatNow(int prop, float value)
		{
			Mpb.SetFloat(prop, value);
			ApplyProperties();
		}

		protected void SetIntNow(int prop, int value)
		{
			Mpb.SetInt(prop, value);
			ApplyProperties();
		}

		protected void SetVector3Now(int prop, Vector3 value)
		{
			Mpb.SetVector(prop, value);
			ApplyProperties();
		}

		protected void SetVector4Now(int prop, Vector4 value)
		{
			Mpb.SetVector(prop, value);
			ApplyProperties();
		}
	}
}
