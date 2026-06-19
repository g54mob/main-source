using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public sealed class FogOfWarRenderer : PostProcessEffectRenderer<FogOfWarSettings>
	{
		private Material _material;

		private Mesh _quadMesh;

		private string _sampleName = "FogOfWarRenderer";

		private int _desaturation_ID;

		private int _brightness_ID;

		private int _levelFogOfWar_ID;

		private int _quadSize_ID;

		private int _minMaxDistance_ID;

		private int _levelFogOfWar_ST;

		public override void Init()
		{
			base.Init();
			_material = new Material(Shader.Find("Hidden/Fog Of War"));
			_quadMesh = MeshUtils.CreatePlaneMesh();
			_desaturation_ID = Shader.PropertyToID("_Desaturation");
			_brightness_ID = Shader.PropertyToID("_Brightness");
			_levelFogOfWar_ID = Shader.PropertyToID("_LevelFogOfWar");
			_quadSize_ID = Shader.PropertyToID("_QuadSize");
			_minMaxDistance_ID = Shader.PropertyToID("_MinMaxDistance");
			_levelFogOfWar_ST = Shader.PropertyToID("_LevelFogOfWar_ST");
		}

		public override void Release()
		{
			if (_material != null)
			{
				Object.Destroy(_material);
			}
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			context.command.BeginSample(_sampleName);
			FogOfWarLevelTextureDefinition fogOfWarLevelTextureDefinition = PostProcessingRendererProxy.Instance?.PostProcessRendererData?.FogOfWarDefinition;
			if (fogOfWarLevelTextureDefinition == null)
			{
				context.command.BlitFullscreenTriangle(context.source, context.destination);
				context.command.EndSample(_sampleName);
				return;
			}
			float num = fogOfWarLevelTextureDefinition.MaxDistance;
			float num2 = (float)base.settings.quadScale * 0.5f / (float)fogOfWarLevelTextureDefinition.TileWidth;
			float num3 = (float)base.settings.quadScale * 0.5f / (float)fogOfWarLevelTextureDefinition.TileHeight;
			Vector4 value = new Vector4(num2, num3, 0.5f * (1f - num2), 0.5f * (1f - num3));
			value.z += 0.5f / (float)fogOfWarLevelTextureDefinition.TileWidth;
			value.w += 0.5f / (float)fogOfWarLevelTextureDefinition.TileHeight;
			_material.SetVector(_levelFogOfWar_ST, value);
			_material.SetVector(_minMaxDistance_ID, new Vector2((float)(int)base.settings.startFadeDistance / num, (float)(int)base.settings.endFadeDistance / num));
			_material.SetFloat(_desaturation_ID, base.settings.desaturation);
			_material.SetFloat(_brightness_ID, base.settings.brightness);
			_material.SetFloat(_quadSize_ID, base.settings.quadScale);
			_material.SetTexture(_levelFogOfWar_ID, fogOfWarLevelTextureDefinition.FogOfWarTexture);
			context.command.SetViewProjectionMatrices(context.camera.worldToCameraMatrix, context.camera.projectionMatrix);
			context.command.SetRenderTarget(context.destination);
			context.command.DrawMesh(_quadMesh, Matrix4x4.Rotate(Quaternion.Euler(90f, 0f, 0f)) * Matrix4x4.Scale(Vector3.one * base.settings.quadScale), _material, 0, 0);
			context.command.EndSample(_sampleName);
		}
	}
}
