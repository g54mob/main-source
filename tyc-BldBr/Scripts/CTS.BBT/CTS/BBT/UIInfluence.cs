using UnityEngine;
using UnityEngine.UI;

namespace CTS.BBT
{
	public class UIInfluence : MonoBehaviour
	{
		[SerializeField]
		private Slider _standingSlider;

		[SerializeField]
		private Slider _ethicsSlider;

		[SerializeField]
		private Slider _atmosphereSlider;

		private void OnEnable()
		{
			InfluenceManager.InfluenceChanged += OnInfluenceChanged;
		}

		private void OnDisable()
		{
			InfluenceManager.InfluenceChanged -= OnInfluenceChanged;
		}

		private void OnInfluenceChanged()
		{
		}
	}
}
