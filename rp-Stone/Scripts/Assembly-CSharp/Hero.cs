using System;
using System.Collections.Generic;
using SafeTypes;
using Stonescript;
using UnityEngine;

public class Hero : Character
{
	public enum State
	{
		Store = 0,
		Idle = 1,
		Walking = 2,
		PickingUp = 3,
		Attacking = 4,
		Pulling = 5,
		Choked = 6
	}

	public AsciiAnimation walkingAnimation;

	public AsciiAnimation pickupAnimation;

	public AsciiAnimation pullAnimation;

	public AsciiSprite chockedSprite;

	public Faerie faerie;

	public BigHead bigHead;

	public int pickupTicDuration = 30;

	public int disablePickupTicCount = 15;

	public AsciiSprite mount;

	public int maxSummons = 1;

	public AsciiSprite testSpriteOverlayed;

	public bool isInvisible;

	public bool renderingEnabled = true;

	private State currentState = State.Idle;

	private int stateElapsedTics;

	private Weapon leftHand;

	private Weapon rightHand;

	private Weapon punchWeapon;

	private Weapon kickWeapon;

	private AsciiSprite idleSprite;

	private Pickup pickupTarget;

	private bool nextEquipHandLeft;

	private bool enableHandToHand;

	private bool nextHandToHandIsKick;

	private int defaultTicsPerMoveH;

	public Color baseBodyColor = Color.white;

	private int lastPosX;

	private int lastPosY;

	private int lastPosZ;

	private int stationaryTics;

	private IFunction destinationReachedCallbackMethod;

	private List<object> destinationReachedCallbackParameters;

	public State CurrentState => currentState;

	public Weapon LeftHand
	{
		get
		{
			return leftHand;
		}
		set
		{
			if (leftHand != null)
			{
				leftHand.HandleUnequipped();
				Character.FireUnequippedWeapon(this, leftHand);
				leftHand.Owner = null;
			}
			leftHand = value;
			if (leftHand != null)
			{
				leftHand.IsOnRightHand = false;
				leftHand.Owner = this;
				leftHand.HandleEquipped();
				Character.FireEquippedWeapon(this, leftHand);
			}
		}
	}

	public Weapon RightHand
	{
		get
		{
			return rightHand;
		}
		set
		{
			if (rightHand != null)
			{
				rightHand.baseRange--;
				rightHand.HandleUnequipped();
				Character.FireUnequippedWeapon(this, rightHand);
				rightHand.Owner = null;
			}
			rightHand = value;
			if (rightHand != null)
			{
				rightHand.baseRange++;
				rightHand.IsOnRightHand = true;
				rightHand.Owner = this;
				rightHand.HandleEquipped();
				Character.FireEquippedWeapon(this, rightHand);
			}
		}
	}

	public int frozenTics { get; set; }

	public bool cinematicHideRightWeapon { get; set; }

	public bool canChangeEquipment { get; set; }

	public StonescriptObject SSObject => GetComponent<SSScriptableObject>().Target;

	public event Action<Hero, AsciiRenderProcedural, int, int> OnPostDrawHero;

	public void Equip(Weapon weapon)
	{
		if (!canChangeEquipment || IsEquipped(weapon))
		{
			return;
		}
		weapon.gameObject.SetActive(value: true);
		UnequipIfDoublehanded();
		if (weapon.handType == Weapon.HandType.LeftOrRight)
		{
			if (RightHand == null)
			{
				RightHand = weapon;
				nextEquipHandLeft = true;
			}
			else if (LeftHand == null)
			{
				LeftHand = weapon;
				nextEquipHandLeft = false;
			}
			else if (nextEquipHandLeft)
			{
				Unequip(LeftHand);
				LeftHand = weapon;
				nextEquipHandLeft = false;
			}
			else
			{
				Unequip(RightHand);
				RightHand = weapon;
				nextEquipHandLeft = true;
			}
		}
		else if (weapon.handType == Weapon.HandType.LeftOnly)
		{
			Unequip(LeftHand);
			LeftHand = weapon;
		}
		else if (weapon.handType == Weapon.HandType.RightOnly)
		{
			Unequip(RightHand);
			RightHand = weapon;
		}
		else if (weapon.handType == Weapon.HandType.DoubleHanded)
		{
			Unequip(LeftHand);
			Unequip(RightHand);
			LeftHand = null;
			RightHand = weapon;
		}
		if (weapon != null)
		{
			weapon.Interrupt();
			weapon.UpdateSelectedSprite();
		}
	}

