using System;
using FMODUnity;
using Mandragora.Utils;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.ElementPresets
{
	public class GUI_PresetSwitcherSFX : MonoBehaviour
	{
		[Serializable]
		private class Entry
		{
			[SerializeField]
			[BoolButton(25, 0, Red = false)]
			private bool usesCustomPresetName;

			[SerializeField]
			private string customPresetName;

			[SerializeField]
			private PresetName presetName;

			[SerializeField]
			private EventReference sound;

			public string PresetName
			{
				get
				{
					if (!usesCustomPresetName)
					{
						return presetName.ToString();
					}
					return customPresetName;
				}
			}

			public EventReference Sound => sound;
		}

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private Entry[] entries = new Entry[0];

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			presetSwitcher.OnPresetChanged += ResolvePresetChanged;
		}

		private void OnDisable()
		{
			if (presetSwitcher.MonoShellExists())
			{
				presetSwitcher.OnPresetChanged -= ResolvePresetChanged;
			}
		}

		private void ResolvePresetChanged()
		{
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry != null && entry.PresetName == presetSwitcher.ActivePresetName)
				{
					audioPlayer.PlaySoundEventOneShot(entry.Sound);
					break;
				}
			}
		}
	}
}
