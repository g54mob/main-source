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

			private IndexedDictionary<int, string> CqwtWTTdeqbHHmqlQWAjPuXAmavk;

			private bool RNkvzIUeKFIDNXVLxOYuebVvuYvS;

			internal bool lKdtQEQhDyedudDVBdbyWFSsLjqhb
			{
				get
				{
					return RNkvzIUeKFIDNXVLxOYuebVvuYvS;
				}
				set
				{
					RNkvzIUeKFIDNXVLxOYuebVvuYvS = rNkvzIUeKFIDNXVLxOYuebVvuYvS;
				}
			}

			public KeyPropertyMap()
			{
				CqwtWTTdeqbHHmqlQWAjPuXAmavk = new IndexedDictionary<int, string>();
				IList<int> keyboardKeyValues = Consts.keyboardKeyValues;
				IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
				for (int i = 0; i < 132; i++)
				{
					CqwtWTTdeqbHHmqlQWAjPuXAmavk.Add(keyboardKeyValues[i], keyboardKeyNames[i]);
				}
				RNkvzIUeKFIDNXVLxOYuebVvuYvS = true;
			}

			public KeyPropertyMap(KeyPropertyMap P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("other");
				}
				CqwtWTTdeqbHHmqlQWAjPuXAmavk = new IndexedDictionary<int, string>(P_0.CqwtWTTdeqbHHmqlQWAjPuXAmavk);
				RNkvzIUeKFIDNXVLxOYuebVvuYvS = true;
			}

			public Key Get(KeyboardKeyCode keyCode)
			{
				if (!CqwtWTTdeqbHHmqlQWAjPuXAmavk.TryGetValue((int)keyCode, out var value))
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
				CqwtWTTdeqbHHmqlQWAjPuXAmavk.SetValue((int)key.keyCode, key.label);
				RNkvzIUeKFIDNXVLxOYuebVvuYvS = true;
			}

			public Key[] Get()
			{
				Key[] array = new Key[CqwtWTTdeqbHHmqlQWAjPuXAmavk.Count];
				int count = CqwtWTTdeqbHHmqlQWAjPuXAmavk.Count;
				for (int i = 0; i < count; i++)
				{
					array[i] = new Key
					{
						keyCode = (KeyboardKeyCode)CqwtWTTdeqbHHmqlQWAjPuXAmavk.GetKeyAt(i),
						label = CqwtWTTdeqbHHmqlQWAjPuXAmavk[i]
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
					CqwtWTTdeqbHHmqlQWAjPuXAmavk.SetValue((int)key.keyCode, key.label);
				}
				RNkvzIUeKFIDNXVLxOYuebVvuYvS = true;
			}
		}

		private KeyPropertyMap XYaBucdbbdUXuPJrkijIhsXmOIpL;

		public KeyPropertyMap keyPropertyMap
		{
			get
			{
				if (XYaBucdbbdUXuPJrkijIhsXmOIpL == null)
				{
					XYaBucdbbdUXuPJrkijIhsXmOIpL = new KeyPropertyMap();
				}
				return XYaBucdbbdUXuPJrkijIhsXmOIpL;
			}
			set
			{
				if (value == null)
				{
					value = new KeyPropertyMap();
				}
				XYaBucdbbdUXuPJrkijIhsXmOIpL = value;
				ENlHgcKXkQSGRFcpgefzvpLoswQH();
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

		internal virtual void AlwqsNMbEAPebHrQMHHXiFbuqnyl()
		{
			base.sisKDAvpjMbjnHxNlCCfIzPoFSmi();
			if (XYaBucdbbdUXuPJrkijIhsXmOIpL != null && XYaBucdbbdUXuPJrkijIhsXmOIpL.lKdtQEQhDyedudDVBdbyWFSsLjqhb)
			{
				ENlHgcKXkQSGRFcpgefzvpLoswQH();
			}
		}

		private void ENlHgcKXkQSGRFcpgefzvpLoswQH()
		{
			HardwareControllerMap_Game jEexZOPzSUUjNTHjvxywblgJdFqE = ReInput.controllers.Keyboard.JEexZOPzSUUjNTHjvxywblgJdFqE;
			int totalCount = jEexZOPzSUUjNTHjvxywblgJdFqE.elementIdentifiers.TotalCount;
			for (int i = 0; i < totalCount; i++)
			{
				if (jEexZOPzSUUjNTHjvxywblgJdFqE.elementIdentifiers.TryGetValueAt(i, out var value))
				{
					KeyboardKeyCode keyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid];
					string label = XYaBucdbbdUXuPJrkijIhsXmOIpL.Get(keyCode).label;
					if (!string.Equals(value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, label))
					{
						value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = label;
					}
				}
			}
			XYaBucdbbdUXuPJrkijIhsXmOIpL.lKdtQEQhDyedudDVBdbyWFSsLjqhb = false;
		}
	}
}
