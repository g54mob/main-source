using System;
using UnityEngine;

public class WalkwayPhysical : MonoBehaviour
{
	public enum Kind
	{
		Dynamic = 0,
		Kinematic = 1,
		KinematicPusher = 2
	}

	public WalkwayFloor.Hit latestFloorHit;

	[WalkwayBuilt]
	public string cacheId;

	[WalkwayBuilt]
	[SerializeField]
	private Kind kind;

	[WalkwayBuilt]
	[SerializeField]
	private Rigidbody2D rigid;

	[WalkwayBuilt]
	[SerializeField]
	private WalkwayPusher pusher;

	[WalkwayBuilt]
	[SerializeField]
	private WalkwaySet walkwaySet;

	[WalkwayBuilt]
	[SerializeField]
	private Walkway walkway_;

	private Transform slaveTransform;

	private Vector3 slaveOffset;

	private bool haveAppliedToSlave_;

	public static bool drawInGame = true;

	public Walkway walkway
	{
		get
		{
			return walkway_;
		}
		set
		{
			Vector2 vector = pos;
			walkway_ = value;
			pos = vector;
		}
	}

	public Vector2 pos
	{
		get
		{
			return rigid.position - walkwayOffset;
		}
		private set
		{
			Vector2 vector = value + walkwayOffset;
			base.transform.position = vector.ToVector3XY(0f);
			rigid.position = vector;
		}
	}

	private Vector2 walkwayOffset
	{
		get
		{
			return (!(walkway_ != null)) ? Vector2.zero : walkway_.offset;
		}
	}

	public bool haveAppliedToSlave
	{
		get
		{
			return haveAppliedToSlave_;
		}
	}

	public bool noclip
	{
		get
		{
			Collider2D[] components = GetComponents<Collider2D>();
			int num = 0;
			if (num < components.Length)
			{
				Collider2D collider2D = components[num];
				return !collider2D.enabled;
			}
			return false;
		}
		set
		{
			Collider2D[] components = GetComponents<Collider2D>();
			foreach (Collider2D collider2D in components)
			{
				collider2D.enabled = !value;
			}
		}
	}

	public Kind GetKind()
	{
		return kind;
	}

	public static WalkwayPhysical Create(WalkwaySet walkwaySet, string name, Kind kind, WalkwayPusher pusher_ = null)
	{
		GameObject gameObject = new GameObject();
		gameObject.name = name;
		gameObject.layer = LayerMask.NameToLayer("Walkway");
		WalkwayPhysical walkwayPhysical = gameObject.AddComponent<WalkwayPhysical>();
		walkwayPhysical.kind = kind;
		walkwayPhysical.walkwaySet = walkwaySet;
		walkwayPhysical.rigid = gameObject.AddComponent<Rigidbody2D>();
		walkwayPhysical.rigid.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		walkwayPhysical.rigid.gravityScale = 0f;
		walkwayPhysical.rigid.isKinematic = kind == Kind.Kinematic || kind == Kind.KinematicPusher;
		walkwayPhysical.rigid.freezeRotation = kind == Kind.Dynamic;
		walkwayPhysical.pusher = pusher_;
		return walkwayPhysical;
	}

	public void AddCircle(Vector2 offset, float radius)
	{
		CircleCollider2D circleCollider2D = base.gameObject.AddComponent<CircleCollider2D>();
		circleCollider2D.offset = offset;
		circleCollider2D.radius = radius;
	}

	public void AddBox(Vector2 offset, Vector2 size)
	{
		BoxCollider2D boxCollider2D = base.gameObject.AddComponent<BoxCollider2D>();
		boxCollider2D.offset = offset;
		boxCollider2D.size = size;
	}

	public void AddPolygon(Vector2[] points)
	{
		PolygonCollider2D polygonCollider2D = base.gameObject.AddComponent<PolygonCollider2D>();
		polygonCollider2D.points = points;
	}

	public void AddEdges(Vector2[] points)
	{
		EdgeCollider2D edgeCollider2D = base.gameObject.AddComponent<EdgeCollider2D>();
		edgeCollider2D.points = points;
	}

