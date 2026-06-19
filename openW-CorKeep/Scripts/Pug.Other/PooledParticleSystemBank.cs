using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Pug.UnityExtensions;
using UnityEngine;

[CreateAssetMenu(menuName = "Pug/Gameplay/PooledParticleSystemBank", order = 1)]
public class PooledParticleSystemBank : PoolablePrefabBank
{
	[Serializable]
	public class PoolInitializer
	{
		public GameObject prefab;

		public int initialSize;

		public int maxSize;

		[AllowNesting]
		[ReadOnly]
		public string persistentName;

		[AllowNesting]
		[ReadOnly]
		public int persistentHash;
	}

	private const int DEFAULT_INITIAL_SIZE = 8;

	private const int DEFAULT_MAX_SIZE = 256;

	[SerializeField]
	public List<PlatformObjectPoolScaling> poolablePlatformScaling = new List<PlatformObjectPoolScaling>();

	[ArrayElementTitle("prefab, initialSize, maxSize")]
	public List<PoolInitializer> poolInitializers = new List<PoolInitializer>();

	private int _previousSize = -1;

	private static readonly string[] ReservedNames = new string[77]
	{
		"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
		"class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum",
		"event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto",
		"if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace",
		"new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public",
		"readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
		"struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
		"unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
	};

	public override IEnumerator<PoolablePrefab> GetEnumerator()
	{
		foreach (PoolInitializer poolInitializer in poolInitializers)
		{
			yield return new PoolablePrefab
			{
				prefab = poolInitializer.prefab,
				initialSize = poolInitializer.initialSize,
				maxSize = poolInitializer.maxSize
			};
		}
	}

	public override bool TryGetCurrentPlatformPoolScaling(out PlatformObjectPoolScaling poolScaling)
	{
		poolScaling = poolablePlatformScaling.FirstOrDefault((PlatformObjectPoolScaling scaling) => scaling.Platform.Equals(Application.platform));
		return poolScaling != null;
	}

	public void OnValidate()
	{
		if (_previousSize == -1)
		{
			_previousSize = poolInitializers.Count;
		}
		for (int i = _previousSize; i < poolInitializers.Count; i++)
		{
			poolInitializers[i].prefab = null;
			poolInitializers[i].initialSize = 8;
			poolInitializers[i].maxSize = 256;
			poolInitializers[i].persistentName = "";
			poolInitializers[i].persistentHash = 0;
		}
		_previousSize = poolInitializers.Count;
		foreach (PoolInitializer poolInitializer in poolInitializers)
		{
			if (poolInitializer.prefab == null)
			{
				continue;
			}
			if (poolInitializer.prefab.GetComponent<PooledParticleSystem>() == null)
			{
				Debug.LogError($"Prefab {poolInitializer.prefab} does not have a suitable PooledParticleSystem component");
				poolInitializer.prefab = null;
			}
			else
			{
				if (!string.IsNullOrEmpty(poolInitializer.persistentName))
				{
					continue;
				}
				string prefabName = poolInitializer.prefab.name;
				bool flag = true;
				if (poolInitializers.Any((PoolInitializer q) => q.persistentName == prefabName))
				{
					Debug.LogError(prefabName + " is already in use. Please rename the prefab to something else.");
					flag = false;
				}
				if (poolInitializers.Any((PoolInitializer q) => q.persistentHash == Animator.StringToHash(prefabName)))
				{
					Debug.LogError("Another particle effect already uses the same hash as " + prefabName + " (wow, that's unlucky!). Please rename the prefab to something else.");
					flag = false;
				}
				if (ReservedNames.Any((string q) => q == prefabName))
				{
					Debug.LogError(prefabName + " is a reserved C# keyword. Please rename the prefab to something else.");
					flag = false;
				}
				for (int num = 0; num < prefabName.Length; num++)
				{
					char c = prefabName[num];
					bool flag2 = (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_';
					bool flag3 = c >= '0' && c <= '9';
					if (num == 0 && flag3)
					{
						Debug.LogError(prefabName + " starts with a number. Please rename the prefab to something else.");
						flag = false;
					}
					if (!flag3 && !flag2)
					{
						Debug.LogError($"{c} is an illegal character. Please rename the prefab to something else.");
						flag = false;
					}
				}
				if (!flag)
				{
					poolInitializer.prefab = null;
					continue;
				}
				poolInitializer.persistentName = prefabName;
				poolInitializer.persistentHash = Animator.StringToHash(prefabName);
			}
		}
	}

	public GameObject Get(int particleEffectID)
	{
		foreach (PoolInitializer poolInitializer in poolInitializers)
		{
			if (poolInitializer.persistentHash == particleEffectID)
			{
				return poolInitializer.prefab;
			}
		}
		return null;
	}
}
