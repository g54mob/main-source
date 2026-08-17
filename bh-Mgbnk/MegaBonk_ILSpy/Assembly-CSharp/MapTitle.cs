using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Managers;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UIElements.Experimental;

public class MapTitle : MonoBehaviour
{
	private sealed class _003CTypeDescription_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapTitle _003C_003E4__this;

		private string _003Cdescription_003E5__2;

		private int _003Ci_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CTypeDescription_003Ed__22(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0256: Expected I4, but got I8
			//IL_03d1: Expected I4, but got O
			MapTitle mapTitle = _003C_003E4__this;
			string text;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					mapTitle.isTyping = true;
					MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
					if ((object)MapController._003CcurrentMap_003Ek__BackingField != null)
					{
						if (mapData.eMap == EMap.Graveyard)
						{
							int numDescriptionsShowed = mapTitle.numDescriptionsShowed + 1;
							mapTitle.numDescriptionsShowed = numDescriptionsShowed;
							if (mapTitle.numDescriptionsShowed == 0)
							{
								if (mapTitle.cryptDesc == null)
								{
									goto IL_03c3;
								}
								text = mapTitle.cryptDesc.GetLocalizedString();
								goto IL_0407;
							}
						}
						if (!MapController.isFinalBossStage)
						{
							if ((object)MapController._003CcurrentStage_003Ek__BackingField == null)
							{
								goto IL_03c3;
							}
							text = MapController._003CcurrentStage_003Ek__BackingField.GetDescription();
						}
						else
						{
							text = "???";
						}
						goto IL_0407;
					}
				}
				goto IL_03c3;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_03b5;
			}
			int num = _003Ci_003E5__3 + 1;
			_003Ci_003E5__3 = num;
			_003C_003E1__state = -1;
			goto IL_043d;
			IL_043d:
			string text2 = _003Cdescription_003E5__2;
			if (_003Cdescription_003E5__2 != null)
			{
				if (_003Ci_003E5__3 >= text2._stringLength)
				{
					goto IL_03b5;
				}
				if ((object)_003C_003E4__this != null && (object)mapTitle.t_description != null)
				{
					string text3 = mapTitle.t_description.text;
					if (_003Cdescription_003E5__2 != null)
					{
						char c = _003Cdescription_003E5__2.get_Chars(_003Ci_003E5__3);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
						string text5 = default(string);
						string text4 = text3 + text5;
						mapTitle.t_description.text = text4;
						if ((object)mapTitle.letterSfx != null)
						{
							mapTitle.letterSfx.Play();
							WaitForSeconds waitForSeconds = new WaitForSeconds(0.05f);
							_003C_003E2__current = waitForSeconds;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
			}
			goto IL_03c3;
			IL_03b5:
			return false;
			IL_03c3:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0407:
			_003Cdescription_003E5__2 = text;
			if ((object)mapTitle.t_description != null)
			{
				mapTitle.t_description.text = "";
				if ((object)mapTitle.t_description != null)
				{
					GameObject gameObject = mapTitle.t_description.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: true);
						_003Ci_003E5__3 = 0;
						goto IL_043d;
					}
				}
			}
			goto IL_03c3;
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

	private float delay = 0.5f;

	private float visibleTime = 2f;

	private float fadeTime = 2f;

	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_tier;

	public CanvasGroup titleCanvasGroup;

	private float alphaTimer;

	public StageData testStage;

	public LocalizedString cryptTitle;

	public LocalizedString cryptDesc;

	private bool started;

	private RunConfig runConfig;

	private int numTimesShowed;

	private float totalTimer;

	private bool hasPlayedSfx;

	private bool isFading;

	private bool isTyping;

	private int numDescriptionsShowed;

	public AudioSource textSfx;

	public RandomSfx letterSfx;

	private bool done;

	public unsafe void StartAnimation()
	{
		//IL_009f: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_0145: Expected O, but got I
		//IL_0155: Expected O, but got I
		//IL_01b2: Expected O, but got Ref
		if (MapController.isFinalBossStage)
		{
			return;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		started = true;
		done = false;
		totalTimer = 0f;
		alphaTimer = 0f;
		isFading = false;
		hasPlayedSfx = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v11+B8]");
		object text = 0;
		t_description.text = (string)text;
		runConfig = MapController.runConfig;
		if (runConfig == null)
		{
			return;
		}
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData.eMap != EMap.Graveyard)
		{
			SetMapText();
		}
		else
		{
			if (numTimesShowed > 0)
			{
				SetMapText();
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rax_v30+B8]");
				object text2 = 0;
				t_tier.text = (string)text2;
				string localizedString = cryptTitle.GetLocalizedString();
				t_title.text = localizedString;
			}
			int num = numTimesShowed + 1;
			numTimesShowed = num;
		}
		Transform transform = titleCanvasGroup.transform;
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
		titleCanvasGroup.alpha = 0f;
		alphaTimer = 0f;
	}

	private void SetGraveyardText()
	{
		//IL_0053: Expected O, but got I
		//IL_0063: Expected O, but got I
		if (numTimesShowed > 0)
		{
			SetMapText();
			int num = numTimesShowed + 1;
			numTimesShowed = num;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v3+B8]");
		object text = 0;
		t_tier.text = (string)text;
		string localizedString = cryptTitle.GetLocalizedString();
		t_title.text = localizedString;
		int num2 = numTimesShowed + 1;
		numTimesShowed = num2;
	}

	private unsafe void SetMapText()
	{
		//IL_0306: Expected I4, but got O
		//IL_0018: Expected I4, but got O
		//IL_0069: Expected I, but got O
		//IL_00b7: Expected I, but got O
		//IL_00bf: Expected I4, but got O
		//IL_00d5: Expected I, but got O
		//IL_00ee: Expected O, but got I
		//IL_0123: Expected I4, but got O
		//IL_0346: Expected O, but got I
		//IL_0346: Expected O, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected I4, but got Unknown
		//IL_0176: Expected I, but got O
		//IL_01b9: Expected I, but got O
		//IL_01c1: Expected I4, but got O
		//IL_01ec: Expected O, but got I
		//IL_0219: Expected I, but got O
		//IL_0223: Expected I4, but got O
		//IL_0293: Expected I, but got O
		//IL_02a3: Expected O, but got I
		//IL_02cd: Expected I, but got O
		//IL_02d2: Expected I4, but got O
		int num = (int)t_tier;
		LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("Other", "TIER_SMART");
		object[] array = new object[1];
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary._002Ector();
		int num2 = (int)this.runConfig;
		bool flag = this.runConfig == null;
		object obj = null;
		nint num3 = 0;
		if (!flag)
		{
			int num4 = default(int);
			string text = num4.ToString();
			bool flag2 = dictionary == null;
			obj = null;
			num3 = unchecked((nint)null);
			num2 = (int)(&num4);
			if (!flag2)
			{
				((Dictionary<object, object>)(object)dictionary).Add((object)"tier", (object)text);
				bool flag3 = array == null;
				obj = text;
				nint num5 = 0;
				num3 = unchecked((nint)"tier");
				num2 = (int)dictionary;
				if (!flag3)
				{
					nint num6 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
					dictionary.Add((string)0, text);
					object obj2 = default(object);
					bool flag4 = obj2 == null;
					obj = text;
					num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
					num3 = 0;
					num2 = (int)dictionary;
					if (flag4)
					{
						((Dictionary<string, string>)num2).Add((string)num3, (string)obj);
						object obj3 = default(object);
						throw obj3;
					}
					num2 = array + 32;
					array[0] = dictionary;
					bool flag5 = localizedStringReference == null;
					obj = text;
					num5 = 0;
					num3 = (nint)dictionary;
					if (!flag5)
					{
						string localizedString = localizedStringReference.GetLocalizedString(array);
						bool flag6 = (object)t_tier == null;
						obj = null;
						num5 = 0;
						num3 = (nint)array;
						num2 = (int)localizedStringReference;
						if (!flag6)
						{
							num5 = ((int*)num)->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r9_v2 (Il2CppMethodInfo)+560]");
							obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ r9_v2 (Il2CppMethodInfo)+558] (should have been resolved before IL gen)");
							RunConfig runConfig = this.runConfig;
							bool flag7 = this.runConfig == null;
							num3 = (nint)localizedString;
							num2 = (int)t_tier;
							if (!flag7)
							{
								TextMeshProUGUI textMeshProUGUI = t_tier;
								Color tierColor = MyColorUtility.GetTierColor(runConfig.mapTierIndex);
								bool flag8 = (object)t_tier == null;
								obj = null;
								num3 = runConfig.mapTierIndex;
								object obj4 = default(object);
								num2 = (int)(&obj4);
								if (!flag8)
								{
									num5 = (nint)textMeshProUGUI;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r9_v2 (Il2CppMethodInfo)+2B0]");
									obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ r9_v2 (Il2CppMethodInfo)+2A8] (should have been resolved before IL gen)");
									string title = GetTitle();
									bool flag9 = (object)t_title == null;
									num3 = unchecked((nint)null);
									num2 = (int)this;
									if (!flag9)
									{
										t_title.text = title;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void Update()
	{
		//IL_0456: Invalid comparison between I4 and F4
		//IL_0377: Invalid comparison between I4 and F4
		//IL_01c9: Expected F4, but got I4
		//IL_00eb: Expected F4, but got I4
		//IL_01db: Expected O, but got Ref
		//IL_0236: Invalid comparison between F4 and I4
		//IL_02ad: Invalid comparison between I4 and F4
		//IL_040c: Invalid comparison between I4 and F4
		//IL_0289: Expected F4, but got I4
		if (done || !started)
		{
			return;
		}
		float num = (totalTimer += MyTime.deltaTime);
		if (delay > num)
		{
			return;
		}
		if (!hasPlayedSfx)
		{
			hasPlayedSfx = true;
			textSfx.Play();
		}
		if (1f > alphaTimer && !isFading)
		{
			float num2 = MyTime.deltaTime / fadeTime;
			float num3 = num2 + alphaTimer;
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
			alphaTimer = num3;
			float alpha = Easing.InOutQuad(num3);
			titleCanvasGroup.alpha = alpha;
			if (!(alphaTimer < 0.3f) && !isTyping)
			{
				_003CTypeDescription_003Ed__22 obj = new _003CTypeDescription_003Ed__22(0);
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj);
			}
		}
		Transform transform = titleCanvasGroup.transform;
		Transform transform2 = titleCanvasGroup.transform;
		Vector3 localScale = transform2.localScale;
		float num4 = MyTime.deltaTime * 0.75f;
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		float num5 = default(float);
		transform.localScale = (Vector3)(&num5);
		float num6 = fadeTime + delay;
		float num7 = num6 + visibleTime;
		if (!(totalTimer > num7))
		{
			return;
		}
		isFading = true;
		if (alphaTimer > 0f)
		{
			float num8 = MyTime.deltaTime / fadeTime;
			float num9 = alphaTimer - num8;
			if (!(0f > num9))
			{
				if (num9 > 1f)
				{
					num9 = 1f;
				}
			}
			else
			{
				num9 = 0f;
			}
			alphaTimer = num9;
			float alpha2 = Easing.InOutQuad(num9);
			titleCanvasGroup.alpha = alpha2;
		}
		if (!(0f < alphaTimer))
		{
			done = true;
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private IEnumerator TypeDescription()
	{
		_003CTypeDescription_003Ed__22 obj = new _003CTypeDescription_003Ed__22(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private string GetTitle()
	{
		//IL_018a: Expected I, but got O
		//IL_01a8: Expected I, but got O
		//IL_01c1: Expected O, but got I
		//IL_02bb: Expected O, but got I
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_026b: Expected I, but got O
		if (!MapController.isFinalBossStage)
		{
			Dictionary<object, object> dictionary = (Dictionary<object, object>)(object)MapController._003CcurrentStage_003Ek__BackingField;
			if ((object)MapController._003CcurrentStage_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180381570");
				string result = default(string);
				return result;
			}
		}
		else
		{
			LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("Maps", "MAP_RIFT");
			object[] array = new object[1];
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			Dictionary<object, object> dictionary = (Dictionary<object, object>)(object)runConfig;
			bool flag = runConfig == null;
			object obj = null;
			nint num = 0;
			if (!flag)
			{
				dictionary = (Dictionary<object, object>)(object)dictionary._buckets;
				bool flag2 = dictionary._buckets == null;
				obj = null;
				num = 0;
				if (!flag2)
				{
					obj = dictionary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ r8_v2 (System.Object)+190]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v326 @ r8_v2 (System.Object)+188] (should have been resolved before IL gen)");
					if (dictionary2 != null)
					{
						object obj2 = default(object);
						((Dictionary<object, object>)(object)dictionary2).Add((object)"mapname", obj2);
						bool flag3 = array == null;
						nint num2 = 0;
						obj = obj2;
						num = unchecked((nint)"mapname");
						dictionary = (Dictionary<object, object>)(object)dictionary2;
						if (!flag3)
						{
							nint num3 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
							dictionary2.Add((string)0, (string)obj2);
							object obj3 = default(object);
							bool flag4 = obj3 == null;
							num2 = 0;
							obj = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
							num = 0;
							dictionary = (Dictionary<object, object>)(object)dictionary2;
							if (flag4)
							{
								((Dictionary<string, string>)(object)dictionary).Add((string)num, (string)obj);
								object obj4 = default(object);
								throw obj4;
							}
							if (array.Length <= 0)
							{
								return (string)(object)new IndexOutOfRangeException();
							}
							dictionary = (Dictionary<object, object>)(array + 32);
							array[0] = dictionary2;
							bool flag5 = localizedStringReference == null;
							num2 = 0;
							obj = obj2;
							num = (nint)dictionary2;
							if (!flag5)
							{
								return localizedStringReference.GetLocalizedString(array);
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private string GetDescription()
	{
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if ((object)MapController._003CcurrentMap_003Ek__BackingField != null)
		{
			if (mapData.eMap == EMap.Graveyard)
			{
				int num = numDescriptionsShowed + 1;
				numDescriptionsShowed = num;
				if (numDescriptionsShowed == 0)
				{
					if (cryptDesc != null)
					{
						return cryptDesc.GetLocalizedString();
					}
					goto IL_0131;
				}
			}
			if (MapController.isFinalBossStage)
			{
				return "???";
			}
			if ((object)MapController._003CcurrentStage_003Ek__BackingField != null)
			{
				return MapController._003CcurrentStage_003Ek__BackingField.GetDescription();
			}
		}
		goto IL_0131;
		IL_0131:
		return (string)(object)new NullReferenceException();
	}
}
