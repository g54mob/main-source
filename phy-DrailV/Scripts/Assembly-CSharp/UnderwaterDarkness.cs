using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnderwaterDarkness : MonoBehaviour
{
	public float maxDarknessValue = 2.6f;

	public float maxDepth = 30f;

	private float initialValue;

	private ColorGrading exp;

	private void Start()
	{
		GetComponent<PostProcessVolume>().profile.TryGetSettings<ColorGrading>(out exp);
		initialValue = exp.postExposure.value;
	}

	private void Update()
	{
		Camera activeCamera = PlayerManager.ActiveCamera;
		if ((bool)activeCamera)
		{
			exp.postExposure.value = NumberUtil.MapClamp(activeCamera.transform.position.y, LevelInfo.WaterLevel - maxDepth, LevelInfo.WaterLevel, initialValue - maxDarknessValue, initialValue);
		}
	}
}
