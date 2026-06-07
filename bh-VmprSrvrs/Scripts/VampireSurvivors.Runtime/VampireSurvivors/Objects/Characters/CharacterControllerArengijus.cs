using Coherence.Toolkit;
using Unity.Mathematics;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerArengijus : CharacterController
	{
		private Random _initializationRng;

		public int SyncedStartingWeaponType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		public int NameIndex { get; set; }

		[Sync]
		public uint InitializationSeed { get; set; }

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}
	}
}
