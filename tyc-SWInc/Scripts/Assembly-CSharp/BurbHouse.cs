using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BurbHouse : Landmark
{
	private struct Tri
	{
		public Vector3 a;

		public Vector3 b;

		public Vector3 c;

		public Tri(Vector3 a, Vector3 b, Vector3 c)
		{
			this.a = a;
			this.b = b;
			this.c = c;
		}

		public Line? CanBeRoof()
		{
			if (a.y.Appx(b.y, 0.1f) && c.y < b.y - 0.01f && c.FlattenVector3().MinDist(b.FlattenVector3()) > 0.1f && c.FlattenVector3().MinDist(a.FlattenVector3()) > 0.1f && (a - b).magnitude > 0.2f)
			{
				return new Line(a, b);
			}
			if (c.y.Appx(b.y, 0.1f) && a.y < b.y - 0.01f && a.FlattenVector3().MinDist(b.FlattenVector3()) > 0.1f && a.FlattenVector3().MinDist(c.FlattenVector3()) > 0.1f && (c - b).magnitude > 0.2f)
			{
				return new Line(c, b);
			}
			if (a.y.Appx(c.y, 0.1f) && b.y < a.y - 0.01f && b.FlattenVector3().MinDist(a.FlattenVector3()) > 0.1f && b.FlattenVector3().MinDist(c.FlattenVector3()) > 0.1f && (a - c).magnitude > 0.2f)
			{
				return new Line(a, c);
			}
			return null;
		}
	}

	private struct Line
	{
		public Vector3 a;

		public Vector3 b;

		public Line(Vector3 a, Vector3 b)
		{
			this.a = a;
			this.b = b;
		}
	}

	[ContextMenuItem("Generate", "GenerateBounds")]
	public Vector2[] Bounds;

	[ContextMenuItem("Generate", "FindTrees")]
	public Transform[] TreePoints;

	public MeshRenderer Rend;

	public MeshFilter MeshRend;

	public bool LightsOn;

	public float OnToggle;

	public float OffToggle;

	public float Height = 1f;

	public Transform SmokePosition;

	private bool _hasSmoke;

	private MaterialPropertyBlock block;

	public float LowerAreaReq;

	public float Cost;

	private float _lastEmit;

	private float _smokeThresh;

	[NonSerialized]
	private Vector4 _matVec = Vector4.zero;

	[ContextMenuItem("Generate", "GenerateRoofLines")]
	public Vector3[] RoofLines;

	[NonSerialized]
	public Vector2[] NavMesh;

	[NonSerialized]
	public Rect RectBounds;

	public int Idx;

	public void Init(Vector2[] bounds = null)
	{
		block = new MaterialPropertyBlock();
		block.SetVector("_TexOffset", new Vector4((float)Utilities.RandomRange(0, 4) / 4f, (float)Utilities.RandomRange(0, 4) / 4f, 0.25f, 0.25f));
		block.SetVector("_ExtraStuff", _matVec);
		Rend.SetPropertyBlock(block);
		OnToggle = UnityEngine.Random.Range(0.6f, 0.9f);
		OffToggle = UnityEngine.Random.Range(0.1f, 0.4f);
		if (bounds != null)
		{
			for (int i = 0; i < TreePoints.Length; i++)
			{
				Vector3 position = TreePoints[i].position;
				if (Utilities.IsInside(position.FlattenVector3(), bounds))
				{
					GameSettings.Instance.AddTree(position);
				}
			}
		}
		NavMesh = Bounds.SelectInPlace((Vector2 x) => base.transform.localToWorldMatrix.MultiplyPoint(x.ToVector3(0f)).FlattenVector3()).ReverseArray();
		RectBounds = ((IList<Vector2>)NavMesh).GetBounds();
		if (SmokePosition != null)
		{
			_hasSmoke = true;
			_smokeThresh = UnityEngine.Random.value;
			_lastEmit = Time.realtimeSinceStartup;
		}
	}

	public void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			float num = TimeOfDay.Instance.HouseOnage.Evaluate((float)TimeOfDay.Instance.Hour + TimeOfDay.Instance.Minute / 60f);
			if (!LightsOn && num > OnToggle)
			{
				LightsOn = true;
			}
			else if (LightsOn && num < OffToggle)
			{
				LightsOn = false;
			}
			if (_hasSmoke && GameSettings.GameSpeed > 0f && GameSettings.Instance.ActiveFloor >= 0 && (Time.realtimeSinceStartup - _lastEmit) * (float)HUD.Instance.GameSpeed > 1f / 7f && TimeOfDay.Instance.GetSnowTemp(1f / 24f) > _smokeThresh * 0.5f)
			{
				_lastEmit = Time.realtimeSinceStartup;
				GameSettings.Instance.ChimneySmokePrefab.Emit(new ParticleSystem.EmitParams
				{
					position = SmokePosition.position,
					velocity = new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(-0.1f, 0.1f)),
					rotation = UnityEngine.Random.Range(0f, 360f)
				}, 1);
			}
			Rend.enabled = GameSettings.Instance.ActiveFloor >= 0;
			UpdateMatVec();
		}
	}

	private void UpdateMatVec(bool force = false)
	{
		Vector4 vector = new Vector4(0f, LightsOn ? 1f : 0f, 0f, 0f);
		if (force || !EqualVec(vector, _matVec))
		{
			_matVec = vector;
			block.SetVector("_ExtraStuff", _matVec);
			Rend.SetPropertyBlock(block);
		}
	}

	private bool EqualVec(Vector4 v1, Vector4 v2)
	{
		float num = v1.x - v2.x;
		num += v1.y - v2.y;
		num += v1.z - v2.z;
		num += v1.w - v2.w;
		if (num > -0.001f)
		{
			return num < 0.001f;
		}
		return false;
	}

	private void OnDrawGizmos()
	{
		for (int i = 0; i < Bounds.Length; i++)
		{
			Gizmos.color = ((i == 0) ? Color.red : Color.cyan);
			Vector3 vector = base.transform.localToWorldMatrix.MultiplyPoint(Bounds[i].ToVector3(0f));
			Vector3 to = base.transform.localToWorldMatrix.MultiplyPoint(Bounds[(i + 1) % Bounds.Length].ToVector3(0f));
			Gizmos.DrawSphere(vector, 0.2f);
			Gizmos.DrawLine(vector, to);
		}
		Gizmos.color = Color.white;
		for (int j = 0; j < TreePoints.Length; j++)
		{
			Gizmos.DrawCube(TreePoints[j].position + Vector3.up * 1f, new Vector3(1f, 2f, 1f));
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
		for (int i = 0; i < RoofLines.Length; i += 2)
		{
			Gizmos.DrawLine(localToWorldMatrix.MultiplyPoint(RoofLines[i]), localToWorldMatrix.MultiplyPoint(RoofLines[i + 1]));
		}
	}

	public void FindTrees()
	{
		TreePoints = (from x in GetComponentsInChildren<Transform>()
			where x != base.transform && x.GetComponent<MeshRenderer>() == null
			select x).ToArray();
	}

	public void GenerateBounds()
	{
		List<Vector3> list = Rend.GetComponent<MeshFilter>().sharedMesh.vertices.Select((Vector3 x) => Rend.transform.localToWorldMatrix.MultiplyPoint(x)).ToList();
		List<Vector2> points = list.Select((Vector3 x) => x.FlattenVector3()).ToList();
		Bounds = Utilities.ComputeConvexHull(points).ToArray();
		Height = list.Max((Vector3 x) => x.y);
	}

	private bool CanConnect(Vector3 a, Vector3 b, Vector3 c, Vector3 d, out bool same)
	{
		same = false;
		if (b.Approximate(c))
		{
			if (a.Approximate(d))
			{
				same = true;
				return true;
			}
			return (b - a).Approximate(d - c);
		}
		return false;
	}

	public void GenerateRoofLines()
	{
		RoofLines = new Vector3[0];
		Mesh sharedMesh = Rend.GetComponent<MeshFilter>().sharedMesh;
		List<Vector3> list = sharedMesh.vertices.Select((Vector3 x) => Rend.transform.localToWorldMatrix.MultiplyPoint(x)).ToList();
		List<Tri> list2 = new List<Tri>();
		List<Line> list3 = new List<Line>();
		int[] triangles = sharedMesh.triangles;
		for (int num = 0; num < triangles.Length; num += 3)
		{
			list2.Add(new Tri(list[triangles[num]], list[triangles[num + 1]], list[triangles[num + 2]]));
		}
		foreach (Tri item in list2)
		{
			Line? line = item.CanBeRoof();
			if (line.HasValue)
			{
				list3.Add(line.Value);
			}
		}
		for (int num2 = 0; num2 < list3.Count; num2++)
		{
			for (int num3 = num2 + 1; num3 < list3.Count; num3++)
			{
				Line line2 = list3[num2];
				Line line3 = list3[num3];
				bool same;
				if (CanConnect(line2.b, line2.a, line3.a, line3.b, out same))
				{
					if (!same)
					{
						list3[num2] = new Line(line2.b, line3.b);
					}
					list3.RemoveAt(num3);
					num3--;
				}
				else if (CanConnect(line2.b, line2.a, line3.b, line3.a, out same))
				{
					if (!same)
					{
						list3[num2] = new Line(line2.b, line3.a);
					}
					list3.RemoveAt(num3);
					num3--;
				}
				else if (CanConnect(line2.a, line2.b, line3.a, line3.b, out same))
				{
					if (!same)
					{
						list3[num2] = new Line(line2.a, line3.b);
					}
					list3.RemoveAt(num3);
					num3--;
				}
				else if (CanConnect(line2.a, line2.b, line3.b, line3.a, out same))
				{
					if (!same)
					{
						list3[num2] = new Line(line2.a, line3.a);
					}
					list3.RemoveAt(num3);
					num3--;
				}
			}
		}
		RoofLines = new Vector3[list3.Count * 2];
		for (int num4 = 0; num4 < list3.Count; num4++)
		{
			RoofLines[num4 * 2] = list3[num4].a;
			RoofLines[num4 * 2 + 1] = list3[num4].b;
		}
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		base.DeserializeMe(dictionary, loading, networkMode);
		block = new MaterialPropertyBlock();
		block.SetVector("_TexOffset", dictionary.Get("TexOffset", new SVector3(0f, 0f, 0.25f, 0.25f)));
		OnToggle = dictionary.Get("OnToggle", 0.75f);
		OffToggle = dictionary.Get("OffToggle", 0.25f);
		base.transform.SetPositionAndRotation(dictionary.Get("Position", new SVector3()), dictionary.Get("Rotation", new SVector3()));
		UpdateMatVec(true);
		NavMesh = Bounds.SelectInPlace((Vector2 x) => base.transform.localToWorldMatrix.MultiplyPoint(x.ToVector3(0f)).FlattenVector3()).ReverseArray();
		RectBounds = ((IList<Vector2>)NavMesh).GetBounds();
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		base.SerializeMe(dictionary, mode, networkMode, checkDIDs);
		dictionary["Idx"] = Idx;
		dictionary["LightsOn"] = LightsOn;
		dictionary["OnToggle"] = OnToggle;
		dictionary["OffToggle"] = OffToggle;
		dictionary["TexOffset"] = (SVector3)block.GetVector("_TexOffset");
		dictionary["Position"] = (SVector3)base.transform.position;
		dictionary["Rotation"] = (SVector3)base.transform.rotation;
	}

	public override string WriteName()
	{
		return "BurbHouse";
	}

	public override Rect GetArea()
	{
		return RectBounds;
	}

	public override Vector2[] GetNavMesh()
	{
		return NavMesh;
	}

	public override Vector2 Center()
	{
		return base.transform.position.FlattenVector3();
	}

	public override MeshFilter GetGrassMesh()
	{
		return MeshRend;
	}

	public override float GetHeight()
	{
		return Height;
	}
}
