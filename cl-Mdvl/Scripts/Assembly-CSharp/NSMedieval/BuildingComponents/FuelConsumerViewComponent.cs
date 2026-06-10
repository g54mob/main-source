using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Construction;
using NSMedieval.Sound;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(FuelConsumerComponent))]
	public class FuelConsumerViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private FuelConsumerComponent fuelConsumerComponent;

		private GameObject pointLight;

		private MeshRenderer[] flameMeshRenderers;

		private string audioEventId;

		private AudioEventsComponent audioEventsComponent;

		private FuelConsumerFireComponent fuelConsumerFireComponent;

		private FuelConsumerComponentInstance FuelConsumerComponentInstance => fuelConsumerComponent.ComponentInstance;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			fuelConsumerComponent = GetComponent<FuelConsumerComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			TryInstantiateFuelConsumerPrefab();
			if (!string.IsNullOrEmpty(FuelConsumerComponentInstance.Blueprint.LightCookieId))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(14, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\FuelConsumers\\FuelConsumerViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(pointLight != null);
					messageBuilder.AppendLiteral(" has component");
				}
				Log.Debug(messageBuilder);
				if (pointLight != null)
				{
					pointLight.GetComponent<SetPointLightCookie>().Setup(FuelConsumerComponentInstance.Blueprint.LightCookieId);
				}
			}
			if (FuelConsumerComponentInstance.TorchState == TorchState.Burning)
			{
				SetFlameActive(active: true);
				pointLight.gameObject.SetActive(value: true);
			}
			FuelConsumerComponentInstance.AllFuelConsumedEvent += OnAllFuelConsumed;
			FuelConsumerComponentInstance.TurnedOnEvent += OnTurnedOn;
			FuelConsumerComponentInstance.TurnedOffEvent += OnTurnedOff;
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			SetFlameActive(active: false);
			pointLight.gameObject.SetActive(value: false);
			MonoBehaviourPool<FuelConsumerFireComponent>.Return(fuelConsumerFireComponent);
			fuelConsumerFireComponent = null;
			base.OnBuildingDisposed(disposable);
		}

		private void TryInstantiateFuelConsumerPrefab()
		{
			if (string.IsNullOrEmpty(FuelConsumerComponentInstance.Blueprint.PrefabId))
			{
				return;
			}
			fuelConsumerFireComponent = MonoBehaviourPool<FuelConsumerFireComponent>.Get(FuelConsumerComponentInstance.Blueprint.PrefabId);
			GameObject gameObject = fuelConsumerFireComponent.gameObject;
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			FuelConsumerComponentInstance.Blueprint.PrefabTransformSettings.ApplyToTransform(gameObject.transform);
			pointLight = fuelConsumerFireComponent.PointLight.gameObject;
			flameMeshRenderers = fuelConsumerFireComponent.FlameMeshRenderers;
			audioEventId = fuelConsumerFireComponent.AudioEventId;
			audioEventsComponent = fuelConsumerFireComponent.GetComponent<AudioEventsComponent>();
			if (fuelConsumerFireComponent.MeshVariationHandler == null || GetComponent<BaseBuildingViewComponent>().BaseBuildingInstance == null || base.BaseBuildingInstance.VariationsApplied == null || base.BaseBuildingInstance.VariationsApplied.Count == 0)
			{
				return;
			}
			foreach (string item in base.BaseBuildingInstance.VariationsApplied)
			{
				MeshVariation meshVariation = base.BaseBuildingInstance.Blueprint.GetMeshVariation(item);
				fuelConsumerFireComponent.MeshVariationHandler.UpdateMeshVariation(meshVariation, base.BaseBuildingInstance.MaterialVariationsApplied);
			}
		}

		private void OnTurnedOn()
		{
			if (FuelConsumerComponentInstance.CanBurn())
			{
				SetFlameActive(active: true);
				pointLight.gameObject.SetActive(value: true);
			}
			else
			{
				SetFlameActive(active: false);
				pointLight.gameObject.SetActive(value: false);
			}
		}

		private void OnTurnedOff()
		{
			SetFlameActive(active: false);
			pointLight.gameObject.SetActive(value: false);
		}

		private void OnAllFuelConsumed()
		{
			SetFlameActive(active: false);
			if ((bool)pointLight.gameObject)
			{
				pointLight.gameObject.SetActive(value: false);
			}
		}

		private void SetFlameActive(bool active)
		{
			if (audioEventsComponent != null && !string.IsNullOrEmpty(audioEventId))
			{
				bool isEnabled;
				if (active)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\FuelConsumers\\FuelConsumerViewComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Playing audio event ");
						messageBuilder.AppendFormatted(audioEventId);
					}
					Log.Trace(messageBuilder);
					audioEventsComponent.PlayEventInstance(audioEventId);
				}
				else
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\FuelConsumers\\FuelConsumerViewComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Stopping audio event ");
						messageBuilder.AppendFormatted(audioEventId);
					}
					Log.Trace(messageBuilder);
					audioEventsComponent.StopEventInstance(audioEventId);
				}
			}
			if (flameMeshRenderers != null)
			{
				MeshRenderer[] array = flameMeshRenderers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].gameObject.SetActive(active);
				}
			}
		}

		protected override void OnShowObject()
		{
			base.OnShowObject();
			if (audioEventsComponent != null && !string.IsNullOrEmpty(audioEventId))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\FuelConsumers\\FuelConsumerViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(audioEventId);
					messageBuilder.AppendLiteral(" Unpause");
				}
				Log.Trace(messageBuilder);
				audioEventsComponent.SetEventParameter(audioEventId, "PausedFader", 0f);
			}
		}

		protected override void OnHideObject()
		{
			base.OnHideObject();
			if (audioEventsComponent != null && !string.IsNullOrEmpty(audioEventId))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(6, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\FuelConsumers\\FuelConsumerViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(audioEventId);
					messageBuilder.AppendLiteral(" Pause");
				}
				Log.Trace(messageBuilder);
				audioEventsComponent.SetEventParameter(audioEventId, "PausedFader", 1f);
			}
		}
	}
}
