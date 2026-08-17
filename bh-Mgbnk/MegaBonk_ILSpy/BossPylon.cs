using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class BossPylon : MonoBehaviour
{
	private Vector3 startPosition;

	private float chargeTime = 5f;

	private float chargeProgress;

	private MaterialPropertyBlock zonePropertyBlock;

	public Renderer zoneRenderer;

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

	public static Action<BossPylon> A_Charged;

	private Enemy boss;

	public LineRenderer laser;

	private int arcPointCount = 10;

	private float arcHeight = 15f;

	private float moveTime;

	private Vector3 fromPos;

	private Vector3 toPos;

	public ParticleSystem moveFx;

	private float height = 14f;

	private float moveOverSeconds = 2f;

	private bool burying;

	private float currentChargeTime;

	private bool wasLoopAudioPlayingWhenPaused;

	private float pitchStart = 0.5f;

	private float pitchEnd = 1.5f;

	private bool completed;

	private bool charging;

	private float volumeWhenExit;

	public unsafe void Set(Enemy enemy)
	{
		//IL_02b2: Expected I, but got O
		//IL_02ef: Expected O, but got I
		//IL_030c: Expected O, but got I
		//IL_0356: Invalid comparison between F4 and O
		//IL_004d: Expected O, but got F4
		//IL_00a1: Expected O, but got Ref
		//IL_0166: Expected O, but got I4
		//IL_01b1: Expected O, but got Ref
		//IL_021e: Expected O, but got Ref
		//IL_0249: Expected O, but got F4
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		object obj = startPosition - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+24]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj2 = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+28]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = num4 - 0;
		object obj4 = obj2 * obj2;
		object obj5 = obj * obj;
		object obj6 = obj3 * obj3;
		object obj7 = obj4 + obj5;
		object obj8 = obj7 + obj6;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			startPosition = (Vector3)position.x;
			_ = position.z;
		}
		Transform transform2 = moveFx.transform;
		transform2.parentInternal = null;
		Transform transform3 = moveFx.transform;
		Vector3 vector = default(Vector3);
		transform3.position = (Vector3)(&vector);
		boss = enemy;
		completed = false;
		GameObject gameObject2 = laser.gameObject;
		gameObject2.SetActive(value: true);
		minimapIcon.SetActive(value: true);
		altarIcon.SetActive(value: true);
		burying = false;
		circleParent.alpha = 0f;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		zonePropertyBlock = materialPropertyBlock;
		zoneRenderer.Internal_GetPropertyBlock(zonePropertyBlock);
		zoneColor = (Color)0;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+4C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+50]");
		_ = 0;
		_ = 0;
		zonePropertyBlock.SetColor("_MainColor", (Color)(&vector));
		zoneRenderer.Internal_SetPropertyBlock(zonePropertyBlock);
		zoneRenderer.enabled = false;
		chargeProgress = 0f;
		completed = false;
		moveTime = 0f;
		Transform transform4 = base.transform;
		float num5 = default(float);
		transform4.position = (Vector3)(&num5);
		Transform transform5 = base.transform;
		Vector3 position2 = transform5.position;
		fromPos = (Vector3)position2.x;
		_ = position2.z;
		toPos = startPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+28]");
		_ = 0;
		GameObject gameObject3 = moveFx.gameObject;
		gameObject3.SetActive(value: true);
		moveFx.Play();
	}

	private void Update()
	{
		ChargeUpdate();
		MoveUpdate();
		DrawLaser();
	}

	private unsafe void DrawLaser()
	{
		//IL_0118: Expected O, but got I4
		//IL_0235: Expected O, but got I4
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected I4, but got Unknown
		//IL_015e: Expected F4, but got I4
		//IL_0126: Invalid comparison between I4 and F4
		//IL_0176: Expected O, but got Ref
		//IL_01ac: Expected O, but got Ref
		//IL_0142: Expected F4, but got I4
		if (!(boss != null))
		{
			return;
		}
		GameObject gameObject = laser.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			return;
		}
		Transform transform = laser.transform;
		Vector3 position = transform.position;
		Vector3 centerPosition = boss.GetCenterPosition();
		int num = arcPointCount;
		laser.positionCount = arcPointCount;
		if (arcPointCount > 0)
		{
			float num2 = centerPosition.x - position.x;
			float num3 = centerPosition.z - position.z;
			int num4 = 0;
			Vector3 vector = (Vector3)0;
			float num12 = default(float);
			bool flag;
			do
			{
				object obj = arcPointCount - 1;
				int num5 = num4 / obj;
				float num6 = ((0 > num5) ? 0f : (((float)num5 > 1f) ? 1f : ((float)num5)));
				float num7 = num2 * num6;
				float num8 = num3 * num6;
				float num9 = num7 + position.x;
				float num10 = num8 + position.z;
				float num11 = (float)num5 * (float)Math.PI;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
				laser.SetPosition(num4, (Vector3)(&num12));
				num4++;
				flag = num4 < arcPointCount;
				num12 = num9;
				num = num4;
				vector = (Vector3)(&num12);
			}
			while (flag);
		}
	}

	private unsafe void Surface()
	{
		//IL_0027: Expected O, but got Ref
		//IL_0052: Expected O, but got F4
		moveTime = 0f;
		Transform transform = base.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		fromPos = (Vector3)position.x;
		_ = position.z;
		toPos = startPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+28]");
		_ = 0;
		GameObject gameObject = moveFx.gameObject;
		gameObject.SetActive(value: true);
		moveFx.Play();
	}

	private void Bury()
	{
		//IL_0075: Expected I, but got O
		fromPos = startPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+28]");
		_ = 0;
		moveTime = 0f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
		float num4 = num3 * 0f;
		float num5 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+28]");
		float num6 = num5 + 0f;
		Vector3 vector = default(Vector3);
		toPos = vector;
		GameObject gameObject = moveFx.gameObject;
		gameObject.SetActive(value: true);
		moveFx.Play();
		burying = true;
	}

	private unsafe void MoveUpdate()
	{
		//IL_015f: Invalid comparison between I4 and F4
		//IL_0041: Expected F4, but got I4
		//IL_019f: Invalid comparison between I4 and F4
		//IL_007d: Expected F4, but got I4
		//IL_008f: Expected O, but got Ref
		if (!(moveTime < 1f))
		{
			return;
		}
		float num = MyTime.deltaTime / moveOverSeconds;
		float num2 = num + moveTime;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		moveTime = num2;
		Transform transform = base.transform;
		float num3 = Easing.InOutQuad(moveTime);
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = default(float);
		transform.position = (Vector3)(&num4);
		if (!(moveTime < 1f))
		{
			GameObject gameObject = moveFx.gameObject;
			gameObject.SetActive(value: false);
			if (burying)
			{
				GameObject gameObject2 = base.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
	}

	public void Despawn()
	{
		GameObject gameObject = laser.gameObject;
		gameObject.SetActive(value: false);
		Bury();
	}

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> b = OnPause;
		Delegate obj = Delegate.Combine(MyTime.A_Pause, b);
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

	private void OnDestroy()
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

	private unsafe void Start()
	{
		//IL_001d: Expected O, but got Ref
		//IL_0034: Expected O, but got Ref
		//IL_0089: Expected O, but got I4
		//IL_00ce: Expected O, but got Ref
		Transform transform = minimapIcon.transform;
		float num = default(float);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num));
		transform.rotation = (Quaternion)(&num);
		circleParent.alpha = 0f;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		zonePropertyBlock = materialPropertyBlock;
		zoneRenderer.Internal_GetPropertyBlock(zonePropertyBlock);
		_ = 1065353216;
		zoneColor = (Color)0;
		_ = 1065353216;
		_ = 1065353216;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+4C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+50]");
		_ = 0;
		zonePropertyBlock.SetColor("_MainColor", (Color)(&num));
		zoneRenderer.Internal_SetPropertyBlock(zonePropertyBlock);
		zoneRenderer.enabled = false;
	}

	private unsafe void Reset()
	{
		//IL_004f: Expected O, but got I4
		//IL_009a: Expected O, but got Ref
		circleParent.alpha = 0f;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		zonePropertyBlock = materialPropertyBlock;
		zoneRenderer.Internal_GetPropertyBlock(zonePropertyBlock);
		zoneColor = (Color)0;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+4C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossPylon)+50]");
		_ = 0;
		_ = 0;
		object obj = default(object);
		zonePropertyBlock.SetColor("_MainColor", (Color)(&obj));
		zoneRenderer.Internal_SetPropertyBlock(zonePropertyBlock);
		zoneRenderer.enabled = false;
		chargeProgress = 0f;
		completed = false;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v16+FFFFFFF8+v178 @ rax_v10*8]");
			if (0 == (nint)typeof(ItemWrench))
			{
				obj3 = 1;
				goto IL_0203;
			}
		}
		obj3 = 0;
		goto IL_0203;
		IL_0203:
		bool flag = obj3 == null;
		ItemBase itemBase = null;
		if (!flag)
		{
			itemBase = item;
		}
		if (itemBase == null)
		{
			currentChargeTime = chargeTime;
			return;
		}
		float num4 = chargeTime * 0.9f;
		int num5 = itemBase.amount;
		float num6 = chargeTime - num4;
		float num7 = num6 / 10f;
		if (itemBase.amount >= 11)
		{
			num5 = 10;
		}
		else if (itemBase.amount < 0)
		{
			num5 = 0;
		}
		float num8 = (float)num5 * num7;
		float num9 = chargeTime - num8;
		if (!(num4 > num9))
		{
			if (num9 > chargeTime)
			{
				currentChargeTime = chargeTime;
				return;
			}
		}
		else
		{
			num9 = num4;
		}
		currentChargeTime = num9;
	}

	private unsafe void ChargeUpdate()
	{
		//IL_0032: Invalid comparison between I4 and F4
		//IL_007e: Invalid comparison between I4 and F4
		//IL_011d: Invalid comparison between I4 and F4
		//IL_016c: Expected O, but got Ref
		//IL_018d: Invalid comparison between I4 and F4
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
		if (0f > chargeProgress || chargeProgress > 1f)
		{
		}
		object obj = default(object);
		zonePropertyBlock.SetColor("_MainColor", (Color)(&obj));
		zoneRenderer.Internal_SetPropertyBlock(zonePropertyBlock);
		if (!(0f < chargeProgress))
		{
			chargeProgress = 0f;
			zoneRenderer.enabled = false;
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
		minimapIcon.SetActive(value: false);
		altarIcon.SetActive(value: false);
		GameObject gameObject2 = laser.gameObject;
		gameObject2.SetActive(value: false);
		Bury();
		Action<BossPylon> a_Charged = A_Charged;
		if (A_Charged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v332 @ rax_v23 (System.Action`1<BossPylon>)+18] (should have been resolved before IL gen)");
		}
	}

	private void ScorePopup()
	{
		UiManager instance = UiManager.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("Game_ScoreUi", "POPUP_PYLON");
		bool useSfx = default(bool);
		float sizeMultiplier = default(float);
		instance.scoreUi.AddScore(localizedString, "+1", isPositive: true, useSfx, sizeMultiplier);
	}

	private void OnTriggerEnter()
	{
		//IL_0121: Expected I, but got O
		//IL_012f: Expected I, but got O
		//IL_013f: Expected O, but got I
		//IL_01bf: Expected O, but got I4
		//IL_017b: Expected O, but got I
		//IL_01b1: Expected O, but got I4
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v7 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v7 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v23+FFFFFFF8+v304 @ rax_v17*8]");
			if (0 == (nint)typeof(ItemWrench))
			{
				obj3 = 1;
				goto IL_02c6;
			}
		}
		obj3 = 0;
		goto IL_02c6;
		IL_02c6:
		bool flag = obj3 == null;
		ItemBase itemBase = null;
		if (!flag)
		{
			itemBase = item;
		}
		if (itemBase == null)
		{
			currentChargeTime = chargeTime;
			return;
		}
		float num4 = chargeTime * 0.9f;
		int num5 = itemBase.amount;
		float num6 = chargeTime - num4;
		float num7 = num6 / 10f;
		if (itemBase.amount >= 11)
		{
			num5 = 10;
		}
		else if (itemBase.amount < 0)
		{
			num5 = 0;
		}
		float num8 = (float)num5 * num7;
		float num9 = chargeTime - num8;
		if (!(num4 > num9))
		{
			if (num9 > chargeTime)
			{
				currentChargeTime = chargeTime;
				return;
			}
		}
		else
		{
			num9 = num4;
		}
		currentChargeTime = num9;
	}

	private void OnTriggerExit()
	{
		if (!completed)
		{
			circleParent.alpha = 0f;
			charging = false;
			audioAbort.Play();
			audioLoop.Stop();
		}
	}
}
