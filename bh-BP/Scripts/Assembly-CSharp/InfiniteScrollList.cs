using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScrollList : SerializedMonoBehaviour
{
	public VerticalLayoutGroup Grp;

	public CoolSelectableWrapper SelectableWrapper;

	public CoolButtonGroup BtnGrp;

	public ScrollRect Scroll;

	public int PageSize;

	protected int _startIdx;

	protected int _endIdx;

	protected int _selectedIdx;

	protected float _startIdxPos;

	protected float _endIdxPos;

	public RectTransform TopFitter;

	public RectTransform BotFitter;

	public float ItemHeight;

	protected bool _isPopulated;

	private const int kScrollMargin = 1;

	protected virtual void Awake()
	{
	}

	protected virtual bool RemoveItem(Transform child)
	{
		return false;
	}

	protected virtual void RemoveItems(int num, bool isTop)
	{
	}

	public virtual InfiniteScrollListItem CreateItem(int idx)
	{
		return null;
	}

	public virtual InfiniteScrollListItem GetItem(int idx)
	{
		return null;
	}

	protected void SetStartIdx(int idx)
	{
	}

	protected void SetEndIdx(int idx)
	{
	}

	public void PopulateList(bool retainSelection)
	{
	}

	public void PopulateList(int defaultSelectionIdx)
	{
	}

	private void RefreshBotFitter()
	{
	}

	private void RefreshTopFitter()
	{
	}

	protected virtual void PopulateList(int startIdx, int endIdx, bool isAppending)
	{
	}

	public virtual void ClearList()
	{
	}

	public virtual int GetTotalListSize()
	{
		return 0;
	}

	public virtual int GetMinStartIdx()
	{
		return 0;
	}

	public virtual int GetMaxEndIdx()
	{
		return 0;
	}

	protected virtual void OnScrolled(Vector2 scrl)
	{
	}

	protected virtual void OnGrpEntered(CoolButton btn)
	{
	}

	protected virtual void OnGrpNav(CoolButton btnPrev, CoolButton btnNext)
	{
	}

	protected virtual void OnGrpExited(CoolButton btn)
	{
	}
}
