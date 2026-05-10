using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(UniversalAdditionalCameraData))]
public class CameraSettingsListener : MonoBehaviour
{
	private Camera m_Camera;

	private UniversalAdditionalCameraData m_CameraData;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void LoadDefault()
	{
	}

	private void OnAAChanged(int index)
	{
	}
}
