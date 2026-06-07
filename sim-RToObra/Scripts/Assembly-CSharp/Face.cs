using UnityEngine;

public class Face : MonoBehaviour
{
	public class Score
	{
		public Face face;

		public float dist = float.MaxValue;

		public float facingAngle = float.MaxValue;

		public float offcenter = float.MaxValue;

		public bool valid
		{
			get
			{
				return face != null;
			}
		}

		public bool IsBetterThan(Score other)
		{
			if (!valid)
			{
				return false;
			}
			if (!other.valid)
			{
				return true;
			}
			if (Mathf.Abs(facingAngle - other.facingAngle) < 90f && Mathf.Abs(dist - other.dist) < 0.75f)
			{
				return offcenter < other.offcenter;
			}
			if (Mathf.Abs(offcenter - other.offcenter) < 0.2f)
			{
				return dist < other.dist;
			}
			return offcenter < other.offcenter;
		}

		public void Invalidate()
		{
			face = null;
		}

		public void CopyFrom(Score src)
		{
			face = src.face;
			dist = src.dist;
			facingAngle = src.facingAngle;
			offcenter = src.offcenter;
		}
	}

	public enum Cost
	{
		Cheap = 0,
		Expensive = 1
	}

	public string crewId;

	public Vector3 worldOrigin;

	public Vector3 worldForward;

	public GameObject focusGo;

	public bool far;

	private const float kRadius = 0.2f;

	private const float kDist0 = 2f;

	private const float kDist1 = 4f;

	private const float kDistFar1 = 6f;

	private const float kOffcenterUnfocusedAtDist0 = 0.33f;

	private const float kOffcenterUnfocusedAtDist1 = 0.25f;

	private const float kOffcenterFocusedAtDist0 = 0.66f;

	private const float kOffcenterFocusedAtDist1 = 0.5f;

	private static int collideLayerMask;

	private static RaycastHit[] sharedRaycastHits = new RaycastHit[4]
	{
		default(RaycastHit),
		default(RaycastHit),
		default(RaycastHit),
		default(RaycastHit)
	};

	private static bool showDebugInGame;

	public Vector3 helpIrisFocusPos
	{
		get
		{
			Vector3 vector = Player.instance.mainCamera.WorldToViewportPoint(worldOrigin);
			return new Vector3(vector.x, vector.y, 120f);
		}
	}

	private void Awake()
	{
		DebugMenu.Add("Show/Faces", KeyCode.None, delegate
		{
			showDebugInGame = !showDebugInGame;
		});
		if (collideLayerMask == 0)
		{
			collideLayerMask = ~((1 << LayerMask.NameToLayer("BlurMap")) | (1 << LayerMask.NameToLayer("Crew")) | (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("ExitPortal")) | (1 << LayerMask.NameToLayer("Glass")));
		}
	}

	private void Update()
	{
		if (showDebugInGame)
		{
			DebugLiner.CallAndFlush(DrawDebug, false);
		}
	}

	public bool IsOnScreen(Camera camera, bool focused, ref Score score, ref Cost cost)
	{
		cost = Cost.Cheap;
		float magnitude = (camera.transform.position - worldOrigin).magnitude;
		if (magnitude > ((!far) ? 4f : 6f) + 0.2f)
		{
			return false;
		}
		Vector2 a = new Vector2(1.7777778f, 1f);
		Vector3 v = camera.WorldToViewportPoint(worldOrigin);
		if (v.z <= 0f)
		{
			return false;
		}
		float magnitude2 = Vector2.Scale(a, v.ToVector2XY() - 0.5f * Vector2.one).magnitude;
		float num = ((!focused) ? Util.LerpScale(magnitude, 2f, 4f, 0.33f, 0.25f) : Util.LerpScale(magnitude, 2f, 4f, 0.66f, 0.5f));
		if (magnitude2 > num)
		{
			return false;
		}
		Vector3 position = camera.transform.position;
		bool flag = false;
		cost = Cost.Expensive;
		if (CanSee(position, worldOrigin))
		{
			flag = true;
		}
		else
		{
			Vector3 b = worldOrigin + camera.transform.right * 0.2f;
			Vector3 b2 = worldOrigin - camera.transform.right * 0.2f;
			for (int i = 1; i < 4; i++)
			{
				float t = (float)i / 3f;
				Vector3 p = Vector3.Lerp(worldOrigin, b2, t);
				Vector3 p2 = Vector3.Lerp(worldOrigin, b, t);
				if (CanSee(position, p) || CanSee(position, p2))
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			score.face = this;
			score.dist = magnitude;
			score.facingAngle = Vector3.Angle(-camera.transform.forward, worldForward);
			score.offcenter = magnitude2;
			return true;
		}
		return false;
	}

	private bool CanSee(Vector3 p0, Vector3 p1)
	{
		Vector3 vector = p1 - p0;
		float magnitude = vector.magnitude;
		if (magnitude == 0f)
		{
			return true;
		}
		Vector3 direction = vector / magnitude;
		return Physics.RaycastNonAlloc(p0, direction, sharedRaycastHits, Mathf.Min(4f, magnitude), collideLayerMask) == 0;
	}

	public void DrawDebug(DebugLiner liner)
	{
		liner.matrix = Matrix4x4.identity;
		liner.color = new Color(0.9f, 0.1f, 0.7f, 1f);
		liner.DrawSphere(worldOrigin, 0.2f);
		liner.color = new Color(1f, 0.5f, 0f, 1f);
		liner.DrawRay(worldOrigin, worldForward);
	}
}