	public void EquipLeft(Weapon weapon)
	{
		if (!canChangeEquipment || LeftHand == weapon)
		{
			return;
		}
		if (weapon.handType == Weapon.HandType.DoubleHanded || weapon.handType == Weapon.HandType.RightOnly)
		{
			Equip(weapon);
			return;
		}
		UnequipIfDoublehanded();
		if (RightHand == weapon)
		{
			Unequip(weapon);
		}
		if (LeftHand == null)
		{
			LeftHand = weapon;
		}
		else if (RightHand == null && LeftHand.handType == Weapon.HandType.LeftOrRight)
		{
			Weapon weapon2 = LeftHand;
			LeftHand = weapon;
			RightHand = weapon2;
			weapon2.Interrupt();
			weapon2.UpdateSelectedSprite();
		}
		else
		{
			Unequip(LeftHand);
			LeftHand = weapon;
		}
		weapon.gameObject.SetActive(value: true);
		weapon.Interrupt();
		weapon.UpdateSelectedSprite();
		nextEquipHandLeft = false;
	}

	public void EquipRight(Weapon weapon)
	{
		if (!canChangeEquipment || RightHand == weapon)
		{
			return;
		}
		if (weapon.handType == Weapon.HandType.DoubleHanded || weapon.handType == Weapon.HandType.LeftOnly)
		{
			Equip(weapon);
			return;
		}
		UnequipIfDoublehanded();
		if (LeftHand == weapon)
		{
			Unequip(weapon);
		}
		if (RightHand == null)
		{
			RightHand = weapon;
		}
		else if (LeftHand == null && RightHand.handType == Weapon.HandType.LeftOrRight)
		{
			Weapon weapon2 = RightHand;
			RightHand = weapon;
			LeftHand = weapon2;
			weapon2.Interrupt();
			weapon2.UpdateSelectedSprite();
		}
		else
		{
			Unequip(RightHand);
			RightHand = weapon;
		}
		weapon.gameObject.SetActive(value: true);
		weapon.Interrupt();
		weapon.UpdateSelectedSprite();
		nextEquipHandLeft = false;
	}

	private void UnequipIfDoublehanded()
	{
		if (RightHand != null && RightHand.handType == Weapon.HandType.DoubleHanded)
		{
			Unequip(RightHand);
			LeftHand = null;
			RightHand = null;
		}
	}

	public void Unequip(Weapon weapon)
	{
		if (canChangeEquipment)
		{
			if (weapon != null)
			{
				weapon.gameObject.SetActive(value: false);
			}
			if (LeftHand == weapon)
			{
				LeftHand = null;
			}
			else if (RightHand == weapon)
			{
				RightHand = null;
			}
		}
	}

	public bool IsEquipped(Weapon weapon)
	{
		if (!(leftHand == weapon))
		{
			return rightHand == weapon;
		}
		return true;
	}

	public bool IsEquipped(string itemSearchCriteria)
	{
		Weapon weapon = Inventory.Singleton.FindBestWeapon(itemSearchCriteria, Weapon.HandType.LeftOrRight);
		if (weapon != null)
		{
			return IsEquipped(weapon);
		}
		return false;
	}

	public void TryToAttack(Character target)
	{
		EvaluateHandToHand(target);
		if (enableHandToHand)
		{
			if (punchWeapon.IsReady() && kickWeapon.IsReady() && punchWeapon.IsTargetWithinRange(target))
			{
				if (nextHandToHandIsKick)
				{
					kickWeapon.Attack(target);
				}
				else
				{
					punchWeapon.Attack(target);
				}
				nextHandToHandIsKick = !nextHandToHandIsKick;
				SetState(State.Attacking);
			}
			return;
		}
		if (rightHand != null && rightHand.IsReady() && rightHand.CanAttack(target) && rightHand.IsTargetWithinRange(target))
		{
			rightHand.Attack(target);
			if (!target.willProbablyDie)
			{
				SetState(State.Attacking);
			}
		}
		if (leftHand != null && leftHand.IsReady() && leftHand.CanAttack(target) && leftHand.IsTargetWithinRange(target))
		{
			leftHand.Attack(target);
			if (!target.willProbablyDie)
			{
				SetState(State.Attacking);
			}
		}
	}

	public void CancelAttack()
	{
		enableHandToHand = false;
		punchWeapon.SetState(Weapon.State.Waiting);
		kickWeapon.SetState(Weapon.State.Waiting);
		if (leftHand != null)
		{
			leftHand.Interrupt();
		}
		if (rightHand != null)
		{
			rightHand.Interrupt();
		}
	}

	public void Pickup(Pickup pickup)
	{
		if (pickupTarget == null)
		{
			SetState(State.PickingUp);
			pickupTarget = pickup;
		}
	}

	public void Walk()
	{
		if (CanMove())
		{
			SetState(State.Walking);
		}
	}

