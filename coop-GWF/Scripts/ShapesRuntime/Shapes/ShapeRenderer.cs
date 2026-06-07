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
		private protected Color color = Color.white;

		[SerializeField]
		private protected DetailLevel detailLevel = DetailLevel.Medium;

		[SerializeField]
		private protected ShapeCulling culling;

		[SerializeField]
		private protected float boundsPadding;

		[SerializeField]
		private int renderQueue = -1;

		public const int DEFAULT_RENDER_QUEUE_AUTO = -1;

		public const CompareFunction DEFAULT_ZTEST = CompareFunction.LessEqual;

		public const float DEFAULT_ZOFS_FACTOR = 0f;

		public const int DEFAULT_ZOFS_UNITS = 0;

		public const ColorWriteMask DEFAULT_COLOR_MASK = ColorWriteMask.All;

		[SerializeField]
		private CompareFunction zTest = CompareFunction.LessEqual;

		[SerializeField]
		private float zOffsetFactor;

		[SerializeField]
		private int zOffsetUnits;

		[SerializeField]
		private ColorWriteMask colorMask = ColorWriteMask.All;

		public const CompareFunction DEFAULT_STENCIL_COMP = CompareFunction.Always;

		public const StencilOp DEFAULT_STENCIL_OP = StencilOp.Keep;

		public const byte DEFAULT_STENCIL_REF_ID = 0;

		public const byte DEFAULT_STENCIL_MASK = byte.MaxValue;

		[SerializeField]
		private CompareFunction stencilComp = CompareFunction.Always;

		[SerializeField]
		private StencilOp stencilOpPass;

		[SerializeField]
		private byte stencilRefID;

		[SerializeField]
		private byte stencilReadMask = byte.MaxValue;

		[SerializeField]
		private byte stencilWriteMask = byte.MaxValue;

		private Material[] mats;

		private MaterialPropertyBlock Mpb => mpb ?? (mpb = new MaterialPropertyBlock());

		internal bool IsUsingUniqueMaterials => !IsInstanced;

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

		public ShapeCulling Culling
		{
			get
			{
				return culling;
			}
			set
			{
				culling = value;
				UpdateBounds();
			}
		}

		public float BoundsPadding
		{
			get
			{
				return boundsPadding;
			}
			set
			{
				boundsPadding = value;
				UpdateBounds();
			}
		}

		private bool IsInstanced
		{
			get
			{
				if (UsingDefaultZTests && UsingDefaultMasking)
				{
					return UsingDefaultRenderQueue;
				}
				return false;
			}
		}

		private bool UsingDefaultRenderQueue => renderQueue == -1;

		public int RenderQueue
		{
			get
			{
				return renderQueue;
			}
			set
			{
				renderQueue = value;
				if (IsUsingUniqueMaterials)
				{
					UpdateMaterial();
					Material[] array = instancedMaterials;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].renderQueue = renderQueue;
					}
				}
			}
		}

		private bool UsingDefaultZTests
		{
			get
			{
				if (zTest == CompareFunction.LessEqual && zOffsetFactor == 0f)
				{
					return zOffsetUnits == 0;
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

		public ColorWriteMask ColorMask
		{
			get
			{
				return colorMask;
			}
			set
			{
				SetIntOnAllInstancedMaterials(ShapesMaterialUtils.propColorMask, (int)(colorMask = value));
			}
		}

		private bool UsingDefaultMasking
		{
			get
			{
				if (stencilComp == CompareFunction.Always && stencilOpPass == StencilOp.Keep && stencilRefID == 0 && stencilReadMask == byte.MaxValue && stencilWriteMask == byte.MaxValue)
				{
					return colorMask == ColorWriteMask.All;
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

		private protected virtual int MaterialCount => 1;

		private protected virtual MeshUpdateMode MeshUpdateMode => MeshUpdateMode.UseAsset;

		internal virtual bool HasScaleModes => true;

		internal virtual bool HasDetailLevels => true;

		private protected virtual bool UseCamOnPreCull => false;

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
				MakeSureComponentExists(ref rnd, out var _);
			}
			if (rnd.receiveShadows)
			{
				rnd.receiveShadows = false;
			}
			if (rnd.shadowCastingMode != ShadowCastingMode.Off)
			{
				rnd.shadowCastingMode = ShadowCastingMode.Off;
			}
			if (rnd.lightProbeUsage != LightProbeUsage.Off)
			{
				rnd.lightProbeUsage = LightProbeUsage.Off;
			}
			if (rnd.reflectionProbeUsage != ReflectionProbeUsage.Off)
			{
				rnd.reflectionProbeUsage = ReflectionProbeUsage.Off;
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

		private protected abstract Bounds GetUnpaddedLocalBounds_Internal();

		private protected abstract void SetAllMaterialProperties();

		private protected virtual void ShapeClampRanges()
		{
		}

		private protected abstract void GetMaterials(Material[] mats);

		private protected virtual void GenerateMesh()
		{
		}

		private protected virtual Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.QuadMesh[HasDetailLevels ? 2 : 0];
		}

		internal virtual void CamOnPreCull()
		{
		}

		private void UpdateBounds()
		{
			Bounds bounds = GetBounds();
			MeshUpdateMode meshUpdateMode = MeshUpdateMode;
			if ((meshUpdateMode == MeshUpdateMode.UseAssetCopy || meshUpdateMode == MeshUpdateMode.SelfGenerated) && Mesh != null)
			{
				Mesh.bounds = bounds;
				rnd.ResetLocalBounds();
			}
			else if (Culling == ShapeCulling.CalculatedLocal)
			{
				rnd.localBounds = bounds;
			}
			else if (Culling == ShapeCulling.SimpleGlobal)
			{
				rnd.ResetLocalBounds();
			}
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

		private protected void UpdateMaterial()
		{
			if (mats == null || mats.Length != MaterialCount)
			{
				mats = new Material[MaterialCount];
			}
			GetMaterials(mats);
			if (IsUsingUniqueMaterials)
			{
				MakeSureMaterialInstancesAreGood(mats);
				for (int i = 0; i < mats.Length; i++)
				{
					mats[i] = instancedMaterials[i];
				}
			}
			VerifyComponents();
			rnd.sharedMaterials = mats;
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
			UpdateBounds();
		}

		public Bounds GetBounds()
		{
			Bounds unpaddedLocalBounds_Internal = GetUnpaddedLocalBounds_Internal();
			unpaddedLocalBounds_Internal.Expand(boundsPadding);
			return unpaddedLocalBounds_Internal;
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
			return new Bounds((vector2 + vector) / 2f, ShapesMath.Abs(vector2 - vector));
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
					array[i].SetInt_Shapes(property, value);
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

		internal void UpdateAllMaterialProperties()
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
					obj.SetInt_Shapes(ShapesMaterialUtils.propZTest, (int)zTest);
					obj.SetFloat(ShapesMaterialUtils.propZOffsetFactor, zOffsetFactor);
					obj.SetInt_Shapes(ShapesMaterialUtils.propZOffsetUnits, zOffsetUnits);
					obj.SetInt_Shapes(ShapesMaterialUtils.propColorMask, (int)colorMask);
					obj.SetInt_Shapes(ShapesMaterialUtils.propStencilComp, (int)stencilComp);
					obj.SetInt_Shapes(ShapesMaterialUtils.propStencilOpPass, (int)stencilOpPass);
					obj.SetInt_Shapes(ShapesMaterialUtils.propStencilID, stencilRefID);
					obj.SetInt_Shapes(ShapesMaterialUtils.propStencilReadMask, stencilReadMask);
					obj.SetInt_Shapes(ShapesMaterialUtils.propStencilWriteMask, stencilWriteMask);
					obj.renderQueue = renderQueue;
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

		private protected void ApplyProperties()
		{
			VerifyComponents();
			rnd.SetPropertyBlock(Mpb);
			UpdateBounds();
		}

		private protected void SetAllDashValues(DashStyle style, bool dashed, bool matchSpacingToSize, float thickness, bool setType, bool now)
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

		private protected float GetNetDashSpacing(DashStyle style, bool dashed, bool matchSpacingToSize, float thickness)
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

		private protected void SetColor(int prop, Color value)
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

		private protected void SetFloat(int prop, float value)
		{
			Mpb.SetFloat(prop, value);
		}

		private protected void SetInt(int prop, int value)
		{
			Mpb.SetInt_Shapes(prop, value);
		}

		private protected void SetVector3(int prop, Vector3 value)
		{
			Mpb.SetVector(prop, value);
		}

		private protected void SetVector4(int prop, Vector4 value)
		{
			Mpb.SetVector(prop, value);
		}

		private protected void SetColorNow(int prop, Color value)
		{
			SetColor(prop, value);
			ApplyProperties();
		}

		private protected void SetFloatNow(int prop, float value)
		{
			Mpb.SetFloat(prop, value);
			ApplyProperties();
		}

		private protected void SetIntNow(int prop, int value)
		{
			Mpb.SetInt_Shapes(prop, value);
			ApplyProperties();
		}

		private protected void SetVector3Now(int prop, Vector3 value)
		{
			Mpb.SetVector(prop, value);
			ApplyProperties();
		}

		private protected void SetVector4Now(int prop, Vector4 value)
		{
			Mpb.SetVector(prop, value);
			ApplyProperties();
		}
	}
}
