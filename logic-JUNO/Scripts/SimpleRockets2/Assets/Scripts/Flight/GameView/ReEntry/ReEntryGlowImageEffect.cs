using Assets.Scripts.DebugScripts;
using ModApi;
using ModApi.Cameras;
using ModApi.Craft;
using ModApi.Packages.FastNoise;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;
using Vectrosity;

namespace Assets.Scripts.Flight.GameView.ReEntry
{
	[RequireComponent(typeof(Camera))]
	public class ReEntryGlowImageEffect : MonoBehaviour
	{
		private struct ShaderPropertyIds
		{
			public int BloomDirection;

			public int EffectMaskTex;

			public int Filter;

			public int ReentryBloomScale;

			public int ReentryIntensity;

			public int ReEntryTint;

			public int SourceTex;

			public int VaporBloomScale;

			public int VaporIntensity;

			public int VaporTint;

			public void Init()
			{
				EffectMaskTex = Shader.PropertyToID("_effectMaskTex");
				Filter = Shader.PropertyToID("_Filter");
				ReentryIntensity = Shader.PropertyToID("_reentryIntensity");
				VaporIntensity = Shader.PropertyToID("_vaporIntensity");
				BloomDirection = Shader.PropertyToID("_bloomDirection");
				SourceTex = Shader.PropertyToID("_SourceTex");
				ReEntryTint = Shader.PropertyToID("_reEntryTint");
				VaporTint = Shader.PropertyToID("_vaporTint");
				ReentryBloomScale = Shader.PropertyToID("_reentryBloomScale");
				VaporBloomScale = Shader.PropertyToID("_vaporBloomScale");
			}
		}

		private const int ApplyBloomPass = 3;

		private const int BoxDownPass = 1;

		private const int BoxDownPrefilterPass = 0;

		private const int BoxUpPass = 2;

		private const string DebugGroup = "Debug";

		private const string DirectionalBloomGroup = "DirectionalBloom";

		private const string MaskApplicationGroup = "MaskApplication";

		private const string MaskCreationGroup = "MaskCreation";

		[SerializeField]
		private readonly string _maskSettingsMessage = "Mask creation settings can be modified directly on the part material at runtime to see immediate effects. To keep any mask creation settings, make sure they are set on the default part materials in the resources folder.";

		private Material _bloom;

		[SerializeField]
		private Vector2 _bloomScreenDir;

		[SerializeField]
		private Shader _bloomShader;

		private ISceneCamera _camera;

		[Range(0f, 10f)]
		[SerializeField]
		private float _intensityReentry = 1f;

		[Range(0f, 10f)]
		[SerializeField]
		private float _intensityVapor = 1f;

		[Range(1f, 16f)]
		[SerializeField]
		private int _iterations = 4;

		[SerializeField]
		[Range(0f, 1f)]
		private float _lengthScaleClose = 0.25f;

		[SerializeField]
		[Range(0f, 50f)]
		private float _lengthScaleFar = 10f;

		private Material _maskApplicationMaterial;

		private IFastNoise _noise;

		[SerializeField]
		[Range(0f, 50f)]
		private float _reentryBloomScale = 2f;

		[SerializeField]
		private Shader _reentryEffectShader;

		[SerializeField]
		private Color _reentryTint = Color.yellow;

		private VectorLine _screenLine;

		private ShaderPropertyIds _shaderProps;

		[SerializeField]
		private bool _showTextures;

		[SerializeField]
		private bool _showVelocityLines;

		[Range(0f, 1f)]
		[SerializeField]
		private float _softThreshold = 0.5f;

		private RenderTexture[] _textures = new RenderTexture[16];

		[Range(0f, 10f)]
		[SerializeField]
		private float _threshold = 1f;

		[SerializeField]
		private bool _useDirectionalBloom = true;

		[SerializeField]
		[Range(0f, 50f)]
		private float _vaporBloomScale = 5f;

		[SerializeField]
		private Color _vaporTint = Color.white;

		public void ApplyDirectionalBloom(Vector2 screenBloomDirection, RenderTexture source, RenderTexture destination)
		{
			if (_bloom == null)
			{
				_bloom = new Material(_bloomShader);
				_bloom.hideFlags = HideFlags.HideAndDontSave;
			}
			float num = _threshold * _softThreshold;
			Vector4 value = default(Vector4);
			value.x = _threshold;
			value.y = value.x - num;
			value.z = 2f * num;
			value.w = 0.25f / (num + 1E-05f);
			_bloom.SetVector(_shaderProps.Filter, value);
			_bloom.SetFloat(_shaderProps.ReentryIntensity, Mathf.GammaToLinearSpace(_intensityReentry * Mathf.Clamp01(FlightSceneScript.Instance.CraftNode.CraftScript.FlightData.MachNumber - 1f)));
			_bloom.SetFloat(_shaderProps.VaporIntensity, Mathf.GammaToLinearSpace(_intensityVapor));
			_bloom.SetVector(_shaderProps.BloomDirection, screenBloomDirection);
			int num2 = source.width / 2;
			int num3 = source.height / 2;
			RenderTextureFormat format = source.format;
			RenderTexture renderTexture = (_textures[0] = RenderTexture.GetTemporary(num2, num3, 0, format));
			renderTexture.name = "ReentryEffects_Bloom";
			Graphics.Blit(source, renderTexture, _bloom, 0);
			RenderTexture renderTexture2 = renderTexture;
			int i;
			for (i = 1; i < _iterations; i++)
			{
				num2 /= 2;
				num3 /= 2;
				if (num3 < 2)
				{
					break;
				}
				renderTexture = (_textures[i] = RenderTexture.GetTemporary(num2, num3, 0, format));
				renderTexture.name = "ReentryEffects_BloomIteration";
				Graphics.Blit(renderTexture2, renderTexture, _bloom, 1);
				renderTexture2 = renderTexture;
			}
			for (i -= 2; i >= 0; i--)
			{
				renderTexture = _textures[i];
				_textures[i] = null;
				Graphics.Blit(renderTexture2, renderTexture, _bloom, 2);
				RenderTexture.ReleaseTemporary(renderTexture2);
				renderTexture2 = renderTexture;
			}
			_bloom.SetTexture(_shaderProps.SourceTex, source);
			Graphics.Blit(renderTexture2, destination, _bloom, 3);
			RenderTexture.ReleaseTemporary(renderTexture2);
		}

