using System;

public struct SaveInfo
{
	public DateTime LastModified;

	public string Path;

	public string Directory;

	public string Name;

	public int SlotIndex;

	public string StoreName;

	public int StoreLevel;

	public bool HasSave;

	public bool IsCorrupt;

	public void UpdateTimestamp()
	{
	}
}
