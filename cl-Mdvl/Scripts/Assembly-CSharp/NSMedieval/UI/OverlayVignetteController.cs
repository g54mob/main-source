using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.UI
{
	public class OverlayVignetteController : UIView
	{
		[SerializeField]
		private GameObject vingettePanel;

		private void OnEnable()
		{
			MonoSingleton<GameSpeedManager>.Instance.UpdateTimeScaleUIEvent += OnChangeTimeScale;
		}

		private void OnDisable()
		{
			if (MonoSingleton<GameSpeedManager>.IsInstantiated())
			{
				MonoSingleton<GameSpeedManager>.Instance.UpdateTimeScaleUIEvent -= OnChangeTimeScale;
			}
		}

		private void OnChangeTimeScale(float timescale, int timescaleindex)
		{
			vingettePanel.SetActive(timescale < float.Epsilon);
		}
	}
}
