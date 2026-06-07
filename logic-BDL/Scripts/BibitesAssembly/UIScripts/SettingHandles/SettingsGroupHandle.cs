using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class SettingsGroupHandle : SettingsListHandle
	{
		private SettingsGroupReference GroupRef;

		public override void CreateUIElement(GameObject _parent)
		{
			GroupRef = Object.Instantiate(UIPrefabsHolder.Instance.SettingGroupPrefab, _parent.transform).GetComponent<SettingsGroupReference>();
			if (string.IsNullOrEmpty(GroupTitle))
			{
				Object.Destroy(GroupRef.titleText.gameObject);
			}
			else
			{
				GroupRef.titleText.text = GroupTitle;
			}
			Settings?.ForEach(delegate(ISettingHandle _r)
			{
				_r.CreateUIElement(GroupRef.settingsHolder);
			});
		}

		public override void HideUIElement()
		{
			GroupRef.gameObject.SetActive(value: false);
		}

		public override void ShowUIElement()
		{
			GroupRef.gameObject.SetActive(value: true);
		}
	}
}
