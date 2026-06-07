using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace OutlineFx
{
	public class OutlineFxFeature : ScriptableRendererFeature
	{
		private class Pass : ScriptableRenderPass
		{
			public OutlineFxFeature _owner;

			private FilteringSettings _filtering;

			private RenderStateBlock _override;

			private RenderTarget _buffer;

			private RTHandle _output;

			public void Init()
			{
				base.renderPassEvent = _owner._event;
				_buffer = new RenderTarget().Allocate("_buffer");
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				CommandBuffer cmd = CommandBufferPool.Get("OutlineFxFeature");
				RenderTextureDescriptor desc = renderingData.cameraData.cameraTargetDescriptor;
				desc.colorFormat = RenderTextureFormat.ARGB32;
				_buffer.Get(cmd, in desc);
				if (_owner._outlineMat == null)
				{
					return;
				}
				_owner._outlineMat.SetFloat(s_Alpha, 0f);
				_owner._outlineMat.SetFloat(s_Solid, _owner._solid);
				if (_owner._solidMask._enabled)
				{
					SolidMask solidMask = _owner._solidMask;
					_owner._outlineMat.SetTexture(s_AlphaTex, solidMask._pattern);
					float num = 1f / (solidMask._velocity.x / 1000f);
					float num2 = 1f / (solidMask._velocity.y / 1000f);
					float z = ((solidMask._velocity.x == 0f) ? 0f : (Time.unscaledTime % num / num * solidMask._scale));
					float w = ((solidMask._velocity.y == 0f) ? 0f : (Time.unscaledTime % num2 / num2 * solidMask._scale));
					float num3 = (float)solidMask._pattern.width / (float)solidMask._pattern.height;
					_owner._outlineMat.SetVector(s_AlphaTO, new Vector4(solidMask._scale * ((float)Screen.width / (float)Screen.height) / num3, solidMask._scale, z, w));
				}
				_output = renderingData.cameraData.renderer.cameraColorTargetHandle;
				if (_owner._output.Enabled)
				{
					_output = _alloc(_owner._output.Value);
				}
				cmd.SetRenderTarget(_buffer.Handle.nameID);
				cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.clear, 1f);
				if (_owner._attachDepth)
				{
					RTHandle cameraDepthTargetHandle = renderingData.cameraData.renderer.cameraDepthTargetHandle;
					cmd.SetRenderTarget(_buffer.Handle, cameraDepthTargetHandle);
				}
				else
				{
					cmd.SetRenderTarget(_buffer.Handle);
				}
				context.ExecuteCommandBuffer(cmd);
				cmd.Clear();
				foreach (Outline renderer in _renderers)
				{
					if (!(renderer == null))
					{
						cmd.SetGlobalTexture(s_MainTex, renderer._renderer.sharedMaterial.mainTexture);
						cmd.SetGlobalColor(s_Color, renderer.Color);
						cmd.DrawRenderer(renderer._renderer, _owner._outlineMat, 0, 0);
					}
				}
				_renderers.Clear();
				cmd.SetGlobalVector(s_Step, _owner._step);
				_blit(_buffer.Handle, _output, _owner._outlineMat, 1);
				_execute();
				void _blit(RTHandle from, RTHandle to, Material mat, int pass = 0)
				{
					OutlineFxFeature._blit(cmd, from, to, mat, pass);
				}
				void _execute()
				{
					context.ExecuteCommandBuffer(cmd);
					CommandBufferPool.Release(cmd);
				}
			}

			public override void FrameCleanup(CommandBuffer cmd)
			{
				_buffer.Release(cmd);
				if (_owner._output.Enabled)
				{
					RTHandles.Release(_output);
				}
			}
		}

		public class RenderTarget
		{
			public RTHandle Handle;

			public int Id;

			private bool _allocated;

			public RenderTarget Allocate(RenderTexture rt, string name)
			{
				Handle = RTHandles.Alloc(rt, name);
				Id = Shader.PropertyToID(name);
				return this;
			}

			public RenderTarget Allocate(string name)
			{
				Handle = _alloc(name);
				Id = Shader.PropertyToID(name);
				return this;
			}

			public void Get(CommandBuffer cmd, in RenderTextureDescriptor desc)
			{
				_allocated = true;
				cmd.GetTemporaryRT(Id, desc);
			}

			public void Release(CommandBuffer cmd)
			{
				if (_allocated)
				{
					_allocated = false;
					cmd.ReleaseTemporaryRT(Id);
				}
			}
		}

		[Serializable]
		public class SolidMask
		{
			public bool _enabled;

			public Texture2D _pattern;

			public float _scale = 50f;

			public Vector2 _velocity = new Vector2(0f, 0f);
		}

		public enum Mode
		{
			Hard = 0,
			Soft = 1
		}

		public enum Filter
		{
			Cross = 0,
			Box = 1
		}

		private static readonly int s_Alpha = Shader.PropertyToID("_Alpha");

		private static readonly int s_MainTex = Shader.PropertyToID("_MainTex");

		private static readonly int s_Step = Shader.PropertyToID("_Step");

		private static readonly int s_Color = Shader.PropertyToID("_Color");

		private static readonly int s_Solid = Shader.PropertyToID("_Solid");

		private static readonly int s_AlphaTex = Shader.PropertyToID("_AlphaTex");

		private static readonly int s_AlphaTO = Shader.PropertyToID("_AlphaTO");

		private const string k_OutlineShader = "Hidden/OutlineFx/Main";

		private static readonly int s_MainTexId = Shader.PropertyToID("_MainTex");

		private static readonly int s_ColorId = Shader.PropertyToID("_Color");

		private static List<ShaderTagId> k_ShaderTags;

		private static Mesh k_ScreenMesh;

		[SerializeField]
		[Tooltip("When draw outline")]
		private RenderPassEvent _event = RenderPassEvent.AfterRenderingPostProcessing;

		[Range(0f, 1f)]
		[SerializeField]
		[Tooltip("Solid fill of outline")]
		private float _solid;

		[Range(0f, 1f)]
		[Tooltip("Outline thickness")]
		public float _thickness = 0.001f;

		[Range(0f, 1f)]
		[SerializeField]
		[Tooltip("Alpha cutout threshold for transparent objects")]
		private float _alphaCutout = 0.5f;

		[Tooltip("Edge filter")]
		public Mode _mode;

		[HideInInspector]
		public Filter _filter = Filter.Box;

		[HideInInspector]
		public bool _attachDepth = true;

		public Optional<string> _output = new Optional<string>("_globalTex", enabled: false);

		public SolidMask _solidMask = new SolidMask();

		[SerializeField]
		[HideInInspector]
		public Shader _shader;

		private Material _outlineMat;

		private Vector4 _step;

		private Pass _pass;

		private static List<Outline> _renderers = new List<Outline>();

		public static Mesh ScreenMesh => k_ScreenMesh;

		public float Solid
		{
			get
			{
				return _solid;
			}
			set
			{
				_solid = Mathf.Clamp01(value);
			}
		}

		public float Thickness
		{
			get
			{
				return _thickness;
			}
			set
			{
				_thickness = Mathf.Clamp01(value);
			}
		}

		public bool Mask
		{
			get
			{
				return _solidMask._enabled;
			}
			set
			{
				if (_solidMask._enabled != value)
				{
					_solidMask._enabled = value;
					if (_solidMask._enabled)
					{
						_outlineMat.EnableKeyword("ALPHA_MASK");
					}
					else
					{
						_outlineMat.DisableKeyword("ALPHA_MASK");
					}
				}
			}
		}

		public override void Create()
		{
			_pass = new Pass
			{
				_owner = this
			};
			_pass.Init();
			_renderers.Clear();
			_validateContent();
			_validateMaterial();
			if (k_ScreenMesh == null)
			{
				k_ScreenMesh = new Mesh();
				_initScreenMesh(k_ScreenMesh, Matrix4x4.identity);
			}
			if (k_ShaderTags == null)
			{
				k_ShaderTags = new List<ShaderTagId>(new ShaderTagId[3]
				{
					new ShaderTagId("SRPDefaultUnlit"),
					new ShaderTagId("UniversalForward"),
					new ShaderTagId("UniversalForwardOnly")
				});
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if ((renderingData.cameraData.cameraType == CameraType.Game || renderingData.cameraData.cameraType == CameraType.SceneView) && _renderers.Count != 0)
			{
				float num = (float)Screen.width / (float)Screen.height;
				_step.x = _thickness / num;
				_step.y = _thickness;
				_step *= 0.007f;
				if (_mode == Mode.Soft)
				{
					_step *= 2f;
				}
				renderer.EnqueuePass(_pass);
			}
		}

		public static void Render(Outline inst)
		{
			_renderers.Add(inst);
		}

		private void _validateMaterial()
		{
			_outlineMat = new Material(_shader);
			switch (_mode)
			{
			case Mode.Soft:
				_outlineMat.EnableKeyword("SOFT");
				break;
			case Mode.Hard:
				_outlineMat.EnableKeyword("HARD");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			switch (_filter)
			{
			case Filter.Cross:
				_outlineMat.EnableKeyword("CROSS");
				break;
			case Filter.Box:
				_outlineMat.EnableKeyword("BOX");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (_solidMask._enabled)
			{
				_outlineMat.EnableKeyword("ALPHA_MASK");
			}
		}

		private void _validateContent()
		{
		}

		private static void _initScreenMesh(Mesh mesh, Matrix4x4 mat)
		{
			mesh.vertices = _verts(0f);
			mesh.uv = _texCoords();
			mesh.triangles = new int[3] { 0, 1, 2 };
			mesh.UploadMeshData(markNoLongerReadable: true);
			static Vector2[] _texCoords()
			{
				Vector2[] array = new Vector2[3];
				for (int i = 0; i < 3; i++)
				{
					if (SystemInfo.graphicsUVStartsAtTop)
					{
						array[i] = new Vector2((i << 1) & 2, 1f - (float)(i & 2));
					}
					else
					{
						array[i] = new Vector2((i << 1) & 2, i & 2);
					}
				}
				return array;
			}
			Vector3[] _verts(float z)
			{
				Vector3[] array = new Vector3[3];
				for (int i = 0; i < 3; i++)
				{
					Vector2 vector = new Vector2((i << 1) & 2, i & 2);
					array[i] = mat.MultiplyPoint(new Vector3(vector.x * 2f - 1f, vector.y * 2f - 1f, z));
				}
				return array;
			}
		}

		private static void _blit(CommandBuffer cmd, RTHandle from, RTHandle to, Material mat, int pass = 0)
		{
			cmd.SetGlobalTexture(s_MainTexId, from.nameID);
			cmd.SetRenderTarget(to.nameID);
			cmd.DrawMesh(k_ScreenMesh, Matrix4x4.identity, mat, 0, pass);
		}

		private static RTHandle _alloc(string id)
		{
			return RTHandles.Alloc(id, id);
		}
	}
}
