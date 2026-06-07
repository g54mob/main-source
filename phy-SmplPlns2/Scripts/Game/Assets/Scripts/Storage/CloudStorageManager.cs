using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Jundroo.SocialPlatforms;
using Jundroo.SocialPlatforms.Steam.Events;
using Jundroo.SocialPlatforms.Steam.RemoteStorage;

namespace Assets.Scripts.Storage
{
	public static class CloudStorageManager
	{
		public static void Delete(string path)
		{
			PerformFileBatchAction(delegate
			{
				File.Delete(path);
			});
		}

		public static void Initialize()
		{
			if (SocialExt.IsSteam)
			{
				SocialExt.Steam.RemoteStorageLocalFileChange += OnLocalFilesChanged;
			}
		}

		public static void PerformFileBatchAction(Action action)
		{
			try
			{
				if (SocialExt.IsSteam)
				{
					SocialExt.Steam.BeginFileWriteBatch();
				}
				action();
			}
			finally
			{
				if (SocialExt.IsSteam)
				{
					SocialExt.Steam.EndFileWriteBatch();
				}
			}
		}

		public static void Save(string path, string fileContent)
		{
			PerformFileBatchAction(delegate
			{
				File.WriteAllText(path, fileContent);
			});
		}

		public static void Save(string path, XDocument xml)
		{
			PerformFileBatchAction(delegate
			{
				xml.Save(path);
			});
		}

		public static void Save(string path, XElement xml)
		{
			PerformFileBatchAction(delegate
			{
				xml.Save(path);
			});
		}

		private static void OnLocalFilesChanged(object sender, RemoteStorageLocalFileChangeEventArgs e)
		{
			bool num = e.Changes.Any((RemoteStorageLocalFileChange x) => x.Path?.EndsWith("CloudSettings.xml", StringComparison.OrdinalIgnoreCase) ?? false);
			bool flag = e.Changes.Any((RemoteStorageLocalFileChange x) => (x.Path?.IndexOf("/" + new DirectoryInfo(Game.Instance.CraftDatabase.CraftFilesRootPath).Name + "/", StringComparison.OrdinalIgnoreCase) ?? (-1)) >= 0);
			bool flag2 = e.Changes.Any((RemoteStorageLocalFileChange x) => (x.Path?.IndexOf("/SubAssemblies/", StringComparison.OrdinalIgnoreCase) ?? (-1)) >= 0);
			if (num)
			{
				Game.Instance.Settings.Cloud.Reload();
			}
			if (flag)
			{
				Game.Instance.CraftDatabase.RescanCraftFilesForChangesAsync().Forget();
			}
			if (Game.Instance.SceneManager.InDesignerScene)
			{
				Designer.Instance.CreateUndoStep("Local Version (Before Cloud Sync)");
				Game.Instance.SceneManager.LoadDesigner(delegate
				{
					Designer.Instance.CreateUndoStep("Cloud Version (After Sync)");
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "New save files have been downloaded from the cloud. The designer has been reloaded using these new files. Your previous craft has been pushed on the 'Undo' stack.";
				});
			}
			else
			{
				Game.Instance.SceneManager.LoadLevelMenuWithMessage("New save files have been downloaded from the cloud.");
			}
		}
	}
}
