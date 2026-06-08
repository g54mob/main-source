using System;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
	public enum HandType
	{
		LeftOrRight = 0,
		LeftOnly = 1,
		RightOnly = 2,
		DoubleHanded = 3,
		CannotEquip = 4
	}

	[Serializable]
	public class AlternativeBullet
	{
		public Bullet prefab;

		public ItemData.Element elementType;

		public int minDistance;

		public int maxDistance = 999;
	}

	[Serializable]
	public class DrawsArmDuring
	{
		public bool idle = true;

		public bool cast = true;

		public bool perf = true;
	}

	[Serializable]
	public class AttackSprites
	{
		public AsciiSprite heroHand;

		public AsciiSprite heroFullBody;

		public AsciiSprite idleSprite;

		public AsciiSprite castSprite;

		public AsciiSprite perfSprite;

		public int minDistance;

		public int maxDistance = 999;

		public void DisableSprites()
		{
			if (idleSprite != null)
			{
				idleSprite.gameObject.SetActive(value: false);
			}
			if (castSprite != null)
			{
				castSprite.gameObject.SetActive(value: false);
			}
			if (perfSprite != null)
			{
				perfSprite.gameObject.SetActive(value: false);
			}
		}
	}

	public enum State
	{
		UI = 0,
		Waiting = 1,
		Casting = 2,
		Performing = 3,
		Cooldown = 4
	}

	public HandType handType;

	public Data.Resource spendsResource;

	public int resourceSpentPerAttack = 1;

	public bool autoEquip;

	public int baseDamage = 1;

	public int baseRange = 1;

	public int maxRange = 22;

	public float baseChanceToAoe;

	public int cast = 15;

	public int perf = 5;

	public int cooldown = 5;

	public bool startOnCooldown;

	public IntPosition projectileExitLeftHand;

	public IntPosition projectileExit;

	public Bullet bulletPrefab;

	public AlternativeBullet[] alternativeBullets;

	public DrawsArmDuring drawsArmDuring;

	public AsciiSprite heroLeftHand;

	public AsciiSprite heroRightHand;

	public AsciiSprite leftHandIdleSprite;

	public AsciiSprite leftHandCastSprite;

	public AsciiSprite leftHandPerfSprite;

	public AsciiSprite leftHandPickingUpSprite;

	public AsciiSprite fullBodyPickupReplacement;

	public AsciiSprite idleSprite;

	public AsciiSprite castSprite;

	public AsciiSprite perfSprite;

	public AttackSprites[] leftHandSprites;

	public AttackSprites[] rightHandSprites;

	public AsciiSprite shieldRotationSprite;

	public AsciiSprite leftChokeSprite;

	public AsciiSprite rightChokeSprite;

	public Action<Weapon, State, State> OnStateChange;

	private bool _isOnRightHand = true;

	private State currentState;

	private int stateElapsedTics;

	private AttackSprites currentAttackSprites;

	protected AsciiSprite currentSprite;

	private AsciiSprite currentHeroBodySprite;

	private Character target;

	private Bullet selectedBulletPrefab;

	protected int cooldownStartTime = -99999;

	private static List<AttackSprites> _workAttackSprites = new List<AttackSprites>();

	private int lastRandomIndex = -1;

	protected int attackSpeed;

	private int _lastAttackSpeed;

	private int _lastCast;

	private int _lastPerf;

	private int _lastCool;

	private int _computedCast = -1;

	private int _computedPerf = -1;

	private int _computedCool = -1;

	private bool hasInitializedSprites;

	public bool IsOnRightHand
	{
		get
		{
			return _isOnRightHand;
		}
		set
		{
			_isOnRightHand = value;
		}
	}

	public List<StatModifier> statModifiersToApply { get; set; }

	public string cachedSearchDescription { get; set; }

	public State CurrentState => currentState;

	public int StateElapsedTics => stateElapsedTics;

	public int distanceToTargetX { get; private set; }

	public int range { get; protected set; }

	public AsciiSprite GetCurrentSprite()
	{
		return currentSprite;
	}

	public virtual bool IsReady()
	{
		if (IsWaiting())
		{
			return CanShoot();
		}
		return false;
	}

	public virtual bool CanAttack(Character target)
	{
		if (bulletPrefab == null)
		{
			return false;
		}
		if (target != null && target.tags.Contains("harvest") && !tags.Contains("harvest"))
		{
			return false;
		}
		return true;
	}

	public virtual void Attack(Character target)
	{
		if (target != null && target.Alive)
		{
			this.target = target;
			distanceToTargetX = GetDistanceToTargetX(target);
			selectedBulletPrefab = SelectBulletPrefab();
			target.willProbablyDie = WillTargetProbablyDie(target);
			SetState(State.Casting);
		}
	}

	public virtual bool IsWaiting()
	{
		return currentState == State.Waiting;
	}

	public virtual bool IsCasting()
	{
		return currentState == State.Casting;
	}

	public virtual bool IsPerforming()
	{
		return currentState == State.Performing;
	}

	public virtual bool IsOnCooldown()
	{
		return currentState == State.Cooldown;
	}

	public virtual bool IsIdle()
	{
		if (currentState != State.Cooldown && currentState != State.UI)
		{
			return currentState == State.Waiting;
		}
		return true;
	}

	public virtual bool IsTargetWithinRange(Character target)
	{
		int num = 0;
		int num2 = 0;
		if (base.Owner != null)
		{
			num = base.Owner.PositionX;
			num2 = base.Owner.PositionZ;
		}
		int num3 = target.PositionX - num;
		if (Mathf.Abs(target.PositionZ - num2) <= 1)
		{
			return num3 <= range;
		}
		return false;
	}

	public virtual int GetDistanceToTargetX(Character target)
	{
		int num = 0;
		if (base.Owner != null)
		{
			num = base.Owner.PositionX;
		}
		return target.PositionX - num;
	}

	private bool WillTargetProbablyDie(Character target)
	{
		if (selectedBulletPrefab == null)
		{
			return false;
		}
		return (float)selectedBulletPrefab.EstimateDamageTo(this, target) >= (float)target.Hitpoints + Mathf.Ceil(target.Armor);
	}

	private Bullet SelectBulletPrefab()
	{
		for (int i = 0; i < alternativeBullets.Length; i++)
		{
			AlternativeBullet alternativeBullet = alternativeBullets[i];
			if (alternativeBullet.elementType == element && distanceToTargetX >= alternativeBullet.minDistance && distanceToTargetX <= alternativeBullet.maxDistance)
			{
				return alternativeBullet.prefab;
			}
		}
		return bulletPrefab;
	}

	private AttackSprites FindAttackSprites(AttackSprites[] attSpriteArr)
	{
		if (attSpriteArr == null)
		{
			return null;
		}
		foreach (AttackSprites attackSprites in attSpriteArr)
		{
			if (distanceToTargetX >= attackSprites.minDistance && distanceToTargetX <= attackSprites.maxDistance)
			{
				_workAttackSprites.Add(attackSprites);
			}
		}
		if (_workAttackSprites.Count <= 0)
		{
			return null;
		}
		int num = UnityEngine.Random.Range(0, _workAttackSprites.Count);
		if (num == lastRandomIndex)
		{
			num = (num + 1) % _workAttackSprites.Count;
		}
		lastRandomIndex = num;
		AttackSprites result = _workAttackSprites[num];
		_workAttackSprites.Clear();
		return result;
	}

	public virtual void SetState(State newState)
	{
		if (newState == State.Casting || currentAttackSprites == null)
		{
			UpdateCurrentAttackSprites();
		}
		if (newState == State.Casting && GetCastTics() <= 0)
		{
			SetState(State.Performing);
			Execute();
			FireStateChangedEvent(newState, currentState);
			return;
		}
		if (newState == State.Performing && GetPerfTics() <= 0)
		{
			SetState(State.Cooldown);
			FireStateChangedEvent(newState, currentState);
			return;
		}
		if (newState == State.Cooldown && GetCooldown() <= 0)
		{
			SetState(State.Waiting);
			FireStateChangedEvent(newState, currentState);
			return;
		}
		UpdateSelectedSprite(newState);
		switch (newState)
		{
		case State.Waiting:
			cooldownStartTime = -99999;
			break;
		case State.Cooldown:
			if (GameStates.Singleton != null)
			{
				cooldownStartTime = GameStates.Singleton.level.gameTime;
			}
			break;
		}
		FireStateChangedEvent(newState, currentState);
		currentState = newState;
		stateElapsedTics = 0;
	}

	private void FireStateChangedEvent(State _new, State _current)
	{
		if (OnStateChange != null)
		{
			OnStateChange(this, _new, _current);
		}
	}

	public void SetStateElapsedTics(int newValue)
	{
		stateElapsedTics = newValue;
	}

	public void UpdateCurrentAttackSprites()
	{
		if (IsOnRightHand && rightHandSprites != null && rightHandSprites.Length != 0)
		{
			currentAttackSprites = FindAttackSprites(rightHandSprites);
		}
		else if (!IsOnRightHand && leftHandSprites != null && leftHandSprites.Length != 0)
		{
			currentAttackSprites = FindAttackSprites(leftHandSprites);
		}
	}

	public void UpdateSelectedSprite()
	{
		UpdateSelectedSprite(currentState);
	}

	private void UpdateSelectedSprite(State newState)
	{
		if (currentSprite != null)
		{
			currentSprite.gameObject.SetActive(value: false);
		}
		switch (newState)
		{
		case State.Casting:
			if (currentAttackSprites != null)
			{
				currentSprite = currentAttackSprites.castSprite;
			}
			else if (IsOnRightHand || leftHandCastSprite == null)
			{
				currentSprite = castSprite;
			}
			else
			{
				currentSprite = leftHandCastSprite;
			}
			break;
		case State.Performing:
			if (currentAttackSprites != null)
			{
				currentSprite = currentAttackSprites.perfSprite;
			}
			else if (IsOnRightHand || leftHandPerfSprite == null)
			{
				currentSprite = perfSprite;
			}
			else
			{
				currentSprite = leftHandPerfSprite;
			}
			break;
		case State.Waiting:
		case State.Cooldown:
			if (currentAttackSprites != null)
			{
				currentSprite = currentAttackSprites.idleSprite;
			}
			else if (IsOnRightHand || leftHandIdleSprite == null)
			{
				currentSprite = idleSprite;
			}
			else
			{
				currentSprite = leftHandIdleSprite;
			}
			break;
		}
		if (currentSprite != null)
		{
			currentSprite.gameObject.SetActive(value: true);
		}
		if (currentAttackSprites != null && (newState == State.Casting || newState == State.Performing))
		{
			currentHeroBodySprite = (currentAttackSprites.heroFullBody ? currentAttackSprites.heroFullBody : currentAttackSprites.heroHand);
		}
		else if (drawsArmDuring.idle || (drawsArmDuring.cast && newState == State.Casting) || (drawsArmDuring.perf && newState == State.Performing))
		{
			currentHeroBodySprite = (IsOnRightHand ? heroRightHand : heroLeftHand);
		}
		else
		{
			currentHeroBodySprite = null;
		}
	}

	public virtual void HandleEquipped()
	{
		UpdateAttackSpeed();
		UpdateRange();
	}

	public virtual void HandleUnequipped()
	{
	}

	public virtual void UpdateTic()
	{
		stateElapsedTics++;
		UpdateAttackSpeed();
		UpdateRange();
		if (currentState == State.Casting && stateElapsedTics >= GetCastTics())
		{
			SetState(State.Performing);
			Execute();
		}
		else if (currentState == State.Performing && stateElapsedTics >= GetPerfTics())
		{
			SetState(State.Cooldown);
		}
		else if (currentState == State.Cooldown)
		{
			if (stateElapsedTics >= GetCooldown())
			{
				SetState(State.Waiting);
			}
			else if (GameStates.Singleton.level.gameTime - cooldownStartTime >= GetCooldown())
			{
				SetState(State.Waiting);
			}
		}
		else if (currentState == State.Casting && (target == null || !target.Alive))
		{
			SetState(State.Waiting);
		}
	}

	public virtual void Interrupt()
	{
		if (currentState <= State.Casting)
		{
			SetState(State.Waiting);
		}
		else if (currentState == State.Performing)
		{
			SetState(State.Cooldown);
		}
		else if (currentState != State.Cooldown)
		{
			int num = stateElapsedTics;
			SetState(State.Cooldown);
			stateElapsedTics = num;
		}
	}

	protected override void Execute()
	{
		base.Execute();
		if (CanShoot())
		{
			Bullet bullet = MakeBullet();
			if (bullet != null)
			{
				bullet.target = target;
				GameStates.Singleton.level.AddCharacter(bullet);
				if (bullet.initialDelay <= 0)
				{
					bullet.TestCollision();
				}
			}
			InventoryResources.singleton.RemoveResourceOfType(spendsResource, resourceSpentPerAttack);
		}
		else
		{
			_ = base.Owner != null;
		}
		Character.FireAttackEnded(base.Owner, target, this);
	}

	protected virtual bool CanShoot()
	{
		if (spendsResource != Data.Resource.None)
		{
			return InventoryResources.singleton.GetResourceOfType(spendsResource) >= resourceSpentPerAttack;
		}
		return true;
	}

	protected virtual Bullet MakeBullet()
	{
		if (selectedBulletPrefab == null)
		{
			Utils.LogError("Bullet prefab missing for weapon " + this);
			return null;
		}
		Bullet bullet = UnityEngine.Object.Instantiate(selectedBulletPrefab);
		if (IsOnRightHand)
		{
			bullet.PositionX = projectileExit.x;
			bullet.PositionY = projectileExit.y;
			bullet.PositionZ = projectileExit.z;
		}
		else
		{
			bullet.PositionX = projectileExitLeftHand.x;
			bullet.PositionY = projectileExitLeftHand.y;
			bullet.PositionZ = projectileExitLeftHand.z;
		}
		if (base.Owner != null)
		{
			bullet.PositionX += base.Owner.PositionX;
			bullet.PositionY += base.Owner.PositionY;
			bullet.PositionZ += base.Owner.PositionZ;
			bullet.Owner = base.Owner;
			bullet.level = base.Owner.level;
		}
		bullet.weapon = this;
		if (GetRarityType() != ItemData.Rarity.Type.Common)
		{
			if (GetRarityType() == ItemData.Rarity.Type.Transcendent)
			{
				bullet.gameObject.AddComponent<AsciiSpritePPRainbow>();
			}
			else
			{
				bullet.colorTint = ItemData.Rarity.GetColorForRarity(GetRarityType());
			}
		}
		bullet.SetDamage(baseDamage);
		float l_chanceToAoe = baseChanceToAoe;
		ForEachStatModController(delegate(StatModController statMod)
		{
			l_chanceToAoe = statMod.ModChanceToAOE(l_chanceToAoe);
		});
		bullet.isAoe = l_chanceToAoe > 0f && UnityEngine.Random.Range(0f, 100f) <= l_chanceToAoe;
		if (statModifiersToApply != null)
		{
			for (int num = 0; num < statModifiersToApply.Count; num++)
			{
				bullet.statModifiersToApply.Add(statModifiersToApply[num]);
			}
		}
		bullet.tags.Add(element.ToString());
		return bullet;
	}

	public virtual void UpdateAttackSpeed()
	{
		attackSpeed = 0;
		ForEachStatModController(delegate(StatModController statMod)
		{
			attackSpeed = statMod.ModAttackSpeed(attackSpeed);
		});
		UpdateAttackTicsWithAttackSpeed(attackSpeed);
	}

	public void UpdateAttackTicsWithAttackSpeed(int _attkSpeed)
	{
		if (_lastAttackSpeed != _attkSpeed || _lastCast != cast || _lastPerf != perf || _lastCool != cooldown)
		{
			_lastAttackSpeed = _attkSpeed;
			_lastCast = cast;
			_lastPerf = perf;
			_lastCool = cooldown;
			_computedCast = CommonTimeCompute(cast, 1, _attkSpeed);
			_computedPerf = CommonTimeCompute(perf, 2, _attkSpeed);
			_computedCool = CommonTimeCompute(cooldown, 0, _attkSpeed);
		}
	}

	public virtual void UpdateRange()
	{
		range = baseRange;
		ForEachStatModController(delegate(StatModController statMod)
		{
			range = statMod.ModRange(range);
		});
		range = Mathf.Max(1, range);
		int b = Mathf.Max(baseRange, maxRange);
		range = Mathf.Min(range, b);
	}

	public int GetCastTics()
	{
		if (_computedCast < 0)
		{
			return cast;
		}
		return _computedCast;
	}

	public int GetPerfTics()
	{
		if (_computedPerf < 0)
		{
			return perf;
		}
		return _computedPerf;
	}

	public int GetCooldown()
	{
		if (_computedCool < 0)
		{
			return cooldown;
		}
		return _computedCool;
	}

	private int CommonTimeCompute(int tics, int remainderCompare, int _attkSpeed)
	{
		int num = _attkSpeed;
		int num2 = -1;
		if (num < 0)
		{
			num = -num;
			num2 = 1;
		}
		while (tics > 1 && num > 0)
		{
			if (num % 3 == remainderCompare)
			{
				tics += num2;
			}
			num--;
		}
		return tics;
	}

	public void ReduceCooldown(int tics)
	{
		if (currentState == State.Cooldown)
		{
			stateElapsedTics += tics;
		}
	}

	private void HandleQuestStarting(Data.Quest questData)
	{
		if (currentState == State.Cooldown)
		{
			SetState(State.Waiting);
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		Draw(r, offsetX, offsetY, ColorConstants.white);
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color bodyColor)
	{
		InitSprites();
		if (currentSprite != null)
		{
			if (currentState == State.Casting)
			{
				SetSpriteFrame(currentSprite, GetCastTics(), stateElapsedTics);
			}
			else if (currentState == State.Performing)
			{
				SetSpriteFrame(currentSprite, GetPerfTics(), stateElapsedTics);
			}
			if (!currentSprite.gameObject.activeSelf)
			{
				currentSprite.gameObject.SetActive(value: true);
			}
			if (leftHandPickingUpSprite != null && leftHandPickingUpSprite.gameObject.activeSelf)
			{
				leftHandPickingUpSprite.gameObject.SetActive(value: false);
			}
			currentSprite.flipX = base.Owner.lookDirection == Character.LookDirection.Left;
			currentSprite.Draw(r, offsetX, offsetY);
			DrawHeroBodyParts(r, offsetX, offsetY, bodyColor);
		}
	}

	private void DrawHeroBodyParts(AsciiRenderProcedural r, int offsetX, int offsetY, Color bodyColor)
	{
		if (currentHeroBodySprite == null)
		{
			return;
		}
		AsciiSprite asciiSprite = null;
		AsciiSprite asciiSprite2 = null;
		if (currentAttackSprites != null)
		{
			asciiSprite = currentAttackSprites.castSprite;
			asciiSprite2 = currentAttackSprites.perfSprite;
		}
		else
		{
			asciiSprite = (IsOnRightHand ? castSprite : leftHandCastSprite);
			asciiSprite2 = (IsOnRightHand ? perfSprite : leftHandPerfSprite);
		}
		if ((bool)asciiSprite && (bool)asciiSprite2)
		{
			int frameIndex = 0;
			if (CurrentState == State.Casting)
			{
				frameIndex = 1 + asciiSprite.GetFrameIndex();
			}
			else if (CurrentState == State.Performing)
			{
				frameIndex = 1 + asciiSprite.FrameCount + asciiSprite2.GetFrameIndex();
			}
			currentHeroBodySprite.flipX = base.Owner.lookDirection == Character.LookDirection.Left;
			currentHeroBodySprite.SetFrameIndex(frameIndex);
			currentHeroBodySprite.Draw(r, offsetX, offsetY, bodyColor);
		}
	}

	public void DrawPickupFrame(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (leftHandPickingUpSprite != null)
		{
			if (currentSprite.gameObject.activeSelf)
			{
				currentSprite.gameObject.SetActive(value: false);
			}
			if (!leftHandPickingUpSprite.gameObject.activeSelf)
			{
				leftHandPickingUpSprite.gameObject.SetActive(value: true);
			}
			leftHandPickingUpSprite.flipX = base.Owner.lookDirection == Character.LookDirection.Left;
			leftHandPickingUpSprite.Draw(r, offsetX, offsetY);
		}
	}

	public void DrawChokeFrame(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetY--;
		if (IsOnRightHand && rightChokeSprite != null)
		{
			rightChokeSprite.Draw(r, offsetX, offsetY);
		}
		else if (!IsOnRightHand && leftChokeSprite != null)
		{
			leftChokeSprite.Draw(r, offsetX, offsetY);
		}
		else if (currentSprite != null)
		{
			currentSprite.Draw(r, offsetX, offsetY);
		}
	}

	public void DrawShieldRotation(AsciiRenderProcedural r, int offsetX, int offsetY, Weapon leftHandWeapon, Color armColor)
	{
		InitSprites();
		if (shieldRotationSprite != null && leftHandWeapon != null)
		{
			int castTics = leftHandWeapon.GetCastTics();
			int perfTics = leftHandWeapon.GetPerfTics();
			int num = 2;
			int num2 = 4;
			int num3 = castTics + perfTics + num + num2;
			int value = 0;
			if (leftHandWeapon.CurrentState == State.Casting)
			{
				value = num + leftHandWeapon.StateElapsedTics;
			}
			else if (leftHandWeapon.CurrentState == State.Performing)
			{
				value = num + castTics + leftHandWeapon.StateElapsedTics;
			}
			else if (leftHandWeapon.CurrentState == State.Cooldown)
			{
				value = ((GameStates.Singleton.CurrentState != GameStates.State.ItemScreen && GameStates.Singleton.CurrentState != GameStates.State.PlayItemScreen) ? (num + castTics + perfTics + leftHandWeapon.StateElapsedTics) : num3);
			}
			value = Mathf.Clamp(value, 0, num3);
			SetSpriteFrame(shieldRotationSprite, num3, value);
			shieldRotationSprite.flipX = base.Owner.lookDirection == Character.LookDirection.Left;
			shieldRotationSprite.Draw(r, offsetX, offsetY);
			DrawShieldRotationArm(r, offsetX, offsetY, armColor);
		}
		else
		{
			Draw(r, offsetX, offsetY, armColor);
		}
	}

	private void DrawShieldRotationArm(AsciiRenderProcedural r, int offsetX, int offsetY, Color armColor)
	{
		if (heroRightHand != null)
		{
			heroRightHand.SetFrameIndex(shieldRotationSprite.GetFrameIndex());
			heroRightHand.Draw(r, offsetX, offsetY, armColor);
		}
	}

	private void SetSpriteFrame(AsciiSprite sprite, int totalStateTics, int elapsedTics)
	{
		if (totalStateTics > 0)
		{
			int frameIndex = sprite.FrameCount - 1;
			if (elapsedTics < totalStateTics - 1)
			{
				frameIndex = sprite.FrameCount * elapsedTics / totalStateTics;
			}
			sprite.SetFrameIndex(frameIndex);
		}
		else
		{
			sprite.SetFrameIndex(0);
		}
	}

	public bool IsDrawingArm()
	{
		if (currentState == State.UI)
		{
			return false;
		}
		if (currentState == State.Casting)
		{
			return drawsArmDuring.cast;
		}
		if (currentState == State.Performing)
		{
			return drawsArmDuring.perf;
		}
		return drawsArmDuring.idle;
	}

	public bool IsDrawingFullBody()
	{
		if (currentAttackSprites != null && currentAttackSprites.heroFullBody != null)
		{
			if (currentState != State.Casting)
			{
				return currentState == State.Performing;
			}
			return true;
		}
		return false;
	}

	public void ReloadSprites()
	{
		AsciiData.StringReplacement stringReplacement = null;
		if (element != ItemData.Element.Stone)
		{
			stringReplacement = new AsciiData.StringReplacement();
			stringReplacement.find = "o";
			stringReplacement.replaceWith = ItemData.CharForElement(element).ToString();
		}
		_InitSprites(stringReplacement);
	}

	private void InitSprites()
	{
		if (!hasInitializedSprites)
		{
			hasInitializedSprites = true;
			AsciiData.StringReplacement stringReplacement = null;
			if (element != ItemData.Element.Stone)
			{
				stringReplacement = new AsciiData.StringReplacement();
				stringReplacement.find = "o";
				stringReplacement.replaceWith = ItemData.CharForElement(element).ToString();
			}
			_InitSprites(stringReplacement);
		}
	}

	private void _InitSprites(AsciiData.StringReplacement additionalStringReplacement)
	{
		ItemData.Rarity.Type rarityType = GetRarityType();
		LoadSprite(heroLeftHand, applyEffects: false);
		if (id == "cult_mask")
		{
			LoadSprite(heroRightHand, null, rarityType);
		}
		else
		{
			LoadSprite(heroRightHand, applyEffects: false);
		}
		LoadSprite(leftHandIdleSprite, additionalStringReplacement, rarityType);
		LoadSprite(leftHandCastSprite, additionalStringReplacement, rarityType);
		LoadSprite(leftHandPerfSprite, additionalStringReplacement, rarityType);
		LoadSprite(leftHandPickingUpSprite, additionalStringReplacement, rarityType);
		LoadSprite(fullBodyPickupReplacement, additionalStringReplacement, rarityType);
		LoadSprite(idleSprite, additionalStringReplacement, rarityType);
		LoadSprite(castSprite, additionalStringReplacement, rarityType);
		LoadSprite(perfSprite, additionalStringReplacement, rarityType);
		LoadSprite(shieldRotationSprite, additionalStringReplacement, rarityType);
		LoadSprites(leftHandSprites, additionalStringReplacement, rarityType);
		LoadSprites(rightHandSprites, additionalStringReplacement, rarityType);
		LoadSprite(leftChokeSprite, additionalStringReplacement, rarityType);
		LoadSprite(rightChokeSprite, additionalStringReplacement, rarityType);
		DisableAllSprites();
	}

	public void RemoveCosmeticFromSprites()
	{
		if (!(base.cosmetic == null))
		{
			_RemoveCosmeticFrom(heroLeftHand);
			_RemoveCosmeticFrom(heroRightHand);
			_RemoveCosmeticFrom(leftHandIdleSprite);
			_RemoveCosmeticFrom(leftHandCastSprite);
			_RemoveCosmeticFrom(leftHandPerfSprite);
			_RemoveCosmeticFrom(leftHandPickingUpSprite);
			_RemoveCosmeticFrom(fullBodyPickupReplacement);
			_RemoveCosmeticFrom(idleSprite);
			_RemoveCosmeticFrom(castSprite);
			_RemoveCosmeticFrom(perfSprite);
			_RemoveCosmeticFrom(shieldRotationSprite);
			_RemoveCosmeticFrom(leftHandSprites);
			_RemoveCosmeticFrom(rightHandSprites);
			_RemoveCosmeticFrom(leftChokeSprite);
			_RemoveCosmeticFrom(rightChokeSprite);
		}
	}

	private void _RemoveCosmeticFrom(AttackSprites[] attackSprites)
	{
		if (attackSprites != null)
		{
			foreach (AttackSprites attackSprites2 in attackSprites)
			{
				_RemoveCosmeticFrom(attackSprites2.idleSprite);
				_RemoveCosmeticFrom(attackSprites2.castSprite);
				_RemoveCosmeticFrom(attackSprites2.perfSprite);
			}
		}
	}

	private void _RemoveCosmeticFrom(AsciiSprite sprite)
	{
		if (sprite != null)
		{
			base.cosmetic.RemoveCustomEffects(sprite);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (cast <= 0 && perf <= 0 && cooldown <= 0)
		{
			cooldown = 1;
			Utils.LogWarning(id + " cannot have cast, perf and cooldown all <= 0. Setting Cooldown = 1.");
		}
		if (startOnCooldown)
		{
			SetState(State.Cooldown);
		}
		else
		{
			SetState(State.Waiting);
		}
		GameStates.OnQuestStarting += HandleQuestStarting;
	}

	public void LoadSprite(AsciiSprite spriteToLoad, AsciiData.StringReplacement additionalStringReplacement = null, ItemData.Rarity.Type rarityType = ItemData.Rarity.Type.Common)
	{
		LoadSprite(spriteToLoad, applyEffects: true, additionalStringReplacement, rarityType);
	}

	private void LoadSprite(AsciiSprite spriteToLoad, bool applyEffects, AsciiData.StringReplacement additionalStringReplacement = null, ItemData.Rarity.Type rarityType = ItemData.Rarity.Type.Common)
	{
		if (!(spriteToLoad != null))
		{
			return;
		}
		if (additionalStringReplacement != null)
		{
			spriteToLoad.stringReplacements.Add(additionalStringReplacement);
		}
		spriteToLoad.Load();
		if (!applyEffects)
		{
			return;
		}
		AsciiSpritePPRainbow component = spriteToLoad.gameObject.GetComponent<AsciiSpritePPRainbow>();
		AsciiSpritePPShiny component2 = spriteToLoad.gameObject.GetComponent<AsciiSpritePPShiny>();
		if (component != null)
		{
			component.enabled = false;
		}
		if (component2 != null)
		{
			component2.enabled = false;
		}
		Cosmetic cosmetic = GetCosmetic();
		if (cosmetic == null || cosmetic.AllowsRarityColor(this))
		{
			switch (rarityType)
			{
			case ItemData.Rarity.Type.Transcendent:
				if (component != null)
				{
					component.enabled = true;
				}
				else
				{
					spriteToLoad.gameObject.AddComponent<AsciiSpritePPRainbow>();
				}
				break;
			default:
			{
				Color colorForRarity = ItemData.Rarity.GetColorForRarity(rarityType);
				spriteToLoad.colorOverride = colorForRarity;
				break;
			}
			case ItemData.Rarity.Type.Common:
				break;
			}
		}
		else
		{
			spriteToLoad.colorOverride = ColorConstants.white;
		}
		if (cosmetic != null)
		{
			cosmetic.ApplyCustomEffects(spriteToLoad);
		}
		if ((cosmetic == null || cosmetic.AllowsShiny(this)) && (base.isShiny || (cosmetic != null && cosmetic.ForcesShiny(this))))
		{
			AsciiSpritePPShiny shinyComponent;
			if (component2 != null)
			{
				component2.enabled = true;
				shinyComponent = component2;
			}
			else
			{
				shinyComponent = spriteToLoad.gameObject.AddComponent<AsciiSpritePPShiny>();
			}
			if (cosmetic != null)
			{
				cosmetic.ModifyShinyComponent(shinyComponent);
			}
		}
	}

	public void LoadSprites(AttackSprites[] attackSprites, AsciiData.StringReplacement additionalStringReplacement, ItemData.Rarity.Type rarityType = ItemData.Rarity.Type.Common)
	{
		if (attackSprites != null)
		{
			foreach (AttackSprites attackSprites2 in attackSprites)
			{
				LoadSprite(attackSprites2.idleSprite, additionalStringReplacement, rarityType);
				LoadSprite(attackSprites2.castSprite, additionalStringReplacement, rarityType);
				LoadSprite(attackSprites2.perfSprite, additionalStringReplacement, rarityType);
			}
		}
	}

	private void DisableAllSprites()
	{
		if (leftHandIdleSprite != null)
		{
			leftHandIdleSprite.gameObject.SetActive(value: false);
		}
		if (leftHandCastSprite != null)
		{
			leftHandCastSprite.gameObject.SetActive(value: false);
		}
		if (leftHandPerfSprite != null)
		{
			leftHandPerfSprite.gameObject.SetActive(value: false);
		}
		if (leftHandPickingUpSprite != null)
		{
			leftHandPickingUpSprite.gameObject.SetActive(value: false);
		}
		if (idleSprite != null)
		{
			idleSprite.gameObject.SetActive(value: false);
		}
		if (castSprite != null)
		{
			castSprite.gameObject.SetActive(value: false);
		}
		if (perfSprite != null)
		{
			perfSprite.gameObject.SetActive(value: false);
		}
		if (leftHandSprites != null)
		{
			for (int i = 0; i < leftHandSprites.Length; i++)
			{
				leftHandSprites[i].DisableSprites();
			}
		}
		if (rightHandSprites != null)
		{
			for (int j = 0; j < rightHandSprites.Length; j++)
			{
				rightHandSprites[j].DisableSprites();
			}
		}
	}

	public static Weapon LoadFromFile(string prefabPath)
	{
		Weapon component = Utils.InstantiatePrefab(prefabPath).GetComponent<Weapon>();
		if (component == null)
		{
			Utils.LogError(prefabPath + " is not a Weapon");
		}
		return component;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		target = null;
		GameStates.OnQuestStarting -= HandleQuestStarting;
	}

	[StonescriptNativeGetter("handType")]
	public object Property_GetHandType()
	{
		return handType.ToString();
	}
}
