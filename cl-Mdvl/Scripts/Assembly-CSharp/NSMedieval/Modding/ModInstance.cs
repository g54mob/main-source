using System.Collections.Generic;
using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.Tools.Textures;
using UnityEngine;

namespace NSMedieval.Modding
{
	public class ModInstance
	{
		public readonly string RootFolderPath;

		public string DataPath;

		public Dictionary<string, string> DataModels { get; } = new Dictionary<string, string>();

		public Dictionary<string, Texture2D> Textures { get; } = new Dictionary<string, Texture2D>();

		public Dictionary<string, Sprite> Sprites { get; } = new Dictionary<string, Sprite>();

		public ModModel ModModel { get; }

		public Sprite PreviewSprite { get; }

		public bool IsEnabled { get; private set; }

		public ModSource Source { get; private set; }

		public ModTag Tag { get; private set; }

		public ulong WorkshopPublishedFileId { get; private set; }

		public string SystemId => $"{ModModel.Id}_{Source}";

		public IList<string> TagsList => ModModel.Tags;

		public ModInstance(ModModel modModel, Sprite sprite, string rootFolderPath, ModSource source)
		{
			RootFolderPath = rootFolderPath;
			DataPath = Path.Combine(RootFolderPath, "Data");
			ModModel = modModel;
			PreviewSprite = sprite;
			Source = source;
			Tag = modModel.GetTags();
			Initialize();
		}

		public void SetWorkshopPublishedFileId(ulong publishedFileId)
		{
			WorkshopPublishedFileId = publishedFileId;
		}

		public void SetEnabled(bool enabled)
		{
			if (enabled)
			{
				OnEnable();
			}
			else if (IsEnabled)
			{
				OnDisable();
			}
			IsEnabled = enabled;
		}

		protected virtual void Initialize()
		{
			if (!Directory.Exists(DataPath))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Data directory ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(DataPath));
					messageBuilder.AppendLiteral(" not found for mod ");
					messageBuilder.AppendFormatted(ModModel.Name);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				LoadDataModels();
				LoadSprites();
			}
		}

		private void LoadAddressableAssets()
		{
			string path = Path.Combine(DataPath, "AddressableAssets");
			if (Directory.Exists(path))
			{
				MonoSingleton<AddressableModManager>.Instance.LoadAssetsFromPath(path);
			}
		}

		private void UnloadAddressableAssets()
		{
			string path = Path.Combine(DataPath, "AddressableAssets");
			if (Directory.Exists(path))
			{
				MonoSingleton<AddressableModManager>.Instance.UnloadAssetsFromPath(path);
			}
		}

		private void LoadSprites()
		{
			string path = Path.Combine(DataPath, "Sprites");
			if (!Directory.Exists(path))
			{
				return;
			}
			string[] files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);
			foreach (string text in files)
			{
				Sprite spriteFromPath = TextureUtils.GetSpriteFromPath(text);
				bool isEnabled;
				if ((object)spriteFromPath == null)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Failed to load sprite from ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(text));
					}
					Log.Error(messageBuilder);
					continue;
				}
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				if (Sprites.TryAdd(fileNameWithoutExtension, spriteFromPath))
				{
					FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModInstance.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Added sprite ");
						messageBuilder2.AppendFormatted(fileNameWithoutExtension);
						messageBuilder2.AppendLiteral(" for mod ");
						messageBuilder2.AppendFormatted(ModModel.Name);
					}
					Log.Debug(messageBuilder2);
				}
				else
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(31, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Sprite ");
						messageBuilder.AppendFormatted(fileNameWithoutExtension);
						messageBuilder.AppendLiteral(" already exists for mod ");
						messageBuilder.AppendFormatted(ModModel.Name);
					}
					Log.Error(messageBuilder);
				}
			}
		}

		private void LoadDataModels()
		{
			DataModels.Clear();
			string path = Path.Combine(DataPath, "Models");
			if (!Directory.Exists(path))
			{
				return;
			}
			string[] files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				if (DataModels.TryAdd(fileName, text))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Added model ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(fileName));
						messageBuilder.AppendLiteral(" for mod ");
						messageBuilder.AppendFormatted(ModModel.Name);
					}
					Log.Trace(messageBuilder);
				}
			}
		}

		protected virtual void OnEnable()
		{
			foreach (KeyValuePair<string, Sprite> sprite in Sprites)
			{
				MonoRepository<SpriteRepository, KeySpritePair>.Instance.AddNewObject(sprite.Key, sprite.Value, overwrite: true);
			}
			foreach (KeyValuePair<string, string> dataModel in DataModels)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(58, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Enabling ");
					messageBuilder.AppendFormatted(ModModel.Name);
					messageBuilder.AppendLiteral(" mod and adding repository from file: ");
					messageBuilder.AppendFormatted(dataModel.Key);
					messageBuilder.AppendLiteral(" at path: ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(dataModel.Value));
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
				MonoSingleton<RepositoryManager>.Instance.AddRepository(dataModel.Key, dataModel.Value);
			}
			MonoSingleton<RepositoryManager>.Instance.RefreshRepositories();
			LoadAddressableAssets();
		}

		protected virtual void OnDisable()
		{
			if (!IsEnabled)
			{
				return;
			}
			UnloadAddressableAssets();
			foreach (KeyValuePair<string, string> dataModel in DataModels)
			{
				MonoSingleton<RepositoryManager>.Instance.RemoveRepository(dataModel.Key, dataModel.Value);
			}
			MonoSingleton<RepositoryManager>.Instance.RefreshRepositories();
		}

		public virtual void Dispose()
		{
			OnDisable();
		}

		public virtual void UpdateData()
		{
		}
	}
}
