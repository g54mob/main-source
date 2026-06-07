using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class FightTornado : GameObjectX
	{
		public static readonly HashSet<FightTornado> AllFightTornadoes;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		internal Actor _fightOrigin;

		private readonly List<Tuple<float, Actor>> _involvedActors;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private readonly List<Actor> _actorsToThrowOut;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private readonly List<Actor> _currentActorsToSuckIn;

		private const float IntensityDecreasePerSecond = -3.3333333f;

		private IRng _rng;

		[PersistenceOptIn]
		private bool _isDying;

		private ParticleSystem[] _particleSystems;

		private const int MinSecondsParticipating = 5;

		private const float SuctionPower = 8f;

		private const float JoinFightDistance = 1f;

		private const float AttractionDistance = 3f;

		private const float MinPeekOutDelay = 2f;

		private const float MaxPeekOutDelay = 4f;

		[PersistenceOptIn]
		private float _nextPeekOut;

		[PersistenceOptIn]
		private readonly Dictionary<int, Vector3> _throwOutDirections;

		private static readonly float DamagePerSecond;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private readonly List<Prop> _currentProps;

		[PersistenceOptIn]
		private float _nextDirectionChange;

		[PersistenceOptIn]
		private Vector3 _currentTarget;

		private GameObject _selectionIndicator;

		[PersistenceOptIn]
		public float Energy { get; private set; }

		[PersistenceOptIn]
		public float DamageDone { get; private set; }

		[PersistenceOptIn]
		public int TotalPeopleInvolved { get; private set; }

		[PersistenceOptIn]
		public float LifeTime { get; private set; }

		[PersistenceOptIn]
		public float AngerConsumed { get; private set; }

		public IEnumerable<Actor> ActorsParticipating => null;

		protected FightTornado()
		{
		}

		public bool IsAboutToEnd()
		{
			return false;
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		private void StopParticles()
		{
		}

		public void OnFightStart(string reasonKey)
		{
		}

		public void AddActor(Actor actor)
		{
		}

		protected override void UpdateInternal()
		{
		}

		public void FixedUpdate()
		{
		}

		private void UpdateEnergy()
		{
		}

		private void StartActorEndAnimation(Actor actor, bool flyout)
		{
		}

		private void DestroyTornado()
		{
		}

		private string GetDamageModifierKey()
		{
			return null;
		}

		private void RemoveAllDamageModifiersFromProps()
		{
		}

		private void SpawnRubbish()
		{
		}

		private void SuckInActors()
		{
		}

		private void UpdateActorPositions()
		{
		}

		private void UpdateActorsPeekingOut()
		{
		}

		private void ThrowOutActors()
		{
		}

		private void ExcludeFromFight(Actor actor)
		{
		}

		private void UpdatePropsToDamage()
		{
		}

		private GameObjectX GetPreferredTarget()
		{
			return null;
		}

		private void UpdateMovement()
		{
		}

		public override IEnumerable<ContextMenuItem> GetAvailableManualJobs(Staff staff)
		{
			return null;
		}

		private static void UpdateFightAudioIntensity()
		{
		}

		public override void OnDestroy()
		{
		}

		public override bool CanSelect()
		{
			return false;
		}

		public override bool IsHighlighted()
		{
			return false;
		}

		public override void AddHighlight(Color? color = null)
		{
		}

		public override void RemoveHighlight()
		{
		}

		public override void SaveState(IDataStore data)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}
	}
}
