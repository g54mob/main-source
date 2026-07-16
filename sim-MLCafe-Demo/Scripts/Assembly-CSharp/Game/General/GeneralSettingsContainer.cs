using System;
using MLCN_Localization;
using UnityEngine;

namespace Game.General
{
	[Serializable]
	public class GeneralSettingsContainer
	{
		[Header("Controls")]
		public float cameraSensitivity;

		[Header("Other")]
		public int language;

		public bool showHintBoxes;

		public bool tutorialAvailable;

		[Header("Dialog")]
		public bool dialogTextAnimation;

		public float dialogTextSpeed;

		public bool dialogAutoplay;

		public float dialogStayDuration;

		public static GeneralSettingsContainer DefaultSettings()
		{
			return new GeneralSettingsContainer(3f, showHintBoxes: true, tutorialAvailable: true, useDialogAnimation: true, 0.75f, dialogAutoplay: false, 10f);
		}

		public GeneralSettingsContainer(float camera, bool showHintBoxes, bool tutorialAvailable, bool useDialogAnimation, float dialogTextSpeed, bool dialogAutoplay, float dialogStayDuration)
		{
			cameraSensitivity = camera;
			language = (int)LocalizationManager.TryGetSystemLanguage();
			this.showHintBoxes = showHintBoxes;
			this.tutorialAvailable = tutorialAvailable;
			dialogTextAnimation = useDialogAnimation;
			this.dialogTextSpeed = dialogTextSpeed;
			this.dialogAutoplay = dialogAutoplay;
			this.dialogStayDuration = dialogStayDuration;
		}
	}
}
