using System.Collections.Generic;
using SafeTypes;
using Stonescript;
using Stonescript.Runtime;
using UnityEngine;

public class Uulaa : Decoration
{
	private enum UulaaState
	{
		Startup = 0,
		FakeShopFTUE = 1,
		Chillin = 2,
		ThanksForInfo = 3,
		GenericQueuedDialog = 4
	}

	public UulaaFakeShopFTUE fakeShopFTUE;

	public UulaaShopScreen shopPrefab;

	public AsciiAnimation talkAnim;

	public AsciiAnimation talkHappyAnim;

	public AsciiAnimation waveAnim;

	public NPCDialogBubble dialogBubble;

	private UulaaState currentUulaaState;

	private int elapsedTics;

	private AsciiSprite defaultSprite;

	private NPCDialogSequence dialogSequence = new NPCDialogSequence();

	private static bool hasSeen2xKiUpsell;

	private IFunction questCallback;

	private void SetUulaaState(UulaaState newState)
	{
		switch (newState)
		{
		case UulaaState.FakeShopFTUE:
			DestroyParticleEmitters();
			if (QuestController.singleton.IsAvailable("uulaa_shop"))
			{
				ShopData.Entry entry = new ShopData.Entry();
				entry.id = "";
				entry.title = "tid_treasure_GT";
				entry.treasures = new string[1] { "giant" };
				entry.copies = new SafeInt(1);
				fakeShopFTUE.crystalSlot.SetContent(entry);
			}
			else
			{
				ShopData.Entry entry2 = new ShopData.Entry();
				entry2.id = "";
				entry2.title = "tid_uulaa_shop_crystals";
				entry2.iconId = "Relics/KiCrystal/ki_crystal_icon_0";
				entry2.copies = new SafeInt(1);
				fakeShopFTUE.crystalSlot.SetContent(entry2);
			}
			break;
		case UulaaState.Chillin:
			base.MySprite = defaultSprite;
			break;
		case UulaaState.ThanksForInfo:
			waveAnim.Play();
			base.MySprite = waveAnim.Sprite;
			dialogBubble.SetMessage(Te.xt("tid_uulaa_shop_thanks"));
			dialogBubble.Show();
			break;
		default:
			_ = 4;
			break;
		}
		currentUulaaState = newState;
		elapsedTics = 0;
	}

	private void ActivateShop()
	{
		UulaaShopScreen.singleton.Show();
		SetUulaaState(UulaaState.Chillin);
	}

	private void ActivateDoubleKiUpsell()
	{
		dialogSequence.Clear();
		dialogSequence.Add(talkAnim, "uulaa_voice", string.Format(Te.xt("tid_uulaa_2x_ki_0"), HeroSettings.name));
		dialogSequence.Add("tid_uulaa_2x_ki_1");
		dialogSequence.Add("tid_uulaa_2x_ki_2");
		dialogSequence.Add(talkHappyAnim, "uulaa_voice", "tid_uulaa_2x_ki_3");
		dialogSequence.Add(waveAnim, null, "tid_uulaa_2x_ki_4");
		PlayDialogSequence();
	}

	private void ActivateHappyHolidays()
	{
		dialogSequence.Clear();
		dialogSequence.Add(waveAnim, "uulaa_voice", "tid_uulaa_winter");
		PlayDialogSequence();
	}

	private void PlayDialogSequence()
	{
		NPCDialogSequence.StepReturnData stepReturnData = dialogSequence.Next();
		if (stepReturnData.hasEnded)
		{
			ActivateShop();
			return;
		}
		dialogBubble.SetMessage(stepReturnData.message);
		dialogBubble.Show();
		if (stepReturnData.animation != null)
		{
			stepReturnData.animation.Stop();
			stepReturnData.animation.Play();
			base.MySprite = stepReturnData.animation.Sprite;
		}
		SetUulaaState(UulaaState.GenericQueuedDialog);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedTics++;
		if (currentUulaaState == UulaaState.Startup)
		{
			if (elapsedTics == 1 && GameStates.Singleton.level.QuestData.id == "uulaa_shop")
			{
				DestroyParticleEmitters();
			}
			else
			{
				if (elapsedTics == 35)
				{
					_ = hasSeen2xKiUpsell;
				}
				if (elapsedTics == 35 && GameStates.Singleton.level.QuestData.id == "uulaa_shop" && EventController.singleton.IsEventActiveAndStarted("winter"))
				{
					ActivateHappyHolidays();
				}
				else if (elapsedTics == 35 && GameStates.Singleton.level.QuestData.id == "uulaa_shop")
				{
					ActivateShop();
				}
			}
		}
		else if (currentUulaaState == UulaaState.FakeShopFTUE)
		{
			fakeShopFTUE.UpdateTic();
		}
		else if (currentUulaaState == UulaaState.ThanksForInfo)
		{
			dialogBubble.UpdateTic();
			if (elapsedTics == 85)
			{
				dialogBubble.Hide();
			}
			else if (elapsedTics >= 90)
			{
				SetUulaaState(UulaaState.Chillin);
			}
		}
		else if (currentUulaaState == UulaaState.GenericQueuedDialog)
		{
			dialogBubble.UpdateTic();
			if (dialogBubble.npcDialogState == NPCDialogBubble.NPCDialogState.Done)
			{
				PlayDialogSequence();
			}
		}
		UulaaShopScreen.singleton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		UulaaShopScreen.singleton.Draw(r, r.width >> 1, 0);
		if (currentUulaaState == UulaaState.FakeShopFTUE)
		{
			fakeShopFTUE.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentUulaaState == UulaaState.ThanksForInfo)
		{
			dialogBubble.SetNPCMouthPosition(base.MySprite.lastDrawX, base.MySprite.lastDrawY + 1);
			int offsetX2 = base.MySprite.lastDrawX;
			int offsetY2 = base.MySprite.lastDrawY;
			dialogBubble.Draw(r, offsetX2, offsetY2);
		}
		else if (currentUulaaState == UulaaState.GenericQueuedDialog)
		{
			dialogBubble.SetNPCMouthPosition(base.MySprite.lastDrawX + 9, base.MySprite.lastDrawY + 1);
			int offsetX3 = base.MySprite.lastDrawX - 20;
			int offsetY3 = base.MySprite.lastDrawY - 6;
			dialogBubble.Draw(r, offsetX3, offsetY3);
		}
	}

