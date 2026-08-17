using System;
using Cpp2ILInjected;
using UnityEngine;

public class RsgPiece : MonoBehaviour
{
	public bool mirror = true;

	public bool reverse;

	public Transform start;

	public Transform end;

	public Transform lowestPoint;

	public GameObject children;

	public MeshFilter meshFilter;

	public MeshCollider newCollider;

	public float complexity = 0.5f;

	public int traverseTime = 15;

	private BoxCollider boundsCollider;

	private Bounds bounds;

	private bool mirrored;

	private void OnValidate()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < componentsInChildren.Length)
		{
			GameObject gameObject = componentsInChildren[obj].gameObject;
			string text = gameObject.name;
			if (text != "Start")
			{
				GameObject gameObject2 = componentsInChildren[obj].gameObject;
				string text2 = gameObject2.name;
				if (text2 == "End")
				{
					end = componentsInChildren[obj];
					obj++;
					obj2 = obj;
					continue;
				}
			}
			else
			{
				start = componentsInChildren[obj];
			}
			obj++;
			obj2 = obj;
		}
	}

	public unsafe Bounds GetBounds()
	{
		//IL_0197: Expected native int or pointer, but got O
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_00ec: Expected O, but got Ref
		if (!(boundsCollider == null))
		{
			goto IL_018d;
		}
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
			boundsCollider = boxCollider;
			if (!mirrored)
			{
				goto IL_00f1;
			}
			if ((object)boundsCollider != null)
			{
				Vector3 center = boundsCollider.center;
				if ((object)boundsCollider != null)
				{
					object obj = default(object);
					boundsCollider.center = (Vector3)(&obj);
					goto IL_00f1;
				}
			}
		}
		goto IL_01ae;
		IL_018d:
		Bounds bounds = default(Bounds);
		((Bounds*)(nint)bounds)->m_Center = (Vector3)this.bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (RsgPiece)+78]");
		_ = 0;
		return bounds;
		IL_01ae:
		return (Bounds)new NullReferenceException();
		IL_00f1:
		if ((object)boundsCollider != null)
		{
			Bounds bounds2 = boundsCollider.bounds;
			Bounds bounds3 = (Bounds)(this + 104);
			this.bounds = (Bounds)bounds2.m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v12 (UnityEngine.Bounds)+10]");
			_ = 0;
			((Bounds*)bounds3)->Expand(-0.05f);
			if ((object)boundsCollider != null)
			{
				boundsCollider.enabled = false;
				goto IL_018d;
			}
		}
		goto IL_01ae;
	}

	public float GetLowestCordY()
	{
		Transform transform;
		if (!(lowestPoint == null))
		{
			transform = lowestPoint;
			goto IL_00fe;
		}
		if ((object)start != null)
		{
			Vector3 position = start.position;
			if ((object)end != null)
			{
				transform = ((end.position.y > position.y) ? start : end);
				goto IL_00fe;
			}
		}
		goto IL_00e9;
		IL_00e9:
		throw new NullReferenceException();
		IL_00fe:
		if ((object)transform != null)
		{
			return transform.position.y;
		}
		goto IL_00e9;
	}

	public unsafe void Mirror()
	{
		//IL_0031: Expected O, but got Ref
		mirrored = true;
		Transform transform = children.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
	}

	public void SetCollider()
	{
		//IL_0073: Expected O, but got I4
		//IL_0111: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00a4: Expected O, but got I4
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00c9: Expected O, but got I4
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		Mesh sharedMesh2;
		if (!mirrored)
		{
			Mesh sharedMesh = meshFilter.sharedMesh;
			sharedMesh2 = sharedMesh;
		}
		else
		{
			Mesh sharedMesh3 = meshFilter.sharedMesh;
			Mesh mesh = new Mesh();
			Vector3[] vertices = sharedMesh3.vertices;
			object obj = 0;
			while ((nint)obj < vertices.Length)
			{
				object obj2 = 0 * 2;
				object obj3 = 0 + obj2;
				object obj4 = 0 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v12 (UnityEngine.Vector3[])+20+v320 @ rcx_v18*4]");
				object obj5 = 0 ^ -0f;
				object obj6 = 0 * 2;
				object obj7 = 0 + obj6;
				obj = obj4;
			}
			mesh.vertices = vertices;
			int[] triangles = sharedMesh3.triangles;
			object obj8 = 0;
			object obj9 = 0;
			while ((nint)obj9 < triangles.Length)
			{
				object obj10 = obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v16 (System.Int32[])+28+v176 @ rdx_v10*4]");
				triangles[obj10] = 0;
				object obj11 = obj8 + 3;
				_ = triangles[obj8];
				obj8 = obj11;
				obj9 = obj11;
			}
			mesh.triangles = triangles;
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			sharedMesh2 = mesh;
		}
		newCollider.sharedMesh = sharedMesh2;
	}

	private Mesh MirrorMesh(Mesh mesh)
	{
		//IL_0020: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		Mesh mesh2 = new Mesh();
		Vector3[] vertices = mesh.vertices;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < vertices.Length)
			{
				if ((nint)obj >= vertices.Length)
				{
					break;
				}
				object obj3 = obj * 2;
				object obj4 = obj + obj3;
				object obj5 = obj + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v8 (UnityEngine.Vector3[])+20+v247 @ rcx_v15*4]");
				object obj6 = 0 ^ -0f;
				object obj7 = obj * 2;
				object obj8 = obj + obj7;
				obj = obj5;
				obj2 = obj5;
				continue;
			}
			mesh2.vertices = vertices;
			int[] triangles = mesh.triangles;
			object obj9 = 0;
			object obj10 = 0;
			while (true)
			{
				if ((nint)obj10 < triangles.Length)
				{
					if ((nint)obj9 >= triangles.Length)
					{
						break;
					}
					object obj11 = obj9 + 2;
					if ((nint)obj11 >= triangles.Length)
					{
						break;
					}
					object obj12 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v12 (System.Int32[])+28+v118 @ rdx_v8*4]");
					triangles[obj12] = 0;
					object obj13 = obj9 + 2;
					if ((nint)obj13 >= triangles.Length)
					{
						break;
					}
					object obj14 = obj9 + 3;
					_ = triangles[obj9];
					obj9 = obj14;
					obj10 = obj14;
					continue;
				}
				mesh2.triangles = triangles;
				mesh2.RecalculateNormals();
				mesh2.RecalculateBounds();
				return mesh2;
			}
			break;
		}
		return (Mesh)(object)new IndexOutOfRangeException();
	}
}
