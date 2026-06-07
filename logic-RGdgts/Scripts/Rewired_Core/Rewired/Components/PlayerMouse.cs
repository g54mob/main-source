using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	[Serializable]
	public sealed class PlayerMouse : PlayerController, IPlayerController, IPlayerMouse, IMouseInputSource
	{
		[Serializable]
		public class ScreenPositionChangedHandler : UnityEvent<Vector2>
		{
		}

		[SerializeField]
		[CustomObfuscation]
		private bool _defaultToCenter;

		[SerializeField]
		[CustomObfuscation]
		private float _pointerSpeed;

		[SerializeField]
		[CustomObfuscation]
		private bool _useHardwarePointerPosition;

		[SerializeField]
		[CustomObfuscation]
		private bool _clampToMovementArea;

		[SerializeField]
		[CustomObfuscation]
		private Rect _movementArea;

		[SerializeField]
		[CustomObfuscation]
		private Rewired.PlayerMouse.MovementAreaUnit _movementAreaUnit;

		[SerializeField]
		[CustomObfuscation]
		private ScreenPositionChangedHandler _onScreenPositionChanged;

		private Rewired.PlayerMouse yGdZHAmdUeDYveLTSINOCvUHtMoHA => null;

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

		internal override List<ElementInfo> KNoWOpeWgdlxCnBGGhQMtQLkTkVM()
		{
			return null;
		}

		private void TMJsPWyfwxDkdGHuOryyBJvhmWNI(Vector2 P_0)
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