	public bool CanMove()
	{
		if (currentState != State.PickingUp && (leftHand == null || leftHand.IsWaiting() || leftHand.IsOnCooldown()))
		{
			if (!(rightHand == null) && !rightHand.IsWaiting())
			{
				return rightHand.IsOnCooldown();
			}
			return true;
		}
		return false;
	}

	public void SetState(State newState)
	{
		if (newState == currentState)
		{
			return;
		}
		if (newState != State.PickingUp)
		{
			pickupTarget = null;
			pickupAnimation.Stop();
		}
		switch (newState)
		{
		case State.Walking:
			base.MySprite = walkingAnimation.Sprite;
			walkingAnimation.Play();
			break;
		case State.PickingUp:
			if ((bool)rightHand && (bool)rightHand.fullBodyPickupReplacement)
			{
				base.MySprite = rightHand.fullBodyPickupReplacement;
			}
			else
			{
				base.MySprite = pickupAnimation.Sprite;
			}
			pickupAnimation.Play();
			break;
		case State.Pulling:
			base.MySprite = pullAnimation.Sprite;
			pullAnimation.Play();
			break;
		case State.Choked:
			base.MySprite = chockedSprite;
			if (LeftHand != null)
			{
				LeftHand.SetState(Weapon.State.Cooldown);
			}
			if (RightHand != null)
			{
				RightHand.SetState(Weapon.State.Cooldown);
			}
			break;
		default:
			base.MySprite = idleSprite;
			base.MySprite.SetFrameIndex(0);
			walkingAnimation.Stop();
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		if (frozenTics-- > 0)
		{
			return;
		}
		base.UpdateTic();
		if (IsStunned())
		{
			return;
		}
		UpdateWeapons();
		faerie.UpdateTic();
		bigHead.UpdateTic();
		stateElapsedTics++;
		if (currentState == State.PickingUp)
		{
			if (pickupTarget == null && HasItemEquipped("star_stone"))
			{
				SetState(State.Idle);
			}
			else if (stateElapsedTics >= pickupTicDuration)
			{
				SetState(State.Idle);
			}
			else if (stateElapsedTics == disablePickupTicCount && pickupTarget != null)
			{
				pickupTarget.ExecutePickUp(this);
				pickupTarget = null;
			}
		}
		else if (currentState == State.Attacking)
		{
			if ((enableHandToHand && punchWeapon.IsWaiting() && kickWeapon.IsWaiting()) || (!enableHandToHand && (leftHand == null || !leftHand.IsCasting()) && (rightHand == null || !rightHand.IsCasting())))
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.Walking)
		{
			UpdateHasStoppedWalking();
		}
	}

	private void UpdateWeapons()
	{
		if (enableHandToHand)
		{
			punchWeapon.UpdateTic();
			kickWeapon.UpdateTic();
		}
		if (leftHand != null)
		{
			leftHand.UpdateTic();
		}
		if (rightHand != null)
		{
			rightHand.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (base.Hidden)
		{
			return;
		}
		faerie.Draw(r, offsetX, offsetY);
		if (isInvisible || !renderingEnabled)
		{
			offsetX += base.PositionX;
			offsetY += base.PositionZ - base.PositionY;
			base.lastDrawX = offsetX;
			base.lastDrawY = offsetY;
			if (this.OnPostDrawHero != null)
			{
				this.OnPostDrawHero(this, r, offsetX, offsetY);
			}
			return;
		}
		bool flag = true;
		if (enableHandToHand)
		{
			if (punchWeapon.IsCasting() || punchWeapon.IsPerforming())
			{
				flag = false;
				punchWeapon.Draw(r, offsetX + base.PositionX, offsetY + base.PositionZ - base.PositionY);
			}
			else if (kickWeapon.IsCasting() || kickWeapon.IsPerforming())
			{
				flag = false;
				kickWeapon.Draw(r, offsetX + base.PositionX, offsetY + base.PositionZ - base.PositionY);
			}
		}
		else if (rightHand != null && rightHand.IsDrawingFullBody())
		{
			flag = false;
		}
		if (currentState == State.Pulling && pullAnimation.Sprite.GetFrameIndex() == 1)
		{
			offsetX--;
		}
		if (flag)
		{
			if (base.MySprite != null)
			{
				base.MySprite.flipX = base.lookDirection == LookDirection.Left;
				if (currentState == State.PickingUp && base.MySprite != pickupAnimation.Sprite)
				{
					base.MySprite.SetFrameIndex(pickupAnimation.Sprite.GetFrameIndex());
				}
			}
			base.Draw(r, offsetX, offsetY);
		}
		if (currentState == State.Pulling || currentState == State.Choked)
		{
			flag = false;
		}
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		Color color = baseBodyColor * base.lastDamageColorMultiply;
		if (currentState == State.PickingUp)
		{
			bigHead.Draw(r, offsetX, offsetY, color);
			Weapon weapon = ((rightHand != null && rightHand.handType == Weapon.HandType.DoubleHanded) ? rightHand : leftHand);
			if (weapon != null)
			{
				int frameIndex = pickupAnimation.Sprite.GetFrameIndex();
				int num = offsetX;
				int num2 = offsetY;
				int[] array = new int[14]
				{
					1, -1, 3, -1, 3, -1, 1, -1, 0, 0,
					0, 0, 0, 0
				};
				num = ((base.lookDirection != LookDirection.Right) ? (num - array[frameIndex * 2]) : (num + array[frameIndex * 2]));
				num2 += array[frameIndex * 2 + 1];
				weapon.DrawPickupFrame(r, num, num2);
			}
		}
		else if (currentState == State.Choked)
		{
			bigHead.Draw(r, offsetX, offsetY, color);
			if (leftHand != null)
			{
				leftHand.DrawChokeFrame(r, offsetX, offsetY);
			}
			if (rightHand != null)
			{
				rightHand.DrawChokeFrame(r, offsetX, offsetY);
			}
		}
		else
		{
			if (flag)
			{
				if ((leftHand == null || !leftHand.IsDrawingArm()) && (rightHand == null || rightHand.handType != Weapon.HandType.DoubleHanded || !rightHand.IsDrawingArm()))
				{
					if (base.lookDirection == LookDirection.Right)
					{
						r.SetCell(offsetX - 1, offsetY - 1, 47, color);
					}
					else
					{
						r.SetCell(offsetX + 1, offsetY - 1, 92, color);
					}
				}
				if (rightHand == null || !rightHand.IsDrawingArm())
				{
					if (base.lookDirection == LookDirection.Right)
					{
						r.SetCell(offsetX + 1, offsetY - 1, 92, color);
					}
					else
					{
						r.SetCell(offsetX - 1, offsetY - 1, 47, color);
					}
				}
			}
			if (!enableHandToHand || currentState != State.Attacking)
			{
				if (rightHand != null && currentState != State.Pulling && !cinematicHideRightWeapon)
				{
					if (rightHand.shieldRotationSprite != null && leftHand != null)
					{
						rightHand.DrawShieldRotation(r, offsetX, offsetY, leftHand, color);
					}
					else
					{
						rightHand.Draw(r, offsetX, offsetY, color);
					}
				}
				bigHead.Draw(r, offsetX, offsetY, color);
				if (leftHand != null)
				{
					leftHand.Draw(r, offsetX, offsetY, color);
				}
			}
			else
			{
				bigHead.Draw(r, offsetX, offsetY, color);
			}
		}
		base.lastDrawX = offsetX;
		base.lastDrawY = offsetY;
		if (testSpriteOverlayed != null)
		{
			testSpriteOverlayed.Draw(r, offsetX, offsetY);
		}
		if (this.OnPostDrawHero != null)
		{
			this.OnPostDrawHero(this, r, offsetX, offsetY);
		}
	}

	private void DrawMount(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
	}

	public int ComputeMinWeaponRange()
	{
		EvaluateHandToHand();
		if (enableHandToHand)
		{
			return punchWeapon.baseRange;
		}
		if (leftHand == null)
		{
			if (rightHand == null)
			{
				return 0;
			}
			return rightHand.range;
		}
		if (rightHand == null)
		{
			return leftHand.range;
		}
		return Mathf.Min(leftHand.range, rightHand.range);
	}

	public int ComputeMaxWeaponRange()
	{
		EvaluateHandToHand();
		if (enableHandToHand)
		{
			return punchWeapon.baseRange;
		}
		if (leftHand == null)
		{
			if (rightHand == null)
			{
				return 0;
			}
			return rightHand.range;
		}
		if (rightHand == null)
		{
			return leftHand.range;
		}
		return Mathf.Max(leftHand.range, rightHand.range);
	}

	public int ComputeMinWeaponRange(Character target)
	{
		EvaluateHandToHand(target);
		if (enableHandToHand)
		{
			return punchWeapon.baseRange;
		}
		if (leftHand == null || !leftHand.CanAttack(target))
		{
			if (rightHand == null || !rightHand.CanAttack(target))
			{
				return 1;
			}
			return rightHand.range;
		}
		if (rightHand == null || !rightHand.CanAttack(target))
		{
			return leftHand.range;
		}
		return Mathf.Min(leftHand.range, rightHand.range);
	}

	public int ComputeMaxWeaponRange(Character target)
	{
		EvaluateHandToHand(target);
		if (enableHandToHand)
		{
			return punchWeapon.baseRange;
		}
		if (leftHand == null || !leftHand.CanAttack(target))
		{
			if (rightHand == null || !rightHand.CanAttack(target))
			{
				return 1;
			}
			return rightHand.range;
		}
		if (rightHand == null || !rightHand.CanAttack(target))
		{
			return leftHand.range;
		}
		return Mathf.Max(leftHand.range, rightHand.range);
	}

	public bool OnlyHasStones()
	{
		return OnlyHasItem("stones");
	}

	private bool OnlyHasSightstone(Character target)
	{
		if (OnlyHasItem("sight_stone"))
		{
			SightstoneWeapon sightstoneWeapon = ((leftHand == null) ? (rightHand as SightstoneWeapon) : (leftHand as SightstoneWeapon));
			if (sightstoneWeapon != null)
			{
				return !sightstoneWeapon.CanAttack(target);
			}
		}
		return false;
	}

	private bool OnlyHasItem(string itemId)
	{
		if (!(leftHand == null) || !(rightHand != null) || !(rightHand.id == itemId))
		{
			if (rightHand == null && leftHand != null)
			{
				return leftHand.id == itemId;
			}
			return false;
		}
		return true;
	}

	private bool HasItemEquipped(string itemId)
	{
		if (!(leftHand != null) || !(leftHand.id == itemId))
		{
			if (rightHand != null)
			{
				return rightHand.id == itemId;
			}
			return false;
		}
		return true;
	}

	private void EvaluateHandToHand()
	{
		enableHandToHand = (leftHand == null && rightHand == null) || (OnlyHasStones() && InventoryResources.singleton.GetResourceOfType(Data.Resource.Stone) <= 0);
	}

	private void EvaluateHandToHand(Character target)
	{
		enableHandToHand = (leftHand == null && rightHand == null) || (OnlyHasStones() && InventoryResources.singleton.GetResourceOfType(Data.Resource.Stone) <= 0) || OnlyHasSightstone(target);
	}

	public void SetMoveDestination(int destinationX, int destinationZ, LookDirection lookDirectionOnArrival = LookDirection.Right)
	{
		GetComponent<HeroAI>().enabled = false;
		HeroCinematicController component = GetComponent<HeroCinematicController>();
		component.enabled = true;
		component.SetDestination(destinationX, destinationZ, lookDirectionOnArrival);
	}

	public void StopAttacking()
	{
		if (LeftHand != null)
		{
			LeftHand.SetState(Weapon.State.Waiting);
		}
		if (RightHand != null)
		{
			RightHand.SetState(Weapon.State.Waiting);
		}
		if (faerie != null && faerie.weapon != null)
		{
			faerie.weapon.SetState(Weapon.State.Waiting);
		}
	}

	public void PauseAI(float time)
	{
		GetComponent<HeroAI>().PauseForSeconds(time);
	}

	public void RestoreAI()
	{
		HeroAI component = GetComponent<HeroAI>();
		component.enabled = true;
		component.remainingPause = 0.001f;
		GetComponent<HeroCinematicController>().enabled = false;
	}

	public override void Die(DeathReason reason)
	{
		Damage damage = new Damage();
		damage.amount = 99999;
		damage.type = Damage.Type.Super;
		InflictDamage(damage);
	}

	private void HandleLifetimeEnded(Bullet bullet)
	{
		if (bullet.Owner == this && bullet.tags.Contains("melee"))
		{
			FloatingText floatingText = ShowFloatingText(Te.xt("MISSED"));
			if (floatingText != null)
			{
				floatingText.PositionX = bullet.PositionX;
			}
		}
	}

	private void HandleOnCharacterGoingToTakeDamage(Character character, Damage dmg)
	{
	}

	private void HandleOnCharacterDied(Character character, DeathReason reason, Damage damage)
	{
	}

	protected override void Start()
	{
		base.Start();
		if (sortTiebreaker < 0)
		{
			sortTiebreaker = 10;
		}
		Utils.PreloadAsyncPrefab("Weapons/HandToHand/punch", delegate(GameObject go)
		{
			punchWeapon = UnityEngine.Object.Instantiate(go).GetComponent<Weapon>();
			punchWeapon.transform.parent = base.transform;
			punchWeapon.Owner = this;
		});
		Utils.PreloadAsyncPrefab("Weapons/HandToHand/kick", delegate(GameObject go)
		{
			kickWeapon = UnityEngine.Object.Instantiate(go).GetComponent<Weapon>();
			kickWeapon.transform.parent = base.transform;
			kickWeapon.Owner = this;
		});
		idleSprite = base.MySprite;
		walkingAnimation.Sprite.Load();
		pickupAnimation.Sprite.Load();
		pullAnimation.Sprite.Load();
		mount.Load();
		Character.OnCharacterGoingToTakeDamage += HandleOnCharacterGoingToTakeDamage;
		Character.OnCharacterDied += HandleOnCharacterDied;
		Bullet.OnLifetimeEnded += HandleLifetimeEnded;
		base.lookDirection = LookDirection.Right;
		defaultTicsPerMoveH = GetComponent<HeroAI>().ticsPerMoveH;
	}

	protected override void Awake()
	{
		base.Awake();
		canChangeEquipment = true;
	}

	private void OnDestroy()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleOnCharacterGoingToTakeDamage;
		Character.OnCharacterDied -= HandleOnCharacterDied;
		Bullet.OnLifetimeEnded -= HandleLifetimeEnded;
	}

	public override void UpdateHitpoints()
	{
		level = XPController.singleton.currentLevel;
		base.UpdateHitpoints();
	}

	public void ReplenishHitpoints()
	{
		UpdateHitpoints();
		base.Hitpoints = Mathf.Max(base.Hitpoints, base.MaxHitpoints);
		f_hitpoints = new SafeFloat(base.Hitpoints);
		base.MaxArmor = 0f;
		if (base.statModController != null)
		{
			base.MaxArmor = base.statModController.ModMaxArmor(base.MaxArmor);
		}
		base.Armor = base.MaxArmor;
	}

	public void ResetTicsToMove()
	{
		GetComponent<HeroAI>().ticsPerMoveH = defaultTicsPerMoveH;
		GetComponent<HeroCinematicController>().ticsPerMoveH = defaultTicsPerMoveH;
	}

	private void Update()
	{
		if (frozenTics > 0)
		{
			return;
		}
		AsciiAnimation asciiAnimation = null;
		if (currentState == State.Walking)
		{
			asciiAnimation = walkingAnimation;
		}
		else if (currentState == State.PickingUp)
		{
			asciiAnimation = pickupAnimation;
		}
		if (asciiAnimation != null)
		{
			if (asciiAnimation.Playing && GameStates.Singleton.CurrentState != GameStates.State.Playing)
			{
				asciiAnimation.Pause();
			}
			else if (asciiAnimation.Paused && GameStates.Singleton.CurrentState == GameStates.State.Playing)
			{
				asciiAnimation.Play();
			}
		}
	}

	private void UpdateHasStoppedWalking()
	{
		if (lastPosX != base.PositionX || lastPosY != base.PositionY || lastPosZ != base.PositionZ)
		{
			lastPosX = base.PositionX;
			lastPosY = base.PositionY;
			lastPosZ = base.PositionZ;
			stationaryTics = 0;
		}
		else
		{
			stationaryTics++;
			if (stationaryTics >= 6)
			{
				SetState(State.Idle);
			}
		}
	}

	[StonescriptNativeGetter("ticsPerMove")]
	public object Property_GetTicsPerMove()
	{
		return GetComponent<HeroAI>().ticsPerMoveH;
	}

	[StonescriptNativeSetter("ticsPerMove")]
	public void Property_SetTicsPerMove(object value)
	{
		GetComponent<HeroAI>().ticsPerMoveH = (int)value;
		GetComponent<HeroCinematicController>().ticsPerMoveH = (int)value;
	}

	private void OnDestinationReached()
	{
		GetComponent<HeroCinematicController>().OnDestinationReached -= OnDestinationReached;
		IFunction function = destinationReachedCallbackMethod;
		List<object> parameters = destinationReachedCallbackParameters;
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		function?.Invoke(parameters);
	}

	[StonescriptNativeMethod]
	public object SetDestination(List<object> parameters, InvocationContext ctx)
	{
		GetComponent<HeroCinematicController>().OnDestinationReached -= OnDestinationReached;
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		int num = 0;
		int destinationX = (int)parameters[num++];
		int destinationZ = (int)parameters[num++];
		if (parameters.Count > num)
		{
			destinationReachedCallbackMethod = parameters[num++] as IFunction;
			if (parameters.Count > num)
			{
				if (!(parameters[num] is StonescriptArray))
				{
					throw new StonescriptRuntimeException("Invalid parameter list for SetDestination callback.");
				}
				destinationReachedCallbackParameters = (parameters[num++] as StonescriptArray).ToList<object>();
			}
			GetComponent<HeroCinematicController>().OnDestinationReached += OnDestinationReached;
		}
		SetMoveDestination(destinationX, destinationZ, LookDirection.None);
		return null;
	}

	[StonescriptNativeMethod]
	public object ClearDestination(List<object> parameters, InvocationContext ctx)
	{
		GetComponent<HeroCinematicController>().OnDestinationReached -= OnDestinationReached;
		GetComponent<HeroAI>().enabled = true;
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		return null;
	}

	[StonescriptNativeMethod]
	public object Stop(List<object> parameters, InvocationContext ctx)
	{
		RestoreAI();
		GetComponent<HeroAI>().enabled = false;
		lookDir_lastPos = (lookDir_lastPos2 = base.PositionX);
		return null;
	}

	[StonescriptNativeMethod]
	public object Resume(List<object> parameters, InvocationContext ctx)
	{
		RestoreAI();
		return null;
	}

	[StonescriptNativeMethod]
	public object HasItem(List<object> parameters, InvocationContext ctx)
	{
		string text = parameters[0] as string;
		return Inventory.Singleton.HasItemById(text);
	}

	[StonescriptNativeMethod]
	public object HasItemByGroupId(List<object> parameters, InvocationContext ctx)
	{
		string groupId = parameters[0] as string;
		return Inventory.Singleton.HasItemByGroupId(groupId);
	}

	[StonescriptNativeMethod]
	public object GetItemByGroupId(List<object> parameters, InvocationContext ctx)
	{
		string groupId = parameters[0] as string;
		return Inventory.Singleton.GetItem(groupId).ssObject;
	}

	[StonescriptNativeMethod]
	public object GetItemCountByGroupId(List<object> parameters, InvocationContext ctx)
	{
		string groupId = parameters[0] as string;
		Item item = Inventory.Singleton.GetItem(groupId);
		if (item == null)
		{
			return 0;
		}
		return item.count;
	}

	[StonescriptNativeMethod]
	public object RemoveItem(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("RemoveItem requires at least 1 parameter");
		}
		int amount = 1;
		if (parameters.Count >= 2 && parameters[1] is int)
		{
			amount = (int)parameters[1];
		}
		if (parameters[0] is string)
		{
			string itemId = parameters[0] as string;
			Inventory.Singleton.RemoveItemById(itemId, amount);
		}
		else if (parameters[0] is StonescriptObject)
		{
			SSScriptableObject scriptable = (parameters[0] as StonescriptObject).Scriptable;
			Item item = null;
			if (scriptable != null)
			{
				item = scriptable.GetComponent<Item>();
			}
			if (item == null)
			{
				throw new StonescriptRuntimeException("RemoveItem parameter 0 is not an item.");
			}
			Inventory.Singleton.RemoveItem(item, amount);
			if (item == LeftHand || item == RightHand || item == faerie.weapon)
			{
				Weapon weapon = item as Weapon;
				if (weapon != null)
				{
					Unequip(weapon);
				}
			}
		}
		return true;
	}

