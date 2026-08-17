using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class LocalizationPreloader : MonoBehaviour
{
	private sealed class _003CLoadStringTablesCoroutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LocalizationPreloader _003C_003E4__this;

		private List<string>.Enumerator _003C_003E7__wrap1;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CLoadStringTablesCoroutine_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		unsafe void IDisposable.Dispose()
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			if (_003C_003E1__state == -3 || _003C_003E1__state == 2)
			{
				_ = 4294967295L;
				object obj = default(object);
				List<string>.Enumerator enumerator = (List<string>.Enumerator)(obj + 40);
				((List<string>.Enumerator*)enumerator)->Dispose();
			}
		}

		private unsafe bool MoveNext()
		{
			//IL_023f: Expected O, but got I
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Expected O, but got Unknown
			//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Expected O, but got Unknown
			//IL_011c: Expected O, but got I
			//IL_0137: Expected O, but got Ref
			//IL_0137: Expected O, but got Ref
			//IL_01b2: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+20]");
			LocalizedStringDatabase localizedStringDatabase = (LocalizedStringDatabase)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+10]");
			bool flag = (nint)0 == 0;
			object obj4 = default(object);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+10]");
				nint num = -1;
				if (!flag)
				{
					if (num != 1)
					{
						return false;
					}
					_ = 4294967293L;
				}
				else
				{
					_ = 4294967295L;
					float time = Time.time;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+20]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rbx_v4 (UnityEngine.Localization.Settings.LocalizedStringDatabase)+28]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rbx_v4 (UnityEngine.Localization.Settings.LocalizedStringDatabase)+28]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					_ = 4294967293L;
				}
				object obj = default(object);
				List<object>.Enumerator enumerator = (List<object>.Enumerator)(obj + 40);
				if (((List<object>.Enumerator*)enumerator)->MoveNext())
				{
					LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+38]");
					TableReference tableReference = (string)0;
					object obj2 = default(object);
					string text = default(string);
					AsyncOperationHandle<StringTable> tableAsync = ((LocalizedDatabase<StringTable, StringTableEntry>)(&obj2)).GetTableAsync((TableReference)stringDatabase, (Locale)(&text));
					object obj3 = (AsyncOperationHandle<StringTable>)obj4;
					_ = 2;
					return true;
				}
				_ = 4294967295L;
				List<string>.Enumerator enumerator2 = (List<string>.Enumerator)(obj + 40);
				((List<string>.Enumerator*)enumerator2)->Dispose();
				_ = 0;
				_ = 0;
				float time2 = Time.time;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+20]");
				bool flag2 = (nint)0 == 0;
				num = 0;
				if (!flag2)
				{
					float num2 = default(float);
					string text2 = num2.ToString();
					string text3 = "✅ All localization tables preloaded. Elapsed time: " + text2 + " seconds.";
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+20]");
					((LocalizationPreloader)0).LoadMain();
					return false;
				}
				throw new NullReferenceException();
			}
			_ = 4294967295L;
			AsyncOperationHandle<LocalizationSettings> initializationOperation = LocalizationSettings.InitializationOperation;
			object obj5 = (AsyncOperationHandle<LocalizationSettings>)obj4;
			_ = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private unsafe void _003C_003Em__Finally1()
		{
			//IL_0014: Expected I4, but got I8
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			_003C_003E1__state = -1;
			List<string>.Enumerator enumerator = (List<string>.Enumerator)(this + 40);
			((List<string>.Enumerator*)enumerator)->Dispose();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private float startedLoadingTablesTime;

	public List<string> tableNamesToPreload;

	private float timeoutAtTime;

	private bool startedLoading;

	private void Start()
	{
		float time = Time.time;
		float num = time + 15f;
		timeoutAtTime = num;
		_003CLoadStringTablesCoroutine_003Ed__4 obj = new _003CLoadStringTablesCoroutine_003Ed__4(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator LoadStringTablesCoroutine()
	{
		_003CLoadStringTablesCoroutine_003Ed__4 obj = new _003CLoadStringTablesCoroutine_003Ed__4(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void Update()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172DF6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float time = Time.time;
		if (time > timeoutAtTime && !startedLoading)
		{
			MyLogger.LogErrorInBuild("Localization preloading timed out after 15 seconds. Proceeding to Main Menu without preloading all tables.");
			LoadMain();
		}
	}

	private void LoadMain()
	{
		if (!startedLoading)
		{
			SceneManager.LoadScene("MainMenu");
			startedLoading = true;
		}
	}

	public LocalizationPreloader()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Main Menu");
		}
		else
		{
			list._size++;
			int num = default(int);
			items[num] = "Main Menu";
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"MainMenuOther");
		}
		else
		{
			list._size++;
			int num2 = default(int);
			items2[num2] = "MainMenuOther";
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"SettingsUi");
		}
		else
		{
			list._size++;
			int num3 = default(int);
			items3[num3] = "SettingsUi";
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Other");
		}
		else
		{
			list._size++;
			int num4 = default(int);
			items4[num4] = "Other";
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Enemies");
		}
		else
		{
			list._size++;
			int num5 = default(int);
			items5[num5] = "Enemies";
		}
		list._version++;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Items");
		}
		else
		{
			list._size++;
			int num6 = default(int);
			items6[num6] = "Items";
		}
		list._version++;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Weapons");
		}
		else
		{
			list._size++;
			int num7 = default(int);
			items7[num7] = "Weapons";
		}
		tableNamesToPreload = list;
		base._002Ector();
	}
}
