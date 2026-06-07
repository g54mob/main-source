using System;

public struct ovrAvatarMeshAssetDataV2
{
	public uint vertexCount;

	public IntPtr vertexBuffer;

	public uint indexCount;

	public IntPtr indexBuffer;

	public ovrAvatarSkinnedMeshPose skinnedBindPose;
}
