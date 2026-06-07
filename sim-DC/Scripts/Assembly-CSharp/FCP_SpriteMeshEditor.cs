using UnityEngine;

[ExecuteInEditMode]
public class FCP_SpriteMeshEditor : MonoBehaviour
{
	public enum MeshType
	{
		CenterPoint = 0,
		forward = 1,
		backward = 2
	}

	public int x;

	public int y;

	public MeshType meshType;

	public Sprite sprite;

	private int bufferedHash;

	private void Update()
	{
	}

	private int GetSettingHash()
	{
		return 0;
	}

	private void MakeMesh(Sprite sprite, int x, int y, MeshType meshtype)
	{
	}
}
