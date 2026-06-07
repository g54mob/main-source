using Data.Variables;
using FronkonGames.Artistic.TiltShift;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "Variables/Settings/TiltShift", fileName = "TiltShiftSO", order = 0)]
public class TiltShiftSO : BoolVariableSO
{
	[SerializeField]
	private QualityLevelSO _qualityLevelSO;

	[SerializeField]
	private UniversalRendererData _universalRendererDataLow;

	[SerializeField]
	private UniversalRendererData _universalRendererDataMedium;

	[SerializeField]
	private UniversalRendererData _universalRendererDataHigh;

	public override void SetValue(bool value)
	{
		base.SetValue(value);
		TiltShift currentTiltShift = GetCurrentTiltShift();
		if ((bool)currentTiltShift)
		{
			currentTiltShift.SetActive(value);
		}
	}

	public TiltShift GetCurrentTiltShift()
	{
		UniversalRendererData universalRendererData = null;
		switch (_qualityLevelSO.Value)
		{
		case 0:
			universalRendererData = _universalRendererDataHigh;
			break;
		case 1:
			universalRendererData = _universalRendererDataMedium;
			break;
		case 2:
			universalRendererData = _universalRendererDataLow;
			break;
		}
		if (universalRendererData != null)
		{
			foreach (ScriptableRendererFeature rendererFeature in universalRendererData.rendererFeatures)
			{
				if (rendererFeature is TiltShift result)
				{
					return result;
				}
			}
		}
		return null;
	}
}
