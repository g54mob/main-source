using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoolSelectable : SerializedMonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, IMoveHandler, ISubmitHandler
{
	public CoolSelectable Parent;

	public bool IsSelectable;

	[Header("Nav Config")]
	public CoolNav Nav;

	public bool RequirePressOnUpNav;

	public bool RequirePressOnDownNav;

	public CoolButtonAud Aud;

	private bool _initialized;

	protected virtual void Start()
	{
	}

	private void Init()
	{
	}

	public void RefreshParent(CoolSelectable setParent = null)
	{
	}

	public virtual void Select(MoveDirection entryDir = MoveDirection.None)
	{
	}

	public virtual void OnSelect(BaseEventData eventData)
	{
	}

	public virtual void OnDeselect(BaseEventData eventData)
	{
	}

	public virtual void OnSubmit(BaseEventData eventData)
	{
	}

	public virtual bool IsInteractable()
	{
		return false;
	}

	public virtual void OnMove(AxisEventData eventData)
	{
	}

	public virtual void OnChildMove(AxisEventData evData, CoolSelectable child)
	{
	}

	public void ClearNav()
	{
	}

	public virtual void RunNavSFX()
	{
	}

	public CoolSelectable FindSelectableSameParent(Vector2 dir)
	{
		return null;
	}
}
