using UnityEngine;

[ExecuteInEditMode]
public class FoggyLight : MonoBehaviour
{
	public enum BlendModeEnum
	{
		Additive = 0,
		AlphaBlended = 1
	}

	public BlendModeEnum BlendMode;

	public bool ApplyTonemap = true;

	private Component FogVolumeComponent;

	public Color PointLightColor = Color.white;

	private Vector3 Position;

	[Range(0f, 8f)]
	public float PointLightIntensity = 1f;

	[Range(0f, 20f)]
	public float FoggyLightIntensity = 1f;

	public float PointLightExponent = 5f;

	public float Offset = -2f;

	[Range(1f, 40f)]
	public float IntersectionRange = 2f;

	public int DrawOrder = 1;

	public bool AttatchLight;

	private Light AttachedLight;

	private Material FoggyLightMaterial;

	[SerializeField]
	private GameObject FogVolumeContainer;

	public bool InsideFogVolume;

	public Material GetMaterial()
	{
		return FoggyLightMaterial;
	}

	private void CreateMaterial()
	{
		if (!FoggyLightMaterial)
		{
			FoggyLightMaterial = new Material(Shader.Find("Hidden/FoggyLight"));
			FoggyLightMaterial.name = base.name.ToString() + " Material";
			base.gameObject.GetComponent<Renderer>().sharedMaterial = FoggyLightMaterial;
			FoggyLightMaterial.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	private void OnEnable()
	{
		CreateMaterial();
	}

	private void OnDisable()
	{
		Disable();
	}

	private void OnWillRenderObject()
	{
		Renderer component = GetComponent<Renderer>();
		component.sortingOrder = DrawOrder;
		Position = base.gameObject.transform.position;
		PointLightExponent = Mathf.Max(1f, PointLightExponent);
		Position = base.gameObject.transform.position;
		component.sharedMaterial.SetColor("PointLightColor", PointLightColor);
		if ((bool)FogVolumeContainer && InsideFogVolume)
		{
			if (!FogVolumeComponent)
			{
				FogVolumeComponent = FogVolumeContainer.GetComponent("FogVolume");
			}
			FoggyLightMaterial.EnableKeyword("_FOG_CONTAINER");
			float value = (float)FogVolumeComponent.GetType().GetMethod("GetVisibility").Invoke(FogVolumeComponent, null);
			component.sharedMaterial.SetFloat("_Visibility", value);
		}
		else
		{
			FoggyLightMaterial.DisableKeyword("_FOG_CONTAINER");
		}
		if (ApplyTonemap)
		{
			FoggyLightMaterial.EnableKeyword("TONEMAP");
		}
		else
		{
			FoggyLightMaterial.DisableKeyword("TONEMAP");
		}
		FoggyLightMaterial.SetVector("PointLightPosition", Position);
		FoggyLightMaterial.SetFloat("PointLightIntensity", PointLightIntensity * FoggyLightIntensity);
		FoggyLightMaterial.SetFloat("PointLightExponent", PointLightExponent);
		FoggyLightMaterial.SetFloat("Offset", Offset);
		FoggyLightMaterial.SetFloat("IntersectionRange", IntersectionRange);
		if (AttatchLight)
		{
			if (AttachedLight == null)
			{
				AttachedLight = base.gameObject.GetComponent<Light>();
				if (AttachedLight == null)
				{
					AttachedLight = base.gameObject.AddComponent<Light>();
				}
				AttachedLight.shadows = LightShadows.Hard;
			}
			AttachedLight.intensity = PointLightIntensity / 2f;
			AttachedLight.color = PointLightColor;
			AttachedLight.enabled = true;
		}
		else if ((bool)AttachedLight)
		{
			AttachedLight.enabled = false;
		}
		BlendValues(BlendMode);
	}

	private void BlendValues(BlendModeEnum BlendMode)
	{
		switch (BlendMode)
		{
		case BlendModeEnum.Additive:
			FoggyLightMaterial.EnableKeyword("_ADDITIVE");
			FoggyLightMaterial.SetInt("_SrcBlend", 1);
			FoggyLightMaterial.SetInt("_DstBlend", 1);
			break;
		case BlendModeEnum.AlphaBlended:
			FoggyLightMaterial.DisableKeyword("_ADDITIVE");
			FoggyLightMaterial.SetInt("_SrcBlend", 5);
			FoggyLightMaterial.SetInt("_DstBlend", 10);
			break;
		}
	}

	public void Disable()
	{
		FoggyLightMaterial.SetFloat("PointLightIntensity", 0f);
	}

	public bool ReturnIsLightAttached(Light light)
	{
		if (light == null)
		{
			return false;
		}
		if (AttatchLight)
		{
			if ((bool)AttachedLight)
			{
				return AttachedLight == light;
			}
			return light == GetComponent<Light>();
		}
		return false;
	}
}
