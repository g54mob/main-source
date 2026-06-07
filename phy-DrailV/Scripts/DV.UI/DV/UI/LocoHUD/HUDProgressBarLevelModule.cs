using System;
using DV.Utils;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDProgressBarLevelModule : HUDVisualLevelModule, HUDUpdateManager.IUpdateSlave
	{
		public RectTransform progressBar;

		public float progressBarMinValue;

		private float progressBarMaxValue;

		private float progressBarDesiredValue;

		[NonSerialized]
		public bool useCallbackForScrollSound;

		[NonSerialized]
		public Func<int, bool> scrollSoundCallbackOverride;

		public override Func<int, bool> ShouldScrollCallback
		{
			get
			{
				if (!useCallbackForScrollSound)
				{
					return base.ShouldScrollCallback;
				}
				return scrollSoundCallbackOverride;
			}
		}

		private void Awake()
		{
			progressBarMaxValue = progressBar.offsetMax.y;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<HUDUpdateManager>.Instance.RemoveSlave(this);
			}
		}

		public void DoUpdate()
		{
			progressBar.offsetMax = new Vector2(progressBar.offsetMax.x, Mathf.Lerp(progressBar.offsetMax.y, progressBarDesiredValue, 10f * Time.unscaledDeltaTime));
			if (progressBar.offsetMax.y.IsInRange(progressBarDesiredValue - 0.01f, progressBarDesiredValue + 0.01f))
			{
				SingletonBehaviour<HUDUpdateManager>.Instance.RemoveSlave(this);
			}
		}

		public override void SetVisualLevel(float level)
		{
			progressBarDesiredValue = Mathf.Lerp(progressBarMinValue, progressBarMaxValue, level);
			SingletonBehaviour<HUDUpdateManager>.Instance.AddSlave(this);
		}

		public override float GetVisualLevel()
		{
			return Mathf.InverseLerp(progressBarMinValue, progressBarMaxValue, progressBarDesiredValue);
		}
	}
}
