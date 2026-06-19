using UnityEngine;
using UnityEngine.Playables;

namespace TH20
{
	public class MetagameHospitalVisual : MonoBehaviour
	{
		public string AnimatableId;

		[SerializeField]
		private MeshRenderer _mesh;

		[SerializeField]
		private PlayableDirector _playableDirector;

		[SerializeField]
		private float _cameraShakeDuration = 1.4f;

		[SerializeField]
		private float _cameraShakeSpeed = 20f;

		[SerializeField]
		private float _cameraShakeMagnitude = 1.1f;

		[HideInInspector]
		public float Desaturation;

		[HideInInspector]
		public float AnimatedY;

		private Vector3 _cachedLocalPosition;

		private Material[] _materialInstances;

		private void Start()
		{
			_cachedLocalPosition = base.transform.localPosition;
			_materialInstances = _mesh.materials;
		}

		public bool IsAnimating()
		{
			return _playableDirector.state == PlayState.Playing;
		}

		private void Update()
		{
			if (IsAnimating())
			{
				SetValues();
			}
		}

		public void SetIsUnlocked(bool isUnlocked, bool instant = true)
		{
			if (instant || !isUnlocked)
			{
				if (isUnlocked)
				{
					_playableDirector.time = _playableDirector.duration;
				}
				else
				{
					_playableDirector.time = 0.0;
				}
				_playableDirector.Evaluate();
				SetValues();
				_playableDirector.Stop();
			}
			else
			{
				_playableDirector.time = 0.0;
				_playableDirector.Play();
				StartCameraShake();
			}
		}

		private void StartCameraShake()
		{
			Camera.main.gameObject.AddComponent<CameraShakeEffectComponent>().Shake(_cameraShakeDuration, _cameraShakeSpeed, _cameraShakeMagnitude, position: true, rotation: false, useUnscaledTime: true);
		}

		private void SetValues()
		{
			if (_materialInstances == null)
			{
				_materialInstances = _mesh.materials;
			}
			float num = 1f - Mathf.Clamp01(Desaturation);
			TH20Standard.SetGrayAnatomyRGBStrength(_materialInstances[0], new Vector3(num, num, num));
			TH20Standard.SetGrayAnatomyRGBStrength(_materialInstances[1], new Vector3(num, num, num));
			base.transform.localPosition = _cachedLocalPosition + new Vector3(0f, AnimatedY * base.transform.localScale.y, 0f);
		}
	}
}
