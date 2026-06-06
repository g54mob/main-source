using System.Collections.Generic;
using UnityEngine;

public class TextPopupPool : MonoBehaviour
{
	private static TextPopupPool _instance;

	private Stack<TextPopup> _pool;

	public static TextPopupPool Instance
	{
		get
		{
			if (!(_instance == null))
			{
				return _instance;
			}
			return CreateInstance();
		}
	}

	private static TextPopupPool CreateInstance()
	{
		_instance = new GameObject("TextPopupPool").AddComponent<TextPopupPool>();
		return _instance;
	}

	public void Add(TextPopup popup)
	{
		if (_pool == null)
		{
			_pool = new Stack<TextPopup>();
		}
		popup.gameObject.SetActive(value: false);
		_pool.Push(popup);
	}

	public TextPopup Get()
	{
		if (_pool == null)
		{
			_pool = new Stack<TextPopup>();
		}
		TextPopup textPopup = ((_pool.Count != 0) ? _pool.Pop() : Object.Instantiate(GameSettings.Instance.FXSettings.TextPopupPrefab));
		textPopup.gameObject.SetActive(value: true);
		return textPopup;
	}
}
