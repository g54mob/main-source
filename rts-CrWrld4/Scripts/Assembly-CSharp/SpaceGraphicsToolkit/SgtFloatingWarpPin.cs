using UnityEngine;
using UnityEngine.UI;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingWarpPin : MonoBehaviour
	{
		public float PickDistance;

		public SgtFloatingTarget CurrentTarget;

		public RectTransform Parent;

		public RectTransform Rect;

		public Text Title;

		public CanvasGroup Group;

		public SgtFloatingWarp Warp;

		public bool HideIfTooClose;

		[HideInInspector]
		public float Alpha;

		public void ClickWarp()
		{
		}

		public void Pick(Vector2 pickScreenPoint)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		private void FingerTap(SgtInputManager.Finger finger)
		{
		}
	}
}
