using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Light;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.TableLamps;
using Restory.Gameplay.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay
{
	public class LightTimeService : MonoBehaviour, IInitializable, IDisposable, Restory.Gameplay.TimeSystems.ITickable
	{
		[SerializeField]
		private LightTimePresets tableLampOnAmbientPresets;

		[SerializeField]
		private LightTimePresets tableLampOffAmbientPresets;

		[SerializeField]
		[Min(0f)]
		private float windowShuttersOpenAmbientIntensityAdditional;

		[SerializeField]
		private LightTimePresets tableLampPresets;

		[SerializeField]
		private LightTimePresets deviceSpotPresets;

		private GameCalendar gameCalendar;

		private TickSystem tickSystem;

		private TableLamp tableLamp;

		private WindowShuttersStoreInteractiveItem windowShuttersStore;

		private LightTimeView[] ambientLightTimeView;

		private LightTimeView deviceSpotLightTimeView;

		private LightTimeView[] tableLampLightTimeView;

		public IReadOnlyList<LightTimeView> AmbientLightTimeView => ambientLightTimeView;

		public LightTimeView DeviceSpotLightTimeView => deviceSpotLightTimeView;

		public IReadOnlyList<LightTimeView> TableLampLightTimeView => tableLampLightTimeView;

		[Inject]
		public void Construct(GameCalendar gameCalendar, TickSystem tickSystem, [Inject(Id = "AmbientLightTimeView")] LightTimeView[] ambientLightTimeView, [Inject(Id = "DeviceSpotLightTimeView")] LightTimeView deviceSpotLightTimeView, [Inject(Id = "TableLampLightTimeView")] LightTimeView[] tableLampLightTimeView, TableLamp tableLamp, WindowShuttersStoreInteractiveItem windowShuttersStore)
		{
			this.gameCalendar = gameCalendar;
			this.tickSystem = tickSystem;
			this.tableLamp = tableLamp;
			this.windowShuttersStore = windowShuttersStore;
			this.ambientLightTimeView = ambientLightTimeView.ToArray();
			this.deviceSpotLightTimeView = deviceSpotLightTimeView;
			this.tableLampLightTimeView = tableLampLightTimeView.ToArray();
		}

		public void Initialize()
		{
			tickSystem.AddSubscriber(this);
			Tick(0f);
		}

		public void Dispose()
		{
			if ((bool)tickSystem)
			{
				tickSystem.RemoveSubscriber(this);
			}
		}

		public void Tick(float deltaTime)
		{
			TimeSpan timeOfDay = gameCalendar.CurrentDateTime.TimeOfDay;
			UpdateAmbientLightTimeView(timeOfDay);
			UpdateTableLampLightTimeView(timeOfDay);
			UpdateDeviceSpotLightTimeView(timeOfDay);
		}

		private void UpdateAmbientLightTimeView(TimeSpan currentTime)
		{
			(tableLamp.IsOn ? tableLampOnAmbientPresets : tableLampOffAmbientPresets).Get(currentTime, out var intensity, out var temperatureK, out var color);
			intensity += windowShuttersStore.WindowOpenProgress * windowShuttersOpenAmbientIntensityAdditional;
			LightTimeView[] array = ambientLightTimeView;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Apply(intensity, temperatureK, color);
			}
		}

		private void UpdateTableLampLightTimeView(TimeSpan currentTime)
		{
			tableLampPresets.Get(currentTime, out var intensity, out var temperatureK, out var color);
			LightTimeView[] array = tableLampLightTimeView;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Apply(intensity, temperatureK, color);
			}
		}

		private void UpdateDeviceSpotLightTimeView(TimeSpan currentTime)
		{
			deviceSpotPresets.Get(currentTime, out var intensity, out var temperatureK, out var color);
			deviceSpotLightTimeView.Apply(intensity, temperatureK, color);
		}
	}
}
