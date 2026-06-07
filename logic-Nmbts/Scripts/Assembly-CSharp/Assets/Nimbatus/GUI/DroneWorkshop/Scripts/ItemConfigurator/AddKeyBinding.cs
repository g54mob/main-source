using System;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class AddKeyBinding : SerializedMonoBehaviour
	{
		public UILabel TitleLabel;

		public UITexture Background;

		public Color AssignedColor;

		public Color EmptyColor;

		public Color InactiveColor;

		private bool _parseInput;

		private bool _ignoreLastInput;

		private KeyCode _startKey;

		private bool _unknownKey;

		private bool _inactive;

		public event Action<KeyCode> KeyAssigned;

		public void Init(KeyCode startKey, bool keyUnknown)
		{
			_inactive = GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial != null && GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.AllowTags;
			if (_inactive)
			{
				TitleLabel.text = "";
				Background.color = InactiveColor;
				Collider component = GetComponent<Collider>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			_unknownKey = keyUnknown;
			_startKey = startKey;
			_parseInput = false;
		}

		public void OnClick()
		{
			if (!_ignoreLastInput && !_inactive)
			{
				TitleLabel.text = LocalizationManager.GetTermTranslation("DroneWorkshop/PressKey");
				Background.color = EmptyColor;
				_parseInput = true;
				RuntimeGlobals.StopInteraction = true;
				BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.KeyBind);
			}
		}

		public void Update()
		{
			if (_inactive)
			{
				return;
			}
			if (_parseInput)
			{
				GetComponent<Collider>().enabled = false;
				KeyCode keyCode = FetchKey();
				switch (keyCode)
				{
				case KeyCode.Escape:
				{
					Action<KeyCode> action = this.KeyAssigned;
					if (action != null)
					{
						action(KeyCode.None);
					}
					_unknownKey = false;
					_startKey = KeyCode.None;
					RuntimeGlobals.StopInteraction = false;
					_parseInput = false;
					return;
				}
				case KeyCode.None:
					return;
				}
				_ignoreLastInput = keyCode == KeyCode.Mouse0 || keyCode == KeyCode.Mouse1 || keyCode == KeyCode.Mouse2;
				_parseInput = false;
				Action<KeyCode> action2 = this.KeyAssigned;
				if (action2 != null)
				{
					action2(keyCode);
				}
				_unknownKey = false;
				_startKey = keyCode;
				RuntimeGlobals.StopInteraction = false;
				TitleLabel.text = keyCode.ToString();
				BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.KeyBind);
			}
			else
			{
				KeyCode startKey = _startKey;
				if (_unknownKey)
				{
					TitleLabel.text = "?";
					Background.color = EmptyColor;
				}
				else if (startKey != KeyCode.None)
				{
					TitleLabel.text = startKey.ToLocalizationString();
					Background.color = AssignedColor;
				}
				else
				{
					TitleLabel.text = LocalizationManager.GetTermTranslation("DroneWorkshop/AddKey");
					Background.color = EmptyColor;
				}
				GetComponent<Collider>().enabled = true;
				_ignoreLastInput = false;
			}
		}

		private KeyCode FetchKey()
		{
			foreach (KeyCode item in Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>())
			{
				if (Input.GetKey(item))
				{
					return item;
				}
			}
			if (Input.GetMouseButtonDown(0))
			{
				return KeyCode.Mouse0;
			}
			if (Input.GetMouseButtonDown(1))
			{
				return KeyCode.Mouse1;
			}
			if (Input.GetMouseButtonDown(2))
			{
				return KeyCode.Mouse2;
			}
			if (Input.GetMouseButtonDown(3))
			{
				return KeyCode.Mouse3;
			}
			if (Input.GetMouseButtonDown(4))
			{
				return KeyCode.Mouse4;
			}
			if (Input.GetMouseButtonDown(5))
			{
				return KeyCode.Mouse5;
			}
			if (Input.GetMouseButtonDown(6))
			{
				return KeyCode.Mouse6;
			}
			return KeyCode.None;
		}
	}
}
