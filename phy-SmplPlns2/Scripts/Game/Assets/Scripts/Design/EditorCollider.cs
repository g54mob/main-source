using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class EditorCollider
	{
		public static int GlobalUpdateId = 1;

		private const float Tolerance = 0.04f;

		private int _updateId;

		public Bounds Bounds { get; private set; }

		public Collider Collider { get; private set; }

		public List<Vector3> Edges { get; private set; }

		public bool IncludeInAero { get; set; }

		public bool IncludeInBounds { get; set; } = true;

		public bool IncludeInIntersections { get; set; }

		public List<Vector3> Normals { get; private set; }

		public PartScript PartScript { get; set; }

		public List<Vector3> Points { get; private set; }

		public bool RequiresSeparatingAxisTest { get; set; }

		public WingScript WingScript { get; set; }

		public EditorCollider(Collider collider, PartScript partScript, PartColliderScript colliderScript)
		{
			RequiresSeparatingAxisTest = false;
			Collider = collider;
			Points = new List<Vector3>();
			Edges = new List<Vector3>();
			Normals = new List<Vector3>();
			PartScript = partScript;
			IncludeInBounds = !(colliderScript != null) || colliderScript.IncludeInBounds;
			IncludeInIntersections = true;
			IncludeInAero = true;
			if (colliderScript != null)
			{
				IncludeInAero = !colliderScript.ExcludeFromDragModel;
				IncludeInIntersections = !colliderScript.IgnoreDesignerCollisions;
			}
		}

		public EditorCollider(WingScript wing, PartScript partScript)
		{
			RequiresSeparatingAxisTest = true;
			WingScript = wing;
			Points = new List<Vector3>();
			Edges = new List<Vector3>();
			Normals = new List<Vector3>();
			PartScript = partScript;
			IncludeInAero = false;
			IncludeInIntersections = true;
			IncludeInBounds = true;
		}

		public void Update()
		{
			if (_updateId == GlobalUpdateId)
			{
				return;
			}
			_updateId = GlobalUpdateId;
			Points.Clear();
			Normals.Clear();
			Edges.Clear();
			if (WingScript != null)
			{
				Points.Add(WingScript.transform.TransformPoint(WingScript.RootTrailingEdge + new Vector3(0f, 0f, 0.04f)));
				Points.Add(WingScript.transform.TransformPoint(WingScript.RootLeadingEdge + new Vector3(0f, 0f, -0.04f)));
				Points.Add(WingScript.transform.TransformPoint(WingScript.TipLeadingEdge + new Vector3(0f, -0.04f, -0.04f)));
				Points.Add(WingScript.transform.TransformPoint(WingScript.TipTrailingEdge + new Vector3(0f, -0.04f, 0.04f)));
				Vector3 vector = Points[1] - Points[0];
				Edges.Add(vector);
				Vector3 vector2 = Points[2] - Points[1];
				Edges.Add(vector2);
				Vector3 vector3 = Points[3] - Points[0];
				if (WingScript.Wing.BaseChord != WingScript.Wing.TipChord)
				{
					Edges.Add(vector3);
				}
				Vector3 vector4 = Vector3.Cross(vector, vector2);
				Normals.Add(vector4);
				Vector3 item = Vector3.Cross(vector, vector4);
				Normals.Add(item);
				Vector3 item2 = Vector3.Cross(vector2, vector4);
				Normals.Add(item2);
				if (WingScript.Wing.BaseChord != WingScript.Wing.TipChord)
				{
					Vector3 item3 = Vector3.Cross(vector3, vector4);
					Normals.Add(item3);
				}
				Bounds = new Bounds(Points[0], Vector3.zero);
				for (int i = 1; i < Points.Count; i++)
				{
					Bounds = ExpandBoundsToIncludePoint(Bounds, Points[i]);
				}
				Vector3 size = Bounds.size;
				if (size.x < 0.1f)
				{
					size.x = 0.1f;
				}
				if (size.y < 0.1f)
				{
					size.y = 0.1f;
				}
				if (size.z < 0.1f)
				{
					size.z = 0.1f;
				}
				Bounds = new Bounds(Bounds.center, size);
			}
			else
			{
				Bounds = Collider.bounds;
				float[] array = new float[3];
				float[] array2 = new float[3];
				array[0] = Bounds.center.x;
				array[1] = Bounds.center.y;
				array[2] = Bounds.center.z;
				array2[0] = Bounds.extents.x - 0.04f;
				array2[1] = Bounds.extents.y - 0.04f;
				array2[2] = Bounds.extents.z - 0.04f;
				Points.Add(new Vector3(array[0] + array2[0], array[1] + array2[1], array[2] + array2[2]));
				Points.Add(new Vector3(array[0] + array2[0], array[1] + array2[1], array[2] - array2[2]));
				Points.Add(new Vector3(array[0] + array2[0], array[1] - array2[1], array[2] + array2[2]));
				Points.Add(new Vector3(array[0] + array2[0], array[1] - array2[1], array[2] - array2[2]));
				Points.Add(new Vector3(array[0] - array2[0], array[1] + array2[1], array[2] + array2[2]));
				Points.Add(new Vector3(array[0] - array2[0], array[1] + array2[1], array[2] - array2[2]));
				Points.Add(new Vector3(array[0] - array2[0], array[1] - array2[1], array[2] + array2[2]));
				Points.Add(new Vector3(array[0] - array2[0], array[1] - array2[1], array[2] - array2[2]));
				Edges.Add(new Vector3(1f, 0f, 0f));
				Edges.Add(new Vector3(0f, 1f, 0f));
				Edges.Add(new Vector3(0f, 0f, 1f));
			}
		}

		private static Bounds ExpandBoundsToIncludePoint(Bounds bounds, Vector3 p)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			if (p.x < min.x)
			{
				min.x = p.x;
			}
			else if (p.x > max.x)
			{
				max.x = p.x;
			}
			if (p.y < min.y)
			{
				min.y = p.y;
			}
			else if (p.y > max.y)
			{
				max.y = p.y;
			}
			if (p.z < min.z)
			{
				min.z = p.z;
			}
			else if (p.z > max.z)
			{
				max.z = p.z;
			}
			bounds.SetMinMax(min, max);
			return bounds;
		}
	}
}
