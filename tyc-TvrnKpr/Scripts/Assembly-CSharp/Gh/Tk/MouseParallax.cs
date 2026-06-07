using UnityEngine;

namespace Gh.Tk
{
	public class MouseParallax : MonoBehaviour
	{
		public Transform root;

		public bool usePosition;

		public bool useRotation;

		private Vector3 _localPos;

		public Vector2 multiplier;

		public bool rotationOverride;

		public Vector3 mouseX;

		public Vector3 mouseY;

		public Vector3 rotationLimit;

		public AnimationCurve rotationResistanceCurve;

		public bool waitUntilLevelLoaded;

		[Header("Sound Triggers")]
		public bool triggerOnAxisX;

		public bool triggerOnAxisY;

		public bool triggerOnAxisZ;

		public Vector3 triggerBoundsMin;

		public Vector3 triggerBoundsMax;

		public string soundTrigger;

		private bool _isTriggerReady;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private float ApplyResistance(float percentage)
		{
			return 0f;
		}

		private bool CheckTriggerBounds(Vector3 newLocalEuler)
		{
			return false;
		}

		private void TriggerSound()
		{
		}
	}
}
