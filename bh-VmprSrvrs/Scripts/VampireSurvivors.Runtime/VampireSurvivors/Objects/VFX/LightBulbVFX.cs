using System.Collections.Generic;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.VFX
{
	public class LightBulbVFX : PoolableMonoBehaviour
	{
		[FormerlySerializedAs("_screenFillRenderer")]
		[SerializeField]
		private SpriteRenderer _ScreenFillRenderer;

		private Timer _timer;

		private Transform _originalParent;

		private PhaserSprite _StarSprite;

		private PhaserSprite _BulbSprite;

		private float _orthographicSize;

		private PhaserText _techniqueNameText;

		private PhaserSprite _techniqueNameBackground;

		private List<Transform> _originalCameraTargets;

		private void Awake()
		{
		}

		public void setDepth(int depth)
		{
		}

		public void SetParent(Transform newParent)
		{
		}

		public void Play(string techniqueName, float volume = 1.8f)
		{
		}

		private void SetupTextBox(string techniqueName)
		{
		}

		public void EndEffect()
		{
		}

		private void Cleanup()
		{
		}

		private void SetupScreenFill()
		{
		}

		private void ResetParent()
		{
		}
	}
}
