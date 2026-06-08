using UnityEngine;

public class ChangeCameraBackgroundBasedOnFocus : MonoBehaviour, IBiomeAffectedObject
{
	[SerializeField]
	private Camera targetCamera;

	[SerializeField]
	private Material skyboxGradientMat;

	[SerializeField]
	private Vector3 hsvOffsetColor2 = new Vector3(0f, -20f, 7f);

	[SerializeField]
	private float colorLerpSpeed = 1f;

	[SerializeField]
	private Color nonDynamicColor;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private Color color1;

	[SerializeField]
	private Color color2;

	private Color targetBiomeColor;

	private Color currentColor = Color.clear;

	public GroupType GroupType => null;

	public ElementType ElementType => null;

	public ElementSubType SubType => null;

	public int Seed => 0;

	public float VariationAlpha => 0.5f;

	private void Start()
	{
		if (!targetCamera)
		{
			targetCamera = Camera.main;
		}
	}

	public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		targetBiomeColor = biomeConfiguration.GetEffectValue<Color>("CameraBackground");
		if (settingsRouter.DynamicBackgroundEnabled && currentColor == Color.clear)
		{
			UpdateColorTo(biomeConfiguration.GetEffectValue<Color>("CameraBackground"));
		}
	}

	private void UpdateColorTo(Color biomeColor)
	{
		currentColor = biomeColor;
		color1 = biomeColor;
		Color.RGBToHSV(biomeColor, out var H, out var S, out var V);
		Vector3 vector = new Vector3(H + hsvOffsetColor2.x / 100f, S + hsvOffsetColor2.y / 100f, V + hsvOffsetColor2.z / 100f);
		color2 = Color.HSVToRGB(vector.x, vector.y, vector.z);
		skyboxGradientMat.SetColor("_Color1", biomeColor);
		skyboxGradientMat.SetColor("_Color2", color2);
	}

	private void Update()
	{
		Color color = (settingsRouter.DynamicBackgroundEnabled ? targetBiomeColor : nonDynamicColor);
		if (currentColor != color)
		{
			UpdateColorTo(Color.Lerp(currentColor, color, Time.deltaTime * colorLerpSpeed));
		}
	}
}
