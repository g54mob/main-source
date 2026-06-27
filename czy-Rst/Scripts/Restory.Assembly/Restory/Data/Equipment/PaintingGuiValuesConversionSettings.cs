using Helpers.Ranges;
using UnityEngine;
using UnityEngine.Serialization;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "PaintingGuiValuesConversionSettings", menuName = "Restory/Equipment/DevicePainter/PaintingGuiValuesConversionSettings")]
	public class PaintingGuiValuesConversionSettings : ScriptableObject
	{
		[FormerlySerializedAs("softEdgeBrush")]
		[SerializeField]
		private ConcentricCirclesBrushMultiRaycasterSettings softEdgeMultiBrush;

		[FormerlySerializedAs("hardEdgeBrush")]
		[SerializeField]
		private ConcentricCirclesBrushMultiRaycasterSettings hardEdgeMultiBrush;

		[SerializeField]
		private SmallSingleBrushRaycasterSettings softEdgeSmallBrush;

		[SerializeField]
		private SmallSingleBrushRaycasterSettings hardEdgeSmallBrush;

		[FormerlySerializedAs("opacityToAlphaMultiplierCurve")]
		[SerializeField]
		private AnimationCurve multiBrushOpacityToAlphaMultiplierCurve;

		[SerializeField]
		private AnimationCurve smallBrushOpacityToAlphaMultiplierCurve;

		[SerializeField]
		private int switchBetweenNormalAndSmallBrushSizeSliderThreshold = 10;

		[SerializeField]
		private FloatRange multiBrushMinMaxSize = new FloatRange
		{
			Min = 0.1f,
			Max = 8f
		};

		[SerializeField]
		private FloatRange smallBrushMinMaxSize = new FloatRange
		{
			Min = 0.35f,
			Max = 1f
		};

		public AnimationCurve MultiBrushOpacityToAlphaMultiplierCurve => multiBrushOpacityToAlphaMultiplierCurve;

		public AnimationCurve SmallBrushOpacityToAlphaMultiplierCurve => smallBrushOpacityToAlphaMultiplierCurve;

		public ConcentricCirclesBrushMultiRaycasterSettings HardEdgeMultiBrush => hardEdgeMultiBrush;

		public ConcentricCirclesBrushMultiRaycasterSettings SoftEdgeMultiBrush => softEdgeMultiBrush;

		public int SwitchBetweenNormalAndSmallBrushSizeSliderThreshold => switchBetweenNormalAndSmallBrushSizeSliderThreshold;

		public FloatRange MultiBrushMinMaxSize => multiBrushMinMaxSize;

		public FloatRange SmallBrushMinMaxSize => smallBrushMinMaxSize;

		public SmallSingleBrushRaycasterSettings SoftEdgeSmallBrush => softEdgeSmallBrush;

		public SmallSingleBrushRaycasterSettings HardEdgeSmallBrush => hardEdgeSmallBrush;
	}
}
