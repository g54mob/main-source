using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Movement;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairUi : MonoBehaviour
{
	public Image crosshairOuter;

	public RawImage crosshairInner;

	public RectTransform parentCrosshair;

	public CanvasGroup group;

	public Color hoveringEnemyColor;

	public Color hoveringMarkedEnemyColor;

	public float movingSize = 50f;

	public float airborneSize = 65f;

	private float globalSizeMultiplier = 1f;

	private float defaultSize = 40f;

	private float desiredSize;

	private bool hoveringEnemy;

	private bool isVisible;

	private static float yMin = 0.05f;

	private static float yMax = 0.5f;

	private void Awake()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		Action<string, object, object> b = OnSettingUpdated;
		Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action = default(Action<string, object, object>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, object, object>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0337;
			}
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02f4;
			}
		}
		Action<WeaponBase> b2 = OnWeaponAdded;
		Delegate obj6 = Delegate.Combine(WeaponInventory.A_WeaponAdded, b2);
		if ((object)obj6 == null)
		{
			WeaponInventory.A_WeaponAdded = (Action<WeaponBase>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action2 = default(Action<WeaponBase>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02ff;
			}
			WeaponInventory.A_WeaponAdded = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<WeaponBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_030f;
			}
		}
		Action<WeaponBase> b3 = OnWeaponRemoved;
		Delegate obj8 = Delegate.Combine(WeaponInventory.A_WeaponRemoved, b3);
		if ((object)obj8 == null)
		{
			WeaponInventory.A_WeaponRemoved = (Action<WeaponBase>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<WeaponBase> action3 = default(Action<WeaponBase>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<WeaponBase>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_0327;
		}
		WeaponInventory.A_WeaponRemoved = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<WeaponBase>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_0337;
		IL_0337:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0327;
		IL_02f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02f4;
		IL_030f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02ff;
		IL_0327:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_030f;
	}

	private void OnDestroy()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		Action<string, object, object> value = OnSettingUpdated;
		Delegate obj = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action = default(Action<string, object, object>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, object, object>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0337;
			}
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02f4;
			}
		}
		Action<WeaponBase> value2 = OnWeaponAdded;
		Delegate obj6 = Delegate.Remove(WeaponInventory.A_WeaponAdded, value2);
		if ((object)obj6 == null)
		{
			WeaponInventory.A_WeaponAdded = (Action<WeaponBase>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action2 = default(Action<WeaponBase>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02ff;
			}
			WeaponInventory.A_WeaponAdded = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<WeaponBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_030f;
			}
		}
		Action<WeaponBase> value3 = OnWeaponRemoved;
		Delegate obj8 = Delegate.Remove(WeaponInventory.A_WeaponRemoved, value3);
		if ((object)obj8 == null)
		{
			WeaponInventory.A_WeaponRemoved = (Action<WeaponBase>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<WeaponBase> action3 = default(Action<WeaponBase>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<WeaponBase>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_0327;
		}
		WeaponInventory.A_WeaponRemoved = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<WeaponBase>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_0337;
		IL_0337:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0327;
		IL_02f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02f4;
		IL_030f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02ff;
		IL_0327:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_030f;
	}

	private void Start()
	{
		desiredSize = defaultSize;
		if (SaveManager._003CInstance_003Ek__BackingField != null)
		{
			RefreshAlpha();
			RefreshSize();
		}
		CheckVisible();
	}

	private void CheckVisible()
	{
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance == null)
		{
			return;
		}
		PlayerInventory inventory = instance.inventory;
		if (instance.inventory == null)
		{
			return;
		}
		WeaponInventory weaponInventory = inventory.weaponInventory;
		if (inventory.weaponInventory != null && weaponInventory.weapons != null)
		{
			isVisible = false;
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			WeaponInventory weaponInventory2 = inventory2.weaponInventory;
			if (weaponInventory2.hasAimableWeapon)
			{
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerInput playerInput = instance3.playerInput;
				isVisible = playerInput.aiming;
			}
			if (isVisible != isVisible)
			{
				GameObject gameObject = crosshairInner.gameObject;
				gameObject.SetActive(isVisible);
				GameObject gameObject2 = crosshairOuter.gameObject;
				gameObject2.SetActive(isVisible);
			}
		}
	}

	private unsafe void Update()
	{
		//IL_004b: Expected O, but got Ref
		//IL_0128: Invalid comparison between I4 and F4
		CheckVisible();
		if (!MyTime.paused && isVisible)
		{
			Vector3 crosshairRaycastPosition = GetCrosshairRaycastPosition();
			object obj = default(object);
			parentCrosshair.position = (Vector3)(&obj);
			MyPlayer instance = MyPlayer.Instance;
			EMovementState movementState = instance.playerMovement.GetMovementState();
			float num;
			if (movementState == EMovementState.Airborne)
			{
				num = airborneSize;
			}
			else
			{
				MyPlayer instance2 = MyPlayer.Instance;
				float speed = instance2.playerMovement.GetSpeed();
				num = ((speed > 5f) ? movingSize : defaultSize);
			}
			desiredSize = num;
			RectTransform rectTransform = crosshairOuter.rectTransform;
			Vector2 sizeDelta = rectTransform.sizeDelta;
			float deltaTime = Time.deltaTime;
			float num2 = deltaTime * 6f;
			if (0f > num2 || num2 > 1f)
			{
			}
			RectTransform rectTransform2 = crosshairOuter.rectTransform;
			Vector2 sizeDelta2 = default(Vector2);
			rectTransform2.sizeDelta = sizeDelta2;
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0053: Expected O, but got Ref
		//IL_00bb: Expected O, but got Ref
		//IL_0191: Expected O, but got Ref
		//IL_01ba: Expected O, but got Ref
		//IL_0126: Expected O, but got Ref
		//IL_02f4: Expected O, but got Ref
		//IL_02d4: Expected O, but got Ref
		//IL_0210: Expected O, but got I
		//IL_0243: Expected O, but got I
		//IL_026e: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Camera main = Camera.main;
		if (!(main != null))
		{
			return;
		}
		Camera main2 = Camera.main;
		Vector3 crosshairRaycastPosition = GetCrosshairRaycastPosition();
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = crosshairRaycastPosition.x;
		_ = crosshairRaycastPosition.z;
		Ray ray = main2.ScreenPointToRay(pos);
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		ref RaycastHit hitInfo = ref System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = ray.m_Origin;
		Ray ray2 = (Ray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v13 (UnityEngine.Ray)+10]");
		_ = 0;
		int layerMask = default(int);
		bool flag = Physics.Raycast(ray2, out hitInfo, 999f, layerMask);
		RawImage rawImage;
		if (!flag)
		{
			if (~(hoveringEnemy ? 1u : 0u) != 0)
			{
				return;
			}
			hoveringEnemy = flag;
			Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED70]");
			_ = 0;
			crosshairOuter.color = color;
			rawImage = crosshairInner;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED70]");
			_ = 0;
		}
		else
		{
			if (hoveringEnemy)
			{
				return;
			}
			hoveringEnemy = true;
			Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = hoveringEnemyColor;
			crosshairOuter.color = color2;
			Color color3 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = hoveringEnemyColor;
			crosshairInner.color = color3;
			RaycastHit raycastHit = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			Collider collider = ((RaycastHit*)raycastHit)->collider;
			bool enemy = EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119)));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			if (!((UnityEngine.Object)0 != null))
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			if (!PassiveAbilityBullseye.IsMarkedEnemy((Enemy)0))
			{
				return;
			}
			Color color4 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = hoveringMarkedEnemyColor;
			crosshairOuter.color = color4;
			rawImage = crosshairInner;
			_ = hoveringMarkedEnemyColor;
		}
		Color color5 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		rawImage.color = color5;
	}

	private void FindDesiredSize()
	{
		MyPlayer instance = MyPlayer.Instance;
		EMovementState movementState = instance.playerMovement.GetMovementState();
		if (movementState != EMovementState.Airborne)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			float speed = instance2.playerMovement.GetSpeed();
			if (!(speed > 5f))
			{
				desiredSize = defaultSize;
			}
			else
			{
				desiredSize = movingSize;
			}
		}
		else
		{
			desiredSize = airborneSize;
		}
	}

	public unsafe static Vector3 GetCrosshairRaycastPosition()
	{
		//IL_00aa: Invalid comparison between I4 and F4
		//IL_00f5: Expected F4, but got I4
		//IL_0153: Expected native int or pointer, but got O
		//IL_018f: Expected native int or pointer, but got O
		//IL_01ba: Expected native int or pointer, but got O
		int height = Screen.height;
		float num = (float)height * 0.5f;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFGameSettings cfGameSettings = config.cfGameSettings;
				if (config.cfGameSettings != null)
				{
					float num2 = cfGameSettings.crosshair_height;
					if (!(0f > cfGameSettings.crosshair_height))
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
					int width = Screen.width;
					float num3 = yMax - yMin;
					Vector3 vector = default(Vector3);
					((Vector3*)(nint)vector)->z = 0f;
					float num4 = num3 * num2;
					float x = (float)width * 0.5f;
					float num5 = num4 + yMin;
					((Vector3*)(nint)vector)->x = x;
					float num6 = num5 * num;
					float y = num6 + num;
					((Vector3*)(nint)vector)->y = y;
					return vector;
				}
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 GetCrosshairUiPosition()
	{
		//IL_001b: Expected native int or pointer, but got O
		//IL_002d: Expected native int or pointer, but got O
		Vector3 crosshairRaycastPosition = GetCrosshairRaycastPosition();
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = crosshairRaycastPosition.x;
		((Vector3*)(nint)vector)->z = crosshairRaycastPosition.z;
		return vector;
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F88]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = settingName != "crosshair_size";
		CrosshairUi crosshairUi = this;
		if (flag)
		{
			if (!(settingName == "crosshair_alpha"))
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 60 Invalid \"Jump target not found in method: 0x1805309C0\"");
			CrosshairUi crosshairUi2 = default(CrosshairUi);
			crosshairUi = crosshairUi2;
		}
		crosshairUi.RefreshSize();
	}

	private void OnWeaponAdded(WeaponBase weapon)
	{
		if (weapon != null)
		{
			CheckVisible();
		}
	}

	private void OnWeaponRemoved(WeaponBase weapon)
	{
		if (weapon != null)
		{
			CheckVisible();
		}
	}

	private unsafe void RefreshSize()
	{
		//IL_0043: Expected O, but got Ref
		Transform transform = parentCrosshair.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
	}

	private void RefreshAlpha()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		group.alpha = cfGameSettings.crosshair_alpha;
	}
}
