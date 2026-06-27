using System;
using System.Collections.Generic;
using DG.Tweening;
using Mandragora.PWS;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Localization;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface.DeviceCustomizations
{
	public class GUI_DeviceCustomizationPanel : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private float fadeDuration = 0.5f;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private GUI_DeviceCustomizationTasksModal modal;

		private TweenSequencesService tweenSequences;

		private LocalizationSystem localizationSystem;

		private Sequence transitionSequence;

		private PaintableDevice paintableDevice;

		private DeviceContainer deviceContainer;

		private readonly List<DeviceWorkType> expectedWorkTypes = new List<DeviceWorkType>();

		public bool InAnimation => modal.InAnimation;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences, LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
			this.tweenSequences = tweenSequences;
		}

		public void Initialize()
		{
			canvasGroup.alpha = 0f;
			base.gameObject.SetActive(value: false);
		}

		public void Dispose()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				transitionSequence = null;
			}
		}

		public void Init(DeviceContainer deviceContainer)
		{
			this.deviceContainer = deviceContainer;
			paintableDevice = deviceContainer.Device.GetComponent<PaintableDevice>();
			CollectExpectedWorks(deviceContainer);
			string nameLocalizationKey = deviceContainer.Device.Info.NameLocalizationKey;
			modal.Init(localizationSystem.GetTranslation(nameLocalizationKey), paintableDevice, expectedWorkTypes);
		}

		private void CollectExpectedWorks(DeviceContainer forDeviceContainer)
		{
			expectedWorkTypes.Clear();
			if (forDeviceContainer.AdditionalProperties.TryToGetProperty<PartOfEmailOrderInteractiveObjectProperty>(out var foundProperty))
			{
				SetCustomizationWorkTypes(foundProperty.WorkTypes);
			}
			if (forDeviceContainer.AdditionalProperties.TryToGetProperty<PartOfWorkOrderInteractiveObjectProperty>(out var foundProperty2))
			{
				SetCustomizationWorkTypes(foundProperty2.WorkTypes);
			}
		}

		public void UpdatePaintingProgress(PaintingProgressInPercentage paintingProgress)
		{
			modal.UpdatePaintingProgress(paintingProgress);
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(canvasGroup.DOFade(1f, fadeDuration)).SetEase(Ease.InQuad);
		}

		public void Hide()
		{
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(canvasGroup.DOFade(0f, fadeDuration)).SetEase(Ease.OutQuad).OnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
			});
		}

		private void SetCustomizationWorkTypes(IReadOnlyCollection<DeviceWorkType> workTypes)
		{
			foreach (DeviceWorkType workType in workTypes)
			{
				if (IsCustomizationWorkType(workType))
				{
					expectedWorkTypes.Add(workType);
				}
			}
		}

		private bool IsCustomizationWorkType(DeviceWorkType workType)
		{
			return workType is DeviceWorkTypeCustomizationBase;
		}
	}
}
