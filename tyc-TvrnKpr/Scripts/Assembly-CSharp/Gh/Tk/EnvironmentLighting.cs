using UnityEngine;
using UnityEngine.PostProcessing;

namespace Gh.Tk
{
	public class EnvironmentLighting : MonoBehaviour
	{
		public PostProcessingProfile postProcProfile;

		private UserLutModel.Settings lutSettings;

		public AnimationCurve lutCurve;

		private float _trilightGradientOffset;

		public AnimationCurve colourGradientCurve;

		public Gradient sunGradient;

		public Color ambientOffsetTop;

		public bool useAmbientOffsetTopGradient;

		public Gradient ambientOffsetTopGradient;

		public Color ambientOffsetSide;

		public bool useAmbientOffsetSideGradient;

		public Gradient ambientOffsetSideGradient;

		public Color ambientOffsetBottom;

		public bool useAmbientOffsetBottomGradient;

		public Gradient ambientOffsetBottomGradient;

		private float _currentDayf;

		private void OnEnable()
		{
		}

		private void ResetCurrentDayF()
		{
		}

		private void Update()
		{
		}
	}
}
