using UnityEngine;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects
{
	public class MagnetZone : ArcadeSprite
	{
		private SpriteRenderer _renderer;

		private Transform _cachedTransform;

		private VampireSurvivors.Objects.Characters.CharacterController _targetCharacter;

		public EggFloat Radius;

		public VampireSurvivors.Objects.Characters.CharacterController TargetCharacter => null;

		private void Awake()
		{
		}

		public void Init(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void RefreshSize()
		{
		}
	}
}
