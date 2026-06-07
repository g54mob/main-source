using System;
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
		[Serialize]
		private Type _type;

		[Serialize]
		[SerializeField]
		private ControllerType _controllerType;

		[SerializeField]
		[Serialize]
		private string _guid;

		[SerializeField]
		[Serialize]
		private string _hardwareIdentifier;

		[SerializeField]
		[Serialize]
		private int _controllerId;

		[NonSerialized]
		private Guid ySnhlQZuqonhHYrzLBkZXrYafZP;

		internal bool hasControllerType => false;

		public Type type
		{
			get
			{
				return default(Type);
			}
			set
			{
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return default(ControllerType);
			}
			set
			{
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Guid controllerTemplateTypeGuid
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public int controllerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal ControllerSetSelector(Type type)
		{
		}

		public ControllerSetSelector()
		{
		}

		public ControllerSetSelector(ControllerSetSelector source)
		{
		}

		internal ControllerSetSelector(Type type, ControllerType controllerType, string guid, string hardwareIdentifier, int controllerId)
		{
		}

		public bool Matches(Controller controller)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		private void nxBCjzAenYFCogfECbnbMAsmkNDF()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		private object KPfRFRKLWxAatcPaDDQxiAPwmfHV()
		{
			return null;
		}

		object IDeepCloneable.DeepClone()
		{
			//ILSpy generated this explicit interface implementation from .override directive in KPfRFRKLWxAatcPaDDQxiAPwmfHV
			return this.KPfRFRKLWxAatcPaDDQxiAPwmfHV();
		}

		public static ControllerSetSelector SelectAll()
		{
			return null;
		}

		public static ControllerSetSelector SelectControllerType(ControllerType controllerType)
		{
			return null;
		}

		public static ControllerSetSelector SelectHardwareType(ControllerType controllerType, Guid hardwareTypeGuid, string hardwareIdentifier)
		{
			return null;
		}

		public static ControllerSetSelector SelectHardwareType(Controller controller)
		{
			return null;
		}

		public static ControllerSetSelector SelectControllerTemplateType(ControllerType controllerType, Guid controllerTemplateTypeGuid)
		{
			return null;
		}

		public static ControllerSetSelector SelectControllerTemplateType(IControllerTemplate controllerTemplate)
		{
			return null;
		}

		public static ControllerSetSelector SelectPersistentControllerInstance(ControllerType controllerType, Guid deviceInstanceGuid)
		{
			return null;
		}

		public static ControllerSetSelector SelectPersistentControllerInstance(Controller controller)
		{
			return null;
		}

		public static ControllerSetSelector SelectSessionControllerInstance(ControllerType controllerType, int controllerId)
		{
			return null;
		}

		public static ControllerSetSelector SelectSessionControllerInstance(Controller controller)
		{
			return null;
		}
	}
}
