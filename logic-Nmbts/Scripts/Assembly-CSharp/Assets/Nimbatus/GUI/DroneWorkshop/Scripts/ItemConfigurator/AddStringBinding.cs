using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class AddStringBinding : SerializedMonoBehaviour
	{
		public SimpleInputLabel Label;

		public UILabel TitleLabel;

		public UITexture Background;

		public Color AssignedColor;

		public Color EmptyColor;

		private KeyBinding _keyBinding;

		private bool _parseInput;

		public void Init(KeyBinding binding)
		{
			_keyBinding = binding;
			_parseInput = false;
		}

		public void OnClick()
		{
			TitleLabel.text = "";
			Background.color = EmptyColor;
			_parseInput = true;
			RuntimeGlobals.StopInteraction = true;
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.KeyBind);
		}

		public void OnEnable()
		{
			Label.OnSubmit += Label_OnSubmit;
		}

		private void Label_OnSubmit(string text)
		{
			if (!string.IsNullOrEmpty(text) && _parseInput)
			{
				_keyBinding.SetKey(text);
				_keyBinding.HasBeenAssigned = true;
				RuntimeGlobals.StopInteraction = false;
				TitleLabel.text = text;
				BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.KeyBind);
				_parseInput = false;
			}
		}

		public void OnDisable()
		{
			Label.OnSubmit -= Label_OnSubmit;
		}

		public void Update()
		{
			if (_parseInput)
			{
				GetComponent<Collider>().enabled = false;
				if (Input.GetKeyDown(KeyCode.Escape) || !ItemSelector.HasSelectedItems())
				{
					RuntimeGlobals.StopInteraction = false;
					_parseInput = false;
				}
				return;
			}
			string stringCode = _keyBinding.StringCode;
			if (!string.IsNullOrEmpty(stringCode))
			{
				TitleLabel.text = stringCode;
				Background.color = AssignedColor;
			}
			else
			{
				TitleLabel.text = "Tag";
				Background.color = EmptyColor;
			}
			GetComponent<Collider>().enabled = true;
		}
	}
}
