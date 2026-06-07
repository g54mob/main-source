using UnityEngine;

public class PrimitiveMesh : MonoBehaviour
{
	private static Mesh _unityCapsuleMesh;

	private static Mesh _unityCubeMesh;

	private static Mesh _unityCylinderMesh;

	private static Mesh _unityPlaneMesh;

	private static Mesh _unitySphereMesh;

	private static Mesh _unityQuadMesh;

	public static Mesh GetUnityPrimitiveMesh(PrimitiveType primitiveType)
	{
		return null;
	}

	private static Mesh GetPrimitiveMesh(ref Mesh primMesh, PrimitiveType primitiveType)
	{
		return null;
	}

	private static Mesh GetCachedPrimitiveMesh(ref Mesh primMesh, PrimitiveType primitiveType)
	{
		return null;
	}

	private static string GetPrimitiveMeshPath(PrimitiveType primitiveType)
	{
		return null;
	}
}