	private void DestroyParticleEmitters()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("destroy_emitter");
		for (int i = 0; i < array.Length; i++)
		{
			Object.Destroy(array[i]);
		}
	}

	private void HandleFTUECrystalPressed(DialogButton btn)
	{
		SetUulaaState(UulaaState.Startup);
		if (QuestController.singleton.IsAvailable("uulaa_shop"))
		{
			List<ItemData.Element> list = new List<ItemData.Element>(1);
			list.Add(ItemData.Element.Fire);
			Item item = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_2", list);
			GameStates.Singleton.AddItemFromPickup(item);
		}
		else
		{
			Item item2 = Inventory.Singleton.MakeReward("ki_crystal", 1);
			GameStates.Singleton.AddItemFromPickup(item2, 20);
			if (item2.count > 20)
			{
				item2.count = 20;
			}
		}
		SfxController.singleton.Play("pickup_success");
	}

	private void HandleDailyCrystal()
	{
		SetUulaaState(UulaaState.ThanksForInfo);
	}

	private void OnDestroy()
	{
		fakeShopFTUE.crystalSlot.OnPressed -= HandleFTUECrystalPressed;
		UulaaShopScreen.singleton.OnDailyCrystal -= HandleDailyCrystal;
	}

	protected override void Awake()
	{
		base.Awake();
		fakeShopFTUE.crystalSlot.OnPressed += HandleFTUECrystalPressed;
		if (UulaaShopScreen.singleton == null)
		{
			Object.Instantiate(shopPrefab);
		}
		UulaaShopScreen.singleton.Hide();
		UulaaShopScreen.singleton.OnDailyCrystal += HandleDailyCrystal;
		defaultSprite = base.MySprite;
	}

	[StonescriptNativeMethod]
	public object ShowCrystalFTUE(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count <= 0 || !(parameters[0] is IFunction))
		{
			throw new RuntimeException(ctx, "ShowCrystalFTUE expected a function as parameter.");
		}
		questCallback = parameters[0] as IFunction;
		GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
		SequentialPopupManager.singleton.itemFoundDialog.OnDone += OnRewardDialogDone;
		SequentialPopupManager.singleton.itemFoundDialog.mode = ItemFoundDialog.DialogMode.CustomQuest;
		SetUulaaState(UulaaState.FakeShopFTUE);
		UulaaShopScreen.singleton.PanCameraForShop();
		return null;
	}

	private void OnRewardDialogDone()
	{
		SequentialPopupManager.singleton.itemFoundDialog.mode = ItemFoundDialog.DialogMode.Normal;
		SequentialPopupManager.singleton.itemFoundDialog.OnDone -= OnRewardDialogDone;
		IFunction function = questCallback;
		questCallback = null;
		function?.Invoke();
		UulaaShopScreen.singleton.PanCameraForUUlaa();
	}

	[StonescriptNativeMethod]
	public object ShowShop(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count <= 0 || !(parameters[0] is IFunction))
		{
			throw new RuntimeException(ctx, "ShowShop expected a function as parameter.");
		}
		questCallback = parameters[0] as IFunction;
		UulaaShopScreen.singleton.OnShopDone += HandleShopDone;
		UulaaShopScreen.singleton.Show();
		return null;
	}

	private void HandleShopDone()
	{
		UulaaShopScreen.singleton.OnShopDone -= HandleShopDone;
		IFunction function = questCallback;
		questCallback = null;
		function?.Invoke();
		QuestController.singleton.MakeAvailable("uulaa_shop");
		int availableQuestIndex = QuestController.singleton.GetAvailableQuestIndex("mushroom_shop");
		QuestController.singleton.SetAvailableQuestIndex("uulaa_shop", availableQuestIndex - 1);
	}
}
