using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerScrollbar : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image background;

		public Image bar;

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
				UpdateScrollbar();
			}
		}

		private void LateUpdate()
		{
			if (UIManagerAsset != null)
			{
				if (Application.isEditor && UIManagerAsset != null)
				{
					dynamicUpdateEnabled = true;
					UpdateScrollbar();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateScrollbar()
		{
			try
			{
				background.color = UIManagerAsset.scrollbarBackgroundColor;
				bar.color = UIManagerAsset.scrollbarColor;
			}
			catch
			{
			}
		}
	}
}
