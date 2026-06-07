using UnityEngine;

public class FurnitureBoundDrawer : MonoBehaviour
{
	public Material mat;

	public Color Build1;

	public Color Build2;

	public Color Nav1;

	public Color Nav2;

	public Color Snap;

	public Color Use;

	public BoxCollider Collider;

	public SnapPoint SnapPoint;

	public bool Boundaries = true;

	public bool Snaps;

	public bool Interaction;

	private Vector3[] _pointCache = new Vector3[8];

	private void OnPostRender()
	{
		FurnitureModdingTool instance = FurnitureModdingTool.Instance;
		GameObject gameObject = (((object)instance != null) ? instance.ActiveObject : null);
		if (!(gameObject != null))
		{
			return;
		}
		Furniture component = gameObject.GetComponent<Furniture>();
		RoomSegment component2 = gameObject.GetComponent<RoomSegment>();
		Vector3 pos = base.transform.position;
		bool began = false;
		BoundaryPointEditor boundaryEditor = FurnitureModdingTool.Instance.BoundaryEditor;
		if (boundaryEditor.Active)
		{
			ActiveFurnDebug.BeginDraw(ref began, mat);
			ActiveFurnDebug.DrawBounds(boundaryEditor.CurrentPoints, 0f, Build1, Build2, pos);
		}
		else if (component != null)
		{
			if (Boundaries)
			{
				Matrix4x4 localToWorldMatrix = component.transform.localToWorldMatrix;
				if (component.BuildBoundary != null && component.BuildBoundary.Length > 1)
				{
					ActiveFurnDebug.BeginDraw(ref began, mat);
					ActiveFurnDebug.DrawBounds(component.BuildBoundary, component.transform.position.y + component.Height1, component.transform.position.y + component.Height2, Build1, Build2, pos, localToWorldMatrix);
				}
				if (component.NavBoundary != null && component.NavBoundary.Length != 0)
				{
					ActiveFurnDebug.BeginDraw(ref began, mat);
					ActiveFurnDebug.DrawBounds(component.NavBoundary, component.transform.position.y - 0.1f, component.transform.position.y - 0.05f, Nav1, Nav2, pos, localToWorldMatrix);
				}
			}
			if (FurnitureModdingTool.Instance.ActiveMeta is FurnCompMeta && component.SurfaceSnapRadius > 0f)
			{
				ActiveFurnDebug.BeginDraw(ref began, mat);
				Utilities.DrawCylinder(component.transform.position + Vector3.up * component.Height1, component.Height2 - component.Height1, component.SurfaceSnapRadius, delegate(Vector3 x, Vector3 y)
				{
					ActiveFurnDebug.DrawLine(x, y, Snap, pos);
				});
			}
			if (Snaps)
			{
				for (int num = 0; num < component.SnapPoints.Length; num++)
				{
					ActiveFurnDebug.BeginDraw(ref began, mat);
					SnapPoint snapPoint = component.SnapPoints[num];
					ActiveFurnDebug.DrawLine(snapPoint.transform.position, snapPoint.transform.position + snapPoint.transform.up.normalized * 0.2f, Snap, pos);
					ActiveFurnDebug.DrawLine(snapPoint.transform.position - snapPoint.transform.right.normalized * 0.1f, snapPoint.transform.position + snapPoint.transform.right.normalized * 0.1f, Snap, pos);
					ActiveFurnDebug.DrawLine(snapPoint.transform.position, snapPoint.transform.position + snapPoint.transform.forward.normalized * 0.3f, Snap, pos);
				}
			}
			if (Interaction)
			{
				for (int num2 = 0; num2 < component.InteractionPoints.Length; num2++)
				{
					ActiveFurnDebug.BeginDraw(ref began, mat);
					InteractionPoint interactionPoint = component.InteractionPoints[num2];
					Vector3 vector = interactionPoint.transform.position.ReplaceY(0f);
					ActiveFurnDebug.DrawLine(vector, vector + interactionPoint.transform.up.normalized * 0.2f, Use, pos);
					ActiveFurnDebug.DrawLine(vector - interactionPoint.transform.right.normalized * 0.1f, vector + interactionPoint.transform.right.normalized * 0.1f, Use, pos);
					ActiveFurnDebug.DrawLine(vector, vector + interactionPoint.transform.forward.normalized * 0.3f, Use, pos);
				}
			}
			if (SnapPoint != null && SnapPoint.Surface != null && SnapPoint.Surface.Length != 0)
			{
				ActiveFurnDebug.BeginDraw(ref began, mat);
				Vector3 p = SnapPoint.transform.localToWorldMatrix.MultiplyPoint(SnapPoint.Surface[SnapPoint.Surface.Length - 1].ToVector3(0f));
				for (int num3 = 0; num3 < SnapPoint.Surface.Length; num3++)
				{
					Vector3 vector2 = SnapPoint.transform.localToWorldMatrix.MultiplyPoint(SnapPoint.Surface[num3].ToVector3(0f));
					ActiveFurnDebug.DrawLine(p, vector2, Snap, pos);
					p = vector2;
				}
			}
		}
		else if (component2 != null && Boundaries)
		{
			ActiveFurnDebug.BeginDraw(ref began, mat);
			ActiveFurnDebug.DrawBounds(new Vector2[4]
			{
				new Vector2(component2.WallWidth / 2f, Room.WallOffset / 2f),
				new Vector2((0f - component2.WallWidth) / 2f, Room.WallOffset / 2f),
				new Vector2((0f - component2.WallWidth) / 2f, (0f - Room.WallOffset) / 2f),
				new Vector2(component2.WallWidth / 2f, (0f - Room.WallOffset) / 2f)
			}, component2.Height1, component2.Height2, Build1, Build2, pos, Matrix4x4.identity);
		}
		if (Collider != null)
		{
			ActiveFurnDebug.BeginDraw(ref began, mat);
			Matrix4x4 localToWorldMatrix2 = Collider.transform.localToWorldMatrix;
			Vector3 vector3 = Collider.center + Collider.size * 0.5f;
			Vector3 vector4 = Collider.center - Collider.size * 0.5f;
			_pointCache[0] = vector3;
			_pointCache[1] = vector4;
			_pointCache[2] = new Vector3(vector4.x, vector3.y, vector4.z);
			_pointCache[3] = new Vector3(vector3.x, vector3.y, vector4.z);
			_pointCache[4] = new Vector3(vector3.x, vector4.y, vector4.z);
			_pointCache[5] = new Vector3(vector3.x, vector4.y, vector3.z);
			_pointCache[6] = new Vector3(vector4.x, vector4.y, vector3.z);
			_pointCache[7] = new Vector3(vector4.x, vector3.y, vector3.z);
			for (int num4 = 0; num4 < _pointCache.Length; num4++)
			{
				_pointCache[num4] = localToWorldMatrix2.MultiplyPoint(_pointCache[num4]);
			}
			ActiveFurnDebug.DrawLine(_pointCache[1], _pointCache[2], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[2], _pointCache[3], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[3], _pointCache[4], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[4], _pointCache[1], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[0], _pointCache[5], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[5], _pointCache[6], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[6], _pointCache[7], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[7], _pointCache[0], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[2], _pointCache[7], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[3], _pointCache[0], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[4], _pointCache[5], Color.green, pos);
			ActiveFurnDebug.DrawLine(_pointCache[6], _pointCache[1], Color.green, pos);
		}
		if (began)
		{
			GL.End();
		}
	}

	private void DrawFace(Vector3 x1, Vector3 x2, Vector3 x3, Vector3 x4, Matrix4x4 m, Vector3 camPos, Color col)
	{
		x1 = m.MultiplyPoint(x1);
		x2 = m.MultiplyPoint(x2);
		x3 = m.MultiplyPoint(x3);
		x4 = m.MultiplyPoint(x4);
		ActiveFurnDebug.DrawLine(x1, x2, col, camPos);
		ActiveFurnDebug.DrawLine(x2, x3, col, camPos);
		ActiveFurnDebug.DrawLine(x3, x4, col, camPos);
		ActiveFurnDebug.DrawLine(x4, x1, col, camPos);
	}
}
