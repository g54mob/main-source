using System;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class Device : ISentryJsonSerializable, ICloneable<Device>, IUpdatable<Device>, IUpdatable
	{
		public const string Type = "device";

		public TimeZoneInfo? Timezone { get; set; }

		public string? Name { get; set; }

		public string? Manufacturer { get; set; }

		public string? Brand { get; set; }

		public string? Family { get; set; }

		public string? Model { get; set; }

		public string? ModelId { get; set; }

		public string? Architecture { get; set; }

		public short? BatteryLevel { get; set; }

		public bool? IsCharging { get; set; }

		public bool? IsOnline { get; set; }

		public DeviceOrientation? Orientation { get; set; }

		public bool? Simulator { get; set; }

		public long? MemorySize { get; set; }

		public long? FreeMemory { get; set; }

		public long? UsableMemory { get; set; }

		public bool? LowMemory { get; set; }

		public long? StorageSize { get; set; }

		public long? FreeStorage { get; set; }

		public long? ExternalStorageSize { get; set; }

		public long? ExternalFreeStorage { get; set; }

		public string? ScreenResolution { get; set; }

		public float? ScreenDensity { get; set; }

		public int? ScreenDpi { get; set; }

		public DateTimeOffset? BootTime { get; set; }

		public int? ProcessorCount { get; set; }

		public string? CpuDescription { get; set; }

		public int? ProcessorFrequency { get; set; }

		public string? DeviceType { get; set; }

		public string? BatteryStatus { get; set; }

		public string? DeviceUniqueIdentifier { get; set; }

		public bool? SupportsVibration { get; set; }

		public bool? SupportsAccelerometer { get; set; }

		public bool? SupportsGyroscope { get; set; }

		public bool? SupportsAudio { get; set; }

		public bool? SupportsLocationService { get; set; }

		internal Device Clone()
		{
			return ((ICloneable<Device>)this).Clone();
		}

		Device ICloneable<Device>.Clone()
		{
			return new Device
			{
				Name = Name,
				Manufacturer = Manufacturer,
				Brand = Brand,
				Architecture = Architecture,
				BatteryLevel = BatteryLevel,
				IsCharging = IsCharging,
				IsOnline = IsOnline,
				BootTime = BootTime,
				ExternalFreeStorage = ExternalFreeStorage,
				ExternalStorageSize = ExternalStorageSize,
				ScreenResolution = ScreenResolution,
				ScreenDensity = ScreenDensity,
				ScreenDpi = ScreenDpi,
				Family = Family,
				FreeMemory = FreeMemory,
				FreeStorage = FreeStorage,
				MemorySize = MemorySize,
				Model = Model,
				ModelId = ModelId,
				Orientation = Orientation,
				Simulator = Simulator,
				StorageSize = StorageSize,
				Timezone = Timezone,
				UsableMemory = UsableMemory,
				LowMemory = LowMemory,
				ProcessorCount = ProcessorCount,
				CpuDescription = CpuDescription,
				ProcessorFrequency = ProcessorFrequency,
				SupportsVibration = SupportsVibration,
				DeviceType = DeviceType,
				BatteryStatus = BatteryStatus,
				DeviceUniqueIdentifier = DeviceUniqueIdentifier,
				SupportsAccelerometer = SupportsAccelerometer,
				SupportsGyroscope = SupportsGyroscope,
				SupportsAudio = SupportsAudio,
				SupportsLocationService = SupportsLocationService
			};
		}

		internal void UpdateFrom(Device source)
		{
			((IUpdatable<Device>)this).UpdateFrom(source);
		}

		void IUpdatable.UpdateFrom(object source)
		{
			if (source is Device source2)
			{
				((IUpdatable<Device>)this).UpdateFrom(source2);
			}
		}

		void IUpdatable<Device>.UpdateFrom(Device source)
		{
			if (Name == null)
			{
				string text = (Name = source.Name);
			}
			if (Manufacturer == null)
			{
				string text = (Manufacturer = source.Manufacturer);
			}
			if (Brand == null)
			{
				string text = (Brand = source.Brand);
			}
			if (Architecture == null)
			{
				string text = (Architecture = source.Architecture);
			}
			if (!BatteryLevel.HasValue)
			{
				short? num = (BatteryLevel = source.BatteryLevel);
			}
			if (!IsCharging.HasValue)
			{
				bool? flag = (IsCharging = source.IsCharging);
			}
			if (!IsOnline.HasValue)
			{
				bool? flag = (IsOnline = source.IsOnline);
			}
			if (!BootTime.HasValue)
			{
				DateTimeOffset? dateTimeOffset = (BootTime = source.BootTime);
			}
			if (!ExternalFreeStorage.HasValue)
			{
				long? num2 = (ExternalFreeStorage = source.ExternalFreeStorage);
			}
			if (!ExternalStorageSize.HasValue)
			{
				long? num2 = (ExternalStorageSize = source.ExternalStorageSize);
			}
			if (ScreenResolution == null)
			{
				string text = (ScreenResolution = source.ScreenResolution);
			}
			if (!ScreenDensity.HasValue)
			{
				float? num3 = (ScreenDensity = source.ScreenDensity);
			}
			if (!ScreenDpi.HasValue)
			{
				int? num4 = (ScreenDpi = source.ScreenDpi);
			}
			if (Family == null)
			{
				string text = (Family = source.Family);
			}
			if (!FreeMemory.HasValue)
			{
				long? num2 = (FreeMemory = source.FreeMemory);
			}
			if (!FreeStorage.HasValue)
			{
				long? num2 = (FreeStorage = source.FreeStorage);
			}
			if (!MemorySize.HasValue)
			{
				long? num2 = (MemorySize = source.MemorySize);
			}
			if (Model == null)
			{
				string text = (Model = source.Model);
			}
			if (ModelId == null)
			{
				string text = (ModelId = source.ModelId);
			}
			if (!Orientation.HasValue)
			{
				DeviceOrientation? deviceOrientation = (Orientation = source.Orientation);
			}
			if (!Simulator.HasValue)
			{
				bool? flag = (Simulator = source.Simulator);
			}
			if (!StorageSize.HasValue)
			{
				long? num2 = (StorageSize = source.StorageSize);
			}
			if (Timezone == null)
			{
				TimeZoneInfo timeZoneInfo = (Timezone = source.Timezone);
			}
			if (!UsableMemory.HasValue)
			{
				long? num2 = (UsableMemory = source.UsableMemory);
			}
			if (!LowMemory.HasValue)
			{
				bool? flag = (LowMemory = source.LowMemory);
			}
			if (!ProcessorCount.HasValue)
			{
				int? num4 = (ProcessorCount = source.ProcessorCount);
			}
			if (CpuDescription == null)
			{
				string text = (CpuDescription = source.CpuDescription);
			}
			if (!ProcessorFrequency.HasValue)
			{
				int? num4 = (ProcessorFrequency = source.ProcessorFrequency);
			}
			if (!SupportsVibration.HasValue)
			{
				bool? flag = (SupportsVibration = source.SupportsVibration);
			}
			if (DeviceType == null)
			{
				string text = (DeviceType = source.DeviceType);
			}
			if (BatteryStatus == null)
			{
				string text = (BatteryStatus = source.BatteryStatus);
			}
			if (DeviceUniqueIdentifier == null)
			{
				string text = (DeviceUniqueIdentifier = source.DeviceUniqueIdentifier);
			}
			if (!SupportsAccelerometer.HasValue)
			{
				bool? flag = (SupportsAccelerometer = source.SupportsAccelerometer);
			}
			if (!SupportsGyroscope.HasValue)
			{
				bool? flag = (SupportsGyroscope = source.SupportsGyroscope);
			}
			if (!SupportsAudio.HasValue)
			{
				bool? flag = (SupportsAudio = source.SupportsAudio);
			}
			if (!SupportsLocationService.HasValue)
			{
				bool? flag = (SupportsLocationService = source.SupportsLocationService);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? _)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "device");
			writer.WriteStringIfNotWhiteSpace("timezone", Timezone?.Id);
			if (!string.Equals(Timezone?.Id, Timezone?.DisplayName, StringComparison.OrdinalIgnoreCase))
			{
				writer.WriteStringIfNotWhiteSpace("timezone_display_name", Timezone?.DisplayName);
			}
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteStringIfNotWhiteSpace("manufacturer", Manufacturer);
			writer.WriteStringIfNotWhiteSpace("brand", Brand);
			writer.WriteStringIfNotWhiteSpace("family", Family);
			writer.WriteStringIfNotWhiteSpace("model", Model);
			writer.WriteStringIfNotWhiteSpace("model_id", ModelId);
			writer.WriteStringIfNotWhiteSpace("arch", Architecture);
			writer.WriteNumberIfNotNull("battery_level", BatteryLevel);
			writer.WriteBooleanIfNotNull("charging", IsCharging);
			writer.WriteBooleanIfNotNull("online", IsOnline);
			writer.WriteStringIfNotWhiteSpace("orientation", Orientation?.ToString().ToLowerInvariant());
			writer.WriteBooleanIfNotNull("simulator", Simulator);
			writer.WriteNumberIfNotNull("memory_size", MemorySize);
			writer.WriteNumberIfNotNull("free_memory", FreeMemory);
			writer.WriteNumberIfNotNull("usable_memory", UsableMemory);
			writer.WriteBooleanIfNotNull("low_memory", LowMemory);
			writer.WriteNumberIfNotNull("storage_size", StorageSize);
			writer.WriteNumberIfNotNull("free_storage", FreeStorage);
			writer.WriteNumberIfNotNull("external_storage_size", ExternalStorageSize);
			writer.WriteNumberIfNotNull("external_free_storage", ExternalFreeStorage);
			writer.WriteStringIfNotWhiteSpace("screen_resolution", ScreenResolution);
			writer.WriteNumberIfNotNull("screen_density", ScreenDensity);
			writer.WriteNumberIfNotNull("screen_dpi", ScreenDpi);
			writer.WriteStringIfNotNull("boot_time", BootTime);
			writer.WriteNumberIfNotNull("processor_count", ProcessorCount);
			writer.WriteStringIfNotWhiteSpace("cpu_description", CpuDescription);
			writer.WriteNumberIfNotNull("processor_frequency", ProcessorFrequency);
			writer.WriteStringIfNotWhiteSpace("device_type", DeviceType);
			writer.WriteStringIfNotWhiteSpace("battery_status", BatteryStatus);
			writer.WriteStringIfNotWhiteSpace("device_unique_identifier", DeviceUniqueIdentifier);
			writer.WriteBooleanIfNotNull("supports_vibration", SupportsVibration);
			writer.WriteBooleanIfNotNull("supports_accelerometer", SupportsAccelerometer);
			writer.WriteBooleanIfNotNull("supports_gyroscope", SupportsGyroscope);
			writer.WriteBooleanIfNotNull("supports_audio", SupportsAudio);
			writer.WriteBooleanIfNotNull("supports_location_service", SupportsLocationService);
			writer.WriteEndObject();
		}

		private static TimeZoneInfo? TryParseTimezone(JsonElement json)
		{
			string text = json.GetPropertyOrNull("timezone")?.GetString();
			string text2 = json.GetPropertyOrNull("timezone_display_name")?.GetString() ?? text;
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			try
			{
				return TimeZoneInfo.FindSystemTimeZoneById(text);
			}
			catch (TimeZoneNotFoundException)
			{
				return TimeZoneInfo.CreateCustomTimeZone(text, TimeSpan.Zero, text2, text2);
			}
		}

		public static Device FromJson(JsonElement json)
		{
			TimeZoneInfo timezone = TryParseTimezone(json);
			string name = json.GetPropertyOrNull("name")?.GetString();
			string manufacturer = json.GetPropertyOrNull("manufacturer")?.GetString();
			string brand = json.GetPropertyOrNull("brand")?.GetString();
			string family = json.GetPropertyOrNull("family")?.GetString();
			string model = json.GetPropertyOrNull("model")?.GetString();
			string modelId = json.GetPropertyOrNull("model_id")?.GetString();
			string architecture = json.GetPropertyOrNull("arch")?.GetString();
			double value = default(double);
			short? batteryLevel = ((json.GetPropertyOrNull("battery_level")?.TryGetDouble(out value) ?? false) ? new short?((short)value) : ((short?)null));
			bool? isCharging = json.GetPropertyOrNull("charging")?.GetBoolean();
			bool? isOnline = json.GetPropertyOrNull("online")?.GetBoolean();
			DeviceOrientation? orientation = json.GetPropertyOrNull("orientation")?.GetString()?.ParseEnum<DeviceOrientation>();
			bool? simulator = json.GetPropertyOrNull("simulator")?.GetBoolean();
			long? memorySize = json.GetPropertyOrNull("memory_size")?.GetInt64();
			long? freeMemory = json.GetPropertyOrNull("free_memory")?.GetInt64();
			long? usableMemory = json.GetPropertyOrNull("usable_memory")?.GetInt64();
			bool? lowMemory = json.GetPropertyOrNull("low_memory")?.GetBoolean();
			long? storageSize = json.GetPropertyOrNull("storage_size")?.GetInt64();
			long? freeStorage = json.GetPropertyOrNull("free_storage")?.GetInt64();
			long? externalStorageSize = json.GetPropertyOrNull("external_storage_size")?.GetInt64();
			long? externalFreeStorage = json.GetPropertyOrNull("external_free_storage")?.GetInt64();
			string screenResolution = json.GetPropertyOrNull("screen_resolution")?.GetString();
			float? screenDensity = json.GetPropertyOrNull("screen_density")?.GetSingle();
			int? screenDpi = json.GetPropertyOrNull("screen_dpi")?.GetInt32();
			DateTimeOffset? bootTime = json.GetPropertyOrNull("boot_time")?.GetDateTimeOffset();
			int? processorCount = json.GetPropertyOrNull("processor_count")?.GetInt32();
			string cpuDescription = json.GetPropertyOrNull("cpu_description")?.GetString();
			double value2 = default(double);
			int? processorFrequency = ((json.GetPropertyOrNull("processor_frequency")?.TryGetDouble(out value2) ?? false) ? new int?((int)value2) : ((int?)null));
			string deviceType = json.GetPropertyOrNull("device_type")?.GetString();
			string batteryStatus = json.GetPropertyOrNull("battery_status")?.GetString();
			string deviceUniqueIdentifier = json.GetPropertyOrNull("device_unique_identifier")?.GetString();
			bool? supportsVibration = json.GetPropertyOrNull("supports_vibration")?.GetBoolean();
			bool? supportsAccelerometer = json.GetPropertyOrNull("supports_accelerometer")?.GetBoolean();
			bool? supportsGyroscope = json.GetPropertyOrNull("supports_gyroscope")?.GetBoolean();
			bool? supportsAudio = json.GetPropertyOrNull("supports_audio")?.GetBoolean();
			bool? supportsLocationService = json.GetPropertyOrNull("supports_location_service")?.GetBoolean();
			return new Device
			{
				Timezone = timezone,
				Name = name,
				Manufacturer = manufacturer,
				Brand = brand,
				Family = family,
				Model = model,
				ModelId = modelId,
				Architecture = architecture,
				BatteryLevel = batteryLevel,
				IsCharging = isCharging,
				IsOnline = isOnline,
				Orientation = orientation,
				Simulator = simulator,
				MemorySize = memorySize,
				FreeMemory = freeMemory,
				UsableMemory = usableMemory,
				LowMemory = lowMemory,
				StorageSize = storageSize,
				FreeStorage = freeStorage,
				ExternalStorageSize = externalStorageSize,
				ExternalFreeStorage = externalFreeStorage,
				ScreenResolution = screenResolution,
				ScreenDensity = screenDensity,
				ScreenDpi = screenDpi,
				BootTime = bootTime,
				ProcessorCount = processorCount,
				CpuDescription = cpuDescription,
				ProcessorFrequency = processorFrequency,
				DeviceType = deviceType,
				BatteryStatus = batteryStatus,
				DeviceUniqueIdentifier = deviceUniqueIdentifier,
				SupportsVibration = supportsVibration,
				SupportsAccelerometer = supportsAccelerometer,
				SupportsGyroscope = supportsGyroscope,
				SupportsAudio = supportsAudio,
				SupportsLocationService = supportsLocationService
			};
		}
	}
}
