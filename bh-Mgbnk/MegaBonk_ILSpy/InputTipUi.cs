using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Assets.Scripts.Utility.Controllers;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class InputTipUi : MonoBehaviour
{
	private sealed class _003CShowTip_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InputTipUi _003C_003E4__this;

		public InputTip inputTip;

		private float _003Ct_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShowTip_003Ed__17(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0012: Expected O, but got I8
			//IL_002c: Expected O, but got I8
			while (true)
			{
				int num = _003C_003E1__state;
				if (_003C_003E1__state > 5)
				{
					break;
				}
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v1+545F34+v29 @ rax_v2 (System.Int32)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v64 @ rcx_v3 (should have been resolved before IL gen)");
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public MyGlyphDisplay glyphContainer;

	public TextMeshProUGUI t_tip;

	public CanvasGroup group;

	public AudioSource audio;

	private Vector3 defaultPosition;

	private string currentAction;

	private float timeout = 5f;

	private float fadeTime = 0.6f;

	private float delay = 0.5f;

	private bool isShowingTip;

	private bool skipping;

	private Queue<InputTip> tipQueue;

	private void Awake()
	{
		//IL_0305: Expected I, but got O
		//IL_0021: Expected O, but got F4
		//IL_00b0: Expected O, but got I4
		//IL_00be: Expected I, but got O
		//IL_0104: Expected O, but got I4
		//IL_0112: Expected I, but got O
		//IL_0270: Expected O, but got I4
		//IL_0279: Expected I, but got O
		//IL_028f: Expected I, but got O
		//IL_02b5: Expected O, but got I4
		Transform transform = base.transform;
		Action action2 = default(Action);
		Delegate obj2;
		nint num;
		if ((object)transform != null)
		{
			Vector3 localPosition = transform.localPosition;
			defaultPosition = (Vector3)localPosition.x;
			_ = localPosition.z;
			Action<WeaponBase> b = OnWeaponAdded;
			Delegate obj = Delegate.Combine(WeaponInventory.A_WeaponAdded, b);
			object obj3;
			Delegate obj4;
			if ((object)obj == null)
			{
				WeaponInventory.A_WeaponAdded = (Action<WeaponBase>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<WeaponBase> action = default(Action<WeaponBase>);
				bool flag = action == null;
				obj2 = obj;
				obj3 = 0;
				num = (nint)typeof(Action<WeaponBase>);
				obj4 = null;
				if (flag)
				{
					goto IL_0235;
				}
				WeaponInventory.A_WeaponAdded = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				obj2 = obj;
				obj3 = 0;
				num = (nint)typeof(Action<WeaponBase>);
				obj4 = null;
				if (flag2)
				{
					goto IL_0240;
				}
			}
			action2 = OnRunStarted;
			Delegate obj6 = Delegate.Combine(GameManager.A_RunStarted, action2);
			if ((object)obj6 == null)
			{
				GameManager.A_RunStarted = null;
				return;
			}
			bool flag3 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag3)
			{
				obj7 = obj6;
			}
			bool flag4 = (object)obj7 == null;
			obj2 = action2;
			obj3 = 0;
			num = (nint)GameManager.A_RunStarted;
			obj4 = obj6;
			nint num2 = (nint)typeof(Action);
			if (flag4)
			{
				goto IL_02d9;
			}
			GameManager.A_RunStarted = (Action)obj7;
			bool flag5 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag5)
			{
				obj8 = obj6;
			}
			bool flag6 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			NullReferenceException typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (!flag6)
			{
				return;
			}
		}
		else
		{
			NullReferenceException typeFromHandle = new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj2 = action2;
		num = (nint)GameManager.A_RunStarted;
		goto IL_02d9;
		IL_0235:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02d9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0240;
		IL_0240:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0235;
	}

	private void OnDestroy()
	{
		//IL_01a1: Expected I, but got O
		//IL_01b2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0207: Expected I, but got O
		//IL_0218: Expected O, but got I4
		//IL_022e: Expected I, but got O
		//IL_0254: Expected I, but got O
		//IL_0265: Expected O, but got I4
		//IL_027b: Expected I, but got O
		Action<WeaponBase> value = OnWeaponAdded;
		Delegate obj = Delegate.Remove(WeaponInventory.A_WeaponAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponAdded = (Action<WeaponBase>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action = default(Action<WeaponBase>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<WeaponBase>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0299;
			}
			WeaponInventory.A_WeaponAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_01e4;
			}
		}
		Action action2 = OnRunStarted;
		Delegate obj6 = Delegate.Remove(GameManager.A_RunStarted, action2);
		if ((object)obj6 == null)
		{
			GameManager.A_RunStarted = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		num2 = (nint)GameManager.A_RunStarted;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_0289;
		}
		GameManager.A_RunStarted = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		num = (nint)GameManager.A_RunStarted;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_0299;
		IL_0289:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01e4;
		IL_01e4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0299:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0289;
	}

	public void SetTip(string tip, string action, float extraDelay = 0f)
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		if (cfGameSettings.show_tips != 0)
		{
			InputTip item = new InputTip(tip, action, extraDelay);
			((Queue<object>)(object)tipQueue).Enqueue((object)item);
		}
	}

	private unsafe void Update()
	{
		//IL_0227: Invalid comparison between I4 and F4
		//IL_019a: Expected F4, but got I4
		//IL_01ac: Expected O, but got Ref
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_0116: Invalid comparison between O and F4
		if (MyTime.paused)
		{
			return;
		}
		if (!isShowingTip)
		{
			Queue<object> queue = (Queue<object>)(object)tipQueue;
			if (queue._size > 0)
			{
				object inputTip = queue.Dequeue();
				_003CShowTip_003Ed__17 obj = new _003CShowTip_003Ed__17(0);
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				obj.inputTip = (InputTip)inputTip;
				Coroutine coroutine = StartCoroutine(obj);
			}
		}
		if (!skipping && isShowingTip)
		{
			if (MyInputManager.GetButtonDown(currentAction))
			{
				SkipTip();
			}
			float axis = MyInputManager.GetAxis(currentAction);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj2 = axis & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f))
			{
				SkipTip();
			}
		}
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 3f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
	}

	private unsafe void SkipTip()
	{
		//IL_0027: Expected O, but got Ref
		skipping = true;
		Transform transform = base.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
	}

	private IEnumerator ShowTip(InputTip inputTip)
	{
		_003CShowTip_003Ed__17 obj = new _003CShowTip_003Ed__17(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.inputTip = inputTip;
		return obj;
	}

	private void OnWeaponAdded(WeaponBase weaponBase)
	{
		WeaponData weaponData = weaponBase.weaponData;
		if (weaponData.hasCrosshair && weaponBase.level == 1)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			string tip = ConfigSettingsUtility.SettingNameToReadable("aim", config.cfControlSettings);
			SetTip(tip, "Aim", 1f);
		}
	}

	private unsafe void OnRunStarted()
	{
		//IL_0033: Expected O, but got Ref
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		StatsSaveFile stats = saveManager.stats;
		object obj = default(object);
		string key = ((Enum)(&obj)).ToString();
		MyStat myStat = stats.stats.get_Item(key);
		if (3f > myStat.value)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager2.config;
			string tip = ConfigSettingsUtility.SettingNameToReadable("jump", config.cfControlSettings);
			SetTip(tip, "Jump", 10f);
			SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config2 = saveManager3.config;
			string tip2 = ConfigSettingsUtility.SettingNameToReadable("slide", config2.cfControlSettings);
			SetTip(tip2, "Slide", 15f);
		}
	}

	public InputTipUi()
	{
		Queue<InputTip> queue = new Queue<InputTip>();
		tipQueue = queue;
		base._002Ector();
	}
}
