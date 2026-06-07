using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.UI
{
	public class UIDrawerArrowAnimator : MonoBehaviour
	{
		private const float CLOSED_DRAWER_VELOCITY = 0.75f;

		private const float MAX_BAR_ROTATION = 45f;

		private const float ROTATION_SPEED = 10f;

		public RectTransform Rotator;

		public RectTransform LeftBar;

		public RectTransform RightBar;

		private RectTransform m_rectTransform;

		private Image m_leftBarImage;

		private Image m_rightBarImage;

		private float m_velocity;

		private Vector3[] m_rotatorCorners;

		private Vector3[] m_drawerCorners;

		private float m_rotatorDisableThreshold;

		private Vector3[] m_tempCorners;

		private Rect m_rotatorRect;

		public UIDrawer Drawer { get; private set; }

		public RectTransform RectTransform => null;

		public float Width { get; private set; }

		public float Height { get; private set; }

		public Vector2 Size => default(Vector2);

		private void Awake()
		{
		}

		public Vector3[] AdjustCornersToIdentityRotation(RectTransform target, Vector3[] corners)
		{
			return null;
		}

		public void SetTargetDrawer(UIDrawer drawer)
		{
		}

		public void UpdateArrow()
		{
		}

		public void UpdateArrowColor(UIDrawer drawer)
		{
		}

		public void UpdateLocalScale(Vector3 scale)
		{
		}

		public void UpdateLocalScale(float scale)
		{
		}

		public void UpdateRotatorPosition(float visibility)
		{
		}

		private void RotateAndMoveArrowToMatchDrawerDirection(UIDrawer drawer)
		{
		}

		private void UpdateSize()
		{
		}
	}
}
