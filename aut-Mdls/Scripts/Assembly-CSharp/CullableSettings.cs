using System;
using Unity.Burst;

[Serializable]
[BurstCompile]
public struct CullableSettings
{
	public bool CullWithQualityLevel;

	public CullingGraphicsQualityLevel CullAtQualityThreshold;

	public bool CullWithCameraDistance;

	public float CameraCullDistance_Low;

	public float CameraCullDistance_Medium;

	public float CameraCullDistance_High;

	public bool LODWithQualityLevel;

	public CullingGraphicsQualityLevel LODAtQualityThreshold;

	public bool LODWithCameraDistance;

	public float CameraLODDistance_Low;

	public float CameraLODDistance_Medium;

	public float CameraLODDistance_High;
}
