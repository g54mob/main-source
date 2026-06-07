using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class SetOccluderTransparency : MonoBehaviour
	{
		public List<MeshRenderer> occluderMeshes;

		private readonly List<Color> _colors;

		public List<ParticleSystem> particles;

		private readonly List<Color> _psColors;

		public float blendTimeMultiplier;

		public float UnoccludedDelayTime;

		public AnimationCurve smoothingCurve;

		public bool occluding;

		public Color alphaMin;

		private bool _opaqueTimer;

		private float _currentUnoccludedDelayTimer;

		private float _blendPercentage;

		public Buildable Buildable;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
