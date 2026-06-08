using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerProgressBarLoop : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public bool hasBackground;

		public bool useRegularBackground;

		public Image bar;

		public Image background;

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
			if (UIManagerAsset != null)
			{
				if (Application.isEditor && UIManagerAsset != null)
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
				if (hasBackground)
				{
					if (useRegularBackground)
					{
						background.color = UIManagerAsset.progressBarBackgroundColor;
					}
					else
					{
						background.color = UIManagerAsset.progressBarLoopBackgroundColor;
					}
				}
			}
			catch
			{
			}
		}
	}
}
