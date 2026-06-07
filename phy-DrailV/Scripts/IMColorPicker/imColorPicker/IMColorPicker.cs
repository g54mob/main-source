using UnityEngine;

namespace imColorPicker
{
	public class IMColorPicker
	{
		public Color RevertColor;

		private Color _color;

		private IMColorPreset preset;

		private float h;

		private float s = 1f;

		private float v = 1f;

		private Rect windowRect = new Rect(20f, 20f, 165f, 100f);

		private GUIStyle previewStyle;

		private GUIStyle labelStyle;

		private GUIStyle svStyle;

		private GUIStyle hueStyle;

		private GUIStyle presetStyle;

		private GUIStyle presetHighlightedStyle;

		private int selectedPreset = -1;

		private Texture2D hueTexture;

		private Texture2D svTexture;

		private Texture2D circle;

		private Texture2D rightArrow;

		private Texture2D leftArrow;

		private Texture2D upArrow;

		private Texture2D button;

		private Texture2D buttonHighlighted;

		private const int kHSVPickerSize = 120;

		private const int kHuePickerWidth = 16;

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
				IMColorUtil.RGBToHSV(_color, out h, out s, out v);
				UpdateSVTexture(_color, svTexture);
			}
		}

		public float H => h;

		public float S => s;

		public float V => v;

		public IMColorPicker()
			: this(Color.red, null)
		{
		}

		public IMColorPicker(Color c)
			: this(c, null)
		{
		}

		public IMColorPicker(IMColorPreset pr)
			: this(Color.red, pr)
		{
		}

		public IMColorPicker(Color c, IMColorPreset pr)
		{
			_color = c;
			RevertColor = c;
			preset = pr;
			Setup();
		}

		private void Setup()
		{
			IMColorUtil.RGBToHSV(_color, out h, out s, out v);
			circle = Resources.Load<Texture2D>("imCircle");
			rightArrow = Resources.Load<Texture2D>("imRight");
			leftArrow = Resources.Load<Texture2D>("imLeft");
			upArrow = Resources.Load<Texture2D>("imUp");
			button = Resources.Load<Texture2D>("imBorder");
			buttonHighlighted = Resources.Load<Texture2D>("imBorderHighlighted");
			previewStyle = new GUIStyle();
			previewStyle.normal.background = Texture2D.whiteTexture;
			labelStyle = new GUIStyle();
			labelStyle.fontSize = 12;
			hueTexture = CreateHueTexture(20, 120);
			hueStyle = new GUIStyle();
			hueStyle.normal.background = hueTexture;
			svTexture = CreateSVTexture(_color, 120);
			svStyle = new GUIStyle();
			svStyle.normal.background = svTexture;
			presetStyle = new GUIStyle();
			presetStyle.normal.background = button;
			presetHighlightedStyle = new GUIStyle();
			presetHighlightedStyle.normal.background = buttonHighlighted;
		}

		public void SetWindowPosition(float x, float y)
		{
			windowRect.x = x;
			windowRect.y = y;
		}

		public void SetColor(Color color)
		{
			Color = color;
			RevertColor = color;
		}

		public void DrawWindow(int id = 0, string title = "IMColorPicker")
		{
			windowRect = GUI.Window(id, windowRect, DrawColorPickerWindow, title);
		}

		private void DrawColorPickerWindow(int windowID)
		{
			DrawColorPicker();
			if (Event.current.type == EventType.Repaint)
			{
				Rect lastRect = GUILayoutUtility.GetLastRect();
				windowRect.height = lastRect.y + lastRect.height + 10f;
			}
			GUI.DragWindow();
		}

		public void DrawColorPicker()
		{
			using (new GUILayout.VerticalScope())
			{
				GUILayout.Space(5f);
				DrawPreview(ref _color);
				GUILayout.Space(10f);
				DrawHSVPicker(ref _color);
				if (preset != null)
				{
					GUILayout.Space(5f);
					DrawPresets();
				}
			}
		}

		private void DrawPreview(ref Color c)
		{
			using (new GUILayout.VerticalScope())
			{
				Color backgroundColor = GUI.backgroundColor;
				float num = 146f;
				using (new GUILayout.HorizontalScope())
				{
					GUI.backgroundColor = new Color(c.r, c.g, c.b);
					GUILayout.Label("", previewStyle, GUILayout.Width(num * 0.6f), GUILayout.Height(14f));
					GUI.backgroundColor = new Color(RevertColor.r, RevertColor.g, RevertColor.b);
					if (GUILayout.Button("", previewStyle, GUILayout.Width(num * 0.4f), GUILayout.Height(14f)))
					{
						Color = RevertColor;
					}
				}
				GUILayout.Space(1f);
				float a = c.a;
				GUI.backgroundColor = new Color(a, a, a);
				GUILayout.Label("", previewStyle, GUILayout.Width(num), GUILayout.Height(3f));
				DrawAlphaHandler(GUILayoutUtility.GetLastRect(), ref c);
				GUI.backgroundColor = backgroundColor;
			}
		}

		private void DrawHSVPicker(ref Color c)
		{
			using (new GUILayout.HorizontalScope())
			{
				GUILayout.Label("", svStyle, GUILayout.Width(120f), GUILayout.Height(120f));
				DrawSVHandler(GUILayoutUtility.GetLastRect(), ref c);
				GUILayout.Space(10f);
				GUILayout.Label("", hueStyle, GUILayout.Width(16f), GUILayout.Height(120f));
				DrawHueHandler(GUILayoutUtility.GetLastRect(), ref c);
			}
		}

		private void DrawPresets()
		{
			GUILayout.Label("Presets", labelStyle);
			GUILayout.Space(2f);
			Color backgroundColor = GUI.backgroundColor;
			int count = preset.Colors.Count;
			Event current = Event.current;
			int i = 0;
			for (int num = count / 10; i <= num; i++)
			{
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(1f);
					int num2 = Mathf.Min(count, (i + 1) * 10);
					for (int j = i * 10; j < num2; j++)
					{
						Color color = (GUI.backgroundColor = preset.Colors[j]);
						if (GUILayout.Button(" ", (j == selectedPreset) ? presetHighlightedStyle : presetStyle, GUILayout.Width(16f), GUILayout.Height(16f)))
						{
							switch (current.button)
							{
							case 0:
								selectedPreset = j;
								Color = color;
								break;
							case 1:
								preset.Colors.RemoveAt(j);
								ClearPresetSelection();
								return;
							}
						}
						GUILayout.Space(1f);
					}
				}
			}
			GUI.backgroundColor = backgroundColor;
			using (new GUILayout.HorizontalScope())
			{
				if (GUILayout.Button("Save", GUILayout.Width(67f), GUILayout.Height(20f)))
				{
					preset.Save(Color);
					selectedPreset = preset.Colors.Count - 1;
				}
				if (selectedPreset >= 0 && GUILayout.Button("Remove", GUILayout.Width(67f), GUILayout.Height(20f)))
				{
					preset.Colors.RemoveAt(selectedPreset);
					ClearPresetSelection();
				}
			}
		}

		private void ClearPresetSelection()
		{
			selectedPreset = -1;
		}

		private void DrawSVHandler(Rect rect, ref Color c)
		{
			GUI.DrawTexture(new Rect(rect.x + s * rect.width - 5f, rect.y + (1f - v) * rect.height - 5f, 10f, 10f), circle);
			Event current = Event.current;
			Vector2 mousePosition = current.mousePosition;
			if (current.button == 0 && (current.type == EventType.MouseDown || current.type == EventType.MouseDrag) && rect.Contains(mousePosition))
			{
				s = (mousePosition.x - rect.x) / rect.width;
				v = 1f - (mousePosition.y - rect.y) / rect.height;
				float a = c.a;
				c = IMColorUtil.HSVToRGB(h, s, v);
				c.a = a;
				current.Use();
				ClearPresetSelection();
			}
		}

		private void DrawHueHandler(Rect rect, ref Color c)
		{
			GUI.DrawTexture(new Rect(rect.x - 11.25f, rect.y + (1f - h) * rect.height - 7.5f, 15f, 15f), rightArrow);
			GUI.DrawTexture(new Rect(rect.x + rect.width - 3.75f, rect.y + (1f - h) * rect.height - 7.5f, 15f, 15f), leftArrow);
			Event current = Event.current;
			Vector2 mousePosition = current.mousePosition;
			if (current.button == 0 && (current.type == EventType.MouseDown || current.type == EventType.MouseDrag) && rect.Contains(mousePosition))
			{
				h = 1f - (mousePosition.y - rect.y) / rect.height;
				float a = c.a;
				c = IMColorUtil.HSVToRGB(h, s, v);
				c.a = a;
				UpdateSVTexture(c, svTexture);
				current.Use();
				ClearPresetSelection();
			}
		}

		private void DrawAlphaHandler(Rect rect, ref Color c)
		{
			float a = c.a;
			GUI.DrawTexture(new Rect(rect.x + a * rect.width - 7.5f, rect.y, 15f, 15f), upArrow);
			Event current = Event.current;
			Vector2 mousePosition = current.mousePosition;
			Rect rect2 = new Rect(rect.x - 5f, rect.y - 7f, rect.width + 10f, rect.height + 14f);
			if (current.button == 0 && (current.type == EventType.MouseDown || current.type == EventType.MouseDrag) && rect2.Contains(mousePosition))
			{
				c.a = Mathf.Clamp01((mousePosition.x - rect.x) / rect.width);
				current.Use();
				ClearPresetSelection();
			}
		}

		private void UpdateSVTexture(Color c, Texture2D tex)
		{
			IMColorUtil.RGBToHSV(c, out var H, out var _, out var _);
			int width = tex.width;
			for (int i = 0; i < width; i++)
			{
				float num = 1f * (float)i / (float)width;
				for (int j = 0; j < width; j++)
				{
					float num2 = 1f * (float)j / (float)width;
					Color color = IMColorUtil.HSVToRGB(H, num2, num);
					tex.SetPixel(j, i, color);
				}
			}
			tex.Apply();
		}

		private Texture2D CreateHueTexture(int width, int height)
		{
			Texture2D texture2D = new Texture2D(width, height);
			for (int i = 0; i < height; i++)
			{
				Color color = IMColorUtil.HSVToRGB(1f * (float)i / (float)height, 1f, 1f);
				for (int j = 0; j < width; j++)
				{
					texture2D.SetPixel(j, i, color);
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		private Texture2D CreateSVTexture(Color c, int size)
		{
			Texture2D texture2D = new Texture2D(size, size);
			UpdateSVTexture(c, texture2D);
			return texture2D;
		}
	}
}
