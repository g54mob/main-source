using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class EnableGameObjectAfterLoad : MonoBehaviour
	{
		public GameObject ObjectToEnable;

		private bool _hasWokenUp;

		public virtual void Update()
		{
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !_hasWokenUp)
			{
				WakeUp();
				_hasWokenUp = true;
			}
		}

		private void WakeUp()
		{
			ObjectToEnable.SetActive(true);
		}
	}
}
