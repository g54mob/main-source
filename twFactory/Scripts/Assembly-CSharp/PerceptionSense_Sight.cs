using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionSense_Sight : PerceptionSense
{
	private static float CHECK_SIGHT_TICK = 0.25f;

	private SphereCollider sightCollider;

	private List<GameObject> detectedObjects;

	private List<GameObject> nearbyObjects;

	private Coroutine checkSightCoroutine;

	private void Awake()
	{
		detectedObjects = new List<GameObject>();
		nearbyObjects = new List<GameObject>();
	}

	public override void InitSense(PerceptionAI perceptionAI)
	{
		base.InitSense(perceptionAI);
		sightCollider = base.gameObject.AddComponent<SphereCollider>();
		sightCollider.radius = perceptionAI.SightRadius;
		sightCollider.isTrigger = true;
	}

	private IEnumerator CheckSightCoroutine()
	{
		while (true)
		{
			for (int num = detectedObjects.Count - 1; num >= 0; num--)
			{
				if (!IsOnSight(detectedObjects[num]))
				{
					nearbyObjects.AddUnique(detectedObjects[num]);
					RemoveDetectedObject(detectedObjects[num]);
				}
			}
			for (int num2 = nearbyObjects.Count - 1; num2 >= 0; num2--)
			{
				if (IsOnSight(nearbyObjects[num2]))
				{
					AddDetectedObject(nearbyObjects[num2]);
				}
			}
			yield return new WaitForSeconds(CHECK_SIGHT_TICK);
		}
	}

	private void AddDetectedObject(GameObject go)
	{
		nearbyObjects.Remove(go);
		if (detectedObjects.AddUnique(go))
		{
			CallOnEnterSense(go);
		}
	}

	private void RemoveDetectedObject(GameObject go)
	{
		if (detectedObjects.Remove(go))
		{
			CallOnExitSense(go);
		}
	}

	private bool IsOnSight(GameObject go)
	{
		if (!IsInsideSightAngle(go))
		{
			return false;
		}
		Vector3 start = base.transform.position + Vector3.up * perceptionAI.SightHeight;
		Vector3 gameObjectSightCheckPoint = GetGameObjectSightCheckPoint(go);
		RaycastHit hitInfo;
		return !Physics.Linecast(start, gameObjectSightCheckPoint, out hitInfo, perceptionAI.SightBlockingLayers);
	}

	private bool IsInsideSightAngle(GameObject go)
	{
		Vector3 to = go.transform.position - base.transform.position;
		to.Scale(new Vector3(1f, 0f, 1f));
		return Vector3.Angle(base.transform.forward, to) <= perceptionAI.SightAngle * 0.5f;
	}

	private Vector3 GetGameObjectSightCheckPoint(GameObject go)
	{
		return go.transform.position + Vector3.up * FunctionLibrary.GetObjectHeight(go) * 0.75f;
	}

	private bool ShouldDetectGameObject(GameObject go)
	{
		Character component = go.GetComponent<Character>();
		if (!component)
		{
			return false;
		}
		TeamComponent component2 = component.GetComponent<TeamComponent>();
		TeamComponent component3 = perceptionAI.Controller.ControlledCharacter.GetComponent<TeamComponent>();
		if ((bool)component2 && (bool)component3 && (!perceptionAI.DetectAllies || !component2.IsAlly(component3)))
		{
			if (perceptionAI.DetectEnemies)
			{
				return component2.IsEnemy(component3);
			}
			return false;
		}
		return true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (ShouldDetectGameObject(other.gameObject))
		{
			if (IsOnSight(other.gameObject))
			{
				AddDetectedObject(other.gameObject);
			}
			else
			{
				nearbyObjects.AddUnique(other.gameObject);
			}
			this.StartCoroutineCheckingVar(CheckSightCoroutine(), ref checkSightCoroutine);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		RemoveDetectedObject(other.gameObject);
		nearbyObjects.Remove(other.gameObject);
		if (nearbyObjects.Count == 0 && detectedObjects.Count == 0)
		{
			this.StopCoroutineCheckingVar(ref checkSightCoroutine);
		}
	}

	private void OnDrawGizmos()
	{
		List<GameObject> list = new List<GameObject>(nearbyObjects);
		list.AddRange(detectedObjects);
		foreach (GameObject item in list)
		{
			if (!IsInsideSightAngle(item))
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(GetGameObjectSightCheckPoint(item), 0.5f);
				continue;
			}
			Vector3 vector = base.transform.position + Vector3.up * perceptionAI.SightHeight;
			Vector3 gameObjectSightCheckPoint = GetGameObjectSightCheckPoint(item);
			RaycastHit hitInfo;
			bool num = Physics.Linecast(vector, gameObjectSightCheckPoint, out hitInfo, perceptionAI.SightBlockingLayers);
			Vector3 vector2 = (num ? hitInfo.point : gameObjectSightCheckPoint);
			Gizmos.color = (num ? Color.red : Color.green);
			Gizmos.DrawWireSphere(vector2, 0.5f);
			Gizmos.DrawLine(vector, vector2);
		}
	}
}
