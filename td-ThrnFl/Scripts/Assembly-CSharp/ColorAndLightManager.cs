using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAndLightManager : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	private static ColorAndLightManager instance;

	[SerializeField]
	private Light sunlight;

	private Light bonfireLight;

	[SerializeField]
	private Colorscheme colorscheme;

	public bool forbidColorschemeCycle;

	private Colorscheme initialColorscheme;

	[SerializeField]
	private WaterSettings waterSettings;

	[SerializeField]
	private float transitionDuration = 3f;

	[SerializeField]
	private Transform playerTransform;

	[SerializeField]
	private Material enemyMaterial;

	[SerializeField]
	private Material allyMaterial;

	[SerializeField]
	private Material allyRangedMaterial;

	[SerializeField]
	private Material playerMaterial;

	[SerializeField]
	private Material playerCapeMaterial;

	[SerializeField]
	private Material playerCrownMaterial;

	[SerializeField]
	private Material horseMaterial;

	[SerializeField]
	private Material buildingMaterial;

	[SerializeField]
	private Material buildingPreviewMaterial;

	[SerializeField]
	private Material coinMaterial;

	[SerializeField]
	private Material groundMaterial;

	[SerializeField]
	private Material groundHigh;

	[SerializeField]
	private Material groundLow;

	[SerializeField]
	private Material earthMaterial;

	[SerializeField]
	private Material sandMaterial;

	[SerializeField]
	private Material groundPatches;

	[SerializeField]
	private Material treeMaterial;

	[SerializeField]
	private Material rockMaterial;

	[SerializeField]
	private Material waterMaterial;

	[SerializeField]
	private Material oceanMaterial;

	[SerializeField]
	private Material roadMaterial;

	[SerializeField]
	private Material shadowShapeMaterial;

	[SerializeField]
	private Material dmgFlashMaterial;

	[SerializeField]
	private Material treasureChestMaterial;

	[SerializeField]
	private Material treasureChestAccentMaterial;

	[SerializeField]
	private bool ignoreEternalTrials;

	[SerializeField]
	private List<Colorscheme> eternalTrialColorschemes = new List<Colorscheme>();

	private GameObject playerCameraParticles;

	public static Colorscheme currentColorscheme;

	private static Material eliteEnemyMaterial;

	public Color originalEnemyHealthBarColor;

	[HideInInspector]
	public Color enemyHealthBarColor;

	private Vector2 oceanOffset;

	private Vector2 riverOffset;

	public static ColorAndLightManager Instance => instance;

	public Light Sunlight => sunlight;

	public Light BonfireLight => bonfireLight;

	public Colorscheme CurrentColorScheme => colorscheme;

	public static Material EliteEnemyMaterial => eliteEnemyMaterial;

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDusk()
	{
		StopAllCoroutines();
		StartCoroutine(ToNight());
	}

	public void OnDawn_BeforeSunrise()
	{
		StopAllCoroutines();
		StartCoroutine(ToDay());
	}

	public void Daylight()
	{
		sunlight.color = colorscheme.dayLightColor;
		AdjustAllOutlineColorsBasedOnLight(colorscheme.globalShadowColor, colorscheme.dayLightColor);
	}

	public void SunsetLight()
	{
		sunlight.color = colorscheme.sunsetLightColor;
		AdjustAllOutlineColorsBasedOnLight(colorscheme.globalShadowColor, colorscheme.sunsetLightColor);
	}

	public void NightLight()
	{
		sunlight.color = colorscheme.nightLightColor;
		AdjustAllOutlineColorsBasedOnLight(colorscheme.globalShadowColor, colorscheme.nightLightColor);
	}

	private IEnumerator ToDay()
	{
		float timer = 0f;
		Color currentColor = sunlight.color;
		while (timer <= transitionDuration)
		{
			timer += Time.deltaTime;
			sunlight.color = Color.Lerp(currentColor, colorscheme.sunsetLightColor, timer / transitionDuration);
			AdjustAllOutlineColorsBasedOnLight(colorscheme.globalShadowColor, sunlight.color);
			yield return null;
		}
		timer = 0f;
		while (timer <= transitionDuration)
		{
			timer += Time.deltaTime;
			sunlight.color = Color.Lerp(colorscheme.sunsetLightColor, colorscheme.dayLightColor, timer / transitionDuration);
			AdjustAllOutlineColorsBasedOnLight(colorscheme.globalShadowColor, sunlight.color);
			yield return null;
		}
		sunlight.color = colorscheme.dayLightColor;
		AdjustAllOutlineColorsBasedOnLight(colorscheme.globalShadowColor, sunlight.color);
	}

	private IEnumerator ToNight()
	{
		float timer = 0f;
		sunlight.color = colorscheme.dayLightColor;
		while (timer <= transitionDuration)
		{
			timer += Time.deltaTime;
			sunlight.color = Color.Lerp(colorscheme.dayLightColor, colorscheme.nightLightColor, timer / transitionDuration);
			AdjustAllOutlineColorsBasedOnLight(colorscheme.globalShadowColor, sunlight.color);
			yield return null;
		}
		sunlight.color = colorscheme.nightLightColor;
		AdjustAllOutlineColorsBasedOnLight(colorscheme.globalShadowColor, sunlight.color);
	}

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		initialColorscheme = colorscheme;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial && !ignoreEternalTrials)
		{
			colorscheme = eternalTrialColorschemes[new System.Random(EternalTrialsRunManager.CurrentRun.currentStageSeed).Next(0, eternalTrialColorschemes.Count)];
		}
		sunlight.color = colorscheme.dayLightColor;
		ApplyColorScheme(colorscheme);
		if (playerCameraParticles != null)
		{
			UnityEngine.Object.Destroy(playerCameraParticles);
		}
		if ((bool)playerTransform && (bool)colorscheme.particlesToAttachToPlayer)
		{
			playerCameraParticles = UnityEngine.Object.Instantiate(colorscheme.particlesToAttachToPlayer, playerTransform);
			playerCameraParticles.transform.localPosition = Vector3.zero;
		}
		eliteEnemyMaterial = new Material(enemyMaterial);
		eliteEnemyMaterial.SetColor("_OutlineColor", Color.yellow);
	}

	private void Update()
	{
		riverOffset.x = Time.time * waterSettings.riverScrollSpeed;
		waterMaterial.SetTextureOffset("_BaseMap", riverOffset);
		oceanOffset.x = Time.time * waterSettings.oceanScrollSpeed;
		oceanMaterial.SetTextureOffset("_BaseMap", oceanOffset);
	}

	public void ApplayColorScheme()
	{
		ApplyColorScheme(colorscheme);
	}

	public static Color HueShift(Color color, float hueShiftDegrees, float boostSaturation)
	{
		Color.RGBToHSV(color, out var H, out var S, out var V);
		float num = hueShiftDegrees / 360f;
		H = (H + num) % 1f;
		if (H < 0f)
		{
			H += 1f;
		}
		S *= boostSaturation;
		S = Mathf.Clamp01(S);
		Color result = Color.HSVToRGB(H, S, V);
		result.a = color.a;
		return result;
	}

	public void ApplyColorScheme(Colorscheme _colorScheme)
	{
		Color color = _colorScheme.enemyLightColor;
		Color color2 = _colorScheme.enemyMidColor;
		enemyHealthBarColor = originalEnemyHealthBarColor;
		if ((bool)SettingsManager.Instance)
		{
			switch (SettingsManager.Instance.ColorblindMode)
			{
			case SettingsManager.ColorBlindMode.YellowEnemies:
				color = HueShift(color, 64f, 1.5f);
				color2 = HueShift(color2, 64f, 1.5f);
				enemyHealthBarColor = HueShift(originalEnemyHealthBarColor, 64f, 1.5f);
				break;
			case SettingsManager.ColorBlindMode.OrangeEnemies:
				color = HueShift(color, 40f, 1.5f);
				color2 = HueShift(color2, 40f, 1.5f);
				enemyHealthBarColor = HueShift(originalEnemyHealthBarColor, 40f, 1.5f);
				break;
			case SettingsManager.ColorBlindMode.PurpleEnemies:
				color = HueShift(color, -42f, 1.5f);
				color2 = HueShift(color2, -42f, 1.5f);
				enemyHealthBarColor = HueShift(originalEnemyHealthBarColor, -42f, 1.5f);
				break;
			case SettingsManager.ColorBlindMode.WhiteEnemies:
				color = Color.white;
				color2 = Color.gray;
				enemyHealthBarColor = new Color(220f, 220f, 220f);
				break;
			}
		}
		SetMaterialColors(enemyMaterial, color, color2, _colorScheme.globalShadowColor);
		SetMaterialColors(allyMaterial, _colorScheme.allyLightColor, _colorScheme.allyMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(allyRangedMaterial, _colorScheme.allyRangedLightColor, _colorScheme.allyRangedMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(playerMaterial, _colorScheme.playerLightColor, _colorScheme.playerMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(playerCapeMaterial, _colorScheme.playerCapeLightColor, _colorScheme.playerCapeMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(playerCrownMaterial, _colorScheme.playerCrownLightColor, _colorScheme.playerCrownMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(horseMaterial, _colorScheme.horseLightColor, _colorScheme.horseMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(buildingMaterial, _colorScheme.buildingLightColor, _colorScheme.buildingMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(_lightCol: new Color(_colorScheme.buildingLightColor.r, _colorScheme.buildingLightColor.g, _colorScheme.buildingLightColor.b, 0.15f), _midCol: new Color(_colorScheme.buildingMidColor.r, _colorScheme.buildingMidColor.g, _colorScheme.buildingMidColor.b, 0.15f), _shadowCol: new Color(_colorScheme.globalShadowColor.r, _colorScheme.globalShadowColor.g, _colorScheme.globalShadowColor.b, 0.15f), _mat: buildingPreviewMaterial);
		SetMaterialColors(coinMaterial, _colorScheme.coinLightColor, _colorScheme.coinMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(groundMaterial, _colorScheme.groundColor, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor);
		SetMaterialColors(groundPatches, _colorScheme.groundColorLow, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor);
		SetMaterialColors(groundHigh, _colorScheme.groundColorHigh, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor);
		SetMaterialColors(groundLow, _colorScheme.groundColorLow, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor);
		SetMaterialColors(earthMaterial, _colorScheme.earthLightColor, _colorScheme.earthMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(sandMaterial, _colorScheme.sandColor, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor);
		SetMaterialColors(treeMaterial, _colorScheme.treeLightColor, _colorScheme.treeMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(rockMaterial, _colorScheme.rockLightColor, _colorScheme.rockMidColor, _colorScheme.globalShadowColor);
		SetMaterialColors(waterMaterial, _colorScheme.waterLightColor, _colorScheme.waterSecondaryColor, _colorScheme.globalShadowColor);
		SetMaterialColors(oceanMaterial, _colorScheme.waterLightColor, _colorScheme.waterSecondaryColor, _colorScheme.globalShadowColor);
		SetMaterialColors(roadMaterial, _colorScheme.roadColor, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor);
		SetMaterialColors(shadowShapeMaterial, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor);
		SetMaterialColors(dmgFlashMaterial, Color.white, _colorScheme.globalShadowColor, _colorScheme.globalShadowColor);
		SetMaterialColors(treasureChestMaterial, treasureChestMaterial.GetColor("_BaseColor"), treasureChestMaterial.GetColor("_ColorDim"), _colorScheme.globalShadowColor);
		SetMaterialColors(treasureChestAccentMaterial, treasureChestAccentMaterial.GetColor("_BaseColor"), treasureChestAccentMaterial.GetColor("_ColorDim"), _colorScheme.globalShadowColor);
		waterMaterial.SetTextureScale("_BaseMap", waterSettings.riverTextureTiling);
		waterMaterial.SetFloat("_SelfShadingSize", waterSettings.selfShadingSize);
		oceanMaterial.SetTextureScale("_BaseMap", waterSettings.oceanTextureTiling);
		oceanMaterial.SetFloat("_SelfShadingSize", waterSettings.oceanSelfShadingSize);
		if ((bool)bonfireLight)
		{
			bonfireLight.color = _colorScheme.bonfireLightColor;
		}
		currentColorscheme = _colorScheme;
	}

	private void SetMaterialColors(Material _mat, Color _lightCol, Color _midCol, Color _shadowCol)
	{
		_mat.SetColor("_BaseColor", _lightCol);
		_mat.SetColor("_ColorDim", _midCol);
		_mat.SetColor("_ColorDimExtra", _shadowCol);
		_mat.SetColor("_UnityShadowColor", _shadowCol);
		_mat.SetColor("_OutlineColor", _shadowCol);
	}

	public void AdjustAllOutlineColorsBasedOnLight(Color outlineColor, Color lightColor)
	{
		SetOutlineColorBasedOnLight(enemyMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(allyMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(allyRangedMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(playerMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(playerCapeMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(playerCrownMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(horseMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(buildingMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(coinMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(groundMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(earthMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(groundLow, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(groundHigh, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(sandMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(groundPatches, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(treeMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(rockMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(waterMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(oceanMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(dmgFlashMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(treasureChestMaterial, outlineColor, lightColor);
		SetOutlineColorBasedOnLight(treasureChestAccentMaterial, outlineColor, lightColor);
	}

	private void SetOutlineColorBasedOnLight(Material _mat, Color _outlineCol, Color lightCol)
	{
		Color value = Color.Lerp(_outlineCol, _outlineCol * lightCol, _mat.GetFloat("_LightContribution"));
		_mat.SetColor("_OutlineColor", value);
	}

	public void OnDuskEarly()
	{
	}

	public void EasyReloadColorScheme()
	{
		EasySwitchEntireColorSchemeTo(colorscheme);
	}

	public void EasySwitchEntireColorSchemeTo(Colorscheme _colorscheme)
	{
		colorscheme = _colorscheme;
		ApplyColorScheme(_colorscheme);
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			Daylight();
		}
		else
		{
			NightLight();
		}
		if (playerCameraParticles != null)
		{
			UnityEngine.Object.Destroy(playerCameraParticles);
		}
		if ((bool)playerTransform && (bool)colorscheme.particlesToAttachToPlayer)
		{
			playerCameraParticles = UnityEngine.Object.Instantiate(colorscheme.particlesToAttachToPlayer, playerTransform);
			playerCameraParticles.transform.localPosition = Vector3.zero;
		}
		eliteEnemyMaterial = new Material(enemyMaterial);
		eliteEnemyMaterial.SetColor("_OutlineColor", Color.yellow);
		MinimapRenderer.instance.StopAllCoroutines();
		MinimapRenderer.instance.Start();
		Healthbar[] array = UnityEngine.Object.FindObjectsOfType<Healthbar>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateColor();
		}
	}

	public void CycleToNextColorscheme()
	{
		int num = 0;
		int num2 = 0;
		foreach (Colorscheme eternalTrialColorscheme in eternalTrialColorschemes)
		{
			if (eternalTrialColorscheme == colorscheme)
			{
				num = num2;
			}
			num2++;
		}
		num++;
		if (num >= eternalTrialColorschemes.Count)
		{
			num = 0;
		}
		EasySwitchEntireColorSchemeTo(eternalTrialColorschemes[num]);
	}

	public void RegisterBonfireLight(Light bonfire)
	{
		bonfireLight = bonfire;
		bonfireLight.color = currentColorscheme.bonfireLightColor;
	}
}
