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

		[Serialize]
		[SerializeField]
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
			while (true)
			{
				int num = 14832288;
				while (true)
				{
					switch (num ^ 0xE252A1)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						_hardwareTypeGuidString = Guid.Empty.ToString();
						return;
					}
					break;
					IL_0024:
					_controllerId = -1;
					_customControllerSourceId = -1;
					num = 14832289;
				}
			}
		}

		public ControllerSetSelector_Editor(ControllerSetSelector_Editor source)
		{
			while (true)
			{
				int num = 871687813;
				while (true)
				{
					switch (num ^ 0x33F4E680)
					{
					case 4:
						break;
					default:
						return;
					case 0:
						_controllerTemplateTypeGuidString = source._controllerTemplateTypeGuidString;
						_deviceInstanceGuidString = source._deviceInstanceGuidString;
						_hardwareIdentifier = source._hardwareIdentifier;
						_customControllerSourceId = source._customControllerSourceId;
						_controllerId = source._controllerId;
						num = 871687811;
						continue;
					case 2:
						_hardwareTypeGuidString = source._hardwareTypeGuidString;
						num = 871687808;
						continue;
					case 1:
						_type = source._type;
						_controllerType = source._controllerType;
						num = 871687810;
						continue;
					case 5:
						if (source == null)
						{
							throw new ArgumentNullException("source");
						}
						goto case 1;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal ControllerSetSelector fNKUAeEnaeBekawvLSEGNjPnlfR()
		{
			string guid = string.Empty;
			if (_type == ControllerSetSelector.Type.All || _controllerType != ControllerType.Custom)
			{
				goto IL_00c5;
			}
			CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(_controllerId);
			if (customControllerById != null)
			{
				guid = customControllerById.typeGuidString;
				goto IL_003c;
			}
			goto IL_0108;
			IL_0041:
			int num;
			ControllerSetSelector.Type type = default(ControllerSetSelector.Type);
			while (true)
			{
				switch (num ^ -192797773)
				{
				case 5:
					break;
				case 1:
					guid = _controllerTemplateTypeGuidString;
					num = -192797766;
					continue;
				case 7:
					goto IL_008b;
				case 0:
					num = -192797775;
					continue;
				case 8:
					goto IL_00a0;
				case 6:
					throw new NotImplementedException();
				case 4:
					num = -192797775;
					continue;
				case 3:
					goto IL_00c5;
				case 9:
					num = -192797775;
					continue;
				case 10:
					switch (type)
					{
					case ControllerSetSelector.Type.ControllerTemplateType:
						break;
					case ControllerSetSelector.Type.PersistentControllerInstance:
						goto IL_008b;
					case ControllerSetSelector.Type.HardwareType:
						goto IL_00a0;
					default:
						goto IL_00fe;
					case ControllerSetSelector.Type.All:
					case ControllerSetSelector.Type.ControllerType:
					case ControllerSetSelector.Type.SessionControllerInstance:
						goto IL_0108;
					}
					goto case 1;
				default:
					goto IL_0108;
					IL_00fe:
					num = -192797771;
					continue;
					IL_00a0:
					guid = _hardwareTypeGuidString;
					num = -192797773;
					continue;
					IL_008b:
					guid = _deviceInstanceGuidString;
					num = -192797775;
					continue;
				}
				break;
			}
			goto IL_003c;
			IL_0108:
			return new ControllerSetSelector(_type, _controllerType, guid, _hardwareIdentifier, _controllerId);
			IL_00c5:
			type = _type;
			num = -192797767;
			goto IL_0041;
			IL_003c:
			num = -192797769;
			goto IL_0041;
		}

		object IDeepCloneable.DeepClone()
		{
			return new ControllerSetSelector_Editor(this);
		}
	}
}
