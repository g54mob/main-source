using DV.UIFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class GraphicsReferences : MonoBehaviour
	{
		public const string ICON_PREFIX = "[icon]";

		public const string TMPRO_PREFIX = "[text]";

		public Image icon;

		public TMP_Text label;

		private bool initialized;

		private void Awake()
		{
			Initialize();
		}

		public void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				if (icon == null)
				{
					icon = DV.UIFramework.Util.FindInChildren<Image>(base.gameObject, "[icon]", logMissing: false);
				}
				if (label == null)
				{
					label = DV.UIFramework.Util.FindInChildren<TMP_Text>(base.gameObject, "[text]", logMissing: false);
				}
			}
		}
	}
}
