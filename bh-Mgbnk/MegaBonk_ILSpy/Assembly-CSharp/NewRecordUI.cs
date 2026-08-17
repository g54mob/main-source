using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Steam.LeaderboardsNew;
using Assets.Scripts.UI.Animation;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class NewRecordUI : MonoBehaviour
{
	private sealed class _003CShowNewItem_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NewRecordUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShowNewItem_003Ed__20(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_0428: Expected I4, but got O
			//IL_01ea: Expected I, but got O
			//IL_01fa: Expected O, but got I
			//IL_02e7: Expected O, but got I4
			if (_003C_003E1__state == 0)
			{
				NewRecordUI newRecordUI = _003C_003E4__this;
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)newRecordUI.content != null)
				{
					newRecordUI.content.SetActive(value: true);
					if ((object)newRecordUI.sfx != null)
					{
						newRecordUI.sfx.Play();
						if ((object)newRecordUI.ps != null)
						{
							newRecordUI.ps.Play();
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							int stat = RunStats.GetStat(EMyStat.kills);
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
							object arg = default(object);
							string value = $"{arg:N0}";
							if (dictionary != null)
							{
								((Dictionary<object, object>)(object)dictionary).Add((object)"", (object)value);
								string localizedString = LocalizationUtility.GetLocalizedString("Game_RoundOver", "RECORD_NEW", dictionary);
								TextMeshProUGUI t_score = newRecordUI.t_score;
								string text = "<size=115%><sprite name=skull></size> " + localizedString;
								if ((object)newRecordUI.t_score != null)
								{
									newRecordUI.t_score.text = text;
									TextMeshProUGUI extraText = newRecordUI.extraText;
									if ((object)newRecordUI.extraText != null)
									{
										nint num = (nint)extraText;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v18 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
										object obj = 0;
										newRecordUI.extraText.text = "";
										UiManager instance = UiManager.Instance;
										if ((object)UiManager.Instance != null)
										{
											DeathScreen deathScreen = instance.deathScreen;
											if ((object)instance.deathScreen != null)
											{
												int num2 = deathScreen._003CnewRecordRank_003Ek__BackingField + 1;
												UiManager instance2 = UiManager.Instance;
												DeathScreen deathScreen2 = instance2.deathScreen;
												SteamLeaderboardNew leaderboard = SteamLeaderboardsManagerNew.GetLeaderboard(deathScreen2._003CnewRecordLbName_003Ek__BackingField);
												if (leaderboard != null)
												{
													int totalEntries = leaderboard.GetTotalEntries(deathScreen2._003CnewRecordLbName_003Ek__BackingField);
													num2 = totalEntries;
													obj = 0;
												}
												Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
												object arg2 = default(object);
												string value2 = $"{arg2:N0}";
												((Dictionary<object, object>)(object)dictionary2).Add((object)"rank", (object)value2);
												string localizedString2 = LocalizationUtility.GetLocalizedString("Game_RoundOver", "RECORD_RANKING", dictionary2);
												Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
												int num3 = deathScreen._003CnewRecordRank_003Ek__BackingField / num2;
												float num4 = (float)num3 * 100f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
												object arg3 = default(object);
												string value3 = $"{arg3:F1}";
												((Dictionary<object, object>)(object)dictionary3).Add((object)"percentile", (object)value3);
												string localizedString3 = LocalizationUtility.GetLocalizedString("Game_RoundOver", "RECORD_PERCENTILE", dictionary3);
												string text2 = localizedString2 + "<size=75%>\n" + localizedString3;
												newRecordUI.extraText.text = text2;
												newRecordUI.yRotation = 720f;
												return false;
											}
										}
									}
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
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

	public GameObject content;

	public RawImage background;

	public RawImage itemDisplay;

	public TextMeshProUGUI itemNameText;

	public TextMeshProUGUI extraText;

	public TextMeshProUGUI t_score;

	public ParticleSystem ps;

	public UiAnimation buttonAnimation;

	private float fadeInTime = 0.6f;

	private float fadeOutTime = 0.2f;

	private float cardDesiredScale;

	private float textDesiredScale;

	private float desiredAlpha = 0.99f;

	private float yRotation = 1000f;

	private float animatorTime;

	private float animatorSpeed = 0.8f;

	public AudioSource sfx;

	private unsafe void Start()
	{
		//IL_0061: Expected O, but got Ref
		background.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
		background.CrossFadeAlpha(desiredAlpha, fadeInTime, ignoreTimeScale: false);
		Transform transform = itemNameText.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
		buttonAnimation.CrossFadeAndScaleIn(1f, EEasing.InOutCirc);
		_003CShowNewItem_003Ed__20 obj2 = new _003CShowNewItem_003Ed__20(0);
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
	}

	private void Update()
	{
		Animate();
	}

	private void Animate()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_004c: Invalid comparison between I4 and F4
		//IL_0097: Expected F4, but got I4
		//IL_044f: Invalid comparison between I4 and F4
		//IL_00d3: Expected F4, but got I4
		//IL_048e: Invalid comparison between I4 and F4
		//IL_013f: Expected F4, but got I4
		//IL_0148: Expected F4, but got I4
		//IL_04bd: Invalid comparison between I4 and F4
		//IL_0184: Expected F4, but got I4
		//IL_04fe: Expected I, but got O
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0282: Invalid comparison between I4 and F4
		//IL_02cd: Expected F4, but got I4
		//IL_05bf: Expected I, but got O
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected O, but got Unknown
		//IL_0620: Expected I, but got O
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
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
		float num6 = animatorTime - 0.5f;
		if (!(0f > num6))
		{
			if (num6 > 1f)
			{
				num6 = 1f;
			}
		}
		else
		{
			num6 = 0f;
		}
		float num7 = Easing.OutElastic(num);
		float num8 = Easing.OutElastic(num2);
		Transform transform = itemDisplay.transform;
		nint num9 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rcx_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num10 = 0;
		float num11 = num7 * (float)Vector3.oneVector;
		float num12 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num13 = num12 * 0f;
		float num14 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num15 = num14 * 0f;
		Vector3 localScale = (Vector3)(obj - 57);
		transform.localScale = localScale;
		Transform transform2 = itemDisplay.transform;
		float num16 = num8 - 1f;
		_ = 0;
		Vector3 euler = (Vector3)(obj - 57);
		float num17 = num16 * 10f;
		float num18 = num17 * ((float)Math.PI / 180f);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		Quaternion localRotation = (Quaternion)(obj - 57);
		_ = quaternion.x;
		transform2.localRotation = localRotation;
		float deltaTime = Time.deltaTime;
		float num19 = deltaTime * 3f;
		if (!(0f > num19))
		{
			if (num19 > 1f)
			{
				num19 = 1f;
			}
		}
		else
		{
			num19 = 0f;
		}
		float num20 = 0f - yRotation;
		float num21 = num20 * num19;
		float num22 = num21 + yRotation;
		yRotation = num22;
		float num23 = Easing.OutPower(num4, 20);
		float num24 = Easing.OutElastic(t);
		Transform transform3 = itemNameText.transform;
		nint num25 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num26 = 0;
		float num27 = num23 * (float)Vector3.oneVector;
		float num28 = num23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num29 = num28 * 0f;
		float num30 = num23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num31 = num30 * 0f;
		Vector3 localScale2 = (Vector3)(obj - 57);
		transform3.localScale = localScale2;
		Transform transform4 = itemNameText.transform;
		float num32 = num24 - 1f;
		_ = 0;
		Vector3 euler2 = (Vector3)(obj - 57);
		float num33 = num32 * 5f;
		float num34 = num33 * ((float)Math.PI / 180f);
		Quaternion quaternion2 = Quaternion.Internal_FromEulerRad(euler2);
		Quaternion localRotation2 = (Quaternion)(obj - 57);
		_ = quaternion2.x;
		transform4.localRotation = localRotation2;
		float num35 = Easing.OutPower(num6, 10);
		Transform transform5 = extraText.transform;
		nint num36 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num37 = 0;
		float num38 = num35 * (float)Vector3.oneVector;
		float num39 = num35;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num40 = num39 * 0f;
		float num41 = num35;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num42 = num41 * 0f;
		Vector3 localScale3 = (Vector3)(obj - 57);
		transform5.localScale = localScale3;
		float deltaTime2 = Time.deltaTime;
		float num43 = deltaTime2 * animatorSpeed;
		float num44 = num43 + animatorTime;
		animatorTime = num44;
	}

	private IEnumerator ShowNewItem()
	{
		_003CShowNewItem_003Ed__20 obj = new _003CShowNewItem_003Ed__20(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
