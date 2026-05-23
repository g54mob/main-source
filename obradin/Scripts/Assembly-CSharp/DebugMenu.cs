using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu
{
	public delegate void ClickFunc();

	private class Entry : IComparable
	{
		public string name;

		public string displayName;

		public Entry parent;

		public Entry selectedEntry;

		public ClickFunc clickFunc;

		public float clickedTime = -1000f;

		public List<Entry> children = new List<Entry>();

		public bool toggledOn;

		private KeyCode _hotkey;

		public bool clickedRecently
		{
			get
			{
				return Time.time - clickedTime < 1f;
			}
		}

		public KeyCode hotkey
		{
			get
			{
				return _hotkey;
			}
			set
			{
				_hotkey = value;
				displayName = ((_hotkey != KeyCode.None) ? _hotkey.ToString() : " ") + " " + name;
			}
		}

		public Entry(string name_, Entry parent_)
		{
			name = name_;
			parent = parent_;
			hotkey = KeyCode.None;
		}

		public int CompareTo(object other)
		{
			Entry entry = (Entry)other;
			if (entry == null)
			{
				return 0;
			}
			return name.CompareTo(entry.name);
		}

		public Entry Find(Substr path, bool createIfNotFound)
		{
			if (name == path)
			{
				return this;
			}
			int num = path.IndexOf("/");
			Substr substr = ((num < 0) ? path : path.Substring(0, num));
			foreach (Entry child in children)
			{
				if (child.name == substr)
				{
					return child.Find(path.Substring(num + 1), createIfNotFound);
				}
			}
			if (createIfNotFound)
			{
				Entry entry = new Entry(substr.ToString(), this);
				children.Add(entry);
				children.Sort();
				selectedEntry = children[0];
				return entry.Find(path.Substring(num + 1), createIfNotFound);
			}
			return null;
		}
	}

	private Entry root;

	private Entry cur;

	private static DebugMenu _instance;

	private static bool enabled
	{
		get
		{
			return Debug.isDebugBuild;
		}
	}

	private static DebugMenu instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DebugMenu();
				DebugManager.AddPreUpdateFuncs();
				Add("Toggle Play Clock", KeyCode.T, delegate
				{
					Clock.play.running = !Clock.play.running;
				});
			}
			return _instance;
		}
	}

	private DebugMenu()
	{
		root = new Entry("Debug Menu", null);
		cur = root;
	}

	public static void Add(string path, KeyCode hotkey, ClickFunc clickFunc = null)
	{
		if (enabled)
		{
			instance._Add(path, hotkey, (clickFunc != null) ? clickFunc : new ClickFunc(ToggleEntryStub));
		}
	}

	public static void Update()
	{
		if (enabled)
		{
			instance._Update();
		}
	}

	public static bool IsOn(string path, KeyCode hotkey = KeyCode.None, bool defaultValue = false)
	{
		if (!enabled)
		{
			return defaultValue;
		}
		return instance._IsOn(path, hotkey, defaultValue);
	}

	private void _Add(string path, KeyCode hotkey, ClickFunc clickFunc)
	{
		Entry entry = root.Find(new Substr(path), true);
		entry.hotkey = hotkey;
		entry.clickFunc = clickFunc;
	}

	private bool _IsOn(string path, KeyCode hotkey, bool defaultValue)
	{
		Entry entry = root.Find(new Substr(path), false);
		if (entry == null)
		{
			entry = root.Find(new Substr(path), true);
			entry.hotkey = hotkey;
			entry.toggledOn = defaultValue;
		}
		return entry.toggledOn;
	}

	private void _Update()
	{
		if ((!Application.isEditor || !RInput.GetButton(11)) && (Application.isEditor || !RInput.GetButton(12) || !RInput.GetButton(39)))
		{
			return;
		}
		foreach (Entry child in cur.children)
		{
			if (GetKeyDown(child.hotkey))
			{
				Click(child);
			}
		}
		if (RInput.GetButtonDown(31))
		{
			int num = cur.children.IndexOf(cur.selectedEntry);
			cur.selectedEntry = cur.children[Mathf.Max(0, num - 1)];
		}
		else if (RInput.GetButtonDown(32))
		{
			int num2 = cur.children.IndexOf(cur.selectedEntry);
			cur.selectedEntry = cur.children[Mathf.Min(cur.children.Count - 1, num2 + 1)];
		}
		else if (RInput.GetButtonDown(33) && cur.parent != null)
		{
			cur = cur.parent;
		}
		if (RInput.GetButtonDown(40))
		{
			Click(cur.selectedEntry);
		}
		DebugDrawer.Screen(Draw);
	}

	private void Click(Entry entry)
	{
		if (entry.children.Count != 0)
		{
			cur = entry;
			return;
		}
		entry.clickedTime = Time.time;
		if (entry.clickFunc == new ClickFunc(ToggleEntryStub) || entry.clickFunc == null)
		{
			entry.toggledOn = !entry.toggledOn;
		}
		else
		{
			entry.clickFunc();
		}
	}

	private void Draw(DebugDrawer dd)
	{
		int num = 6;
		int num2 = 4;
		Color color = new Color(0f, 0f, 0f, 0.5f);
		Color color2 = new Color(1f, 1f, 1f, 1f);
		Color color3 = new Color(1f, 1f, 0.75f, 1f);
		Color color4 = new Color(1f, 0f, 0f, 1f);
		Color color5 = new Color(1f, 0f, 0f, 1f);
		float num3 = 0f;
		float num4 = 0f;
		foreach (Entry child in cur.children)
		{
			Vector2 textSize = dd.GetTextSize(child.displayName, num);
			num3 = Mathf.Max(num3, textSize.x);
			num4 += textSize.y + (float)num2;
		}
		int num5 = 4;
		int num6 = 8;
		int num7 = num6 + 2 * num5 + (int)num3;
		int num8 = 2 * num5 + (int)num4;
		Rect rect = new Rect(DebugDrawer.screenWidth - num7, DebugDrawer.screenHeight - num8, num7, num8);
		dd.FillRect(color, rect);
		Vector3 center = new Vector3(rect.x + (float)num5 + (float)num6, rect.y + rect.height - (float)num5 - (float)(num / 2));
		foreach (Entry child2 in cur.children)
		{
			Color color6 = color2;
			if (child2.clickedRecently)
			{
				color6 = color4;
			}
			else if (child2.toggledOn)
			{
				color6 = color3;
			}
			dd.DrawText(color6, child2.displayName, center, num, true);
			if (child2 == cur.selectedEntry)
			{
				dd.DrawCircle(color5, new Vector3(center.x - (float)num5 - (float)(num6 / 2), center.y), num / 4);
			}
			center.y -= num + num2;
		}
	}

	public static void ToggleEntryStub()
	{
	}

	public static bool GetKeyDown(KeyCode key)
	{
		if (!enabled)
		{
			return false;
		}
		return Input.GetKeyDown(key);
	}

	public static bool WantSkip()
	{
		if (!enabled)
		{
			return false;
		}
		return Input.GetKeyDown(KeyCode.RightBracket);
	}
}
