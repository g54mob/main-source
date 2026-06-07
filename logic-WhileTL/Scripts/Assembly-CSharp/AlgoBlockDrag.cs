using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlgoBlockDrag : ActiveComponent, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IPointerExitHandler, IPointerClickHandler, IPointerEnterHandler
{
	public bool dragged;

	public int num;

	[SceneBind("Info")]
	private Button Info;

	[SceneBind("Grey")]
	private Image Grey;

	[SceneBind("InfoTutorial")]
	public Image InfoTutorial;

	public string KeyName;

	private BlockTutuorial tutuorial;

	private GameObject pref;

	public GameObject text;

	private Sprite showSprite;

	private Image image;

	public void InfoClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		tutuorial.gameObject.SetActive(value: true);
		ActiveComponent.Model.construction.NewBlockTutorialIndicator.gameObject.SetActive(value: false);
		tutuorial.Redraw(KeyName, pref);
		Logic.SendAnalytics("CONSTRUCTION_TUTNODE_OPEN", new Dictionary<string, object> { { "keyName", KeyName } });
		ActiveComponent.Model.P.infotutorial = true;
		InfoTutorial.gameObject.SetActive(value: false);
		ActiveComponent.Model.construction.SetInfotutorialsState(state: false);
	}

	public void Init(string keyName, BlockTutuorial link, GameObject prefab, bool isCustom)
	{
		KeyName = keyName;
		tutuorial = link;
		pref = prefab;
		SceneBindContainer.BindObjects(this, base.transform);
		Info.onClick.AddListener(InfoClick);
		InfoTutorial.gameObject.SetActive(value: false);
		Info.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.infotutorial = true;
		}
	}

	public void SetInfoTutorialState(bool state)
	{
	}

	public void UpdateLayerInfo()
	{
		Info.transform.SetParent(base.transform.parent);
		Info.transform.SetParent(base.transform);
	}

	private void Start()
	{
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (Input.touchCount <= 1)
		{
			dragged = eventData.button == PointerEventData.InputButton.Left;
		}
	}

	private Texture2D LoadTexture(SchemeBlock sh)
	{
		Texture2D texture2D = new Texture2D(Screen.width, Screen.height);
		if (sh.Image != "")
		{
			texture2D.LoadImage(Convert.FromBase64String(sh.Image));
			texture2D.Apply();
		}
		else
		{
			texture2D = null;
		}
		return texture2D;
	}

	private Sprite LoadSpriteSheme(SchemeBlock sh)
	{
		return null;
	}

	public void SetShowImage(Image showImg)
	{
		image = showImg;
	}

	public void SetShowSpriteByName(SchemeBlock sh)
	{
		showSprite = LoadSpriteSheme(sh);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		dragged = false;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		dragged = false;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (showSprite != null)
		{
			image.gameObject.SetActive(value: true);
			image.sprite = showSprite;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
}
