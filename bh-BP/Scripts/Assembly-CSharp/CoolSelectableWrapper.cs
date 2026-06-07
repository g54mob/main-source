using MEC;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoolSelectableWrapper : CoolSelectable
{
	public ScrollRect ScrollOwner;

	public WrapperAlignment Alignment;

	public Vector2Int GridSize;

	private int _lastSelectedChildIdx;

	public bool AutomaticNav;

	public DelegateUtl.DirEvent OnSkipAttempted;

	private CoroutineHandle _curScrollAnim;

	private void Awake()
	{
	}

	public override void Select(MoveDirection entryDir = MoveDirection.None)
	{
	}

	private bool GetSelectableChild(int i, out CoolSelectable s)
	{
		s = null;
		return false;
	}

	public override void OnChildMove(AxisEventData evData, CoolSelectable child)
	{
	}
}
