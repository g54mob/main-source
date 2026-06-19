using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace PugWorldGen
{
	[CreateAssetMenu(menuName = "Pug/World Gen/World Definition", fileName = "World Definition", order = 0)]
	public class PugWorldDefinition : ScriptableObject
	{
		[Serializable]
		public class ParameterDefinitionsEntry
		{
			public string subClassName;

			public ParametersDefinition parameters;
		}

		public Action<Vector2, Vector2, NativeArray<Color32>, int> OnAreaRequestComplete;

		public string className;

		[Space(10f)]
		public float tilesPerMeter = 1f;

		[Space(10f)]
		public ParametersDefinition globalParametersDefinition;

		public ParametersDefinition biomeParametersDefinition;

		public ParameterDefinitionsEntry[] parameterDefinitions;

		public List<BiomeDefinition> biomeDefinitions = new List<BiomeDefinition>();

		public List<TileTypeDefinition> tileTypeDefinitions = new List<TileTypeDefinition>();

		[TextArea(5, 100)]
		public string tileColorizationFunction = "float3 ColorizeTile(float4 data)\r\n{\r\n\tDEBUG_COLOR_OUTPUT\r\n\tuint tileType = data.r * 255u;\r\n\treturn GetTileColor(tileType);\r\n}";

		public Color32 backgroundColor = Color.gray;

		public bool skipErrorChecking;
	}
}
