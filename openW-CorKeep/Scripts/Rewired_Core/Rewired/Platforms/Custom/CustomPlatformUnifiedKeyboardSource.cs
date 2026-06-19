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

			private IndexedDictionary<int, string> QsypEWvdGglXzHCJVZDUQOTpfMtl;

			private bool FqeRhZyMaFvDlqohqBXPlWDYjVhDA;

			internal bool xgvRQFaIhaPdCeXfWhkNWjIRqqyX
			{
				get
				{
					return FqeRhZyMaFvDlqohqBXPlWDYjVhDA;
				}
				set
				{
					FqeRhZyMaFvDlqohqBXPlWDYjVhDA = fqeRhZyMaFvDlqohqBXPlWDYjVhDA;
				}
			}

			public KeyPropertyMap()
			{
				QsypEWvdGglXzHCJVZDUQOTpfMtl = new IndexedDictionary<int, string>();
				IList<int> keyboardKeyValues = Consts.keyboardKeyValues;
				IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
				for (int i = 0; i < 132; i++)
				{
					QsypEWvdGglXzHCJVZDUQOTpfMtl.Add(keyboardKeyValues[i], keyboardKeyNames[i]);
				}
				FqeRhZyMaFvDlqohqBXPlWDYjVhDA = true;
			}

			public KeyPropertyMap(KeyPropertyMap P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("other");
				}
				QsypEWvdGglXzHCJVZDUQOTpfMtl = new IndexedDictionary<int, string>(P_0.QsypEWvdGglXzHCJVZDUQOTpfMtl);
				FqeRhZyMaFvDlqohqBXPlWDYjVhDA = true;
			}

			public Key Get(KeyboardKeyCode keyCode)
			{
				if (!QsypEWvdGglXzHCJVZDUQOTpfMtl.TryGetValue((int)keyCode, out var value))
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
				QsypEWvdGglXzHCJVZDUQOTpfMtl.SetValue((int)key.keyCode, key.label);
				FqeRhZyMaFvDlqohqBXPlWDYjVhDA = true;
			}

			public Key[] Get()
			{
				Key[] array = new Key[QsypEWvdGglXzHCJVZDUQOTpfMtl.Count];
				int count = QsypEWvdGglXzHCJVZDUQOTpfMtl.Count;
				for (int i = 0; i < count; i++)
				{
					array[i] = new Key
					{
						keyCode = (KeyboardKeyCode)QsypEWvdGglXzHCJVZDUQOTpfMtl.GetKeyAt(i),
						label = QsypEWvdGglXzHCJVZDUQOTpfMtl[i]
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
					QsypEWvdGglXzHCJVZDUQOTpfMtl.SetValue((int)key.keyCode, key.label);
				}
				FqeRhZyMaFvDlqohqBXPlWDYjVhDA = true;
			}
		}

		private KeyPropertyMap JssefYZRdeJEdsFbredNqRRJZdhA;

		public KeyPropertyMap keyPropertyMap
		{
			get
			{
				if (JssefYZRdeJEdsFbredNqRRJZdhA == null)
				{
					JssefYZRdeJEdsFbredNqRRJZdhA = new KeyPropertyMap();
				}
				return JssefYZRdeJEdsFbredNqRRJZdhA;
			}
			set
			{
				if (value == null)
				{
					value = new KeyPropertyMap();
				}
				JssefYZRdeJEdsFbredNqRRJZdhA = value;
				EnxNRtkFjMdUxmpJlpzOuoHHqrAv();
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

		internal virtual void GqyqjEyURGDNHoJHFWpitchFtnyJ()
		{
			base.qewMkHDdLAlwJqtxaRESVhPHKIqJ();
			if (JssefYZRdeJEdsFbredNqRRJZdhA != null && JssefYZRdeJEdsFbredNqRRJZdhA.xgvRQFaIhaPdCeXfWhkNWjIRqqyX)
			{
				EnxNRtkFjMdUxmpJlpzOuoHHqrAv();
			}
		}

		private void EnxNRtkFjMdUxmpJlpzOuoHHqrAv()
		{
			HardwareControllerMap_Game lJmpCFrENABMhmUxmGaTconkDyoGA = ReInput.controllers.Keyboard.LJmpCFrENABMhmUxmGaTconkDyoGA;
			int totalCount = lJmpCFrENABMhmUxmGaTconkDyoGA.elementIdentifiers.TotalCount;
			for (int i = 0; i < totalCount; i++)
			{
				if (lJmpCFrENABMhmUxmGaTconkDyoGA.elementIdentifiers.TryGetValueAt(i, out var value))
				{
					KeyboardKeyCode keyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid];
					string label = JssefYZRdeJEdsFbredNqRRJZdhA.Get(keyCode).label;
					if (!string.Equals(value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, label))
					{
						value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = label;
					}
				}
			}
			JssefYZRdeJEdsFbredNqRRJZdhA.xgvRQFaIhaPdCeXfWhkNWjIRqqyX = false;
		}
	}
}
