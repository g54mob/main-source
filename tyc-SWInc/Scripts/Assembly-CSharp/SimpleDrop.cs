using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleDrop : MonoBehaviour
{
	public bool Dropped;

	public List<GameObject> Items = new List<GameObject>();

	public RectTransform DropIcon;

	public Text Label;

	public Action OnChanged;

	private void OnEnable()
	{
		StartCoroutine(Refresh());
	}

	private void OnDisable()
	{
		SubRefresh();
	}

	private IEnumerator Refresh()
	{
		yield return new WaitForEndOfFrame();
		SubRefresh();
	}

	private void SubRefresh()
	{
		Items.ForEach(delegate(GameObject x)
		{
			if (x != null)
			{
				x.SetActive(Dropped && base.gameObject != null && base.gameObject.activeSelf);
			}
		});
		Action onChanged = OnChanged;
		if (onChanged != null)
		{
			onChanged();
		}
	}

	public void Toggle()
	{
		Dropped = !Dropped;
		Items.ForEach(delegate(GameObject x)
		{
			if (x != null)
			{
				x.SetActive(Dropped && base.gameObject != null && base.gameObject.activeSelf);
			}
		});
		DropIcon.rotation = Quaternion.Euler(0f, 0f, Dropped ? 90 : 180);
		Action onChanged = OnChanged;
		if (onChanged != null)
		{
			onChanged();
		}
	}
}
