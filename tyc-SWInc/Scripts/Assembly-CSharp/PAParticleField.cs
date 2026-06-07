using System;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
public class PAParticleField : MonoBehaviour
{
	public enum ParticleType
	{
		Billboard = 0,
		Mesh = 1,
		Custom = 2
	}

	public enum SimulationSpace
	{
		World = 0,
		Local = 1,
		LocalWithDelta = 2
	}

	public enum Shape
	{
		Cube = 0,
		Sphere = 1,
		Cylinder = 2
	}

	public enum EdgeMode
	{
		Alpha = 0,
		Scale = 1,
		Both = 2
	}

	public enum MaterialType
	{
		Transparent = 0,
		TransparentLit = 1,
		Additive = 2,
		AdditiveLit = 3,
		CutOff = 4,
		CutOffLit = 5,
		Custom = 6,
		MeshDefault = 7,
		MeshUnlit = 8
	}

	public enum TextureType
	{
		Simple = 0,
		SpriteGrid = 1,
		AnimatedRows = 2
	}

	public enum SoftParticleType
	{
		None = 0,
		NearClipOnly = 1,
		NearClipAndCameraDepth = 2
	}

	public enum TurbulenceType
	{
		None = 0,
		Simplex2D = 1,
		Simplex = 2
	}

	private static readonly string[] builtinShaderNames = new string[9] { "PA/ParticleField/Transparent", "PA/ParticleField/TransparentLit", "PA/ParticleField/Additive", "PA/ParticleField/AdditiveLit", "PA/ParticleField/CutOff", "PA/ParticleField/CutOffLit", "DoNotUse", "PA/ParticleField/MeshDefault", "PA/ParticleField/MeshUnlit" };

	private const int MAX_PARTICLE_COUNT = 16250;

	public bool clearCacheInBuilds;

	[NonSerialized]
	public float SimulationSpeed = 1f;

	private bool isOpenGL;

	[SerializeField]
	private int mSeed = 1234;

	[SerializeField]
	private ParticleType mGeneratorType;

	[SerializeField]
	private Mesh mInputMesh;

	[SerializeField]
	private int mParticleCount = 1200;

	[SerializeField]
	private float mParticleCountMask = 1f;

	[SerializeField]
	private Vector3 mFieldSize = new Vector3(10f, 10f, 10f);

	[SerializeField]
	private Vector3 mEdgeThreshold = Vector3.one;

	[SerializeField]
	private EdgeMode mEdgeMode;

	[SerializeField]
	private SimulationSpace mSimulationSpace;

	[SerializeField]
	private Shape mShape;

	[SerializeField]
	private bool mUseExclusionZones;

	[SerializeField]
	private Transform mExclusionAnchorOverride;

	[SerializeField]
	private Vector2 mParticleSize = new Vector2(0.1f, 0.1f);

	[SerializeField]
	private float mSpeed = 0.1f;

	[SerializeField]
	private Vector3 mSpeedMask = Vector3.one;

	[SerializeField]
	private Color mColor = Color.white;

	[SerializeField]
	private Vector3 mForce = Vector3.zero;

	[SerializeField]
	private bool mCustomFacingDirection;

	[SerializeField]
	private Vector3 mFacingDirection = Vector3.up;

	[SerializeField]
	private bool mCustomUpDirection;

	[SerializeField]
	private Vector3 mUpDirection = new Vector3(0f, 1f, 0f);

	[SerializeField]
	private bool mStretchedBillboard;

	[SerializeField]
	private float mSpeedScaleMultiplier = 10f;

	[SerializeField]
	private bool mSpin;

	[SerializeField]
	private float mSpinSpeed;

	[SerializeField]
	private float mMinSpinSpeed = -1f;

	[SerializeField]
	private bool mCustomRotationAxis;

	[SerializeField]
	private Vector3 mRotationAxis = new Vector3(0f, 1f, 0f);

	[SerializeField]
	private SoftParticleType mSoftParticles = SoftParticleType.NearClipOnly;

	[SerializeField]
	private float mNearFadeDistance = 1f;

	[SerializeField]
	private float mNearFadeOffset;

	[SerializeField]
	private float mSoftness = 0.5f;

	[SerializeField]
	private TurbulenceType mTurbulenceType;

	[SerializeField]
	private float mTurbulenceFrequency = 1f;

	[SerializeField]
	private float mTurbulenceAmplitude = 1f;

	[SerializeField]
	private Vector3 mTurbulenceScale = Vector3.one;

	[SerializeField]
	private Vector3 mTurbulenceOffsetSpeed = new Vector3(0f, 0.25f, 0f);

	[SerializeField]
	private Gradient mColorVariation = new Gradient();

	[SerializeField]
	private float mMinimumSize = 1f;

	[SerializeField]
	private float mMinimumSpeed = 1f;

	[SerializeField]
	private MaterialType mMaterialType;

	[SerializeField]
	private Shader mShader;

	[SerializeField]
	private Texture2D mTexture;

