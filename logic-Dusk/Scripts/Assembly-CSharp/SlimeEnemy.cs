using System;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : BaseEnemy
{
	private const float DEAD_COLOR_FADE_TIME = 1f;

	private List<IAffectedBySlime> _hurtList = new List<IAffectedBySlime>();

	private AutoFadeColorManager _deadColorFader = new AutoFadeColorManager();

	private Color _aliveColor = Color.white;

	private EnemyManager _enemyManager;

	private GameObject _imagePlane;

	private float _objectCollideCheckTimer = 0.5f;

	public override float BaseMoveSpeed
	{
		get
		{
			return 0.25f;
		}
	}

	public bool IsHibernating { get; private set; }

	public override float TotalHitpoints
	{
		get
		{
			return 200f;
		}
	}

	public override float AttackSpeed
	{
		get
		{
			return 1f;
		}
	}

	public override float AttackDamage
	{
		get
		{
			return 10f;
		}
	}

	public override float AttackRadius
	{
		get
		{
			return 0.1f;
		}
	}

	protected override ProjectileTypeEnum ProjectileType
	{
		get
		{
			return ProjectileTypeEnum.None;
		}
	}

	public int SlimeBrainId { get; set; }

	protected override EnemyAiBehaviors Behaviors
	{
		get
		{
			return EnemyAiBehaviors.None;
		}
	}

	public GameObject ImagePlane
	{
		get
		{
			return _imagePlane;
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		_imagePlane = base.transform.FindChild("ImagePlane").gameObject;
	}

	protected override void OnStart()
	{
		_enemyManager = EnemyManager.Instance;
		Transform transform = base.transform.Find("UIOverlay");
		if (transform != null)
		{
			uiOverlay = transform.gameObject;
			string text = "default";
			SkinEnum currentSkin = GlobalSettings.GameState.CurrentSkin;
			if (currentSkin == SkinEnum.Halloween)
			{
				text = "halloween";
			}
			Texture2D mainTexture = ResourceManager.LoadAsset<Texture2D>("skins/" + text + "/ui/droneview/sensorRectangle");
			uiOverlay.GetComponent<Renderer>().material.mainTexture = mainTexture;
		}
		_aliveColor = _imagePlane.GetComponent<Renderer>().material.color;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		if (GlobalSettings.GameIsOver || GlobalSettings.IsGamePaused)
		{
			return;
		}
		if (IsHibernating && _brain != null)
		{
			_brain.Update();
		}
		if (_deadColorFader.FadeIsInProgress)
		{
			Color color = _deadColorFader.Update(Time.deltaTime);
			_imagePlane.GetComponent<Renderer>().material.color = color;
		}
		GrowShrinkSlime();
		if (!IsHibernating && !IsDead)
		{
			_objectCollideCheckTimer -= Time.deltaTime;
			if (_objectCollideCheckTimer <= 0f)
			{
				_objectCollideCheckTimer = 0.5f;
				int count = _droneManager.dronesList.Count;
				for (int i = 0; i < count; i++)
				{
					Drone drone = _droneManager.dronesList[i];
					if (!drone.IsDead && !(drone.CurrentRoom != CurrentRoom) && !_hurtList.Contains(drone) && drone.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
					{
						_hurtList.Add(drone);
					}
				}
			}
			if (_hurtList.Count > 0)
			{
				int count2 = _hurtList.Count;
				for (int num = count2 - 1; num >= 0; num--)
				{
					IAffectedBySlime affectedBySlime = _hurtList[num];
					if (affectedBySlime.SlimeDamageTimer <= 0f)
					{
						affectedBySlime.SlimeDamageTimer = AttackSpeed;
						affectedBySlime.TakeDamage(AttackDamage, AttackDamageType, this);
						affectedBySlime.ApplySlimeSnare();
					}
					Component component = (Component)affectedBySlime;
					if (!component.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
					{
						_hurtList.RemoveAt(num);
					}
				}
			}
		}
		if (ShowOverlay && uiOverlay != null)
		{
			if (IsHibernating)
			{
				FadeOutOverlay();
			}
			else
			{
				AttemptScan();
			}
		}
	}

	private void GrowShrinkSlime()
	{
		Vector3 b = new Vector3(0.03f, 0.03f, 0.03f);
		if (!IsHibernating && !IsDead)
		{
			if (ImagePlane.transform.localScale.x < 0.1f)
			{
				ImagePlane.transform.localScale = Vector3.Slerp(ImagePlane.transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), 0.8f * Time.deltaTime);
			}
		}
		else if (ImagePlane.transform.localScale.x > b.x)
		{
			ImagePlane.transform.localScale = Vector3.Slerp(ImagePlane.transform.localScale, b, 0.8f * Time.deltaTime);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.LogWarning("Wow, OnCollisionEnter() is actually working, remove my hack from Update() and enable the below code...");
	}

	public override void Stun(float durationMin, float durationMax)
	{
	}

	public void ReplicateSlime()
	{
		SlimeEnemy slimeEnemy = _enemyManager.ClosestEnemySlime(this);
		Vector3 directionVector;
		if (slimeEnemy != null)
		{
			directionVector = (Position - slimeEnemy.Position).normalized;
		}
		else
		{
			float num = BaseEnemy._random.Next(1, 361);
			directionVector = new Vector3(Mathf.Cos(num * ((float)Math.PI / 180f)), Mathf.Sin(num * ((float)Math.PI / 180f)), 0f);
		}
		float num2 = Mathf.Atan2(directionVector.y, directionVector.x) * 57.29578f;
		for (int i = 0; i < 4; i++)
		{
			if (ReplicateSlime(directionVector))
			{
				break;
			}
			num2 += 90f;
			directionVector = new Vector3(Mathf.Cos(num2 * ((float)Math.PI / 180f)), Mathf.Sin(num2 * ((float)Math.PI / 180f)), 0f);
		}
	}

	public bool ReplicateSlime(Vector3 directionVector)
	{
		Vector3? vector = null;
		Vector2 vector2 = new Vector2(GetComponent<Renderer>().bounds.size.x * 0.5f, GetComponent<Renderer>().bounds.size.y * 0.5f);
		float magnitude = vector2.magnitude;
		Vector3 position = Position;
		bool flag = true;
		while (flag)
		{
			position += directionVector * magnitude;
			flag = CurrentRoom.GetComponent<Collider>().bounds.Contains(position);
			if (flag && !_enemyManager.DoesSlimeIntersectWithPosition(position, CurrentRoom))
			{
				vector = position;
				break;
			}
		}
		if (vector.HasValue)
		{
			SlimeEnemy slimeEnemy = _enemyManager.CreateSlime(vector.Value, CurrentRoom);
			slimeEnemy.ImagePlane.transform.localScale = Vector3.zero;
			((SlimeBrain)_brain).PassBrainToSlime(slimeEnemy);
			return true;
		}
		return false;
	}

	public void InitializeBrain()
	{
		_brain = new SlimeBrain(this);
		_brain.Initialize();
		SlimeBrainId = _brain.Id;
	}

	public void SetBrain(SlimeBrain brain)
	{
		_brain = brain;
	}

	public override void EnableRenderer(bool enabled)
	{
		if (_imagePlane != null && _imagePlane.GetComponent<Renderer>().enabled != enabled)
		{
			_imagePlane.GetComponent<Renderer>().enabled = enabled;
			_imagePlane.gameObject.SetActive(enabled);
		}
	}

	public void ForceHibernation()
	{
		_isDead = true;
		IsHibernating = true;
		isOverlayFadingOutOnDeath = true;
		_deadColorFader.StartFade(_aliveColor, DeadColor, 1f);
		FadeOutOverlay();
		if (_brain != null)
		{
			((SlimeBrain)_brain).Hibernate();
		}
	}

	public void UnHibernate()
	{
		_deadColorFader.StartFade(DeadColor, _aliveColor, 1f);
		_isDead = false;
		_currentHitpoints = TotalHitpoints;
		IsHibernating = false;
	}

	public override void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (type != DamageType.Radiation)
		{
			base.TakeDamage(damage, type, attacker);
			if (CurrentHitPoints <= 0f && IsHibernating)
			{
				IsHibernating = false;
			}
		}
	}

	public void FlagForSplitCheck()
	{
		if (_brain != null)
		{
			((SlimeBrain)_brain).CheckForSplit = true;
		}
	}

	protected override void OnDamageTaken(float damage, ICombatTarget attacker)
	{
		if (_brain != null)
		{
			((SlimeBrain)_brain).CheckForSplit = true;
		}
		else
		{
			foreach (BaseEnemy enemy in _enemyManager.Enemies)
			{
				SlimeEnemy slimeEnemy = enemy as SlimeEnemy;
				if (slimeEnemy != null && slimeEnemy.SlimeBrainId == SlimeBrainId)
				{
					slimeEnemy.FlagForSplitCheck();
				}
			}
		}
		if (IsDead)
		{
			_deadColorFader.StartFade(_aliveColor, DeadColor, 1f);
			int num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Slime), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Slime), num);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Slime), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Slime), 0) + num);
			if (num > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Slime), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Slime), num);
			}
		}
	}
}
