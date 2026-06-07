using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.Preview3D
{
	[Settings("Preview 3D", Scope.Project)]
	public class Preview3DSettings : CustomSettings<Preview3DSettings>
	{
		[Header("Manipulator")]
		[SerializeField]
		private UI_Preview3DObjectManipulator.ERotationAxis m_rotationAxis;

		[SerializeField]
		private bool m_hideCursorOnDrag = true;

		[SerializeField]
		[Show("m_hideCursorOnDrag", false)]
		private bool m_cursorStayAtPositionOnDragEnd = true;

		[SerializeField]
		private float m_gamepadDragSpeedMultiplier = 100f;

		public static UI_Preview3DObjectManipulator.ERotationAxis RotationAxis => CustomSettings<Preview3DSettings>.I.m_rotationAxis;

		public static bool HideCursorOnDrag => CustomSettings<Preview3DSettings>.I.m_hideCursorOnDrag;

		public static bool CursorStayAtPositionOnDragEnd => CustomSettings<Preview3DSettings>.I.m_cursorStayAtPositionOnDragEnd;

		public static float GamepadDragSpeedMultiplier => CustomSettings<Preview3DSettings>.I.m_gamepadDragSpeedMultiplier;
	}
}