	[SerializeField]
	private Vector2 mPivotOffset = new Vector2(0f, 0f);

	[SerializeField]
	private TextureType mTextureType;

	[SerializeField]
	private int mSpriteColumns = 1;

	[SerializeField]
	private int mSpriteRows = 1;

	[SerializeField]
	private float mFramerate = 16f;

	[SerializeField]
	private float mCutOff = 0.01f;

	[SerializeField]
	private bool mReceiveShadows;

	[SerializeField]
	private ShadowCastingMode mCastShadows;

	private Mesh particleMesh;

	private MeshFilter meshFilter;

	private MeshRenderer meshRenderer;

	[SerializeField]
	private PAParticleMeshGenerator m_MeshGenerator;

	[SerializeField]
	public Material material;

	private Material renderingMaterial;

	private float time;

	private Vector3 speedTime = Vector3.zero;

	private Vector3 forceTime = Vector3.zero;

	private float spinTime;

	private Vector3 turbulenceOffsetTime = Vector3.zero;

	private float frameTime;

	private Vector3 position;

	private Vector3 deltaPosition;

	private Vector3 scale;

	private bool foundExclusionZones;

	private PAExclusionZone[] zones = new PAExclusionZone[3];

	[SerializeField]
	private Material temporarySerializableMaterial;

	public int seed
	{
		get
		{
			return mSeed;
		}
		set
		{
			if (mSeed != value)
			{
				mSeed = value;
				meshIsDirtyMask |= MeshFlags.Seed;
			}
		}
	}

	public ParticleType generatorType
	{
		get
		{
			return mGeneratorType;
		}
		set
		{
			if (mGeneratorType != value)
			{
				mGeneratorType = value;
				meshIsDirtyMask |= MeshFlags.Generator;
			}
		}
	}

	public int particleCount
	{
		get
		{
			return mParticleCount;
		}
		set
		{
			value = ((!meshGenerator) ? Mathf.Clamp(value, 0, 16250) : meshGenerator.GetClampedParticleCount(value));
			if (mParticleCount != value)
			{
				mParticleCount = value;
				meshIsDirtyMask |= MeshFlags.Count;
			}
		}
	}

	public float particleCountMask
	{
		get
		{
			return mParticleCountMask;
		}
		set
		{
			value = Mathf.Clamp01(value);
			if (mParticleCountMask != value)
			{
				mParticleCountMask = value;
				shaderIsDirty = true;
			}
		}
	}

	public Vector3 fieldSize
	{
		get
		{
			return mFieldSize;
		}
		set
		{
			if (mFieldSize != value)
			{
				mFieldSize = value;
				shaderIsDirty = true;
			}
		}
	}

	public Vector3 edgeThreshold
	{
		get
		{
			return mEdgeThreshold;
		}
		set
		{
			value.x = Mathf.Clamp01(value.x);
			value.y = Mathf.Clamp01(value.y);
			value.z = Mathf.Clamp01(value.z);
			if (mEdgeThreshold != value)
			{
				mEdgeThreshold = value;
				shaderIsDirty = true;
			}
		}
	}

	public SimulationSpace simulationSpace
	{
		get
		{
			return mSimulationSpace;
		}
		set
		{
			if (mSimulationSpace != value)
			{
				mSimulationSpace = value;
				shaderIsDirty = true;
			}
		}
	}

	public Shape shape
	{
		get
		{
			return mShape;
		}
		set
		{
			if (mShape != value)
			{
				mShape = value;
				shaderIsDirty = true;
			}
		}
	}

	public EdgeMode edgeMode
	{
		get
		{
			return mEdgeMode;
		}
		set
		{
			if (mEdgeMode != value)
			{
				mEdgeMode = value;
				shaderIsDirty = true;
			}
		}
	}

	public bool useExclusionZones
	{
		get
		{
			return mUseExclusionZones;
		}
		set
		{
			if (mUseExclusionZones != value)
			{
				mUseExclusionZones = value;
				shaderIsDirty = true;
			}
		}
	}

	public Transform exclusionAnchorOverride
	{
		get
		{
			return mExclusionAnchorOverride;
		}
		set
		{
			if (mExclusionAnchorOverride != value)
			{
				mExclusionAnchorOverride = value;
			}
		}
	}

	public Color color
	{
		get
		{
			return mColor;
		}
		set
		{
			if (mColor != value)
			{
				mColor = value;
				shaderIsDirty = true;
			}
		}
	}

	public float alpha
	{
		get
		{
			return color.a;
		}
		set
		{
			if (this.color.a != value)
			{
				Color color = this.color;
				color.a = value;
				this.color = color;
			}
		}
	}

	public float speed
	{
		get
		{
			return mSpeed;
		}
		set
		{
			if (mSpeed != value)
			{
				mSpeed = value;
				shaderIsDirty = true;
			}
		}
	}

