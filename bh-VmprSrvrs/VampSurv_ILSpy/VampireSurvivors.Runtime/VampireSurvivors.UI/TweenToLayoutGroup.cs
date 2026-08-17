using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace VampireSurvivors.UI;

public class TweenToLayoutGroup : MonoBehaviour
{
	private sealed class _003CWaitAndDo_003Ed__14(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TweenToLayoutGroup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_03cb: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0066: Expected I4, but got I8
			//IL_0091: Expected O, but got I
			//IL_0052: Expected I4, but got I8
			//IL_00da: Expected O, but got I
			//IL_0535: Expected F4, but got I
			//IL_0569: Expected F4, but got I
			//IL_0569: Expected O, but got Ref
			//IL_0569: Expected O, but got I
			//IL_02d4: Expected O, but got I
			//IL_0378: Expected O, but got I
			//IL_038e: Expected O, but got I
			//IL_03a9: Expected O, but got I
			//IL_032f: Expected F4, but got I
			//IL_032f: Expected O, but got I
			//IL_019b: Expected O, but got I
			//IL_019b: Expected O, but got I
			//IL_01df: Expected O, but got I8
			//IL_028d: Expected F4, but got I
			//IL_0442->IL03ae: Incompatible stack heights: 1 vs 0
			//IL_00c5->IL03ae: Incompatible stack heights: 1 vs 0
			//IL_04dc->IL0493: Incompatible stack heights: 3 vs 1
			//IL_046c->IL03ae: Incompatible stack heights: 1 vs 0
			//IL_010e->IL03ae: Incompatible stack heights: 1 vs 0
			//IL_035d->IL03ae: Incompatible stack heights: 2 vs 0
			//IL_03ae->IL03ae: Incompatible stack heights: 2 vs 0
			//IL_048e->IL03ae: Incompatible stack heights: 1 vs 0
			//IL_0153->IL03ae: Incompatible stack heights: 1 vs 0
			//IL_01c0->IL021c: Incompatible stack heights: 2 vs 1
			//IL_0201->IL0201: Incompatible stack heights: 2 vs 0
			//IL_02b5->IL05a1: Incompatible stack heights: 2 vs 0
			Component component = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						_003C_003E1__state = -1;
						goto IL_0201;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					bool flag2 = (object)_003C_003E4__this == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+38]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+38]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v20+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+30]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+30]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rbx_v21+10]");
								if ((nint)0 != 0)
								{
									Transform transform = _003C_003E4__this.transform;
									if ((object)transform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+38]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+38]");
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+30]");
										((Transform)num).SetParent((Transform)0, worldPositionStays: true);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+48]");
										if ((nint)0 > (nint)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+48]");
											object obj4 = 0 & -2147483649L;
											if ((nint)obj4 > 2139095040)
											{
												goto IL_0201;
											}
											WaitForSeconds waitForSeconds = null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+48]");
											waitForSeconds.m_Seconds = 0f;
											_003C_003E2__current = waitForSeconds;
											_003C_003E1__state = 2;
											return true;
										}
										goto IL_021c;
									}
								}
							}
						}
					}
				}
				goto IL_03ae;
			}
			_003C_003E1__state = -1;
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			_003C_003E2__current = waitForEndOfFrame;
			_003C_003E1__state = 1;
			return true;
			IL_021c:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+74]");
			Vector3 value = default(Vector3);
			if ((nint)0 != 0)
			{
				Transform transform2 = _003C_003E4__this.transform;
				bool flag4 = (object)transform2 == null;
				bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
			}
			Transform transform3 = _003C_003E4__this.transform;
			bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
			Transform transform4 = _003C_003E4__this.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+4C]");
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform4, 1f, 0f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+38]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+4C]");
			object obj5 = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMove((Transform)num2, (Vector3)(&obj5), 0f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+40]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+40]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v17+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+40]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+4C]");
					TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTweenModuleUI.DOFade((CanvasGroup)num3, 1f, 0f);
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+75]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+60]");
				TweenExtensions.Complete((Tween)0, withCallbacks: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+50]");
				TweenExtensions.Complete((Tween)0, withCallbacks: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (UnityEngine.Component)+58]");
				TweenExtensions.Complete((Tween)0, withCallbacks: false);
			}
			goto IL_03ae;
			IL_0201:
			bool flag7 = (object)_003C_003E4__this == null;
			goto IL_021c;
			IL_03ae:
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

	private Vector3 originalPos;

	private RectTransform newTarget;

	private RectTransform mRectTransform;

	private CanvasGroup cg;

	private float _delay;

	private float _duration;

	private Tween _tween;

	private Tween _cgTween;

	private Tween _scaleTween;

	private Vector3 _from;

	private bool _isWorldPos;

	private bool _autoComplete;

	public unsafe void TweenFromLocationToLayoutSpot(Transform sender, Vector3 from, float duration, float delay, bool isWorldPos = false)
	{
		//IL_02fa: Expected O, but got F4
		//IL_025e->IL0336: Incompatible stack heights: 11 vs 0
		//IL_02d2->IL0336: Incompatible stack heights: 11 vs 0
		//IL_04ea->IL02eb: Incompatible stack heights: 13 vs 11
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			CanvasGroup component = gameObject.GetComponent<CanvasGroup>();
			cg = component;
			object obj = cg;
			if ((object)cg != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdi_v14 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					if ((object)cg == null)
					{
						goto IL_0336;
					}
					cg.alpha = 0f;
				}
			}
			GameObject gameObject2 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject2, (string)null);
			if ((object)gameObject2 != null)
			{
				Transform transform = gameObject2.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform transform2 = gameObject2.transform;
				Transform parent = base.transform;
				transform2.SetParent(parent, worldPositionStays: true);
				RectTransform rectTransform = gameObject2.AddComponent<RectTransform>();
				newTarget = rectTransform;
				object obj2 = newTarget;
				bool flag2 = (object)newTarget == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rdi_v17 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rdi_v17 (System.Object)+10]");
				Vector3 value2 = default(Vector3);
				Transform.set_localPosition_Injected((IntPtr)0, ref value2);
				bool flag4 = (object)newTarget == null;
				Transform transform3 = newTarget.transform;
				bool flag5 = (object)transform3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rax_v65 (UnityEngine.Transform)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rax_v65 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref value);
				bool flag7 = (object)newTarget == null;
				Transform transform4 = newTarget.transform;
				Transform transform5 = base.transform;
				bool flag8 = (object)transform5 == null;
				Transform parent2 = transform5.parent;
				bool flag9 = (object)transform4 == null;
				transform4.SetParent(parent2, worldPositionStays: true);
				Transform transform6 = base.transform;
				bool flag10 = (object)transform6 == null;
				transform6.SetParent(sender, worldPositionStays: true);
				RectTransform component2 = GetComponent<RectTransform>();
				mRectTransform = component2;
				bool flag11 = (object)mRectTransform == null;
				Vector2 sizeDelta = mRectTransform.sizeDelta;
				if ((object)newTarget != null)
				{
					newTarget.sizeDelta = sizeDelta;
					bool flag12 = default(bool);
					if (flag12)
					{
						Transform transform7 = base.transform;
						bool flag13 = (object)transform7 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v96 (UnityEngine.Transform)+10]");
						bool flag14 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v96 (UnityEngine.Transform)+10]");
						float value3 = default(float);
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value3));
					}
					else
					{
						if ((object)mRectTransform == null)
						{
							goto IL_0336;
						}
						Vector2 anchoredPosition = default(Vector2);
						mRectTransform.anchoredPosition = anchoredPosition;
					}
					_from = (Vector3)from.x;
					float delay2 = default(float);
					_delay = delay2;
					_duration = duration;
					_isWorldPos = flag12;
					_ = from.z;
					_003CWaitAndDo_003Ed__14 obj3 = null;
					obj3._003C_003E1__state = 0;
					obj3._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj3);
					return;
				}
			}
		}
		goto IL_0336;
		IL_0336:
		throw new NullReferenceException();
	}

	public void Complete()
	{
		if (_tween != null)
		{
			TweenExtensions.Complete(_tween, withCallbacks: false);
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Complete(_scaleTween, withCallbacks: false);
		}
		if (_cgTween != null)
		{
			TweenExtensions.Complete(_cgTween, withCallbacks: false);
		}
		_autoComplete = true;
	}

	private IEnumerator WaitAndDo()
	{
		_003CWaitAndDo_003Ed__14 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnDestroy()
	{
		if (_tween != null)
		{
			Tween tween = _tween;
			if (tween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(tween);
			}
		}
		if (_cgTween != null)
		{
			Tween cgTween = _cgTween;
			if (cgTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(cgTween);
			}
		}
		if (_scaleTween != null)
		{
			Tween scaleTween = _scaleTween;
			if (scaleTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(scaleTween);
			}
		}
		RectTransform rectTransform = newTarget;
		if ((object)newTarget != null && ((UnityEngine.Object)rectTransform).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = newTarget.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject obj = newTarget.gameObject;
				UnityEngine.Object.Destroy(obj, 0f);
			}
		}
	}

	public TweenToLayoutGroup()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
