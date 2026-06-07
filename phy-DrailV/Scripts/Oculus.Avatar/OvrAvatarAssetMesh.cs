using System;
using System.Runtime.InteropServices;
using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarAssetMesh : OvrAvatarAsset
{
	public Mesh mesh;

	private ovrAvatarSkinnedMeshPose skinnedBindPose;

	public string[] jointNames;

	public OvrAvatarAssetMesh(ulong _assetId, IntPtr asset, ovrAvatarAssetType meshType)
	{
		assetID = _assetId;
		mesh = new Mesh();
		mesh.name = "Procedural Geometry for asset " + _assetId;
		SetSkinnedBindPose(asset, meshType);
		long vertexCount = 0L;
		IntPtr vertexBuffer = IntPtr.Zero;
		uint indexCount = 0u;
		IntPtr indexBuffer = IntPtr.Zero;
		GetVertexAndIndexData(asset, meshType, out vertexCount, out vertexBuffer, out indexCount, out indexBuffer);
		Vector3[] array = new Vector3[vertexCount];
		Vector3[] array2 = new Vector3[vertexCount];
		Vector4[] array3 = new Vector4[vertexCount];
		Vector2[] array4 = new Vector2[vertexCount];
		Color[] array5 = new Color[vertexCount];
		BoneWeight[] array6 = new BoneWeight[vertexCount];
		long num = vertexBuffer.ToInt64();
		switch (meshType)
		{
		case ovrAvatarAssetType.Mesh:
		{
			long num5 = Marshal.SizeOf(typeof(ovrAvatarMeshVertex));
			for (long num6 = 0L; num6 < vertexCount; num6++)
			{
				long num7 = num5 * num6;
				ovrAvatarMeshVertex ovrAvatarMeshVertex2 = (ovrAvatarMeshVertex)Marshal.PtrToStructure(new IntPtr(num + num7), typeof(ovrAvatarMeshVertex));
				array[num6] = new Vector3(ovrAvatarMeshVertex2.x, ovrAvatarMeshVertex2.y, 0f - ovrAvatarMeshVertex2.z);
				array2[num6] = new Vector3(ovrAvatarMeshVertex2.nx, ovrAvatarMeshVertex2.ny, 0f - ovrAvatarMeshVertex2.nz);
				array3[num6] = new Vector4(ovrAvatarMeshVertex2.tx, ovrAvatarMeshVertex2.ty, 0f - ovrAvatarMeshVertex2.tz, ovrAvatarMeshVertex2.tw);
				array4[num6] = new Vector2(ovrAvatarMeshVertex2.u, ovrAvatarMeshVertex2.v);
				array5[num6] = new Color(0f, 0f, 0f, 1f);
				array6[num6].boneIndex0 = ovrAvatarMeshVertex2.blendIndices[0];
				array6[num6].boneIndex1 = ovrAvatarMeshVertex2.blendIndices[1];
				array6[num6].boneIndex2 = ovrAvatarMeshVertex2.blendIndices[2];
				array6[num6].boneIndex3 = ovrAvatarMeshVertex2.blendIndices[3];
				array6[num6].weight0 = ovrAvatarMeshVertex2.blendWeights[0];
				array6[num6].weight1 = ovrAvatarMeshVertex2.blendWeights[1];
				array6[num6].weight2 = ovrAvatarMeshVertex2.blendWeights[2];
				array6[num6].weight3 = ovrAvatarMeshVertex2.blendWeights[3];
			}
			break;
		}
		case ovrAvatarAssetType.CombinedMesh:
		{
			long num2 = Marshal.SizeOf(typeof(ovrAvatarMeshVertexV2));
			for (long num3 = 0L; num3 < vertexCount; num3++)
			{
				long num4 = num2 * num3;
				ovrAvatarMeshVertexV2 ovrAvatarMeshVertexV3 = (ovrAvatarMeshVertexV2)Marshal.PtrToStructure(new IntPtr(num + num4), typeof(ovrAvatarMeshVertexV2));
				array[num3] = new Vector3(ovrAvatarMeshVertexV3.x, ovrAvatarMeshVertexV3.y, 0f - ovrAvatarMeshVertexV3.z);
				array2[num3] = new Vector3(ovrAvatarMeshVertexV3.nx, ovrAvatarMeshVertexV3.ny, 0f - ovrAvatarMeshVertexV3.nz);
				array3[num3] = new Vector4(ovrAvatarMeshVertexV3.tx, ovrAvatarMeshVertexV3.ty, 0f - ovrAvatarMeshVertexV3.tz, ovrAvatarMeshVertexV3.tw);
				array4[num3] = new Vector2(ovrAvatarMeshVertexV3.u, ovrAvatarMeshVertexV3.v);
				array5[num3] = new Color(ovrAvatarMeshVertexV3.r, ovrAvatarMeshVertexV3.g, ovrAvatarMeshVertexV3.b, ovrAvatarMeshVertexV3.a);
				array6[num3].boneIndex0 = ovrAvatarMeshVertexV3.blendIndices[0];
				array6[num3].boneIndex1 = ovrAvatarMeshVertexV3.blendIndices[1];
				array6[num3].boneIndex2 = ovrAvatarMeshVertexV3.blendIndices[2];
				array6[num3].boneIndex3 = ovrAvatarMeshVertexV3.blendIndices[3];
				array6[num3].weight0 = ovrAvatarMeshVertexV3.blendWeights[0];
				array6[num3].weight1 = ovrAvatarMeshVertexV3.blendWeights[1];
				array6[num3].weight2 = ovrAvatarMeshVertexV3.blendWeights[2];
				array6[num3].weight3 = ovrAvatarMeshVertexV3.blendWeights[3];
			}
			break;
		}
		default:
			throw new Exception("Bad Mesh Asset Type");
		}
		mesh.vertices = array;
		mesh.normals = array2;
		mesh.uv = array4;
		mesh.tangents = array3;
		mesh.boneWeights = array6;
		mesh.colors = array5;
		LoadBlendShapes(asset, vertexCount);
		LoadSubmeshes(asset, indexBuffer, indexCount);
		uint jointCount = skinnedBindPose.jointCount;
		jointNames = new string[jointCount];
		for (uint num8 = 0u; num8 < jointCount; num8++)
		{
			jointNames[num8] = Marshal.PtrToStringAnsi(skinnedBindPose.jointNames[num8]);
		}
	}

	private void LoadSubmeshes(IntPtr asset, IntPtr indexBufferPtr, ulong indexCount)
	{
		uint num = CAPI.ovrAvatarAsset_GetSubmeshCount(asset);
		short[] array = new short[indexCount];
		Marshal.Copy(indexBufferPtr, array, 0, (int)indexCount);
		mesh.subMeshCount = (int)num;
		uint num2 = 0u;
		for (uint num3 = 0u; num3 < num; num3++)
		{
			uint num4 = CAPI.ovrAvatarAsset_GetSubmeshLastIndex(asset, num3);
			uint num5 = num4 - num2;
			int[] array2 = new int[num5];
			int num6 = 0;
			for (ulong num7 = num2; num7 < num4; num7 += 3)
			{
				array2[num6 + 2] = array[num7];
				array2[num6 + 1] = array[num7 + 1];
				array2[num6] = array[num7 + 2];
				num6 += 3;
			}
			num2 += num5;
			mesh.SetIndices(array2, MeshTopology.Triangles, (int)num3);
		}
	}

	private void LoadBlendShapes(IntPtr asset, long vertexCount)
	{
		uint num = CAPI.ovrAvatarAsset_GetMeshBlendShapeCount(asset);
		IntPtr intPtr = CAPI.ovrAvatarAsset_GetMeshBlendShapeVertices(asset);
		if (!(intPtr != IntPtr.Zero))
		{
			return;
		}
		long num2 = 0L;
		long num3 = Marshal.SizeOf(typeof(ovrAvatarBlendVertex));
		long num4 = intPtr.ToInt64();
		for (uint num5 = 0u; num5 < num; num5++)
		{
			Vector3[] array = new Vector3[vertexCount];
			Vector3[] array2 = new Vector3[vertexCount];
			Vector3[] array3 = new Vector3[vertexCount];
			for (long num6 = 0L; num6 < vertexCount; num6++)
			{
				ovrAvatarBlendVertex ovrAvatarBlendVertex2 = (ovrAvatarBlendVertex)Marshal.PtrToStructure(new IntPtr(num4 + num2), typeof(ovrAvatarBlendVertex));
				array[num6] = new Vector3(ovrAvatarBlendVertex2.x, ovrAvatarBlendVertex2.y, 0f - ovrAvatarBlendVertex2.z);
				array2[num6] = new Vector3(ovrAvatarBlendVertex2.nx, ovrAvatarBlendVertex2.ny, 0f - ovrAvatarBlendVertex2.nz);
				array3[num6] = new Vector4(ovrAvatarBlendVertex2.tx, ovrAvatarBlendVertex2.ty, 0f - ovrAvatarBlendVertex2.tz);
				num2 += num3;
			}
			string shapeName = Marshal.PtrToStringAnsi(CAPI.ovrAvatarAsset_GetMeshBlendShapeName(asset, num5));
			mesh.AddBlendShapeFrame(shapeName, 100f, array, array2, array3);
		}
	}

	private void SetSkinnedBindPose(IntPtr asset, ovrAvatarAssetType meshType)
	{
		switch (meshType)
		{
		case ovrAvatarAssetType.Mesh:
			skinnedBindPose = CAPI.ovrAvatarAsset_GetMeshData(asset).skinnedBindPose;
			break;
		case ovrAvatarAssetType.CombinedMesh:
			skinnedBindPose = CAPI.ovrAvatarAsset_GetCombinedMeshData(asset).skinnedBindPose;
			break;
		}
	}

	private void GetVertexAndIndexData(IntPtr asset, ovrAvatarAssetType meshType, out long vertexCount, out IntPtr vertexBuffer, out uint indexCount, out IntPtr indexBuffer)
	{
		vertexCount = 0L;
		vertexBuffer = IntPtr.Zero;
		indexCount = 0u;
		indexBuffer = IntPtr.Zero;
		switch (meshType)
		{
		case ovrAvatarAssetType.Mesh:
			vertexCount = CAPI.ovrAvatarAsset_GetMeshData(asset).vertexCount;
			vertexBuffer = CAPI.ovrAvatarAsset_GetMeshData(asset).vertexBuffer;
			indexCount = CAPI.ovrAvatarAsset_GetMeshData(asset).indexCount;
			indexBuffer = CAPI.ovrAvatarAsset_GetMeshData(asset).indexBuffer;
			break;
		case ovrAvatarAssetType.CombinedMesh:
			vertexCount = CAPI.ovrAvatarAsset_GetCombinedMeshData(asset).vertexCount;
			vertexBuffer = CAPI.ovrAvatarAsset_GetCombinedMeshData(asset).vertexBuffer;
			indexCount = CAPI.ovrAvatarAsset_GetCombinedMeshData(asset).indexCount;
			indexBuffer = CAPI.ovrAvatarAsset_GetCombinedMeshData(asset).indexBuffer;
			break;
		}
	}

	public SkinnedMeshRenderer CreateSkinnedMeshRendererOnObject(GameObject target)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = target.AddComponent<SkinnedMeshRenderer>();
		skinnedMeshRenderer.sharedMesh = mesh;
		mesh.name = "AvatarMesh_" + assetID;
		uint jointCount = skinnedBindPose.jointCount;
		GameObject[] array = new GameObject[jointCount];
		Transform[] array2 = new Transform[jointCount];
		Matrix4x4[] array3 = new Matrix4x4[jointCount];
		for (uint num = 0u; num < jointCount; num++)
		{
			array[num] = new GameObject();
			array2[num] = array[num].transform;
			array[num].name = jointNames[num];
			int num2 = skinnedBindPose.jointParents[num];
			if (num2 == -1)
			{
				array[num].transform.parent = skinnedMeshRenderer.transform;
				skinnedMeshRenderer.rootBone = array[num].transform;
			}
			else
			{
				array[num].transform.parent = array[num2].transform;
			}
			Vector3 position = skinnedBindPose.jointTransform[num].position;
			position.z = 0f - position.z;
			array[num].transform.localPosition = position;
			Quaternion orientation = skinnedBindPose.jointTransform[num].orientation;
			orientation.x = 0f - orientation.x;
			orientation.y = 0f - orientation.y;
			array[num].transform.localRotation = orientation;
			array[num].transform.localScale = skinnedBindPose.jointTransform[num].scale;
			array3[num] = array[num].transform.worldToLocalMatrix * skinnedMeshRenderer.transform.localToWorldMatrix;
		}
		skinnedMeshRenderer.bones = array2;
		mesh.bindposes = array3;
		return skinnedMeshRenderer;
	}
}
