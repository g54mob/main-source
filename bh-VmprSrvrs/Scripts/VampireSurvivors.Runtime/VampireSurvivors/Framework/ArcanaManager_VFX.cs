using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Framework
{
	public class ArcanaManager_VFX
	{
		private GameObject _SapphireMistGO;

		private bool _SapphireMist_Ready;

		private ParticleEmitterManager _SapphireMist_PFXManager;

		private ParticleSystem _SapphireMist_pfxEmitter;

		private ParticleSystem _SapphireMist_pfxEmitter2;

		private GravityWell _SapphireMist_well;

		private VampireSurvivors.Objects.Characters.CharacterController _SapphireMist_LastUser;

		private Vector3 _SapphireMist_GravityWellOffset;

		private List<float> _sapphireMistDetunes;

		private int _sapphireMistDetunesIndex;

		public WorldEaterVFX WorldEaterVFX;

		public void Play_SapphireMist(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void Play_WorldEater(VampireSurvivors.Objects.Characters.CharacterController character, bool isCursed = false)
		{
		}

		public void Update()
		{
		}

		public static List<float> MakeDetunes(int amount = 100, int min = -1000, int max = 1000, bool shuffle = true)
		{
			return null;
		}

		public void Generate_SapphireMist()
		{
		}
	}
}
