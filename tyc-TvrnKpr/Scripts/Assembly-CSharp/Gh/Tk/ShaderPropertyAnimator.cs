using UnityEngine;

namespace Gh.Tk
{
	public class ShaderPropertyAnimator : MonoBehaviour
	{
		public AnimationCurve curve;

		public string propertyName;

		public MeshRenderer mr;

		public bool unscaledTime;

		public bool fadeOut;

		private float _defaultTime;

		private float _currentTime;

		private float _lastTime;

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateFade(float deltaTime)
		{
		}

		public void Reset()
		{
		}

		public bool IsAnimating()
		{
			return false;
		}
	}
}
