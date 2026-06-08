using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerNotification : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image background;

		public Image icon;

		public TextMeshProUGUI title;

		public TextMeshProUGUI description;

		private bool dynamicUpdateEnabled;

		private void OnEnable()
		{
			if (UIManagerAsset == null)
			{
				try
				{
					UIManagerAsset = Resources.Load<UIManager>("MUIP Manager");
				}
				catch
				{
					Debug.LogWarning("No UI Manager found. Assign it manually, otherwise you'll get errors about it.", this);
				}
			}
		}

		private void Awake()
		{
			if (!dynamicUpdateEnabled)
			{
				base.enabled = true;
				UpdateNotification();
			}
		}

		private void LateUpdate()
		{
			if (Application.isEditor && UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateNotification();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateNotification()
		{
			try
			{
				background.color = UIManagerAsset.notificationBackgroundColor;
				icon.color = UIManagerAsset.notificationIconColor;
				title.color = UIManagerAsset.notificationTitleColor;
				description.color = UIManagerAsset.notificationDescriptionColor;
				title.font = UIManagerAsset.notificationTitleFont;
				title.fontSize = UIManagerAsset.notificationTitleFontSize;
				description.font = UIManagerAsset.notificationDescriptionFont;
				description.fontSize = UIManagerAsset.notificationDescriptionFontSize;
			}
			catch
			{
			}
		}
	}
}
