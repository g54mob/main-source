using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.Mathematics;
using VoxelMeshGeneration;

public abstract class tq<a> : rx where a : class, tp
{
	private tr rrp;

	protected a rrq
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	protected virtual float xex => 0f;

	protected virtual byte xey => 0;

	public void gub([NotNull] a meshSettings)
	{
	}

	protected abstract hx<int3, VoxelMesh.Voxel> gsn();
}
