using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Restory.Constants;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathBacklight : MonoBehaviour
	{
		[SerializeField]
		private SonicBathMaterialsHandler materialsHandler;

		[SerializeField]
		[Min(0.1f)]
		private float dimDuration = 1.2f;

		[SerializeField]
		private Ease dimEase = Ease.Linear;

		private TweenSequencesService tweenSequences;

		private Sequence dimSequence;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		public void TurnOn()
		{
			DimBacklight(1f);
		}

		public void TurnOff()
		{
			DimBacklight(0f);
		}

		private void DimBacklight(float targetValue)
		{
			if (dimSequence != null)
			{
				tweenSequences.Kill(dimSequence);
				dimSequence = null;
			}
			Material waterMaterial = materialsHandler.WaterMaterialInstance;
			int emissionProperty = ProjectConstants.MaterialProperties.Emission;
			TweenerCore<float, float, FloatOptions> t = DOTween.To(() => waterMaterial.GetFloat(emissionProperty), delegate(float emission)
			{
				waterMaterial.SetFloat(emissionProperty, emission);
			}, targetValue, dimDuration).SetEase(dimEase);
			Material uvMaterial = materialsHandler.EnvironmentSonicBathUVMaterialInstance;
			int colorProperty = ProjectConstants.MaterialProperties.Color;
			TweenerCore<float, float, FloatOptions> t2 = DOTween.To(() => uvMaterial.GetColor(colorProperty).a, delegate(float alpha)
			{
				Color color = uvMaterial.GetColor(colorProperty);
				color.a = alpha;
				uvMaterial.SetColor(colorProperty, color);
			}, targetValue, dimDuration).SetEase(dimEase);
			dimSequence = tweenSequences.Create();
			dimSequence.Append(t);
			dimSequence.Join(t2);
		}
	}
}
