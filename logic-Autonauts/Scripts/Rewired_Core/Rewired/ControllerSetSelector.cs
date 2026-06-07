using System;
using System.Text;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[Preserve]
	public sealed class ControllerSetSelector : ISerializationCallbackReceiver, IDeepCloneable
	{
		public enum Type
		{
			All = 0,
			ControllerType = 1,
			HardwareType = 2,
			ControllerTemplateType = 3,
			PersistentControllerInstance = 4,
			SessionControllerInstance = 5
		}

		[SerializeField]
		[Serialize(Name = "type")]
		private Type _type;

		[SerializeField]
		[Serialize(Name = "controllerType")]
		private ControllerType _controllerType;

		[Serialize(Name = "guid")]
		[SerializeField]
		private string _guid;

		[SerializeField]
		[Serialize(Name = "hardwareIdentifier")]
		private string _hardwareIdentifier;

		[Serialize(Name = "controllerId")]
		[SerializeField]
		private int _controllerId;

		[NonSerialized]
		private Guid qjVztMzMfxrClyDoGsPzljTlUDM;

		internal bool hasControllerType
		{
			get
			{
				return _type != Type.All;
			}
		}

		public Type type
		{
			get
			{
				return _type;
			}
			set
			{
				if (value != _type)
				{
					fKvtanQPHLUHQHQHyrqRcmplEFA();
				}
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
				if (_type != Type.HardwareType)
				{
					return Guid.Empty;
				}
				return qjVztMzMfxrClyDoGsPzljTlUDM;
			}
			set
			{
				if (_type != Type.ControllerTemplateType)
				{
					while (true)
					{
						switch (-1443263215 ^ -1443263216)
						{
						case 0:
							continue;
						case 1:
							Logger.LogWarning(string.Concat("hardwareTypeGuid can only be set when type is ", Type.HardwareType, "."), true);
							return;
						}
						break;
					}
				}
				qjVztMzMfxrClyDoGsPzljTlUDM = value;
				_guid = value.ToString();
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
				if (_type != Type.ControllerTemplateType)
				{
					return Guid.Empty;
				}
				return qjVztMzMfxrClyDoGsPzljTlUDM;
			}
			set
			{
				if (_type != Type.ControllerTemplateType)
				{
					while (true)
					{
						int num = 1235606332;
						while (true)
						{
							switch (num ^ 0x49A5DB3F)
							{
							case 2:
								break;
							case 3:
								Logger.LogWarning(string.Concat("controllerTemplateTypeGuid can only be set when type is ", Type.ControllerTemplateType, "."), true);
								num = 1235606335;
								continue;
							case 0:
								return;
							default:
								goto end_IL_0009;
							}
							break;
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				qjVztMzMfxrClyDoGsPzljTlUDM = value;
				_guid = value.ToString();
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				if (_type != Type.PersistentControllerInstance)
				{
					return Guid.Empty;
				}
				return qjVztMzMfxrClyDoGsPzljTlUDM;
			}
			set
			{
				if (_type != Type.PersistentControllerInstance)
				{
					Logger.LogWarning(string.Concat("deviceInstanceGuid can only be set when type is ", Type.PersistentControllerInstance, "."), true);
					return;
				}
				while (true)
				{
					qjVztMzMfxrClyDoGsPzljTlUDM = value;
					int num = 2086167725;
					while (true)
					{
						switch (num ^ 0x7C5864AF)
						{
						case 0:
							goto IL_0025;
						case 1:
							break;
						default:
							_guid = value.ToString();
							return;
						}
						break;
						IL_0025:
						num = 2086167726;
					}
				}
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

		internal ControllerSetSelector(Type type)
			: this()
		{
			_type = type;
		}

		public ControllerSetSelector()
		{
			while (true)
			{
				int num = -2097486872;
				while (true)
				{
					switch (num ^ -2097486870)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0024;
					case 1:
						return;
					}
					break;
					IL_0024:
					_controllerId = -1;
					num = -2097486869;
				}
			}
		}

		public ControllerSetSelector(ControllerSetSelector source)
		{
			while (true)
			{
				int num = 1676075569;
				while (true)
				{
					switch (num ^ 0x63E6E230)
					{
					case 7:
						break;
					default:
						return;
					case 1:
					{
						int num2;
						if (source != null)
						{
							num = 1676075568;
							num2 = num;
						}
						else
						{
							num = 1676075573;
							num2 = num;
						}
						continue;
					}
					case 3:
						_guid = source._guid;
						_hardwareIdentifier = source._hardwareIdentifier;
						_controllerId = source._controllerId;
						num = 1676075574;
						continue;
					case 0:
						_type = source._type;
						num = 1676075570;
						continue;
					case 2:
						_controllerType = source._controllerType;
						num = 1676075571;
						continue;
					case 6:
						qjVztMzMfxrClyDoGsPzljTlUDM = source.qjVztMzMfxrClyDoGsPzljTlUDM;
						num = 1676075572;
						continue;
					case 5:
						throw new ArgumentNullException("source");
					case 4:
						return;
					}
					break;
				}
			}
		}

		internal ControllerSetSelector(Type type, ControllerType controllerType, string guid, string hardwareIdentifier, int controllerId)
		{
			_type = type;
			_controllerType = controllerType;
			_guid = guid;
			qjVztMzMfxrClyDoGsPzljTlUDM = StringTools.ToGuid(guid);
			_hardwareIdentifier = hardwareIdentifier;
			_controllerId = controllerId;
		}

		public bool Matches(Controller controller)
		{
			if (controller == null)
			{
				goto IL_0003;
			}
			int num;
			if (_type != Type.All)
			{
				num = 174067663;
				goto IL_0008;
			}
			goto IL_002b;
			IL_002b:
			switch (_type)
			{
			case Type.All:
			case Type.ControllerType:
				break;
			case Type.HardwareType:
				if (qjVztMzMfxrClyDoGsPzljTlUDM != Guid.Empty)
				{
					return qjVztMzMfxrClyDoGsPzljTlUDM == controller.hardwareTypeGuid;
				}
				if (string.IsNullOrEmpty(_hardwareIdentifier))
				{
					return true;
				}
				return string.Equals(_hardwareIdentifier, controller.hardwareIdentifier, StringComparison.Ordinal);
			case Type.ControllerTemplateType:
				return controller.ImplementsTemplate(qjVztMzMfxrClyDoGsPzljTlUDM);
			case Type.PersistentControllerInstance:
				return controller.deviceInstanceGuid == qjVztMzMfxrClyDoGsPzljTlUDM;
			case Type.SessionControllerInstance:
				return controller.id == _controllerId;
			default:
				throw new NotImplementedException();
			}
			goto IL_0082;
			IL_0082:
			return true;
			IL_0003:
			num = 174067662;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0xA600FCC)
				{
				case 0:
					break;
				case 4:
					return false;
				case 3:
					goto IL_005c;
				case 2:
					return false;
				default:
					goto IL_0082;
				}
				break;
				IL_005c:
				if (_controllerType != controller.type)
				{
					num = 174067656;
					continue;
				}
				goto IL_002b;
			}
			goto IL_0003;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringTools.WriteVar(stringBuilder, "Type", _type.ToString());
			while (true)
			{
				int num = -1649779116;
				while (true)
				{
					switch (num ^ -1649779113)
					{
					case 4:
						break;
					case 3:
						StringTools.WriteVar(stringBuilder, "Controller Type", _controllerType.ToString());
						num = -1649779115;
						continue;
					case 2:
						StringTools.WriteVar(stringBuilder, "Guid", _guid.ToString());
						StringTools.WriteVar(stringBuilder, "Hardware Identifier", _hardwareIdentifier.ToString());
						num = -1649779114;
						continue;
					case 1:
						StringTools.WriteVar(stringBuilder, "Controller Id", _controllerId.ToString());
						num = -1649779113;
						continue;
					default:
						return stringBuilder.ToString();
					}
					break;
				}
			}
		}

		private void fKvtanQPHLUHQHQHyrqRcmplEFA()
		{
			_guid = string.Empty;
			while (true)
			{
				int num = -158788399;
				while (true)
				{
					switch (num ^ -158788400)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0029;
					case 0:
						return;
					}
					break;
					IL_0029:
					qjVztMzMfxrClyDoGsPzljTlUDM = Guid.Empty;
					num = -158788400;
				}
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			qjVztMzMfxrClyDoGsPzljTlUDM = StringTools.ToGuid(_guid);
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		object IDeepCloneable.DeepClone()
		{
			return new ControllerSetSelector(this);
		}

		public static ControllerSetSelector SelectAll()
		{
			return new ControllerSetSelector(Type.All);
		}

		public static ControllerSetSelector SelectControllerType(ControllerType controllerType)
		{
			ControllerSetSelector controllerSetSelector = new ControllerSetSelector(Type.ControllerType);
			controllerSetSelector._controllerType = controllerType;
			return controllerSetSelector;
		}

		public static ControllerSetSelector SelectHardwareType(ControllerType controllerType, Guid hardwareTypeGuid, string hardwareIdentifier)
		{
			ControllerSetSelector controllerSetSelector = new ControllerSetSelector(Type.HardwareType);
			controllerSetSelector._controllerType = controllerType;
			controllerSetSelector.hardwareTypeGuid = hardwareTypeGuid;
			controllerSetSelector._hardwareIdentifier = hardwareIdentifier;
			return controllerSetSelector;
		}

		public static ControllerSetSelector SelectHardwareType(Controller controller)
		{
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			return SelectHardwareType(controller.type, controller.hardwareTypeGuid, controller.hardwareIdentifier);
		}

		public static ControllerSetSelector SelectControllerTemplateType(ControllerType controllerType, Guid controllerTemplateTypeGuid)
		{
			ControllerSetSelector controllerSetSelector = new ControllerSetSelector(Type.ControllerTemplateType);
			controllerSetSelector._controllerType = controllerType;
			controllerSetSelector.controllerTemplateTypeGuid = controllerTemplateTypeGuid;
			return controllerSetSelector;
		}

		public static ControllerSetSelector SelectControllerTemplateType(IControllerTemplate controllerTemplate)
		{
			if (controllerTemplate == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return SelectControllerTemplateType(controllerTemplate.controller.type, controllerTemplate.typeGuid);
		}

		public static ControllerSetSelector SelectPersistentControllerInstance(ControllerType controllerType, Guid deviceInstanceGuid)
		{
			ControllerSetSelector controllerSetSelector = new ControllerSetSelector(Type.PersistentControllerInstance);
			controllerSetSelector._controllerType = controllerType;
			controllerSetSelector.deviceInstanceGuid = deviceInstanceGuid;
			return controllerSetSelector;
		}

		public static ControllerSetSelector SelectPersistentControllerInstance(Controller controller)
		{
			if (controller == null)
			{
				while (true)
				{
					switch (-995990785 ^ -995990786)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("controller");
					}
					break;
				}
			}
			return SelectPersistentControllerInstance(controller.type, controller.deviceInstanceGuid);
		}

		public static ControllerSetSelector SelectSessionControllerInstance(ControllerType controllerType, int controllerId)
		{
			ControllerSetSelector controllerSetSelector = new ControllerSetSelector(Type.SessionControllerInstance);
			controllerSetSelector._controllerType = controllerType;
			controllerSetSelector._controllerId = controllerId;
			return controllerSetSelector;
		}

		public static ControllerSetSelector SelectSessionControllerInstance(Controller controller)
		{
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			return SelectSessionControllerInstance(controller.type, controller.id);
		}
	}
}
