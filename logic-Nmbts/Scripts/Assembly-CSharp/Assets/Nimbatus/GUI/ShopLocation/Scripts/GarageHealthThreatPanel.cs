using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class GarageHealthThreatPanel : MonoBehaviour
	{
		public void Start()
		{
			base.gameObject.SetActive(RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat);
		}
	}
}
