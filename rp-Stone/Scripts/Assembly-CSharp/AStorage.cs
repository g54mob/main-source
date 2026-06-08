using System;
using System.Collections.Generic;

public abstract class AStorage
{
	public enum State
	{
		Uninitialized = 0,
		Initializing = 1,
		Success = 2,
		ConnectionError = 3,
		LoadingError = 4,
		StorageMerge = 5
	}

	protected State currentState = State.Success;

	public abstract bool IsBusySaving();

	public abstract void Save();

	public abstract void Load();

	public abstract void Clear();

	public abstract bool HasKey(string key);

	public abstract void DeleteKey(string key);

	public abstract string GetString(string key, string defaultValue = "");

	public abstract void SetString(string key, string value);

	public abstract int GetInt(string key, int defaultValue = 0);

	public abstract void SetInt(string key, int value);

	public abstract bool GetBool(string key, bool defaultValue = false);

	public abstract void SetBool(string key, bool value);

	public abstract string ExportAsString();

	public abstract void ImportFromString(string sjson);

	public abstract string GetStoragePath();

	public abstract List<string> ListDir(string relDir);

	public abstract string LoadTextFile(string relFilename);

	public abstract void SaveTextFile(string relFilename, string text);

	public abstract void Delete(string relFilename);

	public abstract bool Exists(string relFilename);

	public abstract DateTime GetModifiedTime(string relFilename);

	public abstract DateTime GetCreatedTime(string relFilename);

	public abstract void StreamingCopy(string relSrc, string relDst, Utils.IncludeFilePredicate includePredicate = null);

	public virtual State GetState()
	{
		return currentState;
	}

	protected static string ReplaceQuotes(string inValue)
	{
		return inValue.Replace('"', '“');
	}

	protected static string UnplaceQuotes(string inValue)
	{
		inValue = inValue.Replace('“', '"');
		return inValue.Replace('”', '"');
	}
}
