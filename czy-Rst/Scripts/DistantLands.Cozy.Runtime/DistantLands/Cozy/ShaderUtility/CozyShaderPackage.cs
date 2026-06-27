using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.ShaderUtility
{
	public class CozyShaderPackage : ScriptableObject
	{
		public enum SRPTarget
		{
			BIRP = 0,
			URP = 1,
			HDRP = 2
		}

		public enum UnityVersion
		{
			Min = 0,
			Unity2021_2 = 20212,
			Unity2021_3 = 20213,
			Unity2022_1 = 20221,
			Unity2022_2 = 20222,
			Unity2022_3 = 20223,
			Unity2023_2 = 20232,
			Unity2023_3 = 20233,
			Max = 30000
		}

		[Serializable]
		public class Entry
		{
			public SRPTarget srpTarget;

			public UnityVersion min;

			public UnityVersion max = UnityVersion.Max;

			public Shader shader;

			[HideInInspector]
			public string shaderSource;
		}

		public List<Entry> entries = new List<Entry>();

		public void PackageShaderVariants()
		{
			foreach (Entry entry in entries)
			{
				if (!entry.shader)
				{
					break;
				}
				_ = entry.shader != null;
			}
		}

		public static SRPTarget GetCurrentSRP()
		{
			return SRPTarget.URP;
		}

		public string GetShaderSource()
		{
			UnityVersion unityVersion = UnityVersion.Min;
			unityVersion = UnityVersion.Unity2021_2;
			unityVersion = UnityVersion.Unity2021_3;
			unityVersion = UnityVersion.Unity2022_1;
			unityVersion = UnityVersion.Unity2022_2;
			unityVersion = UnityVersion.Unity2022_3;
			SRPTarget currentSRP = GetCurrentSRP();
			string text = null;
			foreach (Entry entry in entries)
			{
				if (currentSRP == entry.srpTarget && unityVersion >= entry.min && unityVersion <= entry.max)
				{
					if (text != null)
					{
						Debug.LogWarning("Found multiple possible entries for unity version of shader");
					}
					text = entry.shaderSource;
				}
			}
			return text;
		}
	}
}
