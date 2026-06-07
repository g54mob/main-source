using System;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class PanickingBarAlert : MonoSingleton<PanickingBarAlert>
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private bool _tutorialMode;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Feedback Settings")]
		private string _panicIcon;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		private string _panicTitle;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		[TextArea]
		private string _panicText;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		private string _panicInfo1;

		private bool _isItTheFirstTime = true;

		public static event Action IncidentTriggering;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			SceneReset.Reset += Reset;
		}

		private void OnDisable()
		{
			SceneReset.Reset -= Reset;
		}

		private void Reset()
		{
			_isItTheFirstTime = true;
		}

		[Button("Trigger an alert", EButtonEnableMode.Playmode)]
		private void DebugTriggerAlert()
		{
			TriggerAlertIncident(base.transform);
		}

		public void TriggerAlertIncident(Transform _incidentTransform)
		{
			PanickingBarAlert.IncidentTriggering?.Invoke();
			if (CTSSingleton<LevelParameters>.Instance.IsOpen)
			{
				MonoSingleton<PushHandlers>.Instance.PushANotification(_panicIcon, PushColor.Danger, _incidentTransform, _panicTitle, _panicText, _panicInfo1, null);
				if (_tutorialMode && _isItTheFirstTime)
				{
					_isItTheFirstTime = true;
					MonoSingleton<TimeController>.Instance.TimeMode = ETimeModes.Pause;
				}
			}
		}
	}
}
