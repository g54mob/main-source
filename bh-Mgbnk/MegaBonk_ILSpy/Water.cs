using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class Water : MonoBehaviour
{
	public MeshRenderer waterUpper;

	public MeshRenderer waterUnder;

	private bool isCameraUnder;

	private bool isPlayerUnder;

	private bool isDamageZone;

	private MapData mapData;

	private StageData stageData;

	private Color _003Ccolor_003Ek__BackingField;

	public static Action<Water> A_CameraEnterWater;

	public static Action<Water> A_CameraExitWater;

	public static Action<Water> A_PlayerEnterWater;

	public static Action<Water> A_PlayerExitWater;

	private GameObject splashFx;

	public GameObject lavaSplashFx;

	public Material lavaMaterial;

	private float nextDamageTime;

	private float damageInterval = 1f;

	private float damage = 1f;

	private float threshold = 0.15f;

	private float nextSplashTime;

	private float splashInterval = 1f;

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

	public void Set(MapData mapData, StageData stageData)
	{
		//IL_0083: Expected O, but got F4
		this.mapData = mapData;
		this.stageData = stageData;
		if (stageData.waterMaterial != null)
		{
			((Renderer)waterUpper).SetMaterial(stageData.waterMaterial);
			((Renderer)waterUnder).SetMaterial(stageData.waterMaterial);
			_003Ccolor_003Ek__BackingField = (Color)stageData.waterMaterial.GetColor("_MidColor").r;
			isDamageZone = mapData.isWaterDamaging;
			splashFx = stageData.waterSplashFx;
		}
	}

	public void SetFloorIsLava()
	{
		//IL_0082: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BE5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		splashFx = lavaSplashFx;
		isDamageZone = true;
		((Renderer)waterUpper).SetMaterial(lavaMaterial);
		((Renderer)waterUnder).SetMaterial(lavaMaterial);
		_003Ccolor_003Ek__BackingField = (Color)lavaMaterial.GetColor("_MidColor").r;
	}

	private unsafe void FixedUpdate()
	{
		//IL_008f: Expected O, but got Ref
		if (isDamageZone && isPlayerUnder && !(nextDamageTime > MyTime.time))
		{
			float num = damage * 1.1f;
			damage = num;
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			object obj = default(object);
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 0f, (Vector3)(&obj), ignoreShield, damageSource, flags, damageEffect);
			float num2 = MyTime.time + damageInterval;
			nextDamageTime = num2;
		}
	}

	private unsafe void Update()
	{
		//IL_04e2: Expected F4, but got I4
		//IL_0513: Invalid comparison between I4 and F4
		//IL_053a: Expected O, but got I4
		//IL_053a: Expected O, but got I4
		//IL_0548: Expected F4, but got O
		//IL_0212: Invalid comparison between F4 and I4
		//IL_044b: Expected O, but got Ref
		//IL_044b: Expected O, but got Ref
		//IL_02d5: Expected O, but got Ref
		//IL_02d5: Expected O, but got Ref
		bool flag = PlayerCamera.Instance == null;
		if (flag)
		{
			return;
		}
		Action<Water> action;
		if (isCameraUnder == flag)
		{
			Transform transform = PlayerCamera.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			if (transform2.position.y > position.y)
			{
				isCameraUnder = true;
				action = A_CameraEnterWater;
				goto IL_045a;
			}
			if (!isCameraUnder)
			{
				goto IL_0477;
			}
		}
		Transform transform3 = PlayerCamera.Instance.transform;
		Vector3 position2 = transform3.position;
		Transform transform4 = base.transform;
		Vector3 position3 = transform4.position;
		if (position2.y > position3.y)
		{
			isCameraUnder = false;
			action = A_CameraExitWater;
			goto IL_045a;
		}
		goto IL_0477;
		IL_045a:
		if (action != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v565 @ rax_v116 (System.Action`1<Water>)+18] (should have been resolved before IL gen)");
		}
		goto IL_0477;
		IL_0477:
		object obj = default(object);
		object obj2 = default(object);
		if (!isPlayerUnder)
		{
			Vector3 feetPosition = MyPlayer.Instance.GetFeetPosition();
			Transform transform5 = base.transform;
			float num = transform5.position.y - threshold;
			if (num > feetPosition.y)
			{
				float num2 = nextDamageTime + 4f;
				if (MyTime.time > num2)
				{
					MyPlayer instance = MyPlayer.Instance;
					PlayerInventory inventory = instance.inventory;
					GameObject playerHealth = (GameObject)(object)inventory.playerHealth;
					num2 = PlayerHealth.maxMaxHp;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rcx_v60 (UnityEngine.GameObject)+14]");
					float num3 = 0f * 0.005f;
					float num4 = num3 - 1f;
					if (0f > num4 || num4 > (float)PlayerHealth.maxMaxHp)
					{
					}
					GameObject gameObject = UnityEngine.Object.Instantiate(playerHealth, (Vector3)0, (Quaternion)0);
					damage = (float)gameObject;
				}
				isPlayerUnder = true;
				float time = MyTime.time;
				if (MyTime.time > nextSplashTime)
				{
					MyPlayer instance2 = MyPlayer.Instance;
					PlayerMovement playerMovement = instance2.playerMovement;
					bool flag2 = !(-1f > playerMovement.fallSpeed);
					time = -1f;
					if (!flag2)
					{
						bool flag3 = splashFx != null;
						bool flag4 = !flag3;
						time = -1f;
						if (!flag4)
						{
							Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
							GameObject gameObject2 = UnityEngine.Object.Instantiate(splashFx, (Vector3)(&obj), (Quaternion)(&obj2));
							time = MyTime.time + splashInterval;
							nextSplashTime = time;
						}
					}
				}
				Action<Water> a_PlayerEnterWater = A_PlayerEnterWater;
				if (A_PlayerEnterWater != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v762 @ rax_v68 (System.Action`1<Water>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
			if (!isPlayerUnder)
			{
				return;
			}
		}
		Vector3 feetPosition3 = MyPlayer.Instance.GetFeetPosition();
		Transform transform6 = base.transform;
		float num5 = transform6.position.y - threshold;
		if (!(feetPosition3.y > num5))
		{
			return;
		}
		isPlayerUnder = false;
		Action<Water> a_PlayerExitWater = A_PlayerExitWater;
		if (A_PlayerExitWater != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v720 @ rax_v16 (System.Action`1<Water>)+18] (should have been resolved before IL gen)");
		}
		if (MyTime.time > nextSplashTime)
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerMovement playerMovement2 = instance3.playerMovement;
			if (playerMovement2.fallSpeed > 1f && splashFx != null)
			{
				Vector3 feetPosition4 = MyPlayer.Instance.GetFeetPosition();
				GameObject gameObject3 = UnityEngine.Object.Instantiate(splashFx, (Vector3)(&obj), (Quaternion)(&obj2));
				float num6 = MyTime.time + splashInterval;
				nextSplashTime = num6;
			}
		}
	}
}
