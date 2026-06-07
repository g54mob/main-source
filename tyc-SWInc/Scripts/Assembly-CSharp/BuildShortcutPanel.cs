using UnityEngine;
using UnityEngine.UI;

public class BuildShortcutPanel : MonoBehaviour
{
	public Text Label;

	public RectTransform Panel;

	public Color KeyColor;

	public Color ActionColor;

	private void OnDisable()
	{
		Label.text = "";
	}

	private void OnEnable()
	{
	}

	public void Hide()
	{
		Panel.gameObject.SetActive(false);
		base.enabled = false;
		Label.text = "";
	}

	private void Update()
	{
		bool activeSelf = Panel.gameObject.activeSelf;
		Vector2 localPoint;
		bool flag = !RectTransformUtility.ScreenPointToLocalPointInRectangle(Panel, Input.mousePosition, UICamSize.GetUICam(), out localPoint) || localPoint.x < 0f || localPoint.y > 0f || localPoint.x > Panel.rect.width || localPoint.y < 0f - Panel.rect.height;
		if (activeSelf != flag)
		{
			Panel.gameObject.SetActive(flag);
			if (flag)
			{
				HelpTipPanel.Show(HintController.Hints.FurnitureShortCutHint, Panel);
			}
		}
	}

	public void AddShortcut(InputController.Keys key, bool hold = false)
	{
		Activate();
		string fullKeyBindString = InputController.GetFullKeyBindString(key, false, true);
		if (fullKeyBindString != null)
		{
			AppendString("KeyDoAction".Loc(GetButton(fullKeyBindString, !IsMouseKey(InputController.GetBinding(key, false)), hold), InputController.GetLocKey((int)key).FontColor(ActionColor)));
		}
	}

	public void AddShortcut(string desc, KeyCode key, bool hold = false)
	{
		Activate();
		AppendString("KeyDoAction".Loc(GetButton(key, hold), desc.FontColor(ActionColor)));
	}

	public void AddShortcut(string desc, KeyCode mod, KeyCode key, bool hold = false)
	{
		Activate();
		string key2 = InputController.GetPrettyKeyName(mod) + " + " + InputController.GetPrettyKeyName(key);
		AppendString("KeyDoAction".Loc(GetButton(key2, true, hold), desc.FontColor(ActionColor)));
	}

	public void AddShortcut(string desc, string key, bool hold = false)
	{
		Activate();
		AppendString("KeyDoAction".Loc(GetButton(key, false, hold), desc.FontColor(ActionColor)));
	}

	private void Activate()
	{
		base.enabled = true;
	}

	public string GetButton(KeyCode key, bool hold)
	{
		if (hold)
		{
			return "HoldKey".Loc(InputController.GetPrettyKeyName(key).FontColor(KeyColor));
		}
		if (IsMouseKey(key))
		{
			return InputController.GetPrettyKeyName(key).FontColor(KeyColor);
		}
		return "PressKey".Loc(InputController.GetPrettyKeyName(key).FontColor(KeyColor));
	}

	public string GetButton(string key, bool press, bool hold)
	{
		if (hold)
		{
			return "HoldKey".Loc(key.FontColor(KeyColor));
		}
		if (!press)
		{
			return key.FontColor(KeyColor);
		}
		return "PressKey".Loc(key.FontColor(KeyColor));
	}

	public bool IsMouseKey(KeyCode key)
	{
		if (key >= (KeyCode)232)
		{
			return key <= KeyCode.Mouse6;
		}
		return false;
	}

	private void AppendString(string s)
	{
		if (Label.text.Length > 0)
		{
			Text label = Label;
			label.text = label.text + "\n" + s;
		}
		else
		{
			Label.text = s;
		}
	}
}
