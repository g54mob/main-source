using System.Collections.Generic;
using Factory;
using UnityEngine;

public class JournalAppCommandSource : IAppCommandSource
{
	[Dependency]
	private AppCommandJournal _journal;

	private int _commandCursor;

	private readonly List<IAppCommand> _frameCommands = new List<IAppCommand>(8);

	private int _journalFramesPerRuntimeFrame = 1;

	public void Start()
	{
	}

	public IEnumerable<IAppCommand> GetFrameCommands()
	{
		_frameCommands.Clear();
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			_journalFramesPerRuntimeFrame++;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_journalFramesPerRuntimeFrame = Mathf.Max(1, _journalFramesPerRuntimeFrame - 1);
		}
		for (int i = 0; i < _journalFramesPerRuntimeFrame; i++)
		{
			if (_commandCursor >= _journal.EntryCount)
			{
				continue;
			}
			IAppCommand entry = _journal.GetEntry(_commandCursor);
			float timestamp = entry.Timestamp;
			_frameCommands.Add(entry);
			_commandCursor++;
			while (_commandCursor < _journal.EntryCount)
			{
				IAppCommand entry2 = _journal.GetEntry(_commandCursor);
				if (entry2.Timestamp > timestamp)
				{
					break;
				}
				_frameCommands.Add(entry2);
				_commandCursor++;
			}
		}
		return _frameCommands;
	}

	public void SetRewiredMode(int mode)
	{
	}
}
