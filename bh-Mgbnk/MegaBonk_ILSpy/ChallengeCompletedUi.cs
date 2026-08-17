using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ChallengeCompletedUi : MonoBehaviour
{
	private sealed class _003CStartAnimate_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChallengeCompletedUi _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CStartAnimate_003Ed__24(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_02b1: Expected I4, but got O
			//IL_01d6: Expected O, but got Ref
			//IL_021c: Expected O, but got Ref
			if (_003C_003E1__state <= 1)
			{
				ChallengeCompletedUi challengeCompletedUi = _003C_003E4__this;
				_003C_003E1__state = -1;
				if (Application.isFocused)
				{
					if ((object)_003C_003E4__this != null && (object)challengeCompletedUi.content != null)
					{
						challengeCompletedUi.content.SetActive(value: true);
						if ((object)challengeCompletedUi.canvasGroup != null)
						{
							challengeCompletedUi.canvasGroup.alpha = 1f;
							if ((object)challengeCompletedUi.background != null)
							{
								challengeCompletedUi.background.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
								if ((object)challengeCompletedUi.background != null)
								{
									challengeCompletedUi.background.CrossFadeAlpha(challengeCompletedUi.desiredAlpha, challengeCompletedUi.fadeInTime, ignoreTimeScale: false);
									if ((object)challengeCompletedUi.sfx != null)
									{
										challengeCompletedUi.sfx.Play();
										if ((object)challengeCompletedUi.text != null)
										{
											Transform transform = challengeCompletedUi.text.transform;
											if ((object)transform != null)
											{
												Vector3 vector = default(Vector3);
												transform.localScale = (Vector3)(&vector);
												if ((object)challengeCompletedUi.challengeBox != null)
												{
													Transform transform2 = challengeCompletedUi.challengeBox.transform;
													if ((object)transform2 != null)
													{
														transform2.localScale = (Vector3)(&vector);
														challengeCompletedUi.animatorTime = 0f;
														challengeCompletedUi.animatorSpeed = 0.8f;
														if ((object)challengeCompletedUi.particles != null)
														{
															GameObject gameObject = challengeCompletedUi.particles.gameObject;
															if ((object)gameObject != null)
															{
																gameObject.SetActive(value: true);
																return false;
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
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				WaitForSeconds waitForSeconds = new WaitForSeconds(MyTime.deltaTime);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
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

	public AudioSource sfx;

	public GameObject content;

	public GameObject text;

	public GameObject challengeBox;

	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_description;

	public TextSizer textSizer;

	public CanvasGroup canvasGroup;

	public GameObject particles;

	public RawImage shadow;

	private float fadeInTime = 0.6f;

	private float fadeOutTime = 0.2f;

	private float cardDesiredScale;

	private float textDesiredScale;

	private float desiredAlpha = 0.98f;

	private float animatorTime;

	private float animatorSpeed = 0.8f;

	public Image background;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<ChallengeData> b = OnAchievementUnlocked;
		Delegate obj = Delegate.Combine(ChallengesTracker.A_ChallengeCompleted, b);
		if ((object)obj == null)
		{
			ChallengesTracker.A_ChallengeCompleted = (Action<ChallengeData>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ChallengeData> action = default(Action<ChallengeData>);
		if (action != null)
		{
			ChallengesTracker.A_ChallengeCompleted = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<ChallengeData>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<ChallengeData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<ChallengeData> value = OnAchievementUnlocked;
		Delegate obj = Delegate.Remove(ChallengesTracker.A_ChallengeCompleted, value);
		if ((object)obj == null)
		{
			ChallengesTracker.A_ChallengeCompleted = (Action<ChallengeData>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ChallengeData> action = default(Action<ChallengeData>);
		if (action != null)
		{
			ChallengesTracker.A_ChallengeCompleted = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<ChallengeData>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<ChallengeData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Test()
	{
	}

	private void OnAchievementUnlocked(ChallengeData challenge)
	{
		TextMeshProUGUI textMeshProUGUI = t_header;
		string displayName = challenge.GetDisplayName();
		textMeshProUGUI.text = displayName;
		_003CStartAnimate_003Ed__24 obj = new _003CStartAnimate_003Ed__24(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void Update()
	{
		Animate();
	}

	private unsafe void Animate()
	{
		//IL_0058: Invalid comparison between I4 and F4
		//IL_00d3: Expected F4, but got I4
		//IL_00dc: Expected F4, but got I4
		//IL_0267: Invalid comparison between I4 and F4
		//IL_0118: Expected F4, but got I4
		//IL_013e: Expected O, but got Ref
		//IL_015b: Expected O, but got Ref
		//IL_0171: Expected O, but got Ref
		//IL_01a9: Expected O, but got Ref
		//IL_0325: Invalid comparison between I4 and F4
		//IL_0303: Invalid comparison between I4 and F4
		if (!content.activeSelf)
		{
			return;
		}
		float num = animatorTime - 0.1f;
		float num2 = num * 0.5f;
		float t;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				t = 1f;
				num2 = 1f;
			}
			else
			{
				float num3 = animatorTime - 0.1f;
				t = num3 * 0.5f;
			}
		}
		else
		{
			t = 0f;
			num2 = 0f;
		}
		float num4 = animatorTime - 0.5f;
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
		float num5 = Easing.OutPower(num2, 20);
		float num6 = Easing.OutElastic(t);
		Transform transform = text.transform;
		float num7 = default(float);
		transform.localScale = (Vector3)(&num7);
		Transform transform2 = text.transform;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num7));
		transform2.localRotation = (Quaternion)(&num7);
		float num8 = Easing.OutPower(num4, 10);
		Transform transform3 = challengeBox.transform;
		transform3.localScale = (Vector3)(&num7);
		float num9 = MyTime.deltaTime * animatorSpeed;
		if ((animatorTime = num9 + animatorTime) > 1.5f)
		{
			animatorSpeed = -0.8f;
		}
		if (0f > animatorSpeed && 0.55f > animatorTime)
		{
			background.CrossFadeAlpha(0f, 0.3f, ignoreTimeScale: false);
		}
		if (0f > animatorTime)
		{
			animatorTime = 0f;
			content.SetActive(value: false);
			GameObject gameObject = particles.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private IEnumerator StartAnimate()
	{
		_003CStartAnimate_003Ed__24 obj = new _003CStartAnimate_003Ed__24(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
