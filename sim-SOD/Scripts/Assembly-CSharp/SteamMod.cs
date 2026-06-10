using System;
using Steamworks;

[Serializable]
public class SteamMod
{
	public string installPath;

	public PublishedFileId_t PublishedFileIdT;

	public bool isEnabled;

	public int orderToLoad;

	public SteamMod(string path, PublishedFileId_t fileId)
	{
	}
}
