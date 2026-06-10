using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class AddressableRepositoryStartupHandler : MonoBehaviour
	{
		[SerializeField]
		private bool generateRepositoriesOnStartup;

		private void Awake()
		{
			generateRepositoriesOnStartup = false;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (!(commandLineArgs[i] != "-force_preload"))
				{
					Log.Info("Force pre-preload argument detected.", "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\AddressableRepositoryStartupHandler.cs");
					generateRepositoriesOnStartup = true;
					break;
				}
			}
			Transform transform = base.transform;
			int childCount = transform.childCount;
			if (!generateRepositoriesOnStartup)
			{
				for (int j = 0; j < childCount; j++)
				{
					transform.GetChild(j).gameObject.SetActive(value: true);
				}
				return;
			}
			List<GameObject> list = new List<GameObject>();
			for (int k = 0; k < childCount; k++)
			{
				list.Add(transform.GetChild(k).gameObject);
			}
			foreach (GameObject item in list)
			{
				UnityEngine.Object.Destroy(item);
			}
			Log.Info("Pre-made repos destroyed! Generating addressable repos in realtime. Might take some time...", "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\AddressableRepositoryStartupHandler.cs");
			GameObject obj = new GameObject("DynamicAddressableRepository");
			obj.transform.parent = base.transform;
			obj.AddComponent<TextureRepository>().SetLoadOnStartup(value: true);
			obj.AddComponent<PrefabRepository>().SetLoadOnStartup(value: true);
			obj.AddComponent<SpriteRepository>().SetLoadOnStartup(value: true);
			obj.AddComponent<SpriteAssetRepository>().SetLoadOnStartup(value: true);
			obj.AddComponent<MeshRepository>().SetLoadOnStartup(value: true);
			Log.Info("Repo generation completed", "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\AddressableRepositoryStartupHandler.cs");
		}
	}
}
