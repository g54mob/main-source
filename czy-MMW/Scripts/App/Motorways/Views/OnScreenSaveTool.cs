using System.Collections.Generic;
using System.IO;
using DevTools.OnScreenDebugTools;
using Factory;
using UnityEngine;

namespace Motorways.Views
{
	public class OnScreenSaveTool : IOnScreenTool
	{
		private enum View
		{
			SavedGameList = 0,
			DownloadReport = 1,
			DownloadingReport = 2
		}

		private class SavedJournalInfo
		{
			public readonly string name;

			public readonly string filepath;

			public bool pendingDeleteConfirmation;

			public SavedJournalInfo(string name, string filepath)
			{
				this.name = name;
				this.filepath = filepath;
			}
		}

		private readonly IScope _scope;

		private readonly IActivePlayer _activePlayer;

		private readonly OnScreenDebugStorage _debugStorage;

		private readonly StorableTypeHandlerRegistry _storableTypeHandlerRegistry;

		private View _currentView;

		private GUIStyle _sectionHeaderStyle;

		private GUIStyle _listButtonStyle;

		private GUIStyle _disabledListButtonStyle;

		private GUIStyle _listLabelStyle;

		private GUIStyle _toggleStyle;

		private GUIStyle _reportIdLabelStyle;

		private GUIStyle _numberPadButtonStyle;

		private GUIStyle _actionButtonStyle;

		private GUIStyle _downloadStatusLabelStyle;

		private static readonly Vector2Int BaseResolution = new Vector2Int(1920, 1080);

		private const int BaseWindowWidth = 480;

		private const int BaseWindowHeight = 720;

		private static readonly Rect DefaultWindowRect = new Rect(BaseResolution.x - 480, 0.5f * (float)(BaseResolution.y - 720), 480f, 720f);

		private Rect _windowRect = DefaultWindowRect;

		private IReadOnlyList<SavedJournalInfo> _savedJournalInfo;

		private GameStarter _gameStarter;

		private bool _startGamesPaused;

		private const int MaxReportIdDigits = 10;

		private const string DefaultReportId = "";

		private string _reportIdInput = "";

		private bool _isDownloadingReport;

		private Diagnostics.Report _remoteReport;

		private const string ClearButton = "C";

		private const string BackspaceButton = "<";

		private readonly string[] _numberPadButtons = new string[12]
		{
			"1", "2", "3", "4", "5", "6", "7", "8", "9", "C",
			"0", "<"
		};

		private const int NoButtonSelected = -1;

		private int _selectedGridButtonIndex = -1;

		private const string GameJournalFileExtension = ".gamejournal";

		public Rect InputBlockingRect => _windowRect;

		public OnScreenSaveTool(IScope scope)
		{
			_scope = scope;
			_activePlayer = scope.Get<IActivePlayer>();
			_debugStorage = scope.Get<OnScreenDebugStorage>();
			_storableTypeHandlerRegistry = scope.Get<StorableTypeHandlerRegistry>();
		}

		public void OnGUI(IScope scope)
		{
			if (_reportIdLabelStyle == null)
			{
				_reportIdLabelStyle = new GUIStyle(GUI.skin.label)
				{
					fontSize = 30
				};
			}
			if (_numberPadButtonStyle == null)
			{
				_numberPadButtonStyle = new GUIStyle(GUI.skin.button)
				{
					fontSize = 30
				};
			}
			if (_sectionHeaderStyle == null)
			{
				_sectionHeaderStyle = new GUIStyle(GUI.skin.label)
				{
					fontSize = 40,
					alignment = TextAnchor.MiddleCenter
				};
			}
			if (_downloadStatusLabelStyle == null)
			{
				_downloadStatusLabelStyle = new GUIStyle(GUI.skin.label)
				{
					fontSize = 30,
					wordWrap = true,
					alignment = TextAnchor.MiddleCenter
				};
			}
			if (_listButtonStyle == null)
			{
				_listButtonStyle = new GUIStyle(GUI.skin.button)
				{
					fontSize = 30,
					padding = new RectOffset(5, 5, 5, 5)
				};
			}
			if (_disabledListButtonStyle == null)
			{
				_disabledListButtonStyle = new GUIStyle(_listButtonStyle);
			}
			_disabledListButtonStyle.normal.textColor = Color.gray;
			if (_listLabelStyle == null)
			{
				_listLabelStyle = new GUIStyle(GUI.skin.label)
				{
					fontSize = 30,
					margin = new RectOffset(0, 0, 5, 0)
				};
			}
			if (_actionButtonStyle == null)
			{
				_actionButtonStyle = new GUIStyle(GUI.skin.button)
				{
					fontSize = 30,
					padding = new RectOffset(0, 0, 10, 10)
				};
			}
			if (_toggleStyle == null)
			{
				_toggleStyle = new GUIStyle(GUI.skin.toggle)
				{
					fontSize = 25
				};
			}
			if (_savedJournalInfo == null)
			{
				_savedJournalInfo = LoadSavedJournalList();
			}
			_windowRect = GUI.Window(0, _windowRect, DrawReportDownloadWindow, "Save Tool");
		}

