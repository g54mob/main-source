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
		[SerializeField]
		[Serialize]
		private ControllerSetSelector.Type _type;

		[Serialize]
		[SerializeField]
		private ControllerType _controllerType;

		[Serialize]
		[SerializeField]
		private string _hardwareTypeGuidString;

		[SerializeField]
		[Serialize]
		private string _hardwareIdentifier;

		[Serialize]
		[SerializeField]
		private string _controllerTemplateTypeGuidString;

		[Serialize]
		[SerializeField]
		private string _deviceInstanceGuidString;

		[SerializeField]
		[Serialize]
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

		internal ControllerSetSelector tyEwseEJKkWWIdVgizZVszJwpmd()
		{
			string guid = string.Empty;
			while (true)
			{
				int num = 985437543;
				while (true)
				{
					switch (num ^ 0x3ABC956F)
					{
					case 3:
						break;
					case 2:
						throw new NotImplementedException();
					case 7:
						switch (_type)
						{
						case ControllerSetSelector.Type.ControllerTemplateType:
							goto IL_0078;
						case ControllerSetSelector.Type.HardwareType:
							goto IL_00bd;
						case ControllerSetSelector.Type.PersistentControllerInstance:
							goto IL_00d8;
						case ControllerSetSelector.Type.All:
						case ControllerSetSelector.Type.ControllerType:
						case ControllerSetSelector.Type.SessionControllerInstance:
							goto IL_00e9;
						}
						num = 985437549;
						continue;
					case 6:
						goto IL_0078;
					case 8:
					{
						if (_type == ControllerSetSelector.Type.All || _controllerType != ControllerType.Custom)
						{
							goto case 7;
						}
						CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(_controllerId);
						if (customControllerById != null)
						{
							guid = customControllerById.typeGuidString;
							num = 985437547;
							continue;
						}
						goto IL_00e9;
					}
					case 5:
						goto IL_00bd;
					case 1:
						num = 985437547;
						continue;
					case 0:
						goto IL_00d8;
					default:
						goto IL_00e9;
						IL_00bd:
						guid = _hardwareTypeGuidString;
						num = 985437550;
						continue;
						IL_0078:
						guid = _controllerTemplateTypeGuidString;
						num = 985437547;
						continue;
						IL_00e9:
						return new ControllerSetSelector(_type, _controllerType, guid, _hardwareIdentifier, _controllerId);
						IL_00d8:
						guid = _deviceInstanceGuidString;
						num = 985437547;
						continue;
					}
					break;
				}
			}
		}

		private object hEZwsICCTkbnKIzILtxAEaqwNbdC()
		{
			return new ControllerSetSelector_Editor(this);
		}

		object IDeepCloneable.DeepClone()
		{
			//ILSpy generated this explicit interface implementation from .override directive in hEZwsICCTkbnKIzILtxAEaqwNbdC
			return this.hEZwsICCTkbnKIzILtxAEaqwNbdC();
		}
	}
}
