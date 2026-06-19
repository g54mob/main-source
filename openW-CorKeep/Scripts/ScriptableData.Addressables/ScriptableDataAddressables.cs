using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class ScriptableDataAddressables
{
	public class ScriptableDataAddressablesLoader : IScriptableDataLoader
	{
		private AsyncOperationHandle<IList<ScriptableDataBlock>> m_loadHandle;

		private Stopwatch m_loadTimer = new Stopwatch();

		private string m_addressablesLabel;

		public bool HasDataBlockChanges => false;

		public bool LoadCompleted => isLoaded;

		public float LoadCompletedPercentage
		{
			get
			{
				if (!isLoading)
				{
					return 0f;
				}
				if (!isLoaded)
				{
					return m_loadHandle.PercentComplete;
				}
				return 1f;
			}
		}

		private bool isLoading
		{
			get
			{
				if (m_loadHandle.IsValid())
				{
					return m_loadHandle.Status != AsyncOperationStatus.Succeeded;
				}
				return false;
			}
		}

		private bool isLoaded
		{
			get
			{
				if (m_loadHandle.IsValid())
				{
					return m_loadHandle.Status == AsyncOperationStatus.Succeeded;
				}
				return false;
			}
		}

		public ScriptableDataAddressablesLoader(string addressablesLabel)
		{
			m_addressablesLabel = addressablesLabel;
		}

		public async Task<IEnumerable<ScriptableDataBlock>> LoadAsync()
		{
			if (isLoaded)
			{
				UnityEngine.Debug.LogError("LoadAsync cannot be called when data blocks are already loaded.");
				return null;
			}
			if (isLoading)
			{
				UnityEngine.Debug.LogError("LoadAsync cannot be called while data blocks are already loading.");
				return null;
			}
			UnityEngine.Debug.Log("Loading data blocks...");
			m_loadTimer.Restart();
			m_loadHandle = Addressables.LoadAssetsAsync<ScriptableDataBlock>(m_addressablesLabel);
			await m_loadHandle.Task;
			m_loadTimer.Stop();
			double totalSeconds = m_loadTimer.Elapsed.TotalSeconds;
			UnityEngine.Debug.Log($"Data blocks finished loading from addressables ({totalSeconds}s)");
			return m_loadHandle.Result;
		}

		public IEnumerable<ScriptableDataBlock> Load()
		{
			if (isLoaded)
			{
				return m_loadHandle.Result;
			}
			if (!isLoading)
			{
				m_loadTimer.Restart();
				m_loadHandle = Addressables.LoadAssetsAsync<ScriptableDataBlock>(m_addressablesLabel);
			}
			m_loadHandle.WaitForCompletion();
			m_loadTimer.Stop();
			double totalSeconds = m_loadTimer.Elapsed.TotalSeconds;
			UnityEngine.Debug.Log($"Data blocks finished loading from addressables ({totalSeconds}s)");
			return m_loadHandle.Result;
		}

		public void Unload()
		{
			if (!m_loadHandle.IsValid())
			{
				UnityEngine.Debug.LogError("not loaded");
				return;
			}
			if (isLoading)
			{
				m_loadHandle.WaitForCompletion();
			}
			m_loadHandle.Release();
			m_loadHandle = default(AsyncOperationHandle<IList<ScriptableDataBlock>>);
		}
	}

	public const string ADDRESSABLES_LABEL = "ScriptableDataBlock";

	private static AsyncOperationHandle<IList<ScriptableDataBlock>> s_loadHandle;

	private static Stopwatch s_loadTimer = new Stopwatch();

	private static ConcurrentQueue<ScriptableDataBlock> s_loadQueue = new ConcurrentQueue<ScriptableDataBlock>();

	public static bool isLoading
	{
		get
		{
			if (s_loadHandle.IsValid())
			{
				return s_loadHandle.Status != AsyncOperationStatus.Succeeded;
			}
			return false;
		}
	}

	public static bool isLoaded
	{
		get
		{
			if (s_loadHandle.IsValid())
			{
				return s_loadHandle.Status == AsyncOperationStatus.Succeeded;
			}
			return false;
		}
	}

	public static float loadTime => (float)s_loadTimer.Elapsed.TotalSeconds;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void Init()
	{
		if (Application.isPlaying)
		{
			ScriptableData.AddDataBlocksLoader("addressables", new ScriptableDataAddressablesLoader("ScriptableDataBlock"));
		}
	}
}
