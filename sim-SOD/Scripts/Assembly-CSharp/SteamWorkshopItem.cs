using Steamworks;

internal struct SteamWorkshopItem
{
	public string ContentFolderPath;

	public string Description;

	public string PreviewImagePath;

	public string[] Tags;

	public string Title;

	public string Name;

	public string OwnerName;

	public string PreviewImageURL;

	public SteamWorkshopItem ParseItem(UGCQueryHandle_t p_handle, uint p_indexInHandle, SteamUGCDetails_t p_itemDetails)
	{
		return default(SteamWorkshopItem);
	}
}
