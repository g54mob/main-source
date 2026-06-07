using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelScene
{
	public class NimbatusReentryAnimation : MonoBehaviour
	{
		public GameObject GlowEffect;

		private float _currentSpeed;

		private float _maxDuration;

		private float _currentTime;

		private Material _glowMaterial;

		private void Start()
		{
			_glowMaterial = GlowEffect.GetComponent<Renderer>().material;
		}

		private void Update()
		{
			if (_currentTime > 0f)
			{
				_currentTime -= Time.deltaTime * _currentSpeed;
				float value = _currentTime / _maxDuration;
				_glowMaterial.SetFloat("_Fade", value);
			}
			GlowEffect.SetActive(_currentTime > 0f);
		}

		public void SetDuration(int duration, float speed)
		{
			_maxDuration = (float)duration / 100f;
			_currentTime = _maxDuration;
			_currentSpeed = speed;
		}
	}
}
