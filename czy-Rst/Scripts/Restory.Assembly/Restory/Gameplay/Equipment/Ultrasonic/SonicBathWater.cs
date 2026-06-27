using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Restory.Constants;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathWater : MonoBehaviour
	{
		[SerializeField]
		private SonicBathMaterialsHandler materialsHandler;

		[SerializeField]
		private ParticleSystem bubbles;

		[SerializeField]
		[Min(0.1f)]
		private float transitionDuration = 0.8f;

		[SerializeField]
		private Ease transitionEase = Ease.Linear;

		[SerializeField]
		private float refractionStrength = 0.0015f;

		private TweenSequencesService tweenSequences;

		private Sequence transitionSequence;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		public void StartBubbling()
		{
			ChangeRefractionStrength(refractionStrength);
			bubbles.Play();
		}

		public void StopBubbling()
		{
			ChangeRefractionStrength(0f);
			bubbles.Stop();
		}

		private void ChangeRefractionStrength(float targetValue)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				transitionSequence = null;
			}
			Material waterMaterial = materialsHandler.WaterMaterialInstance;
			int refractionProperty = ProjectConstants.MaterialProperties.RefractionStrength;
			TweenerCore<float, float, FloatOptions> t = DOTween.To(() => waterMaterial.GetFloat(refractionProperty), delegate(float strength)
			{
				waterMaterial.SetFloat(refractionProperty, strength);
			}, targetValue, transitionDuration).SetEase(transitionEase);
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(t);
		}
	}
}
