using System.Collections;
using Restory.Data.Soldering;
using Restory.Infrastructure.ProjectServices;
using UnityEngine;

namespace Restory.Gameplay.Soldering
{
	public class DisappearingTraceCoroutineHandler
	{
		private DisappearingTraceTransitionSettings settings;

		private SolderTrace solderTrace;

		private ICoroutineRunner coroutineRunner;

		private Material materialInstance;

		private Coroutine coroutine;

		public DisappearingTraceCoroutineHandler(DisappearingTraceTransitionSettings settings, SolderTrace solderTrace, ICoroutineRunner coroutineRunner)
		{
			this.settings = settings;
			this.solderTrace = solderTrace;
			this.coroutineRunner = coroutineRunner;
			materialInstance = new Material(settings.DisappearingMaterial);
			solderTrace.OverrideMaterial(materialInstance);
			coroutine = coroutineRunner.Run(DisappearingTraceCoroutine());
		}

		public void Clear()
		{
			if (coroutine != null)
			{
				coroutineRunner.Stop(coroutine);
				CompleteDisappearingTrace();
			}
		}

		private IEnumerator DisappearingTraceCoroutine()
		{
			yield return MaterialTransitionCoroutine();
			float duration = Mathf.Max(0f, settings.DisappearingDurationInSeconds);
			if (duration <= 0f)
			{
				CompleteDisappearingTrace();
				yield break;
			}
			float elapsed = 0f;
			while (elapsed < duration)
			{
				elapsed += Time.deltaTime;
				float num = Mathf.Clamp01(elapsed / duration);
				SetDisappearingMaterialAlpha(materialInstance, 1f - num);
				yield return null;
			}
			CompleteDisappearingTrace();
		}

		private IEnumerator MaterialTransitionCoroutine()
		{
			float duration = Mathf.Max(0f, settings.TransformationDurationInSeconds);
			float initialMetallic = GetMaterialFloat(materialInstance, settings.MetallicProperty);
			float initialNoiseOpacity = GetMaterialFloat(materialInstance, settings.NoiseOpacityProperty);
			float initialNoiseTile = GetMaterialFloat(materialInstance, settings.NoiseTileProperty);
			float initialNormalTile = GetMaterialFloat(materialInstance, settings.NormalTileProperty);
			float initialNormalSpeed = GetMaterialFloat(materialInstance, settings.NormalSpeedProperty);
			if (duration <= 0f)
			{
				SetMaterialFloat(materialInstance, settings.MetallicProperty, settings.MetallicTarget);
				SetMaterialFloat(materialInstance, settings.NoiseOpacityProperty, settings.NoiseOpacityTarget);
				SetMaterialFloat(materialInstance, settings.NoiseTileProperty, settings.NoiseTileTarget);
				SetMaterialFloat(materialInstance, settings.NormalTileProperty, settings.NormalTileTarget);
				SetMaterialFloat(materialInstance, settings.NormalSpeedProperty, settings.NormalSpeedTarget);
				yield break;
			}
			float elapsed = 0f;
			while (elapsed < duration)
			{
				elapsed += Time.deltaTime;
				float t = Mathf.Clamp01(elapsed / duration);
				SetMaterialFloat(materialInstance, settings.MetallicProperty, Mathf.Lerp(initialMetallic, settings.MetallicTarget, t));
				SetMaterialFloat(materialInstance, settings.NoiseOpacityProperty, Mathf.Lerp(initialNoiseOpacity, settings.NoiseOpacityTarget, t));
				SetMaterialFloat(materialInstance, settings.NoiseTileProperty, Mathf.Lerp(initialNoiseTile, settings.NoiseTileTarget, t));
				SetMaterialFloat(materialInstance, settings.NormalTileProperty, Mathf.Lerp(initialNormalTile, settings.NormalTileTarget, t));
				SetMaterialFloat(materialInstance, settings.NormalSpeedProperty, Mathf.Lerp(initialNormalSpeed, settings.NormalSpeedTarget, t));
				yield return null;
			}
			SetMaterialFloat(materialInstance, settings.MetallicProperty, settings.MetallicTarget);
			SetMaterialFloat(materialInstance, settings.NoiseOpacityProperty, settings.NoiseOpacityTarget);
			SetMaterialFloat(materialInstance, settings.NoiseTileProperty, settings.NoiseTileTarget);
			SetMaterialFloat(materialInstance, settings.NormalTileProperty, settings.NormalTileTarget);
			SetMaterialFloat(materialInstance, settings.NormalSpeedProperty, settings.NormalSpeedTarget);
		}

		private void CompleteDisappearingTrace()
		{
			if (coroutine != null)
			{
				coroutine = null;
				settings = null;
				coroutineRunner = null;
				if ((bool)solderTrace)
				{
					solderTrace.Hide();
					solderTrace = null;
				}
				DestroyMaterial(materialInstance);
				materialInstance = null;
			}
		}

		private void SetDisappearingMaterialAlpha(Material materialInstance, float alpha)
		{
			float a = Mathf.Clamp01(alpha);
			Color color = materialInstance.GetColor(settings.BaseColorProperty);
			color.a = a;
			materialInstance.SetColor(settings.BaseColorProperty, color);
		}

		private static float GetMaterialFloat(Material material, int propertyId)
		{
			if (!material || !material.HasProperty(propertyId))
			{
				return 0f;
			}
			return material.GetFloat(propertyId);
		}

		private static void SetMaterialFloat(Material material, int propertyId, float value)
		{
			if ((bool)material && material.HasProperty(propertyId))
			{
				material.SetFloat(propertyId, value);
			}
		}

		private static void DestroyMaterial(Material material)
		{
			if ((bool)material)
			{
				Object.Destroy(material);
			}
		}
	}
}
