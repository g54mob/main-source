using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
	public enum PopUpAction
	{
		None = -1,
		GotoEmp = 0,
		GotoRoom = 1,
		GotoFurn = 2,
		GotoHR = 3,
		OpenInsurance = 4,
		OpenProductDetails = 5,
		OpenCompanyDetails = 6,
		OpenComplaints = 7
	}

	[Serializable]
	public class PopUp
	{
		public readonly string Icon;

		public readonly string Text;

		public readonly PopUpAction Action = PopUpAction.None;

		public readonly SDateTime Time;

		public readonly int Identifier;

		public uint[] ActionTarget;

		public readonly SVector3 textColor;

		public float Importance;

		public int CooldownDays = 6;

		public int SelectOffset;

		public PopUp(string t, string c, PopUpAction action, uint[] actionTarget, SDateTime time, int id, Color color, int cooldown)
		{
			Icon = c;
			Text = t;
			Time = time;
			Identifier = id;
			textColor = color;
			Action = action;
			ActionTarget = actionTarget;
			CooldownDays = cooldown;
		}

		public PopUp()
		{
		}
	}

	public enum PopupIDs
	{
		None = -1,
		Teamcompat = 0,
		Dirt = 1,
		Furniture = 2,
		Computer = 3,
		JobSatisfcation = 4,
		EmployeeCountProblem = 5,
		ServerProblems = 6,
		Marketing = 7,
		Bus = 8,
		ElectronicHeat = 9,
		BlockedOff = 10,
		Support = 11,
		TemperatureOverburdenend = 12,
		EmployeeWorkAssignment = 13,
		PCWarning = 14,
		FanWarning = 15,
		HRHireBudget = 16,
		CookStove = 17,
		LateProduct = 18,
		CourierParking = 19,
		ProductPrinterBackedUp = 20,
		ProjectManagement = 21,
		EmptyRoomGroup = 22,
		SubsidiaryOverwork = 23,
		StuckOnRoad = 24,
		ServingTray = 25,
		EmployeeDislike = 26,
		EmployeeStuck = 27,
		Fire = 28,
		GuardEntrance = 29,
		NoPlaceToEat = 30,
		DealRoomFail = 31,
		FurnitureInLimitedRoom = 32,
		FireFurn = 33,
		FormalComplaint = 34,
		NoFridge = 35,
		ComponentPrinterLimit = 36
	}

	public enum NotificationSound
	{
		Issue = 0,
		Warning = 1,
		Good = 2,
		Neutral = 3
	}

	public static HashSet<PopupIDs> MergeTargets = new HashSet<PopupIDs>
	{
		PopupIDs.Fire,
		PopupIDs.FireFurn,
		PopupIDs.TemperatureOverburdenend,
		PopupIDs.FurnitureInLimitedRoom,
		PopupIDs.Computer,
		PopupIDs.Furniture,
		PopupIDs.ComponentPrinterLimit
	};

	public GameObject ButtonPrefab;

	public Gradient ImportanceGradient;

	public RectTransform ButtonPanel;

	public RectTransform MainPanel;

	public Scrollbar Scroll;

	[NonSerialized]
	public List<GUIPopUp> PopupButtons = new List<GUIPopUp>();

	[NonSerialized]
	public Dictionary<int, GUIPopUp> PopupIDDict = new Dictionary<int, GUIPopUp>();

	public int MaxPops = 50;

	private float firstY;

	private float firstH;

	private bool isDragging;

	private GUIPopUp HasID(int id)
	{
		if (id == -1)
		{
			return null;
		}
		GUIPopUp value = null;
		if (PopupIDDict.TryGetValue(id, out value))
		{
			return value;
		}
		return null;
	}

	public static bool HasID(PopupIDs id)
	{
		if (id == PopupIDs.None)
		{
			return false;
		}
		if (HUD.Instance.popupManager == null)
		{
			return true;
		}
		return HUD.Instance.popupManager.PopupIDDict.ContainsKey((int)id);
	}

	private void PlaySFX(NotificationSound sfx)
	{
		UISoundFX.PlaySFX("Notification" + sfx);
	}

	public void AddPopup(string message, string icon, PopUpAction action, uint[] target, Color textColor, float importance, NotificationSound sfx, int cooldown, PopupIDs idd = PopupIDs.None)
	{
		AddPopup(message, icon, action, target, textColor, importance, sfx, cooldown, (int)idd);
	}

	public void UpdateCooldowns()
	{
		for (int i = 0; i < PopupButtons.Count - 1 && SDateTime.GetDays(PopupButtons[i].popup.Time, SDateTime.Now()) > (float)PopupButtons[i].popup.CooldownDays; i++)
		{
			UnityEngine.Object.Destroy(PopupButtons[i].gameObject);
		}
		if (PopupButtons.Count > 0)
		{
			GUIPopUp gUIPopUp = PopupButtons[PopupButtons.Count - 1];
			if (SDateTime.GetDays(gUIPopUp.popup.Time, SDateTime.Now()) > (float)gUIPopUp.popup.CooldownDays)
			{
				UnityEngine.Object.Destroy(gUIPopUp.gameObject);
			}
		}
	}

	public void AddPopup(string message, string icon, PopUpAction action, uint[] target, Color textColor, float importance, NotificationSound sfx, int cooldown, int id = -1)
	{
		GUIPopUp gUIPopUp = HasID(id);
		if (gUIPopUp == null)
		{
			PlaySFX(sfx);
			UpdateCooldowns();
			if (PopupButtons.Count > MaxPops)
			{
				UnityEngine.Object.Destroy(PopupButtons[0].gameObject);
			}
			PopUp popUp = new PopUp(message, icon, action, target, SDateTime.Now(), id, textColor, cooldown);
			popUp.Importance = importance;
			GameObject obj = UnityEngine.Object.Instantiate(ButtonPrefab);
			obj.transform.SetParent(ButtonPanel, false);
			GUIPopUp component = obj.GetComponent<GUIPopUp>();
			component.popup = popUp;
			component.MainImage.color = ImportanceGradient.Evaluate(Mathf.Clamp01(importance));
			PopupButtons.Add(component);
			PopupIDDict[id] = component;
			component.Made = Time.realtimeSinceStartup;
		}
		else
		{
			if (MergeTargets.Contains((PopupIDs)id))
			{
				HashSet<uint> hashSet = new HashSet<uint>(gUIPopUp.popup.ActionTarget);
				hashSet.AddRange(target);
				gUIPopUp.popup.ActionTarget = hashSet.ToArray();
			}
			if (importance > 1f && PopupButtons[PopupButtons.Count - 1] != gUIPopUp)
			{
				PlaySFX(sfx);
				gUIPopUp.transform.SetAsLastSibling();
				PopupButtons.Remove(gUIPopUp);
				PopupButtons.Add(gUIPopUp);
			}
		}
	}

	public void AddPopup(PopUp pop)
	{
		GameObject obj = UnityEngine.Object.Instantiate(ButtonPrefab);
		obj.transform.SetParent(ButtonPanel, false);
		GUIPopUp component = obj.GetComponent<GUIPopUp>();
		component.popup = pop;
		component.IsNew = false;
		component.MainImage.color = ImportanceGradient.Evaluate(pop.Importance);
		PopupButtons.Add(component);
		PopupIDDict[pop.Identifier] = component;
	}

	private void Update()
	{
		if (MainPanel.sizeDelta.y == 16f)
		{
			Scroll.value = 0f;
		}
		if (isDragging)
		{
			MainPanel.sizeDelta = new Vector2(MainPanel.sizeDelta.x, Mathf.Clamp(firstH - (Input.mousePosition.y / Options.UISize - firstY), 16f, (float)Screen.height / Options.UISize - 262f));
			return;
		}
		float num = 16f;
		int num2 = PopupButtons.Count - 1;
		while (num2 > -1 && (PopupButtons[num2].popup.Importance > 1f || (PopupButtons[num2].Made > -1f && Time.realtimeSinceStartup - PopupButtons[num2].Made < 10f * (1f + PopupButtons[num2].popup.Importance))))
		{
			num += PopupButtons[num2].panel.preferredHeight;
			num2--;
		}
		if (!(num < MainPanel.sizeDelta.y) || !RectTransformUtility.RectangleContainsScreenPoint(MainPanel, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 8f), UICamSize.GetUICam()))
		{
			float num3 = Mathf.Round(Mathf.Lerp(MainPanel.sizeDelta.y, num, Time.deltaTime * 16f));
			if (Mathf.Abs(num3 - num) < 2f)
			{
				num3 = num;
			}
			if (Mathf.Approximately(MainPanel.sizeDelta.y, 16f) && num > 16f)
			{
				UISoundFX.PlaySFX("PopupRolldown");
			}
			MainPanel.sizeDelta = new Vector2(MainPanel.sizeDelta.x, Mathf.Clamp(num3, 16f, Screen.height - 262));
		}
	}

	public void BeginDrag()
	{
		firstY = Mathf.Max((float)Screen.height / Options.UISize - MainPanel.sizeDelta.y, Input.mousePosition.y / Options.UISize);
		firstH = MainPanel.sizeDelta.y;
		PopupButtons.ForEach(delegate(GUIPopUp x)
		{
			x.Made = -1f;
		});
		isDragging = true;
	}

	public void EndDrag()
	{
		isDragging = false;
	}
}
