using Factory.Pools;
using UnityEngine;

namespace Motorways.Views
{
	public class OnScreenDebugToolsActivator : MonoBehaviour, IReusable
	{
		public delegate void ActivationStatusChange(bool isActive);

		private static readonly Vector2Int BaseResolution = new Vector2Int(1920, 1080);

		private const int HitCountBeforeActivation = 5;

		private const float ActivationAreaSize = 200f;

		private const float MaxTimeBetweenHitsInSeconds = 0.3f;

		private float _lastHitTime = float.MinValue;

		private int _hitCount;

		public ActivationStatusChange onActivationStatusChanged;

		public bool AreToolsActive { get; private set; }

		private void Awake()
		{
			if (!FeatureToggle.IsFeatureEnabled(Feature.OnScreenDebugTools))
			{
				base.enabled = false;
			}
		}

		private void OnGUI()
		{
			if (!FeatureToggle.IsFeatureEnabled(Feature.OnScreenDebugTools))
			{
				return;
			}
			Matrix4x4 matrix = GUI.matrix;
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / (float)BaseResolution.x, (float)Screen.height / (float)BaseResolution.y, 1f));
			if (GUI.Button(new Rect(0f, (float)BaseResolution.y - 200f, 200f, 200f), "", GUIStyle.none))
			{
				if (_lastHitTime <= float.MinValue)
				{
					_hitCount++;
					_lastHitTime = Time.time;
				}
				else if (Time.time - _lastHitTime < 0.3f)
				{
					_hitCount++;
					_lastHitTime = Time.time;
					if (_hitCount >= 5)
					{
						_hitCount = 0;
						_lastHitTime = float.MinValue;
						AreToolsActive = !AreToolsActive;
						onActivationStatusChanged?.Invoke(AreToolsActive);
					}
				}
				else
				{
					_hitCount = 1;
					_lastHitTime = float.MinValue;
				}
			}
			GUI.matrix = matrix;
		}

		public void Reset()
		{
			_hitCount = 0;
			_lastHitTime = float.MinValue;
			AreToolsActive = false;
		}
	}
}
