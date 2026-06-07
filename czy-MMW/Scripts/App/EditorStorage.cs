using System;
using System.Collections.Generic;
using System.IO;
using Factory;
using UnityEngine;

public class EditorStorage : LocalFileStorage, ICreatedInScopeHandler
{
	private PersistentStorageServiceStatus _status;

	private static List<string> IgnoredFilenames = new List<string> { "Thumbs.db", "desktop.ini", ".DS_Store", ".Spotlight-V100", ".Trashes" };

	[Dependency]
	private PlayerDatabase _playerDatabase;

	private static EditorStorage Instance;

	public static readonly string GlobalSavedGamePath = Path.Combine(Application.persistentDataPath, "EditorGameJournals");

	private string StatusMessageKey
	{
		get
		{
			return _status.messageKey;
		}
		set
		{
			if (_status.messageKey != value)
			{
				_status.messageKey = value;
				SetStatus(_status);
			}
		}
	}

	public override void LoadAll(Action loadCompleteCallback)
	{
		IStorableTypeHandler handlerForType = _storableTypeHandlerRegistry.GetHandlerForType<IGameJournalSave>();
		if (handlerForType != null && Directory.Exists(GlobalSavedGamePath))
		{
			string[] files = Directory.GetFiles(GlobalSavedGamePath);
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				if (!IgnoredFilenames.Contains(fileName))
				{
					byte[] data;
					try
					{
						data = File.ReadAllBytes(text);
					}
					catch (Exception ex)
					{
						LocalFileStorage.Log.Warn("Failed to load global saved game from {0}.\n{1}", text, ex);
						continue;
					}
					IStorable storable = handlerForType.Load(data);
					if (storable == null)
					{
						LocalFileStorage.Log.Warn("Failed to load global saved game from {0}.", text);
					}
					else if (storable is IGameJournalSave newGlobalSavedGame)
					{
						_playerDatabase.AddGlobalSavedGame(newGlobalSavedGame);
					}
				}
			}
		}
		base.LoadAll(loadCompleteCallback);
	}

	public void OnCreatedInScope(IScope scope)
	{
		Instance = this;
	}

	private void ToggleStatusIssue(PersistentStorageServiceIssues issueToToggle)
	{
		_status.issues ^= issueToToggle;
		SetStatus(_status);
	}
}
