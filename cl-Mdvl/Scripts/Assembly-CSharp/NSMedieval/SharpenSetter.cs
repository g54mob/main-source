using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval
{
	[RequireComponent(typeof(PrismSharpen))]
	public class SharpenSetter : MonoBehaviour
	{
		private PrismSharpen prismSharpen;

		private void Awake()
		{
			prismSharpen = GetComponent<PrismSharpen>();
		}

		private void Start()
		{
			if (prismSharpen == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(64, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Camera\\SharpenSetter.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SharpenSetter for ");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" not subscribing because prismSharpen is null.");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				MonoSingleton<OptionsController>.Instance.SharpnessChangedEvent += OnSharpnessSet;
				OnSharpnessSet();
			}
		}

		private void OnSharpnessSet()
		{
			if (prismSharpen == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(42, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Camera\\SharpenSetter.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnSharpnessSet for ");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(": prismSharpen is null.");
				}
				Log.Error(messageBuilder);
				if (MonoSingleton<OptionsController>.IsInstantiated())
				{
					MonoSingleton<OptionsController>.Instance.SharpnessChangedEvent -= OnSharpnessSet;
					messageBuilder = new FVLogErrorInterpolationHandler(77, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Camera\\SharpenSetter.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("OnSharpnessSet: SharpenSetter for ");
						messageBuilder.AppendFormatted(base.gameObject.name);
						messageBuilder.AppendLiteral(" unsubscribed because prismSharpen is null.");
					}
					Log.Error(messageBuilder);
				}
			}
			else
			{
				if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings == null)
				{
					throw new Exception("GlobalSettings is null for " + base.gameObject.name);
				}
				prismSharpen.sharpenAmount = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.Sharpness;
			}
		}

		private void OnDestroy()
		{
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.SharpnessChangedEvent -= OnSharpnessSet;
			}
			prismSharpen = null;
		}
	}
}
