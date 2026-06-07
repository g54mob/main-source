using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageTemplate : MonoBehaviour
{
	private class InitialFocus
	{
		public PageItem.ButtonSide side;

		public Selectable specificSelectable;
	}

	[Serializable]
	public class SelectableInfo
	{
		public Selectable selectable;

		public PageItem pageItem;

		public PageItem.ButtonSide side
		{
			get
			{
				return pageItem.buttonSettings.side;
			}
		}

		public int priority
		{
			get
			{
				return pageItem.buttonSettings.priority;
			}
		}
	}

	[Readonly]
	public BookSpec.TemplateId id;

	[Readonly]
	public List<PageItem> pageItems = new List<PageItem>();

	[Readonly]
	public List<SelectableInfo> selectableInfos = new List<SelectableInfo>();

	[Readonly]
	public Canvas canvas;

	[Readonly]
	public List<TextFitter> textFitters = new List<TextFitter>();

	[Readonly]
	public List<TextSqueezer> textSqueezers = new List<TextSqueezer>();

	public PageItem.ButtonSide initialFocusPreferredSide;

	public bool makeInteractableOnEnable;

	private bool wantInteractable;

	private InitialFocus initialFocus = new InitialFocus();

	private Dictionary<string, PageItem> pageItemDict_;

	private bool interactable_ = true;

	public Dictionary<string, PageItem> pageItemDict
	{
		get
		{
			if (pageItemDict_ == null)
			{
				pageItemDict_ = new Dictionary<string, PageItem>();
				foreach (PageItem pageItem in pageItems)
				{
					if (!string.IsNullOrEmpty(pageItem.id))
					{
						if (pageItemDict.ContainsKey(pageItem.id))
						{
							Debug.LogWarningFormat("Duplicate PageItem in {0}: {1}", base.name, pageItem.id);
						}
						else
						{
							pageItemDict_.Add(pageItem.id, pageItem);
						}
					}
				}
			}
			return pageItemDict_;
		}
	}

	public bool interactable
	{
		get
		{
			return interactable_;
		}
		set
		{
			interactable_ = value;
			if (!value)
			{
				RememberSelectionIfActive();
			}
			foreach (SelectableInfo selectableInfo in selectableInfos)
			{
				selectableInfo.selectable.interactable = selectableInfo.selectable.isActiveAndEnabled && interactable_;
			}
			if (interactable_ && id != BookSpec.TemplateId.Base)
			{
				SelectionHelper.SwitchToLegal(GetFocusSelectables(), true);
				Selectable currentSelectable = SelectionHelper.GetCurrentSelectable();
				HighlightEffect highlightEffect = ((!(currentSelectable != null)) ? null : currentSelectable.GetComponent<HighlightEffect>());
				if (highlightEffect != null)
				{
					highlightEffect.Kick();
				}
			}
		}
	}

	public void OnEnable()
	{
		wantInteractable = makeInteractableOnEnable;
	}

	public void BeginRefresh()
	{
		foreach (PageItem pageItem in pageItems)
		{
			if (pageItem.isStaticText)
			{
				pageItem.text = Lang.GetGendered(pageItem.staticStringId, SaveData.it.generalRo.playerGender);
			}
			else
			{
				pageItem.touched = false;
			}
		}
	}

	public void EndRefresh()
	{
		foreach (PageItem pageItem in pageItems)
		{
			pageItem.visible = pageItem.touched || string.IsNullOrEmpty(pageItem.id);
		}
		foreach (TextSqueezer textSqueezer in textSqueezers)
		{
			if (textSqueezer.isActiveAndEnabled)
			{
				textSqueezer.Squeeze();
			}
		}
	}

	private void Update()
	{
		if (wantInteractable)
		{
			interactable = true;
			wantInteractable = false;
		}
		if (interactable && id != BookSpec.TemplateId.Base)
		{
			SelectionHelper.SwitchToLegal(GetFocusSelectables());
			RememberSelectionIfActive();
		}
	}

	private IEnumerable<Selectable> GetFocusSelectables()
	{
		if (initialFocus.specificSelectable != null)
		{
			yield return initialFocus.specificSelectable;
		}
		PageItem.ButtonSide side = initialFocus.side;
		if (side == PageItem.ButtonSide.None)
		{
			side = initialFocusPreferredSide;
		}
		if (side == PageItem.ButtonSide.Left || side == PageItem.ButtonSide.None)
		{
			foreach (SelectableInfo s in selectableInfos)
			{
				if (s.side == PageItem.ButtonSide.Left && s.priority >= 0)
				{
					yield return s.pageItem.selectable;
				}
			}
			foreach (SelectableInfo s2 in selectableInfos)
			{
				if (s2.side == PageItem.ButtonSide.Right && s2.priority >= 0)
				{
					yield return s2.pageItem.selectable;
				}
			}
		}
		else
		{
			foreach (SelectableInfo s3 in selectableInfos)
			{
				if (s3.side == PageItem.ButtonSide.Right && s3.priority >= 0)
				{
					yield return s3.pageItem.selectable;
				}
			}
			foreach (SelectableInfo s4 in selectableInfos)
			{
				if (s4.side == PageItem.ButtonSide.Left && s4.priority >= 0)
				{
					yield return s4.pageItem.selectable;
				}
			}
		}
		if (side == PageItem.ButtonSide.Left || side == PageItem.ButtonSide.None)
		{
			foreach (SelectableInfo s5 in selectableInfos)
			{
				if (s5.side == PageItem.ButtonSide.Left && s5.priority < 0)
				{
					yield return s5.pageItem.selectable;
				}
			}
			{
				foreach (SelectableInfo s6 in selectableInfos)
				{
					if (s6.side == PageItem.ButtonSide.Right && s6.priority < 0)
					{
						yield return s6.pageItem.selectable;
					}
				}
				yield break;
			}
		}
		foreach (SelectableInfo s7 in selectableInfos)
		{
			if (s7.side == PageItem.ButtonSide.Right && s7.priority < 0)
			{
				yield return s7.pageItem.selectable;
			}
		}
		foreach (SelectableInfo s8 in selectableInfos)
		{
			if (s8.side == PageItem.ButtonSide.Left && s8.priority < 0)
			{
				yield return s8.pageItem.selectable;
			}
		}
	}

	private IEnumerable<Selectable> GetFocusSelectablesIgnorePriority()
	{
		if (initialFocus.specificSelectable != null)
		{
			yield return initialFocus.specificSelectable;
		}
		PageItem.ButtonSide side = initialFocus.side;
		if (side == PageItem.ButtonSide.None)
		{
			side = initialFocusPreferredSide;
		}
		if (side == PageItem.ButtonSide.Left || side == PageItem.ButtonSide.None)
		{
			foreach (SelectableInfo s in selectableInfos)
			{
				if (s.side == PageItem.ButtonSide.Left)
				{
					yield return s.pageItem.selectable;
				}
			}
			{
				foreach (SelectableInfo s2 in selectableInfos)
				{
					if (s2.side == PageItem.ButtonSide.Right)
					{
						yield return s2.pageItem.selectable;
					}
				}
				yield break;
			}
		}
		foreach (SelectableInfo s3 in selectableInfos)
		{
			if (s3.side == PageItem.ButtonSide.Right)
			{
				yield return s3.pageItem.selectable;
			}
		}
		foreach (SelectableInfo s4 in selectableInfos)
		{
			if (s4.side == PageItem.ButtonSide.Left)
			{
				yield return s4.pageItem.selectable;
			}
		}
	}

	public void SetInitialFocus(PageItem.ButtonSide side, Selectable specificSelectable = null)
	{
		initialFocus.side = side;
		if (!(specificSelectable == initialFocus.specificSelectable))
		{
			if (specificSelectable != null && HasSelectable(specificSelectable))
			{
				initialFocus.specificSelectable = specificSelectable;
			}
			else
			{
				initialFocus.specificSelectable = null;
			}
		}
	}

	public PageItem.ButtonSide GetSelectableSide(Selectable selectable)
	{
		SelectableInfo selectableInfo = FindSelectableInfo(selectable);
		return (selectableInfo != null) ? selectableInfo.side : PageItem.ButtonSide.None;
	}

	public int GetSelectablePriority(Selectable selectable)
	{
		SelectableInfo selectableInfo = FindSelectableInfo(selectable);
		return (selectableInfo != null) ? selectableInfo.priority : 0;
	}

	private void RememberSelectionIfActive()
	{
		Selectable currentSelectable = SelectionHelper.GetCurrentSelectable();
		if (HasSelectable(currentSelectable))
		{
			SetInitialFocus(initialFocusPreferredSide, currentSelectable);
		}
	}

	private bool HasSelectable(Selectable selectable)
	{
		foreach (SelectableInfo selectableInfo in selectableInfos)
		{
			if (selectableInfo.selectable == selectable)
			{
				return true;
			}
		}
		return false;
	}

	private SelectableInfo FindSelectableInfo(Selectable selectable)
	{
		foreach (SelectableInfo selectableInfo in selectableInfos)
		{
			if (selectableInfo.selectable == selectable)
			{
				return selectableInfo;
			}
		}
		return null;
	}

	public PageItem FindPageItem(string id)
	{
		PageItem value = null;
		pageItemDict.TryGetValue(id, out value);
		return value;
	}

	public void UpdateTextFitters()
	{
		foreach (TextFitter textFitter in textFitters)
		{
			if (textFitter.isActiveAndEnabled)
			{
				textFitter.LateUpdate();
			}
		}
	}

	private bool JumpSelection(SelectableInfo selectableInfo, int offset)
	{
		int num = selectableInfos.IndexOf(selectableInfo);
		SelectableInfo selectableInfo2 = selectableInfos[Mathf.Clamp(num + offset, 0, selectableInfos.Count - 1)];
		if (selectableInfo2 != selectableInfo)
		{
			SelectionHelper.SetCurrent(selectableInfo2.selectable);
			return true;
		}
		return false;
	}

	public bool MoveSelectionIfPossible(PageItem curPageItem, int dir)
	{
		if (id == BookSpec.TemplateId.ScrollableManifest)
		{
			SelectableInfo selectableInfo = FindSelectableInfo(SelectionHelper.GetCurrentSelectable());
			if (selectableInfo != null && dir > 0)
			{
				return JumpSelection(selectableInfo, 10);
			}
			if (selectableInfo != null && dir < 0)
			{
				return JumpSelection(selectableInfo, -10);
			}
			return false;
		}
		if (dir < 0 && curPageItem.buttonSettings.side == PageItem.ButtonSide.Right)
		{
			SetInitialFocus(PageItem.ButtonSide.Left);
			SelectionHelper.SwitchToLegal(GetFocusSelectablesIgnorePriority(), true);
			return SelectionHelper.GetCurrentSelectable() != null;
		}
		if (dir > 0 && curPageItem.buttonSettings.side == PageItem.ButtonSide.Left)
		{
			SetInitialFocus(PageItem.ButtonSide.Right);
			SelectionHelper.SwitchToLegal(GetFocusSelectablesIgnorePriority(), true);
			return SelectionHelper.GetCurrentSelectable() != null;
		}
		return false;
	}
}
