using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.GalaxyMap.CombatArena;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Sirenix.OdinInspector;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Health
{
	public class HealthPool : SerializedMonoBehaviour
	{
		public SkeletonAnimation HitAnimation;

		public bool HasHealthBar;

		[ShowIf("HasHealthBar", true)]
		public Transform HealthBarTransform;

		public bool CustomRenderers;

		[ShowIf("CustomRenderers", true)]
		public List<GameObject> AffectedRenderers;

		public bool IsInvincible;

		[HideIf("IsInvincible", true)]
		public float MaxHealth = 100f;

		private float _activeModifier = 1f;

		public int HeatResistance;

		public int ColdResistance;

		public bool IgnoreBurningDamage;

		public bool DisableTemperatureRegulation;

		private TrackEntry _currentAnim;

		private bool _isShowingDamage;

		private bool _showHealthbar;

		private List<ColorizedRenderer> _renderers;

		private AudioObject _audioLoop;

		private bool _isPlaying;

		[HideInInspector]
		public float LastDamageTime;

		[HideInInspector]
		public bool IsDead;

		private float _currentHealth;

		private float _currentTemperature;

		private EChemicalState _currentState;

		private Collider _collider;

		private Dictionary<EHealthModifier, float> _healthMod = new Dictionary<EHealthModifier, float>();

		private HealthBarDisplay _healthBar;

		private float _lastDamageTime;

		private float _burningStartTime;

		private bool _initialized;

		[HideInInspector]
		public float ActiveMaxHealth
		{
			get
			{
				return MaxHealth * _activeModifier;
			}
		}

		[HideInInspector]
		public EChemicalState CurrentState
		{
			get
			{
				return _currentState;
			}
			private set
			{
				EChemicalState currentState = _currentState;
				_currentState = value;
				if (currentState != _currentState)
				{
					StopActiveSoundLoop();
					if (_currentState == EChemicalState.Frozen)
					{
						StartSoundLoop("FrozenSFX_PN");
					}
					else if (_currentState == EChemicalState.Burning)
					{
						StartSoundLoop("BurningSFX_PN");
					}
					Action<EChemicalState, EChemicalState> action = this.StateChanged;
					if (action != null)
					{
						action(currentState, _currentState);
					}
				}
			}
		}

		[HideInInspector]
		public float CurrentTemperature
		{
			get
			{
				return _currentTemperature;
			}
			private set
			{
				float currentTemperature = _currentTemperature;
				_currentTemperature = value;
				UpdateRenderers();
				Action<float, float> action = this.TemperatureChanged;
				if (action != null)
				{
					action(currentTemperature, _currentTemperature);
				}
			}
		}

		[HideInInspector]
		public float CurrentHealth
		{
			get
			{
				return _currentHealth;
			}
			private set
			{
				float currentHealth = _currentHealth;
				if (Math.Abs(currentHealth - value) > 1E-06f)
				{
					if (currentHealth > value)
					{
						LastDamageTime = Time.time;
					}
					_currentHealth = value;
					Action<float, float> action = this.HealthChanged;
					if (action != null)
					{
						action(currentHealth, _currentHealth);
					}
				}
			}
		}

		public event EventHandler HasDied;

		public event Action<EChemicalState, EChemicalState> StateChanged;

		public event Action<float, float> HealthChanged;

		public event Action<float, float> TemperatureChanged;

		public event Action<HealthPool, DamageInformation> DamageTaken;

		protected void Awake()
		{
			Init();
		}

		public void Init()
		{
			if (!_initialized)
			{
				IsDead = false;
				_currentTemperature = 0f;
				_activeModifier = 1f;
				_showHealthbar = false;
				_collider = GetComponent<Collider>();
				_renderers = new List<ColorizedRenderer>();
				_healthMod = new Dictionary<EHealthModifier, float>();
				if (BaseSingleton<CollisionLayerManager>.Instance.IsLayer(BaseSingleton<CollisionLayerManager>.Instance.EnemyHealthLayer, base.gameObject.layer))
				{
					SetHealthModifier(EHealthModifier.SandboxSetting, (float)RuntimeGlobals.GameModeSettings.EnemyHealth / 100f);
				}
				CurrentHealth = ActiveMaxHealth;
				_initialized = true;
			}
		}

		protected void OnEnable()
		{
			StartCoroutine(UpdateTemperature());
			if (HasHealthBar)
			{
				if (_healthBar == null)
				{
					Transform healthBarTransform = base.gameObject.transform;
					if (HealthBarTransform != null)
					{
						healthBarTransform = HealthBarTransform;
					}
					_healthBar = UnityEngine.Object.Instantiate(BaseSingleton<CollisionLayerManager>.Instance.HealthBarPrefab, healthBarTransform);
					Vector3 localPosition = _healthBar.transform.localPosition;
					localPosition.z = -10f;
					_healthBar.transform.localPosition = localPosition;
					_healthBar.Init(this);
					_healthBar.gameObject.SetActive(false);
				}
				StartCoroutine(UpdateHealthbar());
			}
			if (BaseSingleton<ChemicalManager>.Instance != null)
			{
				BaseSingleton<ChemicalManager>.Instance.Register(this);
			}
		}

		protected void OnDisable()
		{
			StopAllCoroutines();
			_isShowingDamage = false;
			UpdateRenderers();
			if (BaseSingleton<ChemicalManager>.Instance != null)
			{
				BaseSingleton<ChemicalManager>.Instance.Unregister(this);
			}
		}

		public void Start()
		{
			if (HitAnimation != null)
			{
				HitAnimation.AnimationState.End += AnimationState_End;
			}
			if (CustomRenderers && AffectedRenderers != null && AffectedRenderers.Count > 0)
			{
				foreach (GameObject affectedRenderer in AffectedRenderers)
				{
					FillUpRenderers(affectedRenderer);
				}
			}
			else
			{
				FillUpRenderers(base.gameObject);
			}
			if (BaseSingleton<ChemicalManager>.Instance != null)
			{
				BaseSingleton<ChemicalManager>.Instance.Register(this);
			}
		}

		public void ResetModifier(EHealthModifier mod)
		{
			_activeModifier = 1f;
			if (_healthMod.ContainsKey(mod))
			{
				_healthMod.Remove(mod);
			}
			CalculateModifier();
		}

		public void SetHealthModifier(EHealthModifier modType, float value)
		{
			if (_healthMod.ContainsKey(modType))
			{
				_healthMod[modType] = value;
			}
			else
			{
				_healthMod.Add(modType, value);
			}
			CalculateModifier();
		}

		private void CalculateModifier()
		{
			if (_healthMod.Count > 0)
			{
				float num = 1f;
				foreach (KeyValuePair<EHealthModifier, float> item in _healthMod)
				{
					num *= item.Value;
				}
				_activeModifier = num;
			}
			else
			{
				_activeModifier = 1f;
			}
			CurrentHealth = ActiveMaxHealth;
		}

		public void AddRenderer(tk2dSprite sprite)
		{
			_renderers.Add(new ColorizedRendererTk2d(sprite));
		}

		private void FillUpRenderers(GameObject go)
		{
			SpriteRenderer component = go.GetComponent<SpriteRenderer>();
			if (component != null)
			{
				_renderers.Add(new ColorizedRendererSprite(component));
			}
			tk2dSprite component2 = go.GetComponent<tk2dSprite>();
			if (component2 != null)
			{
				_renderers.Add(new ColorizedRendererTk2d(component2));
			}
			SkeletonRenderer component3 = go.GetComponent<SkeletonRenderer>();
			if (component3 != null)
			{
				_renderers.Add(new ColorizedRendererSpine(component3));
			}
			SkeletonAnimation component4 = go.GetComponent<SkeletonAnimation>();
			if (component4 != null)
			{
				_renderers.Add(new ColorizedRendererSpine(component4));
			}
		}

		private void UpdateRenderers()
		{
			foreach (ColorizedRenderer renderer in _renderers)
			{
				Color color = Color.white;
				if (CurrentTemperature > 0f)
				{
					color = new Color(0.01f * CurrentTemperature, _isShowingDamage ? 1 : 0, 0f, 0f);
				}
				else if (CurrentTemperature < 0f)
				{
					color = new Color(0f, _isShowingDamage ? 1 : 0, 0.01f * Mathf.Abs(CurrentTemperature), 0f);
				}
				else if (_isShowingDamage)
				{
					color = new Color(0f, _isShowingDamage ? 1 : 0, 0f, 0f);
				}
				renderer.SetColor(color);
			}
		}

		public void TakeDamageSimple(float amount, EDamageReason reason)
		{
			TakeDamage(new DamageInformation(amount, reason));
		}

		public void TakeDamage(DamageInformation damage)
		{
			if (IsInvincible || IsDead)
			{
				return;
			}
			float num = damage.DamageAmount;
			if (damage.Reason == EDamageReason.Enemy)
			{
				num *= (float)RuntimeGlobals.GameModeSettings.EnemyDamage / 100f;
			}
			else if (damage.Reason == EDamageReason.Player && CombatArenaManager.Instance != null)
			{
				CombatArenaManager instance = CombatArenaManager.Instance;
				float num2 = Mathf.Clamp(num, 0f, CurrentHealth);
				if (base.gameObject.layer == instance.LeftDrone.RootDronePart.gameObject.layer)
				{
					instance.RightDroneDamage += num2;
				}
				else if (base.gameObject.layer == instance.RightDrone.RootDronePart.gameObject.layer)
				{
					instance.LeftDroneDamage += num2;
				}
			}
			CurrentHealth = Mathf.Clamp(CurrentHealth - num, 0f, ActiveMaxHealth);
			Action<HealthPool, DamageInformation> action = this.DamageTaken;
			if (action != null)
			{
				action(this, damage);
			}
			if (CurrentHealth <= 0f)
			{
				IsDead = true;
				RaiseHasDied();
			}
			if (HitAnimation != null && CurrentState != EChemicalState.Frozen)
			{
				if (_currentAnim != null)
				{
					if (_currentAnim.animation.Name != "hitLoop" || _currentAnim.IsComplete)
					{
						_currentAnim = HitAnimation.AnimationState.SetAnimation(0, "hitLoop", false);
					}
				}
				else
				{
					_currentAnim = HitAnimation.AnimationState.SetAnimation(0, "hitLoop", false);
				}
			}
			if (_renderers.Count > 0 && !_isShowingDamage)
			{
				StartCoroutine(ShowDamage());
			}
			_lastDamageTime = Time.time;
		}

		public void Heal(float healAmount)
		{
			if (!IsDead)
			{
				CurrentHealth = Mathf.Clamp(CurrentHealth + healAmount, 0f, ActiveMaxHealth);
			}
		}

		private IEnumerator ShowDamage()
		{
			_isShowingDamage = true;
			UpdateRenderers();
			yield return new WaitForSeconds(0.1f);
			_isShowingDamage = false;
			UpdateRenderers();
		}

		private IEnumerator UpdateHealthbar()
		{
			while (_healthBar != null)
			{
				_showHealthbar = Time.time - _lastDamageTime < 1f;
				_healthBar.gameObject.SetActive(_showHealthbar);
				yield return true;
			}
		}

		public void SpreadTemperature()
		{
			if (WorldController.HasExpandingPlanetCore && base.transform.position.magnitude <= WorldController.PlanetCoreRadius)
			{
				ChangeTemperatureBy(WorldController.PlanetCoreTemperature);
			}
			if (!(Mathf.Abs(CurrentTemperature) > 40f))
			{
				return;
			}
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			float a = 10f;
			float b = 10f;
			if (_collider != null)
			{
				b = _collider.bounds.extents.y;
				a = _collider.bounds.extents.x;
			}
			Collider[] array = Physics.OverlapSphere(base.transform.position, Mathf.Max(a, b) * 1.5f);
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = array[i].gameObject;
				if (!hashSet.Contains(gameObject))
				{
					gameObject.SendMessage("SetNeighbourTemperature", CurrentTemperature, SendMessageOptions.DontRequireReceiver);
					hashSet.Add(gameObject);
				}
			}
		}

		public void SetNeighbourTemperature(float neighbourTemp)
		{
			if (CurrentState != EChemicalState.Burning && (CurrentState != EChemicalState.Frozen || !(neighbourTemp < 90f)))
			{
				float num = neighbourTemp - CurrentTemperature;
				if (num < 0f)
				{
					ChangeTemperatureBy(num * 0.02f);
				}
				else
				{
					ChangeTemperatureBy(num * 0.2f);
				}
			}
		}

		private IEnumerator UpdateTemperature()
		{
			float time = 0.05f;
			while (true)
			{
				if (!DisableTemperatureRegulation)
				{
					if (CurrentTemperature > 0f && CurrentTemperature < 90f)
					{
						ChangeTemperatureBy(0f - time);
					}
					if (CurrentTemperature < 0f)
					{
						ChangeTemperatureBy(time);
					}
				}
				if (CurrentState == EChemicalState.Burning && !IgnoreBurningDamage)
				{
					if (Time.time - _burningStartTime < 5f)
					{
						TakeDamageSimple(Mathf.Min(1000f, ActiveMaxHealth) * 0.1f * time, EDamageReason.Fire);
					}
					else
					{
						SetTemperature(80f);
					}
				}
				yield return new WaitForSeconds(time);
			}
		}

		public void SetTemperature(float amount)
		{
			CurrentTemperature = amount;
			UpdateChemicalState();
		}

		public void ChangeTemperatureBy(float amount)
		{
			if (amount > 0f && CurrentTemperature >= -0.1f)
			{
				float num = amount / 99.9f * (float)HeatResistance;
				amount = Mathf.Max(0f, amount - num);
			}
			else if (amount < 0f && CurrentTemperature <= 0.1f)
			{
				float num2 = amount / 99.9f * (float)ColdResistance;
				amount = Mathf.Min(amount - num2);
			}
			if (Math.Abs(amount) > 0.001f)
			{
				CurrentTemperature = Mathf.Max(-100f, Mathf.Min(100f, CurrentTemperature + amount));
				UpdateChemicalState();
			}
		}

		public void ChangeChemicalState(EChemicalState state, bool overrideTemp)
		{
			switch (state)
			{
			case EChemicalState.Burning:
				if (CurrentState != EChemicalState.Burning)
				{
					_burningStartTime = Time.time;
					CurrentState = EChemicalState.Burning;
				}
				CurrentTemperature = 100f;
				break;
			case EChemicalState.Frozen:
				CurrentState = EChemicalState.Frozen;
				CurrentTemperature = -100f;
				break;
			case EChemicalState.None:
				if (CurrentState == EChemicalState.Frozen)
				{
					CurrentState = EChemicalState.None;
					if (overrideTemp)
					{
						CurrentTemperature = -10f;
					}
				}
				else if (CurrentState == EChemicalState.Burning)
				{
					CurrentState = EChemicalState.None;
					if (overrideTemp)
					{
						CurrentTemperature = 10f;
					}
				}
				break;
			}
		}

		private void UpdateChemicalState()
		{
			if (CurrentTemperature >= 90f && CurrentState != EChemicalState.Burning)
			{
				ChangeChemicalState(EChemicalState.Burning, false);
			}
			else if (CurrentTemperature <= -90f && CurrentState != EChemicalState.Frozen)
			{
				ChangeChemicalState(EChemicalState.Frozen, false);
			}
			else if (CurrentTemperature > -90f && CurrentTemperature < 90f)
			{
				ChangeChemicalState(EChemicalState.None, false);
			}
		}

		private void AnimationState_End(TrackEntry trackEntry)
		{
			if (_currentAnim != null && _currentAnim.animation.Name == "hitLoop")
			{
				_currentAnim = HitAnimation.AnimationState.SetAnimation(0, "idle", true);
			}
		}

		private void RaiseHasDied()
		{
			_isShowingDamage = false;
			_showHealthbar = false;
			if (BaseSingleton<ChemicalManager>.Instance != null)
			{
				BaseSingleton<ChemicalManager>.Instance.Unregister(this);
			}
			StopAllCoroutines();
			EventHandler eventHandler = this.HasDied;
			if (eventHandler != null)
			{
				eventHandler(this, null);
			}
		}

		[Button]
		public void Die()
		{
			TakeDamageSimple(ActiveMaxHealth, EDamageReason.Death);
		}

		internal void StartSoundLoop(string sound, float volume = 1f)
		{
			if (!_isPlaying && !string.IsNullOrEmpty(sound) && (!(_audioLoop != null) || !_audioLoop.IsPlaying()))
			{
				_audioLoop = AudioController.Play(sound, base.transform, volume);
				_isPlaying = true;
			}
		}

		internal AudioObject PlaySound(string sound)
		{
			if (string.IsNullOrEmpty(sound))
			{
				return null;
			}
			return AudioController.Play(sound, base.transform);
		}

		internal void StopActiveSoundLoop()
		{
			if (_isPlaying)
			{
				if (_audioLoop != null)
				{
					_audioLoop.Stop(0.1f);
					_isPlaying = false;
				}
				_isPlaying = false;
			}
		}
	}
}
