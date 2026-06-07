using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class History : ActiveComponent
{
	private class Record
	{
		public string state;

		public int index;

		public DateTime time;

		public int numBlocks;
	}

	private enum ReadState
	{
		OK = 0,
		EOF = 1,
		Corrupt = 2
	}

	private string questName = string.Empty;

	private int questHash;

	private int curRecord = -1;

	private int lastValid = -1;

	private List<Record> records = new List<Record>();

	private string historyFile = string.Empty;

	public void Clear(string newQuest = "")
	{
		curRecord = -1;
		questName = newQuest;
		questHash = ((newQuest.Length > 0) ? newQuest.GetHashCode() : 0);
		records.Clear();
		DeleteFile(historyFile);
	}

	public int AddRecord()
	{
		Record newRecord = GetNewRecord();
		newRecord.index = curRecord + 1;
		if (++curRecord < GetNumRecords())
		{
			records[curRecord] = newRecord;
			lastValid = curRecord;
		}
		else
		{
			records.Add(newRecord);
		}
		lastValid = curRecord;
		return newRecord.index;
	}

	public int GetNumRecords()
	{
		return records.Count;
	}

	public bool isUndoAvialble()
	{
		return curRecord > 0;
	}

	public bool isRedoAviable()
	{
		return curRecord < lastValid;
	}

	public void RewriteLastRecord()
	{
		records[records.Count - 1] = GetNewRecord();
	}

	public bool Undo()
	{
		if (curRecord > 0)
		{
			Record r = records[--curRecord];
			Restore(r, writeReplay: true, changeZoomAndPos: false);
			return true;
		}
		return false;
	}

	public bool Redo(bool writeReplay = true)
	{
		if (curRecord < lastValid)
		{
			Record r = records[++curRecord];
			Restore(r, writeReplay, changeZoomAndPos: false);
			return true;
		}
		return false;
	}

	public bool FastForward(int record)
	{
		if (record < records.Count && record >= 0)
		{
			curRecord = record;
			Record r = records[record];
			Restore(r);
			return true;
		}
		return false;
	}

	private void Restore(Record r, bool writeReplay = true, bool changeZoomAndPos = true)
	{
		ActiveComponent.Model.Scheme = Deserialize(r.state);
		ActiveComponent.Model.construction.LoadFromScheme(ActiveComponent.Model.Scheme, changeZoomAndPos);
		Debug.Log(r.index + ". record restored: " + r.numBlocks + " node(s); at " + r.time);
	}

	private Record GetRecordFromScheme(SchemeBlock schemeBlock)
	{
		SchemeBlock schemeBlock2 = new SchemeBlock();
		ActiveComponent.Model.construction.InitSocketsNums();
		schemeBlock2.Init(ActiveComponent.Model.construction);
		schemeBlock2.ClearToSave();
		return new Record
		{
			state = Serialize((schemeBlock != null) ? schemeBlock : schemeBlock2),
			index = -1,
			time = DateTime.Now,
			numBlocks = schemeBlock2.blocks.Count
		};
	}

	private Record GetNewRecord()
	{
		return GetRecordFromScheme(null);
	}

	private string Serialize(SchemeBlock obj)
	{
		return JsonConvert.SerializeObject(obj, Formatting.None, Logic.GetGlobalSettings());
	}

	private SchemeBlock Deserialize(string json)
	{
		return JsonConvert.DeserializeObject<SchemeBlock>(json, Logic.GetGlobalSettings());
	}

	public bool Load(string filename)
	{
		string filePath = GetFilePath(filename);
		if (!File.Exists(filePath))
		{
			return false;
		}
		using (BinaryReader binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open)))
		{
			int num = binaryReader.ReadInt32();
			int currentAppVersion = Logic.GetCurrentAppVersion();
			if (num != currentAppVersion)
			{
				Debug.LogError("WARNING: Replay from version: " + num + " trying to run on: " + currentAppVersion);
			}
			questHash = binaryReader.ReadInt32();
			records.Clear();
			while (true)
			{
				Record record = new Record();
				if (Read(record, binaryReader) != ReadState.OK)
				{
					break;
				}
				records.Add(record);
			}
		}
		curRecord = 0;
		lastValid = records.Count - 1;
		return true;
	}

	private bool DeleteFile(string filename)
	{
		string filePath = GetFilePath(filename);
		if (File.Exists(filePath))
		{
			File.Delete(filePath);
			return true;
		}
		return false;
	}

	private static string GetFilePath(string filename)
	{
		if (!Path.IsPathRooted(filename))
		{
			return Program.GetReplayPath() + filename;
		}
		return filename;
	}

	private string GetFilePath()
	{
		if (historyFile.Length == 0)
		{
			DateTime now = DateTime.Now;
			string text = $"{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}";
			historyFile = "Replay_" + text;
		}
		return GetFilePath(historyFile);
	}

	private ReadState Read(Record r, BinaryReader stream)
	{
		try
		{
			long num = stream.ReadInt64();
			if (num != 2305843009213693951L && num != 2305843009213693950L)
			{
				Debug.LogError("Broken or non-history record");
				return ReadState.Corrupt;
			}
			questHash = stream.ReadInt32();
			short year = stream.ReadInt16();
			byte month = stream.ReadByte();
			byte day = stream.ReadByte();
			byte hour = stream.ReadByte();
			byte minute = stream.ReadByte();
			byte second = stream.ReadByte();
			r.time = new DateTime(year, month, day, hour, minute, second, 0);
			r.index = stream.ReadInt32();
			r.numBlocks = stream.ReadInt32();
			int count = stream.ReadInt32();
			byte[] array = stream.ReadBytes(count);
			if (num == 2305843009213693951L)
			{
				array = LZF.Decompress(array);
			}
			r.state = Encoding.UTF8.GetString(array);
		}
		catch (EndOfStreamException)
		{
			return ReadState.EOF;
		}
		catch (Exception)
		{
			return ReadState.Corrupt;
		}
		return ReadState.OK;
	}

	private void Write(Record record, bool compressed = true, BinaryWriter bstream = null)
	{
		try
		{
			BinaryWriter binaryWriter = bstream;
			if (bstream == null)
			{
				string filePath = GetFilePath();
				if (!File.Exists(filePath))
				{
					binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.CreateNew));
					WriteHeader(binaryWriter);
				}
				else
				{
					binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.Append));
				}
			}
			binaryWriter.Write(compressed ? 2305843009213693951L : 2305843009213693950L);
			binaryWriter.Write(questHash);
			binaryWriter.Write((short)record.time.Year);
			binaryWriter.Write((byte)record.time.Month);
			binaryWriter.Write((byte)record.time.Day);
			binaryWriter.Write((byte)record.time.Hour);
			binaryWriter.Write((byte)record.time.Minute);
			binaryWriter.Write((byte)record.time.Second);
			binaryWriter.Write(record.index);
			binaryWriter.Write(record.numBlocks);
			byte[] array = Encoding.UTF8.GetBytes(record.state.ToCharArray());
			if (compressed)
			{
				array = LZF.Compress(array);
			}
			binaryWriter.Write(array.Length);
			binaryWriter.Write(array, 0, array.Length);
			if (bstream == null)
			{
				binaryWriter.Close();
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Record write failed: " + ex.ToString());
		}
	}

	private void Write(bool compressed = true)
	{
		string filePath = GetFilePath();
		try
		{
			using BinaryWriter bstream = new BinaryWriter(File.Open(filePath, FileMode.CreateNew));
			WriteHeader(bstream);
			for (int i = 0; i < curRecord; i++)
			{
				Write(records[i], compressed, bstream);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Record file write failed: " + ex.ToString());
		}
	}

	private void WriteHeader(BinaryWriter bstream)
	{
		bstream.Write(Logic.GetCurrentAppVersion());
		bstream.Write(questHash);
	}

	public static int GetQuestFromReplay(string filename)
	{
		string filePath = GetFilePath(filename);
		try
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open));
			binaryReader.ReadInt32();
			int result = binaryReader.ReadInt32();
			long num = binaryReader.ReadInt64();
			if (num == 2305843009213693951L || num == 2305843009213693950L)
			{
				return result;
			}
		}
		catch (Exception)
		{
			return 0;
		}
		return 0;
	}

	public static bool IsReplayFile(string filename)
	{
		if (filename.Length <= 0)
		{
			return false;
		}
		return GetQuestFromReplay(filename) != 0;
	}
}
