using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class DynamicResolutionController : MonoBehaviour
{
	public enum DLSSQuality
	{
		MaximumPerformance = 0,
		Balanced = 1,
		MaximumQuality = 2,
		UltraPerformance = 3
	}

	public List<HDAdditionalCameraData> AllHDCameras;

	[SerializeField]
	private bool dynamicResolutionEnabled;

	[SerializeField]
	private bool dlssEnabled;

	private static DynamicResolutionController _instance;

	public bool DynamicResolutionEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool DLSSEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static DynamicResolutionController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void SetDynamicResolutionEnabled(bool enable)
	{
	}

	public void SetDLSSEnabled(bool enable)
	{
	}

	public void SetDLSSQualityMode(DLSSQuality quality)
	{
	}

	private uint ConvertDLSSQualityValue(DLSSQuality quality)
	{
		return 0u;
	}
}
