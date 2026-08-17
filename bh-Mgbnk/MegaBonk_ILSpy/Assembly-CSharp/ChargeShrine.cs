using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class ChargeShrine : BaseInteractable
{
	private float chargeTime = 5f;

	private float currentChargeTime = 5f;

	private float chargeProgress;

	public Renderer zoneRenderer;

	public Renderer meshRenderer;

	public Transform runeStone;

	private MaterialPropertyBlock zonePropertyBlock;

	private MaterialPropertyBlock rendererPropertyBlock;

	private Color zoneColor;

	private Color startColor;

	public GameObject minimapIcon;

	public Image circleProgress;

	public CanvasGroup circleParent;

	public AudioSource audioStart;

	public AudioSource audioLoop;

	public AudioSource audioComplete;

	public AudioSource audioAbort;

	public GameObject finishParticles;

	public GameObject altarIcon;

	public GameObject healingZone;

	private bool notInterrupted = true;

	public static Action A_ChargeShrineSpawned;

	public static Action<bool> A_Charged;

	private float goldChance = 0.008f;

	private bool _003CisGolden_003Ek__BackingField;

	public Material goldMaterial;

	private bool wasLoopAudioPlayingWhenPaused;

	private float pitchStart = 0.5f;

	private float pitchEnd = 1.5f;

	private bool completed;

	private float rewardTime;

	private bool rewardGiven;

	public static ChargeShrine lastRewardShrine;

	private bool charging;

	private float volumeWhenExit;

	public static string debugName = "Charge Shrines";

	public bool isGolden
	{
		get
		{
			return _003CisGolden_003Ek__BackingField;
		}
		private set
		{
			_003CisGolden_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_0095: Expected I, but got O
		//IL_00a6: Expected O, but got I4
		//IL_00af: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		float num = UnityEngine.Random.Range(0f, 1f);
		if (!(goldChance > num))
		{
			_003CisGolden_003Ek__BackingField = false;
		}
		else
		{
			_003CisGolden_003Ek__BackingField = true;
			meshRenderer.SetMaterial(goldMaterial);
		}
		Action<bool> b = OnPause;
		Delegate obj = Delegate.Combine(MyTime.A_Pause, b);
		if ((object)obj == null)
		{
			MyTime.A_Pause = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		bool flag = action == null;
		nint num2 = (nint)typeof(Action<bool>);
		Delegate obj2 = obj;
		object obj3 = 0;
		object obj4 = 0;
		if (!flag)
		{
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag2 = obj5 == null;
			obj4 = 0;
			if (!flag2)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			IntPtr intPtr = default(IntPtr);
			num2 = intPtr;
			Delegate obj6 = default(Delegate);
			obj2 = obj6;
			object obj7 = default(object);
			obj3 = obj7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> value = OnPause;
		Delegate obj = Delegate.Remove(MyTime.A_Pause, value);
		if ((object)obj == null)
		{
			MyTime.A_Pause = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new unsafe void Start()
	{
		//IL_001d: Expected O, but got Ref
		//IL_0034: Expected O, but got Ref
		//IL_0070: Expected O, but got Ref
		//IL_0107: Expected O, but got F4
		//IL_0169: Expected O, but got I
		//IL_017f: Expected O, but got I
		//IL_0195: Expected O, but got I
		//IL_01ae: Expected O, but got Ref
		//IL_01dd: Expected O, but got Ref
		base.Start();
		Transform transform = minimapIcon.transform;
		float num = default(float);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num));
		transform.rotation = (Quaternion)(&num);
		circleParent.alpha = 0f;
		Transform transform2 = runeStone.transform;
		transform2.localScale = (Vector3)(&num);
		GameObject gameObject = runeStone.gameObject;
		gameObject.SetActive(value: false);
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		zonePropertyBlock = materialPropertyBlock;
		zoneRenderer.Internal_GetPropertyBlock(zonePropertyBlock);
		float saturationMax = default(float);
		float valueMin = default(float);
		float valueMax = default(float);
		float alphaMin = default(float);
		zoneColor = (Color)UnityEngine.Random.ColorHSV(0f, 1f, 0.5f, saturationMax, valueMin, valueMax, alphaMin, 1f).r;
		startColor = zoneColor;
		_ = 0;
		MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
		rendererPropertyBlock = materialPropertyBlock2;
		meshRenderer.Internal_GetPropertyBlock(rendererPropertyBlock);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ChargeShrine)+94]");
		object obj = (nint)0 * (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ChargeShrine)+98]");
		object obj2 = (nint)0 * (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ChargeShrine)+9C]");
		object obj3 = (nint)0 * (nint)0;
		Vector3 vector = default(Vector3);
		rendererPropertyBlock.SetColor("_EmissionColor", (Color)(&vector));
		meshRenderer.Internal_SetPropertyBlock(rendererPropertyBlock);
		zonePropertyBlock.SetColor("_MainColor", (Color)(&num));
		zoneRenderer.Internal_SetPropertyBlock(zonePropertyBlock);
		zoneRenderer.enabled = false;
		Action a_ChargeShrineSpawned = A_ChargeShrineSpawned;
		if (A_ChargeShrineSpawned != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v345.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void FindChargeTime()
	{
		//IL_0063: Expected I, but got O
		//IL_0071: Expected I, but got O
		//IL_0081: Expected O, but got I
		//IL_0101: Expected O, but got I4
		//IL_00bd: Expected O, but got I
		//IL_00f3: Expected O, but got I4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		ItemBase item = inventory.itemInventory.GetItem(EItem.Wrench);
		if (item == null)
		{
			currentChargeTime = chargeTime;
			return;
		}
		nint num = (nint)item;
		nint num2 = (nint)typeof(ItemWrench);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v14+FFFFFFF8+v179 @ rax_v10*8]");
			if (0 == (nint)typeof(ItemWrench))
			{
				obj3 = 1;
				goto IL_019c;
			}
		}
		obj3 = 0;
		goto IL_019c;
		IL_019c:
		float num4 = chargeTime;
		bool flag = obj3 == null;
		ItemWrench itemWrench = null;
		if (!flag)
		{
			itemWrench = (ItemWrench)item;
		}
		if (itemWrench != null)
		{
			float chargeSpeedIncrease = itemWrench.GetChargeSpeedIncrease();
			float num5 = chargeSpeedIncrease * num4;
			num4 -= num5;
			if (!(0.2f > num4))
			{
				if (num4 > chargeTime)
				{
					currentChargeTime = chargeTime;
					return;
				}
			}
			else
			{
				num4 = 0.2f;
			}
		}
		currentChargeTime = num4;
	}

	private unsafe void Update()
	{
		//IL_00b9: Invalid comparison between I4 and F4
		//IL_016d: Invalid comparison between I4 and F4
		//IL_0216: Invalid comparison between I4 and F4
		//IL_0261: Expected F4, but got I4
		//IL_027a: Expected O, but got Ref
		//IL_02bf: Expected O, but got Ref
		//IL_02fb: Expected O, but got Ref
		//IL_0306: Invalid comparison between I4 and F4
		//IL_0360: Expected O, but got Ref
		if (!rewardGiven && completed && !(MyTime.time < rewardTime) && !rewardGiven)
		{
			lastRewardShrine = this;
			rewardGiven = true;
			UiManager instance = UiManager.Instance;
			instance.encounterWindows.AddEncounter(EEncounter.RandomStats);
		}
		if (!(chargeProgress < 1f) || (!charging && !(0f < chargeProgress)))
		{
			return;
		}
		float num3;
		if (!charging)
		{
			float num = currentChargeTime * 0.25f;
			float num2 = MyTime.deltaTime / num;
			num3 = chargeProgress - num2;
		}
		else
		{
			float num4 = MyTime.deltaTime / currentChargeTime;
			float num5 = num4 + chargeProgress;
			num3 = num5;
		}
		chargeProgress = num3;
		if (num3 < 1f)
		{
			if (!(0f < num3))
			{
				chargeProgress = 0f;
			}
		}
		else
		{
			chargeProgress = 1f;
			Complete();
		}
		float num6 = pitchEnd - pitchStart;
		float num7 = num6 * chargeProgress;
		float pitch = num7 + pitchStart;
		audioLoop.pitch = pitch;
		circleProgress.fillAmount = chargeProgress;
		float num8 = chargeProgress;
		if (!(0f > chargeProgress))
		{
			if (num8 > 1f)
			{
				num8 = 1f;
			}
		}
		else
		{
			num8 = 0f;
		}
		float num9 = default(float);
		zonePropertyBlock.SetColor("_MainColor", (Color)(&num9));
		zoneRenderer.Internal_SetPropertyBlock(zonePropertyBlock);
		meshRenderer.Internal_GetPropertyBlock(rendererPropertyBlock);
		rendererPropertyBlock.SetColor("_EmissionColor", (Color)(&num9));
		meshRenderer.Internal_SetPropertyBlock(rendererPropertyBlock);
		Transform transform = runeStone.transform;
		transform.localScale = (Vector3)(&num9);
		if (!(0f < chargeProgress))
		{
			chargeProgress = 0f;
			zoneRenderer.enabled = false;
			Transform transform2 = runeStone.transform;
			transform2.localScale = (Vector3)(&num9);
			GameObject gameObject = runeStone.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private void OnPause(bool paused)
	{
		if (!paused)
		{
			if (wasLoopAudioPlayingWhenPaused != paused)
			{
				audioLoop.Play();
			}
		}
		else
		{
			bool isPlaying = audioLoop.isPlaying;
			wasLoopAudioPlayingWhenPaused = isPlaying;
			audioLoop.Pause();
		}
	}

	private unsafe void Complete()
	{
		//IL_007e: Expected O, but got Ref
		//IL_007e: Expected O, but got Ref
		//IL_00a6: Expected O, but got Ref
		//IL_0151: Expected I, but got O
		//IL_015f: Expected I, but got O
		//IL_016f: Expected O, but got I
		//IL_01ab: Expected O, but got I
		completed = true;
		audioLoop.Stop();
		audioComplete.Play();
		zoneRenderer.enabled = false;
		circleParent.alpha = 0f;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		Quaternion quaternion = default(Quaternion);
		GameObject gameObject = UnityEngine.Object.Instantiate(finishParticles, (Vector3)(&obj), (Quaternion)(&quaternion));
		ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
		component.startColor = (Color)(&quaternion);
		Invoke("ScorePopup", 0.2f);
		float num = MyTime.time + 0.5f;
		rewardTime = num;
		minimapIcon.SetActive(value: false);
		altarIcon.SetActive(value: false);
		ControllerShaker.Shake(0, 0.4f, 0.2f);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		ItemBase item = inventory.itemInventory.GetItem(EItem.Beacon);
		if (item != null)
		{
			nint num2 = (nint)item;
			nint num3 = (nint)typeof(ItemBeacon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v17 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBeacon>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r8_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v17 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBeacon>)+130]");
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r8_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v38+FFFFFFF8+v435 @ rax_v37*8]");
				if (0 == (nint)typeof(ItemBeacon))
				{
					Transform transform2 = healingZone.transform;
					transform2.parentInternal = null;
					healingZone.SetActive(value: true);
				}
			}
		}
		Action<bool> a_Charged = A_Charged;
		if (A_Charged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v302 @ r9_v5 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private void ScorePopup()
	{
		UiManager instance = UiManager.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("Game_ScoreUi", "POPUP_SHRINE");
		bool useSfx = default(bool);
		float sizeMultiplier = default(float);
		instance.scoreUi.AddScore(localizedString, "+1", isPositive: true, useSfx, sizeMultiplier);
	}

	private void Reward()
	{
		if (!rewardGiven)
		{
			lastRewardShrine = this;
			rewardGiven = true;
			UiManager instance = UiManager.Instance;
			instance.encounterWindows.AddEncounter(EEncounter.RandomStats);
		}
	}

	private void OnTriggerEnter()
	{
		//IL_014a: Expected I, but got O
		//IL_0158: Expected I, but got O
		//IL_0168: Expected O, but got I
		//IL_01e8: Expected O, but got I4
		//IL_01a4: Expected O, but got I
		//IL_01da: Expected O, but got I4
		if (completed || charging)
		{
			return;
		}
		circleParent.alpha = 1f;
		zoneRenderer.enabled = true;
		charging = true;
		audioLoop.pitch = 1f;
		audioLoop.volume = 1f;
		audioStart.Play();
		audioLoop.Play();
		GameObject gameObject = runeStone.gameObject;
		gameObject.SetActive(value: true);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		ItemBase item = inventory.itemInventory.GetItem(EItem.Wrench);
		float num;
		if (item == null)
		{
			num = chargeTime;
			goto IL_0286;
		}
		nint num2 = (nint)item;
		nint num3 = (nint)typeof(ItemWrench);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rdx_v10 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ r9_v3 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rdx_v10 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ r9_v3 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rax_v24+FFFFFFF8+v319 @ rax_v20*8]");
			if (0 == (nint)typeof(ItemWrench))
			{
				obj3 = 1;
				goto IL_0295;
			}
		}
		obj3 = 0;
		goto IL_0295;
		IL_0286:
		currentChargeTime = num;
		return;
		IL_0295:
		num = chargeTime;
		bool flag = obj3 == null;
		ItemWrench itemWrench = null;
		if (!flag)
		{
			itemWrench = (ItemWrench)item;
		}
		if (itemWrench != null)
		{
			float chargeSpeedIncrease = itemWrench.GetChargeSpeedIncrease();
			float num5 = chargeSpeedIncrease * num;
			num -= num5;
			if (!(0.2f > num))
			{
				if (num > chargeTime)
				{
					num = chargeTime;
				}
			}
			else
			{
				num = 0.2f;
			}
		}
		goto IL_0286;
	}

	private void OnTriggerExit()
	{
		if (!completed)
		{
			circleParent.alpha = 0f;
			charging = false;
			audioAbort.Play();
			audioLoop.Stop();
			notInterrupted = false;
		}
	}

	public override bool Interact()
	{
		return false;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BFA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "";
	}

	public override bool CanInteract()
	{
		return false;
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public ChargeShrine()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
