using System.Collections.Generic;
using Rewired;
using Rewired.Data;
using Unity.Profiling;
using UnityEngine;

public class ControlMappingManager : ManagerBase
{
	[SerializeField]
	private PlatformFlags _supportedPlatformsForKeyboard;

	[SerializeField]
	private PlatformFlags _supportedPlatformsForMouse;

	[SerializeField]
	private PlatformFlags _supportedPlatformsForJoystick;

	[Tooltip("Should we use the Rewired user data store to store user mappings?")]
	[SerializeField]
	private bool _useUserDataStore;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("ControlMappingManager.Init");

	private Dictionary<ControllerType, PlatformFlags> _supportedPlatformsForMapping = new Dictionary<ControllerType, PlatformFlags>();

	[field: Header("Debug (need DEBUG_CONTROL_MAPPING defined to work)")]
	[field: SerializeField]
	public RuntimePlatform DebugPlatform { get; private set; }

	public bool DebugConsole => false;

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			_supportedPlatformsForMapping = new Dictionary<ControllerType, PlatformFlags>
			{
				{
					ControllerType.Keyboard,
					_supportedPlatformsForKeyboard
				},
				{
					ControllerType.Mouse,
					_supportedPlatformsForMouse
				},
				{
					ControllerType.Joystick,
					_supportedPlatformsForJoystick
				}
			};
			UserDataStore_File userDataStore_File = Manager.input.GetRewiredUserDataStore() as UserDataStore_File;
			if (userDataStore_File != null)
			{
				userDataStore_File.isEnabled = _useUserDataStore;
				userDataStore_File.loadKeyboardAssignments = PlatformSupportsMappingForControllerType(ControllerType.Keyboard);
				userDataStore_File.loadMouseAssignments = PlatformSupportsMappingForControllerType(ControllerType.Mouse);
				userDataStore_File.loadJoystickAssignments = PlatformSupportsMappingForControllerType(ControllerType.Joystick);
				userDataStore_File.LoadPlayerData(0);
			}
			return true;
		}
	}

	public bool PlatformSupportsMappingForControllerType(ControllerType controllerType)
	{
		if (_supportedPlatformsForMapping.TryGetValue(controllerType, out var value))
		{
			switch (Application.platform)
			{
			case RuntimePlatform.PS4:
			case RuntimePlatform.PS5:
				return value.HasFlag(PlatformFlags.Playstation);
			case RuntimePlatform.GameCoreXboxSeries:
			case RuntimePlatform.GameCoreXboxOne:
				return value.HasFlag(PlatformFlags.Xbox);
			case RuntimePlatform.Switch:
			case RuntimePlatform.Switch2:
				return value.HasFlag(PlatformFlags.Switch);
			default:
				return value.HasFlag(PlatformFlags.PC);
			}
		}
		return false;
	}
}
