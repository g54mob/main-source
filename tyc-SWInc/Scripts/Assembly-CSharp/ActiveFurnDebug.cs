using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveFurnDebug : MonoBehaviour
{
	public static ActiveFurnDebug Instance;

	public Material mat;

	private bool _furnDebug;

	public static bool EnableActorDraw = true;

	public float FurnBoundWidth = 0.01f;

	public Color Build1;

	public Color Build2;

	public Color Nav1;

	public Color Nav2;

	public Color Snap;

	public Color Use;

	public static void Activate(bool en)
	{
		if (Instance != null)
		{
			Instance._furnDebug = en;
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public static void BeginDraw(ref bool began, Material mat)
	{
		if (!began)
		{
			mat.SetPass(0);
			GL.Begin(7);
			began = true;
		}
	}

	private void DrawPathLine(Vector3 a, Vector3 b, float speed, ref bool began)
	{
		float num = (float)GameSettings.Instance.ActiveFloor * 2f;
		float num2 = (float)GameSettings.Instance.ActiveFloor * 2f + 2f;
		float y = a.y;
		float y2 = b.y;
		if (y > y2)
		{
			y = b.y;
			y2 = a.y;
		}
		if (Utilities.Overlap(y, y2, num - 0.1f, num2 - 0.1f))
		{
			BeginDraw(ref began, mat);
			Color col = ((speed < 0f) ? Color.Lerp(Color.red, Color.cyan, speed.MapRange(-0.25f, 0f, 0f, 1f, true)) : Color.Lerp(Color.cyan, Color.green, speed.MapRange(0f, 0.25f, 0f, 1f, true)));
			DrawLine(a.ReplaceY(Mathf.Clamp(a.y, num - 2f, num2)), b.ReplaceY(Mathf.Clamp(b.y, num - 2f, num2)), col, base.transform.position);
		}
	}

	private void DrawPathLine(PathVector a, PathVector b, Vector3? skip, ref bool began)
	{
		if (a.Type == PathVector.PathType.Outside)
		{
			Vector3 vector = (skip.HasValue ? skip.Value : ((Vector3)a));
			float num = a.GetSpeed(vector);
			Vector3 vector2 = b - a;
			float magnitude = vector2.magnitude;
			float num2 = (vector - a).magnitude;
			if (magnitude - num2 > 1f)
			{
				float num3 = 0.25f;
				Vector3 vector3 = vector2 * (1f / magnitude);
				while (num2 < magnitude)
				{
					num2 += num3;
					Vector3 vector4 = a + vector3 * num2;
					float speed = a.GetSpeed(vector4);
					if (speed != num)
					{
						DrawPathLine(vector, vector4, num, ref began);
						vector = vector4;
						num = speed;
					}
				}
			}
			DrawPathLine(vector, b, num, ref began);
		}
		else
		{
			DrawPathLine(skip.HasValue ? skip.Value : ((Vector3)a), b, a.GetSpeed(a), ref began);
		}
	}

	private void OnPostRender()
	{
		if (GameSettings.Instance.IsReferenceNull() || SelectorController.Instance == null)
		{
			return;
		}
		bool began = false;
		Vector3 position = base.transform.position;
		if (GameSettings.Instance.ActiveFireReport != null && "FireInspection".Equals(DataOverlay.Instance.ActiveOverlayName))
		{
			foreach (List<SVector3> escapePath in GameSettings.Instance.ActiveFireReport.EscapePaths)
			{
				for (int i = 0; i < escapePath.Count - 1; i++)
				{
					DrawPathLine(escapePath[i], escapePath[i + 1], -1f, ref began);
				}
			}
		}
		if (EnableActorDraw)
		{
			Actor actor = SelectorController.Instance.Selected.FirstOrDefaultOf<Actor>();
			if (actor.IsAliveNotNull())
			{
				if (actor.CurrentPath != null && actor.CurrentPathNode < actor.CurrentPath.Count - 1)
				{
					DrawPathLine(actor.CurrentPath[actor.CurrentPathNode], actor.CurrentPath[actor.CurrentPathNode + 1], actor.ActualPosition, ref began);
					for (int j = actor.CurrentPathNode + 1; j < actor.CurrentPath.Count - 1; j++)
					{
						DrawPathLine(actor.CurrentPath[j], actor.CurrentPath[j + 1], null, ref began);
					}
				}
				if (actor.Floor == GameSettings.Instance.ActiveFloor && actor.AtFurniture && actor.UsingPoint != null && "Computer".Equals(actor.UsingPoint.Parent.Type))
				{
					float num = 1f - actor.UsingPoint.Parent.GetUseEffect(Furniture.UseEffect.SocialIsolation);
					if (num > 0f)
					{
						foreach (Actor neighbour in actor.GetNeighbours())
						{
							if (neighbour.AtFurniture)
							{
								BeginDraw(ref began, mat);
								float num2 = actor.employee.Compatibility(neighbour.employee) * num;
								DrawLine(actor.HeadBone.position, neighbour.HeadBone.position, new Color(0f, 1f, 0f, num2 / 2f), position, num2.MapRange(0f, 2f, 0.005f, 0.015f, true));
							}
						}
					}
				}
			}
		}
		if (BuildController.Instance.CurrentFurnitureBuilder != null)
		{
			FurnitureBuilder currentFurnitureBuilder = BuildController.Instance.CurrentFurnitureBuilder;
			Furniture furniture = ((currentFurnitureBuilder.FurnPrefab != null) ? currentFurnitureBuilder.FurnPrefab.GetComponent<Furniture>() : null);
			if (furniture.IsAliveNotNull() && furniture.ShowBuildBoundaryOutline)
			{
				BeginDraw(ref began, mat);
				Matrix4x4 localToWorldMatrix = currentFurnitureBuilder.transform.localToWorldMatrix;
				Vector3 p = localToWorldMatrix.MultiplyPoint(furniture.BuildBoundary.Last().ToVector3(0f));
				for (int k = 0; k < furniture.BuildBoundary.Length; k++)
				{
					Vector3 vector = localToWorldMatrix.MultiplyPoint(furniture.BuildBoundary[k].ToVector3(0f));
					DrawLine(p, vector, Color.red, position, FurnBoundWidth * (0f - CameraScript.Instance.mainCam.transform.localPosition.z));
					p = vector;
				}
			}
		}
		if (_furnDebug)
		{
			List<Furniture> list = SelectorController.Instance.Selected.OfType<Furniture>().ToList();
			if (list.Count > 0)
			{
				BeginDraw(ref began, mat);
				for (int l = 0; l < list.Count; l++)
				{
					Furniture furniture2 = list[l];
					if (furniture2.FinalBoundary != null && furniture2.FinalBoundary.Length > 1)
					{
						DrawBounds(furniture2.FinalBoundary, (float)(furniture2.Parent.Floor * 2) + furniture2.OffsetHeight(0), (float)(furniture2.Parent.Floor * 2) + furniture2.OffsetHeight(1), Build1, Build2, position);
					}
					if (furniture2.FinalNav != null && furniture2.FinalNav.Length != 0)
					{
						DrawBounds(furniture2.FinalNav, (float)(furniture2.Parent.Floor * 2) - 0.1f, (float)(furniture2.Parent.Floor * 2) - 0.05f, Nav1, Nav2, position);
					}
					for (int m = 0; m < furniture2.SnapPoints.Length; m++)
					{
						SnapPoint snapPoint = furniture2.SnapPoints[m];
						DrawLine(snapPoint.transform.position, snapPoint.transform.position + snapPoint.transform.up.normalized * 0.2f, Snap, position);
						DrawLine(snapPoint.transform.position - snapPoint.transform.right.normalized * 0.1f, snapPoint.transform.position + snapPoint.transform.right.normalized * 0.1f, Snap, position);
						DrawLine(snapPoint.transform.position, snapPoint.transform.position + snapPoint.transform.forward.normalized * 0.3f, Snap, position);
					}
					for (int n = 0; n < furniture2.InteractionPoints.Length; n++)
					{
						InteractionPoint interactionPoint = furniture2.InteractionPoints[n];
						DrawLine(interactionPoint.transform.position, interactionPoint.transform.position + interactionPoint.transform.up.normalized * 0.2f, Use, position);
						DrawLine(interactionPoint.transform.position - interactionPoint.transform.right.normalized * 0.1f, interactionPoint.transform.position + interactionPoint.transform.right.normalized * 0.1f, Use, position);
						DrawLine(interactionPoint.transform.position, interactionPoint.transform.position + interactionPoint.transform.forward.normalized * 0.3f, Use, position);
					}
				}
			}
		}
		if (began)
		{
			GL.End();
		}
	}

	public static void DrawBounds(IList<Transform> bounds, float h1, Color c1, Color c2, Vector3 pos)
	{
		if (bounds.Count == 2)
		{
			Transform obj = bounds[0];
			DrawLine(p2: bounds[1].position, p1: obj.position, col: c1, col2: c1, pos: pos);
			return;
		}
		for (int i = 0; i < bounds.Count; i++)
		{
			Color col = Color.Lerp(c1, c2, (float)i / (float)bounds.Count);
			Color col2 = Color.Lerp(c1, c2, ((float)i + 1f) / (float)bounds.Count);
			Transform obj2 = bounds[i];
			DrawLine(p2: bounds[(i + 1) % bounds.Count].position, p1: obj2.position, col: col, col2: col2, pos: pos);
		}
	}

	public static void DrawBounds(Vector2[] bounds, float h1, float h2, Color c1, Color c2, Vector3 pos)
	{
		if (bounds.Length == 2)
		{
			Vector2 vector = bounds[0];
			Vector2 vector2 = bounds[1];
			DrawLine(new Vector3(vector.x, h1, vector.y), new Vector3(vector.x, h2, vector.y), c1, c1, pos);
			DrawLine(new Vector3(vector.x, h1, vector.y), new Vector3(vector2.x, h1, vector2.y), c1, c2, pos);
			DrawLine(new Vector3(vector.x, h2, vector.y), new Vector3(vector2.x, h2, vector2.y), c1, c2, pos);
			DrawLine(new Vector3(vector2.x, h1, vector2.y), new Vector3(vector2.x, h2, vector2.y), c2, c2, pos);
			return;
		}
		for (int i = 0; i < bounds.Length; i++)
		{
			Color color = Color.Lerp(c1, c2, (float)i / (float)bounds.Length);
			Color col = Color.Lerp(c1, c2, ((float)i + 1f) / (float)bounds.Length);
			Vector2 vector3 = bounds[i];
			Vector2 vector4 = bounds[(i + 1) % bounds.Length];
			DrawLine(new Vector3(vector3.x, h1, vector3.y), new Vector3(vector3.x, h2, vector3.y), color, color, pos);
			DrawLine(new Vector3(vector3.x, h1, vector3.y), new Vector3(vector4.x, h1, vector4.y), color, col, pos);
			DrawLine(new Vector3(vector3.x, h2, vector3.y), new Vector3(vector4.x, h2, vector4.y), color, col, pos);
		}
	}

	public static void DrawBounds(Vector2[] bounds, float h1, float h2, Color c1, Color c2, Vector3 pos, Matrix4x4 mat)
	{
		if (bounds.Length == 2)
		{
			Vector3 vector = mat.MultiplyPoint(bounds[0].ToVector3(0f));
			Vector3 vector2 = mat.MultiplyPoint(bounds[1].ToVector3(0f));
			DrawLine(new Vector3(vector.x, h1, vector.z), new Vector3(vector.x, h2, vector.z), c1, c1, pos);
			DrawLine(new Vector3(vector.x, h1, vector.z), new Vector3(vector2.x, h1, vector2.z), c1, c2, pos);
			DrawLine(new Vector3(vector.x, h2, vector.z), new Vector3(vector2.x, h2, vector2.z), c1, c2, pos);
			DrawLine(new Vector3(vector2.x, h1, vector2.z), new Vector3(vector2.x, h2, vector2.z), c2, c2, pos);
			return;
		}
		for (int i = 0; i < bounds.Length; i++)
		{
			Color color = Color.Lerp(c1, c2, (float)i / (float)bounds.Length);
			Color col = Color.Lerp(c1, c2, ((float)i + 1f) / (float)bounds.Length);
			Vector3 vector3 = mat.MultiplyPoint(bounds[i].ToVector3(0f));
			Vector3 vector4 = mat.MultiplyPoint(bounds[(i + 1) % bounds.Length].ToVector3(0f));
			DrawLine(new Vector3(vector3.x, h1, vector3.z), new Vector3(vector3.x, h2, vector3.z), color, color, pos);
			DrawLine(new Vector3(vector3.x, h1, vector3.z), new Vector3(vector4.x, h1, vector4.z), color, col, pos);
			DrawLine(new Vector3(vector3.x, h2, vector3.z), new Vector3(vector4.x, h2, vector4.z), color, col, pos);
		}
	}

	public static void DrawLine(Vector3 p1, Vector3 p2, Color col, Vector3 pos, float width = 0.015f)
	{
		GL.Color(col);
		Vector3 vector = Vector3.Cross(p1 - p2, p1 - pos).normalized * width / 2f;
		GL.Vertex(p1 + vector);
		GL.Vertex(p2 + vector);
		GL.Vertex(p2 - vector);
		GL.Vertex(p1 - vector);
	}

	public static void DrawLine(Vector3 p1, Vector3 p2, Color col, Color col2, Vector3 pos, float width = 0.015f)
	{
		Vector3 vector = Vector3.Cross(p1 - p2, p1 - pos).normalized * width / 2f;
		GL.Color(col);
		GL.Vertex(p1 + vector);
		GL.Vertex(p1 - vector);
		GL.Color(col2);
		GL.Vertex(p2 - vector);
		GL.Vertex(p2 + vector);
	}
}
