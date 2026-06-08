using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerProgressBar : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image bar;

		public Image background;

		public TextMeshProUGUI label;

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
				UpdateProgressBar();
			}
		}

		private void LateUpdate()
		{
			if (Application.isEditor && UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateProgressBar();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateProgressBar()
		{
			try
			{
				bar.color = UIManagerAsset.progressBarColor;
				background.color = UIManagerAsset.progressBarBackgroundColor;
				label.color = UIManagerAsset.progressBarLabelColor;
				label.font = UIManagerAsset.progressBarLabelFont;
				label.fontSize = UIManagerAsset.progressBarLabelFontSize;
			}
			catch
			{
			}
		}
	}
}