	public Vector3 speedMask
	{
		get
		{
			return mSpeedMask;
		}
		set
		{
			if (mSpeedMask != value)
			{
				mSpeedMask = value;
				shaderIsDirty = true;
			}
		}
	}

	public Vector2 particleSize
	{
		get
		{
			return mParticleSize;
		}
		set
		{
			if (mParticleSize != value)
			{
				mParticleSize = value;
				shaderIsDirty = true;
			}
		}
	}

	public bool stretchedBillboard
	{
		get
		{
			return mStretchedBillboard;
		}
		set
		{
			if (mStretchedBillboard != value)
			{
				mStretchedBillboard = value;
				if (value)
				{
					mCustomUpDirection = false;
					mSpin = false;
				}
				shaderIsDirty = true;
			}
		}
	}

	public float speedScaleMultiplier
	{
		get
		{
			return mSpeedScaleMultiplier;
		}
		set
		{
			if (mSpeedScaleMultiplier != value)
			{
				mSpeedScaleMultiplier = value;
				shaderIsDirty = true;
			}
		}
	}

	public bool spin
	{
		get
		{
			return mSpin;
		}
		set
		{
			if (mSpin != value)
			{
				mSpin = value;
				if (value)
				{
					mStretchedBillboard = false;
					mCustomUpDirection = false;
				}
				shaderIsDirty = true;
			}
		}
	}

	public float spinSpeed
	{
		get
		{
			return mSpinSpeed;
		}
		set
		{
			if (mSpinSpeed != value)
			{
				mSpinSpeed = value;
				shaderIsDirty = true;
			}
		}
	}

	public float minSpinSpeed
	{
		get
		{
			return mMinSpinSpeed;
		}
		set
		{
			value = Mathf.Clamp(value, -1f, 1f);
			if (mMinSpinSpeed != value)
			{
				mMinSpinSpeed = value;
				meshIsDirtyMask |= MeshFlags.Speed;
			}
		}
	}

	public bool customRotationAxis
	{
		get
		{
			return mCustomRotationAxis;
		}
		set
		{
			if (mCustomRotationAxis != value)
			{
				mCustomRotationAxis = value;
				meshIsDirtyMask |= MeshFlags.Speed;
			}
		}
	}

	public Vector3 rotationAxis
	{
		get
		{
			return mRotationAxis;
		}
		set
		{
			if (mRotationAxis != value)
			{
				mRotationAxis = value;
				meshIsDirtyMask |= MeshFlags.Speed;
			}
		}
	}

	public bool customFacingDirection
	{
		get
		{
			return mCustomFacingDirection;
		}
		set
		{
			if (mCustomFacingDirection != value)
			{
				mCustomFacingDirection = value;
				shaderIsDirty = true;
			}
		}
	}

	public Vector3 facingDirection
	{
		get
		{
			return mFacingDirection;
		}
		set
		{
			if (mFacingDirection != value)
			{
				mFacingDirection = value;
				mStretchedBillboard = false;
				shaderIsDirty = true;
			}
		}
	}

	public bool customUpDirection
	{
		get
		{
			return mCustomUpDirection;
		}
		set
		{
			if (mCustomUpDirection != value)
			{
				mCustomUpDirection = value;
				if (value)
				{
					mSpin = false;
					mStretchedBillboard = false;
				}
				shaderIsDirty = true;
			}
		}
	}

	public Vector3 upDirection
	{
		get
		{
			return mUpDirection;
		}
		set
		{
			if (mUpDirection != value)
			{
				mUpDirection = value;
				shaderIsDirty = true;
			}
		}
	}

	public SoftParticleType softParticles
	{
		get
		{
			return mSoftParticles;
		}
		set
		{
			if (value == SoftParticleType.NearClipAndCameraDepth && int.Parse(Application.unityVersion.Split('.')[0]) < 5 && !Application.HasProLicense())
			{
				Debug.Log("Soft particles requires Unity Pro");
				if (mSoftParticles != SoftParticleType.NearClipOnly)
				{
					mSoftParticles = SoftParticleType.NearClipOnly;
					shaderIsDirty = true;
				}
			}
			else if (mSoftParticles != value)
			{
				mSoftParticles = value;
				shaderIsDirty = true;
			}
		}
	}

	public float nearFadeDistance
	{
		get
		{
			return mNearFadeDistance;
		}
		set
		{
			if (mNearFadeDistance != value)
			{
				mNearFadeDistance = value;
				shaderIsDirty = true;
			}
		}
	}

	public float nearFadeOffset
	{
		get
		{
			return mNearFadeOffset;
		}
		set
		{
			if (mNearFadeOffset != value)
			{
				mNearFadeOffset = value;
				shaderIsDirty = true;
			}
		}
	}

	public float softness
	{
		get
		{
			return mSoftness;
		}
		set
		{
			if (mSoftness != value)
			{
				mSoftness = value;
				shaderIsDirty = true;
			}
		}
	}

