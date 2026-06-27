using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedKeyboardSource : CustomPlatformUnifiedControllerSource
	{
		public sealed class KeyPropertyMap
		{
			public struct Key
			{
				public KeyboardKeyCode keyCode;

				public string label;
			}

			private IndexedDictionary<int, string> HSPJvKIujiBxaWfnxBpvsxSjkSOw;

			private bool YpHrXGJXAXrcibHuObBmTYaCsvWD;

			internal bool ktIMfLZExqRQFpZiaKYmiLPRVBTc
			{
				get
				{
					return YpHrXGJXAXrcibHuObBmTYaCsvWD;
				}
				set
				{
					YpHrXGJXAXrcibHuObBmTYaCsvWD = ypHrXGJXAXrcibHuObBmTYaCsvWD;
				}
			}

			public KeyPropertyMap()
			{
				HSPJvKIujiBxaWfnxBpvsxSjkSOw = new IndexedDictionary<int, string>();
				IList<int> keyboardKeyValues = Consts.keyboardKeyValues;
				IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
				for (int i = 0; i < 132; i++)
				{
					HSPJvKIujiBxaWfnxBpvsxSjkSOw.Add(keyboardKeyValues[i], keyboardKeyNames[i]);
				}
				YpHrXGJXAXrcibHuObBmTYaCsvWD = true;
			}

			public KeyPropertyMap(KeyPropertyMap P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("other");
				}
				HSPJvKIujiBxaWfnxBpvsxSjkSOw = new IndexedDictionary<int, string>(P_0.HSPJvKIujiBxaWfnxBpvsxSjkSOw);
				YpHrXGJXAXrcibHuObBmTYaCsvWD = true;
			}

			public Key Get(KeyboardKeyCode keyCode)
			{
				if (!HSPJvKIujiBxaWfnxBpvsxSjkSOw.TryGetValue((int)keyCode, out var value))
				{
					return default(Key);
				}
				return new Key
				{
					keyCode = keyCode,
					label = value
				};
			}

			public void Set(Key key)
			{
				HSPJvKIujiBxaWfnxBpvsxSjkSOw.SetValue((int)key.keyCode, key.label);
				YpHrXGJXAXrcibHuObBmTYaCsvWD = true;
			}

			public Key[] Get()
			{
				Key[] array = new Key[HSPJvKIujiBxaWfnxBpvsxSjkSOw.Count];
				int count = HSPJvKIujiBxaWfnxBpvsxSjkSOw.Count;
				for (int i = 0; i < count; i++)
				{
					array[i] = new Key
					{
						keyCode = (KeyboardKeyCode)HSPJvKIujiBxaWfnxBpvsxSjkSOw.GetKeyAt(i),
						label = HSPJvKIujiBxaWfnxBpvsxSjkSOw[i]
					};
				}
				return array;
			}

			public void Set(ICollection<Key> keys)
			{
				if (keys == null)
				{
					throw new ArgumentNullException("keys");
				}
				foreach (Key key in keys)
				{
					HSPJvKIujiBxaWfnxBpvsxSjkSOw.SetValue((int)key.keyCode, key.label);
				}
				YpHrXGJXAXrcibHuObBmTYaCsvWD = true;
			}
		}

		private KeyPropertyMap MFFnqfelqthjZdidNIMQOwUJkROm;

		public KeyPropertyMap keyPropertyMap
		{
			get
			{
				if (MFFnqfelqthjZdidNIMQOwUJkROm == null)
				{
					MFFnqfelqthjZdidNIMQOwUJkROm = new KeyPropertyMap();
				}
				return MFFnqfelqthjZdidNIMQOwUJkROm;
			}
			set
			{
				if (value == null)
				{
					value = new KeyPropertyMap();
				}
				MFFnqfelqthjZdidNIMQOwUJkROm = value;
				XOWtJvTXEMawohxhXNNdQoIVPWbp();
			}
		}

		public CustomPlatformUnifiedKeyboardSource()
			: base(0, Consts._keyboardKeyValues.Length)
		{
		}

		protected void SetKeyValue(KeyboardKeyCode keyCode, bool value)
		{
			int buttonIndex = ReInput.controllers.Keyboard.GetButtonIndex(keyCode);
			if (buttonIndex >= 0)
			{
				SetButtonValue(buttonIndex, value);
			}
		}

		internal virtual void LtTEeKcLsKxpGvjtlFeRQRwVQYZJA()
		{
			base.pUJIEReQcKLJQtQXMqfzvsOBezPs();
			if (MFFnqfelqthjZdidNIMQOwUJkROm != null && MFFnqfelqthjZdidNIMQOwUJkROm.ktIMfLZExqRQFpZiaKYmiLPRVBTc)
			{
				XOWtJvTXEMawohxhXNNdQoIVPWbp();
			}
		}

		private void XOWtJvTXEMawohxhXNNdQoIVPWbp()
		{
			HardwareControllerMap_Game uzVdrXbKoYScsNhLYrSoTUeynXDBb = ReInput.controllers.Keyboard.UzVdrXbKoYScsNhLYrSoTUeynXDBb;
			int totalCount = uzVdrXbKoYScsNhLYrSoTUeynXDBb.elementIdentifiers.TotalCount;
			for (int i = 0; i < totalCount; i++)
			{
				if (uzVdrXbKoYScsNhLYrSoTUeynXDBb.elementIdentifiers.TryGetValueAt(i, out var value))
				{
					KeyboardKeyCode keyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid];
					string label = MFFnqfelqthjZdidNIMQOwUJkROm.Get(keyCode).label;
					if (!string.Equals(value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, label))
					{
						value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = label;
					}
				}
			}
			MFFnqfelqthjZdidNIMQOwUJkROm.ktIMfLZExqRQFpZiaKYmiLPRVBTc = false;
		}
	}
}
