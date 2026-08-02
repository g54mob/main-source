using UnityEngine;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(SettingsElement))]
	public class SettingsDescription : MonoBehaviour
	{
		[Header("Resources")]
		public SettingsDescriptionManager manager;

		public SettingsElement element;

		[Header("Content")]
		[SerializeField]
		private Sprite cover;

		[SerializeField]
		private string title = "Title";

		[SerializeField]
		[TextArea]
		private string description = "Description area.";

		[Header("Localization")]
		[SerializeField]
		private string titleKey;

		[SerializeField]
		private string descriptionKey;

		private void Start()
		{
			if (manager == null && Object.FindObjectsOfType(typeof(SettingsDescriptionManager)).Length != 0)
			{
				manager = (SettingsDescriptionManager)Object.FindObjectsOfType(typeof(SettingsDescriptionManager))[0];
			}
			else if (manager == null)
			{
				Object.Destroy(this);
			}
			if (element == null)
			{
				element = base.gameObject.GetComponent<SettingsElement>();
			}
			element.onHover.AddListener(delegate
			{
				UpdateManager();
			});
			element.onLeave.AddListener(delegate
			{
				SetManagerToDefault();
			});
		}

		public void UpdateManager()
		{
			if (!(manager == null))
			{
				if (manager.localizedObject != null && manager.useLocalization && !string.IsNullOrEmpty(titleKey) && !string.IsNullOrEmpty(descriptionKey))
				{
					manager.UpdateUI(manager.localizedObject.GetKeyOutput(titleKey), manager.localizedObject.GetKeyOutput(descriptionKey), cover);
				}
				else
				{
					manager.UpdateUI(title, description, cover);
				}
			}
		}

		public void SetManagerToDefault()
		{
			if (!(manager == null))
			{
				manager.SetDefault();
			}
		}
	}
}
