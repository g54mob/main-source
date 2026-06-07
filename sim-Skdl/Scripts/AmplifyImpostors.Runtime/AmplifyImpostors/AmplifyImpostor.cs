using System;
using System.Collections.Generic;
using UnityEngine;

namespace AmplifyImpostors
{
	public class AmplifyImpostor : MonoBehaviour
	{
		public const string PresetBiRP = "e4786beb7716da54dbb02a632681cc37";

		public const string ShaderBiRP = "e82933f4c0eb9ba42aab0739f48efe21";

		public const string ShaderOctaBiRP = "572f9be5706148142b8da6e9de53acdb";

		public const string PresetHDRP = "47b6b3dcefe0eaf4997acf89caf8c75e";

		public const string ShaderHDRP = "175c951fec709c44fa2f26b8ab78b8dd";

		public const string ShaderOctaHDRP = "56236dc63ad9b7949b63a27f0ad180b3";

		public const string PresetURP = "0403878495ffa3c4e9d4bcb3eac9b559";

		public const string ShaderOctaURP = "83dd8de9a5c14874884f9012def4fdcc";

		public const string ShaderURP = "da79d698f4bf0164e910ad798d07efdf";

		public const string DilateGUID = "57c23892d43bc9f458360024c5985405";

		public const string PackerGUID = "31bd3cd74692f384a916d9d7ea87710d";

		public static readonly int _DetailNormalMap_PID;

		[SerializeField]
		private AmplifyImpostorAsset m_data;

		[SerializeField]
		private Transform m_rootTransform;

		[SerializeField]
		private LODGroup m_lodGroup;

		[SerializeField]
		private Renderer[] m_renderers;

		public LODReplacement m_lodReplacement;

		[SerializeField]
		public RenderPipelineInUse m_renderPipelineInUse;

		public int m_insertIndex;

		[SerializeField]
		public GameObject m_lastImpostor;

		[SerializeField]
		public string m_folderPath;

		[NonSerialized]
		public string m_impostorName;

		[SerializeField]
		public CutMode m_cutMode;

		[NonSerialized]
		private const float StartXRotation = -90f;

		[NonSerialized]
		private const float StartYRotation = 90f;

		[NonSerialized]
		private const int MinAlphaResolution = 256;

		[NonSerialized]
		private RenderTexture[] m_rtGBuffers;

		[NonSerialized]
		private RenderTexture[] m_alphaGBuffers;

		[NonSerialized]
		private RenderTexture m_trueDepth;

		[NonSerialized]
		public Texture2D m_alphaTex;

		[NonSerialized]
		private float m_xyFitSize;

		[NonSerialized]
		private float m_depthFitSize;

		[NonSerialized]
		private Vector2 m_pixelOffset;

		[NonSerialized]
		private Bounds m_originalBound;

		[NonSerialized]
		private Vector3 m_oriPos;

		[NonSerialized]
		private Quaternion m_oriRot;

		[NonSerialized]
		private Vector3 m_oriSca;

		[NonSerialized]
		private const int BlockSize = 65536;

		public AmplifyImpostorAsset Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform RootTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LODGroup LodGroup
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Renderer[] Renderers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void GenerateTextures(List<TextureOutput> outputList, bool standardRendering)
		{
		}

		private void GenerateAlphaTextures(List<TextureOutput> outputList)
		{
		}

		private void ClearBuffers()
		{
		}

		private void ClearAlphaBuffers()
		{
		}

		public void RenderImpostor(ImpostorType impostorType, int targetAmount, bool impostorMaps = true, bool combinedAlphas = false, bool useMinResolution = false, Shader customShader = null)
		{
		}

		private Matrix4x4 GetCameraRotationMatrix(ImpostorType impostorType, int hframes, int vframes, int x, int y)
		{
			return default(Matrix4x4);
		}

		private Vector3 OctahedronToVector(Vector2 oct)
		{
			return default(Vector3);
		}

		private Vector3 OctahedronToVector(float x, float y)
		{
			return default(Vector3);
		}

		private Vector3 HemiOctahedronToVector(float x, float y)
		{
			return default(Vector3);
		}

		public void GenerateAutomaticMesh(AmplifyImpostorAsset data)
		{
		}

		public Mesh GenerateMesh(Vector2[] points, Vector3 offset, float width = 1f, float height = 1f, bool invertY = true)
		{
			return null;
		}
	}
}
