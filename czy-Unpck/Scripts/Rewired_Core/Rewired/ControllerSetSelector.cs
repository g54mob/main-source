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

		[Serialize(Name = "type")]
		[SerializeField]
		private Type _type;

		[Serialize(Name = "controllerType")]
		[SerializeField]
		private ControllerType _controllerType;

		[Serialize(Name = "guid")]
		[SerializeField]
		private string _guid;

		[SerializeField]
		[Serialize(Name = "hardwareIdentifier")]
		private string _hardwareIdentifier;

		[SerializeField]
		[Serialize(Name = "controllerId")]
		private int _controllerId;

		[NonSerialized]
		private Guid PlZAGRfFpvyucLZPHqBcOrjeMVdk;

		internal bool hasControllerType => _type != Type.All;

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
					KJtDYqgtkNpVBoMmflWKmNNqbNb();
					goto IL_000f;
				}
				goto IL_002d;
				IL_002d:
				_type = value;
				int num = -791657801;
				goto IL_0014;
				IL_000f:
				num = -791657804;
				goto IL_0014;
				IL_0014:
				switch (num ^ -791657802)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_002d;
				case 1:
					return;
				}
				goto IL_000f;
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
				return PlZAGRfFpvyucLZPHqBcOrjeMVdk;
			}
			set
			{
				if (_type != Type.ControllerTemplateType)
				{
					goto IL_0009;
				}
				goto IL_0051;
				IL_0009:
				int num = -1110216466;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -1110216465)
					{
					case 4:
						break;
					case 1:
						Logger.LogWarning(string.Concat("hardwareTypeGuid can only be set when type is ", Type.HardwareType, "."), requiredThreadSafety: true);
						num = -1110216467;
						continue;
					case 0:
						goto IL_0051;
					case 2:
						return;
					default:
						_guid = value.ToString();
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0051:
				PlZAGRfFpvyucLZPHqBcOrjeMVdk = value;
				num = -1110216468;
				goto IL_000e;
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
				return PlZAGRfFpvyucLZPHqBcOrjeMVdk;
			}
			set
			{
				if (_type != Type.ControllerTemplateType)
				{
					Logger.LogWarning(string.Concat("controllerTemplateTypeGuid can only be set when type is ", Type.ControllerTemplateType, "."), requiredThreadSafety: true);
					goto IL_0024;
				}
				goto IL_0064;
				IL_0064:
				PlZAGRfFpvyucLZPHqBcOrjeMVdk = value;
				int num = 251958412;
				goto IL_0029;
				IL_0024:
				num = 251958415;
				goto IL_0029;
				IL_0029:
				while (true)
				{
					switch (num ^ 0xF04948E)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						_guid = value.ToString();
						num = 251958413;
						continue;
					case 4:
						goto IL_0064;
					case 1:
						return;
					case 3:
						return;
					}
					break;
				}
				goto IL_0024;
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
				return PlZAGRfFpvyucLZPHqBcOrjeMVdk;
			}
			set
			{
				if (_type != Type.PersistentControllerInstance)
				{
					goto IL_0009;
				}
				goto IL_004e;
				IL_0009:
				int num = 1527139001;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x5B064ABA)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					Logger.LogWarning(string.Concat("deviceInstanceGuid can only be set when type is ", Type.PersistentControllerInstance, "."), requiredThreadSafety: true);
					return;
				case 0:
					goto IL_004e;
				case 1:
					return;
				}
				goto IL_0009;
				IL_004e:
				PlZAGRfFpvyucLZPHqBcOrjeMVdk = value;
				_guid = value.ToString();
				num = 1527139003;
				goto IL_000e;
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
			_controllerId = -1;
		}

		public ControllerSetSelector(ControllerSetSelector source)
		{
			while (true)
			{
				int num = 1030877947;
				while (true)
				{
					switch (num ^ 0x3D71F2FA)
					{
					case 2:
						break;
					case 1:
						if (source != null)
						{
							goto IL_003d;
						}
						throw new ArgumentNullException("source");
					case 3:
						goto IL_003d;
					default:
						_hardwareIdentifier = source._hardwareIdentifier;
						_controllerId = source._controllerId;
						PlZAGRfFpvyucLZPHqBcOrjeMVdk = source.PlZAGRfFpvyucLZPHqBcOrjeMVdk;
						return;
					}
					break;
					IL_003d:
					_type = source._type;
					_controllerType = source._controllerType;
					_guid = source._guid;
					num = 1030877946;
				}
			}
		}

		internal ControllerSetSelector(Type type, ControllerType controllerType, string guid, string hardwareIdentifier, int controllerId)
		{
			_type = type;
			_controllerType = controllerType;
			_guid = guid;
			PlZAGRfFpvyucLZPHqBcOrjeMVdk = StringTools.ToGuid(guid);
			_hardwareIdentifier = hardwareIdentifier;
			_controllerId = controllerId;
		}

		public bool Matches(Controller controller)
		{
			if (controller == null)
			{
				return false;
			}
			if (_type != Type.All)
			{
				goto IL_000d;
			}
			goto IL_0065;
			IL_004a:
			int num;
			if (PlZAGRfFpvyucLZPHqBcOrjeMVdk != Guid.Empty)
			{
				num = 2025739440;
				goto IL_0012;
			}
			if (string.IsNullOrEmpty(_hardwareIdentifier))
			{
				return true;
			}
			return string.Equals(_hardwareIdentifier, controller.hardwareIdentifier, StringComparison.Ordinal);
			IL_000d:
			num = 2025739441;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x78BE54B3)
				{
				case 0:
					break;
				case 2:
					goto IL_0033;
				case 4:
					goto IL_0048;
				case 1:
					return false;
				default:
					return PlZAGRfFpvyucLZPHqBcOrjeMVdk == controller.hardwareTypeGuid;
				}
				break;
				IL_0033:
				if (_controllerType != controller.type)
				{
					num = 2025739442;
					continue;
				}
				goto IL_0065;
			}
			goto IL_000d;
			IL_0065:
			switch (_type)
			{
			case Type.All:
			case Type.ControllerType:
				break;
			case Type.HardwareType:
				goto IL_004a;
			case Type.ControllerTemplateType:
				return controller.ImplementsTemplate(PlZAGRfFpvyucLZPHqBcOrjeMVdk);
			case Type.PersistentControllerInstance:
				return controller.deviceInstanceGuid == PlZAGRfFpvyucLZPHqBcOrjeMVdk;
			case Type.SessionControllerInstance:
				return controller.id == _controllerId;
			default:
				throw new NotImplementedException();
			}
			goto IL_0048;
			IL_0048:
			return true;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringTools.WriteVar(stringBuilder, "Type", _type.ToString());
			StringTools.WriteVar(stringBuilder, "Controller Type", _controllerType.ToString());
			StringTools.WriteVar(stringBuilder, "Guid", _guid.ToString());
			StringTools.WriteVar(stringBuilder, "Hardware Identifier", _hardwareIdentifier.ToString());
			StringTools.WriteVar(stringBuilder, "Controller Id", _controllerId.ToString());
			return stringBuilder.ToString();
		}

		private void KJtDYqgtkNpVBoMmflWKmNNqbNb()
		{
			_guid = string.Empty;
			PlZAGRfFpvyucLZPHqBcOrjeMVdk = Guid.Empty;
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			PlZAGRfFpvyucLZPHqBcOrjeMVdk = StringTools.ToGuid(_guid);
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		private object hEZwsICCTkbnKIzILtxAEaqwNbdC()
		{
			return new ControllerSetSelector(this);
		}

		object IDeepCloneable.DeepClone()
		{
			//ILSpy generated this explicit interface implementation from .override directive in hEZwsICCTkbnKIzILtxAEaqwNbdC
			return this.hEZwsICCTkbnKIzILtxAEaqwNbdC();
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
			while (true)
			{
				int num = -1765298593;
				while (true)
				{
					switch (num ^ -1765298594)
					{
					case 2:
						break;
					case 1:
						goto IL_002c;
					default:
						controllerSetSelector._hardwareIdentifier = hardwareIdentifier;
						return controllerSetSelector;
					}
					break;
					IL_002c:
					controllerSetSelector.hardwareTypeGuid = hardwareTypeGuid;
					num = -1765298594;
				}
			}
		}

		public static ControllerSetSelector SelectHardwareType(Controller controller)
		{
			if (controller == null)
			{
				while (true)
				{
					switch (-1210020648 ^ -1210020647)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("controller");
					}
					break;
				}
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
					switch (-1559411268 ^ -1559411266)
					{
					case 0:
						continue;
					case 2:
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
				while (true)
				{
					switch (-1706315059 ^ -1706315060)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("controller");
					}
					break;
				}
			}
			return SelectSessionControllerInstance(controller.type, controller.id);
		}
	}
}
