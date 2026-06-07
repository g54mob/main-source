using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialResourceJunk : MonoBehaviour
	{
		public Renderer Renderer;

		public CapsuleCollider Collider;

		public AnimationCurve ThresholdToRadius;

		public AnimationCurve ResourceAmountToThreshold;

		private float _resourceSlider01;

		private bool _everythingCollected;

		public void Start()
		{
		}

		public void Update()
		{
			if (Renderer != null && Collider != null)
			{
				float num = ResourceAmountToThreshold.Evaluate(_resourceSlider01);
				Renderer.material.SetFloat("_Threshold", Mathf.Clamp01(num));
				Collider.radius = 25f * ThresholdToRadius.Evaluate(num);
				if (num < 0.61f)
				{
					Collider.enabled = true;
					Renderer.enabled = true;
					_everythingCollected = false;
				}
				else
				{
					Collider.enabled = false;
					Renderer.enabled = false;
					_everythingCollected = true;
				}
			}
		}

		public void GatherResource(float amount)
		{
			_resourceSlider01 = Mathf.Clamp01(_resourceSlider01 + amount);
		}

		public bool IsEverythingCollected()
		{
			return _everythingCollected;
		}
	}
}
