using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors.Objects.Characters
{
	public class MazerellaDancerAnimation
	{
		private struct DanceAnimationStage
		{
			public readonly string AnimationName;

			public readonly bool FlipX;

			public DanceAnimationStage(string animationName, bool flipX)
			{
				AnimationName = null;
				FlipX = false;
			}
		}

		private const string TarantellaTextureName = "character_tarantella";

		private const string CharacterCacheGroupName = "CharacterTextures";

		private const string FemaleCharacterName = "Tarantella_F_";

		private const string MaleCharacterName = "Tarantella_M_";

		private const string KickAnimName = "kick_i0";

		private const string SpinAnimName = "spin_i0";

		private const string FemaleTambourineAnimName = "tamborine_i0";

		private const string MaleTambourineAnimName = "tamborin_i0";

		private const string MaleKick = "Tarantella_M_kick_i0";

		private const string MaleSpin = "Tarantella_M_spin_i0";

		private const string MaleTambourine = "Tarantella_M_tamborin_i0";

		private const string FemaleKick = "Tarantella_F_kick_i0";

		private const string FemaleSpin = "Tarantella_F_spin_i0";

		private const string FemaleTambourine = "Tarantella_F_tamborine_i0";

		private SpriteRenderer _spriteRenderer;

		private SpriteAnimation _spriteAnimation;

		private int _currentAnimationStageIndex;

		private readonly List<DanceAnimationStage> _danceAnimationStages;

		private static string KickAnimationName(EnemyMazerellaDancer.DancerSide dancerSide)
		{
			return null;
		}

		private static string SpinAnimationName(EnemyMazerellaDancer.DancerSide dancerSide)
		{
			return null;
		}

		private static string TambourineAnimationName(EnemyMazerellaDancer.DancerSide dancerSide)
		{
			return null;
		}

		public void InitAnims(SpriteRenderer spriteRenderer, SpriteAnimation spriteAnimation, EnemyMazerellaDancer.DancerSide dancerSide)
		{
		}

		private void AddDanceAnim(string animName, string textureName, int frameCount, int fps)
		{
		}

		private void PlayNextAnimationStage()
		{
		}

		private void PlayAnimationStage(int stageIndex)
		{
		}

		private List<string> MakeAnimFrameList(string animName, int frameCount)
		{
			return null;
		}
	}
}
