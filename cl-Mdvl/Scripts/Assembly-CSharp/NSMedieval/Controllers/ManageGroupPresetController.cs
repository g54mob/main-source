using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Resources;

namespace NSMedieval.Controllers
{
	public class ManageGroupPresetController : MonoSingleton<ManageGroupPresetController>
	{
		private readonly List<ManageGroupPreset> defaultPresets = new List<ManageGroupPreset>();

		public void Initialize()
		{
			defaultPresets.AddRange(Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.GetAllItems());
			InitUserPresets();
			foreach (ManageGroupPreset userPreset in Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets)
			{
				userPreset.InitManageGroupResources();
			}
			foreach (ManageGroupPreset allItem in Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.GetAllItems())
			{
				allItem.InitManageGroupResources();
			}
		}

		private void InitUserPresets()
		{
			List<ManageGroupPreset> list = new List<ManageGroupPreset>();
			list.AddRange(Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets);
			if (list.Count == 0)
			{
				LoadDefaults();
				return;
			}
			foreach (ManageGroupPreset preset in list)
			{
				if ((preset.DefaultAllowedResources == null || preset.DefaultAllowedResources.Count == 0) && (preset.DefaultForbiddenResources == null || preset.DefaultForbiddenResources.Count == 0))
				{
					LoadDefaults();
					break;
				}
				if (Repository<ManageGroupRepository, ManageGroup>.Instance.GetByID(preset.GroupId) == null)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(89, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\ManageGroupPresetController.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("User preset '");
						messageBuilder.AppendFormatted(preset.GetID());
						messageBuilder.AppendLiteral("' references non-existent manage group '");
						messageBuilder.AppendFormatted(preset.GroupId);
						messageBuilder.AppendLiteral("', resetting user presets to default");
					}
					Log.Info(messageBuilder);
					LoadDefaults();
					break;
				}
				ManageGroupPreset manageGroupPreset = defaultPresets.FirstOrDefault((ManageGroupPreset p) => p.GetID().Equals(preset.GetID()));
				if (!(manageGroupPreset == null))
				{
					Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UpdateUserPreset(manageGroupPreset);
				}
			}
		}

		private void LoadDefaults()
		{
			Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UpdateUserPresets(defaultPresets);
		}
	}
}
