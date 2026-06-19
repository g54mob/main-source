using System.Collections.Generic;
using UnityEngine;

public class WorldContentBundleOption : MonoBehaviour
{
	public WorldContentMenu worldContentMenu;

	public RadicalMenuOption_Apply addButton;

	public PugText title;

	public PugText description;

	public PugText dependencyText;

	public SpriteRenderer notificationIcon;

	private ContentBundleDataBlock _currentContentBundle;

	public ContentBundleDataBlock CurrentContentBundle
	{
		get
		{
			return _currentContentBundle;
		}
		set
		{
			if (!(_currentContentBundle == value))
			{
				title.SetText(WorldContentMenu.GetContentBundleTitle(value));
				title.Render();
				description.SetText(WorldContentMenu.GetContentBundleDescription(value));
				description.Render();
				_currentContentBundle = value;
				ClearDependencies();
			}
		}
	}

	public void SetNotificationStatus(bool notificationActive)
	{
		notificationIcon.gameObject.SetActive(notificationActive);
	}

	public void ShakeDependencyText()
	{
		dependencyText.StartCoroutine(EffectCoroutines.Shake(dependencyText.transform));
	}

	public void SetDependencies(List<ContentBundleDataBlock> dependencies)
	{
		if (dependencies == null || dependencies.Count == 0)
		{
			ClearDependencies();
			return;
		}
		string text = PugText.ProcessText(WorldContentMenu.GetContentBundleTitle(dependencies[0]), null, shouldLocalize: true, shouldLocalizeFormatFields: false);
		PugText pugText = dependencyText;
		string text2 = ((dependencies.Count != 1) ? "Menu/MissingContentDependencyMultiple" : "Menu/MissingContentDependencySingle");
		pugText.SetText(text2);
		PugText pugText2 = dependencyText;
		string[] formatFields = ((dependencies.Count != 1) ? new string[2]
		{
			text,
			(dependencies.Count - 1).ToString()
		} : new string[1] { text });
		pugText2.formatFields = formatFields;
		dependencyText.MarkUIComponentAsDirty(render: true);
		dependencyText.gameObject.SetActive(value: true);
	}

	private void ClearDependencies()
	{
		dependencyText.SetText("");
		dependencyText.gameObject.SetActive(value: false);
		dependencyText.MarkUIComponentAsDirty(render: true);
	}

	public void SetAvailable(bool available)
	{
		addButton.SetInteractable(available);
		dependencyText.color = (available ? Color.green : Color.red);
	}

	public void OnAdd()
	{
		worldContentMenu.OnAdd(CurrentContentBundle);
	}
}
