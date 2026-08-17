using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors;

public class LanguageController : MonoBehaviour
{
	private sealed class _003CFixLayout_003Ed__10(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LanguageController _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_01df: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0177: Expected I4, but got I8
			//IL_0239: Expected I4, but got O
			//IL_0052: Expected I4, but got I8
			//IL_0081: Expected O, but got I
			//IL_00de: Expected O, but got I
			//IL_0139: Expected O, but got I
			Component component = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_0225;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (UnityEngine.Component)+30]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (UnityEngine.Component)+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v26+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v26+10]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v26+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v21+20]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v21+20]");
										Selectable component2 = ((GameObject)0).GetComponent<Selectable>();
										if ((object)component2 != null)
										{
											component2.Select();
											goto IL_0225;
										}
									}
								}
							}
							else
							{
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							}
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						RectTransform component3 = _003C_003E4__this.GetComponent<RectTransform>();
						LayoutRebuilder.ForceRebuildLayoutImmediate(component3);
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_0225:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private GameObject LanguageButtonPrefab;

	private RectTransform Container;

	private List<GameObject> spawned;

	private SignalBus signalBus;

	private PlayerOptions _playerOptions;

	private void Construct(SignalBus _signal, PlayerOptions playerOptions)
	{
		signalBus = _signal;
		_playerOptions = playerOptions;
	}

	private unsafe void Start()
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Ref, but got Unknown
		//IL_00f3: Expected I8, but got I4
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Ref, but got Unknown
		PlayerOptionsData config = _playerOptions.Config;
		string text = config._003CLanguage_003Ek__BackingField;
		LocalizationManager.InitializeIfNeeded();
		string mCurrentLanguage = LocalizationManager.mCurrentLanguage;
		if ((object)config._003CLanguage_003Ek__BackingField == LocalizationManager.mCurrentLanguage)
		{
			return;
		}
		if (config._003CLanguage_003Ek__BackingField != null && LocalizationManager.mCurrentLanguage != null && text._stringLength == mCurrentLanguage._stringLength)
		{
			ref byte first = ref *(byte*)(config._003CLanguage_003Ek__BackingField + 20);
			ulong length = (ulong)(text._stringLength + text._stringLength);
			if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(LocalizationManager.mCurrentLanguage + 20), length))
			{
				return;
			}
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		LocalizationManager.CurrentLanguage = config2._003CLanguage_003Ek__BackingField;
	}

	public void Set()
	{
		SetLanguage component = GetComponent<SetLanguage>();
		component.ApplyLanguage();
	}

	public static string GetCurrentLanguageName()
	{
		//IL_0052: Expected I, but got O
		//IL_0062: Expected O, but got I
		//IL_0072: Expected O, but got I
		LocalizationManager.InitializeIfNeeded();
		CultureInfo cultureInfo = new CultureInfo(LocalizationManager.mCurrentLanguage, true, false);
		if (cultureInfo != null)
		{
			nint num = (nint)cultureInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v2 (Il2CppClass<System.Globalization.CultureInfo>)+268]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v2 (Il2CppClass<System.Globalization.CultureInfo>)+270]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v103 @ r8_v2 (should have been resolved before IL gen)");
		}
		return (string)(object)new NullReferenceException();
	}

	private void OnEnable()
	{
		List<string> allLanguages = LocalizationManager.GetAllLanguages();
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			string text = null;
			CultureInfo cultureInfo = new CultureInfo((string)null, true, false);
			bool flag = cultureInfo == null;
			CultureInfo cultureInfo2 = cultureInfo;
			if (!flag)
			{
				string nativeName = cultureInfo.NativeName;
				object obj = "zh-CN";
				string text2;
				if (0 != unchecked((nint)"zh-CN"))
				{
					object obj2 = "zh-TW";
					text2 = ((0 == unchecked((nint)"zh-TW")) ? "中文（繁體中文）" : nativeName);
				}
				else
				{
					text2 = "简体中文";
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(LanguageButtonPrefab, Container);
				bool flag2 = (object)gameObject == null;
				cultureInfo2 = (CultureInfo)(object)LanguageButtonPrefab;
				if (!flag2)
				{
					LanguageButtonUI component = gameObject.GetComponent<LanguageButtonUI>();
					bool flag3 = (object)component == null;
					cultureInfo2 = (CultureInfo)(object)gameObject;
					if (!flag3)
					{
						component.SetLanguage(this, text2, null);
						cultureInfo2 = (CultureInfo)(object)spawned;
						if (spawned != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		_003CFixLayout_003Ed__10 obj3 = null;
		obj3._003C_003E1__state = 0;
		obj3._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj3);
	}

	private IEnumerator FixLayout()
	{
		_003CFixLayout_003Ed__10 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnDisable()
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		bool flag = spawned == null;
		LanguageController languageController = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			languageController = (LanguageController)(object)spawned;
			if (spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v2 (VampireSurvivors.LanguageController)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)languageController).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)languageController).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)languageController).m_CachedPtr, 0, (int)((MonoBehaviour)languageController).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void ApplyLanguage(string code)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_00af: Expected I, but got O
		//IL_00cb: Expected O, but got I
		LocalizationManager.CurrentLanguageCode = code;
		string message = "Current languiage : " + code;
		Debug.Log(message);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		_playerOptions.Save(commitImmediately: false);
	}

	public GameObject GetFirstObject()
	{
		List<GameObject> list = spawned;
		if (list._size > 0)
		{
			GameObject[] items = list._items;
			return items[0];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	public LanguageController()
	{
		List<GameObject> list = new List<GameObject>();
		spawned = list;
	}
}
