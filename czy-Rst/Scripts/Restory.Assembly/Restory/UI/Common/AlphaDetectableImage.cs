using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Common
{
	public class AlphaDetectableImage : Image
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float alphaHitTestMinimumThresholdOverride = 0.1f;

		protected override void Awake()
		{
			base.Awake();
			base.alphaHitTestMinimumThreshold = alphaHitTestMinimumThresholdOverride;
		}
	}
}
