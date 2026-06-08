using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerModalWindow : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image background;

		public Image contentBackground;

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
				UpdateModalWindow();
			}
		}

		private void LateUpdate()
		{
			if (Application.isEditor && UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateModalWindow();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateModalWindow()
		{
			try
			{
				background.color = UIManagerAsset.modalWindowBackgroundColor;
				contentBackground.color = UIManagerAsset.modalWindowContentPanelColor;
				icon.color = UIManagerAsset.modalWindowIconColor;
				title.color = UIManagerAsset.modalWindowTitleColor;
				description.color = UIManagerAsset.modalWindowDescriptionColor;
				title.font = UIManagerAsset.modalWindowTitleFont;
				description.font = UIManagerAsset.modalWindowContentFont;
			}
			catch
			{
			}
		}
	}
}