	[StonescriptNativeGetter("leftHand")]
	public object Property_GetLeftHand()
	{
		return leftHand?.ssObject;
	}

	[StonescriptNativeSetter("leftHand")]
	public void Property_SetLeftHand(object value)
	{
		if (value == null)
		{
			LeftHand = null;
		}
		else if (value is StonescriptObject)
		{
			Weapon weapon = (value as StonescriptObject)?.Scriptable?.GetComponent<Weapon>();
			if (weapon == null)
			{
				throw new Exception("The object assigned to rightHand is not a weapon.");
			}
			EquipLeft(weapon);
		}
		else if (value is string)
		{
			string criteria = value as string;
			Weapon weapon2 = Inventory.Singleton.FindBestWeapon(criteria, Weapon.HandType.RightOnly);
			if ((bool)weapon2)
			{
				EquipLeft(weapon2);
			}
		}
	}

	[StonescriptNativeGetter("rightHand")]
	public object Property_GetRightHand()
	{
		return rightHand?.ssObject;
	}

	[StonescriptNativeSetter("rightHand")]
	public void Property_SetRightHand(object value)
	{
		if (value == null)
		{
			RightHand = null;
		}
		else if (value is StonescriptObject)
		{
			Weapon weapon = (value as StonescriptObject)?.Scriptable?.GetComponent<Weapon>();
			if (weapon == null)
			{
				throw new Exception("The object assigned to rightHand is not a weapon.");
			}
			EquipRight(weapon);
		}
		else if (value is string)
		{
			string criteria = value as string;
			Weapon weapon2 = Inventory.Singleton.FindBestWeapon(criteria, Weapon.HandType.RightOnly);
			if ((bool)weapon2)
			{
				EquipRight(weapon2);
			}
		}
	}

