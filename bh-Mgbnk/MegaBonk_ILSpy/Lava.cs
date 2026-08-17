using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class Lava : MonoBehaviour
{
	private bool isCameraUnder;

	private bool isPlayerUnder;

	private bool isDamageZone;

	private MapData mapData;

	private StageData stageData;

	private Color _003Ccolor_003Ek__BackingField;

	public static Action A_CameraEnterWater;

	public static Action A_CameraExitWater;

	public static Action A_PlayerEnterWater;

	public static Action A_PlayerExitWater;

	public GameObject splashFx;

	private float nextDamageTime;

	private float damageInterval;

	private float damage;

	private string damageSource;

	private Collider collider;

	private Bounds bounds;

	private Vector3 lastPos;

	private float threshold;

	private float nextSplashTime;

	private float splashInterval;

	public unsafe Color color
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)_003Ccolor_003Ek__BackingField;
			return color;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003Ccolor_003Ek__BackingField = (Color)value.r;
		}
	}

	private void Start()
	{
		//IL_0021: Expected O, but got F4
		Collider component = GetComponent<Collider>();
		collider = component;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		lastPos = (Vector3)position.x;
		_ = position.z;
		Invoke("UpdateBounds", 0.25f);
	}

	private void UpdateBounds()
	{
		//IL_0056: Expected O, but got F4
		bounds = (Bounds)collider.bounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v3 (UnityEngine.Bounds)+10]");
		_ = 0;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		lastPos = (Vector3)position.x;
		_ = position.z;
	}

	private void CheckBounds()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_00d4: Invalid comparison between F4 and I4
		//IL_00fd: Expected O, but got I4
		//IL_0173: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Lava)+90]");
		float num2 = num - 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Lava)+8C]");
		object obj2 = default(object);
		object obj = obj2 - 0;
		float num3 = position.x - (float)lastPos;
		object obj3 = obj * obj;
		float num4 = num2 * num2;
		float num5 = num3 * num3;
		float num6 = (float)obj3 + num5;
		float num7 = num6 + num4;
		bool flag = 9.9999994E-11f < num7;
		float num8 = 9.9999994E-11f - num7;
		bool flag2 = num8 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj4 = flag4 & flag3;
		if (obj4 == null)
		{
			bounds = (Bounds)collider.bounds.m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v9 (UnityEngine.Bounds)+10]");
			_ = 0;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			lastPos = (Vector3)position2.x;
			_ = position2.z;
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_00ca: Invalid comparison between F4 and I4
		//IL_00f3: Expected O, but got I4
		//IL_0169: Expected O, but got F4
		//IL_01e3: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Lava)+90]");
		float num2 = num - 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Lava)+8C]");
		object obj2 = default(object);
		object obj = obj2 - 0;
		float num3 = position.x - (float)lastPos;
		object obj3 = obj * obj;
		float num4 = num2 * num2;
		float num5 = num3 * num3;
		float num6 = (float)obj3 + num5;
		float num7 = num6 + num4;
		bool flag = 9.9999994E-11f < num7;
		float num8 = 9.9999994E-11f - num7;
		bool flag2 = num8 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj4 = flag4 & flag3;
		if (obj4 == null)
		{
			bounds = (Bounds)collider.bounds.m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v35 (UnityEngine.Bounds)+10]");
			_ = 0;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			lastPos = (Vector3)position2.x;
			_ = position2.z;
		}
		if (isPlayerUnder && !(nextDamageTime > MyTime.time))
		{
			float num9 = damage * 1.15f;
			damage = num9;
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			float num10 = default(float);
			bool ignoreShield = default(bool);
			string text = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 0f, (Vector3)(&num10), ignoreShield, text, flags, damageEffect);
			float num11 = MyTime.time + damageInterval;
			nextDamageTime = num11;
		}
	}

	private unsafe void Update()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_005a: Expected O, but got Ref
		//IL_039e: Expected I, but got O
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_0420: Expected O, but got Ref
		//IL_0572: Expected O, but got I4
		//IL_02c9: Expected O, but got I4
		//IL_04e8: Expected F4, but got I4
		//IL_0509: Invalid comparison between I4 and F4
		//IL_0530: Expected O, but got I4
		//IL_0530: Expected O, but got I4
		//IL_053e: Expected F4, but got O
		//IL_0547: Expected F4, but got I4
		//IL_026d: Invalid comparison between F4 and I4
		//IL_0309: Expected O, but got I4
		//IL_0342: Expected O, but got Ref
		//IL_0342: Expected O, but got Ref
		//IL_05de: Expected O, but got Ref
		//IL_0228: Expected O, but got Ref
		//IL_0228: Expected O, but got Ref
		if (!(PlayerCamera.Instance != null))
		{
			return;
		}
		Transform transform = PlayerCamera.Instance.transform;
		Vector3 position = transform.position;
		Bounds bounds = (Bounds)(this + 112);
		float num = default(float);
		bool flag = ((Bounds*)bounds)->Contains((Vector3)(&num));
		bool flag2 = isCameraUnder;
		bool flag3 = false;
		if (!flag2)
		{
			flag3 = flag;
		}
		Action action;
		if (!flag3)
		{
			if (isCameraUnder == flag3 || flag)
			{
				goto IL_0107;
			}
			isCameraUnder = flag;
			action = A_CameraExitWater;
		}
		else
		{
			isCameraUnder = true;
			action = A_CameraEnterWater;
		}
		if (action != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v450.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		goto IL_0107;
		IL_0107:
		Vector3 feetPosition = MyPlayer.Instance.GetFeetPosition();
		nint num2 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num4 = 0f * 0.5f;
		float num5 = num4 + feetPosition.z;
		Bounds bounds2 = (Bounds)(this + 112);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num6 = 0f * 0.5f;
		float num7 = num6 + feetPosition.y;
		bool flag4 = ((Bounds*)bounds2)->Contains((Vector3)(&num));
		bool flag5 = isPlayerUnder;
		bool flag6 = false;
		if (!flag5)
		{
			flag6 = flag4;
		}
		object obj = default(object);
		if (!flag6)
		{
			if (isPlayerUnder == flag6 || flag4)
			{
				return;
			}
			isPlayerUnder = flag4;
			Action a_PlayerExitWater = A_PlayerExitWater;
			if (A_PlayerExitWater != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v708.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			if (MyTime.time > nextSplashTime)
			{
				MyPlayer instance = MyPlayer.Instance;
				PlayerMovement playerMovement = instance.playerMovement;
				if (playerMovement.fallSpeed > 1f && splashFx != null)
				{
					Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
					GameObject gameObject = UnityEngine.Object.Instantiate(splashFx, (Vector3)(&num), (Quaternion)(&obj));
					float num8 = MyTime.time + splashInterval;
					nextSplashTime = num8;
				}
			}
			return;
		}
		float num9 = nextDamageTime + 4f;
		bool flag7 = !(MyTime.time > num9);
		float num10 = 0.5f;
		if (!flag7)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			GameObject playerHealth = (GameObject)(object)inventory.playerHealth;
			num9 = PlayerHealth.maxMaxHp;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ rcx_v46 (UnityEngine.GameObject)+14]");
			float num11 = 0f * 0.05f;
			if (0f > num11 || num11 > (float)PlayerHealth.maxMaxHp)
			{
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate(playerHealth, (Vector3)0, (Quaternion)0);
			damage = (float)gameObject2;
			num10 = 0f;
		}
		isPlayerUnder = true;
		float time = MyTime.time;
		bool flag8 = !(MyTime.time > nextSplashTime);
		Quaternion quaternion = (Quaternion)0;
		if (!flag8)
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerMovement playerMovement2 = instance3.playerMovement;
			bool flag9 = !(-1f > playerMovement2.fallSpeed);
			time = -1f;
			quaternion = (Quaternion)0;
			if (!flag9)
			{
				bool flag10 = splashFx != null;
				bool flag11 = !flag10;
				time = -1f;
				quaternion = (Quaternion)0;
				if (!flag11)
				{
					Vector3 feetPosition3 = MyPlayer.Instance.GetFeetPosition();
					GameObject gameObject3 = UnityEngine.Object.Instantiate(splashFx, (Vector3)(&num), (Quaternion)(&obj));
					time = MyTime.time + splashInterval;
					nextSplashTime = time;
					quaternion = (Quaternion)(&obj);
				}
			}
		}
		Action a_PlayerEnterWater = A_PlayerEnterWater;
		if (A_PlayerEnterWater != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v625.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public Lava()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BE3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		nextDamageTime = -99f;
		damageInterval = 1f;
		damage = 1f;
		damageSource = "Lava";
		threshold = 0.15f;
		splashInterval = 1f;
		base._002Ector();
	}
}
