using Controllers;
using KitchenData;
using Platforms;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class RemapElement : ButtonElement
	{
		[Header("Configuration")]
		[SerializeField]
		private TextMeshPro InputPrompt;

		private int PlayerID;

		private string Action;

		private GlobalLocalisation Localisation => GameData.Main.GlobalLocalisation;

		private ControllerIcons Icons => GameData.Main.GlobalLocalisation.ControllerIcons;

		private IInputSource InputSource => InputSourceIdentifier.DefaultInputSource;

		public override void Initialise()
		{
			base.Initialise();
			InputSourceIdentifier.DefaultInputSource.OnBindingChange += HandleBindingChange;
		}

		public override void Destroy()
		{
			base.Destroy();
			InputSourceIdentifier.DefaultInputSource.OnBindingChange -= HandleBindingChange;
		}

		public RemapElement SetButton(int player, string action)
		{
			PlayerID = player;
			Action = action;
			UpdateBinding();
			return this;
		}

		private void HandleBindingChange(int i, string s)
		{
			if (i == PlayerID && (s == Action || s == ""))
			{
				UpdateBinding();
			}
		}

		private void UpdateBinding()
		{
			if (PlayerID != 0 && Action != null)
			{
				ControllerType currentController = InputSource.GetCurrentController(PlayerID);
				string bindingName = InputSource.GetBindingName(PlayerID, Action);
				string tMPIcon = Icons.GetTMPIcon(currentController, bindingName);
				InputPrompt.text = tMPIcon;
			}
		}

		public override ButtonElement SetSize(float width, float height)
		{
			BackingBorder.Width = width;
			BackingBorder.Height = height;
			MouseBackingBorder.Width = width;
			MouseBackingBorder.Height = height;
			return this;
		}
	}
}
