using UnityEngine;

public class Clearing : MonoBehaviour
{
	public Texture texture;

	public Vector4 verticalEdges;

	public Bounds worldBounds;

	public Matrix4x4 uvTransform;

	public static void InitFromMaya(GameObject go, MayaProps props)
	{
		go.AddComponent<Clearing>();
		go.layer = LayerMask.NameToLayer("Clearing");
	}
}
