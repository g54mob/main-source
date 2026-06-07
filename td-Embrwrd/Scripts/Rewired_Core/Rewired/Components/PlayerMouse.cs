using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("Rewired/Player Controllers/Player Mouse")]
	public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
	{
		[Serializable]
		public class ScreenPositionChangedHandler : UnityEvent<Vector2>
		{
		}

		[Tooltip("If enabled, the screen position will default to the center of the allowed movement area. Otherwise, it will default to the lower-left corner of the allowed movement area.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _defaultToCenter;

		[Tooltip("The pointer speed. This does not affect the speed of input from the mouse x/y axes if useHardwarePointerPosition is enabled. It only affects the speed from input sources other than mouse x/y or if mouse x/y are mapped to Actions assigned to Axes. ")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _pointerSpeed;

		[Tooltip("If enabled, the hardware pointer position will be used for mouse input. Otherwise, the position of the pointer will be calculated only from the Axis Action values. The Player that owns this Player Mouse must have the physical mouse assigned to it in order for the hardware position to be used, ex: player.controllers.hasMouse == true.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useHardwarePointerPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, movement will be clamped to the Movement Area.")]
		private bool _clampToMovementArea;

		[Tooltip("The allowed movement area for the mouse pointer. Set Movement Area Unit to determine the data format of this value. This rect is a screen-space rect with 0, 0 at the lower-left corner.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Rect _movementArea;

		[Tooltip("The unit format of the movement area. This is used to determine the data format of Movement Area.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Rewired.PlayerMouse.MovementAreaUnit _movementAreaUnit;

		[Tooltip("Triggered when the screen position changes. Link this to your pointer to drive its position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ScreenPositionChangedHandler _onScreenPositionChanged;

		private Rewired.PlayerMouse NjsGkyGgvuISIAQuJkKLzQJARkgvb => null;

		public bool defaultToCenter
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				return default(ScreenRect);
			}
			set
			{
			}
		}

		public Rewired.PlayerMouse.MovementAreaUnit movementAreaUnit
		{
			get
			{
				return default(Rewired.PlayerMouse.MovementAreaUnit);
			}
			set
			{
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 screenPositionPrev => default(Vector2);

		public Vector2 screenPositionDelta => default(Vector2);

		public Rewired.PlayerController.MouseAxis xAxis => null;

		public Rewired.PlayerController.MouseAxis yAxis => null;

		public Rewired.PlayerController.MouseWheel wheel => null;

		public Rewired.PlayerController.Button leftButton => null;

		public Rewired.PlayerController.Button rightButton => null;

		public Rewired.PlayerController.Button middleButton => null;

		public float pointerSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool IMouseInputSource.enabled => false;

		Vector2 IMouseInputSource.screenPosition => default(Vector2);

		Vector2 IMouseInputSource.screenPositionDelta => default(Vector2);

		Vector2 IMouseInputSource.wheelDelta => default(Vector2);

		bool IMouseInputSource.locked => false;

		bool IPlayerController.enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action<Vector2> ScreenPositionChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		protected override void OnValidated()
		{
		}

		protected override void OnReset()
		{
		}

		protected override Rewired.PlayerController CreateSource(object args)
		{
			return null;
		}

		protected override void Deinitialize()
		{
		}

		protected override void Subscribe()
		{
		}

		protected override void Unsubscribe()
		{
		}

		internal override List<ElementInfo> tqKtTocfcpjWbSHMMmrMmbfMiWlO()
		{
			return null;
		}

		private void DgXnDFdBUyCFmFMIEGqRYtCwKNYDA(Vector2 P_0)
		{
		}

		bool IMouseInputSource.GetButtonDown(int button)
		{
			return false;
		}

		bool IMouseInputSource.GetButtonUp(int button)
		{
			return false;
		}

		bool IMouseInputSource.GetButton(int button)
		{
			return false;
		}
	}
}
