using ManagementScripts;
using SettingScripts;
using UnityEngine;
using Utility;

namespace OneUseScripts
{
	public class BackgroundManager : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer backgroundSR;

		[SerializeField]
		private GameObject microscopeShade;

		private Material background;

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private static readonly int SimSize = Shader.PropertyToID("_SimSize");

		private static readonly int ShadeFadeDistance = Shader.PropertyToID("_ShadeFadeDistance");

		private static readonly int ShadeStart = Shader.PropertyToID("_ShadeStart");

		private static readonly int ShadeEnd = Shader.PropertyToID("_ShadeEnd");

		private static readonly int ShowGrid = Shader.PropertyToID("_showGrid");

		private static readonly int LineColor1 = Shader.PropertyToID("_LineColor");

		private static readonly int LineColor2 = Shader.PropertyToID("_LineColor2");

		private static readonly int LineStep = Shader.PropertyToID("_LineStep");

		private static readonly int LineStep2 = Shader.PropertyToID("_LineStep2");

		private static readonly int LineWidth = Shader.PropertyToID("_LineWidth");

		private static readonly int LineWidth2 = Shader.PropertyToID("_LineWidth2");

		private static readonly int LineAlpha1 = Shader.PropertyToID("_LineAlpha");

		private static readonly int LineAlpha2 = Shader.PropertyToID("_LineAlpha2");

		private static readonly int ShowTexture = Shader.PropertyToID("_ShowTexture");

		private static readonly int CellColor = Shader.PropertyToID("_CellColor");

		private float fineThreshold = 1f;

		private float coarseThreshold = 1f;

		public static float SimulationSize;

		private const float FadeStart = 0.5f;

		public const float ShadeStartFactor = 1.5f;

		private Camera cam;

		public static float shadeStart => 1.5f * ScenarioIndependentSettings.Instance.SimulationSize.val;

		public static float shadeEnd => shadeStart + shadeFadeLength;

		public static float shadeFadeLength => 1000f;

		private void Start()
		{
			background = backgroundSR.material;
			cam = Camera.main;
			UserSettings.BackgroundColor.Subscribe(UpdateBackgroundColor);
			ScenarioSettings.Instance.shadeOutsideOfBounds.Subscribe(UpdateShade);
			UpdateShade(ScenarioSettings.Instance.shadeOutsideOfBounds.val);
			UpdateBackgroundColor();
			ScenarioIndependentSettings.Instance.SimulationSize.Subscribe(UpdateSimSize);
			UserSettings.ShowGrid.Subscribe(UpgradeBackgroundLines);
			UserSettings.GridColor1.Subscribe(UpgradeBackgroundLines);
			UserSettings.GridStep1.Subscribe(UpgradeBackgroundLines);
			UserSettings.GridLineWidth1.Subscribe(UpgradeBackgroundLines);
			UserSettings.GridColor2.Subscribe(UpgradeBackgroundLines);
			UserSettings.GridStep2.Subscribe(UpgradeBackgroundLines);
			UserSettings.GridLineWidth2.Subscribe(UpgradeBackgroundLines);
			UpdateSimSize(ScenarioIndependentSettings.Instance.SimulationSize.val);
			UpgradeBackgroundLines();
			UserSettings.ShowTexture.Subscribe(UpdateTexture);
			UserSettings.TextureColor.Subscribe(UpdateTextureColor);
			UpdateTexture();
			UpdateTextureColor();
			CameraManager.onCameraSizeChange.AddListener(UpdateLinesAlpha);
			ScreenChangeDetector.onScreenDimensionChange.AddListener(UpdateLineThresholds);
		}

		public void UpdateShade(bool shade)
		{
			microscopeShade.SetActive(shade);
		}

		public void UpdateBackgroundColor()
		{
			background.SetColor(Color1, UserSettings.BackgroundColor.val);
		}

		public void UpdateSimSize(float val)
		{
			SimulationSize = val;
			Shader.SetGlobalFloat(SimSize, val);
			Shader.SetGlobalFloat(ShadeFadeDistance, shadeFadeLength);
			Shader.SetGlobalFloat(ShadeStart, shadeStart);
			Shader.SetGlobalFloat(ShadeEnd, shadeEnd);
		}

		public void UpgradeBackgroundLines()
		{
			background.SetInt(ShowGrid, UserSettings.ShowGrid.val ? 1 : 0);
			background.SetColor(LineColor1, UserSettings.GridColor1.val);
			background.SetColor(LineColor2, UserSettings.GridColor2.val);
			background.SetFloat(LineStep, UserSettings.GridStep1.val);
			background.SetFloat(LineStep2, UserSettings.GridStep1.val * UserSettings.GridStep2.val);
			background.SetFloat(LineWidth, UserSettings.GridLineWidth1.val);
			background.SetFloat(LineWidth2, UserSettings.GridLineWidth1.val * (float)UserSettings.GridLineWidth2.val);
			UpdateLineThresholds();
		}

		public void UpdateTexture()
		{
			background.SetInt(ShowTexture, UserSettings.ShowTexture.val ? 1 : 0);
		}

		public void UpdateTextureColor()
		{
			background.SetColor(CellColor, UserSettings.TextureColor.val);
		}

		private void UpdateLineThresholds()
		{
			fineThreshold = (float)Mathf.Min(Screen.height, Screen.width) * UserSettings.GridLineWidth1.val / 2f;
			coarseThreshold = fineThreshold * (float)UserSettings.GridLineWidth2.val;
			UpdateLinesAlpha(cam.orthographicSize);
		}

		public void UpdateLinesAlpha(float camSize)
		{
			if (camSize / fineThreshold < 0.5f)
			{
				background.SetFloat(LineAlpha1, 1f);
			}
			else if (camSize / fineThreshold < 1f)
			{
				background.SetFloat(LineAlpha1, (1f - camSize / fineThreshold) / 0.5f);
			}
			else
			{
				background.SetFloat(LineAlpha1, 0f);
			}
			if (camSize / coarseThreshold < 0.5f)
			{
				background.SetFloat(LineAlpha2, 1f);
			}
			else if (camSize / coarseThreshold < 1f)
			{
				background.SetFloat(LineAlpha2, (1f - camSize / coarseThreshold) / 0.5f);
			}
			else
			{
				background.SetFloat(LineAlpha2, 0f);
			}
		}

		private void OnDestroy()
		{
			UserSettings.BackgroundColor.UnSubscribe(UpdateBackgroundColor);
			ScenarioSettings.Instance.shadeOutsideOfBounds.UnSubscribe(UpdateShade);
			ScenarioIndependentSettings.Instance.SimulationSize.UnSubscribe(UpdateSimSize);
			UserSettings.ShowGrid.UnSubscribe(UpgradeBackgroundLines);
			UserSettings.GridColor1.UnSubscribe(UpgradeBackgroundLines);
			UserSettings.GridStep1.UnSubscribe(UpgradeBackgroundLines);
			UserSettings.GridLineWidth1.UnSubscribe(UpgradeBackgroundLines);
			UserSettings.GridColor2.UnSubscribe(UpgradeBackgroundLines);
			UserSettings.GridStep2.UnSubscribe(UpgradeBackgroundLines);
			UserSettings.GridLineWidth2.UnSubscribe(UpgradeBackgroundLines);
			UserSettings.ShowTexture.UnSubscribe(UpdateTexture);
			UserSettings.TextureColor.UnSubscribe(UpdateTextureColor);
			ScreenChangeDetector.onScreenDimensionChange.RemoveListener(UpdateLineThresholds);
		}
	}
}
