using UnityEngine;

public class LightShaftObject : MonoBehaviour
{
	private void Start()
	{
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[12]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f)
		};
		mesh.triangles = new int[18]
		{
			0, 1, 2, 2, 3, 0, 4, 5, 6, 6,
			7, 4, 8, 9, 10, 10, 11, 8
		};
		mesh.uv = new Vector2[12]
		{
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f),
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f),
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f),
			new Vector2(0f, 0f)
		};
		GetComponent<MeshFilter>().sharedMesh = mesh;
	}

	private void Update()
	{
		Plane plane = new Plane(Vector3.up, new Vector3(0f, Mathf.Floor(base.transform.position.y / 2f) * 2f, 0f));
		Vector3 direction = TimeOfDay.Instance.transform.rotation * Vector3.forward;
		Vector3 vector = base.transform.position + (Vector3)(Matrix4x4.TRS(Vector3.zero, base.transform.rotation, base.transform.localScale) * new Vector3(-1f, -1f, 0f));
		Vector3 vector2 = base.transform.position + (Vector3)(Matrix4x4.TRS(Vector3.zero, base.transform.rotation, base.transform.localScale) * new Vector3(-1f, 1f, 0f));
		Vector3 vector3 = base.transform.position + (Vector3)(Matrix4x4.TRS(Vector3.zero, base.transform.rotation, base.transform.localScale) * new Vector3(1f, 1f, 0f));
		Vector3 vector4 = base.transform.position + (Vector3)(Matrix4x4.TRS(Vector3.zero, base.transform.rotation, base.transform.localScale) * new Vector3(1f, -1f, 0f));
		Ray ray = new Ray(vector, direction);
		float enter = 0f;
		plane.Raycast(ray, out enter);
		Vector3 point = ray.GetPoint(enter);
		ray = new Ray(vector2, direction);
		plane.Raycast(ray, out enter);
		Vector3 point2 = ray.GetPoint(enter);
		ray = new Ray(vector3, direction);
		plane.Raycast(ray, out enter);
		Vector3 point3 = ray.GetPoint(enter);
		ray = new Ray(vector4, direction);
		plane.Raycast(ray, out enter);
		Vector3 point4 = ray.GetPoint(enter);
		GetComponent<MeshFilter>().mesh.vertices = new Vector3[12]
		{
			base.transform.worldToLocalMatrix * (point - base.transform.position),
			base.transform.worldToLocalMatrix * (point2 - base.transform.position),
			base.transform.worldToLocalMatrix * (vector2 - base.transform.position),
			base.transform.worldToLocalMatrix * (vector - base.transform.position),
			base.transform.worldToLocalMatrix * (point3 - base.transform.position),
			base.transform.worldToLocalMatrix * (point4 - base.transform.position),
			base.transform.worldToLocalMatrix * (vector4 - base.transform.position),
			base.transform.worldToLocalMatrix * (vector3 - base.transform.position),
			base.transform.worldToLocalMatrix * (point2 - base.transform.position),
			base.transform.worldToLocalMatrix * (point3 - base.transform.position),
			base.transform.worldToLocalMatrix * (vector3 - base.transform.position),
			base.transform.worldToLocalMatrix * (vector2 - base.transform.position)
		};
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(2f, 2f, 0.01f));
		Gizmos.matrix = Matrix4x4.identity;
	}
}
