using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoundaryPointEditor : MonoBehaviour
{
	public Camera MainCam;

	public GameObject PointPrefab;

	public float PointRad = 0.1f;

	public List<Transform> CurrentPoints = new List<Transform>();

	private bool _nav;

	public bool Active;

	private Furniture _furn;

	private FurnSnapMeta _point;

	private Matrix4x4 _mat;

	private int _dragging = -1;

	public void Save()
	{
		Matrix4x4 inverse = _mat.inverse;
		Vector2[] array = new Vector2[CurrentPoints.Count];
		for (int i = 0; i < CurrentPoints.Count; i++)
		{
			array[i] = inverse.MultiplyPoint(CurrentPoints[i].position).FlattenVector3();
		}
		if (_point != null)
		{
			_point.Changed = true;
			SnapPoint snapPoint = (SnapPoint)_point.Target;
			snapPoint.Surface = array;
			FurnitureModdingTool.Instance.BoundaryDrawer.SnapPoint = snapPoint;
		}
		else if (_nav)
		{
			_furn.NavBoundary = array;
		}
		else
		{
			_furn.BuildBoundary = array;
		}
	}

	public void Clear()
	{
		if (_point != null)
		{
			_point.Changed = true;
			SnapPoint snapPoint = (SnapPoint)_point.Target;
			snapPoint.Surface = null;
			FurnitureModdingTool.Instance.BoundaryDrawer.SnapPoint = snapPoint;
		}
		else if (_nav)
		{
			_furn.NavBoundary = null;
		}
		else
		{
			_furn.BuildBoundary = null;
		}
	}

	public void Exit()
	{
		for (int i = 0; i < CurrentPoints.Count; i++)
		{
			Object.Destroy(CurrentPoints[i].gameObject);
		}
		CurrentPoints.Clear();
		Active = false;
	}

	public void Init(Furniture furn, bool nav)
	{
		_furn = furn;
		_point = null;
		_mat = furn.transform.localToWorldMatrix;
		Active = true;
		_nav = nav;
		Vector2[] array = (nav ? furn.NavBoundary : furn.BuildBoundary);
		if (array == null || array.Length == 0)
		{
			array = new Vector2[4]
			{
				new Vector2(-0.5f, -0.5f),
				new Vector2(-0.5f, 0.5f),
				new Vector2(0.5f, 0.5f),
				new Vector2(0.5f, -0.5f)
			};
		}
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = Object.Instantiate(PointPrefab);
			gameObject.transform.position = _mat.MultiplyPoint(array[i].ToVector3(0f));
			CurrentPoints.Add(gameObject.transform);
		}
	}

	public void Init(Furniture furn, FurnSnapMeta snap)
	{
		_furn = furn;
		SnapPoint snapPoint = (SnapPoint)snap.Target;
		_point = snap;
		_mat = snapPoint.transform.localToWorldMatrix;
		Active = true;
		Vector2[] array = snapPoint.Surface;
		if (array == null || array.Length == 0)
		{
			array = new Vector2[4]
			{
				new Vector2(-0.5f, -0.5f),
				new Vector2(-0.5f, 0.5f),
				new Vector2(0.5f, 0.5f),
				new Vector2(0.5f, -0.5f)
			};
		}
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = Object.Instantiate(PointPrefab);
			gameObject.transform.position = _mat.MultiplyPoint(array[i].ToVector3(0f));
			CurrentPoints.Add(gameObject.transform);
		}
	}

	public bool DoUpdate()
	{
		if (Active && !EventSystem.current.IsPointerOverGameObject() && (FurnitureModdingTool.Instance.CurrentGizmo == null || !FurnitureModdingTool.Instance.CurrentGizmo.IsDragging))
		{
			Plane plane = new Plane(Vector3.up, _mat.GetTranslation());
			Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				Vector3 point = ray.GetPoint(enter);
				if (_dragging >= 0)
				{
					CurrentPoints[_dragging].position = point;
					if (Input.GetMouseButtonUp(0))
					{
						_dragging = -1;
					}
					return true;
				}
				if (Input.GetMouseButtonDown(0))
				{
					Transform transform = null;
					float num = PointRad;
					for (int i = 0; i < CurrentPoints.Count; i++)
					{
						Transform transform2 = CurrentPoints[i];
						float magnitude = (transform2.position - point).magnitude;
						if (magnitude < num)
						{
							num = magnitude;
							transform = transform2;
						}
					}
					if (transform != null)
					{
						_dragging = CurrentPoints.IndexOf(transform);
						return true;
					}
					if (_dragging == -1)
					{
						for (int j = 0; j < CurrentPoints.Count; j++)
						{
							Transform transform3 = CurrentPoints[j];
							Transform transform4 = CurrentPoints[(j + 1) % CurrentPoints.Count];
							Vector2 res;
							if (Utilities.ProjectToLine(point.FlattenVector3(), transform3.transform.position.FlattenVector3(), transform4.transform.position.FlattenVector3(), out res))
							{
								float magnitude2 = (res - point.FlattenVector3()).magnitude;
								if (magnitude2 < num)
								{
									transform = transform3;
									num = magnitude2;
								}
							}
						}
						if (transform != null)
						{
							GameObject gameObject = Object.Instantiate(PointPrefab);
							gameObject.transform.position = point;
							int num2 = CurrentPoints.IndexOf(transform);
							CurrentPoints.Insert(num2 + 1, gameObject.transform);
							_dragging = num2 + 1;
							return true;
						}
					}
				}
				if (Input.GetMouseButtonDown(1) && CurrentPoints.Count > 2)
				{
					Transform transform5 = null;
					float num3 = PointRad;
					for (int k = 0; k < CurrentPoints.Count; k++)
					{
						Transform transform6 = CurrentPoints[k];
						float magnitude3 = (transform6.position - point).magnitude;
						if (magnitude3 < num3)
						{
							num3 = magnitude3;
							transform5 = transform6;
						}
					}
					if (transform5 != null)
					{
						Object.Destroy(transform5.gameObject);
						CurrentPoints.Remove(transform5);
						_dragging = -1;
						return true;
					}
				}
			}
		}
		return false;
	}
}
