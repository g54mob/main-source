using UnityEngine;

public abstract class LaserRayBase : DynamicObjectBase
{
	[SerializeField]
	private Vector3 laserPosition;

	[SerializeField]
	private Vector3 laserDirection;

	[SerializeField]
	protected float laserLength = 25f;

	protected Vector3 worldLaserPosition;

	protected Vector3 worldLaserDirection;

	protected Vector3 worldLaserEndPosition;

	private RaycastHit objectRaycastHit;

	private GameObject objectHit;

	private bool wasObjectHit;

	private LineComponent lineComponent;

	private GameObject endLinePointObject;

	public bool IsOnReplay { get; set; }

	protected override void Awake()
	{
		base.Awake();
		lineComponent = GetComponent<LineComponent>();
		lineComponent.Initialize(base.transform);
		endLinePointObject = base.transform.FindChildRecursively("EndLinePoint").gameObject;
		wasObjectHit = false;
		IsOnReplay = false;
	}

	protected override void AddReplayComponents()
	{
		base.AddReplayComponents();
		base.gameObject.AddComponent<LaserEmitterReplay>();
	}

	public override void Recycle()
	{
		base.Recycle();
		IsOnReplay = false;
	}

	protected virtual void FixedUpdate()
	{
		if (wasObjectHit)
		{
			LaserHitHandlerFixedUpdate(objectRaycastHit, objectHit);
		}
		else
		{
			LaserNotHitHandlerFixedUpdate();
		}
	}

	protected virtual void Update()
	{
		worldLaserPosition = base.transform.TransformPoint(laserPosition);
		worldLaserDirection = base.transform.TransformDirection(laserDirection);
		worldLaserEndPosition = worldLaserPosition + worldLaserDirection * laserLength;
		if (Physics.Raycast(new Ray(worldLaserPosition, worldLaserDirection), out objectRaycastHit, laserLength, LayerNames.BlockMask | LayerNames.LevelMask))
		{
			if (!endLinePointObject.activeSelf)
			{
				endLinePointObject.SetActive(value: true);
			}
			objectHit = objectRaycastHit.collider.gameObject;
			worldLaserEndPosition = objectRaycastHit.point - worldLaserDirection * 0.01f;
			wasObjectHit = true;
			LaserHitHandler(objectRaycastHit, objectHit);
		}
		else
		{
			if (endLinePointObject.activeSelf)
			{
				endLinePointObject.SetActive(value: false);
			}
			wasObjectHit = false;
			LaserNotHitHandler();
		}
		lineComponent.SetPositions(worldLaserPosition, worldLaserEndPosition);
	}

	protected virtual void LaserHitHandler(RaycastHit objectRaycastHit, GameObject objectHit)
	{
	}

	protected virtual void LaserNotHitHandler()
	{
	}

	protected virtual void LaserHitHandlerFixedUpdate(RaycastHit objectRaycastHit, GameObject objectHit)
	{
	}

	protected virtual void LaserNotHitHandlerFixedUpdate()
	{
	}

	private void OnDrawGizmos()
	{
		Vector3 vector = base.transform.TransformPoint(laserPosition);
		Vector3 vector2 = base.transform.TransformDirection(laserDirection);
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(vector, vector2 * laserLength);
	}
}
