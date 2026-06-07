using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/FX Settings")]
public class FXSettings : ScriptableObject
{
	[Header("Particles")]
	[Tooltip("Splash particles.")]
	public ParticleController Splash;

	[Tooltip("Building Radius Visualizer")]
	public CircleWaveHighlighter BuildingRadiusPrefab;

	public Color BuildingRadiusColor = new Vector4(1f, 0f, 0f, 0.5f);

	[Tooltip("The prefab of the circlewaveHighlighter.")]
	public CircleWaveHighlighter CircleHighlighterPrefab;

	public Color SwimmingRangeHighlighterColor = new Vector4(1f, 0f, 0f, 0.5f);

	public Color BoatRangeHighlighterColor = new Vector4(1f, 1f, 0f, 0.5f);

	public Color MarkerNotSelectedInsideSwimmingHighlightRadiusColor = new Vector4(1f, 0f, 0f, 0.5f);

	public Color MarkerNotSelectedOutsideSwimmingHighlightRadiusColor = new Vector4(1f, 0f, 0f, 0.5f);

	[Space]
	[Tooltip("Particle Effects.")]
	public ParticleEffect[] ParticleEffects;

	[Space]
	public PolygonLineRenderer PolygonLineRenderer;

	[Space]
	public TextPopup TextPopupPrefab;
}
