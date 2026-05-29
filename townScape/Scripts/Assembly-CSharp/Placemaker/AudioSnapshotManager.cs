using Placemaker.Ui;
using UnityEngine;
using UnityEngine.Audio;

namespace Placemaker
{
	public class AudioSnapshotManager : MonoBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private AudioMixerSnapshot inFocusSnapshot;

		[SerializeField]
		private AudioMixerSnapshot outOfFocusSnapshot;

		private bool windowFocused;

		private bool alphaDim;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void OnApplicationFocus(bool focus)
		{
		}

		private void Update()
		{
		}
	}
}
