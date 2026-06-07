using UnityEngine;
using UnityEngine.Rendering;

public class VaporMesh : MonoBehaviour
{
	public Material material;

	public bool reverse;

	public float particleSize0;

	public float particleSize1 = 1f;

	public float headFade = 0.25f;

	public float tailFade = 0.5f;

	public float speed0 = 2f;

	public float speed1 = 0.75f;

	[Readonly]
	public float maxDistFromCenter;

	private float flightLoc;

	public bool inFlight { get; private set; }

	public bool launched { get; private set; }

	public bool completelyCoveringBody
	{
		get
		{
			return flightLoc > maxDistFromCenter + spread * headFade;
		}
	}

	private float spread
	{
		get
		{
			return maxDistFromCenter / (1f - (tailFade + headFade));
		}
	}

	public void Launch()
	{
		base.gameObject.SetActive(true);
		inFlight = true;
		flightLoc = 0f;
		launched = true;
		material = GetComponent<Renderer>().material;
		material.SetVector("_VaporMeshSizes", new Vector4(particleSize0, particleSize1, 0f, 0f));
	}

	private void Update()
	{
		if (inFlight)
		{
			float num = Util.LerpScale(flightLoc, 0f, maxDistFromCenter, speed0, speed1);
			flightLoc += num * Clock.play.deltaTime;
			float num2 = ((!reverse) ? flightLoc : (maxDistFromCenter + spread - flightLoc));
			float b = num2;
			float a = num2 - spread;
			material.SetVector("_VaporMeshInfo", new Vector4(Mathf.Lerp(a, b, 0f), Mathf.Lerp(a, b, tailFade), Mathf.Lerp(a, b, 1f - headFade), Mathf.Lerp(a, b, 1f)));
			if (flightLoc > maxDistFromCenter + spread)
			{
				inFlight = false;
				base.gameObject.SetActive(false);
			}
		}
	}

	public void CreateMesh(GameObject targetGo, Vector3 center)
	{
		base.transform.position = center;
		float num = 0f;
		PointMeshBuilder pointMeshBuilder = new PointMeshBuilder();
		MeshFilter[] componentsInChildren = targetGo.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			Vector3[] vertices = meshFilter.sharedMesh.vertices;
			Matrix4x4 matrix4x = base.transform.worldToLocalMatrix * meshFilter.transform.localToWorldMatrix;
			Vector3 vector = new Vector3(10000f, 0f, 0f);
			for (int j = 0; j < vertices.Length; j += 2)
			{
				Vector3 vector2 = matrix4x.MultiplyPoint(vertices[j]);
				num = Mathf.Max(num, vector2.sqrMagnitude);
				if (!((vector - vector2).sqrMagnitude < 0.01f))
				{
					vector = vector2;
					pointMeshBuilder.Add(vector2);
				}
			}
		}
		Mesh mesh = new Mesh();
		mesh.name = "VaporMesh (" + targetGo.name + ")";
		pointMeshBuilder.Apply(mesh);
		maxDistFromCenter = Mathf.Sqrt(num);
		MeshFilter meshFilter2 = base.gameObject.AddComponent<MeshFilter>();
		meshFilter2.sharedMesh = mesh;
		MeshRenderer meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
		meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		meshRenderer.receiveShadows = false;
		meshRenderer.lightProbeUsage = LightProbeUsage.Off;
		meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		meshRenderer.sharedMaterial = material;
		base.gameObject.SetActive(false);
	}
}
