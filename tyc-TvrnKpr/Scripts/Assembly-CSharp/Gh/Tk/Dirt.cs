using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class Dirt : DirtBase
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsInfested;

		public static int IsInfestedPriorityModifier;

		public static int PukePriorityModifier;

		[PersistenceOptIn]
		private float _createNestDayF;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _wasOnFire;

		[PersistenceOptIn]
		private IRng _rng;

		private const float MinFilthForInfestation = 2f;

		private const float MinTemperatureForInfestation = 0f;

		private static float InfestationChanceModifier { get; set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		public SicknessTrait SourceSickness { get; set; }

		private IRng RngInstance => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override void Start()
		{
		}

		public void AddDirt(DirtType dirtType, Vector3 position, Quaternion? rotation = null, int strength = 1, string uniqueKeyFilterOverride = null, bool changeFilth = true)
		{
		}

		protected override void SetFilth(float filth)
		{
		}

		private void IncreaseFilth(float delta)
		{
		}

		protected override void UpdateInternal()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		private void UpdateTintRenderers()
		{
		}

		private void EnableInfestedBugs(bool enable)
		{
		}

		public override bool CanUseDirectly(Actor actor)
		{
			return false;
		}
	}
}
