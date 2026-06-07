using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Serialization;

namespace VampireSurvivors.Objects.VFX
{
	public class OrologionVfx : PoolableMonoBehaviour
	{
		[FormerlySerializedAs("_screenFillRenderer")]
		[SerializeField]
		private SpriteRenderer _ScreenFillRenderer;

		[FormerlySerializedAs("_shockwaveRenderer")]
		[SerializeField]
		private SpriteRenderer _ShockwaveRenderer;

		private float _worldScreenHeight;

		private float _worldScreenWidth;

		private Transform _originalParent;

		private void Awake()
		{
		}

		public void SetParent(Transform newParent)
		{
		}

		public void Play()
		{
		}

		private void Init()
		{
		}

		private void PerformScreenFill()
		{
		}

		private void PerformShockwave()
		{
		}

		private void Cleanup()
		{
		}

		private void ResetParent()
		{
		}
	}
}
