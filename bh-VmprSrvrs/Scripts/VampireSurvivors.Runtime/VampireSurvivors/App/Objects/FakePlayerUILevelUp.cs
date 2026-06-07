using I2.Loc;
using TMPro;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.App.Objects
{
	public class FakePlayerUILevelUp : GameMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _ProgressBox;

		[SerializeField]
		private PhaserSprite _ProgressBar;

		[SerializeField]
		private TextMeshPro _PlayerLevelText;

		private int _level;

		private float _value;

		private readonly LocalizedString _playerLevelString;

		private Color _defaultBarColor;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Init(float xPos, float yPos)
		{
		}

		private void UpdateLevelDisplay()
		{
		}
	}
}
