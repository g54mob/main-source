using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	public class CozyThunderManager : MonoBehaviour
	{
		private float thunderTimer;

		public CozyWeather weatherSphere;

		public ThunderFX thunderFX;

		public void PlayEffect(float weight)
		{
			if (Application.isPlaying && weight > 0.5f)
			{
				thunderTimer -= Time.deltaTime;
				if (thunderTimer <= 0f)
				{
					Strike();
				}
				if (thunderTimer > thunderFX.timeBetweenStrikes.y)
				{
					thunderTimer = thunderFX.timeBetweenStrikes.y;
				}
			}
		}

		public void Strike()
		{
			if ((bool)weatherSphere.cozyCamera)
			{
				Camera cozyCamera = weatherSphere.cozyCamera;
				Vector3 position2;
				if (Random.value > thunderFX.spawnInFrustumPercentage)
				{
					Vector3 position = new Vector3(Random.Range(thunderFX.minScreenXmultiplier, thunderFX.maxScreenXmultiplier), Random.Range(thunderFX.minScreenYmultiplier, thunderFX.maxScreenYmultiplier), Random.Range(cozyCamera.nearClipPlane + thunderFX.minimumDistance, thunderFX.maximumDistance));
					position2 = cozyCamera.ViewportToWorldPoint(position);
				}
				else
				{
					position2 = cozyCamera.transform.position + new Vector3(Random.Range(-1, 1), 0f, Random.Range(-1, 1)).normalized * Random.Range(thunderFX.minimumDistance, thunderFX.maximumDistance);
				}
				position2.y = cozyCamera.transform.position.y;
				Object.Instantiate(thunderFX.thunderPrefab, position2, Quaternion.identity, base.transform).transform.LookAt(cozyCamera.transform.position);
				thunderTimer = Random.Range(thunderFX.timeBetweenStrikes.x, thunderFX.timeBetweenStrikes.y);
			}
		}
	}
}