	public TurbulenceType turbulenceType
	{
		get
		{
			return mTurbulenceType;
		}
		set
		{
			if (mTurbulenceType != value)
			{
				mTurbulenceType = value;
				shaderIsDirty = true;
			}
		}
	}

	public float turbulenceFrequency
	{
		get
		{
			return mTurbulenceFrequency;
		}
		set
		{
			if (mTurbulenceFrequency != value)
			{
				mTurbulenceFrequency = value;
				shaderIsDirty = true;
			}
		}
	}

	public float turbulenceAmplitude
	{
		get
		{
			return mTurbulenceAmplitude;
		}
		set
		{
			if (mTurbulenceAmplitude != value)
			{
				mTurbulenceAmplitude = value;
				shaderIsDirty = true;
			}
		}
	}

	public Vector3 turbulenceScale
	{
		get
		{
			return mTurbulenceScale;
		}
		set
		{
			if (mTurbulenceScale != value)
			{
				mTurbulenceScale = value;
				shaderIsDirty = true;
			}
		}
	}

	public Vector3 turbulenceOffsetSpeed
	{
		get
		{
			return mTurbulenceOffsetSpeed;
		}
		set
		{
			if (mTurbulenceOffsetSpeed != value)
			{
				mTurbulenceOffsetSpeed = value;
				shaderIsDirty = true;
			}
		}
	}

	public Gradient colorVariation
	{
		get
		{
			if (mColorVariation == null)
			{
				mColorVariation = new Gradient();
			}
			return mColorVariation;
		}
		set
		{
			if (mColorVariation != value)
			{
				mColorVariation = value;
				meshIsDirtyMask |= MeshFlags.Color;
			}
		}
	}

	public float minimumSize
	{
		get
		{
			return mMinimumSize;
		}
		set
		{
			value = Mathf.Clamp01(value);
			if (mMinimumSize != value)
			{
				mMinimumSize = value;
				meshIsDirtyMask |= MeshFlags.Surface;
			}
		}
	}

	public float minimumSpeed
	{
		get
		{
			return mMinimumSpeed;
		}
		set
		{
			value = Mathf.Clamp01(value);
			if (mMinimumSpeed != value)
			{
				mMinimumSpeed = value;
				meshIsDirtyMask |= MeshFlags.Speed;
			}
		}
	}

	public Vector3 force
	{
		get
		{
			return mForce;
		}
		set
		{
			if (mForce != value)
			{
				mForce = value;
				shaderIsDirty = true;
			}
		}
	}

	public MaterialType materialType
	{
		get
		{
			return mMaterialType;
		}
		set
		{
			if (mMaterialType != value)
			{
				material = null;
				mMaterialType = value;
				if (mMaterialType != MaterialType.Custom)
				{
					shader = Shader.Find(builtinShaderNames[(int)mMaterialType]);
					shaderIsDirty = true;
				}
			}
		}
	}

	public Shader shader
	{
		get
		{
			return mShader;
		}
		private set
		{
			if (mShader != value)
			{
				mShader = value;
				shaderIsDirty = true;
			}
		}
	}

	public Texture2D texture
	{
		get
		{
			return mTexture;
		}
		set
		{
			if (mTexture != value)
			{
				mTexture = value;
				shaderIsDirty = true;
			}
		}
	}

	public TextureType textureType
	{
		get
		{
			return mTextureType;
		}
		set
		{
			if (mTextureType != value)
			{
				mTextureType = value;
				shaderIsDirty = true;
				meshIsDirtyMask |= MeshFlags.Surface;
			}
		}
	}

	public int spriteColumns
	{
		get
		{
			return mSpriteColumns;
		}
		set
		{
			value = Mathf.Min(value, 1);
			if (mSpriteColumns != value)
			{
				mSpriteColumns = value;
				meshIsDirtyMask |= MeshFlags.Surface;
			}
		}
	}

	public int spriteRows
	{
		get
		{
			return mSpriteRows;
		}
		set
		{
			value = Mathf.Min(value, 1);
			if (mSpriteRows != value)
			{
				mSpriteRows = value;
				meshIsDirtyMask |= MeshFlags.Surface;
			}
		}
	}

	public float framerate
	{
		get
		{
			return mFramerate;
		}
		set
		{
			if (mFramerate != value)
			{
				mFramerate = value;
			}
		}
	}

	public float cutOff
	{
		get
		{
			return mCutOff;
		}
		set
		{
			value = Mathf.Clamp01(value);
			if (mCutOff != value)
			{
				mCutOff = value;
				shaderIsDirty = true;
			}
		}
	}

	public Vector2 pivotOffset
	{
		get
		{
			return mPivotOffset;
		}
		set
		{
			if (mPivotOffset != value)
			{
				mPivotOffset = value;
				meshIsDirtyMask |= MeshFlags.Surface;
			}
		}
	}

	public Mesh inputMesh
	{
		get
		{
			return mInputMesh;
		}
		set
		{
			mInputMesh = value;
			meshIsDirtyMask |= MeshFlags.All;
		}
	}