	public void CopyCollidersFrom(WalkwayPhysical src)
	{
		CircleCollider2D[] components = GetComponents<CircleCollider2D>();
		foreach (CircleCollider2D obj in components)
		{
			UnityEngine.Object.DestroyImmediate(obj);
		}
		CircleCollider2D[] components2 = src.GetComponents<CircleCollider2D>();
		foreach (CircleCollider2D circleCollider2D in components2)
		{
			AddCircle(circleCollider2D.offset, circleCollider2D.radius);
		}
		BoxCollider2D[] components3 = GetComponents<BoxCollider2D>();
		foreach (BoxCollider2D obj2 in components3)
		{
			UnityEngine.Object.DestroyImmediate(obj2);
		}
		BoxCollider2D[] components4 = src.GetComponents<BoxCollider2D>();
		foreach (BoxCollider2D boxCollider2D in components4)
		{
			AddBox(boxCollider2D.offset, boxCollider2D.size);
		}
		PolygonCollider2D[] components5 = GetComponents<PolygonCollider2D>();
		foreach (PolygonCollider2D obj3 in components5)
		{
			UnityEngine.Object.DestroyImmediate(obj3);
		}
		PolygonCollider2D[] components6 = src.GetComponents<PolygonCollider2D>();
		foreach (PolygonCollider2D polygonCollider2D in components6)
		{
			AddPolygon(polygonCollider2D.points);
		}
		EdgeCollider2D[] components7 = GetComponents<EdgeCollider2D>();
		foreach (EdgeCollider2D obj4 in components7)
		{
			UnityEngine.Object.DestroyImmediate(obj4);
		}
		EdgeCollider2D[] components8 = src.GetComponents<EdgeCollider2D>();
		foreach (EdgeCollider2D edgeCollider2D in components8)
		{
			AddEdges(edgeCollider2D.points);
		}
	}

	public void MoveTo(Vector2 pos2D)
	{
		rigid.MovePosition(pos2D + walkwayOffset);
		rigid.velocity = Vector2.zero;
	}

	public void MoveTo(Vector2 pos2D, float rotation)
	{
		rigid.MovePosition(pos2D + walkwayOffset);
		rigid.velocity = Vector2.zero;
		rigid.MoveRotation(180f - rotation);
	}

	public void WarpTo(Vector3 footPos3D)
	{
		Walkway.Sample bestSample = walkwaySet.GetBestSample(footPos3D);
		if (bestSample.valid)
		{
			walkway_ = bestSample.walkway;
		}
		if ((bool)walkway_)
		{
			walkway_.enabled = true;
		}
		pos = footPos3D.ToVector2XZ();
	}

	public void WarpTo(Vector3 footPos3D, float rotation)
	{
		Walkway.Sample bestSample = walkwaySet.GetBestSample(footPos3D);
		if (bestSample.valid)
		{
			walkway_ = bestSample.walkway;
		}
		pos = footPos3D.ToVector2XZ();
		rigid.rotation = 180f - rotation;
		base.transform.rotation = Quaternion.Euler(0f, 0f, rigid.rotation);
	}

	public void SetSlave(Transform slaveTransform_, Vector3 slaveOffset_)
	{
		slaveTransform = slaveTransform_;
		slaveOffset = slaveOffset_;
	}

	private void Update()
	{
		if (pusher != null && !pusher.isActiveAndEnabled)
		{
			base.gameObject.SetActive(false);
		}
		else if (Walkway.showDebugInGame)
		{
			DebugLiner.CallAndFlush(DrawDebug, false);
		}
	}

	private void LateUpdate()
	{
		if (slaveTransform == null)
		{
			return;
		}
		if (walkway != null)
		{
			latestFloorHit = walkway.GetSample(pos).ToWalkwayFloorHit();
		}
		else
		{
			Walkway.Sample bestSample = walkwaySet.GetBestSample(pos.ToVector3XZ(0f));
			if (bestSample.valid)
			{
				walkway = bestSample.walkway;
				latestFloorHit = walkway.GetSample(pos).ToWalkwayFloorHit();
			}
		}
		if (walkway != null)
		{
			Walkway portalDestination = walkway.GetPortalDestination(pos);
			if (portalDestination != null)
			{
				walkway.enabled = false;
				walkway = portalDestination;
				portalDestination.enabled = true;
				latestFloorHit = walkway.GetSample(pos).ToWalkwayFloorHit();
			}
		}
		slaveTransform.position = pos.ToVector3XZ(latestFloorHit.worldY) + slaveOffset;
		haveAppliedToSlave_ = true;
	}

