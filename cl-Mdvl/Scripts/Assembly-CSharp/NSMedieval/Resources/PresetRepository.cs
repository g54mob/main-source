using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.Resources
{
	public abstract class PresetRepository<T, M> : JsonRepository<T, M> where T : Repository<T, M> where M : NSEipix.Base.Model
	{
		private SerializableList<M> userPresets;

		public IList<M> UserPresets
		{
			get
			{
				if (userPresets == null)
				{
					InitUserPresets();
				}
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Stockpile\\PresetRepository.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Get UserPresets for ");
					messageBuilder.AppendFormatted(typeof(T).Name);
					messageBuilder.AppendLiteral(", Count: ");
					messageBuilder.AppendFormatted(userPresets.Count);
				}
				Log.Trace(messageBuilder);
				return userPresets;
			}
		}

		public PresetRepository()
		{
		}

		public override void Deserialize()
		{
			base.Deserialize();
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(45, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Stockpile\\PresetRepository.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Deserializing preset repository for ");
				messageBuilder.AppendFormatted(typeof(T).Name);
				messageBuilder.AppendLiteral(", Count: ");
				messageBuilder.AppendFormatted(GetAllItems().Count());
			}
			Log.Debug(messageBuilder);
		}

		protected abstract string UserPresetsPath();

		public abstract void UpdateUserPreset(M model);

		protected virtual void InitUserPresets()
		{
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Stockpile\\PresetRepository.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Init UserPresets for ");
				messageBuilder.AppendFormatted(typeof(T).Name);
			}
			Log.Info(messageBuilder);
			userPresets = new SerializableList<M>();
			try
			{
				string json = FileUtils.SafeReadAllText(Path.Combine(FileReaders.Get.GetPersistentDataPath(), UserPresetsPath()));
				userPresets = JsonUtility.FromJson<SerializableList<M>>(json) ?? new SerializableList<M>();
			}
			catch (Exception)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Stockpile\\PresetRepository.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot load ");
					messageBuilder.AppendFormatted(typeof(M));
					messageBuilder.AppendLiteral(" presets in ");
					messageBuilder.AppendFormatted(GetType());
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
			}
			if (userPresets == null || userPresets.Count == 0)
			{
				userPresets?.AddRange(GetAllItems());
				SaveUserPresets();
			}
		}

		public void SaveUserPresets()
		{
			try
			{
				string text = Path.Combine(FileReaders.Get.GetPersistentDataPath(), UserPresetsPath());
				FilePathUtils.CheckAndCreatePath(text);
				string data = JsonUtility.ToJson(userPresets);
				FileUtils.SafeWriteAllText(text, data);
			}
			catch (Exception)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("save_group_presets_failed"));
			}
		}

		public void AddUserPreset(M model)
		{
			userPresets.Add(model);
			SaveUserPresets();
		}

		public void DeleteUserPreset(M model)
		{
			if (userPresets.Count > 1)
			{
				if (userPresets.Contains(model))
				{
					userPresets.Remove(model);
				}
				SaveUserPresets();
			}
		}
	}
}
