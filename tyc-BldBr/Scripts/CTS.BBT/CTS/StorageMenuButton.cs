using System;
using CTS.UI;
using UnityEngine.Localization;

namespace CTS
{
	[Obsolete]
	public class StorageMenuButton : InterfaceButton
	{
		private ToolTipsShower _toolTips;

		private LocalizedString _storageString;

		private LocalizedString _morgueString;

		public static StorageMenuButton Instance { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			_toolTips = GetComponent<ToolTipsShower>();
			Instance = this;
		}

		private void OnDestroy()
		{
			Instance = null;
		}

		public void ForceShow()
		{
			canvasToShow.QuickShow();
			for (int i = 0; i < canvasToHide.Length; i++)
			{
				canvasToHide[i].QuickHide();
			}
		}
	}
}
