using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SmallCanvas
{
	public class GadgetBrowserSmallPanel : MonoBehaviour
	{
		private SerializedGadgetMetaData currentGadgetMetadata;

		[SerializeField]
		private UIText gadgetName;

		[SerializeField]
		private SteamVotesBar likesBar;

		[SerializeField]
		private UIText author;

		[SerializeField]
		private UIText lastShared;

		[SerializeField]
		private UIText artTag;

		[SerializeField]
		private UIText codeTag;

		[SerializeField]
		private UIText audioTag;

		[SerializeField]
		private UIText gameTag;

		[SerializeField]
		private UIText toolTag;

		[SerializeField]
		private UIText gamepadTag;

		[SerializeField]
		private UIText keyboardTag;

		[SerializeField]
		private UIText assetsTag;

		[SerializeField]
		private UIText templateTag;

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
		private UIText tagDots;

		public GameObject allElements;

		private Dictionary<GadgetTags, UIText> tagButtonDict;

		public void Init()
		{
		}

		public void SetMetadata(SerializedGadgetMetaData gadgetData)
		{
		}

		public void RefreshGadget()
		{
		}

		public void SetLauncherIcon()
		{
		}

		private void ClearIcons()
		{
		}

		public void ClearData()
		{
		}

		private void ManageTags()
		{
		}
	}
}
