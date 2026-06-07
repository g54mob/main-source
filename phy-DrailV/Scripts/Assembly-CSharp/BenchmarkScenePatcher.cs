using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

public class BenchmarkScenePatcher : MonoBehaviour
{
	[Header("Weather")]
	public Weather24hPresetSO weatherOverride;

	private void Awake()
	{
		if (SingletonBehaviour<BenchmarkSetup>.Instance.IsAwoken)
		{
			Initialize();
		}
		else
		{
			SingletonBehaviour<BenchmarkSetup>.Instance.awakeEvent.AddListener(Initialize);
		}
	}

	private void Initialize()
	{
		SingletonBehaviour<BenchmarkSetup>.Instance.playerTransform.gameObject.AddComponent<UpdateFogValuesDV>();
		SingletonBehaviour<BenchmarkSetup>.Instance.playerTransform.gameObject.AddComponent<TOD_Camera>();
		SingletonBehaviour<WeatherDriver>.Instance.presetOverride = weatherOverride;
		SingletonBehaviour<WeatherDriver>.Instance.GetComponent<WeatherEditorGUI>().enabled = false;
	}
}
