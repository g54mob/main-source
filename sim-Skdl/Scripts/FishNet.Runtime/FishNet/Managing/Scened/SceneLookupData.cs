using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Scened
{
	public class SceneLookupData : IEquatable<SceneLookupData>
	{
		public int Handle;

		public string Name;

		private const string INVALID_SCENE = "One or more scene information entries contain invalid data and have been skipped.";

		public string NameOnly => null;

		public bool IsValid => false;

		public SceneLookupData()
		{
		}

		public SceneLookupData(Scene scene)
		{
		}

		public SceneLookupData(string name)
		{
		}

		public SceneLookupData(int handle)
		{
		}

		public SceneLookupData(int handle, string name)
		{
		}

		public static bool operator ==(SceneLookupData sldA, SceneLookupData sldB)
		{
			return false;
		}

		public static bool operator !=(SceneLookupData sldA, SceneLookupData sldB)
		{
			return false;
		}

		public bool Equals(SceneLookupData sld)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public static SceneLookupData CreateData(Scene scene)
		{
			return null;
		}

		public static SceneLookupData CreateData(string name)
		{
			return null;
		}

		public static SceneLookupData CreateData(int handle)
		{
			return null;
		}

		public static SceneLookupData[] CreateData(List<Scene> scenes)
		{
			return null;
		}

		public static SceneLookupData[] CreateData(List<string> names)
		{
			return null;
		}

		public static SceneLookupData[] CreateData(List<int> handles)
		{
			return null;
		}

		public static SceneLookupData[] CreateData(Scene[] scenes)
		{
			return null;
		}

		public static SceneLookupData[] CreateData(string[] names)
		{
			return null;
		}

		public static SceneLookupData[] ValidateData(SceneLookupData data)
		{
			return null;
		}

		public static SceneLookupData[] ValidateData(SceneLookupData[] datas)
		{
			return null;
		}

		public static SceneLookupData[] CreateData(int[] handles)
		{
			return null;
		}

		private static string RemoveUnityExtension(string text)
		{
			return null;
		}

		public Scene GetScene(out bool foundByHandle, bool warnIfDuplicates = true)
		{
			foundByHandle = default(bool);
			return default(Scene);
		}
	}
}
