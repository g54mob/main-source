using Unity.Components.Events;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
	public static bool IsActive = true;

	public WeakEvent<ClickableObject> OnClick = new WeakEvent<ClickableObject>();

	public WeakEvent<ClickableObject> OnEnter = new WeakEvent<ClickableObject>();

	public WeakEvent<ClickableObject> OnExit = new WeakEvent<ClickableObject>();

	private bool _isOver;

	private void Start()
	{
		if (GetComponent<Collider>() == null)
		{
			base.gameObject.AddComponent<BoxCollider>().size = UnityUtils.GetBounds(base.gameObject);
		}
	}

	private void OnMouseEnter()
	{
		if (IsActive && Cursor.visible)
		{
			_isOver = true;
			OnEnter.Invoke(this);
		}
	}

	private void OnMouseOver()
	{
		if (IsActive && Cursor.visible)
		{
			if (!_isOver)
			{
				OnEnter.Invoke(this);
			}
			_isOver = true;
		}
	}

	private void OnMouseExit()
	{
		if (IsActive && Cursor.visible)
		{
			_isOver = true;
			OnExit.Invoke(this);
		}
	}

	private void OnMouseUpAsButton()
	{
		if (IsActive && Cursor.visible)
		{
			OnClick.Invoke(this);
		}
	}
}
