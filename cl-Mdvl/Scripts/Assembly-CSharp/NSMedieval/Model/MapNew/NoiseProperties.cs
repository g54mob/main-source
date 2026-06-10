using System;
using NSEipix.Base;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	[FVSerializableKey("NoiseProperties", "")]
	public class NoiseProperties : NSEipix.Base.Model, IFVSerializable
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private int noiseType;

		[SerializeField]
		private float frequency = 5f;

		[SerializeField]
		private float gain = 1f;

		[SerializeField]
		private int fractalOctaves = 4;

		[SerializeField]
		private int fractalType;

		[SerializeField]
		private float fractalGain = 1f;

		[SerializeField]
		private bool multiplyWithBrush;

		[SerializeField]
		private float distortAmplitude;

		[SerializeField]
		private float distortFrequency = 0.05f;

		public int NoiseType => noiseType;

		public float Frequency => frequency;

		public float Gain => gain;

		public int FractalOctaves => fractalOctaves;

		public int FractalType => fractalType;

		public float FractalGain => fractalGain;

		public bool MultiplyWithBrush => multiplyWithBrush;

		public float DistortAmplitude => distortAmplitude;

		public float DistortFrequency => distortFrequency;

		public NoiseProperties()
		{
		}

		public override string GetID()
		{
			return id;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("noiseType", noiseType);
			serializer.Write("frequency", frequency);
			serializer.Write("gain", gain);
			serializer.Write("fractalOctaves", fractalOctaves);
			serializer.Write("fractalType", fractalType);
			serializer.Write("fractalGain", fractalGain);
			serializer.Write("multiplyWithBrush", multiplyWithBrush);
			serializer.Write("distortAmplitude", distortAmplitude);
			serializer.Write("distortFrequency", distortFrequency);
		}

		public NoiseProperties(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			noiseType = deserializer.ReadInt("noiseType");
			frequency = deserializer.ReadFloat("frequency");
			gain = deserializer.ReadFloat("gain");
			fractalOctaves = deserializer.ReadInt("fractalOctaves");
			fractalType = deserializer.ReadInt("fractalType");
			fractalGain = deserializer.ReadFloat("fractalGain");
			multiplyWithBrush = deserializer.ReadBool("multiplyWithBrush");
			distortAmplitude = deserializer.ReadFloat("distortAmplitude");
			distortFrequency = deserializer.ReadFloat("distortFrequency");
		}
	}
}
