using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.UI.Animation;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class VictoryScreen : MonoBehaviour
{
	private sealed class _003CShowNewItem_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VictoryScreen _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShowNewItem_003Ed__27(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0577: Expected I4, but got I8
			//IL_05a0: Expected I, but got O
			//IL_05a9: Expected O, but got I4
			//IL_05dd: Expected I, but got O
			//IL_07d1: Expected I, but got O
			//IL_077b: Expected I, but got O
			//IL_0629: Expected O, but got Ref
			//IL_00dd: Expected I4, but got O
			//IL_0102: Expected I, but got O
			//IL_010f: Expected O, but got Ref
			//IL_068b: Expected I, but got O
			//IL_012f: Expected O, but got Ref
			//IL_01bc: Expected I, but got O
			//IL_0222: Expected I, but got O
			//IL_022f: Expected O, but got Ref
			//IL_026d: Expected I, but got O
			//IL_0293: Expected I, but got O
			//IL_02ac: Expected O, but got I
			//IL_079f: Expected O, but got I
			//IL_07b8: Expected I4, but got O
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_031f: Expected O, but got Unknown
			//IL_034e: Expected I, but got O
			//IL_037e: Expected I, but got O
			//IL_03ed: Expected O, but got Ref
			//IL_040d: Expected O, but got Ref
			//IL_0461: Expected I, but got O
			//IL_046a: Expected I, but got O
			//IL_0490: Expected I, but got O
			//IL_04a0: Expected O, but got I
			//IL_04d3: Expected I, but got O
			//IL_04e9: Expected I, but got O
			VictoryScreen victoryScreen = _003C_003E4__this;
			float num2 = default(float);
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				_003CShowNewItem_003Ed__27 obj = this;
				if (!flag)
				{
					bool flag2 = (object)victoryScreen.content == null;
					obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.content;
					if (!flag2)
					{
						victoryScreen.content.SetActive(value: true);
						bool flag3 = (object)victoryScreen.sfx == null;
						nint num = 1;
						object obj2 = null;
						obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.sfx;
						if (!flag3)
						{
							victoryScreen.sfx.Play();
							obj = (_003CShowNewItem_003Ed__27)(object)MapController.runConfig;
							bool flag4 = MapController.runConfig == null;
							num = unchecked((nint)null);
							obj2 = null;
							if (!flag4)
							{
								Color tierColor = MyColorUtility.GetTierColor((int)obj._003C_003E4__this);
								bool flag5 = (object)victoryScreen.ps == null;
								num = (nint)obj._003C_003E4__this;
								obj2 = null;
								obj = (_003CShowNewItem_003Ed__27)(&num2);
								if (!flag5)
								{
									victoryScreen.ps.startColor = (Color)(&num2);
									bool flag6 = (object)victoryScreen.ps == null;
									num = (nint)(&num2);
									obj2 = null;
									obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.ps;
									if (!flag6)
									{
										victoryScreen.ps.Play();
										LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("Other", "TIER_SMART");
										object[] array = new object[1];
										Dictionary<string, string> dictionary = new Dictionary<string, string>();
										nint num3 = (nint)typeof(MapController);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rcx_v30 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
										nint num4 = 0;
										obj = (_003CShowNewItem_003Ed__27)(object)MapController.runConfig;
										bool flag7 = MapController.runConfig == null;
										num = num4;
										obj2 = null;
										if (!flag7)
										{
											int num5 = default(int);
											string text = num5.ToString();
											bool flag8 = dictionary == null;
											num = unchecked((nint)null);
											obj2 = null;
											obj = (_003CShowNewItem_003Ed__27)(&num5);
											if (!flag8)
											{
												((Dictionary<object, object>)(object)dictionary).Add((object)"tier", (object)text);
												bool flag9 = array == null;
												nint num6 = 0;
												num = unchecked((nint)"tier");
												obj2 = text;
												obj = (_003CShowNewItem_003Ed__27)(object)dictionary;
												if (!flag9)
												{
													nint num7 = (nint)array;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rdx_v24 (Il2CppClass<System.Object[]>)+40]");
													dictionary.Add((string)0, text);
													object obj3 = default(object);
													bool flag10 = obj3 == null;
													num6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rdx_v24 (Il2CppClass<System.Object[]>)+40]");
													num = 0;
													obj2 = text;
													obj = (_003CShowNewItem_003Ed__27)(object)dictionary;
													if (flag10)
													{
														((Dictionary<string, string>)(object)obj).Add((string)num, (string)obj2);
														object obj4 = default(object);
														throw obj4;
													}
													if (array.Length <= 0)
													{
														IndexOutOfRangeException ex = new IndexOutOfRangeException();
														return (byte)(int)ex != 0;
													}
													obj = (_003CShowNewItem_003Ed__27)(array + 32);
													array[0] = dictionary;
													bool flag11 = localizedStringReference == null;
													num6 = 0;
													num = (nint)dictionary;
													obj2 = text;
													if (!flag11)
													{
														string localizedString = localizedStringReference.GetLocalizedString(array);
														num = (nint)MapController.runConfig;
														bool flag12 = MapController.runConfig == null;
														num6 = 0;
														obj2 = null;
														obj = (_003CShowNewItem_003Ed__27)(object)typeof(MapController);
														if (!flag12)
														{
															Color tierColor2 = MyColorUtility.GetTierColor(0);
															bool flag13 = (object)victoryScreen.t_score == null;
															num6 = 0;
															num = 0;
															obj2 = null;
															obj = (_003CShowNewItem_003Ed__27)(&num2);
															if (!flag13)
															{
																victoryScreen.t_score.color = (Color)(&num2);
																TextMeshProUGUI t_score = victoryScreen.t_score;
																string localizedString2 = LocalizationUtility.GetLocalizedString("Game_RoundOver", "VICTORY_COMPLETED");
																string text2 = localizedString + "\n<size=50%>" + localizedString2;
																bool flag14 = (object)victoryScreen.t_score == null;
																num6 = unchecked((nint)null);
																num = unchecked((nint)"\n<size=50%>");
																obj2 = localizedString2;
																obj = (_003CShowNewItem_003Ed__27)(object)localizedString;
																if (!flag14)
																{
																	num6 = (nint)t_score;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r9_v3 (Il2CppMethodInfo)+560]");
																	obj2 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v458 @ r9_v3 (Il2CppMethodInfo)+558] (should have been resolved before IL gen)");
																	obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.extraText;
																	bool flag15 = (object)victoryScreen.extraText == null;
																	num = (nint)text2;
																	if (!flag15)
																	{
																		nint num8 = (nint)obj;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v655 @ rax_v48 (Il2CppClass<VictoryScreen+<ShowNewItem>d__27>)+558] (should have been resolved before IL gen)");
																		victoryScreen.animatorTime = 0f;
																		victoryScreen.yRotation = 720f;
																		WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
																		_003C_003E2__current = waitForSeconds;
																		_003C_003E1__state = 1;
																		return true;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0717;
				}
				_003C_003E1__state = -1;
				int stat = RunStats.GetStat(EMyStat.silverEarned);
				bool flag16 = (object)_003C_003E4__this == null;
				nint num = unchecked((nint)null);
				_003CShowNewItem_003Ed__27 obj = (_003CShowNewItem_003Ed__27)23;
				if (!flag16)
				{
					victoryScreen.maxSilver = stat;
					bool flag17 = (object)victoryScreen.extraText == null;
					num = unchecked((nint)null);
					obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.extraText;
					if (!flag17)
					{
						Transform transform = victoryScreen.extraText.transform;
						obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.extraText;
						bool flag18 = (object)transform == null;
						num = unchecked((nint)null);
						if (!flag18)
						{
							transform.localScale = (Vector3)(&num2);
							bool flag19 = (object)victoryScreen.extraText == null;
							num = (nint)(&num2);
							object obj2 = null;
							obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.extraText;
							if (!flag19)
							{
								GameObject gameObject = victoryScreen.extraText.gameObject;
								bool flag20 = (object)gameObject == null;
								num = unchecked((nint)null);
								obj2 = null;
								obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.extraText;
								if (!flag20)
								{
									gameObject.SetActive(value: true);
									victoryScreen.silverStarted = true;
									bool flag21 = (object)victoryScreen.silverSfx == null;
									num = 1;
									obj2 = null;
									obj = (_003CShowNewItem_003Ed__27)(object)victoryScreen.silverSfx;
									if (!flag21)
									{
										victoryScreen.silverSfx.Play();
										goto IL_0717;
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_0717:
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

	public GameObject content;

	public RawImage background;

	public RawImage itemDisplay;

	public TextMeshProUGUI itemNameText;

	public TextMeshProUGUI extraText;

	public TextMeshProUGUI t_score;

	public ParticleSystem ps;

	public GameObject btnContinue;

	public GameObject coinFx;

	public UiAnimation buttonAnimation;

	private float fadeInTime = 0.6f;

	private float fadeOutTime = 0.2f;

	private float cardDesiredScale;

	private float textDesiredScale;

	private float desiredAlpha = 0.99f;

	private float yRotation = 1000f;

	public AudioSource silverSfx;

	public AudioSource silverSfxFinish;

	private float animatorTime;

	private float animatorSpeed = 0.8f;

	public AudioSource sfx;

	private bool silverStarted;

	private int maxSilver;

	private float silverTimer;

	private float silverAnimateTime = 1.75f;

	private unsafe void Start()
	{
		//IL_0033: Expected O, but got Ref
		//IL_0099: Expected O, but got Ref
		RunConfig runConfig = MapController.runConfig;
		Color tierColor = MyColorUtility.GetTierColor(runConfig.mapTierIndex);
		float num = default(float);
		background.color = (Color)(&num);
		background.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
		background.CrossFadeAlpha(desiredAlpha, fadeInTime, ignoreTimeScale: false);
		Transform transform = itemNameText.transform;
		transform.localScale = (Vector3)(&num);
		GameObject gameObject = btnContinue.gameObject;
		gameObject.SetActive(value: false);
		_003CShowNewItem_003Ed__27 obj = new _003CShowNewItem_003Ed__27(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void Update()
	{
		Animate();
	}

	private unsafe Color GetBackgroundColor()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0092: Expected native int or pointer, but got O
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b2: Expected native int or pointer, but got O
		//IL_00e3: Expected native int or pointer, but got O
		//IL_0129: Expected native int or pointer, but got O
		RunConfig runConfig = MapController.runConfig;
		if (MapController.runConfig != null)
		{
			Color tierColor = MyColorUtility.GetTierColor(runConfig.mapTierIndex);
			object obj = 0 - tierColor.r;
			object obj2 = 0 - tierColor.b;
			float num = (float)obj * 0.85f;
			float num2 = (float)obj2 * 0.85f;
			float r = num + tierColor.r;
			float b = num2 + tierColor.b;
			Color color = default(Color);
			((Color*)(nint)color)->r = r;
			object obj3 = 0 - tierColor.g;
			((Color*)(nint)color)->b = b;
			float num3 = (float)obj3 * 0.85f;
			float g = num3 + tierColor.g;
			((Color*)(nint)color)->g = g;
			float num4 = 1f - tierColor.a;
			float num5 = num4 * 0.85f;
			float a = num5 + tierColor.a;
			((Color*)(nint)color)->a = a;
			return color;
		}
		return (Color)new NullReferenceException();
	}

	private void Animate()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_090a: Invalid comparison between I4 and F4
		//IL_0063: Expected F4, but got I4
		//IL_0939: Invalid comparison between I4 and F4
		//IL_009f: Expected F4, but got I4
		//IL_0978: Invalid comparison between I4 and F4
		//IL_010b: Expected F4, but got I4
		//IL_0114: Expected F4, but got I4
		//IL_09b9: Expected I, but got O
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_0212: Invalid comparison between I4 and F4
		//IL_025d: Expected F4, but got I4
		//IL_0a7a: Expected I, but got O
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_036e: Expected O, but got I4
		//IL_0851: Invalid comparison between F4 and I4
		//IL_04c4: Invalid comparison between I4 and F4
		//IL_0adb: Expected I, but got O
		//IL_0b0d: Invalid comparison between I4 and F4
		//IL_0511: Expected F4, but got I4
		//IL_03ed: Expected F4, but got I4
		//IL_0c00: Invalid comparison between I4 and F4
		//IL_0557: Expected F4, but got I4
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_0425: Expected O, but got I4
		//IL_0cc1: Expected I, but got O
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Expected O, but got Unknown
		//IL_06ca: Expected F8, but got I
		//IL_06e0: Expected O, but got I
		//IL_05ef: Expected F8, but got I
		//IL_0605: Expected O, but got I
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4f: Expected O, but got Unknown
		//IL_0827: Invalid comparison between F8 and I4
		object obj2 = default(object);
		object obj = obj2 - 95;
		float num = animatorTime * 0.85f;
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
		float num2 = animatorTime * 0.5f;
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
		float num3 = animatorTime - 0.1f;
		float num4 = num3 * 0.5f;
		float t;
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
				t = 1f;
			}
			else
			{
				float num5 = animatorTime - 0.1f;
				t = num5 * 0.5f;
			}
		}
		else
		{
			num4 = 0f;
			t = 0f;
		}
		float num6 = Easing.OutElastic(num);
		float num7 = Easing.OutElastic(num2);
		Transform transform = itemDisplay.transform;
		nint num8 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num9 = 0;
		float num10 = num6 * (float)Vector3.oneVector;
		float num11 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num12 = num11 * 0f;
		float num13 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num14 = num13 * 0f;
		Vector3 localScale = (Vector3)(obj - 89);
		transform.localScale = localScale;
		Transform transform2 = itemDisplay.transform;
		float num15 = num7 - 1f;
		_ = 0;
		Vector3 euler = (Vector3)(obj - 89);
		float num16 = num15 * 10f;
		float num17 = num16 * ((float)Math.PI / 180f);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		Quaternion localRotation = (Quaternion)(obj - 89);
		_ = quaternion.x;
		transform2.localRotation = localRotation;
		float deltaTime = Time.deltaTime;
		float num18 = deltaTime * 3f;
		if (!(0f > num18))
		{
			if (num18 > 1f)
			{
				num18 = 1f;
			}
		}
		else
		{
			num18 = 0f;
		}
		float num19 = 0f - yRotation;
		float num20 = num19 * num18;
		float num21 = num20 + yRotation;
		yRotation = num21;
		float num22 = Easing.OutPower(num4, 20);
		float num23 = Easing.OutElastic(t);
		Transform transform3 = itemNameText.transform;
		nint num24 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rcx_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num25 = 0;
		float num26 = num22 * (float)Vector3.oneVector;
		float num27 = num22;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v14 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num28 = num27 * 0f;
		float num29 = num22;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v14 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num30 = num29 * 0f;
		Vector3 localScale2 = (Vector3)(obj - 89);
		transform3.localScale = localScale2;
		Transform transform4 = itemNameText.transform;
		float num31 = num23 - 1f;
		_ = 0;
		Vector3 euler2 = (Vector3)(obj - 89);
		float num32 = num31 * 5f;
		float num33 = num32 * ((float)Math.PI / 180f);
		Quaternion quaternion2 = Quaternion.Internal_FromEulerRad(euler2);
		Quaternion localRotation2 = (Quaternion)(obj - 89);
		_ = quaternion2.x;
		transform4.localRotation = localRotation2;
		GameObject gameObject = extraText.gameObject;
		bool activeInHierarchy = gameObject.activeInHierarchy;
		bool flag = !activeInHierarchy;
		object obj3 = 0;
		if (!flag)
		{
			Transform transform5 = extraText.transform;
			Transform transform6 = extraText.transform;
			Vector3 localScale3 = transform6.localScale;
			nint num34 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v62 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num35 = 0;
			float deltaTime2 = Time.deltaTime;
			float num36 = deltaTime2 * 6f;
			if (!(0f > num36))
			{
				if (num36 > 1f)
				{
					num36 = 1f;
				}
			}
			else
			{
				num36 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ rcx_v55 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
			float num37 = 0f - localScale3.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ rcx_v55 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num38 = 0f - localScale3.z;
			float num39 = (float)Vector3.oneVector - localScale3.x;
			float num40 = num37 * num36;
			float num41 = num38 * num36;
			float num42 = num39 * num36;
			float num43 = num40 + localScale3.y;
			float num44 = num41 + localScale3.z;
			float num45 = num42 + localScale3.x;
			Vector3 localScale4 = (Vector3)(obj - 89);
			transform5.localScale = localScale4;
			obj3 = 0;
		}
		float deltaTime3 = Time.deltaTime;
		bool flag2 = !silverStarted;
		float num46 = deltaTime3 * animatorSpeed;
		float num47 = num46 + animatorTime;
		animatorTime = num47;
		if (flag2 || !(silverAnimateTime > silverTimer))
		{
			goto IL_0846;
		}
		float deltaTime4 = Time.deltaTime;
		float num48 = deltaTime4 + silverTimer;
		if (!(0f > num48))
		{
			if (num48 > silverAnimateTime)
			{
				num48 = silverAnimateTime;
			}
		}
		else
		{
			num48 = 0f;
		}
		silverTimer = num48;
		float num49 = num48 / silverAnimateTime;
		float num50 = ((0f > num49) ? 0f : ((num49 > 1f) ? 1f : num49));
		float num51 = (float)maxSilver * num50;
		nint num52 = (nint)typeof(Math);
		object obj4 = obj + 119;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rcx_v38 (Il2CppClass<System.Math>)+E4]");
		double num53;
		double num55;
		if ((nint)0 >= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018057BC78h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rcx_v38 (Il2CppClass<System.Math>)+E4]");
			double num54;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm1\"");
				num53 = Math.Floor(num51);
				num54 = 0.5;
				goto IL_0740;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			num55 = 0.0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			object obj5 = (nint)0 & (nint)1;
			bool flag3 = obj5 == null;
			num54 = 0.5;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,qword ptr [18262EC98h]\"");
				num54 = 0.5;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262ED10h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018057BCAFh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rcx_v38 (Il2CppClass<System.Math>)+E4]");
			double num54;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC90h]\"");
				num53 = Math.Ceiling(num51);
				num54 = num28;
				goto IL_0740;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			num55 = 0.0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			object obj6 = (nint)0 & (nint)1;
			bool flag4 = obj6 == null;
			num54 = num28;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC98h]\"");
				num54 = num28;
			}
		}
		goto IL_0c2a;
		IL_0740:
		num55 = num53;
		goto IL_0c2a;
		IL_0c2a:
		float num56 = silverTimer / 0.12f;
		double num57 = Math.Floor(num56);
		if (!(num55 > num57))
		{
			num55 = num57;
		}
		object obj7 = obj + 103;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"<sprite name=silver> {arg}";
		string text2 = text + "\n<size=60%>Silver Earned";
		extraText.text = text2;
		float num58 = num49 * 0.25f;
		float pitch = num58 + 1f;
		silverSfx.pitch = pitch;
		float num59 = num49 * 0.2f;
		float volume = num59 + 0.3f;
		silverSfx.volume = volume;
		if (!(silverTimer < silverAnimateTime) || !(num55 < (double)maxSilver))
		{
			FinishSilverCounter();
		}
		goto IL_0846;
		IL_0846:
		if (silverTimer > 0f && silverAnimateTime > silverTimer)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.config != null && MyInputManager.GetButtonDown(MyInputManager.Interact))
			{
				FinishSilverCounter();
			}
		}
	}

	private unsafe void FinishSilverCounter()
	{
		//IL_011c: Expected I, but got O
		//IL_0074: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317309F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		silverTimer = silverAnimateTime;
		silverSfxFinish.Play();
		silverSfx.Stop();
		Transform transform = extraText.transform;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = (float)Vector3.oneVector * 1.6f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num4 = 0f * 1.6f;
		float num5 = default(float);
		transform.localScale = (Vector3)(&num5);
		Invoke("ShowButton", 0.25f);
		coinFx.SetActive(value: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"<sprite name=silver> {arg}";
		string localizedString = LocalizationUtility.GetLocalizedString("Game_RoundOver", "VICTORY_SILVER");
		string text2 = text + "\n<size=60%>" + localizedString;
		extraText.text = text2;
	}

	private void ShowButton()
	{
		btnContinue.SetActive(value: true);
		buttonAnimation.CrossFadeAndScaleIn(0.5f, EEasing.InOutCirc);
		MyButton component = btnContinue.GetComponent<MyButton>();
		ButtonManager.ForceHoverButton(component);
	}

	private IEnumerator ShowNewItem()
	{
		_003CShowNewItem_003Ed__27 obj = new _003CShowNewItem_003Ed__27(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
