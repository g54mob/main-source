using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.GameOver
{
	public class ResetGalaxy : MonoBehaviour
	{
		public void OnClick()
		{
			SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeHealth(Mathf.Max(1, SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth - 1));
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.ResetGalaxy();
		}
	}
}
