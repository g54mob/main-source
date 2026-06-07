using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Behaviours;
using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Common.Cursor;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects
{
	public class InteractiveWorldObject : NimbatusWorldObject
	{
		private class CollectInfo
		{
			public float LastCollectTime;

			public int Count;
		}

		public bool IsCollectable;

		public bool HasExplosion;

		[ShowIf("HasExplosion", true)]
		public NimbatusParticleEffect ExplosionEffect;

		[ShowIf("HasExplosion", true)]
		public bool HasFrozenExplosion;

		[ShowIf("HasExplosion", true)]
		[ShowIf("HasFrozenExplosion", true)]
		public NimbatusParticleEffect FrozenExplosionEffect;

		[ShowIf("HasExplosion", true)]
		public bool HasBurningExplosion;

		[ShowIf("HasExplosion", true)]
		[ShowIf("HasBurningExplosion", true)]
		public NimbatusParticleEffect BurningExplosionEffect;

		[ShowIf("HasExplosion", true)]
		public Transform ExplosionTransform;

		public string DefaultSoundLoop;

		public bool StopSoundLoopWhenFrozen = true;

		[HideInInspector]
		public HealthPool HealthPool;

		[HideInInspector]
		public Spawner Spawner;

		[HideInInspector]
		public int ObjectSeed;

		[OdinSerialize]
		protected internal NimbatusBehaviour Behaviour;

		[HideInInspector]
		public List<InteractiveWorldObjectPart> Parts;

		[HideInInspector]
		public float StartingTime;

		[HideInInspector]
		private static Dictionary<string, CollectInfo> _collectedItems = new Dictionary<string, CollectInfo>();

		public event Action OnFixedUpdate;

		public event Action OnUpdate;

		public event Action OnCollected;

		public event Action OnStart;

		public static event Action<NotificationData> OnNotify;

		public event Action<Collision> OnCollision;

		public int GetCollectCount()
		{
			if (_collectedItems.ContainsKey(UniqueId))
			{
				return _collectedItems[UniqueId].Count;
			}
			return 0;
		}

		public void SendNotification(NotificationData data)
		{
			Action<NotificationData> onNotify = InteractiveWorldObject.OnNotify;
			if (onNotify != null)
			{
				onNotify(data);
			}
		}

		protected override void Start()
		{
			base.Start();
			StartingTime = Time.time;
			Parts = GetComponentsInChildren<InteractiveWorldObjectPart>().ToList();
			foreach (InteractiveWorldObjectPart part in Parts)
			{
				part.Init(this);
			}
			Action action = this.OnStart;
			if (action != null)
			{
				action();
			}
			StartCoroutine(TryToStartSoundLoop());
			BaseSingleton<MissionTargetManager>.Instance.Register(this);
			if (CursorToTarget.Instance != null)
			{
				CursorToTarget.Instance.Register(this);
			}
		}

		public void RemoveSpawner(Spawner spawner)
		{
			Spawner = null;
		}

		public override void Update()
		{
			base.Update();
			Action action = this.OnUpdate;
			if (action != null)
			{
				action();
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			Action action = this.OnFixedUpdate;
			if (action != null)
			{
				action();
			}
		}

		public virtual void OnCollisionEnter(Collision col)
		{
			if (col != null && Rigidbody != null)
			{
				Action<Collision> action = this.OnCollision;
				if (action != null)
				{
					action(col);
				}
			}
		}

		public virtual void InitSpawn(int seed, Spawner spawner = null)
		{
			ObjectSeed = seed;
			Spawner = spawner;
		}

		protected void Release()
		{
			Spawner spawner = Spawner;
			if (spawner != null)
			{
				spawner.RemoveFromSpawner(this);
			}
			StopActiveSoundLoop();
			BaseSingleton<MissionTargetManager>.Instance.UnRegister(this);
			if (HealthPool != null)
			{
				HealthPool.StateChanged -= HealthPool_StateChanged;
			}
		}

		public void Destroy()
		{
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.ObjectDestroyed(UniqueId);
			Release();
			NimbatusBehaviour behaviour = Behaviour;
			if (behaviour != null)
			{
				behaviour.Release();
			}
			if (HasExplosion)
			{
				Transform trans = ((ExplosionTransform != null) ? ExplosionTransform : base.transform);
				if (HealthPool.CurrentState == EChemicalState.Frozen && FrozenExplosionEffect != null && HasFrozenExplosion)
				{
					FrozenExplosionEffect.PlayEffect(trans);
				}
				else if (HealthPool.CurrentState == EChemicalState.Burning && BurningExplosionEffect != null && HasBurningExplosion)
				{
					BurningExplosionEffect.PlayEffect(trans);
				}
				else if (ExplosionEffect != null)
				{
					ExplosionEffect.PlayEffect(trans);
				}
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void Collect()
		{
			if (_collectedItems.ContainsKey(UniqueId))
			{
				if (_collectedItems[UniqueId].LastCollectTime < Time.time - 20f)
				{
					_collectedItems[UniqueId].Count = 0;
				}
				_collectedItems[UniqueId].Count++;
				_collectedItems[UniqueId].LastCollectTime = Time.time;
			}
			else
			{
				_collectedItems.Add(UniqueId, new CollectInfo
				{
					Count = 1,
					LastCollectTime = Time.time
				});
			}
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.ObjectCollected(UniqueId);
			Release();
			Action action = this.OnCollected;
			if (action != null)
			{
				action();
			}
			NimbatusBehaviour behaviour = Behaviour;
			if (behaviour != null)
			{
				behaviour.Release();
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public virtual void OnEnable()
		{
			HealthPool = GetComponent<HealthPool>();
			if (HealthPool != null)
			{
				HealthPool.HasDied += HealthPool_HasDied;
				HealthPool.StateChanged += HealthPool_StateChanged;
			}
			NimbatusSceneManager.OnBeforeSceneChange += NimbatusSceneManagerOnOnBeforeSceneChange;
			NimbatusBehaviour behaviour = Behaviour;
			if (behaviour != null)
			{
				behaviour.Init(this);
			}
		}

		private void HealthPool_StateChanged(EChemicalState from, EChemicalState to)
		{
			if (to == EChemicalState.Frozen)
			{
				SerializableMonobehaviour<MissionManager, MissionData>.Instance.ObjectFrozen(this);
				if (StopSoundLoopWhenFrozen)
				{
					StopActiveSoundLoop();
				}
			}
			if (from == EChemicalState.Frozen && StopSoundLoopWhenFrozen)
			{
				SerializableMonobehaviour<MissionManager, MissionData>.Instance.ObjectUnfrozen(this);
				StopActiveSoundLoop();
				StartSoundLoop(DefaultSoundLoop);
			}
		}

		private void HealthPool_HasDied(object sender, EventArgs e)
		{
			Destroy();
		}

		public override void OnDisable()
		{
			base.OnDisable();
			NimbatusSceneManager.OnBeforeSceneChange -= NimbatusSceneManagerOnOnBeforeSceneChange;
			NimbatusBehaviour behaviour = Behaviour;
			if (behaviour != null)
			{
				behaviour.Release();
			}
			if (HealthPool != null)
			{
				HealthPool.HasDied -= HealthPool_HasDied;
				HealthPool.StateChanged -= HealthPool_StateChanged;
			}
		}

		private void NimbatusSceneManagerOnOnBeforeSceneChange()
		{
			NimbatusBehaviour behaviour = Behaviour;
			if (behaviour != null)
			{
				behaviour.Release();
			}
		}

		public void UnregisterPart(InteractiveWorldObjectPart part)
		{
			if (!Parts.Contains(part))
			{
				return;
			}
			part.transform.parent = null;
			Parts.Remove(part);
			UnityEngine.Object.Destroy(part.gameObject);
			if (!part.DestroyParentWhenDead)
			{
				return;
			}
			foreach (InteractiveWorldObjectPart item in Parts.Where((InteractiveWorldObjectPart p) => p != part).ToList())
			{
				item.HealthPool.Die();
			}
			HealthPool.Die();
		}

		public void SetBehaviourActive(bool activate)
		{
			base.enabled = activate;
		}

		private IEnumerator TryToStartSoundLoop()
		{
			yield return new WaitForEndOfFrame();
			while (RuntimeGlobals.IsGameLoading)
			{
				yield return new WaitForSeconds(0.2f);
			}
			StartSoundLoop(DefaultSoundLoop);
		}
	}
}
