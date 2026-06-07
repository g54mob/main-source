using UnityEngine;

public class RoadLightScript : MonoBehaviour
{
	private bool On;

	public float Intensity = 1f;

	public PipLight localLight;

	public Renderer rend;

	public Renderer Cone;

	public Gradient LightColor;

	private void Start()
	{
		localLight.enabled = false;
		Cone.gameObject.SetActive(false);
	}

	private bool ToggleNow()
	{
		if (Cheats.ForceLights)
		{
			return true;
		}
		if (!HUD.Instance.IsReferenceNull() && HUD.Instance.BuildMode)
		{
			return HUD.Instance.SunSlider.value < 0.5f;
		}
		if (TimeOfDay.Instance.Hour <= 19)
		{
			return TimeOfDay.Instance.Hour < 7;
		}
		return true;
	}

	public void RefreshColor()
	{
		Vector3 position = base.transform.position;
		Vector2 vector = new Vector2((position.x * 0.3183099f + 0.1f) % 1f, (position.z * 0.3183099f + 0.1f) % 1f) * 6f;
		Color color = LightColor.Evaluate(vector.x * vector.y * (vector.x + vector.y) % 1f);
		localLight.color = color;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetColor("_Color1", color);
		Cone.SetPropertyBlock(materialPropertyBlock);
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			bool flag = GameSettings.Instance.ActiveFloor >= 0;
			if (rend.enabled != flag)
			{
				rend.enabled = flag;
			}
			bool flag2 = GameSettings.Instance.ActiveFloor >= 0 && ToggleNow();
			if (On != flag2)
			{
				On = flag2;
				localLight.enabled = On;
				Cone.gameObject.SetActive(On);
			}
			if (localLight.enabled && ((localLight.shadowType == LightShadows.Hard) ^ Options.MoreShadow))
			{
				localLight.shadowType = (Options.MoreShadow ? LightShadows.Hard : LightShadows.None);
			}
		}
	}
}
