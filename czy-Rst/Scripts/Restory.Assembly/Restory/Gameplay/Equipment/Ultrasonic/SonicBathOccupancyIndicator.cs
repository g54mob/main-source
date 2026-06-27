using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Restory.Constants;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathOccupancyIndicator : MonoBehaviour
	{
		[SerializeField]
		private SonicBathMaterialsHandler materialsHandler;

		[SerializeField]
		[Min(1f)]
		private int capacity = 3;

		[SerializeField]
		[Min(0.1f)]
		private float warningFlashHalfDuration = 0.4f;

		[SerializeField]
		private Ease warningFlashEase = Ease.InOutSine;

		private TweenSequencesService tweenSequences;

		private Sequence warningSequence;

		public int Capacity => capacity;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		public void SetFilledCount(int filledCount)
		{
			int num = Mathf.Clamp(filledCount, 0, Capacity);
			materialsHandler.AnimationLightsMaterialInstance.SetFloat(ProjectConstants.MaterialProperties.Number, num);
		}

		public void PlayWarningIndication()
		{
			if (warningSequence != null)
			{
				tweenSequences.Kill(warningSequence);
				ResolveWarningIndicationComplete();
			}
			Material material = materialsHandler.AnimationLightsMaterialInstance;
			int property = ProjectConstants.MaterialProperties.ErrorIntensity;
			TweenerCore<float, float, FloatOptions> t = DOTween.To(() => material.GetFloat(property), delegate(float intensity)
			{
				material.SetFloat(property, intensity);
			}, 1f, warningFlashHalfDuration).SetLoops(4, LoopType.Yoyo).SetEase(warningFlashEase);
			warningSequence = tweenSequences.Create();
			warningSequence.Append(t).OnComplete(ResolveWarningIndicationComplete);
		}

		private void ResolveWarningIndicationComplete()
		{
			materialsHandler.AnimationLightsMaterialInstance.SetFloat(ProjectConstants.MaterialProperties.ErrorIntensity, 0f);
			warningSequence = null;
		}
	}
}