	public bool receiveShadows
	{
		get
		{
			return mReceiveShadows;
		}
		set
		{
			mReceiveShadows = value;
			if ((bool)meshRenderer)
			{
				meshRenderer.receiveShadows = value;
			}
		}
	}

	public ShadowCastingMode castShadows
	{
		get
		{
			return mCastShadows;
		}
		set
		{
			mCastShadows = value;
			if ((bool)meshRenderer)
			{
				meshRenderer.shadowCastingMode = value;
			}
		}
	}

	private PAParticleMeshGenerator meshGenerator
	{
		get
		{
			if (m_MeshGenerator == null)
			{
				m_MeshGenerator = GetComponent<PAParticleMeshGenerator>();
				if (m_MeshGenerator == null && generatorType != ParticleType.Custom)
				{
					UpdateGeneratorType(generatorType);
				}
			}
			return m_MeshGenerator;
		}
		set
		{
			m_MeshGenerator = value;
		}
	}

	public MeshFlags meshIsDirtyMask { get; set; }

	public bool shaderIsDirty { get; set; }

	private T GetOrAddComponent<T>() where T : Component
	{
		T val = GetComponent<T>();
		if (!val)
		{
			val = base.gameObject.AddComponent<T>();
		}
		return val;
	}

	private void GetRenderingComponents()
	{
		meshFilter = GetOrAddComponent<MeshFilter>();
		meshFilter.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
		meshRenderer = GetOrAddComponent<MeshRenderer>();
		meshRenderer.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
		meshRenderer.receiveShadows = mReceiveShadows;
		meshRenderer.shadowCastingMode = mCastShadows;
	}

	private void CreateAssetTypes()
	{
		if (!particleMesh)
		{
			particleMesh = new Mesh();
			particleMesh.name = base.gameObject.name + "_PAPF";
		}
		particleMesh.hideFlags = HideFlags.HideAndDontSave | HideFlags.HideInInspector;
		meshFilter.sharedMesh = particleMesh;
		if (!shader)
		{
			shader = Shader.Find("PA/ParticleField/Transparent");
		}
		renderingMaterial = CreateInstanceMaterial();
		meshRenderer.sharedMaterial = renderingMaterial;
	}

	private Material CreateInstanceMaterial()
	{
		return new Material((materialType == MaterialType.Custom && (bool)material) ? material.shader : shader)
		{
			name = base.gameObject.name + " (Instance)" + DateTime.Now.Millisecond,
			hideFlags = (HideFlags.HideAndDontSave | HideFlags.HideInInspector)
		};
	}

	private void UpdateGeneratorType(ParticleType newType)
	{
		if ((bool)m_MeshGenerator)
		{
			if (newType != ParticleType.Custom)
			{
				UnityEngine.Object.DestroyImmediate(m_MeshGenerator);
			}
			else
			{
				m_MeshGenerator.hideFlags = HideFlags.None;
			}
		}
		switch (newType)
		{
		case ParticleType.Billboard:
			m_MeshGenerator = base.gameObject.AddComponent<PABillboardParticle>();
			m_MeshGenerator.hideFlags = HideFlags.HideInInspector;
			break;
		case ParticleType.Mesh:
		{
			PAMeshParticle pAMeshParticle = base.gameObject.AddComponent<PAMeshParticle>();
			pAMeshParticle.inputMesh = inputMesh;
			m_MeshGenerator = pAMeshParticle;
			m_MeshGenerator.hideFlags = HideFlags.HideInInspector;
			break;
		}
		}
		if (newType != ParticleType.Custom && materialType != MaterialType.Custom)
		{
			if (newType == ParticleType.Mesh)
			{
				materialType = MaterialType.MeshDefault;
			}
			else
			{
				materialType = MaterialType.Transparent;
			}
			CreateAssetTypes();
		}
		mGeneratorType = newType;
		shaderIsDirty = true;
		meshIsDirtyMask = MeshFlags.All;
	}

