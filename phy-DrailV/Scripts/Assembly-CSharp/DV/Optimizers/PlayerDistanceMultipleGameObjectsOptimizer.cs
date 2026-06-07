using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Optimizers
{
	public class PlayerDistanceMultipleGameObjectsOptimizer : MonoBehaviour
	{
		public GameObject gameObjectToCheckDistance;

		public List<GameObject> gameObjectsToDisable;

		public List<MonoBehaviour> scriptsToDisable;

		public float disableSqrDistance = 250000f;

		public float checkPeriod = 2f;

		private bool gameObjectsAndScriptsDisabled;

		private Transform referenceTransform;

		private void Awake()
		{
			if (gameObjectToCheckDistance == null || gameObjectsToDisable == null || scriptsToDisable == null || (gameObjectsToDisable.Count == 0 && scriptsToDisable.Count == 0))
			{
				Debug.LogError("gameObjectsToDisable / scriptsToDisable or gameObjectToCheckDistance weren't set, destroying PlayerDistanceMultipleGameObjectsOptimizer!", this);
				Object.Destroy(this);
			}
			else
			{
				gameObjectsAndScriptsDisabled = false;
				referenceTransform = gameObjectToCheckDistance.transform;
			}
		}

		private void OnEnable()
		{
			StartCoroutine(GameObjectDistanceCheck(checkPeriod));
			PlayerManager.PlayerTeleportFinished += OnPlayerTeleport;
		}

		private void OnDisable()
		{
			PlayerManager.PlayerTeleportFinished -= OnPlayerTeleport;
			StopAllCoroutines();
			foreach (GameObject item in gameObjectsToDisable)
			{
				item.SetActive(value: true);
			}
			foreach (MonoBehaviour item2 in scriptsToDisable)
			{
				item2.enabled = true;
			}
			gameObjectsAndScriptsDisabled = false;
		}

		private void OnPlayerTeleport()
		{
			StartCoroutine(CheckDistanceLater());
			IEnumerator CheckDistanceLater()
			{
				yield return null;
				CheckDistance();
			}
		}

		private IEnumerator GameObjectDistanceCheck(float timeout)
		{
			while (!WorldStreamingInit.IsLoaded)
			{
				yield return null;
			}
			yield return WaitFor.Seconds(1f);
			while (true)
			{
				yield return WaitFor.Seconds(timeout);
				CheckDistance();
			}
		}

		private void CheckDistance()
		{
			Vector3 position = PlayerManager.ActiveCamera.transform.position;
			float sqrMagnitude = (referenceTransform.position - position).sqrMagnitude;
			if (!gameObjectsAndScriptsDisabled && sqrMagnitude > disableSqrDistance)
			{
				foreach (GameObject item in gameObjectsToDisable)
				{
					item.SetActive(value: false);
				}
				foreach (MonoBehaviour item2 in scriptsToDisable)
				{
					item2.enabled = false;
				}
				gameObjectsAndScriptsDisabled = true;
			}
			else
			{
				if (!gameObjectsAndScriptsDisabled || !(sqrMagnitude <= disableSqrDistance))
				{
					return;
				}
				foreach (GameObject item3 in gameObjectsToDisable)
				{
					item3.SetActive(value: true);
				}
				foreach (MonoBehaviour item4 in scriptsToDisable)
				{
					item4.enabled = true;
				}
				gameObjectsAndScriptsDisabled = false;
			}
		}
	}
}
