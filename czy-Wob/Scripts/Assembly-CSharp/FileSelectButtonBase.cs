using UnityEngine;

public class FileSelectButtonBase : MonoBehaviour
{
	public Sprite offSprite;

	public Sprite overSprite;

	public float overScale = 1.1f;

	protected Vector3 overVec;

	protected bool selected;

	protected bool locked = true;

	protected SpriteRenderer renderRef;

	protected CursorController cursorRef;

	private void Awake()
	{
		AwakeBehavior();
	}

	protected virtual void AwakeBehavior()
	{
		renderRef = GetComponent<SpriteRenderer>();
		cursorRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		Lock();
		overVec = new Vector3(overScale, overScale, overScale);
	}

	private void LateUpdate()
	{
		if (selected && base.transform.localScale != overVec)
		{
			base.transform.localScale = overVec;
		}
	}

	public void Lock()
	{
		OnDeselect();
		locked = true;
	}

	public void Unlock()
	{
		locked = false;
	}

	public void OnMouseOver()
	{
		OnSelect();
	}

	public void OnMouseExit()
	{
		OnDeselect();
	}

	public void OnMouseDown()
	{
		OnClick();
	}

	protected virtual void OnSelect()
	{
		if (locked || selected)
		{
			if (locked)
			{
				cursorRef.SetCursor(CursorController.CursorType.LOCKED_CLICKABLE);
			}
			else
			{
				cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
			}
		}
		else
		{
			selected = true;
			renderRef.sprite = overSprite;
			base.transform.localScale = overVec;
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
		}
	}

	protected virtual void OnDeselect()
	{
		if (!locked && selected)
		{
			selected = false;
			renderRef.sprite = offSprite;
			base.transform.localScale = Vector3.one;
		}
	}

	protected virtual void OnClick()
	{
		if (!locked)
		{
			_ = selected;
		}
	}
}
