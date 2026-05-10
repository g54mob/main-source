using UnityEngine;

public abstract class RenderableInstance
{
	public uint InstanceId;

	public Matrix4x4 Matrix;

	public Matrix4x4 MatrixInverse;

	public AABB Bounds;

	public int Id { get; protected set; }

	public Mesh Mesh { get; protected set; }

	public int Submesh { get; protected set; }

	public Material Material { get; protected set; }
}
