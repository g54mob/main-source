#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using Data.Shapes;
using Logic.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using Utils;
using Utils.JsonConverterUtils;

public static class SaveDirectoryVersionPlaytest
{
	public class ShapeDtoConverter : JsonConverter<ShapeDto>
	{
		[Serializable]
		public class OldVoxelDto
		{
			public int x;

			public int y;

			public int z;

			public bool IsOccupied;

			public float r;

			public float g;

			public float b;

			public float a;
		}

		public override void WriteJson(JsonWriter writer, ShapeDto value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override ShapeDto ReadJson(JsonReader reader, Type objectType, ShapeDto existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject obj = JObject.Load(reader);
			OldVoxelDto[] value = obj.GetValue<OldVoxelDto[]>("Voxels");
			Vector3Int value2 = obj.GetValue<Vector3Int>("Bounds");
			string value3 = obj.GetValue<string>("Hash");
			Voxel[] array = new Voxel[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				array[i] = new Voxel
				{
					Position = new Vector3Int(value[i].x, value[i].y, value[i].z),
					IsOccupied = value[i].IsOccupied,
					Color = new Color(value[i].r, value[i].g, value[i].b, value[i].a)
				};
			}
			return new ShapeDto(ShapeHashPair.Parse(value3), array, value2);
		}
	}

	public class SavedObjectDtoConverter : JsonConverter<SavedObjectDto>
	{
		public override void WriteJson(JsonWriter writer, SavedObjectDto value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override SavedObjectDto ReadJson(JsonReader reader, Type objectType, SavedObjectDto existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject obj = JObject.Load(reader);
			List<Vector3Int> value = obj.GetValue<List<Vector3Int>>("OccupiedPositions");
			int value2 = JsonExtensions.GetValue(obj, "Rotation", 0);
			bool value3 = obj.GetValue("Mirrored", defaultValue: false);
			bool value4 = obj.GetValue("NonChangable", defaultValue: false);
			int value5 = JsonExtensions.GetValue(obj, "Id", 0);
			List<Vector3Int> value6 = obj.GetValue<List<Vector3Int>>("SoftLinkedPositions");
			List<Vector3Int> value7 = obj.GetValue<List<Vector3Int>>("HardLinkedPositions");
			JsonConverter[] jsonConverters = new JsonConverter[3]
			{
				new ColorConverter(),
				new Vector3Converter(),
				new ShapeDtoConverter()
			};
			List<BehaviourConfigurationDto> valueWithDeseralize = obj.GetValueWithDeseralize<List<BehaviourConfigurationDto>>("BehaviourConfigurationDto", null, jsonConverters);
			List<BehaviourSaveStateDto> valueWithDeseralize2 = obj.GetValueWithDeseralize<List<BehaviourSaveStateDto>>("BehaviourSaveStateDto", null, jsonConverters);
			return new SavedObjectDto(value[0], value2, value3, value4, value5, value6, value7, valueWithDeseralize, valueWithDeseralize2);
		}
	}

	[Serializable]
	public class OldFactoryFloorSaveData
	{
		public ShapeDto[] Shapes;

		public FactoryLayerSaveData TerrainLayer;

		public FactoryLayerSaveData EditableFloor;

		public FactoryLayerSaveData UnlockableZones;
	}

	public static bool TryUpdateLevelSaveFile(string savePath, out FactoryShapesSaveData factoryShapesSaveData, out FactoryFloorSaveData factoryFloorSaveData)
	{
		string text = savePath + "/level.json";
		typeof(SaveDirectoryVersionPlaytest).Log("Trying: Updating Level Save File, filepath:\n" + text, "TryUpdateLevelSaveFile", 86);
		if (!SaveSystem.LoadFileData(text, out var data))
		{
			typeof(SaveDirectoryVersionPlaytest).LogError("Failed to load file data", "TryUpdateLevelSaveFile", 89);
			factoryShapesSaveData = null;
			factoryFloorSaveData = null;
			return false;
		}
		typeof(SaveDirectoryVersionPlaytest).Log("File Loaded, json:\n" + data, "TryUpdateLevelSaveFile", 94);
		if (!TryReadJson<OldFactoryFloorSaveData>(data, out var data2))
		{
			typeof(SaveDirectoryVersionPlaytest).LogError("Failed to read json data", "TryUpdateLevelSaveFile", 98);
			factoryShapesSaveData = null;
			factoryFloorSaveData = null;
			return false;
		}
		typeof(SaveDirectoryVersionPlaytest).Log($"Data Read (Shapes: {data2.Shapes.Length}, TerrainLayer: {data2.TerrainLayer.SavedObjectDtos.Count}, EditableFloor: {data2.EditableFloor.SavedObjectDtos.Count}, UnlockableZones: {data2.UnlockableZones.SavedObjectDtos.Count})", "TryUpdateLevelSaveFile", 103);
		factoryFloorSaveData = new FactoryFloorSaveData(data2.TerrainLayer, data2.EditableFloor);
		factoryShapesSaveData = new FactoryShapesSaveData(data2.Shapes);
		return true;
	}

	public static bool TryReadJson<T>(string json, out T data)
	{
		try
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};
			jsonSerializerSettings.Converters.Add(new ColorConverter());
			jsonSerializerSettings.Converters.Add(new Vector3Converter());
			jsonSerializerSettings.Converters.Add(new ShapeDtoConverter());
			jsonSerializerSettings.Converters.Add(new SavedObjectDtoConverter());
			data = JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
		}
		catch (Exception ex)
		{
			typeof(SaveDirectoryVersionPlaytest).LogAssertion("Failed to read json data with exception: " + ex.Message, "TryReadJson", 122);
			typeof(SaveDirectoryVersionPlaytest).LogWarning(json, "TryReadJson", 123);
			data = default(T);
			return false;
		}
		return data != null;
	}
}
