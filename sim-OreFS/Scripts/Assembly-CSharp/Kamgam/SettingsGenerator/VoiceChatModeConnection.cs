using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class VoiceChatModeConnection : ConnectionWithOptions<string>
	{
		protected List<string> _labels;

		protected List<VoiceActivationMode> _values;

		private int _cachedIndex;

		public static VoiceActivationMode CachedMode { get; private set; }

		public override int Get()
		{
			if (GameManager.Instance == null)
			{
				return _cachedIndex;
			}
			VoiceActivationMode voiceActivationMode = GameManager.Instance.voiceActivationMode;
			List<VoiceActivationMode> values = GetValues();
			for (int i = 0; i < values.Count; i++)
			{
				if (values[i] == voiceActivationMode)
				{
					return i;
				}
			}
			return 0;
		}

		public override void Set(int index)
		{
			List<VoiceActivationMode> values = GetValues();
			index = Mathf.Clamp(index, 0, values.Count - 1);
			_cachedIndex = index;
			CachedMode = values[index];
			VoiceActivationMode voiceActivationMode = values[index];
			if (GameManager.Instance != null)
			{
				GameManager.Instance.voiceActivationMode = voiceActivationMode;
			}
			NotifyListenersIfChanged(index);
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels == null)
			{
				_labels = new List<string> { "Voice Activation", "Push To Talk", "Off" };
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			List<VoiceActivationMode> values = GetValues();
			if (optionLabels == null || optionLabels.Count != values.Count)
			{
				Debug.LogError("Invalid new labels for VoiceChatModeConnection. Need to be " + values.Count + ".");
			}
			else
			{
				_labels = new List<string>(optionLabels);
			}
		}

		public override void RefreshOptionLabels()
		{
			_labels = null;
			GetOptionLabels();
		}

		protected List<VoiceActivationMode> GetValues()
		{
			if (_values == null)
			{
				_values = new List<VoiceActivationMode>
				{
					VoiceActivationMode.VoiceActivation,
					VoiceActivationMode.PushToTalk,
					VoiceActivationMode.Off
				};
			}
			return _values;
		}
	}
}
