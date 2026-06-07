using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CathubBtn : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public int index;

	private Cathub cathub;

	[SceneBind("CatHub")]
	private Image CatHubImg;

	[SceneBind("DarkLayer")]
	private Image Darklayer;

	[SceneBind("BackLayer")]
	private Image Backlayer;

	private Image selfImg;

	private static List<CathubBtn> CathubObjects = new List<CathubBtn>();

	public void OnPointerEnter(PointerEventData eventData)
	{
		CatHubImg.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CatHubImg.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		selfImg = base.transform.GetComponent<Image>();
		base.transform.GetComponent<Button>().onClick.AddListener(OnClicked);
	}

	public void OnClicked()
	{
		if (index == cathub.GetCurrentScheme())
		{
			SaveScheme();
			ActiveComponent.Model.construction.GetCurCathub().SetUseAsCustom(index);
			ActiveComponent.Model.construction.ReInitConstructionArea(resetInOut: false);
			return;
		}
		CathubScheme scheme = cathub.GetScheme(index);
		ActiveComponent.Model.construction.GetCurCathub().ClearHistory();
		if (scheme == null || !scheme.IsValid())
		{
			SaveScheme(saveInMemory: false);
			LoadScheme();
			SaveScheme();
		}
		else
		{
			RestoreScheme();
			SaveScheme();
		}
		UpdateButtons();
		ActiveComponent.Model.construction.ReInitConstructionArea(resetInOut: false);
	}

	private void UpdateButtons()
	{
		foreach (CathubBtn cathubButton in GetCathubButtons())
		{
			cathubButton.Refresh();
		}
		CathubObjects.Clear();
	}

	public void Refresh()
	{
		SetActiveScheme(cathub.GetCurrentScheme() == index);
	}

	private List<CathubBtn> GetCathubButtons()
	{
		if (CathubObjects.Count == 0)
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("CAT_HUB");
			if (array.Length != 0)
			{
				CathubObjects = new List<CathubBtn>();
				GameObject[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					CathubBtn component = array2[i].GetComponent<CathubBtn>();
					CathubObjects.Add(component);
				}
			}
		}
		return CathubObjects;
	}

	private bool IsValid()
	{
		CathubScheme scheme = cathub.GetScheme(index);
		if (scheme == null || !scheme.IsValid())
		{
			return index == 0;
		}
		return true;
	}

	private void SaveScheme(bool saveInMemory = true)
	{
		ActiveComponent.Model.construction.AutoSave(Construction.Info.ShowNothing, saveInMemory);
		Logic.SaveCurCathub();
	}

	private void LoadScheme(bool changeZoomAndPos = true)
	{
		CathubScheme scheme = cathub.GetScheme(index);
		ActiveComponent.Model.construction.ClearCanvasScheme();
		ActiveComponent.Model.construction.GetCurCathub().ClearHistory();
		if (scheme != null)
		{
			if (scheme.IsValid())
			{
				ActiveComponent.Model.Scheme = DeserializeObject<SchemeBlock>(scheme.json);
			}
			else
			{
				ActiveComponent.Model.Scheme = GetEmptyScheme();
			}
			ActiveComponent.Model.construction.LoadFromScheme(ActiveComponent.Model.Scheme, changeZoomAndPos);
			scheme.json = SerializeObject(ActiveComponent.Model.Scheme);
			if (!cathub.SetScheme(index, scheme))
			{
				throw new Exception("Can't serialize previous scheme");
			}
		}
		ActiveComponent.Model.construction.GetCurCathub().RecordHistory();
		ActiveComponent.Model.construction.RedoUndoButtonsStatesUpdate();
	}

	private SchemeBlock GetEmptyScheme()
	{
		SchemeBlock schemeBlock = new SchemeBlock();
		schemeBlock.Init(ActiveComponent.Model.construction);
		return schemeBlock;
	}

	private ColorBlock GetColors()
	{
		return base.gameObject.GetComponent<Button>().colors;
	}

	public void SetColor(Color color, bool setDisabledColor = true)
	{
		CatHubImg.color = color;
	}

	public void SetScale(float scale)
	{
		base.gameObject.GetComponent<RectTransform>().localScale = Vector3.one * scale;
	}

	public Color GetColor()
	{
		return GetColors().normalColor;
	}

	public Color GetHighlightColor()
	{
		return GetColors().highlightedColor;
	}

	public Color GetPressedColor()
	{
		return GetColors().pressedColor;
	}

	public void SetActiveScheme(bool state = true)
	{
		Backlayer.gameObject.SetActive(state);
		Darklayer.gameObject.SetActive(!state);
		if (IsValid())
		{
			SetColor(Logic.GetColor("GREEN"));
		}
		else
		{
			SetColor(Color.grey);
		}
	}

	private bool RestoreScheme()
	{
		try
		{
			SaveScheme(saveInMemory: false);
			LoadScheme();
			return true;
		}
		catch (Exception ex)
		{
			Debug.Log("Cathub scheme load failed: " + ex.Message);
		}
		return false;
	}

	public void SetCathub(Cathub c)
	{
		cathub = c;
	}

	public string SerializeObject(object obj)
	{
		return JsonConvert.SerializeObject(obj, Formatting.None, Logic.GetGlobalSettings());
	}

	public T DeserializeObject<T>(string json)
	{
		return JsonConvert.DeserializeObject<T>(json, Logic.GetGlobalSettings());
	}
}
