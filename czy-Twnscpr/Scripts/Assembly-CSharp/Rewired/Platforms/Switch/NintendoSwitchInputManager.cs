using System;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Platforms.Switch
{
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
			[SerializeField]
			private bool _isAllowed;

			[SerializeField]
			private int _rewiredPlayerId;

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
			[SerializeField]
			private bool _enabled;

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
