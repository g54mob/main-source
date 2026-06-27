using FMODUnity;
using UnityEngine;

namespace Restory.Data.Audio.SoundBanks
{
	[CreateAssetMenu(menuName = "Restory/GUI/GuiEventHandlerSoundBank", fileName = "GuiEventHandlerSoundBank - New Bank Name", order = 0)]
	public class GuiEventSoundBank : ScriptableObject
	{
		public EventReference OnPointerEnterSound;

		public EventReference OnPointerExitSound;

		public EventReference OnPointerDownSound;

		public EventReference OnPointerUpSound;

		public EventReference OnPointerClickSound;

		public EventReference OnSliderMoveSound;

		public EventReference OnToggleSwitchedSound;

		public EventReference OnDropdownMenuOpenSound;

		public EventReference OnDropdownMenuItemSelectedSound;
	}
}
