using UnityEngine;

namespace Data.SaveData
{
	public class GlobalPersistentLoadWidget : MonoBehaviour
	{
		[SerializeField]
		private GlobalPersistentManager _globalPersistentManager;

		private void Awake()
		{
			_globalPersistentManager.LoadGlobalPersistentSOs();
		}
	}
}
