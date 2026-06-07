using System;
using NaisuPorter.CommonScripts;
using UnityEngine;

[Serializable]
public class SecurityCameraSaveData
{
	public int Id;

	public SerializableVector3 Position;

	public bool IsAtCeiling;

	public SerializableQuaternion TargetRotation;

	public Matrix4x4 CullingMatrix;

	public SecurityCameraSaveData(int id, Vector3 position, bool isAtCeiling, Quaternion targetRotation, Matrix4x4 cullingMatrix)
	{
	}
}
