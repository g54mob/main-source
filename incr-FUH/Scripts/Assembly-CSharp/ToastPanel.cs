using UnityEngine;

public class ToastPanel : MonoBehaviour
{
	public ToastPanelItem ItemTemplate;

	private void Start()
	{
		ItemTemplate.gameObject.SetActive(value: false);
	}

	private void Update()
	{
	}

	public void AddItem(string text)
	{
		ToastPanelItem toastPanelItem = Object.Instantiate(ItemTemplate, base.transform);
		toastPanelItem.Initialize(text);
		toastPanelItem.gameObject.SetActive(value: true);
		GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_toast_pop);
	}
}
