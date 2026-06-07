using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModErrorWindow : MonoBehaviour
{
	public static ModErrorWindow Instance;

	private static HashSet<string> _triggered = new HashSet<string>();

	private static bool _emptyTriggered = false;

	private static List<KeyValuePair<string, Exception>> _queue = new List<KeyValuePair<string, Exception>>();

	public InputField ErrMsg;

	public Text ErrPrompt;

	public GUIWindow Window;

	public static void Show(ModController.DLLMod mod, Exception ex)
	{
		if (mod == null)
		{
			if (!_emptyTriggered)
			{
				_emptyTriggered = true;
				lock (_queue)
				{
					_queue.Add(new KeyValuePair<string, Exception>(null, ex));
				}
			}
		}
		else if (_triggered.Add(mod.ItemTitle))
		{
			lock (_queue)
			{
				_queue.Add(new KeyValuePair<string, Exception>(mod.ItemTitle, ex));
			}
		}
	}

	public static void Show(string mod, Exception ex)
	{
		if (mod == null)
		{
			if (_emptyTriggered)
			{
				return;
			}
			_emptyTriggered = true;
		}
		lock (_queue)
		{
			_queue.Add(new KeyValuePair<string, Exception>(mod, ex));
		}
	}

	public static void UpdateMe()
	{
		if (!(Instance != null) || Instance.Window.Shown)
		{
			return;
		}
		lock (_queue)
		{
			if (_queue.Count > 0)
			{
				Instance.ShowMe(_queue[0].Key, _queue[0].Value);
				_queue.RemoveAt(0);
			}
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void ShowMe(string mod, Exception ex)
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.GameSpeed = 0f;
		}
		ErrPrompt.text = ((mod == null) ? "NonSpecificModErrorMessage".Loc() : "SpecificModErrorMessage".Loc(mod.FontBold()));
		ErrMsg.text = ex.ToString();
		Window.StartHidden = false;
		Window.Show(true);
	}
}
