using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval;
using UnityEngine;

namespace FoxyVoxel
{
	public class LogUserData : MonoBehaviour
	{
		private void Start()
		{
			if (!MonoSingleton<GlobalSaveController>.Instance.UserDataInfo.HavePurchaseVersion)
			{
				Log.Info("User has no Purchase version recorded", "C:\\GIT\\dev\\Assets\\Scripts\\LogUserData.cs");
				return;
			}
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(18, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\LogUserData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Purchase version: ");
				messageBuilder.AppendFormatted(MonoSingleton<GlobalSaveController>.Instance.UserDataInfo.PurchaseVersion);
			}
			Log.Info(messageBuilder);
			messageBuilder = new FVLogInfoInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\LogUserData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Is Early Bird: ");
				messageBuilder.AppendFormatted(MonoSingleton<GlobalSaveController>.Instance.UserDataInfo.IsEarlyBird);
			}
			Log.Info(messageBuilder);
		}
	}
}
