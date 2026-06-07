using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

namespace Data.SaveData
{
	[CreateAssetMenu(menuName = "PersistentSOs/Global Persistent Manager", fileName = "GlobalPersistentManager", order = 0)]
	public class GlobalPersistentManager : ScriptableObject
	{
		[SerializeField]
		private PersistentSOLibrary _globallyPersistentSOLibrary;

		[SerializeField]
		private string _globalPersistentSOFolder = "GlobalSettings";

		private string Path => SaveSystem.GameSavePath + "/" + _globalPersistentSOFolder;

		[Button(null, EButtonEnableMode.Always)]
		public void SaveGlobalPersistentSOs()
		{
			Task.WaitAll(_globallyPersistentSOLibrary.SaveAllPersistentSOsAsync(Path));
		}

		[Button(null, EButtonEnableMode.Always)]
		public void ResetToDefaults()
		{
			_globallyPersistentSOLibrary.ResetPersistentSOs();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void LoadGlobalPersistentSOs()
		{
			_globallyPersistentSOLibrary.LoadAllPersistentSOs(Path);
		}

		public void SavePersistentSOManually(AbstractPersistentSO persistentSo)
		{
			_globallyPersistentSOLibrary.SavePersistentSO(Path, persistentSo);
		}
	}
}
