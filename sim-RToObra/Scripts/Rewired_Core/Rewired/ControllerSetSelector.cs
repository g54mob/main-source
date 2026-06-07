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

		[SerializeField]
		[Serialize(Name = "guid")]
		private string _guid;

		[SerializeField]
		[Serialize(Name = "hardwareIdentifier")]
		private string _hardwareIdentifier;

		[SerializeField]
		[Serialize(Name = "controllerId")]
		private int _controllerId;

		[NonSerialized]
		private Guid BVYaTrLWdjEMRUrycmhzODtgLLX;

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
					while (true)
					{
						int num = 1863064989;
						while (true)
						{
							switch (num ^ 0x6F0C1D9F)
							{
							case 0:
								break;
							case 2:
								MxjqlmgyBPrHxduUStMFNJrlHtF();
								num = 1863064990;
								continue;
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
				return BVYaTrLWdjEMRUrycmhzODtgLLX;
			}
			set
			{
				if (_type != Type.ControllerTemplateType)
				{
					while (true)
					{
						switch (-519504851 ^ -519504852)
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
				BVYaTrLWdjEMRUrycmhzODtgLLX = value;
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
				return BVYaTrLWdjEMRUrycmhzODtgLLX;
			}
			set
			{
				if (_type != Type.ControllerTemplateType)
				{
					Logger.LogWarning(string.Concat("controllerTemplateTypeGuid can only be set when type is ", Type.ControllerTemplateType, "."), true);
					while (true)
					{
						switch (-2027674906 ^ -2027674905)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				BVYaTrLWdjEMRUrycmhzODtgLLX = value;
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
				return BVYaTrLWdjEMRUrycmhzODtgLLX;
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
					BVYaTrLWdjEMRUrycmhzODtgLLX = value;
					int num = 1976159404;
					while (true)
					{
						switch (num ^ 0x75C9CCAD)
						{
						case 0:
							goto IL_0025;
						case 2:
							break;
						default:
							_guid = value.ToString();
							return;
						}
						break;
						IL_0025:
						num = 1976159407;
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
			_controllerId = -1;
		}

		public ControllerSetSelector(ControllerSetSelector source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			_type = source._type;
			_controllerType = source._controllerType;
			_guid = source._guid;
			_hardwareIdentifier = source._hardwareIdentifier;
			_controllerId = source._controllerId;
			BVYaTrLWdjEMRUrycmhzODtgLLX = source.BVYaTrLWdjEMRUrycmhzODtgLLX;
		}

		internal ControllerSetSelector(Type type, ControllerType controllerType, string guid, string hardwareIdentifier, int controllerId)
		{
			_type = type;
			_controllerType = controllerType;
			_guid = guid;
			BVYaTrLWdjEMRUrycmhzODtgLLX = StringTools.ToGuid(guid);
			_hardwareIdentifier = hardwareIdentifier;
			_controllerId = controllerId;
		}

		public bool Matches(Controller controller)
		{
			if (controller == null)
			{
				return false;
			}
			if (_type == Type.All)
			{
				goto IL_0046;
			}
			while (true)
			{
				int num = -1402324935;
				while (true)
				{
					switch (num ^ -1402324936)
					{
					case 0:
						break;
					case 1:
						goto IL_002f;
					case 3:
						return false;
					default:
						goto end_IL_000d;
					}
					break;
					IL_002f:
					if (_controllerType != controller.type)
					{
						num = -1402324933;
						continue;
					}
					goto IL_0046;
				}
				continue;
				end_IL_000d:
				break;
			}
			goto IL_0074;
			IL_0074:
			return true;
			IL_0046:
			switch (_type)
			{
			case Type.All:
			case Type.ControllerType:
				break;
			case Type.HardwareType:
				if (BVYaTrLWdjEMRUrycmhzODtgLLX != Guid.Empty)
				{
					return BVYaTrLWdjEMRUrycmhzODtgLLX == controller.hardwareTypeGuid;
				}
				if (string.IsNullOrEmpty(_hardwareIdentifier))
				{
					return true;
				}
				return string.Equals(_hardwareIdentifier, controller.hardwareIdentifier, StringComparison.Ordinal);
			case Type.ControllerTemplateType:
				return controller.ImplementsTemplate(BVYaTrLWdjEMRUrycmhzODtgLLX);
			case Type.PersistentControllerInstance:
				return controller.deviceInstanceGuid == BVYaTrLWdjEMRUrycmhzODtgLLX;
			case Type.SessionControllerInstance:
				return controller.id == _controllerId;
			default:
				throw new NotImplementedException();
			}
			goto IL_0074;
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

		private void MxjqlmgyBPrHxduUStMFNJrlHtF()
		{
			_guid = string.Empty;
			BVYaTrLWdjEMRUrycmhzODtgLLX = Guid.Empty;
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			BVYaTrLWdjEMRUrycmhzODtgLLX = StringTools.ToGuid(_guid);
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
			while (true)
			{
				int num = -62184603;
				while (true)
				{
					switch (num ^ -62184604)
					{
					case 2:
						break;
					case 1:
						goto IL_0025;
					default:
						return controllerSetSelector;
					}
					break;
					IL_0025:
					controllerSetSelector._controllerType = controllerType;
					controllerSetSelector.hardwareTypeGuid = hardwareTypeGuid;
					controllerSetSelector._hardwareIdentifier = hardwareIdentifier;
					num = -62184604;
				}
			}
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
				throw new ArgumentNullException("controller");
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
					switch (0x7077C61E ^ 0x7077C61C)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("controller");
					}
					break;
				}
			}
			return SelectSessionControllerInstance(controller.type, controller.id);
		}
	}
}
