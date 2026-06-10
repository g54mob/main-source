using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Enums;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	[FVSerializableKey("MapGenerationStep2", "")]
	public class MapGenerationStep2 : NSEipix.Base.Model, IFVSerializable
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private List<string> brushIDs = new List<string>();

		[SerializeField]
		private List<string> brushIDsLarge = new List<string>();

		[SerializeField]
		private Vector2 position;

		[SerializeField]
		private Vector2 randomPosition;

		[SerializeField]
		private Vector2 size;

		[SerializeField]
		private float rotation;

		[SerializeField]
		private int height;

		[SerializeField]
		private float randomRotation;

		[SerializeField]
		private int repeatCount = 1;

		[SerializeField]
		private int repeatCountMax;

		[SerializeField]
		private string operation = "Max";

		[SerializeField]
		private FloatRange scaleXRange = new FloatRange(1f, 1f);

		[SerializeField]
		private FloatRange scaleYRange = new FloatRange(1f, 1f);

		[SerializeField]
		private bool noiseEnabled;

		[SerializeField]
		private NoiseProperties noise;

		[SerializeField]
		private string plotData = string.Empty;

		[SerializeField]
		private int plotOnlyOnTopLayers;

		[SerializeField]
		private int plotHeightCenter = 1;

		[SerializeField]
		private int plotHeightBelow = 2;

		[SerializeField]
		private int plotHeightAbove = 1;

		[SerializeField]
		private int plotHeightOffsetDown;

		[SerializeField]
		private PropPlacement props;

		[SerializeField]
		private float executeStepChance = 1f;

		[SerializeField]
		private bool skipRiverOnExecute;

		[SerializeField]
		private bool dontScaleWithMap;

		[SerializeField]
		private float topLayerWaterLevel;

		private HeightmapOperationType operationCache = HeightmapOperationType.Add;

		private bool operationCacheInit;

		public List<string> BrushIDs => brushIDs;

		public List<string> BrushIDsLarge => brushIDsLarge;

		public Vector2 Position => position;

		public Vector2 RandomPosition => randomPosition;

		public Vector2 Size => size;

		public float Rotation => rotation;

		public int Height => height;

		public float RandomRotation => randomRotation;

		public int RepeatCount => repeatCount;

		public int RepeatCountMax => repeatCountMax;

		public HeightmapOperationType Operation
		{
			get
			{
				if (!operationCacheInit)
				{
					operationCacheInit = true;
					operationCache = Enum.Parse<HeightmapOperationType>(operation);
				}
				return operationCache;
			}
		}

		public FloatRange ScaleXRange => scaleXRange;

		public FloatRange ScaleYRange => scaleYRange;

		public bool NoiseEnabled => noiseEnabled;

		public NoiseProperties Noise => noise;

		public string PlotData => plotData;

		public int PlotOnlyOnTopLayers => plotOnlyOnTopLayers;

		public int PlotHeightCenter => plotHeightCenter;

		public int PlotHeightBelow => plotHeightBelow;

		public int PlotHeightAbove => plotHeightAbove;

		public int PlotHeightOffsetDown => plotHeightOffsetDown;

		public PropPlacement Props => props;

		public float ExecuteStepChance => executeStepChance;

		public bool SkipRiverOnExecute => skipRiverOnExecute;

		public bool DontScaleWithMap => dontScaleWithMap;

		public float TopLayerWaterLevel => topLayerWaterLevel;

		public MapGenerationStep2()
		{
		}

		public override string GetID()
		{
			return id;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("brushIDs", brushIDs);
			serializer.Write("brushIDsLarge", brushIDsLarge);
			serializer.Write("position", position);
			serializer.Write("randomPosition", randomPosition);
			serializer.Write("size", size);
			serializer.Write("rotation", rotation);
			serializer.Write("height", height);
			serializer.Write("randomRotation", randomRotation);
			serializer.Write("repeatCount", repeatCount);
			serializer.Write("repeatCountMax", repeatCountMax);
			serializer.Write("operation", operation);
			serializer.Write("scaleXRange", scaleXRange);
			serializer.Write("scaleYRange", scaleYRange);
			serializer.Write("noiseEnabled", noiseEnabled);
			serializer.Write("noise", noise);
			serializer.Write("plotData", plotData);
			serializer.Write("plotOnlyOnTopLayers", plotOnlyOnTopLayers);
			serializer.Write("plotHeightCenter", plotHeightCenter);
			serializer.Write("plotHeightBelow", plotHeightBelow);
			serializer.Write("plotHeightAbove", plotHeightAbove);
			serializer.Write("plotHeightOffsetDown", plotHeightOffsetDown);
			serializer.Write("props", props);
		}

		public MapGenerationStep2(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			brushIDs = deserializer.ReadStringList("brushIDs");
			brushIDsLarge = deserializer.ReadStringList("brushIDsLarge");
			position = deserializer.ReadVector2("position");
			randomPosition = deserializer.ReadVector2("randomPosition");
			size = deserializer.ReadVector2("size");
			rotation = deserializer.ReadFloat("rotation");
			height = deserializer.ReadInt("height");
			randomRotation = deserializer.ReadFloat("randomRotation");
			repeatCount = deserializer.ReadInt("repeatCount");
			repeatCountMax = deserializer.ReadInt("repeatCountMax");
			operation = deserializer.ReadString("operation");
			scaleXRange = deserializer.ReadObject<FloatRange>("scaleXRange");
			scaleYRange = deserializer.ReadObject<FloatRange>("scaleYRange");
			noiseEnabled = deserializer.ReadBool("noiseEnabled");
			noise = deserializer.ReadObject<NoiseProperties>("noise");
			plotData = deserializer.ReadString("plotData");
			plotOnlyOnTopLayers = deserializer.ReadInt("plotOnlyOnTopLayers");
			plotHeightCenter = deserializer.ReadInt("plotHeightCenter");
			plotHeightBelow = deserializer.ReadInt("plotHeightBelow");
			plotHeightAbove = deserializer.ReadInt("plotHeightAbove");
			plotHeightOffsetDown = deserializer.ReadInt("plotHeightOffsetDown");
			props = deserializer.ReadObject<PropPlacement>("props");
		}
	}
}
