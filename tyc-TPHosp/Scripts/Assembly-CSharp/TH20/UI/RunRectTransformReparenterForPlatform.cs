#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine;

namespace TH20.UI
{
	[DisallowMultipleComponent]
	public class RunRectTransformReparenterForPlatform : MonoBehaviour
	{
		[Serializable]
		private struct PlatformTransforms
		{
			public OSManager.Platform Platform;

			public RectTransformReparenter Reparenter;
		}

		[SerializeField]
		private PlatformTransforms[] _platformTransforms;

		private void OnEnable()
		{
			RunPositionerForPlatform(OSManager.GetPlatform());
		}

		private void RunPositionerForPlatform(OSManager.Platform platform)
		{
			int num = FindIndexOfPlatform(platform);
			if (num < 0)
			{
				Logging.Warning(LogChannels.GUI, "Failed to find entry for platform {0}", platform);
			}
			else
			{
				_platformTransforms[num].Reparenter.ReparentTransforms();
			}
		}

		private int FindIndexOfPlatform(OSManager.Platform platform)
		{
			for (int i = 0; i < _platformTransforms.Length; i++)
			{
				if (_platformTransforms[i].Platform == platform)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