	[StonescriptNativeMethod]
	public object IsEquipped(List<object> parameters, InvocationContext ctx)
	{
		string itemSearchCriteria = parameters[0] as string;
		return IsEquipped(itemSearchCriteria);
	}

	[StonescriptNativeMethod]
	public object EquipRight(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new Exception("Equip requires a weapon item or description.");
		}
		if (parameters[0] == null)
		{
			RightHand = null;
			return null;
		}
		if (parameters[0] is StonescriptObject)
		{
			Weapon weapon = (parameters[0] as StonescriptObject)?.Scriptable?.GetComponent<Weapon>();
			if (weapon == null)
			{
				throw new Exception("The object passed to Equip is not a weapon.");
			}
			EquipRight(weapon);
			return weapon.ssObject;
		}
		if (parameters[0] is string)
		{
			string criteria = parameters[0] as string;
			Weapon weapon2 = Inventory.Singleton.FindBestWeapon(criteria, Weapon.HandType.RightOnly);
			if ((bool)weapon2)
			{
				EquipRight(weapon2);
				return weapon2.ssObject;
			}
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object EquipLeft(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new Exception("Equip requires a weapon item or description.");
		}
		if (parameters[0] == null)
		{
			LeftHand = null;
			return null;
		}
		if (parameters[0] is StonescriptObject)
		{
			Weapon weapon = (parameters[0] as StonescriptObject)?.Scriptable?.GetComponent<Weapon>();
			if (weapon == null)
			{
				throw new Exception("The object passed to EquipLeft is not a weapon.");
			}
			EquipLeft(weapon);
			return weapon.ssObject;
		}
		if (parameters[0] is string)
		{
			string criteria = parameters[0] as string;
			Weapon weapon2 = Inventory.Singleton.FindBestWeapon(criteria, Weapon.HandType.LeftOnly);
			if ((bool)weapon2)
			{
				EquipLeft(weapon2);
				return weapon2.ssObject;
			}
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object Equip(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new Exception("Equip requires a weapon item or description.");
		}
		if (parameters[0] == null)
		{
			LeftHand = null;
			RightHand = null;
			return null;
		}
		if (parameters[0] is StonescriptObject)
		{
			Weapon weapon = (parameters[0] as StonescriptObject)?.Scriptable?.GetComponent<Weapon>();
			if (weapon == null)
			{
				throw new Exception("The object passed to Equip is not a weapon.");
			}
			Equip(weapon);
			return weapon.ssObject;
		}
		if (parameters[0] is string)
		{
			string criteria = parameters[0] as string;
			Weapon weapon2 = Inventory.Singleton.FindBestWeapon(criteria, Weapon.HandType.LeftOrRight);
			if ((bool)weapon2)
			{
				Equip(weapon2);
				return weapon2.ssObject;
			}
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object UnequipAll(List<object> parameters, InvocationContext ctx)
	{
		LeftHand = null;
		RightHand = null;
		return null;
	}

	[StonescriptNativeMethod]
	public object TryToAttack(List<object> parameters, InvocationContext ctx)
	{
		Character target = (parameters[0] as StonescriptObject).Scriptable?.Character;
		TryToAttack(target);
		return null;
	}

	[StonescriptNativeMethod]
	public object GetResource(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1)
		{
			throw new Exception("GetResource expects a resource.");
		}
		Data.Resource resourceType = InventoryResources.ParseResource(parameters[0] as string);
		return (int)InventoryResources.singleton.GetResourceOfType(resourceType);
	}

	[StonescriptNativeMethod]
	public object AddResource(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 2)
		{
			throw new Exception("RemoveResource expects a resource and an amount.");
		}
		Data.Resource resourceType = InventoryResources.ParseResource(parameters[0] as string);
		int num = (int)parameters[1];
		InventoryResources.singleton.AddResourceOfType(resourceType, num);
		return null;
	}

	[StonescriptNativeMethod]
	public object RemoveResource(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 2)
		{
			throw new Exception("RemoveResource expects a resource and an amount.");
		}
		Data.Resource resourceType = InventoryResources.ParseResource(parameters[0] as string);
		int num = (int)parameters[1];
		InventoryResources.singleton.RemoveResourceOfType(resourceType, num);
		return null;
	}

	[StonescriptNativeMethod]
	public object ActivateSightStone(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count <= 0)
		{
			throw new Exception("ActivateSightStone expects a target character.");
		}
		Weapon weapon = LeftHand;
		if (weapon == null || weapon.id != "sight_stone")
		{
			weapon = RightHand;
		}
		if (weapon != null && weapon.id == "sight_stone")
		{
			Character component = (parameters[0] as StonescriptObject).Scriptable.GetComponent<Character>();
			if (component != null)
			{
				weapon.Attack(component);
			}
		}
		return null;
	}
}
