using System.Collections.Generic;
using App.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CatController : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SceneBind("BuyWindow/Yes")]
	private Button yes;

	[SceneBind("BuyWindow/No")]
	private Button no;

	[SceneBind("RightClick")]
	private Button RightBtn;

	[SceneBind("LeftClick")]
	private Button LeftBtn;

	[SceneBind("UnderLeft")]
	private Image UnderLeft;

	[SceneBind("Layer")]
	private Image Layer;

	[SceneBind("CREDIT")]
	private Image Credit;

	[SceneBind("UnderRight")]
	private Image UnderRight;

	[SceneBind("BuyWindow/Text")]
	private Text text;

	[SceneBind("BuyWindow")]
	private Image buyWindow;

	private List<GameObject> VRs = new List<GameObject>();

	protected override void RightSwipe()
	{
		PrevCat(cycle: true);
	}

	protected override void LeftSwipe()
	{
		NextCat(cycle: true);
	}

	protected override void UpSwipe()
	{
		PrevCat(cycle: true);
	}

	protected override void DownSwipe()
	{
		NextCat(cycle: true);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!Credit.gameObject.activeSelf)
		{
			if (!ActiveComponent.Model.CurInputDeviceIsController)
			{
				LeftBtn.gameObject.SetActive(value: true);
				UnderLeft.gameObject.SetActive(value: true);
				RightBtn.gameObject.SetActive(value: true);
				UnderRight.gameObject.SetActive(value: true);
			}
			if (ActiveComponent.Model.P.curCat == 0)
			{
				LeftBtn.gameObject.SetActive(value: false);
				UnderLeft.gameObject.SetActive(value: false);
			}
			if (ActiveComponent.Model.P.curCat == ActiveComponent.Model.P.unlockedCatHats.Count - 1)
			{
				RightBtn.gameObject.SetActive(value: false);
				UnderRight.gameObject.SetActive(value: false);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Redraw();
		LeftBtn.gameObject.SetActive(value: false);
		UnderLeft.gameObject.SetActive(value: false);
		RightBtn.gameObject.SetActive(value: false);
		UnderRight.gameObject.SetActive(value: false);
		buyWindow.gameObject.SetActive(value: false);
	}

	public void Redraw()
	{
		RedrawVR(ActiveComponent.Model.P.unlockedCatHats[ActiveComponent.Model.P.curCat].KeyName);
	}

	private void RedrawVR(string KeyName)
	{
		KeyName = KeyName.ToLower();
		if (ActiveComponent.Model.P.credits.Count > 0)
		{
			KeyName = "CREDIT";
		}
		Credit.gameObject.SetActive(KeyName.ToLower() == "CREDIT".ToLower());
		if (KeyName == "DEFAULTCAT".ToLower())
		{
			DateEvent curDateEvent = Logic.GetCurDateEvent();
			KeyName = ((curDateEvent == null) ? "DEFAULT".ToLower() : curDateEvent.KeyName.ToLower());
		}
		foreach (GameObject vR in VRs)
		{
			if (vR.name.ToLower() == KeyName)
			{
				vR.gameObject.SetActive(value: true);
			}
			else
			{
				if (!(vR.transform != base.transform))
				{
					continue;
				}
				foreach (CatVR item in ActiveComponent._staticData.CatCost)
				{
					if (item.KeyName.ToLower() == vR.name.ToLower())
					{
						vR.gameObject.SetActive(value: false);
					}
				}
				foreach (DateEvent dateEvent in ActiveComponent._staticData.DateEvents)
				{
					if (dateEvent.KeyName.ToLower() == vR.name.ToLower())
					{
						vR.gameObject.SetActive(value: false);
					}
				}
				if (vR.name.ToLower() == "DEFAULT".ToLower())
				{
					vR.gameObject.SetActive(value: false);
				}
				foreach (CatVR promoCat in ActiveComponent._staticData.PromoCats)
				{
					if (promoCat.KeyName.ToLower() == vR.name.ToLower())
					{
						vR.gameObject.SetActive(value: false);
					}
				}
			}
		}
		base.gameObject.GetComponent<ZoomOnMouse>().enabled = KeyName.ToLower() != "CREDIT".ToLower();
		base.gameObject.GetComponent<SoundClickController>().enabled = KeyName.ToLower() != "CREDIT".ToLower();
	}

	private void Start()
	{
	}

	private void PrevCat(bool cycle = false)
	{
		if (cycle || ActiveComponent.Model.P.curCat != 0)
		{
			if (ActiveComponent.Model.P.curCat == 0)
			{
				ActiveComponent.Model.P.curCat = ActiveComponent.Model.P.unlockedCatHats.Count - 1;
			}
			else
			{
				ActiveComponent.Model.P.curCat--;
			}
			RedrawVR(ActiveComponent.Model.P.unlockedCatHats[ActiveComponent.Model.P.curCat].KeyName);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			if (!ActiveComponent.Model.CurInputDeviceIsController)
			{
				LeftBtn.gameObject.SetActive(value: true);
				UnderLeft.gameObject.SetActive(value: true);
				RightBtn.gameObject.SetActive(value: true);
				UnderRight.gameObject.SetActive(value: true);
			}
			if (ActiveComponent.Model.P.curCat == 0)
			{
				LeftBtn.gameObject.SetActive(value: false);
				UnderLeft.gameObject.SetActive(value: false);
			}
		}
	}

	private void NextCat(bool cycle = false)
	{
		if (cycle || ActiveComponent.Model.P.curCat != ActiveComponent.Model.P.unlockedCatHats.Count - 1)
		{
			ActiveComponent.Model.P.curCat = (ActiveComponent.Model.P.curCat + 1) % ActiveComponent.Model.P.unlockedCatHats.Count;
			RedrawVR(ActiveComponent.Model.P.unlockedCatHats[ActiveComponent.Model.P.curCat].KeyName);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			if (!ActiveComponent.Model.CurInputDeviceIsController)
			{
				LeftBtn.gameObject.SetActive(value: true);
				UnderLeft.gameObject.SetActive(value: true);
				RightBtn.gameObject.SetActive(value: true);
				UnderRight.gameObject.SetActive(value: true);
			}
			if (ActiveComponent.Model.P.curCat == ActiveComponent.Model.P.unlockedCatHats.Count - 1)
			{
				RightBtn.gameObject.SetActive(value: false);
				UnderRight.gameObject.SetActive(value: false);
			}
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			VRs.Add(transform.gameObject);
		}
		if (ActiveComponent.Model.P != null)
		{
			RedrawVR(ActiveComponent.Model.P.unlockedCatHats[ActiveComponent.Model.P.curCat].KeyName);
		}
		buyWindow.gameObject.SetActive(value: false);
		RightBtn.onClick.AddListener(delegate
		{
			NextCat();
		});
		LeftBtn.onClick.AddListener(delegate
		{
			PrevCat();
		});
		LeftBtn.gameObject.SetActive(value: false);
		UnderLeft.gameObject.SetActive(value: false);
		RightBtn.gameObject.SetActive(value: false);
		UnderRight.gameObject.SetActive(value: false);
		dragDistance = (float)Screen.height * 5f / 100f;
	}

	private void Update()
	{
		if (base.IsInited && !ActiveComponent._controller.Inbox.gameObject.activeSelf && !ActiveComponent._controller.construction.gameObject.activeSelf && !ActiveComponent._controller.Tree.gameObject.activeSelf && !ActiveComponent._controller.buy.gameObject.activeSelf)
		{
			CheckMobilInput();
			CheckJoyConInput();
		}
	}
}
