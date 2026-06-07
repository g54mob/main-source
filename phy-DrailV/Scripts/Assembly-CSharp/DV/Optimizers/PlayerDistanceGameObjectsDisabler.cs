using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.Optimizers
{
	public class PlayerDistanceGameObjectsDisabler : MonoBehaviour
	{
		public List<GameObject> optimizingGameObjects;

		public float disableSqrDistance = 250000f;

		public float checkPeriodPerGO = 2f;

		private void Start()
		{
			if (optimizingGameObjects == null || optimizingGameObjects.Count == 0)
			{
				Debug.LogError("No optimizingGameObjects were set, destroying PlayerDistanceGameObjectsDisabler!", this);
				Object.Destroy(this);
			}
		}

		private void OnEnable()
		{
			StartCoroutine(GameObjectsDistanceCheck(checkPeriodPerGO));
		}

		private void OnDisable()
		{
			StopAllCoroutines();
			foreach (GameObject optimizingGameObject in optimizingGameObjects)
			{
				optimizingGameObject.SetActive(value: true);
			}
		}

		private IEnumerator GameObjectsDistanceCheck(float timeout)
		{
			yield return WaitFor.Seconds(1f);
			while (!SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded)
			{
				yield return null;
			}
			int i = 0;
			while (true)
			{
				yield return WaitFor.Seconds(timeout);
				if (!(PlayerManager.ActiveCamera == null))
				{
					Vector3 position = PlayerManager.ActiveCamera.transform.position;
					GameObject gameObject = optimizingGameObjects[i];
					bool flag = (gameObject.transform.position - position).sqrMagnitude < disableSqrDistance;
					if (gameObject.activeSelf != flag)
					{
						gameObject.SetActive(flag);
					}
					i = (i + 1) % optimizingGameObjects.Count;
				}
			}
		}
	}
}
