using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerContextMenu : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image backgroundImage;

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
					Debug.Log("No UI Manager found. Assign it manually, otherwise you'll get errors about it.", this);
				}
			}
		}

		private void Awake()
		{
			if (!dynamicUpdateEnabled)
			{
				base.enabled = true;
				UpdateContextMenu();
			}
		}

		private void LateUpdate()
		{
			if (Application.isEditor && UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateContextMenu();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateContextMenu()
		{
			backgroundImage.color = UIManagerAsset.contextBackgroundColor;
		}
	}
}
