using System;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[Preserve]
	public sealed class ControllerSetSelector_Editor : IDeepCloneable
	{
		[Serialize]
		[SerializeField]
		private ControllerSetSelector.Type _type;

		[SerializeField]
		[Serialize]
		private ControllerType _controllerType;

		[Serialize]
		[SerializeField]
		private string _hardwareTypeGuidString;

		[Serialize]
		[SerializeField]
		private string _hardwareIdentifier;

		[SerializeField]
		[Serialize]
		private string _controllerTemplateTypeGuidString;

		[SerializeField]
		[Serialize]
		private string _deviceInstanceGuidString;

		[Serialize]
		[SerializeField]
		private int _customControllerSourceId;

		[SerializeField]
		[Serialize]
		private int _controllerId;

		public ControllerSetSelector.Type type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return _controllerType;
			}
			set
			{
				_controllerType = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return StringTools.ToGuid(_hardwareTypeGuidString);
			}
			set
			{
				_hardwareTypeGuidString = value.ToString();
			}
		}

		public string hardwareTypeGuidString
		{
			get
			{
				return _hardwareTypeGuidString;
			}
			set
			{
				_hardwareTypeGuidString = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return _hardwareIdentifier;
			}
			set
			{
				_hardwareIdentifier = value;
			}
		}

		public Guid controllerTemplateTypeGuid
		{
			get
			{
				return StringTools.ToGuid(_controllerTemplateTypeGuidString);
			}
			set
			{
				_controllerTemplateTypeGuidString = value.ToString();
			}
		}

		public string controllerTemplateTypeGuidString
		{
			get
			{
				return _controllerTemplateTypeGuidString;
			}
			set
			{
				_controllerTemplateTypeGuidString = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return StringTools.ToGuid(_deviceInstanceGuidString);
			}
			set
			{
				_deviceInstanceGuidString = value.ToString();
			}
		}

		public string deviceInstanceGuidString
		{
			get
			{
				return _deviceInstanceGuidString;
			}
			set
			{
				_deviceInstanceGuidString = value;
			}
		}

		public int controllerId
		{
			get
			{
				return _controllerId;
			}
			set
			{
				_controllerId = value;
			}
		}

		public int customControllerSourceId
		{
			get
			{
				return _customControllerSourceId;
			}
			set
			{
				_customControllerSourceId = value;
			}
		}

		internal ControllerSetSelector_Editor(ControllerSetSelector.Type type)
			: this()
		{
			_type = type;
		}

		public ControllerSetSelector_Editor()
		{
			_controllerId = -1;
			_customControllerSourceId = -1;
			_hardwareTypeGuidString = Guid.Empty.ToString();
		}

		public ControllerSetSelector_Editor(ControllerSetSelector_Editor source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			_type = source._type;
			_controllerType = source._controllerType;
			_hardwareTypeGuidString = source._hardwareTypeGuidString;
			_controllerTemplateTypeGuidString = source._controllerTemplateTypeGuidString;
			_deviceInstanceGuidString = source._deviceInstanceGuidString;
			_hardwareIdentifier = source._hardwareIdentifier;
			_customControllerSourceId = source._customControllerSourceId;
			_controllerId = source._controllerId;
		}

		internal ControllerSetSelector UaSeBxgSckzTTOlibRIWoQHplqI()
		{
			string guid = string.Empty;
			if (_type != ControllerSetSelector.Type.All && _controllerType == ControllerType.Custom)
			{
				goto IL_001e;
			}
			goto IL_00b0;
			IL_008a:
			guid = _controllerTemplateTypeGuidString;
			int num = 1120524276;
			goto IL_0023;
			IL_001e:
			num = 1120524272;
			goto IL_0023;
			IL_0023:
			while (true)
			{
				switch (num ^ 0x42C9D7F1)
				{
				case 3:
					break;
				case 1:
				{
					CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(_controllerId);
					if (customControllerById != null)
					{
						guid = customControllerById.typeGuidString;
						num = 1120524281;
						continue;
					}
					goto IL_00ef;
				}
				case 7:
					goto IL_007c;
				case 4:
					goto IL_008a;
				case 8:
					num = 1120524276;
					continue;
				case 6:
					goto IL_009f;
				case 2:
					goto IL_00b0;
				case 0:
					throw new NotImplementedException();
				default:
					goto IL_00ef;
				}
				break;
			}
			goto IL_001e;
			IL_00ef:
			return new ControllerSetSelector(_type, _controllerType, guid, _hardwareIdentifier, _controllerId);
			IL_007c:
			guid = _hardwareTypeGuidString;
			num = 1120524276;
			goto IL_0023;
			IL_009f:
			guid = _deviceInstanceGuidString;
			num = 1120524276;
			goto IL_0023;
			IL_00b0:
			switch (_type)
			{
			case ControllerSetSelector.Type.HardwareType:
				break;
			case ControllerSetSelector.Type.ControllerTemplateType:
				goto IL_008a;
			case ControllerSetSelector.Type.PersistentControllerInstance:
				goto IL_009f;
			default:
				goto IL_00d5;
			case ControllerSetSelector.Type.All:
			case ControllerSetSelector.Type.ControllerType:
			case ControllerSetSelector.Type.SessionControllerInstance:
				goto IL_00ef;
			}
			goto IL_007c;
			IL_00d5:
			num = 1120524273;
			goto IL_0023;
		}

		object IDeepCloneable.DeepClone()
		{
			return new ControllerSetSelector_Editor(this);
		}
	}
}