		private void DrawReportDownloadWindow(int windowId)
		{
			Rect contentRect = new Rect(60f, 18f, 360f, 684f);
			switch (_currentView)
			{
			case View.SavedGameList:
				DrawSaveGameListView(contentRect);
				break;
			case View.DownloadReport:
				DrawDownloadReportView(contentRect);
				break;
			case View.DownloadingReport:
				DrawDownloadingReportView(contentRect);
				break;
			}
			GUI.DragWindow(new Rect(0f, 0f, 360f, 684f));
		}

		private void DrawSaveGameListView(Rect contentRect)
		{
			GUILayout.BeginArea(contentRect);
			GUILayout.Space(0.03f * contentRect.height);
			if (GUILayout.Button("Load Remote Save", _actionButtonStyle))
			{
				_currentView = View.DownloadReport;
				return;
			}
			GUILayout.Space(0.02f * contentRect.height);
			GUILayout.Label("Downloaded Saves", _sectionHeaderStyle);
			GUILayout.Space(0.01f * contentRect.height);
			if (_savedJournalInfo == null || _savedJournalInfo.Count < 0)
			{
				GUILayout.Label("No saves downloaded.");
			}
			else
			{
				_startGamesPaused = GUILayout.Toggle(_startGamesPaused, " Start Paused?", _toggleStyle);
				GUILayout.Space(0.03f * contentRect.height);
				foreach (SavedJournalInfo item in _savedJournalInfo)
				{
					GUILayout.BeginHorizontal();
					GUILayout.Label(item.name, _listLabelStyle);
					if (GUILayout.Button("Load", _listButtonStyle) && _gameStarter == null && LoadJournalSave(item.filepath) is MotorwaysGameJournalSave save)
					{
						SaveToolUtilities.StartGame(save, _startGamesPaused, _scope, ref _gameStarter);
					}
					if (item.pendingDeleteConfirmation)
					{
						if (GUILayout.Button(" Sure?", _listButtonStyle))
						{
							_debugStorage.Delete(item.filepath);
							RefreshSavedJournalList();
						}
					}
					else if (GUILayout.Button("Delete", _listButtonStyle))
					{
						item.pendingDeleteConfirmation = true;
					}
					GUILayout.EndHorizontal();
					GUILayout.Space(0.05f * contentRect.height);
				}
			}
			GUILayout.EndArea();
		}

