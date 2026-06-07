using UnityEngine;

namespace Lean.Touch
{
	[AddComponentMenu("Lean/Touch/Lean Drag Translate")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanDragTranslate")]
	public class LeanDragTranslate : MonoBehaviour
	{
		public LeanFingerFilter Use;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private float sensitivity;

		[SerializeField]
		private float damping;

		[Range(0f, 1f)]
		[SerializeField]
		private float inertia;

		[SerializeField]
		private Vector3 remainingTranslation;

		public Camera Camera
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Sensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Damping
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Inertia
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public void AddFinger(LeanFinger finger)
		{
		}

		public void RemoveFinger(LeanFinger finger)
		{
		}

		public void RemoveAllFingers()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{
		}

		private void TranslateUI(Vector2 screenDelta)
		{
		}

		private void Translate(Vector2 screenDelta)
		{
		}
	}
}
