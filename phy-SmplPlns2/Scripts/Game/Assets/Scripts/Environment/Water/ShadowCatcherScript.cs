using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts.Environment.Water
{
	public class ShadowCatcherScript : MonoBehaviour
	{
		protected virtual void Awake()
		{
			if ((ShadowQualitySettings.ShadowQualityLevel)Game.Instance.Settings.Quality.Shadow.ShadowQuality == ShadowQualitySettings.ShadowQualityLevel.Off)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		protected virtual void Update()
		{
			float valueOrDefault = GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault();
			Vector3 position = Camera.main.transform.position;
			base.transform.position = new Vector3(position.x, valueOrDefault + 0.05f, position.z);
		}
	}
}