	private void FixedUpdate()
	{
		if (slaveTransform != null)
		{
			rigid.velocity = 0.5f * rigid.velocity;
		}
	}

	public void DrawDebug(DebugLiner liner)
	{
		liner.matrix = Matrix4x4.TRS(pos.ToVector3XZ(0f), Quaternion.Euler(0f, 0f - rigid.rotation, 0f), Vector3.one);
		if (walkway != null)
		{
			liner.matrix = walkway.debugBaseMatrix * liner.matrix;
		}
		if (kind == Kind.Dynamic)
		{
			liner.color = Color.green;
		}
		else if (kind == Kind.Kinematic)
		{
			liner.color = Color.red;
		}
		else if (kind == Kind.KinematicPusher)
		{
			liner.color = new Color(1f, 0f, 1f);
		}
		PolygonCollider2D[] components = base.gameObject.GetComponents<PolygonCollider2D>();
		foreach (PolygonCollider2D polygonCollider2D in components)
		{
			for (int j = 0; j < polygonCollider2D.pathCount; j++)
			{
				Vector2[] path = polygonCollider2D.GetPath(j);
				for (int k = 0; k < path.Length; k++)
				{
					Vector2 v = path[k];
					Vector2 v2 = path[(k + 1) % path.Length];
					liner.DrawLine(v.ToVector3XZ(0f), v2.ToVector3XZ(0f));
				}
			}
		}
		Color color = liner.color;
		liner.color = new Color(color.r, color.g + 0.5f, color.b, color.a);
		EdgeCollider2D[] components2 = base.gameObject.GetComponents<EdgeCollider2D>();
		foreach (EdgeCollider2D edgeCollider2D in components2)
		{
			Vector2[] points = edgeCollider2D.points;
			for (int m = 0; m < points.Length - 1; m++)
			{
				Vector2 v3 = points[m];
				Vector2 v4 = points[m + 1];
				liner.DrawLine(v3.ToVector3XZ(0f), v4.ToVector3XZ(0f), 0.25f);
			}
		}
		liner.color = color;
		CircleCollider2D[] components3 = base.gameObject.GetComponents<CircleCollider2D>();
		foreach (CircleCollider2D circleCollider2D in components3)
		{
			Vector3 vector = circleCollider2D.offset.ToVector3XZ(0f);
			for (int num = 0; num < 20; num++)
			{
				float f = (float)Math.PI * 2f * (float)num / 20f;
				float f2 = (float)Math.PI * 2f * (float)(num + 1) / 20f;
				Vector3 a = vector + circleCollider2D.radius * new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f));
				Vector3 b = vector + circleCollider2D.radius * new Vector3(Mathf.Cos(f2), 0f, Mathf.Sin(f2));
				liner.DrawLine(a, b);
			}
		}
		BoxCollider2D[] components4 = base.gameObject.GetComponents<BoxCollider2D>();
		foreach (BoxCollider2D boxCollider2D in components4)
		{
			Bounds bounds = boxCollider2D.bounds;
			bounds.center -= walkwayOffset.ToVector3XY(0f);
			Vector3 vector2 = new Vector3(bounds.min.x, 0f, bounds.min.y);
			Vector3 vector3 = new Vector3(bounds.max.x, 0f, bounds.min.y);
			Vector3 vector4 = new Vector3(bounds.max.x, 0f, bounds.max.y);
			Vector3 vector5 = new Vector3(bounds.min.x, 0f, bounds.max.y);
			liner.DrawLine(vector2, vector3);
			liner.DrawLine(vector3, vector4);
			liner.DrawLine(vector4, vector5);
			liner.DrawLine(vector5, vector2);
		}
	}
}
