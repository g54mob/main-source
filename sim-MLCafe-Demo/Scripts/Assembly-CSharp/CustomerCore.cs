using System;
using UnityEngine;
using UnityEngine.AI;

public class CustomerCore : MonoBehaviour
{
	[SerializeField]
	private EntityNameTag entityNameTag;

	[SerializeField]
	private CustomerNeeds needs;

	[SerializeField]
	private CustomerRating rating;

	[SerializeField]
	private Product.ProductSize[] preferredSizes;

	[SerializeField]
	private int evaluationValue;

	[SerializeField]
	private int paidPrice;

	[Range(0f, 100f)]
	[SerializeField]
	private int propabilityPriceReaction = 100;

	[SerializeField]
	private CustomerUIInfo customerUIInfo;

	[SerializeField]
	private CharacterVariationLibrary customerVariantLibrary;

	[SerializeField]
	private Transform variantContainer;

	[SerializeField]
	private Animator animator;

	private Transform handBone;

	[SerializeField]
	private ItemSocket socket;

	[SerializeField]
	private string hintTag = "Customer_Interaction";

	[Header("Localization")]
	[SerializeField]
	private string localizationKeyGiveInvalidItemToCustomer;

	[Header("Sound")]
	[SerializeField]
	private string soundTalking;

	[SerializeField]
	private bool usePitchVariation;

	[SerializeField]
	private float pitchVariationAddition;

	[SerializeField]
	private string soundDirtGoo = "characters_spawn_dirt_goo";

	[Header("Dirt")]
	[SerializeField]
	private GameObject[] dirtObstacles;

	[SerializeField]
	private int waitTicksForDirtSpawnCheck = 30;

	private int maxDirtSpawns = 2;

	private int waitedDirtTicks;

	private int spawnedDirt;

	public Transform spawnPoint;

	private Outline outline;

	private FSMManager statemachine;

	public Transform GetSpawnPoint()
	{
		return spawnPoint;
	}

	public void ApplySpawnPoint(Transform spot)
	{
		spawnPoint = spot;
	}

	public ItemSocket GetCupSocket()
	{
		return socket;
	}

	public void SetNameTag(EntityNameTag nameTag)
	{
		entityNameTag = nameTag;
		entityNameTag.SetID(Guid.NewGuid().GetHashCode());
	}

	public EntityNameTag GetNameTag()
	{
		return entityNameTag;
	}

	public CustomerNeeds GetCustomerNeeds()
	{
		return needs;
	}

	public CustomerRating GetRating()
	{
		return rating;
	}

	public CustomerUIInfo GetCustomerUIInfo()
	{
		return customerUIInfo;
	}

	public void SetAnimationLayer(int layer, float weight)
	{
		animator.SetLayerWeight(layer, weight);
	}

	public void SetAnimationState(string key, bool state)
	{
		animator.SetBool(key, state);
	}

	public void TriggerAnimationState(string key)
	{
		animator.SetTrigger(key);
	}

	private void Start()
	{
		CreateCustomerVariant();
		outline = GetComponent<Outline>();
		statemachine = GetComponentInChildren<FSMManager>();
		rating = CustomerRating.Start();
	}

	private void Update()
	{
		socket.transform.position = handBone.position;
		socket.transform.rotation = handBone.rotation;
	}

	public void Init()
	{
		string randomNameKey = CustomerManager.GetRandomNameKey();
		if (randomNameKey == "")
		{
			entityNameTag = new EntityNameTag("", CustomerManager.GetCustomerNameColor());
		}
		else
		{
			entityNameTag = new EntityNameTag(randomNameKey, CustomerManager.GetCustomerNameColor());
		}
		SetNameTag(entityNameTag);
		if (!ProductManager.IsValidated() || preferredSizes == null || preferredSizes.Length == 0)
		{
			preferredSizes = new Product.ProductSize[0];
			needs = new CustomerNeeds(preferredSizes[0]);
		}
		else
		{
			int num = UnityEngine.Random.Range(0, ProductManager.GetUnlockedProductSizes().Length);
			if (num >= preferredSizes.Length)
			{
				num = preferredSizes.Length - 1;
			}
			else if (num < 0)
			{
				num = 0;
			}
			needs = new CustomerNeeds(preferredSizes[num]);
		}
		GetComponent<NavMeshAgent>().avoidancePriority = UnityEngine.Random.Range(0, 6000);
		if (statemachine == null)
		{
			statemachine = GetComponentInChildren<FSMManager>();
		}
		if (needs.sellingProductId == -1)
		{
			statemachine.Dismiss();
		}
	}

