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
		[Serialize(Name = "type")]
		private Type _type;

		[SerializeField]
		[Serialize(Name = "controllerType")]
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
		private Guid rYwHoLMdXLmZAIFuTCRbBkXXdxQu;

		internal bool MyKCzqaeZamTvQdCjVcLiZSbfKIWA => false;

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

		internal ControllerSetSelector(Type P_0)
		{
		}

		public ControllerSetSelector()
		{
		}

		public ControllerSetSelector(ControllerSetSelector P_0)
		{
		}

		internal ControllerSetSelector(Type P_0, ControllerType P_1, string P_2, string P_3, int P_4)
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

		private void QkKbJfYXZpaMIfKfxsWLMQmUjVsAA()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		object IDeepCloneable.DeepClone()
		{
			return null;
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
