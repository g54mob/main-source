using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(BoxCollider))]
public class UnderwaterPostProc : MonoBehaviour
{
	public PostProcessVolume ppVolume1stCam;

	public PostProcessVolume ppVolume3rdCam;

	private List<PostProcessEffectSettings> effectsToToggle = new List<PostProcessEffectSettings>();

	private void Awake()
	{
		FindPostProcessingEffects();
		BoxCollider component = GetComponent<BoxCollider>();
		Vector3 center = component.center;
		center.y = component.size.y / -2f + LevelInfo.WaterLevel;
		component.center = center;
		BoxCollider boxCollider = base.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
		boxCollider.center = component.center;
		boxCollider.size = component.size;
		boxCollider.isTrigger = component.isTrigger;
		GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Plane);
		obj.transform.parent = base.transform;
		obj.transform.eulerAngles = new Vector3(180f, 0f, 0f);
		obj.transform.localScale = Vector3.one * component.size.x;
		obj.transform.position = Vector3.up * LevelInfo.WaterLevel;
		obj.layer = LayerMask.NameToLayer("Water");
		MeshCollider component2 = obj.GetComponent<MeshCollider>();
		component2.convex = true;
		component2.isTrigger = true;
		Object.Destroy(obj.GetComponent<MeshRenderer>());
	}

	private void Start()
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.PostProcessing, OnSettingChanged);
		OnSettingChanged();
	}

	private void OnDestroy()
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.PostProcessing, OnSettingChanged);
	}

	private void OnSettingChanged()
	{
		bool active = GamePreferences.Get<bool>(Preferences.PostProcessing);
		foreach (PostProcessEffectSettings item in effectsToToggle)
		{
			item.active = active;
		}
	}

	private void FindPostProcessingEffects()
	{
		if (ppVolume1stCam.profile.TryGetSettings<DepthOfField>(out var outSetting))
		{
			effectsToToggle.Add(outSetting);
		}
		else
		{
			Debug.LogError("Couldn't find DepthOfField effect", base.gameObject);
		}
		if (ppVolume3rdCam.profile.TryGetSettings<Vignette>(out var outSetting2))
		{
			effectsToToggle.Add(outSetting2);
		}
		else
		{
			Debug.LogError("Couldn't find Vignette effect", base.gameObject);
		}
		if (ppVolume3rdCam.profile.TryGetSettings<ChromaticAberration>(out var outSetting3))
		{
			effectsToToggle.Add(outSetting3);
		}
		else
		{
			Debug.LogError("Couldn't find ChromaticAberration effect", base.gameObject);
		}
		if (ppVolume3rdCam.profile.TryGetSettings<ColorGrading>(out var outSetting4))
		{
			effectsToToggle.Add(outSetting4);
		}
		else
		{
			Debug.LogError("Couldn't find ColorGrading effect", base.gameObject);
		}
	}
}
