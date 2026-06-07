using UnityEngine;

public class LaserEmitter : LaserRayBase
{
	[SerializeField]
	private LineComponent[] lineComponents;

	protected override void Awake()
	{
		base.Awake();
		for (int i = 0; i < lineComponents.Length; i++)
		{
			lineComponents[i].Initialize(lineComponents[i].transform);
		}
	}

	protected override void LaserHitHandler(RaycastHit objectRaycastHit, GameObject objectHit)
	{
		base.LaserHitHandler(objectRaycastHit, objectHit);
		CreateNextLaserSegment(objectRaycastHit, objectHit, worldLaserDirection, 0);
	}

	protected override void LaserNotHitHandler()
	{
		base.LaserNotHitHandler();
		for (int i = 0; i < lineComponents.Length; i++)
		{
			if (lineComponents[i].gameObject.activeSelf)
			{
				lineComponents[i].gameObject.SetActive(value: false);
			}
		}
	}

	private void CreateNextLaserSegment(RaycastHit objectRaycastHit, GameObject objectHit, Vector3 lastLaserDirection, int segmentIndex)
	{
		CheckLaserButton(objectHit);
		if (objectHit.CompareTag("MirrorZone"))
		{
			if (!lineComponents[segmentIndex].gameObject.activeSelf)
			{
				lineComponents[segmentIndex].gameObject.SetActive(value: true);
			}
			_ = objectRaycastHit.distance;
			Vector3 point = objectRaycastHit.point;
			Vector3 vector = Vector3.Reflect(lastLaserDirection, objectRaycastHit.normal);
			Vector3 endPosition = point + vector * laserLength;
			if (Physics.Raycast(new Ray(point, vector), out var hitInfo, laserLength, LayerNames.BlockMask | LayerNames.LevelMask))
			{
				endPosition = hitInfo.point - vector * 0.01f;
				if (segmentIndex + 1 < lineComponents.Length)
				{
					CreateNextLaserSegment(hitInfo, hitInfo.collider.gameObject, vector, segmentIndex + 1);
				}
				else
				{
					CheckLaserButton(hitInfo.collider.gameObject);
				}
			}
			else if (segmentIndex + 1 < lineComponents.Length)
			{
				for (int i = segmentIndex + 1; i < lineComponents.Length; i++)
				{
					if (lineComponents[i].gameObject.activeSelf)
					{
						lineComponents[i].gameObject.SetActive(value: false);
					}
				}
			}
			lineComponents[segmentIndex].SetPositions(point, endPosition);
			return;
		}
		for (int j = segmentIndex; j < lineComponents.Length; j++)
		{
			if (lineComponents[j].gameObject.activeSelf)
			{
				lineComponents[j].gameObject.SetActive(value: false);
			}
		}
	}

	private void CheckLaserButton(GameObject objectHit)
	{
		if (!base.IsOnReplay && objectHit.CompareTag("LaserTriggerZone"))
		{
			LaserButton component = objectHit.transform.parent.GetComponent<LaserButton>();
			if (component != null)
			{
				component.SetOn();
			}
		}
	}
}
