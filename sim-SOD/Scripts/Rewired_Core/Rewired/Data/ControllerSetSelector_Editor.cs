using System;
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
				return default(ControllerSetSelector.Type);
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

		public string hardwareTypeGuidString
		{
			get
			{
				return null;
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

		public string controllerTemplateTypeGuidString
		{
			get
			{
				return null;
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

		public string deviceInstanceGuidString
		{
			get
			{
				return null;
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

		public int customControllerSourceId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal ControllerSetSelector_Editor(ControllerSetSelector.Type type)
		{
		}

		public ControllerSetSelector_Editor()
		{
		}

		public ControllerSetSelector_Editor(ControllerSetSelector_Editor source)
		{
		}

		internal ControllerSetSelector BlNldOkgsTEKlDsbcttSaqlBujNa()
		{
			return null;
		}

		private object PgEbwicioRtyjsSmRbjFwgsRabH()
		{
			return null;
		}

		object IDeepCloneable.DeepClone()
		{
			//ILSpy generated this explicit interface implementation from .override directive in PgEbwicioRtyjsSmRbjFwgsRabH
			return this.PgEbwicioRtyjsSmRbjFwgsRabH();
		}
	}
}
