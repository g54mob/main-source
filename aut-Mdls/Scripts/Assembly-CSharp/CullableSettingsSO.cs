using UnityEngine;

[CreateAssetMenu(menuName = "Culling/Cullable Item Settings", fileName = "CullableSettings", order = 0)]
public class CullableSettingsSO : ScriptableObject
{
	public bool LODWithQualityLevel;

	public CullingGraphicsQualityLevel LODAtQualityThreshold = CullingGraphicsQualityLevel.Medium;

	public bool LODWithCameraDistance = true;

	public float CameraLODDistance_Low = 50f;

	public float CameraLODDistance_Medium = 60f;

	public float CameraLODDistance_High = 70f;

	public bool CullWithQualityLevel;

	public CullingGraphicsQualityLevel CullAtQualityThreshold = CullingGraphicsQualityLevel.Low;

	public bool CullWithCameraDistance;

	public float CameraCullDistance_Low = 50f;

	public float CameraCullDistance_Medium = 60f;

	public float CameraCullDistance_High = 70f;

	public CullableSettings ToCullableSettings()
	{
		return new CullableSettings
		{
			CullWithQualityLevel = CullWithQualityLevel,
			CullAtQualityThreshold = CullAtQualityThreshold,
			CullWithCameraDistance = CullWithCameraDistance,
			CameraCullDistance_Low = CameraCullDistance_Low,
			CameraCullDistance_Medium = CameraCullDistance_Medium,
			CameraCullDistance_High = CameraCullDistance_High,
			LODWithQualityLevel = LODWithQualityLevel,
			LODAtQualityThreshold = LODAtQualityThreshold,
			LODWithCameraDistance = LODWithCameraDistance,
			CameraLODDistance_Low = CameraLODDistance_Low,
			CameraLODDistance_Medium = CameraLODDistance_Medium,
			CameraLODDistance_High = CameraLODDistance_High
		};
	}
}
