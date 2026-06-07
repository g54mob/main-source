using System;
using UnityEngine;

public class GUIIconBrowser : MonoBehaviour
{
	private static bool _shown;

	[NonSerialized]
	private string _search;

	[NonSerialized]
	private Rect _windowRect = new Rect(0f, 0f, 256f, 512f);

	[NonSerialized]
	private Vector2 _scroll;

	private void Awake()
	{
		if (_shown)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		_windowRect.x = (float)Screen.width / 2f - _windowRect.width / 2f;
		_windowRect.y = (float)Screen.height / 2f - _windowRect.height / 2f;
		_shown = true;
	}

	private void OnGUI()
	{
		_windowRect = GUI.Window(0, _windowRect, delegate
		{
			_search = GUILayout.TextField(_search);
			_scroll = GUILayout.BeginScrollView(_scroll);
			string text = (string.IsNullOrWhiteSpace(_search) ? null : _search.ToLower());
			ObjectDatabase.IconObject[] iconObjects = ObjectDatabase.Instance.IconObjects;
			for (int i = 0; i < iconObjects.Length; i++)
			{
				ObjectDatabase.IconObject iconObject = iconObjects[i];
				if (text == null || iconObject.Name.ToLower().Contains(text))
				{
					Rect rect = GUILayoutUtility.GetRect(0f, 999f, 34f, 34f);
					rect = new Rect(rect.x, rect.y, rect.width, 32f);
					DrawSprite(iconObject.Icon, rect);
					GUI.Label(new Rect(rect.x + rect.height + 4f, rect.y + 4f, rect.width - rect.height - 4f, rect.height), iconObject.Name);
				}
			}
			GUILayout.EndScrollView();
			if (GUILayout.Button("Close"))
			{
				_shown = false;
				UnityEngine.Object.Destroy(base.gameObject);
			}
			GUI.DragWindow();
		}, "Icons");
	}

	private void DrawSprite(Sprite icon, Rect r)
	{
		if (icon.packed)
		{
			Rect textureRect = icon.textureRect;
			int width = icon.texture.width;
			int height = icon.texture.height;
			textureRect = new Rect(textureRect.x / (float)width, textureRect.y / (float)height, textureRect.width / (float)width, textureRect.height / (float)height);
			float num = textureRect.width / textureRect.height;
			float num2 = r.height;
			float num3 = r.height;
			if (num > 1f)
			{
				num3 = r.height / num;
			}
			else
			{
				num2 = r.height * num;
			}
			GUI.DrawTextureWithTexCoords(new Rect(r.x + (r.height - num2) / 2f, r.y + (r.height - num3) / 2f, num2, num3), icon.texture, textureRect);
		}
		else
		{
			GUI.DrawTexture(new Rect(r.x, r.y, r.height, r.height), icon.texture);
		}
	}
}
