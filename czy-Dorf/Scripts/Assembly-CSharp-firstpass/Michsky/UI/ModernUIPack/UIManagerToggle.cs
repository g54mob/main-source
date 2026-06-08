using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerToggle : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image border;

		public Image background;

		public Image check;

		public TextMeshProUGUI onLabel;

		public TextMeshProUGUI offLabel;

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
				UpdateToggle();
			}
		}

		private void LateUpdate()
		{
			if (UIManagerAsset != null)
			{
				if (Application.isEditor && UIManagerAsset != null)
				{
					dynamicUpdateEnabled = true;
					UpdateToggle();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateToggle()
		{
			try
			{
				border.color = UIManagerAsset.toggleBorderColor;
				background.color = UIManagerAsset.toggleBackgroundColor;
				check.color = UIManagerAsset.toggleCheckColor;
				onLabel.color = new Color(UIManagerAsset.toggleTextColor.r, UIManagerAsset.toggleTextColor.g, UIManagerAsset.toggleTextColor.b, onLabel.color.a);
				onLabel.font = UIManagerAsset.toggleFont;
				onLabel.fontSize = UIManagerAsset.toggleFontSize;
				offLabel.color = new Color(UIManagerAsset.toggleTextColor.r, UIManagerAsset.toggleTextColor.g, UIManagerAsset.toggleTextColor.b, offLabel.color.a);
				offLabel.font = UIManagerAsset.toggleFont;
				offLabel.fontSize = UIManagerAsset.toggleFontSize;
			}
			catch
			{
			}
		}
	}
}
