using System;
using I18n;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh.Tk.UI.Dialogs
{
	public class VolumeControl3DUIView : MonoBehaviour
	{
		public string volumeControlId;

		public string titleLabel;

		[FormerlySerializedAs("_titleText")]
		[SerializeField]
		public TextMeshProI18n TitleText;

		[SerializeField]
		private Slider3DUIView _slider;

		[SerializeField]
		private Button3DUIView _muteButton;

		[SerializeField]
		private Button3DUIView _resetButton;

		private string MuteSFXId => null;

		private string UnmuteSFXId => null;

		private string GetMuteId()
		{
			return null;
		}

		private void SetMutedState(bool isMuted)
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnProfileChanged(object sender, EventArgs<PlayerProfile> e)
		{
		}

		private void OnEnable()
		{
		}

		public void SetData(string id, string label)
		{
		}

		private void OnVolumeValueChanged(object sender, EventArgs eventArgs)
		{
		}

		private void UpdateLabel()
		{
		}
	}
}
