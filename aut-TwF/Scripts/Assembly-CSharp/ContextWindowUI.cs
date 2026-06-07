using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ContextWindowUI : MonoBehaviour
{
	protected virtual void Start()
	{
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Update()
	{
		CheckClickOutside();
	}

	public virtual void OpenWindow()
	{
		base.gameObject.SetActive(value: true);
	}

	public virtual void CloseWindow()
	{
		base.gameObject.SetActive(value: false);
	}

	private void CheckClickOutside()
	{
		if (!Mouse.current.leftButton.wasPressedThisFrame)
		{
			return;
		}
		if (EventSystem.current.IsPointerOverGameObject())
		{
			PointerEventData eventData = new PointerEventData(EventSystem.current)
			{
				position = Mouse.current.position.ReadValue()
			};
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(eventData, list);
			bool flag = false;
			foreach (RaycastResult item in list)
			{
				if (item.gameObject == base.gameObject || item.gameObject.transform.IsChildOf(base.transform))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				CloseWindow();
			}
		}
		else
		{
			CloseWindow();
		}
	}
}
