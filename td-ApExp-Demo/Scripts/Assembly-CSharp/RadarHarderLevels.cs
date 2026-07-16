using UnityEngine;

[CreateAssetMenu(fileName = "18HarderLevels", menuName = "Radar/18HarderLevels")]
public class RadarHarderLevels : EnhancementRadar
{
	[SerializeField]
	private float easyProbChange = -0.3f;

	[SerializeField]
	private float mediumProbChange = 0.2f;

	[SerializeField]
	private float hardProbChange = 0.1f;

	private bool added;

	public override void OnApplied()
	{
	}

	public override void OnRemoved()
	{
	}
}
