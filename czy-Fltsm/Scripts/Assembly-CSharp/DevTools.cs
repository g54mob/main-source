using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class DevTools : MonoBehaviour, IUIFlagsProvider
{
	[SerializeField]
	private GameObject _panel;

	[SerializeField]
	private KeyCode _shortcut = KeyCode.BackQuote;

	private StringBuilder _cheatCode = new StringBuilder();

	private Dictionary<string, UnityAction> _cheatTable = new Dictionary<string, UnityAction>();

	public static bool Unlocked { get; private set; }

	public PanelContainerFlags Flags => PanelContainerFlags.BlockDPadInput;

	public bool BlockCancel => false;

	private void Awake()
	{
		_cheatTable.Add("iddqd", Unlock);
	}

	private void Update()
	{
		if ((Unlocked || Application.isEditor) && Input.GetKeyDown(_shortcut))
		{
			ToggleActive();
		}
		UpdateCheatCode();
	}

	private void OnDestroy()
	{
		Unlocked = false;
	}

	private void UpdateCheatCode()
	{
		bool flag = true;
		string inputString = Input.inputString;
		foreach (char value in inputString)
		{
			_cheatCode.Append(value);
			string text = _cheatCode.ToString();
			Dictionary<string, UnityAction>.Enumerator enumerator = _cheatTable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Key.Equals(text))
				{
					Debug.LogException(new Exception("Cheat code match: " + text));
					flag = true;
					enumerator.Current.Value();
					break;
				}
				if (enumerator.Current.Key.StartsWith(text))
				{
					flag = false;
				}
			}
			if (flag)
			{
				_cheatCode.Remove(0, _cheatCode.Length);
			}
		}
	}

	private void Unlock()
	{
		Unlocked = true;
	}

	private void ToggleActive()
	{
		bool flag = !_panel.activeSelf;
		_panel.SetActive(flag);
		if (flag)
		{
			UIEvent.Dispatch(UIEvent.Type.CheatTools);
		}
	}
}
