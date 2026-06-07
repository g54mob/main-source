using UnityEngine;

public class TOD_UnderwaterLevelSetter : MonoBehaviour
{
	private const float BLEND_DISTANCE = 0.1f;

	private const float VR_SCALE_MULT = 0.5f;

	private TOD_Camera cam;

	private void Start()
	{
		cam = GetComponent<TOD_Camera>();
		if (!cam)
		{
			Debug.LogError("Missing Camera Main Component (TOD_Camera)!");
		}
		if ((bool)TOD_Sky.Instance)
		{
			TOD_Sky.Instance.SunAndMoonScale = (VRManager.IsVREnabled() ? 0.5f : 1f);
		}
	}

	private void Update()
	{
		float waterLevel = LevelInfo.WaterLevel;
		cam.underwaterLerpFactor = Mathf.InverseLerp(waterLevel + 0.1f, waterLevel, base.transform.position.y);
	}
}
