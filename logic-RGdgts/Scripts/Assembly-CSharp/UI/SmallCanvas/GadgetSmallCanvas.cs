using System;
using TMPro;
using UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SmallCanvas
{
	public class GadgetSmallCanvas : MonoBehaviour
	{
		private SerializedGadgetMetaData currentGadgetMetadata;

		[SerializeField]
		private Image openIcon;

		[SerializeField]
		private Image protectedIcon;

		[SerializeField]
		private Image questionMarkIcon;

		[SerializeField]
		private Image cameraIcon;

		[SerializeField]
		private Image wifiIcon;

		[SerializeField]
		private Image launcherIcon;

		[SerializeField]
		private TextMeshProUGUI author;

		[SerializeField]
		private UIButton authorButton;

		private ulong authorSteamId;

		[SerializeField]
		private TextMeshProUGUI lastShared;

		[SerializeField]
		private TextMeshProUGUI creationDate;

		[SerializeField]
		private TextMeshProUGUI lastEdited;

		[SerializeField]
		private Transform localLabels;

		public UIButton launcherButton;

		[SerializeField]
		private SteamVotesBar likesBar;

		public void Init(SerializedGadgetMetaData gadgetData, Action OpenLaucherSettings)
		{
		}

		public void SetMetadata(SerializedGadgetMetaData gadgetData)
		{
		}

		public void RefreshGadget()
		{
		}

		private void SetIcons()
		{
		}

		public void SetLauncherIcon()
		{
		}

		public void RefreshLikes(SerializedGadgetMetaData metadata)
		{
		}

		public void ClearData()
		{
		}

		private void ClearIcons()
		{
		}

		private void OpenGadgetCreatorUserProfile()
		{
		}

		public void RefreshButtonsGadgetState()
		{
		}
	}
}
