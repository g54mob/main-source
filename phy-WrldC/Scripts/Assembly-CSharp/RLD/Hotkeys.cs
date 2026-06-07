using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class Hotkeys
	{
		private static List<KeyCode> _availableKeys;

		private static List<string> _availableKeyNames;

		private const int _maxNumberOfKeys = 2;

		[SerializeField]
		private bool _isEnabled = true;

		[SerializeField]
		private KeyCode _key;

		[SerializeField]
		private bool _lCtrl;

		[SerializeField]
		private bool _lCmd;

		[SerializeField]
		private bool _lAlt;

		[SerializeField]
		private bool _lShift;

		[SerializeField]
		private bool _useStrictModifierCheck = true;

		[SerializeField]
		private bool _lMouseBtn;

		[SerializeField]
		private bool _rMouseBtn;

		[SerializeField]
		private bool _mMouseBtn;

		[SerializeField]
		private bool _useStrictMouseCheck;

		[SerializeField]
		private string _name = "Hotkeys";

		[NonSerialized]
		private List<Hotkeys> _potentialOverlaps = new List<Hotkeys>();

		[SerializeField]
		private HotkeysStaticData _staticData;

		public static List<KeyCode> AvailableKeys => new List<KeyCode>(_availableKeys);

		public static List<string> AvailableKeyNames => new List<string>(_availableKeyNames);

		public bool IsEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				_isEnabled = value;
			}
		}

		public string Name => _name;

		public KeyCode Key
		{
			get
			{
				return _key;
			}
			set
			{
				if (_availableKeys.Contains(value))
				{
					_key = value;
				}
			}
		}

		public bool LCtrl
		{
			get
			{
				return _lCtrl;
			}
			set
			{
				_lCtrl = value;
			}
		}

		public bool LCmd
		{
			get
			{
				return _lCmd;
			}
			set
			{
				_lCmd = value;
			}
		}

		public bool LAlt
		{
			get
			{
				return _lAlt;
			}
			set
			{
				_lAlt = value;
			}
		}

		public bool LShift
		{
			get
			{
				return _lShift;
			}
			set
			{
				_lShift = value;
			}
		}

		public bool LMouseButton
		{
			get
			{
				return _lMouseBtn;
			}
			set
			{
				_lMouseBtn = value;
			}
		}

		public bool RMouseButton
		{
			get
			{
				return _rMouseBtn;
			}
			set
			{
				_rMouseBtn = value;
			}
		}

		public bool MMouseButton
		{
			get
			{
				return _mMouseBtn;
			}
			set
			{
				_mMouseBtn = value;
			}
		}

		public bool UseStrictMouseCheck
		{
			get
			{
				return _useStrictMouseCheck;
			}
			set
			{
				_useStrictMouseCheck = value;
			}
		}

		public bool UseStrictModifierCheck
		{
			get
			{
				return _useStrictModifierCheck;
			}
			set
			{
				_useStrictModifierCheck = value;
			}
		}

		static Hotkeys()
		{
			_availableKeys = new List<KeyCode>();
			_availableKeys.Add(KeyCode.Space);
			_availableKeys.Add(KeyCode.Backspace);
			_availableKeys.Add(KeyCode.Return);
			_availableKeys.Add(KeyCode.Tab);
			_availableKeys.Add(KeyCode.Delete);
			_availableKeys.Add(KeyCode.LeftBracket);
			_availableKeys.Add(KeyCode.RightBracket);
			for (int i = 97; i <= 122; i++)
			{
				_availableKeys.Add((KeyCode)i);
			}
			for (int j = 48; j <= 57; j++)
			{
				_availableKeys.Add((KeyCode)j);
			}
			_availableKeys.Add(KeyCode.None);
			_availableKeyNames = new List<string>();
			for (int k = 0; k < _availableKeys.Count; k++)
			{
				_availableKeyNames.Add(_availableKeys[k].ToString());
			}
		}

		public Hotkeys(string name)
		{
			_name = name;
			_key = KeyCode.None;
			_staticData = new HotkeysStaticData
			{
				CanHaveMouseButtons = true
			};
		}

		public Hotkeys(string name, HotkeysStaticData staticData)
		{
			_name = name;
			_key = KeyCode.None;
			_staticData = staticData;
		}

		public static void EstablishPotentialOverlaps(List<Hotkeys> hotkeysCollection)
		{
			foreach (Hotkeys item in hotkeysCollection)
			{
				foreach (Hotkeys item2 in hotkeysCollection)
				{
					item.AddPotentialOverlap(item2);
				}
			}
		}

		public int GetNumModifiers()
		{
			int num = 0;
			if (LAlt)
			{
				num++;
			}
			if (LCtrl)
			{
				num++;
			}
			if (LShift)
			{
				num++;
			}
			return num;
		}

		public int GetNumMouseButtons()
		{
			int num = 0;
			if (LMouseButton)
			{
				num++;
			}
			if (RMouseButton)
			{
				num++;
			}
			if (MMouseButton)
			{
				num++;
			}
			return num;
		}

		public List<MouseButton> GetAllUsedMouseButtons()
		{
			if (GetNumMouseButtons() == 0)
			{
				return new List<MouseButton>();
			}
			List<MouseButton> list = new List<MouseButton>(3);
			if (LMouseButton)
			{
				list.Add(MouseButton.Left);
			}
			if (RMouseButton)
			{
				list.Add(MouseButton.Right);
			}
			if (MMouseButton)
			{
				list.Add(MouseButton.Middle);
			}
			return list;
		}

		public bool UsesMouseButtons(List<MouseButton> buttons)
		{
			List<MouseButton> allUsedMouseButtons = GetAllUsedMouseButtons();
			foreach (MouseButton button in buttons)
			{
				if (!allUsedMouseButtons.Contains(button))
				{
					return false;
				}
			}
			return true;
		}

		public List<KeyCode> GetAllUsedModifiers()
		{
			if (GetNumMouseButtons() == 0)
			{
				return new List<KeyCode>();
			}
			List<KeyCode> list = new List<KeyCode>(3);
			if (LAlt)
			{
				list.Add(KeyCode.LeftAlt);
			}
			if (LShift)
			{
				list.Add(KeyCode.LeftShift);
			}
			if (LCtrl)
			{
				list.Add(KeyCode.LeftControl);
			}
			return list;
		}

		public bool UsesModifiers(List<KeyCode> modifiers)
		{
			List<KeyCode> allUsedModifiers = GetAllUsedModifiers();
			foreach (KeyCode modifier in modifiers)
			{
				if (!allUsedModifiers.Contains(modifier))
				{
					return false;
				}
			}
			return true;
		}

		public void AddPotentialOverlap(Hotkeys hotkeys)
		{
			if (hotkeys != null && hotkeys != this && !ContainsPotentialOverlap(hotkeys))
			{
				_potentialOverlaps.Add(hotkeys);
			}
		}

		public bool ContainsPotentialOverlap(Hotkeys hotkeys)
		{
			return _potentialOverlaps.Contains(hotkeys);
		}

		public bool IsOverlappedBy(Hotkeys hotkeys)
		{
			if (hotkeys == null || hotkeys == this)
			{
				return false;
			}
			if (GetNumModifiers() <= hotkeys.GetNumModifiers() && GetNumMouseButtons() <= hotkeys.GetNumMouseButtons() && hotkeys.Key == Key && hotkeys.UsesModifiers(GetAllUsedModifiers()) && hotkeys.UsesMouseButtons(GetAllUsedMouseButtons()))
			{
				return true;
			}
			return false;
		}

		public bool IsActive(bool checkForOverlaps = true)
		{
			if (!IsEnabled || IsEmpty())
			{
				return false;
			}
			if (Key != KeyCode.None && !Input.GetKey(Key))
			{
				return false;
			}
			if (UseStrictModifierCheck && HasNoModifiers() && IsAnyModifierKeyPressed())
			{
				return false;
			}
			if (_lCtrl && !Input.GetKey(KeyCode.LeftControl))
			{
				return false;
			}
			if (_lCmd && !Input.GetKey(KeyCode.LeftCommand))
			{
				return false;
			}
			if (_lAlt && !Input.GetKey(KeyCode.LeftAlt))
			{
				return false;
			}
			if (_lShift && !Input.GetKey(KeyCode.LeftShift))
			{
				return false;
			}
			if (UseStrictMouseCheck && HasNoMouseButtons() && IsAnyMouseButtonPressed())
			{
				return false;
			}
			if (_lMouseBtn && !Input.GetMouseButton(0))
			{
				return false;
			}
			if (_rMouseBtn && !Input.GetMouseButton(1))
			{
				return false;
			}
			if (_mMouseBtn && !Input.GetMouseButton(2))
			{
				return false;
			}
			if (checkForOverlaps)
			{
				foreach (Hotkeys potentialOverlap in _potentialOverlaps)
				{
					if (potentialOverlap.IsActive(checkForOverlaps: false) && IsOverlappedBy(potentialOverlap))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool IsActiveInFrame(bool checkForOverlaps = true)
		{
			if (!IsEnabled || IsEmpty())
			{
				return false;
			}
			if (Key != KeyCode.None && !Input.GetKeyDown(Key))
			{
				return false;
			}
			if (UseStrictModifierCheck && HasNoModifiers() && IsAnyModifierKeyPressed())
			{
				return false;
			}
			if (_lCtrl && !Input.GetKey(KeyCode.LeftControl))
			{
				return false;
			}
			if (_lCmd && !Input.GetKey(KeyCode.LeftCommand))
			{
				return false;
			}
			if (_lAlt && !Input.GetKey(KeyCode.LeftAlt))
			{
				return false;
			}
			if (_lShift && !Input.GetKey(KeyCode.LeftShift))
			{
				return false;
			}
			if (UseStrictMouseCheck && HasNoMouseButtons() && IsAnyMouseButtonPressed())
			{
				return false;
			}
			if (_lMouseBtn && !Input.GetMouseButtonDown(0))
			{
				return false;
			}
			if (_rMouseBtn && !Input.GetMouseButtonDown(1))
			{
				return false;
			}
			if (_mMouseBtn && !Input.GetMouseButtonDown(2))
			{
				return false;
			}
			if (checkForOverlaps)
			{
				foreach (Hotkeys potentialOverlap in _potentialOverlaps)
				{
					if (potentialOverlap.IsActiveInFrame(checkForOverlaps: false) && IsOverlappedBy(potentialOverlap))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool HasNoKeys()
		{
			return Key == KeyCode.None;
		}

		public bool HasNoModifiers()
		{
			if (!_lAlt && !_lCmd && !_lCtrl)
			{
				return !_lShift;
			}
			return false;
		}

		public bool HasNoMouseButtons()
		{
			if (!_lMouseBtn && !_rMouseBtn)
			{
				return !_mMouseBtn;
			}
			return false;
		}

		public bool IsEmpty()
		{
			if (HasNoKeys() && HasNoModifiers())
			{
				return HasNoMouseButtons();
			}
			return false;
		}

		private bool IsAnyModifierKeyPressed()
		{
			if (Input.GetKey(KeyCode.LeftControl))
			{
				return true;
			}
			if (Input.GetKey(KeyCode.LeftCommand))
			{
				return true;
			}
			if (Input.GetKey(KeyCode.LeftAlt))
			{
				return true;
			}
			if (Input.GetKey(KeyCode.LeftShift))
			{
				return true;
			}
			return false;
		}

		private bool IsAnyMouseButtonPressed()
		{
			if (Input.GetMouseButton(0))
			{
				return true;
			}
			if (Input.GetMouseButton(1))
			{
				return true;
			}
			if (Input.GetMouseButton(2))
			{
				return true;
			}
			return false;
		}
	}
}
