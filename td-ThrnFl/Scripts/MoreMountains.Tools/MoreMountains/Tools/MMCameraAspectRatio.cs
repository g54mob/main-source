using UnityEngine;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("More Mountains/Tools/Camera/MMCameraAspectRatio")]
	public class MMCameraAspectRatio : MonoBehaviour
	{
		public enum Modes
		{
			Fixed = 0,
			ScreenRatio = 1
		}

		[Header("Camera")]
		[Tooltip("the camera to change the aspect ratio on")]
		public Camera TargetCamera;

		[Tooltip("the mode of choice, fixed will force a specified ratio, while ScreenRatio will adapt the camera's aspect to the current screen ratio")]
		public Modes Mode;

		[Tooltip("in fixed mode, the ratio to apply to the camera")]
		[MMEnumCondition("Mode", new int[] { 0 })]
		public Vector2 FixedAspectRatio = Vector2.zero;

		[Header("Automation")]
		[Tooltip("whether or not to apply the ratio automatically on Start")]
		public bool ApplyAspectRatioOnStart = true;

		[Tooltip("whether or not to apply the ratio automatically on enable")]
		public bool ApplyAspectRatioOnEnable;

		[Header("Debug")]
		[MMInspectorButton("ApplyAspectRatio")]
		public bool ApplyAspectRatioButton;

		protected float _defaultAspect = 1.7777778f;

		protected virtual void OnEnable()
		{
			if (ApplyAspectRatioOnEnable)
			{
				ApplyAspectRatio();
			}
		}

		protected virtual void Start()
		{
			if (ApplyAspectRatioOnStart)
			{
				ApplyAspectRatio();
			}
		}

		public virtual void ApplyAspectRatio()
		{
			if (!(TargetCamera == null))
			{
				float defaultAspect = _defaultAspect;
				float num = 1f;
				float num2 = 1f;
				switch (Mode)
				{
				case Modes.Fixed:
					num = FixedAspectRatio.x;
					num2 = FixedAspectRatio.y;
					break;
				case Modes.ScreenRatio:
					num = Screen.width;
					num2 = Screen.height;
					break;
				}
				defaultAspect = ((num2 != 0f) ? (num / num2) : _defaultAspect);
				TargetCamera.aspect = defaultAspect;
			}
		}
	}
}
