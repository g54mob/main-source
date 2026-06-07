using Aux;
using UnityEngine;
using UnityEngine.UI;

public class SetBestFit : ActiveComponent
{
	private Rect parentRect;

	private Text textComponent;

	private UpdateFontPS updateFont;

	private LocalizedText localizedText;

	private PlatformDependendSelfDestroy platformDependendSelfDestroy;

	public bool ignoreOnPS;

	private void Start()
	{
		Init();
		parentRect = Helper.GetWorldRect(base.transform.root.GetComponent<RectTransform>());
		textComponent = base.gameObject.GetComponent<Text>();
		updateFont = base.gameObject.GetComponent<UpdateFontPS>();
		localizedText = base.gameObject.GetComponent<LocalizedText>();
		platformDependendSelfDestroy = base.gameObject.GetComponent<PlatformDependendSelfDestroy>();
	}

	private void Update()
	{
		if (base.gameObject.activeInHierarchy && ActiveComponent.Program != null && ActiveComponent.Model.globalSaves != null && Logic.GetController().objectInitFinished && (updateFont == null || !updateFont.forceSelfDestroy) && (localizedText == null || !localizedText.selfDestroy) && platformDependendSelfDestroy == null && parentRect.Contains(base.transform.position))
		{
			textComponent.resizeTextForBestFit = true;
			Object.Destroy(this);
		}
	}

	private void LateUpdate()
	{
		if (base.gameObject.activeInHierarchy && ActiveComponent.Program != null && ActiveComponent.Model.globalSaves != null && Logic.GetController().objectInitFinished && (updateFont == null || !updateFont.forceSelfDestroy) && (localizedText == null || !localizedText.selfDestroy) && platformDependendSelfDestroy == null && parentRect.Contains(base.transform.position))
		{
			textComponent.resizeTextForBestFit = true;
			Object.Destroy(this);
		}
	}
}
