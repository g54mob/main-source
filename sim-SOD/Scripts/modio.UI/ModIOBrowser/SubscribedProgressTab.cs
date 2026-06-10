using ModIO;
using ModIOBrowser.Implementation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class SubscribedProgressTab : MonoBehaviour
	{
		public GameObject progressBar;

		public Image progressBarFill;

		public TMP_Text progressBarText;

		public GameObject progressBarQueuedOutline;

		public ModProfile profile;

		private Translation progressBarTextTranslation;

		public void Setup(ModProfile profile)
		{
		}

		public void MimicOtherProgressTab(SubscribedProgressTab other)
		{
		}

		public void UpdateProgress(ProgressHandle handle)
		{
		}

		internal void UpdateStatus(ModManagementEventType updatedStatus, ModId id)
		{
		}
	}
}
