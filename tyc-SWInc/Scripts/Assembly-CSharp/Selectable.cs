using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Selectable : Writeable
{
	[NonSerialized]
	protected Renderer[] Highlightables;

	protected bool IsHighlight;

	protected bool IsSecondary;

	protected bool IsHover;

	protected bool IsErrorOutline;

	public static bool DisableDiagonalHighlights;

	public bool IsSelected
	{
		get
		{
			return IsHighlight;
		}
	}

	public virtual string[] GetActions()
	{
		return new string[0];
	}

	public virtual void TeamChange()
	{
	}

	public void ToggleError(bool t)
	{
		IsErrorOutline = t;
		RefreshHighlight();
	}

	public void HoverHighlight(bool hover)
	{
		if (IsHover != hover)
		{
			IsHover = hover;
			if (!GameSettings.IsQuitting && !(SelectorController.Instance == null) && SelectorController.Instance.Selected != null && SelectorController.Instance.SecondaryHighlights != null && !(this == null) && !(base.transform == null) && !(base.gameObject == null))
			{
				RefreshHighlightMaterials();
				UpdateOnHighlight();
			}
		}
	}

	public void RefreshHighlight()
	{
		Highlight(IsHighlight, IsSecondary);
	}

	public void Highlight(bool highlight, bool secondary = false)
	{
		if (GameSettings.Instance.IsReferenceNull() || SelectorController.Instance == null || SelectorController.Instance.Selected == null || SelectorController.Instance.SecondaryHighlights == null || !this.IsAliveNotNull())
		{
			return;
		}
		if (highlight)
		{
			if (secondary)
			{
				IsSecondary = true;
				SelectorController.Instance.SecondaryHighlights.Add(this);
			}
			else
			{
				IsHighlight = true;
				foreach (Selectable item in from x in GetRelated()
					where x != null && x.gameObject != null
					select x)
				{
					if (SelectorController.Instance.Selected.Contains(item))
					{
						SelectorController.Instance.SecondaryHighlights.Add(item);
						item.IsSecondary = true;
					}
					else
					{
						item.Highlight(true, true);
					}
				}
			}
		}
		else if (secondary)
		{
			IsSecondary = false;
		}
		else
		{
			IsHighlight = false;
		}
		RefreshHighlightMaterials();
		UpdateOnHighlight();
	}

	protected virtual void UpdateOnHighlight()
	{
	}

	private void RefreshHighlightMaterials()
	{
		if (!base.IsGOActive || this == null)
		{
			return;
		}
		bool flag = Highlightables == null;
		if (!flag)
		{
			for (int i = 0; i < Highlightables.Length; i++)
			{
				if (Highlightables[i] == null)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			List<Renderer> list = new List<Renderer>();
			UpdateHighlightables(base.transform, list);
			Highlightables = list.ToArray();
		}
		for (int j = 0; j < Highlightables.Length; j++)
		{
			UpdateHighlight(Highlightables[j]);
		}
	}

	public virtual Renderer[] GetHighlightRenders()
	{
		if (Highlightables == null)
		{
			List<Renderer> list = new List<Renderer>();
			UpdateHighlightables(base.transform, list);
			Highlightables = list.ToArray();
		}
		return Highlightables;
	}

	protected bool GetHighlightType(out SelectorController.HighlightType type)
	{
		type = SelectorController.HighlightType.Error;
		if (!IsErrorOutline)
		{
			if (IsHover)
			{
				if (IsHighlight)
				{
					type = SelectorController.HighlightType.PrimaryAndTertiary;
				}
				else
				{
					type = SelectorController.HighlightType.Tertiary;
				}
			}
			else if (IsHighlight)
			{
				type = SelectorController.HighlightType.Primary;
			}
			else
			{
				if (!IsSecondary)
				{
					return false;
				}
				type = SelectorController.HighlightType.Secondary;
			}
		}
		return true;
	}

	private void UpdateHighlight(Renderer rend)
	{
		if (rend.sharedMaterials.Length != 0 && !(rend.sharedMaterials[0] != RoomMaterialController.Instance.ShadowsOnly))
		{
			return;
		}
		SelectorController.HighlightType type;
		if (GetHighlightType(out type))
		{
			bool flag = SingleMat();
			if (rend.tag.Equals("HighlightAlpha"))
			{
				CleanUpAlpha(rend, (!flag) ? 1 : 0);
			}
			rend.sharedMaterials = GetMaterials(flag ? null : rend.sharedMaterials[0], type, rend.tag);
		}
		else if (SingleMat())
		{
			if (rend.tag.Equals("HighlightAlpha"))
			{
				CleanUpAlpha(rend, 0);
			}
			rend.sharedMaterials = new Material[0];
		}
		else if (rend.sharedMaterials.Length > 1)
		{
			if (rend.tag.Equals("HighlightAlpha"))
			{
				CleanUpAlpha(rend, 1);
			}
			rend.sharedMaterials = new Material[1] { rend.sharedMaterials[0] };
		}
	}

	private void CleanUpAlpha(Renderer rend, int start)
	{
		Material[] sharedMaterials = rend.sharedMaterials;
		for (int i = start; i < sharedMaterials.Length; i++)
		{
			UnityEngine.Object.Destroy(sharedMaterials[i]);
		}
	}

	private static Material[] GetMaterials(Material main, SelectorController.HighlightType type, string tag)
	{
		bool flag = tag.Equals("HighlightAlpha");
		bool flag2 = flag || tag.Equals("Highlight") || tag.EndsWith("AndDiag");
		bool flag3 = Options.DiagonalRoomHighlights && !DisableDiagonalHighlights && tag.EndsWith("Diag");
		int num = 0;
		num += ((main != null) ? 1 : 0);
		num += (flag2 ? 1 : 0);
		num += (flag3 ? 1 : 0);
		Material[] array = new Material[num];
		num = 0;
		if (main != null)
		{
			array[num] = main;
			num++;
		}
		if (flag2)
		{
			array[num] = SelectorController.Instance.GetHighlightMaterial(type, false, flag, main);
			num++;
		}
		if (flag3)
		{
			array[num] = SelectorController.Instance.GetHighlightMaterial(type, true, flag, main);
		}
		return array;
	}

	private void UpdateHighlightables(Transform node, List<Renderer> result)
	{
		if (!(node == null) && (!(node.gameObject != base.gameObject) || !(node.GetComponent<Selectable>() != null)))
		{
			Renderer component = node.GetComponent<Renderer>();
			if (component != null && component.tag.StartsWith("Highlight"))
			{
				result.Add(component);
			}
			for (int i = 0; i < node.childCount; i++)
			{
				UpdateHighlightables(node.GetChild(i), result);
			}
		}
	}

	public virtual IEnumerable<Selectable> GetRelated()
	{
		yield break;
	}

	public virtual string GetInfo()
	{
		return "N/A";
	}

	public virtual string[] GetExtendedInfo()
	{
		return null;
	}

	public virtual string[] GetExtendedIconInfo()
	{
		return null;
	}

	public virtual string[] GetExtendedTooltipInfo()
	{
		return null;
	}

	public virtual Color[] GetExtendedColorInfo()
	{
		return null;
	}

	public virtual string[] GetMultiIcon()
	{
		return null;
	}

	public virtual string[] GetMultiDesc()
	{
		return null;
	}

	public virtual string[] GetMultiValue(IEnumerable<Selectable> selected)
	{
		return null;
	}

	public virtual string Description()
	{
		return "Selectables";
	}

	public virtual string GetPanelActionName()
	{
		return null;
	}

	public virtual string GetPanelActionTip(ref float sum)
	{
		return null;
	}

	public virtual void InvokePanelAction(List<UndoObject.UndoAction> undos)
	{
	}

	public virtual bool PanelActionOnlyOnce()
	{
		return false;
	}

	public virtual Selectable PanelActionDivert()
	{
		return this;
	}

	public virtual void FinalizePanelAction(string action, List<UndoObject.UndoAction> undos)
	{
	}

	public virtual bool CanRectSelect()
	{
		return false;
	}

	protected Color GetColorStat(float stat)
	{
		if (stat < 1f)
		{
			return Color.Lerp(HUD.GetWarningColor().ChangeValue(0.7f), new Color32(50, 50, 50, byte.MaxValue), stat);
		}
		if (stat > 1f)
		{
			return Color.Lerp(new Color32(50, 50, 50, byte.MaxValue), HUD.GetAccentColor().ChangeValue(0.7f), stat - 1f);
		}
		return new Color32(50, 50, 50, byte.MaxValue);
	}

	public virtual IEnumerable<Renderer> GetHighlights()
	{
		yield break;
	}

	public abstract int GetFloor();

	public abstract Vector2 GetFlatPos();

	public virtual Vector3 GetTransformPosition()
	{
		return base.transform.position;
	}

	public bool IsSelectable()
	{
		if (!IsSelectionRestricted())
		{
			return IsSelectableInView();
		}
		return false;
	}

	public virtual bool IsSelectionRestricted()
	{
		return false;
	}

	public virtual bool IsSelectableInView()
	{
		return GetFloor() == GameSettings.Instance.ActiveFloor;
	}

	public virtual bool IsSelectableAboveFloor()
	{
		return false;
	}

	public virtual bool SingleMat()
	{
		return false;
	}

	public virtual Vector3 GetSelectPosition()
	{
		return base.transform.position;
	}

	public virtual TemperatureGroup GetTempGroup()
	{
		return null;
	}

	public virtual TemperatureGroup.TempType GetTempType()
	{
		return TemperatureGroup.TempType.None;
	}

	public virtual bool SelectableThroughWall()
	{
		return false;
	}

	public virtual IStyle GetStyle()
	{
		return null;
	}

	public virtual Selectable DeferSelection()
	{
		return this;
	}
}