	private void SetShaderValues()
	{
		PAPFHelper.GetPropertyIDs();
		if (materialType == MaterialType.Custom && material != null)
		{
			if (renderingMaterial.shader != material.shader)
			{
				renderingMaterial.shader = material.shader;
			}
			renderingMaterial.CopyPropertiesFromMaterial(material);
		}
		else if (renderingMaterial.shader != shader)
		{
			renderingMaterial.shader = shader;
		}
		Vector3 vector = speed * speedMask;
		Vector3 vector2 = new Vector3(vector.x / fieldSize.x, vector.y / fieldSize.y, vector.z / fieldSize.z);
		Vector3 vector3 = new Vector3((0f - force.x) / fieldSize.x, (0f - force.y) / fieldSize.y, (0f - force.z) / fieldSize.z);
		renderingMaterial.SetVector(PAPFHelper._DeltaSpeed, vector2);
		renderingMaterial.SetVector(PAPFHelper._DeltaForce, vector3);
		renderingMaterial.SetVector(PAPFHelper._TurbulenceDeltaOffset, turbulenceOffsetSpeed * (1f / 60f));
		Vector3 vector4 = Vector3.Scale(fieldSize, base.transform.lossyScale);
		Vector3 vector5 = ((simulationSpace == SimulationSpace.LocalWithDelta) ? new Vector3(deltaPosition.x / vector4.x, deltaPosition.y / vector4.y, deltaPosition.z / vector4.z) : Vector3.zero);
		renderingMaterial.SetVector(PAPFHelper._DeltaPosition, vector5);
		if (materialType != MaterialType.Custom)
		{
			renderingMaterial.SetColor(PAPFHelper._Color, color);
		}
		else if (material != null && material.HasProperty(PAPFHelper._Color))
		{
			renderingMaterial.SetColor(PAPFHelper._Color, material.color * color);
		}
		if (materialType != MaterialType.Custom)
		{
			renderingMaterial.SetTexture(PAPFHelper._MainTex, texture);
			renderingMaterial.SetFloat(PAPFHelper._CutOff, cutOff);
		}
		if (textureType != TextureType.AnimatedRows)
		{
			renderingMaterial.SetFloat(PAPFHelper._UOffset, 0f);
		}
		renderingMaterial.SetFloat(PAPFHelper._CountMask, particleCountMask);
		renderingMaterial.SetFloat(PAPFHelper._ParticleCount, particleCount);
		renderingMaterial.SetVector(PAPFHelper._FieldSize, Vector3.Scale(fieldSize, (simulationSpace == SimulationSpace.World) ? base.transform.lossyScale : Vector3.one));
		renderingMaterial.SetVector(PAPFHelper._EdgeThreshold, Vector3.one - edgeThreshold);
		renderingMaterial.SetVector(PAPFHelper._InverseEdgeThreshold, new Vector3(1f / edgeThreshold.x, 1f / edgeThreshold.y, 1f / edgeThreshold.z));
		renderingMaterial.SetVector(PAPFHelper._ParticleSize, particleSize);
		renderingMaterial.SetFloat(PAPFHelper._SpeedScale, stretchedBillboard ? speedScaleMultiplier : 1f);
		renderingMaterial.SetVector(PAPFHelper._FaceDirection, customFacingDirection ? (facingDirection.normalized + Vector3.right * 0.001f) : Vector3.forward);
		renderingMaterial.SetVector(PAPFHelper._UpDirection, mCustomUpDirection ? upDirection.normalized : Vector3.up);
		renderingMaterial.SetFloat(PAPFHelper._NearFadeDistance, (softParticles != SoftParticleType.None) ? nearFadeDistance : 0f);
		renderingMaterial.SetFloat(PAPFHelper._NearFadeOffset, (softParticles != SoftParticleType.None) ? nearFadeOffset : 0f);
		renderingMaterial.SetFloat(PAPFHelper._Softness, softness);
		renderingMaterial.SetFloat(PAPFHelper._TurbulenceFrequency, turbulenceFrequency);
		renderingMaterial.SetVector(PAPFHelper._TurbulenceScale, turbulenceScale * turbulenceAmplitude);
		SetFloatKeyword(PAPFHelper._EdgeAlpha, edgeMode == EdgeMode.Alpha || edgeMode == EdgeMode.Both);
		SetFloatKeyword(PAPFHelper._EdgeScale, edgeMode == EdgeMode.Scale || edgeMode == EdgeMode.Both);
		SetFloatKeyword(PAPFHelper._UserFacing, customFacingDirection);
		SetFloatKeyword(PAPFHelper._Editor, !Application.isPlaying);
		SetKeyword("DIRECTIONAL_ON", stretchedBillboard);
		SetKeyword("WORLDSPACE_ON", simulationSpace == SimulationSpace.World);
		SetKeyword("SPIN_ON", spin);
		SetKeyword("TURBULENCE_SIMPLEX2D", turbulenceType == TurbulenceType.Simplex2D);
		SetKeyword("TURBULENCE_SIMPLEX", turbulenceType == TurbulenceType.Simplex);
		SetKeyword("SHAPE_SPHERE", shape == Shape.Sphere);
		SetKeyword("SHAPE_CYLINDER", shape == Shape.Cylinder);
		float num = ((generatorType == ParticleType.Mesh) ? particleSize.x : Mathf.Max(particleSize.x, particleSize.y));
		if ((bool)particleMesh && (bool)meshGenerator)
		{
			particleMesh.bounds = new Bounds(Vector3.zero, fieldSize + num * meshGenerator.GetParticleBaseSize() * 2f * Vector3.one);
		}
	}

	private void SetKeyword(string keyword, bool enable)
	{
		SetMaterialKeyword(keyword, enable, renderingMaterial);
	}

	private static void SetMaterialKeyword(string keyword, bool enable, Material material)
	{
		if ((bool)material)
		{
			if (enable)
			{
				material.EnableKeyword(keyword);
			}
			else
			{
				material.DisableKeyword(keyword);
			}
		}
	}

