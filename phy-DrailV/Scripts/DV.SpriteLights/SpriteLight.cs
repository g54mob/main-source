using System.Collections.Generic;
using UnityEngine;

public class SpriteLight : MonoBehaviour
{
	public struct SpriteLightData
	{
		public Vector4 position;

		public Vector4 normal;

		public Vector4 color;

		public Vector4 mergeOffset;

		public float density;

		public float scale;
	}

	public class LightBakeContainer
	{
		public List<SpriteLights.LightData> streetLights = new List<SpriteLights.LightData>();

		public List<SpriteLights.LightData> blinkingRedLights = new List<SpriteLights.LightData>();

		public List<SpriteLights.LightData> windowLights = new List<SpriteLights.LightData>();

		public List<SpriteLights.LightData> yellowLights = new List<SpriteLights.LightData>();

		public List<SpriteLights.LightData> uniqueLights = new List<SpriteLights.LightData>();

		public List<SpriteLights.LightData> blinkingGreenLights = new List<SpriteLights.LightData>();

		public List<SpriteLights.LightData> whiteLights = new List<SpriteLights.LightData>();

		public int GetCount()
		{
			return streetLights.Count + blinkingRedLights.Count + windowLights.Count + yellowLights.Count + uniqueLights.Count + blinkingGreenLights.Count + whiteLights.Count;
		}

		public void PrintCount()
		{
			Debug.Log("Number of SpriteLights found:");
			Debug.Log("  Street lights: " + streetLights.Count);
			Debug.Log("  Blinking Red lights: " + blinkingRedLights.Count);
			Debug.Log("  Window lights: " + windowLights.Count);
			Debug.Log("  Yellow lights: " + yellowLights.Count);
			Debug.Log("  Unique Color/Size lights: " + uniqueLights.Count);
			Debug.Log("  Blinking Green lights: " + blinkingGreenLights.Count);
			Debug.Log("  White lights: " + whiteLights.Count);
			Debug.Log("Total: " + GetCount() + " lights");
		}
	}

	private const string CULLING_MASK_LAYER_NAME = "Reflection_Probe_Only";

	[Header("Real light")]
	public bool generateRealLight = true;

	public bool overrideColor;

	public Color lightColor = Color.black;

	public bool overrideIntensity;

	public float intensity;

	public bool overrideRange;

	public float range;

	public SpriteLight[] mergeGroup;

	public Vector3 mergeOffset = Vector3.zero;

	[Header("Grouping")]
	public int groupID;

	public SpriteLightGroup ParentGroup { get; set; }

	public virtual bool ShouldGenerateRealLight => generateRealLight;

	public virtual bool RealtimeEffectsEntry => true;

	public virtual SpriteLightType LightType => SpriteLightType.Generic;

	public virtual LightType GeneratedLightType => UnityEngine.LightType.Point;

	public virtual float LightIntensity => 1f;

	public virtual float LightRange => 6f;

	public virtual Color LightColor => Color.white;

	public void FillInData(Vector3 worldShift, ref SpriteLightData data, float on)
	{
		Vector3 forward = base.transform.forward;
		Vector3 vector = base.transform.position - worldShift;
		data.position = new Vector4(vector.x, vector.y, vector.z, on);
		data.normal = new Vector4(forward.x, forward.y, forward.z, (GeneratedLightType == UnityEngine.LightType.Spot) ? 1 : 0);
		data.color = (overrideColor ? lightColor : LightColor);
		data.scale = (overrideRange ? range : LightRange);
		data.density = (overrideIntensity ? intensity : LightIntensity) * 0.01f;
		data.mergeOffset = new Vector4(mergeOffset.x, mergeOffset.y, mergeOffset.z, ShouldGenerateRealLight ? 1 : 0);
	}

	public Light GenerateRealLight()
	{
		Light light = GetComponent<Light>();
		if (!ShouldGenerateRealLight)
		{
			if ((bool)light)
			{
				Object.Destroy(light);
			}
			return null;
		}
		if (!light)
		{
			light = base.gameObject.AddComponent<Light>();
		}
		SetupLight(light);
		light.cullingMask = ~LayerMask.GetMask("Reflection_Probe_Only");
		if (overrideIntensity)
		{
			light.intensity = intensity;
		}
		if (overrideRange)
		{
			light.range = range;
		}
		if (overrideColor)
		{
			light.color = lightColor;
		}
		light.intensity *= 2f;
		return light;
	}

	protected virtual void SetupLight(Light light)
	{
		light.type = GeneratedLightType;
		light.intensity = LightIntensity;
		light.range = LightRange;
		light.color = LightColor;
	}

	public virtual void FillLights(LightBakeContainer container)
	{
	}
}
