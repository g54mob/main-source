using UnityEngine;

namespace TH20
{
	public class LightHeadedBulb : MonoBehaviour
	{
		public float LightBulbIntensity = 1f;

		public RuntimeAnimatorController RuntimeAnimatorController;

		private Animator _animator;

		private Material _lightBulbMaterial;

		private Color _initialEmissiveColor;

		private float _nextFlicker;

		public Material LightBulbMaterial
		{
			set
			{
				_lightBulbMaterial = value;
				_initialEmissiveColor = TH20Standard.GetEmissiveColor(_lightBulbMaterial);
			}
		}

		public Transform LightBulbTransform
		{
			set
			{
			}
		}

		private void Start()
		{
			InitAnimator();
			_nextFlicker = Random.Range(15f, 30f);
		}

		private void InitAnimator()
		{
			if (_animator == null)
			{
				_animator = base.gameObject.AddComponent<Animator>();
				_animator.runtimeAnimatorController = RuntimeAnimatorController;
			}
		}

		private void Update()
		{
			if (_lightBulbMaterial != null)
			{
				TH20Standard.SetEmissiveColor(_lightBulbMaterial, _initialEmissiveColor * LightBulbIntensity);
			}
			_nextFlicker -= Time.deltaTime;
			if (_nextFlicker < 0f)
			{
				FlickerBulb();
				_nextFlicker = Random.Range(8f, 15f);
			}
		}

		public void FlickerBulb()
		{
			InitAnimator();
			_animator.SetTrigger("Flicker");
		}

		public void TurnOffBulb()
		{
			InitAnimator();
			_animator.SetBool("IsOff", value: true);
		}

		public void DestroyBulb()
		{
		}
	}
}
