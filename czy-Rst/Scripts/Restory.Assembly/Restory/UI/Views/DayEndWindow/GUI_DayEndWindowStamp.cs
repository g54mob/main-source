using System;
using Restory.UI.Presenters.DayEndWindow;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_DayEndWindowStamp : MonoBehaviour
	{
		[SerializeField]
		private GameObject stampingFinalizeTriggerObject;

		[SerializeField]
		private GameObject stampingStartTriggerObject;

		[SerializeField]
		private GUI_StampingStartTrigger stampingStartTrigger;

		[SerializeField]
		private Button stampingFinalizeTrigger;

		[SerializeField]
		private GUI_DayEndStampResult stampResultPrefab;

		private DayEndSceneCursorView dayEndSceneCursorView;

		public event Action OnStampHighlighted;

		public event Action OnStampPickedUp;

		public event Action OnStampingDone;

		[Inject]
		private void Construct(DayEndSceneCursorView dayEndSceneCursorView)
		{
			this.dayEndSceneCursorView = dayEndSceneCursorView;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void Init()
		{
			stampingStartTrigger.OnHighlighted += ResolveStampHighlighted;
			stampingStartTrigger.OnTriggered += ResolveStampingModeStartTriggerClicked;
			stampingFinalizeTrigger.onClick.AddListener(ResolveStampingModeConcludeTriggerClicked);
			stampingFinalizeTriggerObject.SetActive(value: false);
			stampingStartTriggerObject.SetActive(value: true);
		}

		private void OnEnable()
		{
			if ((bool)dayEndSceneCursorView)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (stampingStartTrigger.MonoShellExists())
			{
				stampingStartTrigger.OnHighlighted -= ResolveStampHighlighted;
				stampingStartTrigger.OnTriggered -= ResolveStampingModeStartTriggerClicked;
			}
			if (stampingFinalizeTrigger.MonoShellExists())
			{
				stampingFinalizeTrigger.onClick.RemoveListener(ResolveStampingModeConcludeTriggerClicked);
			}
		}

		private void ResolveStampHighlighted()
		{
			this.OnStampHighlighted?.Invoke();
		}

		private void ResolveStampingModeStartTriggerClicked()
		{
			switch (dayEndSceneCursorView.CurrentMode)
			{
			case DayEndSceneCursorModes.Default:
				dayEndSceneCursorView.CurrentMode = DayEndSceneCursorModes.Stamping;
				stampingFinalizeTriggerObject.SetActive(value: true);
				stampingStartTriggerObject.SetActive(value: false);
				this.OnStampPickedUp?.Invoke();
				break;
			case DayEndSceneCursorModes.Stamping:
				dayEndSceneCursorView.CurrentMode = DayEndSceneCursorModes.Default;
				stampingFinalizeTriggerObject.SetActive(value: false);
				stampingStartTriggerObject.SetActive(value: true);
				break;
			default:
				throw new NotImplementedException();
			case DayEndSceneCursorModes.None:
			case DayEndSceneCursorModes.AfterStamping:
				break;
			}
		}

		private void ResolveStampingModeConcludeTriggerClicked()
		{
			stampingFinalizeTrigger.onClick.RemoveListener(ResolveStampingModeConcludeTriggerClicked);
			stampingFinalizeTriggerObject.SetActive(value: false);
			dayEndSceneCursorView.CurrentMode = DayEndSceneCursorModes.AfterStamping;
			if (dayEndSceneCursorView.TryToGetStampCursorParameters(out var stampCursorParameters))
			{
				GUI_DayEndStampResult component = UnityEngine.Object.Instantiate(stampResultPrefab.gameObject, base.transform).GetComponent<GUI_DayEndStampResult>();
				component.SetUp(stampCursorParameters.StampIcon, stampCursorParameters.StampZRotation);
				component.transform.position = stampCursorParameters.StampPosition;
			}
			this.OnStampingDone?.Invoke();
		}
	}
}
