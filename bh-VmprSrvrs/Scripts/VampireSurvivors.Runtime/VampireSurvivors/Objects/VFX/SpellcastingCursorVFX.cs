using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.VFX
{
	public class SpellcastingCursorVFX : PoolableMonoBehaviour
	{
		private Transform _originalParent;

		private PhaserSprite _cursor;

		private MultiTargetTween _cursorTween;

		private PhaserSprite _cursorAdd;

		private MultiTargetTween _cursorAddTween;

		private void Awake()
		{
		}

		public void SetParent(Transform newParent)
		{
		}

		public void Display(int _times, float _duration, Vector3 position, float angle, string texture, string frame, bool flip = false)
		{
		}

		private void StartDespawn()
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