		protected virtual void OnDestroy()
		{
			if (_bloom != null)
			{
				Object.Destroy(_bloom);
				_bloom = null;
			}
			if (_maskApplicationMaterial != null)
			{
				Object.Destroy(_maskApplicationMaterial);
				_maskApplicationMaterial = null;
			}
			_noise?.Dispose();
			_noise = null;
		}

		private void ApplyReentryQualitySettings(ImageEffectsQualitySettings.ReEntryQuality reentryQuality)
		{
			base.enabled = reentryQuality != ImageEffectsQualitySettings.ReEntryQuality.Off;
		}

		private void Awake()
		{
			_camera = GetComponent<ISceneCamera>();
			_maskApplicationMaterial = new Material(_reentryEffectShader);
			_shaderProps.Init();
			_noise = FastNoise.CreatePerlinNoise(Random.Range(int.MinValue, int.MaxValue), 0.10000000149011612);
			_screenLine = VectorLine.SetLine(Color.white, Vector2.zero, Vector2.zero);
			EnumSetting<ImageEffectsQualitySettings.ReEntryQuality> reEntry = Game.Instance.QualitySettings.ImageEffects.ReEntry;
			reEntry.Changed += ReentryQualityChanged;
			ApplyReentryQualitySettings(reEntry);
		}

		private Vector2 CalculateScreenBlurDirection()
		{
			ICraftNode craftNode = FlightSceneScript.Instance.CraftNode;
			Vector3 framePosition = craftNode.FramePosition;
			Camera camera = _camera.Camera;
			Vector3 position = framePosition + craftNode.CraftScript.SurfaceVelocity.normalized;
			Vector3 vector = Utilities.GameWorldToScreenPoint(camera, framePosition);
			Vector3 vector2 = Utilities.GameWorldToScreenPoint(camera, position);
			if (vector2.z < 0f && vector.z > 0f)
			{
				vector2 *= -1f;
				vector *= -1f;
			}
			_bloomScreenDir = vector2 - vector;
			if (_bloomScreenDir.magnitude > 50f)
			{
				_bloomScreenDir = _bloomScreenDir.normalized * 50f;
			}
			float num = Vector3.Distance(_camera.Camera.transform.position, framePosition);
			float num2 = Mathf.Lerp(_lengthScaleClose, _lengthScaleFar, num / 2000f);
			float num3 = Mathf.Abs((float)_noise.GetNoise(framePosition.x, framePosition.y, framePosition.z) / 2.5f) * num2;
			num2 += num3;
			Vector2 result = _bloomScreenDir * num2;
			if (_showVelocityLines)
			{
				DebugGizmos.DrawRay("Velocity", framePosition, craftNode.CraftScript.SurfaceVelocity.normalized, 2f, Color.red).lineWidth = 4f;
				_screenLine.points2.Clear();
				_screenLine.points2.Add(vector);
				_screenLine.points2.Add((Vector2)vector + _bloomScreenDir * 5f);
				_screenLine.Draw();
			}
			return result;
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			int width = source.width;
			int height = source.height;
			RenderTextureFormat format = source.format;
			RenderTexture renderTextureCraftMask = _camera.MasterCamera.RenderTextureCraftMask;
			RenderTexture renderTexture = null;
			if (_useDirectionalBloom)
			{
				renderTexture = RenderTexture.GetTemporary(width, height, 0, format);
				renderTexture.name = "ReentryEffects_DirectionalBloomedTexture";
				Vector2 screenBloomDirection = CalculateScreenBlurDirection();
				ApplyDirectionalBloom(screenBloomDirection, renderTextureCraftMask, renderTexture);
				_maskApplicationMaterial.SetTexture(_shaderProps.EffectMaskTex, renderTexture);
			}
			else
			{
				_maskApplicationMaterial.SetTexture(_shaderProps.EffectMaskTex, renderTextureCraftMask);
			}
			_maskApplicationMaterial.SetColor(_shaderProps.ReEntryTint, _reentryTint);
			_maskApplicationMaterial.SetColor(_shaderProps.VaporTint, _vaporTint);
			_maskApplicationMaterial.SetFloat(_shaderProps.ReentryBloomScale, _reentryBloomScale);
			_maskApplicationMaterial.SetFloat(_shaderProps.VaporBloomScale, _vaporBloomScale);
			Graphics.Blit(source, destination, _maskApplicationMaterial);
			if (_showTextures)
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, Screen.width, Screen.height, 0f);
				Graphics.DrawTexture(new Rect(0f, 0f, 512f, 512f), renderTextureCraftMask);
				if (renderTexture != null)
				{
					Graphics.DrawTexture(new Rect(0f, 512f, 512f, 512f), renderTexture);
				}
				GL.PopMatrix();
			}
			if (renderTexture != null)
			{
				RenderTexture.ReleaseTemporary(renderTexture);
			}
			renderTextureCraftMask.DiscardContents();
		}

		private void ReentryQualityChanged(object sender, SettingChangedEventArgs<ImageEffectsQualitySettings.ReEntryQuality> e)
		{
			ApplyReentryQualitySettings(e.Setting);
		}
	}
}
