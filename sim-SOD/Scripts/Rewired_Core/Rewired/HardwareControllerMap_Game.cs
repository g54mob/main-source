using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class HardwareControllerMap_Game
	{
		public readonly string controllerName;

		public readonly HardwareControllerMapIdentifier hardwareMapIdentifier;

		public readonly int customControllerSourceId;

		public readonly ADictionary<int, ControllerElementIdentifier> elementIdentifiers;

		public readonly ControllerElementIdentifier[] elementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] buttonElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] axisElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] axis2DElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] hatElementIdentifiers_cache;

		public readonly IList<ControllerElementIdentifier> elementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> buttonElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> axisElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> axis2DElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> hatElementIdentifiers_readOnly;

		public readonly int[] buttonElementIdentifierIds;

		public readonly int[] axisElementIdentifierIds;

		public readonly int[] axis2DElementIdentifierIds;

		public readonly int[] hatElementIdentifierIds;

		public readonly int elementIdentifierCount;

		public readonly int axisCount;

		public readonly int buttonCount;

		public readonly int compoundElementCount;

		public readonly int axis2DCount;

		public readonly int hatCount;

		public readonly JoystickType[] joystickTypes;

		public readonly AxisCalibrationData[] hwAxisCalibrationData;

		public readonly AxisRange[] hwAxisRanges;

		public readonly HardwareAxisInfo[] hwAxisInfo;

		public readonly HardwareButtonInfo[] hwButtonInfo;

		public readonly HardwareJoystickMap.CompoundElement[] compoundElements;

		private HardwareControllerMap_Game(string controllerName)
		{
		}

		public HardwareControllerMap_Game(string controllerName, int customControllerSourceId, ControllerElementIdentifier[] hardwareElementIdentifiers, int[] buttonElementIdentifierIds, int[] axisElementIdentifierIds, AxisCalibrationData[] hwAxisCalibrationData, AxisRange[] hwAxisRanges, HardwareAxisInfo[] hwAxisInfo, HardwareButtonInfo[] hwButtonInfo, HardwareJoystickMap.CompoundElement[] compoundElements)
		{
		}

		public HardwareControllerMap_Game(string controllerName, HardwareControllerMapIdentifier hardwareMapIdentifier, JoystickType[] joystickTypes, ControllerElementIdentifier[] hardwareElementIdentifiers, int[] buttonElementIdentifierIds, int[] axisElementIdentifierIds, AxisCalibrationData[] hwAxisCalibrationData, AxisRange[] hwAxisRanges, HardwareAxisInfo[] hwAxisInfo, HardwareButtonInfo[] hwButtonInfo, HardwareJoystickMap.CompoundElement[] compoundElements)
		{
		}

		public HardwareControllerMap_Game(string controllerName, HardwareControllerMapIdentifier hardwareMapIdentifier, ControllerElementIdentifier[] hardwareElementIdentifiers, int[] buttonElementIdentifierIds, int[] axisElementIdentifierIds, AxisCalibrationData[] hwAxisCalibrationData, AxisRange[] hwAxisRanges, HardwareAxisInfo[] hwAxisInfo, HardwareButtonInfo[] hwButtonInfo, HardwareJoystickMap.CompoundElement[] compoundElements)
		{
		}

		private HardwareControllerMap_Game(string controllerName, ControllerElementIdentifier[] hardwareElementIdentifiers, int[] buttonElementIdentifierIds, int[] axisElementIdentifierIds, AxisCalibrationData[] hwAxisCalibrationData, AxisRange[] hwAxisRanges, HardwareAxisInfo[] hwAxisInfo, HardwareButtonInfo[] hwButtonInfo, HardwareJoystickMap.CompoundElement[] compoundElements)
		{
		}

		public string GetElementIdentifierName(int elementIdentifierId)
		{
			return null;
		}

		public string GetElementIdentifierPositiveName(int elementIdentifierId)
		{
			return null;
		}

		public string GetElementIdentifierNegativeName(int elementIdentifierId)
		{
			return null;
		}

		public int GetAxisIndex(int elementIdentifierId)
		{
			return 0;
		}

		public int GetAxisIndex(string elementIdentifierName)
		{
			return 0;
		}

		public int GetButtonIndex(int elementIdentifierId)
		{
			return 0;
		}

		public int GetButtonIndex(string elementIdentifierName)
		{
			return 0;
		}

		public ControllerElementIdentifier GetElementIdentifierById(int id)
		{
			return null;
		}

		public ControllerElementIdentifier GetButtonElementIdentifierById(int id)
		{
			return null;
		}

		public ControllerElementIdentifier GetAxisElementIdentifierById(int id)
		{
			return null;
		}

		public HardwareJoystickMap.CompoundElement GetAxis2DData(int index)
		{
			return null;
		}

		public HardwareJoystickMap.CompoundElement GetHatData(int index)
		{
			return null;
		}

		public ControllerElementType GetElementType(int elementIdentifierId)
		{
			return default(ControllerElementType);
		}

		private int jmbtMlFOItjbwHrwiwuNuyIuhWmn(ControllerElementIdentifier[] P_0, int P_1)
		{
			return 0;
		}
	}
}
