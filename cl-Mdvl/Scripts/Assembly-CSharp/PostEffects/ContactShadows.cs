using UnityEngine;
using UnityEngine.Rendering;

namespace PostEffects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public sealed class ContactShadows : MonoBehaviour
	{
		[SerializeField]
		private Light _light;

		[SerializeField]
		[Range(0f, 5f)]
		private float _rejectionDepth = 0.5f;

		[SerializeField]
		[Range(4f, 32f)]
		private int _sampleCount = 16;

		[SerializeField]
		[Range(0f, 1f)]
		private float _temporalFilter = 0.5f;

		[SerializeField]
		private bool _downsample;

		[SerializeField]
		[HideInInspector]
		private Shader _shader;

		[SerializeField]
		[HideInInspector]
		private NoiseTextureSet _noiseTextures;

		private Material _material;

		private RenderTexture _prevMaskRT1;

		private RenderTexture _prevMaskRT2;

		private CommandBuffer _command1;

		private CommandBuffer _command2;

		private Matrix4x4 _previousVP = Matrix4x4.identity;

		public float RejectionDepth
		{
			get
			{
				return _rejectionDepth;
			}
			set
			{
				_rejectionDepth = Mathf.Clamp(value, 0f, 5f);
			}
		}

		private void OnDestroy()
		{
			if (_material != null)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(_material);
				}
				else
				{
					Object.DestroyImmediate(_material);
				}
			}
			if (_prevMaskRT1 != null)
			{
				RenderTexture.ReleaseTemporary(_prevMaskRT1);
			}
			if (_prevMaskRT2 != null)
			{
				RenderTexture.ReleaseTemporary(_prevMaskRT2);
			}
			if (_command1 != null)
			{
				_command1.Release();
			}
			if (_command2 != null)
			{
				_command2.Release();
			}
		}

		private void OnPreCull()
		{
			UpdateTempObjects();
			if (_light != null)
			{
				BuildCommandBuffer();
				_light.AddCommandBuffer(LightEvent.AfterScreenspaceMask, _command1);
				_light.AddCommandBuffer(LightEvent.AfterScreenspaceMask, _command2);
			}
		}

		private void OnPreRender()
		{
			if (_light != null)
			{
				_light.RemoveCommandBuffer(LightEvent.AfterScreenspaceMask, _command1);
				_light.RemoveCommandBuffer(LightEvent.AfterScreenspaceMask, _command2);
				_command1.Clear();
				_command2.Clear();
			}
		}

		private void Update()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private static Matrix4x4 CalculateVPMatrix()
		{
			Camera current = Camera.current;
			Matrix4x4 nonJitteredProjectionMatrix = current.nonJitteredProjectionMatrix;
			Matrix4x4 worldToCameraMatrix = current.worldToCameraMatrix;
			return GL.GetGPUProjectionMatrix(nonJitteredProjectionMatrix, renderIntoTexture: true) * worldToCameraMatrix;
		}

		private Vector2Int GetScreenSize()
		{
			Camera current = Camera.current;
			int num = ((!_downsample) ? 1 : 2);
			return new Vector2Int(current.pixelWidth / num, current.pixelHeight / num);
		}

		private void UpdateTempObjects()
		{
			if (_prevMaskRT2 != null)
			{
				RenderTexture.ReleaseTemporary(_prevMaskRT2);
				_prevMaskRT2 = null;
			}
			if (!(_light == null))
			{
				if (_material == null)
				{
					_material = new Material(_shader);
					_material.hideFlags = HideFlags.DontSave;
				}
				if (_command1 == null)
				{
					_command1 = new CommandBuffer();
					_command2 = new CommandBuffer();
					_command1.name = "Contact Shadow Ray Tracing";
					_command2.name = "Contact Shadow Temporal Filter";
				}
				else
				{
					_command1.Clear();
					_command2.Clear();
				}
				_material.SetFloat("_RejectionDepth", _rejectionDepth);
				_material.SetInt("_SampleCount", _sampleCount);
				float value = Mathf.Pow(1f - _temporalFilter, 2f);
				_material.SetFloat("_Convergence", value);
				_material.SetVector("_LightVector", base.transform.InverseTransformDirection(-_light.transform.forward) * _light.shadowBias / ((float)_sampleCount - 1.5f));
				Texture2D texture = _noiseTextures.GetTexture();
				Vector2 vector = (Vector2)GetScreenSize() / (float)texture.width;
				_material.SetVector("_NoiseScale", vector);
				_material.SetTexture("_NoiseTex", texture);
				_material.SetMatrix("_Reprojection", _previousVP * base.transform.localToWorldMatrix);
				_previousVP = CalculateVPMatrix();
			}
		}

		private void BuildCommandBuffer()
		{
			Vector2Int screenSize = GetScreenSize();
			RenderTextureFormat format = RenderTextureFormat.R8;
			RenderTexture temporary = RenderTexture.GetTemporary(screenSize.x, screenSize.y, 0, format);
			temporary.name = "[temp] ContactShadows.tempMaskRT";
			if (_temporalFilter == 0f)
			{
				_command1.SetGlobalTexture(Shader.PropertyToID("_ShadowMask"), BuiltinRenderTextureType.CurrentActive);
				_command1.SetRenderTarget(temporary);
				_command1.DrawProcedural(Matrix4x4.identity, _material, 0, MeshTopology.Triangles, 3);
			}
			else
			{
				int num = Shader.PropertyToID("_UnfilteredMask");
				_command1.SetGlobalTexture(Shader.PropertyToID("_ShadowMask"), BuiltinRenderTextureType.CurrentActive);
				_command1.GetTemporaryRT(num, screenSize.x, screenSize.y, 0, FilterMode.Point, format);
				_command1.SetRenderTarget(num);
				_command1.DrawProcedural(Matrix4x4.identity, _material, 0, MeshTopology.Triangles, 3);
				_command1.SetGlobalTexture(Shader.PropertyToID("_PrevMask"), _prevMaskRT1);
				_command1.SetRenderTarget(temporary);
				_command1.DrawProcedural(Matrix4x4.identity, _material, 1 + (Time.frameCount & 1), MeshTopology.Triangles, 3);
			}
			if (_downsample)
			{
				_command2.SetGlobalTexture(Shader.PropertyToID("_TempMask"), temporary);
				_command2.DrawProcedural(Matrix4x4.identity, _material, 3, MeshTopology.Triangles, 3);
			}
			else
			{
				_command2.Blit(temporary, BuiltinRenderTextureType.CurrentActive);
			}
			_prevMaskRT2 = _prevMaskRT1;
			_prevMaskRT1 = temporary;
		}
	}
}
