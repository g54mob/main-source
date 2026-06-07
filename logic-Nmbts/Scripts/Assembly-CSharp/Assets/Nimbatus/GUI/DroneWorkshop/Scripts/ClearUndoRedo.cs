using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ClearUndoRedo : MonoBehaviour
	{
		public void OnClick()
		{
			BaseSingleton<UndoManager>.Instance.Reset();
		}
	}
}
