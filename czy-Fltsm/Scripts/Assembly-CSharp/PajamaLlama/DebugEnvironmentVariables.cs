using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama
{
	public class DebugEnvironmentVariables : ScriptableObject
	{
		[Serializable]
		public struct Variable
		{
			public DebugEnvironmentVariable Id;

			public UnityEngine.Object ObjectReference;
		}

		public const string Path = "Assets/Resources/DebugVariables.asset";

		public const string VARIABLE_DebugTileProperties = "DebugTileProperties";

		[SerializeField]
		private string _prefabPath;

		[SerializeField]
		private List<Variable> _variables;

		private static bool _loadResource = true;

		private static DebugEnvironmentVariables _instance;

		public bool IsEmpty => _variables.IsNullOrEmpty();

		public static T GetObjectReference<T>(DebugEnvironmentVariable id) where T : UnityEngine.Object
		{
			return null;
		}
	}
}
