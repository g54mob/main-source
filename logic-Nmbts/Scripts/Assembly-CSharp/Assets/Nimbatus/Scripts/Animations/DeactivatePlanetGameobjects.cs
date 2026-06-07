using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class DeactivatePlanetGameobjects : MonoBehaviour
	{
		private GameObject _foreGroundTerrain;

		private GameObject _backgroundTerrain;

		public float StartDelay;

		private void OnEnable()
		{
			if (_foreGroundTerrain == null && _backgroundTerrain == null)
			{
				_foreGroundTerrain = GameObject.Find("ForeGroundTerrain");
				_backgroundTerrain = GameObject.Find("BackgroundTerrain");
			}
			StartCoroutine(DeactivateObjects());
		}

		private IEnumerator DeactivateObjects()
		{
			yield return new WaitForSeconds(StartDelay);
			if (_foreGroundTerrain != null)
			{
				_foreGroundTerrain.SetActive(false);
			}
			if (_backgroundTerrain != null)
			{
				_backgroundTerrain.SetActive(false);
			}
		}
	}
}
