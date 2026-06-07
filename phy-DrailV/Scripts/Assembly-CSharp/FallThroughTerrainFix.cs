using System.Collections;
using System.Linq;
using DV.OriginShift;
using UnityEngine;

[DisallowMultipleComponent]
public class FallThroughTerrainFix : MonoBehaviour
{
	private const float RAYCAST_DISTANCE = 5f;

	private const float CHECK_INTERVAL = 0.5f;

	private const float UNDER_MAP_LEVEL = -10f;

	private bool forceMove;

	private static Vector3 lastGoodPosition = Vector3.positiveInfinity;

	private Coroutine checkCoro;

	private int terrainLayerMask;

	private void OnEnable()
	{
		if (checkCoro != null)
		{
			StopCoroutine(checkCoro);
		}
		checkCoro = StartCoroutine(CheckPlayerPosition());
		terrainLayerMask = LayerMask.GetMask("Terrain");
	}

	private void OnDisable()
	{
		if (checkCoro != null)
		{
			StopCoroutine(checkCoro);
		}
		checkCoro = null;
		if (UnloadWatcher.isUnloading)
		{
			lastGoodPosition = Vector3.positiveInfinity;
		}
	}

	public void MoveToLastGoodPosition()
	{
		forceMove = true;
	}

	private IEnumerator CheckPlayerPosition()
	{
		WaitForSeconds wait = WaitFor.Seconds(0.5f);
		while (true)
		{
			yield return wait;
			RaycastHit hitInfo;
			if (forceMove || base.transform.position.y < -10f)
			{
				forceMove = false;
				ScreenFade.Fade(Color.black, 0f);
				base.transform.SetAbsolutePosition(GetGoodPosition());
				base.transform.rotation = Quaternion.identity;
				Rigidbody component = base.transform.GetComponent<Rigidbody>();
				if ((bool)component)
				{
					component.velocity = Vector3.zero;
					component.angularVelocity = Vector3.zero;
				}
				yield return WaitFor.Seconds(0.2f);
				ScreenFade.Fade(Color.clear, 1f);
			}
			else if (Physics.Raycast(new Ray(base.transform.position + Vector3.up, Vector3.down), out hitInfo, 5f, terrainLayerMask, QueryTriggerInteraction.Ignore) && hitInfo.point.y < base.transform.position.y)
			{
				lastGoodPosition = base.transform.AbsolutePosition();
			}
		}
	}

	private Vector3 GetGoodPosition()
	{
		if (float.IsPositiveInfinity(lastGoodPosition.x))
		{
			Debug.Log("lastGoodPosition is uninitialized, finding closest terrain");
			Terrain terrain = (from t in Object.FindObjectsOfType<Terrain>()
				orderby Vector3.SqrMagnitude(base.transform.position - t.transform.position)
				select t).FirstOrDefault();
			if ((bool)terrain)
			{
				Vector3 vector = terrain.terrainData.size / 2f;
				Vector3 origin = terrain.transform.position + new Vector3(vector.x, 2000f, vector.z);
				if (Physics.Raycast(new Ray(origin, Vector3.down), out var hitInfo, 3000f, terrainLayerMask, QueryTriggerInteraction.Ignore))
				{
					lastGoodPosition = hitInfo.point - WorldMover.currentMove + Vector3.up * 0.3f;
				}
			}
			else
			{
				Vector3 vector2 = new Vector3(1f, 1000f, 1f);
				Debug.Log($"couldn't find closest terrain, moving player to {vector2}");
				lastGoodPosition = vector2;
			}
		}
		return lastGoodPosition;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(lastGoodPosition + WorldMover.currentMove, 1.5f);
	}
}
