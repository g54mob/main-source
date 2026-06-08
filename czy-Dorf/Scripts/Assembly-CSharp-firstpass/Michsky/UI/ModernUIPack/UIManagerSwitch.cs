using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerSwitch : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image border;

		public Image background;

		public Image handleOn;

		public Image handleOff;

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
				UpdateSwitch();
			}
		}

		private void LateUpdate()
		{
			if (UIManagerAsset != null)
			{
				if (Application.isEditor && UIManagerAsset != null)
				{
					dynamicUpdateEnabled = true;
					UpdateSwitch();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateSwitch()
		{
			try
			{
				border.color = new Color(UIManagerAsset.switchBorderColor.r, UIManagerAsset.switchBorderColor.g, UIManagerAsset.switchBorderColor.b, border.color.a);
				background.color = new Color(UIManagerAsset.switchBackgroundColor.r, UIManagerAsset.switchBackgroundColor.g, UIManagerAsset.switchBackgroundColor.b, background.color.a);
				handleOn.color = new Color(UIManagerAsset.switchHandleOnColor.r, UIManagerAsset.switchHandleOnColor.g, UIManagerAsset.switchHandleOnColor.b, handleOn.color.a);
				handleOff.color = new Color(UIManagerAsset.switchHandleOffColor.r, UIManagerAsset.switchHandleOffColor.g, UIManagerAsset.switchHandleOffColor.b, handleOff.color.a);
			}
			catch
			{
			}
		}
	}
}
