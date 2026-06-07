using System;
using UnityEngine;

namespace VisualDesignCafe.Nature
{
	[ExecuteAlways]
	public class RuntimeEntryPoint : MonoBehaviour
	{
		private static RuntimeEntryPoint _entryPoint;

		[SerializeField]
		private ShaderResources _shaderResources;

		[NonSerialized]
		internal bool _isDestroyed;

		public static RuntimeEntryPoint EntryPoint => null;

		public ShaderResources Resources => null;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		internal static void Load()
		{
		}

		internal static void Unload()
		{
		}

		private static RuntimeEntryPoint CreateEntryPoint()
		{
			return null;
		}

		private static RuntimeEntryPoint FindExistingEntryPointInScene()
		{
			return null;
		}

		private void LoadResources()
		{
		}

		private void UnloadResources()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