	private void SetFloatKeyword(string keyword, bool enable)
	{
		renderingMaterial.SetFloat(keyword, enable ? 1 : 0);
	}

	private void SetFloatKeyword(int keywordID, bool enable)
	{
		renderingMaterial.SetFloat(keywordID, enable ? 1 : 0);
	}

	public void UpdateParticleField()
	{
		UpdateMesh();
		UpdateShader();
	}

	public void UpdateMesh()
	{
		if ((meshIsDirtyMask & MeshFlags.Generator) != MeshFlags.None)
		{
			UpdateGeneratorType(generatorType);
		}
		if (meshGenerator != null)
		{
			meshGenerator.UpdateMesh(particleMesh, this);
		}
		meshIsDirtyMask = MeshFlags.None;
	}

	public void UpdateShader()
	{
		SetShaderValues();
		shaderIsDirty = false;
	}

	private void UpdateAnimationValues()
	{
		if (Application.isPlaying && SimulationSpeed > 0f)
		{
			Simulate(Time.deltaTime * SimulationSpeed);
		}
	}

	public void Simulate(float t, bool restart = false)
	{
		if (restart)
		{
			ResetTimers();
		}
		time += t;
		speedTime += speed * speedMask * t;
		forceTime += force * (0f - t);
		spinTime += spinSpeed * t;
		turbulenceOffsetTime += turbulenceOffsetSpeed * t;
		frameTime += t * framerate;
	}

	private void UpdateExclusionZoneValues()
	{
		if (useExclusionZones)
		{
			foundExclusionZones = PAExclusionZone.GetExclusionZones(ref zones, exclusionAnchorOverride ? exclusionAnchorOverride.position : base.transform.position, new Bounds(base.transform.position, fieldSize), base.gameObject.layer);
		}
	}

	private void SetShaderAnimationValues()
	{
		if (Application.isPlaying)
		{
			renderingMaterial.SetVector(PAPFHelper._Speed, new Vector3(speedTime.x / fieldSize.x, speedTime.y / fieldSize.y, speedTime.z / fieldSize.z));
			renderingMaterial.SetVector(PAPFHelper._Force, new Vector3(forceTime.x / fieldSize.x, forceTime.y / fieldSize.y, forceTime.z / fieldSize.z));
			renderingMaterial.SetFloat(PAPFHelper._SpinSpeed, spinTime * 0.5f * 3.145f / 180f);
			renderingMaterial.SetFloat(PAPFHelper._TotalTime, time);
			renderingMaterial.SetVector(PAPFHelper._TurbulenceOffset, turbulenceOffsetTime);
			if (textureType == TextureType.AnimatedRows)
			{
				int num = (int)Mathf.Repeat(frameTime, spriteColumns);
				renderingMaterial.SetFloat(PAPFHelper._UOffset, (float)num / (float)spriteColumns);
			}
			return;
		}
		Vector3 vector = speed * speedMask;
		Vector3 vector2 = new Vector3(vector.x / fieldSize.x, vector.y / fieldSize.y, vector.z / fieldSize.z);
		Vector3 vector3 = new Vector3((0f - force.x) / fieldSize.x, (0f - force.y) / fieldSize.y, (0f - force.z) / fieldSize.z);
		renderingMaterial.SetVector(PAPFHelper._Speed, vector2);
		renderingMaterial.SetVector(PAPFHelper._Force, vector3);
		renderingMaterial.SetFloat(PAPFHelper._SpinSpeed, spinSpeed * 0.5f * 3.14159f / 180f);
		renderingMaterial.SetFloat(PAPFHelper._TotalTime, Time.timeSinceLevelLoad);
		renderingMaterial.SetVector(PAPFHelper._TurbulenceOffset, turbulenceOffsetSpeed);
		if (textureType == TextureType.AnimatedRows)
		{
			int num2 = (int)Mathf.Repeat(Time.timeSinceLevelLoad * framerate, spriteColumns);
			renderingMaterial.SetFloat(PAPFHelper._UOffset, (float)num2 / (float)spriteColumns);
		}
	}

