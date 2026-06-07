using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIPopUp : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler
{
	public LayoutElement panel;

	public RawImage MainImage;

	public Image Icon;

	public Text TextBox;

	public Text Date;

	[NonSerialized]
	public PopupManager.PopUp popup;

	[NonSerialized]
	public float Made = -1f;

	[NonSerialized]
	public bool IsNew = true;

	private void Start()
	{
		if (popup != null)
		{
			TextBox.text = popup.Text;
			if (popup.ActionTarget != null && popup.ActionTarget.Length != 0 && popup.Action != PopupManager.PopUpAction.None)
			{
				Text textBox = TextBox;
				textBox.text = textBox.text + " <B>(" + "NotificationGotoHint".Loc() + ")</B>";
			}
			TextBox.color = popup.textColor;
			Date.text = popup.Time.ToExtraCompactString();
			Icon.sprite = ObjectDatabase.GetIcon(popup.Icon);
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform.parent.GetComponent<RectTransform>());
			panel.preferredHeight = Mathf.Max(45f, TextBox.preferredHeight + 4f);
			if (IsNew)
			{
				Color color = MainImage.color;
				MainImage.color = new Color32(149, 180, 253, 191);
				MainImage.DOColor(color, 3f);
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void OnDestroy()
	{
		if (HUD.Instance != null)
		{
			HUD.Instance.popupManager.PopupButtons.Remove(this);
			HUD.Instance.popupManager.PopupIDDict.Remove(popup.Identifier);
		}
	}

	private void Goto(List<Selectable> sel, int offset, bool moveIfInactive)
	{
		if (!BuildController.Instance.CanChangeFloor())
		{
			return;
		}
		for (int i = 0; i < sel.Count; i++)
		{
			int index = (i + offset) % sel.Count;
			if (moveIfInactive || sel[index].isActiveAndEnabled)
			{
				CameraScript.Instance.MoveTo(sel[index].GetFlatPos(), sel[index].GetFloor());
				break;
			}
		}
		SelectorController.Instance.SetSelection(sel);
	}

	private bool GotoAndSelect(IEnumerable<Selectable> sel, List<Selectable> targets, HashSet<uint> dids)
	{
		targets.AddRange(sel.Where((Selectable x) => dids.Contains(x.DID)));
		if (targets.Count != 0)
		{
			Goto(targets, popup.SelectOffset, false);
			return true;
		}
		return false;
	}

	public void OnPointerClick(PointerEventData d)
	{
		if (d.button == PointerEventData.InputButton.Left)
		{
			if (popup.ActionTarget == null || popup.ActionTarget.Length == 0 || popup.Action == PopupManager.PopUpAction.None)
			{
				return;
			}
			UISoundFX.PlaySFX("ButtonClick");
			HashSet<uint> dids = popup.ActionTarget.ToHashSet();
			List<Selectable> targets = new List<Selectable>();
			switch (popup.Action)
			{
			case PopupManager.PopUpAction.GotoEmp:
				if (!GotoAndSelect(GameSettings.Instance.sActorManager.Actors.OfType<Selectable>(), targets, dids) && !GotoAndSelect(GameSettings.Instance.sActorManager.Staff.OfType<Selectable>(), targets, dids))
				{
					GotoAndSelect(GameSettings.Instance.sActorManager.Others.SelectMany((KeyValuePair<string, HashSet<Actor>> x) => x.Value).OfType<Selectable>(), targets, dids);
				}
				break;
			case PopupManager.PopUpAction.GotoRoom:
				GotoAndSelect(GameSettings.Instance.sRoomManager.Rooms.OfType<Selectable>(), targets, dids);
				break;
			case PopupManager.PopUpAction.GotoFurn:
				GotoAndSelect(GameSettings.Instance.sRoomManager.AllFurniture.OfType<Selectable>(), targets, dids);
				break;
			case PopupManager.PopUpAction.GotoHR:
			{
				Actor actor = GameSettings.Instance.sActorManager.Actors.FirstOrDefault((Actor x) => x.DID == popup.ActionTarget[0]);
				if (actor != null && actor.employee.IsRole(Employee.RoleBit.Lead))
				{
					HUD.Instance.TeamWindow.autoWindow.Show(actor.GetTeam());
				}
				break;
			}
			case PopupManager.PopUpAction.OpenInsurance:
				HUD.Instance.insuranceWindow.Show(false);
				break;
			case PopupManager.PopUpAction.OpenProductDetails:
			{
				SoftwareProduct product = GameSettings.Instance.simulation.GetProduct(popup.ActionTarget[0], false);
				if (product != null)
				{
					HUD.Instance.GetProductWindow(null).ShowProductDetails(product);
				}
				break;
			}
			case PopupManager.PopUpAction.OpenCompanyDetails:
			{
				Company company = GameSettings.Instance.simulation.GetCompany(popup.ActionTarget[0]);
				if (company != null)
				{
					HUD.Instance.companyWindow.ShowCompanyDetails(company);
				}
				break;
			}
			case PopupManager.PopUpAction.OpenComplaints:
				HUD.Instance.complaintWindow.Show();
				break;
			}
			popup.SelectOffset = (popup.SelectOffset + 1) % popup.ActionTarget.Length;
		}
		else if (d.button == PointerEventData.InputButton.Right)
		{
			SelectorController.CanClick = false;
			UISoundFX.PlaySFX("ButtonSwoop");
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
