using System;
using UnityEngine;

[Serializable]
public class AppStoreBaseData
{
	public string Name;

	public string phraseSerch;

	public bool HideInStore;

	[AppNameDropdown]
	public string NameIdentifierInAppBase;

	public AppStoreBaseRate rateBase;

	public FileSystemObject ApplicationFiles;

	public string TitleDescription;

	public Sprite[] Screenshots;

	public Sprite ApplicationIcon;

	public string ContentDescription;

	public AppStoreApplicationAvailable ApplicationAvailability;

	public AppStoreApplicationPublisher PublisherName;

	public string ReleaseDate;

	public AppStoreApplicationCategory Category;

	public float SizeMB;
}
