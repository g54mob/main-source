using QFSW.MOP2;
using UnityEngine;

namespace VampireSurvivors.Objects.VFX
{
	public class EME_ShowstopperVfx : PoolableMonoBehaviour
	{
		[SerializeField]
		private Transform _transform;

		[SerializeField]
		private MeshRenderer _Model1;

		private static readonly int _ScrollSpeedX;

		private static readonly int _ScrollSpeedY;

		private static readonly int _AlphaMul;

		private void Awake()
		{
		}

		public void Reset()
		{
		}

		public void FadeOut()
		{
		}

		private void Cleanup()
		{
		}
	}
}
