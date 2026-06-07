using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class HardwareControllerMap_Game
	{
		private enum MbZXUOQejSjjvMYluRCWgEZyaHGJ
		{
			Error = 0,
			FoundIndex = 1,
			IsWholeElement = 2
		}

		public readonly string controllerName;

		public readonly HardwareControllerMapIdentifier hardwareMapIdentifier;

		public readonly int customControllerSourceId;

		public readonly ADictionary<int, ControllerElementIdentifier> elementIdentifiers;

		public readonly ControllerElementIdentifier[] elementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] buttonElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] axisElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] axis2DElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] hatElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] dpadElementIdentifiers_cache;

		public readonly IList<ControllerElementIdentifier> elementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> buttonElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> axisElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> axis2DElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> hatElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> dpadElementIdentifiers_readOnly;

		public readonly int[] buttonElementIdentifierIds;

		public readonly int[] axisElementIdentifierIds;

		public readonly int[] axis2DElementIdentifierIds;

		public readonly int[] hatElementIdentifierIds;

		public readonly int[] dpadElementIdentifierIds;

		public readonly int elementIdentifierCount;

		public readonly int axisCount;

		public readonly int buttonCount;

		public readonly int compoundElementCount;

		public readonly int axis2DCount;

		public readonly int hatCount;

		public readonly int dpadCount;

		public readonly JoystickType[] joystickTypes;

		public readonly AxisCalibrationData[] hwAxisCalibrationData;

		public readonly AxisRange[] hwAxisRanges;

		public readonly HardwareAxisInfo[] hwAxisInfo;

		public readonly HardwareButtonInfo[] hwButtonInfo;

		public readonly HardwareJoystickMap.CompoundElement[] compoundElements;

		private readonly DeviceLocalizationInfo HcEdmueDFZNJKLqFBMktbRBJwBmBB;

		public DeviceLocalizationInfo deviceLocalizationInfo => null;

		public HardwareControllerMap_Game(string P_0, DeviceLocalizationInfo P_1, int P_2, ControllerElementIdentifier[] P_3, int[] P_4, int[] P_5, AxisCalibrationData[] P_6, AxisRange[] P_7, HardwareAxisInfo[] P_8, HardwareButtonInfo[] P_9, HardwareJoystickMap.CompoundElement[] P_10)
		{
		}

		public HardwareControllerMap_Game(string P_0, DeviceLocalizationInfo P_1, HardwareControllerMapIdentifier P_2, JoystickType[] P_3, ControllerElementIdentifier[] P_4, int[] P_5, int[] P_6, AxisCalibrationData[] P_7, AxisRange[] P_8, HardwareAxisInfo[] P_9, HardwareButtonInfo[] P_10, HardwareJoystickMap.CompoundElement[] P_11)
		{
		}

		public HardwareControllerMap_Game(string P_0, HardwareControllerMapIdentifier P_1, ControllerElementIdentifier[] P_2, int[] P_3, int[] P_4, AxisCalibrationData[] P_5, AxisRange[] P_6, HardwareAxisInfo[] P_7, HardwareButtonInfo[] P_8, HardwareJoystickMap.CompoundElement[] P_9)
		{
		}

		private HardwareControllerMap_Game(string P_0, DeviceLocalizationInfo P_1, ControllerElementIdentifier[] P_2, int[] P_3, int[] P_4, AxisCalibrationData[] P_5, AxisRange[] P_6, HardwareAxisInfo[] P_7, HardwareButtonInfo[] P_8, HardwareJoystickMap.CompoundElement[] P_9)
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

		public HardwareJoystickMap.CompoundElement GetDPadData(int index)
		{
			return null;
		}

		public ControllerElementType GetElementType(int elementIdentifierId)
		{
			return default(ControllerElementType);
		}

		public bool TryGetCompoundElementMemberCombinedLocalizedName(IList<ActionElementMap> aems, out string result)
		{
			result = null;
			return false;
		}

		public bool TryGetCompoundElementMemberCombinedGlyph(IList<ActionElementMap> aems, bool getGlyph, bool getFinalKey, out object glyphResult, out string finalKey)
		{
			glyphResult = null;
			finalKey = null;
			return false;
		}

		private int PVYRoCIQLyQSBVwGrWchesmauBrf(ControllerElementIdentifier[] P_0, int P_1)
		{
			return 0;
		}

		private static MbZXUOQejSjjvMYluRCWgEZyaHGJ tRnOxdMncwdRrQbdzARtYEVhXVwR(HardwareJoystickMap.CompoundElement P_0, ControllerElementIdentifier P_1, IList<ActionElementMap> P_2, out int P_3)
		{
			P_3 = default(int);
			return default(MbZXUOQejSjjvMYluRCWgEZyaHGJ);
		}
	}
}
