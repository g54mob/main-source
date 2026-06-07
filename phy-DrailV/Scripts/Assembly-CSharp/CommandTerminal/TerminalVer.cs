using DV;
using UnityEngine;

namespace CommandTerminal
{
	public class TerminalVer : Terminal
	{
		private GUIStyle _versionStyle;

		private string _text;

		private GUIStyle VersionStyle
		{
			get
			{
				if (_versionStyle == null)
				{
					_versionStyle = new GUIStyle(GUI.skin.label);
					_versionStyle.alignment = TextAnchor.UpperRight;
					_versionStyle.font = ConsoleFont;
					_versionStyle.fontSize = 12;
					_versionStyle.normal.textColor = new Color(0.8f, 0.8f, 0.8f, 0.4f);
				}
				return _versionStyle;
			}
		}

		private string Text
		{
			get
			{
				if (_text == null)
				{
					string text = (string.IsNullOrWhiteSpace(BuildInfo.BUILDBOT_INFO) ? "" : ("-" + BuildInfo.BUILDBOT_INFO));
					string[] value = new string[7]
					{
						BuildInfo.BUILD_VERSION_STR + text,
						(Debug.isDebugBuild ? "development build" : "release build") + " - " + BuildInfo.BUILD_DESTINATION,
						"Unity " + Application.unityVersion,
						SystemInfo.operatingSystem ?? "",
						$"{SystemInfo.processorType} - {SystemInfo.processorFrequency} MHz",
						$"{SystemInfo.graphicsDeviceName} - {SystemInfo.graphicsMemorySize} MB VRAM",
						$"{SystemInfo.systemMemorySize} MB RAM"
					};
					_text = string.Join("\n", value);
					_text = _text.Replace("  ", " ");
				}
				return _text;
			}
		}

		protected override void DrawConsole(int Window2D)
		{
			string text = Text;
			GUIStyle versionStyle = VersionStyle;
			GUIContent content = new GUIContent(text);
			Vector2 vector = versionStyle.CalcSize(content);
			GUI.Label(new Rect((float)Screen.width - vector.x - 7f, 2f, vector.x, vector.y), text, versionStyle);
			base.DrawConsole(Window2D);
		}
	}
}