	public void CreateCustomerVariant()
	{
		CustomerVariantInstance component = UnityEngine.Object.Instantiate(customerVariantLibrary.GetRandomVariant().baseCharacter, variantContainer).GetComponent<CustomerVariantInstance>();
		animator = component.GetAnimator();
		handBone = component.GetHandBone();
	}

	public void OnPlayerInteraction(CharacterControllerComponent character)
	{
		string activeState = statemachine.ReadActiveState();
		FSMState currentState = statemachine.currentRoutine.GetCurrentState();
		HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
		if (PopupMessageManager.GetPopHint().TryShow(hintBoxByTag))
		{
			return;
		}
		if (currentState.GetType() == typeof(CafeState))
		{
			PlayChattingDialog(activeState);
			return;
		}
		if (character.GetSocket().IsHoldingItem())
		{
			if (!rating.gotServiced && EvaluateItemInteraction(character.GetSocket().GetItemComponent()))
			{
				ReceiveCoffee(character, currentState);
			}
			return;
		}
		DialogSequence dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsState(activeState));
		if (dialogSequence == null)
		{
			DialogSequenceManager.PlayDialogSequence(new Dialog(GetNameTag(), new string[1] { DialogManager.GetMissingDialog() }, soundTalking, autoProceed: true));
		}
		else if (currentState.GetType() == typeof(WaitForServiceState))
		{
			if (!rating.gotServiced)
			{
				PlayProductAskingDialog(activeState, currentState);
			}
		}
		else
		{
			DialogSequenceManager.PlayDialogSequence(dialogSequence.AsDialog(GetNameTag(), dialogSequence.sound));
		}
	}

	private void ReceiveCoffee(CharacterControllerComponent character, FSMState currentState)
	{
		ItemComponent coffee = character.socket.GetItemComponent();
		if (coffee != null)
		{
			coffee.DeactivateCollision();
			coffee.socket.Clear();
			coffee.transform.parent = null;
			coffee.psMovingTrails.Play();
			TweenerManager.TweenTimeAction(entityNameTag.GetID() + "_emit_movingparticles", 3f, delegate
			{
				coffee.psMovingTrails.Stop();
			});
		}
		socket.PushItem(coffee, default(Vector3), reactivateCollision: false, 3f);
		socket.GetItemComponent().DeactivateCollision();
		Action action = delegate
		{
			((WaitForServiceState)currentState).assignedPoint.Free();
			GetComponent<NavMeshAgent>().ResetPath();
			if (CafeShopManager.IsCafeOpen())
			{
				statemachine.currentRoutine.NextRoutine();
			}
			else
			{
				statemachine.Dismiss();
			}
			SetAnimationState("Coffee", state: true);
			SetAnimationLayer(1, 1f);
		};
		TriggerAnimationState("ReceiveCoffee");
		TweenerManager.TweenTimeAction("MoveFromCounter", 4.5f, action);
		rating.gotServiced = true;
	}

	private bool EvaluateItemInteraction(ItemComponent itemComponent)
	{
		if (itemComponent.productComponent != null && itemComponent.GetComponent<CupComponent>() != null)
		{
			if (!itemComponent.productComponent.IsHoldingProduct())
			{
				DialogSequenceManager.PlayDialogSequence(new Dialog(GetNameTag(), new string[1] { localizationKeyGiveInvalidItemToCustomer }, soundTalking, autoProceed: true));
				return false;
			}
			ProgressionManager.GainXP("ServedCoffee", 1);
			return EvaluateProduct(itemComponent.productComponent);
		}
		DialogSequenceManager.PlayDialogSequence(new Dialog(GetNameTag(), new string[1] { localizationKeyGiveInvalidItemToCustomer }, soundTalking, autoProceed: true));
		return false;
	}

	private bool EvaluateProduct(ProductComponent productComponent)
	{
		if (!productComponent.IsHoldingProduct())
		{
			Debug.LogError("TODO: Evaluate Product -> No Holding Product");
			return false;
		}
		evaluationValue = needs.EvaluateReceivingProduct(productComponent.GetProduct(), null) + CustomerManager.GetCleanupRating();
		PriceRating priceRating = ProductManager.GetPriceRating(productComponent.GetProduct().id);
		EvaluatePayAndDialog(evaluationValue, ProductManager.GetProductPrice(productComponent.GetProduct().id, productComponent.GetProduct().size), priceRating);
		return true;
	}

	private void EvaluatePayAndDialog(int evaluation, int receivingProductWorth, PriceRating priceRating)
	{
		int num = receivingProductWorth;
		int num2 = 0;
		int num3 = 128;
		DialogSequence dialogSequence = null;
		bool flag = false;
		DialogSequence dialogSequence2 = null;
		int num4 = 0;
		int num5 = Mathf.RoundToInt((float)(receivingProductWorth / 4) * GameModeManager.GetGameModeValue<float>("gm_customer_tips_multiplier"));
		if (num < priceRating.minPrice)
		{
			dialogSequence2 = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductCheap"));
			flag = true;
			num4 += 16;
			num5 = receivingProductWorth / 2;
		}
		if (num > priceRating.maxPrice)
		{
			dialogSequence2 = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductExpensive"));
			flag = true;
			num4 -= 48;
			num5 = 0;
		}
		if (evaluation > CustomerRating.GetDevineMin() || evaluation >= CustomerRating.GetDevineMax())
		{
			dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductDivine"));
			num2 = UnityEngine.Random.Range(num5 * 3, num5 * 5);
			num3 = 255 + num4;
		}
		else
		{
			num3 = evaluation + num4;
		}
		if (evaluation > CustomerRating.GetGreatMin() && evaluation <= CustomerRating.GetGreatMax())
		{
			dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductGreat"));
			num2 = (int)UnityEngine.Random.Range((float)num5 * 2f, num5 * 4);
		}
		if (evaluation > CustomerRating.GetGoodMin() && evaluation <= CustomerRating.GetGoodMax())
		{
			dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductGood"));
			num2 = (int)UnityEngine.Random.Range(num5, (float)num5 * 3f);
		}
		if (evaluation > CustomerRating.GetOkMin() && evaluation <= CustomerRating.GetOkMax())
		{
			dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductOk"));
			num2 = UnityEngine.Random.Range(num5, num5 * 2);
		}
		if (evaluation > CustomerRating.GetMehMin() && evaluation <= CustomerRating.GetMehMax())
		{
			dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductMeh"));
			num2 = 0;
		}
		if (evaluation >= CustomerRating.GetDisgustingMin() && evaluation <= CustomerRating.GetDisgustingMax())
		{
			dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductDisgusting"));
			num = receivingProductWorth / 2;
			num2 = 0;
		}
		WaitForServiceState waitForServiceState = (WaitForServiceState)statemachine.currentRoutine.GetCurrentState();
		if ((double)waitForServiceState.GetCurrentWaitingCount() < (double)waitForServiceState.GetMaxWaitCount() * 0.25)
		{
			rating.service = byte.MaxValue;
		}
		else
		{
			float t = Mathf.InverseLerp(0f, waitForServiceState.GetMaxWaitCount(), waitForServiceState.GetCurrentWaitingCount());
			rating.service = (byte)(128f + Mathf.Lerp(100f, -120f, t) + (float)num4);
		}
		rating.product = (byte)num3;
		rating.cleanness = CustomerManager.GetCleanupRating();
		paidPrice = num + num2;
		waitForServiceState.assignedCounter.Pay(paidPrice, num, num2);
		ProgressionManager.GainXP("Tip", num2);
		if (dialogSequence == null)
		{
			DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, new string[1] { DialogManager.GetMissingDialog() }, soundTalking, autoProceed: true));
			return;
		}
		int num6 = UnityEngine.Random.Range(0, 100);
		if (flag && dialogSequence2 != null && num6 < propabilityPriceReaction)
		{
			string randomDialogKey = dialogSequence.GetRandomDialogKey();
			string randomDialogKey2 = dialogSequence2.GetRandomDialogKey();
			string[] sentenceKeys = new string[2] { randomDialogKey, randomDialogKey2 };
			DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, sentenceKeys, dialogSequence2.sound, autoProceed: true), customerUIInfo.GetLocalDialogBoxComponent());
		}
		else
		{
			DialogSequenceManager.PlayDialogSequence(dialogSequence.GetSingleRandomAsDialog(entityNameTag), customerUIInfo.GetLocalDialogBoxComponent());
		}
	}

	public void WaitedTooLongForService()
	{
		rating.service -= 64;
	}

	public void Dismiss()
	{
		statemachine.Dismiss();
	}

	private void PlayChattingDialog(string activeState)
	{
		if (DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsState(activeState)) == null)
		{
			DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, new string[1] { DialogManager.GetMissingDialog() }, soundTalking, autoProceed: true));
		}
		else
		{
			DialogSequenceManager.PlayDialogSequence(DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("Chatting")).GetSingleRandomAsDialog(entityNameTag, soundTalking));
		}
	}

	private void PlayProductAskingDialog(string activeState, FSMState currentState)
	{
		DialogSequence dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsState(activeState));
		WaitForServiceState waitForServiceState = (WaitForServiceState)currentState;
		if (waitForServiceState.assignedCounter.IsFirstPositionInQue(waitForServiceState.assignedPoint))
		{
			dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("ProductAsking"));
			if (dialogSequence != null)
			{
				string text = dialogSequence.GetRandomDialog() + needs.GetProductDialog();
				DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, new string[1] { text }, dialogSequence.sound, autoProceed: true, isLocalized: true));
			}
		}
		else
		{
			dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag(""));
			if (dialogSequence != null)
			{
				DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, new string[1] { dialogSequence.GetFirst() }, dialogSequence.sound, autoProceed: true, isLocalized: true));
			}
		}
	}

	public void Speak(string msg)
	{
		DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, new string[1] { msg }, soundTalking, autoProceed: true, isLocalized: true), customerUIInfo.GetLocalDialogBoxComponent());
	}

	public void TrySpawnDirt()
	{
		maxDirtSpawns = GameModeManager.GetGameModeValue<int>("gm_customer_spawn_dirt_max");
		if (spawnedDirt >= maxDirtSpawns || waitedDirtTicks < waitTicksForDirtSpawnCheck)
		{
			return;
		}
		waitedDirtTicks = 0;
		if (GameModeManager.GetGameModeValue<bool>("gm_customer_spawn_dirt_enabled"))
		{
			int gameModeValue = GameModeManager.GetGameModeValue<int>("gm_customer_spawn_dirt_chance");
			if (UnityEngine.Random.Range(0, 100) <= gameModeValue)
			{
				SpawnDirt();
			}
		}
	}

	public void SpawnDirt()
	{
		if (CafeShopManager.IsCustomerInsideCafe(this))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(dirtObstacles[UnityEngine.Random.Range(0, dirtObstacles.Length)]);
			gameObject.transform.position = new Vector3(base.transform.position.x, 0.08f, base.transform.position.z);
			gameObject.transform.localScale = Vector3.zero;
			TweenerManager.TweenScale(entityNameTag.GetID() + "_DirtSpawn", gameObject.transform, Vector3.zero, Vector3.one, 0.5f, TweenerManager.GetDefaultEaseCurve());
			SoundManager.PlaySoundOnce(soundDirtGoo);
			spawnedDirt++;
		}
	}
}