		private void DrawDownloadReportView(Rect contentRect)
		{
			GUI.BeginGroup(contentRect);
			GUIContent content = new GUIContent(_reportIdInput);
			Vector2 vector = _reportIdLabelStyle.CalcSize(content);
			float num = 0.1f * contentRect.height;
			GUI.BeginGroup(new Rect(0f, 0f, contentRect.width, num));
			GUI.Label(new Rect(0.5f * (contentRect.width - vector.x), 0.5f * (num - vector.y), vector.x, vector.y), content, _reportIdLabelStyle);
			GUI.EndGroup();
			GUILayout.BeginArea(new Rect(0f, num, contentRect.width, 0.9f * contentRect.height));
			_selectedGridButtonIndex = GUILayout.SelectionGrid(_selectedGridButtonIndex, _numberPadButtons, 3, _numberPadButtonStyle, GUILayout.ExpandHeight(expand: true), GUILayout.MaxWidth(contentRect.width));
			if (_selectedGridButtonIndex != -1)
			{
				string text = _numberPadButtons[_selectedGridButtonIndex];
				if (_reportIdInput.Length < 10 && int.TryParse(text, out var result))
				{
					_reportIdInput += result;
				}
				else if (text == "C")
				{
					_reportIdInput = "";
				}
				else if (text == "<" && _reportIdInput.Length > 0)
				{
					_reportIdInput = _reportIdInput.Remove(_reportIdInput.Length - 1);
				}
				_selectedGridButtonIndex = -1;
			}
			GUILayout.BeginVertical();
			if (GUILayout.Button("Download", _actionButtonStyle) && _reportIdInput.Length > 0 && int.TryParse(_reportIdInput, out var result2))
			{
				_isDownloadingReport = true;
				_remoteReport = Diagnostics.Report.Download(result2);
				_currentView = View.DownloadingReport;
			}
			if (GUILayout.Button("Back", _actionButtonStyle))
			{
				_remoteReport = null;
				_currentView = View.SavedGameList;
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
			GUI.EndGroup();
		}

		private void DrawDownloadingReportView(Rect contentRect)
		{
			GUI.BeginGroup(contentRect);
			string text = _remoteReport.State.ToString();
			float height = 0.5f * contentRect.height;
			float num = 0.2f * contentRect.height;
			GUIContent content = new GUIContent(text);
			float num2 = _downloadStatusLabelStyle.CalcHeight(content, contentRect.width);
			GUILayout.BeginArea(new Rect(0f, 0.5f * (contentRect.height - (num2 + num)), contentRect.width, height));
			GUILayout.BeginVertical();
			GUILayout.Label(content, _downloadStatusLabelStyle);
			if (GUILayout.Button("Back", _actionButtonStyle))
			{
				_remoteReport = null;
				_currentView = View.SavedGameList;
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
			GUI.EndGroup();
		}

		public void Update()
		{
			if (_gameStarter != null && _gameStarter.CanStart)
			{
				ScreenStack screenStack = _scope.Get<ScreenStack>();
				if (screenStack.GetTopActiveScreenType() == ScreenStack.MotorwaysScreen.MainMenu)
				{
					_gameStarter.Start(screenStack, _scope);
					_gameStarter = null;
				}
			}
			if (!_isDownloadingReport || _remoteReport == null || _remoteReport.State == Diagnostics.ReportState.Searching || _remoteReport.State == Diagnostics.ReportState.Downloading)
			{
				return;
			}
			foreach (Diagnostics.ReportAttachment attachment in _remoteReport.Attachments)
			{
				if (!(attachment.Filename != "simulation.gamejournal") && OnScreenDebugStorage.LoadBytesFromFile(attachment.LocalFilepath, out var bytes) && _storableTypeHandlerRegistry.GetHandlerForType(typeof(MotorwaysGameJournalSave)) is SavedGameStorableTypeHandler savedGameStorableTypeHandler)
				{
					IStorable storable = savedGameStorableTypeHandler.Load(bytes);
					if (storable != null && storable is IGameJournalSave newForeignSavedGame)
					{
						_debugStorage.Store(_remoteReport.Id + ".gamejournal", bytes);
						RefreshSavedJournalList();
						_activePlayer.AddForeignSavedGame(newForeignSavedGame);
					}
				}
			}
			_isDownloadingReport = false;
		}

		public void Reset()
		{
			_reportIdInput = "";
			_windowRect = DefaultWindowRect;
		}

		private void RefreshSavedJournalList()
		{
			_savedJournalInfo = LoadSavedJournalList();
		}

		private IGameJournalSave LoadJournalSave(string filepath)
		{
			IStorableTypeHandler handlerForType = _storableTypeHandlerRegistry.GetHandlerForType(typeof(MotorwaysGameJournalSave));
			if (OnScreenDebugStorage.LoadBytesFromFile(filepath, out var bytes))
			{
				return handlerForType.Load(bytes) as IGameJournalSave;
			}
			return null;
		}

		private IReadOnlyList<SavedJournalInfo> LoadSavedJournalList()
		{
			string[] array = _debugStorage.LoadAll();
			if (array == null)
			{
				return new List<SavedJournalInfo>().AsReadOnly();
			}
			List<SavedJournalInfo> list = new List<SavedJournalInfo>(array.Length);
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.EndsWith(".gamejournal"))
				{
					string fileName = Path.GetFileName(text);
					string name = fileName.Substring(0, fileName.Length - ".gamejournal".Length);
					list.Add(new SavedJournalInfo(name, text));
				}
			}
			return list;
		}
	}
}
