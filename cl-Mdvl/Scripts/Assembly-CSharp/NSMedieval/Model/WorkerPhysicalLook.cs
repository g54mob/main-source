using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NSMedieval.Dictionary;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("WorkerPhysicalLook", "")]
	public class WorkerPhysicalLook : IFVSerializable
	{
		[SerializeField]
		private List<string> workerBody;

		[SerializeField]
		private StringStringDictionary bodyColors;

		[SerializeField]
		private List<string> possibleBodyParts;

		public List<string> WorkerBody => workerBody;

		public Dictionary<string, string> BodyColors => bodyColors.Dictionary;

		public List<string> ShaderParameters { get; private set; }

		public List<string> ShaderTextureParameters { get; private set; }

		public List<string> PossibleBodyParts => possibleBodyParts;

		public WorkerPhysicalLook()
		{
			ShaderParameters = new List<string> { "_SkinColor", "_HairColor" };
			ShaderTextureParameters = new List<string> { "_AlbedoTexture", "_ReflectiveTexture" };
		}

		public void Initialize()
		{
			ShaderParameters = new List<string> { "_SkinColor", "_HairColor" };
			ShaderTextureParameters = new List<string> { "_AlbedoTexture", "_ReflectiveTexture" };
			workerBody = new List<string>();
			bodyColors = SerializableDictionary<string, string>.CreateNew<StringStringDictionary>();
			foreach (string shaderParameter in ShaderParameters)
			{
				BodyColors.Add(shaderParameter, string.Empty);
			}
		}

		public void SetWorkerBody(List<string> activeParts)
		{
			workerBody = activeParts;
		}

		public void SetPossibleBodyParts(List<string> possibleParts)
		{
			possibleBodyParts = possibleParts;
		}

		public string GetHairType()
		{
			return workerBody[0];
		}

		public void SetHairType(string hairType)
		{
			workerBody[0] = hairType;
		}

		public string GetHeadType()
		{
			return workerBody[1];
		}

		public void SetHeadType(string headType)
		{
			workerBody[1] = headType;
		}

		public string GetFacialHairGroup()
		{
			if (workerBody.Count < 3 || (string.IsNullOrEmpty(workerBody[2]) && string.IsNullOrEmpty(workerBody[3])))
			{
				return string.Empty;
			}
			if (!(workerBody[2] != string.Empty))
			{
				return "moustaches";
			}
			return "beards";
		}

		public string GetFacialHairType()
		{
			if (workerBody.Count < 4)
			{
				return string.Empty;
			}
			if (workerBody[2].Equals(string.Empty) || workerBody[2].Equals("none"))
			{
				return workerBody[3];
			}
			return workerBody[2];
		}

		public void SetBeardType(string beardType)
		{
			if (workerBody.Count >= 3)
			{
				workerBody[2] = beardType;
			}
		}

		public string GetBeardType()
		{
			if (workerBody.Count < 3 || string.IsNullOrEmpty(workerBody[2]))
			{
				return string.Empty;
			}
			if (!(workerBody[2] == string.Empty))
			{
				return workerBody[2];
			}
			return "none";
		}

		public void SetMoustacheType(string moustacheType)
		{
			if (workerBody.Count >= 4)
			{
				workerBody[3] = moustacheType;
			}
		}

		public string GetMoustacheType()
		{
			if (workerBody.Count < 4 || string.IsNullOrEmpty(workerBody[3]))
			{
				return string.Empty;
			}
			if (!(workerBody[3] == string.Empty))
			{
				return workerBody[3];
			}
			return "none";
		}

		public void SetBodyColors(Dictionary<string, string> bodyColors)
		{
			this.bodyColors.Dictionary = bodyColors;
		}

		public string GetHairColor()
		{
			if (bodyColors.Dictionary.ContainsKey(ShaderParameters[1]))
			{
				return bodyColors.Dictionary[ShaderParameters[1]];
			}
			if (!bodyColors.Dictionary.ContainsKey("_Color1"))
			{
				return "#71635A";
			}
			return bodyColors.Dictionary["_Color1"];
		}

		public void SetHairColor(string color)
		{
			bodyColors.Dictionary[ShaderParameters[1]] = color;
		}

		public string GetSkinColor()
		{
			if (bodyColors.Dictionary.ContainsKey(ShaderParameters[0]))
			{
				return bodyColors.Dictionary[ShaderParameters[0]];
			}
			if (!bodyColors.Dictionary.ContainsKey("_Color0"))
			{
				return "#fbe5ba";
			}
			return bodyColors.Dictionary["_Color0"];
		}

		public void SetSkinColor(string color)
		{
			bodyColors.Dictionary[ShaderParameters[0]] = color;
		}

		[OnDeserialized]
		private void SetValuesOnDeserialized(StreamingContext context)
		{
			OnDeserialized();
		}

		private void OnDeserialized()
		{
			ShaderParameters = new List<string> { "_SkinColor", "_HairColor" };
			ShaderTextureParameters = new List<string> { "_AlbedoTexture", "_ReflectiveTexture" };
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("workerBody", workerBody);
			serializer.Write("bodyColors", bodyColors);
			serializer.Write("possibleBodyParts", possibleBodyParts);
		}

		public WorkerPhysicalLook(FVDeserializer deserializer)
		{
			workerBody = deserializer.ReadStringList("workerBody");
			bodyColors = deserializer.ReadObject<StringStringDictionary>("bodyColors");
			possibleBodyParts = deserializer.ReadStringList("possibleBodyParts");
			OnDeserialized();
		}
	}
}
