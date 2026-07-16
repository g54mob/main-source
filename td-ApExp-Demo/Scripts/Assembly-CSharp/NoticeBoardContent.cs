using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoticeBoardContent : MonoBehaviour, IMoveHandler, IEventSystemHandler
{
	[NonSerialized]
	public int Index;

	public Image iconBorder;

	public Image mask;

	public Image hoverImg;

	public Image slotImg;

	public Image icon;

	public new TextMeshProUGUI name;

	[NonSerialized]
	public Sprite hoverSprite;

	[NonSerialized]
	public Sprite selectedSprite;

	[SerializeField]
	private GameObject lockImg;

	[SerializeField]
	private Image iconBackgroundColor;

	public static Action OnNBCNavigate;

	public void OnMove(AxisEventData eventData)
	{
		OnNBCNavigate?.Invoke();
		GetComponent<UnitAudioController>().PlayChannel0();
	}

	public void Lock()
	{
		lockImg.SetActive(value: true);
	}

	public void Unlock()
	{
		lockImg.SetActive(value: false);
		iconBackgroundColor.color = new Color(1f, 1f, 1f);
	}
}
