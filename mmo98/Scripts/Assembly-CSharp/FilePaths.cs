using System.IO;
using Cysharp.Text;
using UnityEngine;

public static class FilePaths
{
	private const string ProfileFolderFormat = "Profile {0}";

	private const string ProfileFolderDemoFormat = "Profile {0} Demo";

	private const string BoxArtFolder = "BoxArt";

	private const string MetaFileNameFormat = "mmo98_{0}_meta.gnome";

	private const string GameFileNameFormat = "mmo98_{0}_game.gnome";

	private const string BackgroundFileNameFormat = "mmo98_{0}_background.jpg";

	private const string BoxArtFileNameFormat = "boxart_{0}.jpg";

	private const string GlobalFileNameFormat = "global.gnome";

	public const string TEMP_EXTENSION = ".tmp";

	public const string BACKUP_EXTENSION = ".bak";

	public const string IMAGE_EXTENSION = ".jpg";

	public static readonly string ProfilesRootPath = Path.Combine(Application.persistentDataPath, "profiles");

	public static string ProfileFolderPath(int profile)
	{
		return Path.Combine(ProfilesRootPath, ZString.Format("Profile {0}", profile));
	}

	public static string BoxArtFolderPath(int profile)
	{
		return Path.Combine(ProfileFolderPath(profile), "BoxArt");
	}

	public static string GetMetaFilePath(int profile)
	{
		return Path.Combine(ProfileFolderPath(profile), ZString.Format("mmo98_{0}_meta.gnome", profile));
	}

	public static string GetStateFilePath(int profile)
	{
		return Path.Combine(ProfileFolderPath(profile), ZString.Format("mmo98_{0}_game.gnome", profile));
	}

	public static string GetGlobalFilePath()
	{
		return Path.Combine(ProfilesRootPath, "global.gnome");
	}

	public static string GetBackgroundFilePath(int profile)
	{
		return Path.Combine(ProfileFolderPath(profile), ZString.Format("mmo98_{0}_background.jpg", profile));
	}

	public static string GetBoxArtFilePath(int profile, int release)
	{
		return Path.Combine(BoxArtFolderPath(profile), ZString.Format("boxart_{0}.jpg", release));
	}
}
