using System.Linq;
using NSEipix.Repository;
using NSMedieval.Fire;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval
{
	public class ArrayStorageInitializers : MonoBehaviour
	{
		private static bool initDone;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void OnRuntimeInitialize()
		{
			Application.quitting -= OnApplicationQuit;
			Application.quitting += OnApplicationQuit;
			initDone = false;
		}

		private static void Init()
		{
			foreach (MapSize item in Repository<MapSizeRepository, MapSize>.Instance.GetAllItems().Reverse())
			{
				if (item.ShownInRelease)
				{
					GridDataIndexTools.CheckSetMaxDataLength(item.Width, item.Height, item.Length);
				}
			}
		}

		private static void OnApplicationQuit()
		{
			Application.quitting -= OnApplicationQuit;
			ArrayStorage.DisposeAll();
			ArrayStorage.ClearStorageDictionary();
		}

		private void Start()
		{
			if (!initDone)
			{
				initDone = true;
				Init();
			}
		}
	}
}
