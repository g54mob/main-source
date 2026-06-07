using System;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Platforms.Switch
{
	[AddComponentMenu("Rewired/Nintendo Switch Input Manager")]
	[RequireComponent(typeof(InputManager))]
	public sealed class NintendoSwitchInputManager : MonoBehaviour, IExternalInputManager
	{
		[Serializable]
		private class UserData : IKeyedData<int>
		{
			[SerializeField]
			private int _allowedNpadStyles;

			[SerializeField]
			private int _joyConGripStyle;

			[SerializeField]
			private bool _adjustIMUsForGripStyle;

			[SerializeField]
			private int _handheldActivationMode;

			[SerializeField]
			private bool _assignJoysticksByNpadId;

			[SerializeField]
			private bool _useVibrationThread;

			[SerializeField]
			private NpadSettings_Internal _npadNo1;

			[SerializeField]
			private NpadSettings_Internal _npadNo2;

			[SerializeField]
			private NpadSettings_Internal _npadNo3;

			[SerializeField]
			private NpadSettings_Internal _npadNo4;

			[SerializeField]
			private NpadSettings_Internal _npadNo5;

			[SerializeField]
			private NpadSettings_Internal _npadNo6;

			[SerializeField]
			private NpadSettings_Internal _npadNo7;

			[SerializeField]
			private NpadSettings_Internal _npadNo8;

			[SerializeField]
			private NpadSettings_Internal _npadHandheld;

			[SerializeField]
			private DebugPadSettings_Internal _debugPad;

			private Dictionary<int, object[]> __delegates;

			public int allowedNpadStyles
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int joyConGripStyle
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool adjustIMUsForGripStyle
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int handheldActivationMode
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool assignJoysticksByNpadId
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool useVibrationThread
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			private NpadSettings_Internal npadNo1 => null;

			private NpadSettings_Internal npadNo2 => null;

			private NpadSettings_Internal npadNo3 => null;

			private NpadSettings_Internal npadNo4 => null;

			private NpadSettings_Internal npadNo5 => null;

			private NpadSettings_Internal npadNo6 => null;

			private NpadSettings_Internal npadNo7 => null;

			private NpadSettings_Internal npadNo8 => null;

			private NpadSettings_Internal npadHandheld => null;

			public DebugPadSettings_Internal debugPad => null;

			private Dictionary<int, object[]> delegates => null;

			bool IKeyedData<int>.TryGetValue<T>(int key, out T value)
			{
				value = default(T);
				return false;
			}

			bool IKeyedData<int>.TrySetValue<T>(int key, T value)
			{
				return false;
			}
		}

		[Serializable]
		private sealed class NpadSettings_Internal : IKeyedData<int>
		{
			[Tooltip("Determines whether this Npad id is allowed to be used by the system.")]
			[SerializeField]
			private bool _isAllowed;

			[Tooltip("The Rewired Player Id assigned to this Npad id.")]
			[SerializeField]
			private int _rewiredPlayerId;

			[Tooltip("Determines how Joy-Cons should be handled.\n\nUnmodified: Joy-Con assignment mode will be left at the system default.\nDual: Joy-Cons pairs are handled as a single controller.\nSingle: Joy-Cons are handled as individual controllers.")]
			[SerializeField]
			private int _joyConAssignmentMode;

			private Dictionary<int, object[]> __delegates;

			private bool isAllowed
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			private int rewiredPlayerId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			private int joyConAssignmentMode
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			private Dictionary<int, object[]> delegates => null;

			internal NpadSettings_Internal(int playerId)
			{
			}

			bool IKeyedData<int>.TryGetValue<T>(int key, out T value)
			{
				value = default(T);
				return false;
			}

			bool IKeyedData<int>.TrySetValue<T>(int key, T value)
			{
				return false;
			}
		}

		[Serializable]
		private sealed class DebugPadSettings_Internal : IKeyedData<int>
		{
			[Tooltip("Determines whether the Debug Pad will be enabled.")]
			[SerializeField]
			private bool _enabled;

			[Tooltip("The Rewired Player Id to which the Debug Pad will be assigned.")]
			[SerializeField]
			private int _rewiredPlayerId;

			private Dictionary<int, object[]> __delegates;

			private int rewiredPlayerId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			private bool enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			private Dictionary<int, object[]> delegates => null;

			internal DebugPadSettings_Internal(int playerId)
			{
			}

			bool IKeyedData<int>.TryGetValue<T>(int key, out T value)
			{
				value = default(T);
				return false;
			}

			bool IKeyedData<int>.TrySetValue<T>(int key, T value)
			{
				return false;
			}
		}

		[SerializeField]
		private UserData _userData;

		object IExternalInputManager.Initialize(Platform platform, object configVars)
		{
			return null;
		}

		void IExternalInputManager.Deinitialize()
		{
		}
	}
}
