using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Data
{
	public sealed class ControllerDataFiles : ScriptableObject
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap defaultHardwareJoystickMap;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap[] hardwareJoystickMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickTemplateMap[] joystickTemplates;

		[NonSerialized]
		private bool IctPxxMPxbDOWgQTyaIwcTgIcoLh;

		[NonSerialized]
		private readonly ADictionary<Guid, NrzRMZtpwBYsRYBDroszOSHvSgOn> ecgDOcphWFWmnuLKIzMCMobVRkzo;

		public Guid defaultHardwareJoystickMapGuid => default(Guid);

		public HardwareJoystickTemplateMap[] JoystickTemplates
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public HardwareJoystickMap[] HardwareJoystickMaps
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public HardwareJoystickMap DefaultHardwareJoystickMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] GetJoystickNames()
		{
			return null;
		}

		public string[] GetEditorJoystickNames()
		{
			return null;
		}

		public Guid[] GetJoystickGuids()
		{
			return null;
		}

		public string[] GetJoystickTemplateNames()
		{
			return null;
		}

		public Guid[] GetJoystickTemplateGuids()
		{
			return null;
		}

		public HardwareJoystickMap GetHardwareJoystickMap(Guid guid)
		{
			return null;
		}

		public HardwareJoystickTemplateMap GetJoystickTemplate(Guid guid)
		{
			return null;
		}

		public IHardwareControllerTemplateMap GetControllerTemplate(Guid guid)
		{
			return null;
		}

		public IHardwareControllerMap GetHardwareJoystickOrTemplateMap(Guid guid)
		{
			return null;
		}

		internal ControllerTemplateElementIdentifier azfTiitMlzdfVjjVcBtXxZfpSdYbA(Guid P_0, int P_1, out HardwareJoystickMap P_2)
		{
			P_2 = null;
			return null;
		}

		internal int iptGhuyCBockQhYelFLeTncSCYRbA(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.uKDNunZxjrWGmifMdjMNvgUgUdWg> P_3)
		{
			return 0;
		}

		internal HardwareJoystickMap_InputManager yLFVkHdHhRSncqxSpBtuFuTRQiNG(Guid P_0, InputSource P_1)
		{
			return null;
		}

		internal HardwareJoystickMap_InputManager kFxmfxNjXzGVaeGIFCSCeliIvNHIb(BridgedControllerHWInfo P_0)
		{
			return null;
		}

		private HardwareJoystickMap_InputManager twOuJyxRssSfUlFbSCjABcHTCcwAb(HardwareJoystickMap P_0, BridgedControllerHWInfo P_1, bool P_2, out InputPlatform P_3, out int P_4, out HardwareJoystickMap.Platform P_5)
		{
			P_3 = default(InputPlatform);
			P_4 = default(int);
			P_5 = null;
			return null;
		}

		private HardwareJoystickMap_InputManager emCKhQCCAaDHGRpQvHHGuAqSJLbp(BridgedControllerHWInfo P_0, string P_1)
		{
			return null;
		}

		private HardwareJoystickMap_InputManager DvGaXRcNcDhJYwpmoJFzYfnfNvMfA(BridgedControllerHWInfo P_0)
		{
			return null;
		}

		internal NrzRMZtpwBYsRYBDroszOSHvSgOn sQxbIrqEaLtExqRskuQlFaLIfCwb(Guid P_0)
		{
			return null;
		}

		internal IHardwareControllerTemplateMap zGZDtyXWWuXVVaAqjeLBvMLEixTc(Guid P_0)
		{
			return null;
		}

		private void pRWIjkwgrAmLyiNifpaGqnFzYSVX()
		{
		}
	}
}
