using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrestigeButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject Tooltip;

	private static Tween _shakeAnimation = null;

	private static DateTime _lastShake = DateTime.Now;

	private const float SHAKE_DELAY = 200f;

	public void OnPointerEnter(PointerEventData eventData)
	{
		ShowTooltip();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HideTooltip();
	}

	public void OnDeselect(PointerEventData eventData)
	{
		HideTooltip();
	}

	private void ShowTooltip()
	{
		if (GameController.Instance.PrestigeCount < GameController.GetMaxPrestigeCount())
		{
			Tooltip.gameObject.SetActive(value: true);
			Tooltip.transform.Find("Title").GetComponent<TMP_Text>().text = PanelTitle.GetTitle("Earthquake", GameController.Instance.PrestigeCount + 1);
			Tooltip.transform.Find("Amount").GetComponent<TMP_Text>().text = GameController.Instance.PrestigeCount + "/" + GameController.GetMaxPrestigeCount();
			string text = "";
			text += "When the hole is full, an earthquake will empty it, destroy all buildings and remove money.\n\n";
			text = text + "+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetPrestigeDestroyPercentage()) + " $ spent converted to trash\n";
			text += "+1 blue shard\n";
			text = text + "+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetPrestigeMoneyKeptPercentage()) + " current $ converted to trash\n";
			text += "Increase cost of buildings";
			Tooltip.transform.Find("Description").GetComponent<TMP_Text>().text = text;
			if ((_shakeAnimation == null || !_shakeAnimation.active) && (DateTime.Now - _lastShake).TotalMilliseconds >= 200.0)
			{
				GlobalSfx2Controller.Instance.PlayOneWithPitch(SoundManager.SoundTypeEnum.ui_button2_hover);
				_shakeAnimation = Tooltip.GetComponent<RectTransform>().DOShakeRotation(0.1f, new Vector3(0f, 0f, 5f)).SetLoops(2, LoopType.Restart);
			}
		}
		else
		{
			Tooltip.gameObject.SetActive(value: true);
			Tooltip.transform.Find("Title").GetComponent<TMP_Text>().text = "Fill Up The Hole";
			Tooltip.transform.Find("Amount").GetComponent<TMP_Text>().text = "";
			string text2 = ((!Installation.IsDemo()) ? "This will be the end. The statue is waiting. Fill up the hole one more time to reach the statue.\n\nAfter reaching the statue, the game can continue in Endless Mode." : "This will be the end of the demo.");
			Tooltip.transform.Find("Description").GetComponent<TMP_Text>().text = text2;
			if ((_shakeAnimation == null || !_shakeAnimation.active) && (DateTime.Now - _lastShake).TotalMilliseconds >= 200.0)
			{
				GlobalSfx2Controller.Instance.PlayOneWithPitch(SoundManager.SoundTypeEnum.ui_button2_hover);
				_shakeAnimation = Tooltip.GetComponent<RectTransform>().DOShakeRotation(0.1f, new Vector3(0f, 0f, 5f)).SetLoops(2, LoopType.Restart);
			}
		}
	}

	private void HideTooltip()
	{
		_lastShake = DateTime.Now;
		Tooltip.gameObject.SetActive(value: false);
	}

	public void ExecutePrestige()
	{
		if (GameController.Instance.PrestigeCount < GameController.GetMaxPrestigeCount())
		{
			HideTooltip();
			GameController.Instance.ExecutePrestige();
		}
		else
		{
			ScreenCanvasController.Instance.ProcessEndOfGame();
		}
	}
}