	private void SetShaderExclusionZoneValues()
	{
		if (!useExclusionZones || !foundExclusionZones)
		{
			renderingMaterial.DisableKeyword("EXCLUSION_ON");
			return;
		}
		renderingMaterial.EnableKeyword("EXCLUSION_ON");
		for (int i = 0; i < zones.Length; i++)
		{
			if (zones[i] != null)
			{
				zones[i].transform.localScale *= 0.5f;
				Matrix4x4 value = ((simulationSpace == SimulationSpace.World) ? zones[i].transform.worldToLocalMatrix : (zones[i].transform.worldToLocalMatrix * base.transform.localToWorldMatrix));
				zones[i].transform.localScale *= 2f;
				Vector3 vector = Vector3.Min(zones[i].edgeThreshold, Vector3.one * 0.9999f);
				Vector3 vector2 = new Vector3(1f / (1f - vector.x), 1f / (1f - vector.y), 1f / (1f - vector.z));
				renderingMaterial.SetMatrix(PAPFHelper._ExclusionMatrix[i], value);
				renderingMaterial.SetVector(PAPFHelper._ExclusionThreshold[i], vector);
				renderingMaterial.SetVector(PAPFHelper._InverseExclusionThreshold[i], vector2);
			}
			else
			{
				renderingMaterial.SetMatrix(PAPFHelper._ExclusionMatrix[i], Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * 100000f));
				renderingMaterial.SetVector(PAPFHelper._ExclusionThreshold[i], Vector3.zero);
				renderingMaterial.SetVector(PAPFHelper._InverseExclusionThreshold[i], Vector3.one * float.PositiveInfinity);
			}
		}
	}

	private void Start()
	{
		meshIsDirtyMask = MeshFlags.None;
		isOpenGL = SystemInfo.graphicsDeviceVersion.ToLower().Contains("opengl");
		GetRenderingComponents();
		CreateAssetTypes();
		UpdateParticleField();
	}

	private void OnDisable()
	{
		ResetTimers();
	}

	public void ResetTimers()
	{
		time = 0f;
		spinTime = 0f;
		speedTime = Vector3.zero;
		forceTime = Vector3.zero;
		turbulenceOffsetTime = Vector3.zero;
		frameTime = 0f;
	}

	private void Update()
	{
		if (base.transform.position != position)
		{
			Vector3 vector = base.transform.InverseTransformDirection(base.transform.position - position);
			deltaPosition += vector;
			position = base.transform.position;
			shaderIsDirty = true;
		}
		if (base.transform.lossyScale != scale)
		{
			scale = base.transform.lossyScale;
			shaderIsDirty = true;
		}
		UpdateAnimationValues();
		UpdateExclusionZoneValues();
		if (meshIsDirtyMask != MeshFlags.None)
		{
			UpdateMesh();
		}
		if (materialType != MaterialType.Custom)
		{
			if (shaderIsDirty)
			{
				UpdateShader();
			}
			SetShaderAnimationValues();
			SetShaderExclusionZoneValues();
		}
	}

	private void OnWillRenderObject()
	{
		if ((bool)renderingMaterial)
		{
			if (materialType == MaterialType.Custom)
			{
				UpdateShader();
				SetShaderExclusionZoneValues();
				SetShaderAnimationValues();
			}
			if (isOpenGL)
			{
				renderingMaterial.SetFloat(PAPFHelper._NearFadeDistance, Camera.current.orthographic ? 0f : mNearFadeDistance);
			}
			bool flag = softParticles == SoftParticleType.NearClipAndCameraDepth;
			flag &= Camera.current.depthTextureMode != DepthTextureMode.None;
			flag &= !Application.isMobilePlatform;
			SetKeyword("SOFTPARTICLES_ON", flag);
		}
	}

	private void OnDestroy()
	{
		if ((bool)renderingMaterial)
		{
			UnityEngine.Object.DestroyImmediate(renderingMaterial);
		}
		if ((bool)particleMesh)
		{
			UnityEngine.Object.DestroyImmediate(particleMesh);
		}
	}

	public int GetMaxCount()
	{
		if (meshGenerator != null)
		{
			return meshGenerator.GetMaximumParticleCount();
		}
		return 16250;
	}

	public Bounds GetBounds()
	{
		if ((bool)meshRenderer)
		{
			return meshRenderer.bounds;
		}
		return new Bounds(base.transform.position, Vector3.Scale(fieldSize, base.transform.lossyScale));
	}

	public static PAParticleField Create(string name)
	{
		return new GameObject(name).AddComponent<PAParticleField>();
	}

	private void CreateTemporarySerializableMaterial()
	{
		temporarySerializableMaterial = new Material((mMaterialType != MaterialType.Custom) ? shader : material.shader);
		SetMaterialKeyword("DIRECTIONAL_ON", stretchedBillboard, temporarySerializableMaterial);
		SetMaterialKeyword("WORLDSPACE_ON", simulationSpace == SimulationSpace.World, temporarySerializableMaterial);
		SetMaterialKeyword("SPIN_ON", spin, temporarySerializableMaterial);
		SetMaterialKeyword("TURBULENCE_SIMPLEX2D", turbulenceType == TurbulenceType.Simplex2D, temporarySerializableMaterial);
		SetMaterialKeyword("TURBULENCE_SIMPLEX", turbulenceType == TurbulenceType.Simplex, temporarySerializableMaterial);
		SetMaterialKeyword("SOFTPARTICLES_ON", softParticles == SoftParticleType.NearClipAndCameraDepth, temporarySerializableMaterial);
		SetMaterialKeyword("SHAPE_SPHERE", shape == Shape.Sphere, temporarySerializableMaterial);
		SetMaterialKeyword("SHAPE_CYLINDER", shape == Shape.Cylinder, temporarySerializableMaterial);
	}
}
