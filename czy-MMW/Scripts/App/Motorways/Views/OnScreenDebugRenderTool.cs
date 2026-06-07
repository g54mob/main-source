using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways.Views
{
	public class OnScreenDebugRenderTool : IOnScreenTool
	{
		private class RendererSetViewInfo
		{
			public bool isCollapsed = true;

			public Vector2 scrollPosition = Vector2.zero;
		}

		private IDebugRenderSetManager _debugRenderSetManager;

		private static readonly Vector2Int BaseResolution = new Vector2Int(1920, 1080);

		private const int BaseWindowWidth = 500;

		private const int BaseWindowHeight = 720;

		private static readonly Rect DefaultWindowRect = new Rect(BaseResolution.x - 500, 0.5f * (float)(BaseResolution.y - 720), 500f, 720f);

		private Rect _windowRect = DefaultWindowRect;

		private GUIStyle _headerStyle;

		private GUIStyle _rootStyle;

		private GUIStyle _levelOneStyle;

		private GUIStyle _leftButtonStyle;

		private readonly Color _mutedColor = new Color(0.8f, 0f, 0f);

		private Vector2 _scrollPosition = Vector2.zero;

		private readonly Dictionary<string, RendererSetViewInfo> _rendererSetViewInfos = new Dictionary<string, RendererSetViewInfo>();

		public Rect InputBlockingRect => _windowRect;

		public void OnGUI(IScope scope)
		{
			_debugRenderSetManager = scope.Get<IDebugRenderSetManager>();
			if (_headerStyle == null)
			{
				_headerStyle = new GUIStyle(GUI.skin.label)
				{
					fontSize = 35,
					alignment = TextAnchor.MiddleCenter,
					margin = new RectOffset(20, 20, 30, 5),
					wordWrap = false
				};
			}
			if (_rootStyle == null)
			{
				_rootStyle = new GUIStyle(GUI.skin.label)
				{
					fontSize = 30,
					alignment = TextAnchor.MiddleLeft,
					wordWrap = false,
					margin = new RectOffset(0, 0, 10, 0)
				};
			}
			if (_levelOneStyle == null)
			{
				_levelOneStyle = new GUIStyle(GUI.skin.label)
				{
					fontSize = 25,
					alignment = TextAnchor.MiddleLeft,
					margin = new RectOffset(20, 0, 10, 0),
					wordWrap = false
				};
			}
			if (_leftButtonStyle == null)
			{
				_leftButtonStyle = new GUIStyle(GUI.skin.button)
				{
					fontSize = 50,
					alignment = TextAnchor.MiddleLeft,
					margin = new RectOffset(20, 20, 0, 20)
				};
			}
			GUI.skin.verticalScrollbar.fixedWidth = 30f;
			GUI.skin.verticalScrollbarThumb.fixedWidth = 30f;
			_windowRect = GUI.Window(1, _windowRect, DrawDebugRenderSetWindow, "Render Set Tool");
		}

		public void Update()
		{
		}

		private void DrawDebugRenderSetWindow(int windowId)
		{
			GUILayout.BeginArea(new Rect(12.5f, 18f, 475f, 684f));
			GUILayout.Label("Views", _headerStyle);
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, false, true);
			if (_debugRenderSetManager.RendererSets == null)
			{
				return;
			}
			foreach (KeyValuePair<string, DebugRendererSet> rendererSet in _debugRenderSetManager.RendererSets)
			{
				string key = rendererSet.Key;
				if (!_rendererSetViewInfos.ContainsKey(key))
				{
					_rendererSetViewInfos.Add(key, new RendererSetViewInfo());
				}
				RendererSetViewInfo rendererSetViewInfo = _rendererSetViewInfos[key];
				DebugRendererSet value = rendererSet.Value;
				GUILayout.BeginHorizontal();
				if (GUILayout.Button(rendererSetViewInfo.isCollapsed ? ">" : "v", _leftButtonStyle))
				{
					rendererSetViewInfo.isCollapsed = !rendererSetViewInfo.isCollapsed;
				}
				GUILayout.Label(Truncate(key, 20), _rootStyle);
				GUILayout.FlexibleSpace();
				bool allRenderersMuted = value.AllRenderersMuted;
				Color backgroundColor = GUI.backgroundColor;
				if (allRenderersMuted)
				{
					GUI.backgroundColor = _mutedColor;
				}
				if (GUILayout.Button("M", _leftButtonStyle))
				{
					value.SetAllRenderersMuted(!allRenderersMuted);
				}
				GUI.backgroundColor = backgroundColor;
				GUILayout.EndHorizontal();
				if (rendererSetViewInfo.isCollapsed)
				{
					continue;
				}
				rendererSetViewInfo.scrollPosition = GUILayout.BeginScrollView(rendererSetViewInfo.scrollPosition, false, true);
				foreach (string rendererName in value.RendererNames)
				{
					GUILayout.BeginHorizontal();
					bool flag = value.AreRenderersWithNameMuted(rendererName);
					GUILayout.Label(Truncate(rendererName, 20), _levelOneStyle);
					Color backgroundColor2 = GUI.backgroundColor;
					if (flag)
					{
						GUI.backgroundColor = _mutedColor;
					}
					GUILayout.FlexibleSpace();
					if (GUILayout.Button("M", _leftButtonStyle))
					{
						value.SetRendersWithNameMuted(rendererName, !flag);
					}
					GUI.backgroundColor = backgroundColor2;
					GUILayout.EndHorizontal();
				}
				GUILayout.EndScrollView();
				break;
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUI.DragWindow(new Rect(0f, 0f, 475f, 684f));
		}

		private string Truncate(string input, int maxCharacters, string truncationString = "...")
		{
			if (input.Length > maxCharacters)
			{
				return input.Substring(0, maxCharacters - truncationString.Length) + truncationString;
			}
			return input;
		}
	}
}
