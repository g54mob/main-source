using Restory.UI.Presenters.DevicePaintingTool;
using Restory.Utils;
using UnityEngine;

namespace Restory.UserInterface
{
	public class GUI_DropdownSFX : GUI_SfxEventHandler
	{
		[SerializeField]
		private GUI_RestoryDropdown dropdown;

		private void OnEnable()
		{
			dropdown.OnDropdownMenuOpen += ResolveDropdownMenuOpen;
			dropdown.onValueChanged.AddListener(ResolveDropdownItemSelected);
		}

		private void OnDisable()
		{
			if (dropdown.MonoShellExists())
			{
				dropdown.OnDropdownMenuOpen -= ResolveDropdownMenuOpen;
				dropdown.onValueChanged.RemoveListener(ResolveDropdownItemSelected);
			}
		}

		private void ResolveDropdownMenuOpen()
		{
			TryToPlaySound(soundBank.OnDropdownMenuOpenSound);
		}

		private void ResolveDropdownItemSelected(int selectedItemIndex)
		{
			TryToPlaySound(soundBank.OnDropdownMenuItemSelectedSound);
		}
	}
}
