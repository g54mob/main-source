using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class InkToColorAnimator : MonoBehaviour
	{
		public Material inkMat;

		private Color _inkColor;

		private float _inkMetallic;

		private float _inkSmoothness;

		public AnimationCurve curve;

		private float curveTime;

		public bool lerpToColor;

		public float lerpTimeMultiplier;

		private List<Material> _mats;

		private List<Color> _colors;

		private List<float> _metallic;

		private List<float> _smoothness;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
