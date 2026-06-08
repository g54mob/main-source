using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerTooltip : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image background;

		public TextMeshProUGUI text;

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
			}
		}

		private void LateUpdate()
		{
			if (UIManagerAsset != null)
			{
				if (Application.isEditor && UIManagerAsset != null)
				{
					dynamicUpdateEnabled = true;
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}
	}
}
