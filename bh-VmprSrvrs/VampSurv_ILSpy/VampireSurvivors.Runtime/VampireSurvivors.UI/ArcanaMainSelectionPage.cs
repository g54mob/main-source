using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI;

public class ArcanaMainSelectionPage : BaseUIPage, ISetArcanaInfo
{
	public delegate void OnArcanaModeChange(ArcanaMode m);

	public enum ArcanaMode
	{
		LIGHT,
		DARK
	}

	public enum TentacleMode
	{
		TOP,
		ENCIRCLING
	}

	[StructLayout((LayoutKind)3)]
	private struct _003C_003CEnableInputFirstMenu_003Eb__115_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public ArcanaMainSelectionPage _003C_003E4__this;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0098: Expected O, but got I
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_00c5: Expected O, but got I
			//IL_0069: Expected O, but got I4
			//IL_0074: Expected O, but got Ref
			//IL_00f8: Expected O, but got I
			//IL_018c: Expected I4, but got I8
			//IL_0197: Expected O, but got Ref
			object CS_0024_003C_003E8__locals5 = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				_003C_003E1__state = -1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (System.Object)+A8]");
			if ((nint)0 != 0)
			{
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				YieldAwaitable.YieldAwaiter awaiter = default(YieldAwaitable.YieldAwaiter);
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (System.Object)+110]");
			Button component = ((GameObject)0).GetComponent<Button>();
			component.interactable = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (System.Object)+118]");
			Button component2 = ((GameObject)0).GetComponent<Button>();
			component2.interactable = true;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (System.Object)+1B8]");
			Transform transform = ((Component)0).transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, 1f, 0.2f);
			TweenCallback tweenCallback = delegate
			{
				Vector2 pivot = default(Vector2);
				VampireSurvivors.App.Tools.Extensions.SetPivot(((ArcanaMainSelectionPage)CS_0024_003C_003E8__locals5)._InfoGroup, pivot);
				Button component3 = ((ArcanaMainSelectionPage)CS_0024_003C_003E8__locals5)._DarkButton.GetComponent<Button>();
				component3.interactable = true;
				if (((ArcanaMainSelectionPage)CS_0024_003C_003E8__locals5)._willPlayDarkanaIntro)
				{
					((ArcanaMainSelectionPage)CS_0024_003C_003E8__locals5).SwitchArcanaMode();
					((ArcanaMainSelectionPage)CS_0024_003C_003E8__locals5)._willPlayDarkanaIntro = false;
				}
			};
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class _003C_003Ec__DisplayClass102_0
	{
		public ArcanaCardUI c;

		internal void _003CPopulateSecondMenu_003Eb__0()
		{
			Tween tween = c.Reveal();
		}
	}

	private sealed class _003C_003Ec__DisplayClass109_0
	{
		public GameObject v;

		internal void _003CPerformReRoll_003Eb__1()
		{
			UnityEngine.Object.Destroy(v, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass109_1
	{
		public ArcanaCardUI c;

		internal void _003CPerformReRoll_003Eb__2()
		{
			Tween tween = c.Reveal();
		}

		internal void _003CPerformReRoll_003Eb__3()
		{
			Selectable component = c.GetComponent<Selectable>();
			component.Select();
		}
	}

	private sealed class _003C_003Ec__DisplayClass114_0
	{
		public GameObject v;

		public ArcanaMainSelectionPage _003C_003E4__this;

		internal void _003CPopulateFirstMenu_003Eb__0()
		{
			//IL_01c4->IL0154: Incompatible stack heights: 1 vs 0
			//IL_0098->IL0154: Incompatible stack heights: 1 vs 0
			//IL_00b5->IL0154: Incompatible stack heights: 1 vs 0
			//IL_00eb->IL0154: Incompatible stack heights: 1 vs 0
			//IL_0117->IL0154: Incompatible stack heights: 1 vs 0
			if ((object)v != null)
			{
				Transform transform = v.transform;
				if ((object)transform != null)
				{
					Transform parent = transform.parent;
					if ((object)parent != null)
					{
						bool flag = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
						int siblingIndex_Injected = Transform.GetSiblingIndex_Injected(((UnityEngine.Object)parent).m_CachedPtr);
						if ((object)v != null)
						{
							Transform transform2 = v.transform;
							ArcanaMainSelectionPage arcanaMainSelectionPage = _003C_003E4__this;
							if ((object)_003C_003E4__this != null && (object)transform2 != null)
							{
								transform2.SetParent(arcanaMainSelectionPage._CardContainer, worldPositionStays: true);
								if ((object)v != null)
								{
									Transform transform3 = v.transform;
									if ((object)transform3 != null)
									{
										transform3.SetSiblingIndex(siblingIndex_Injected);
										GameObject gameObject = parent.gameObject;
										UnityEngine.Object.Destroy(gameObject, 0f);
										return;
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass114_1
	{
		public ArcanaCardUI card;

		internal void _003CPopulateFirstMenu_003Eb__1()
		{
			Tween tween = card.Reveal();
		}
	}

	private sealed class _003C_003Ec__DisplayClass124_0
	{
		public GameObject g;

		internal void _003CAddStrips_003Eb__0()
		{
			g.SetActive(value: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass124_1
	{
		public GameObject g;

		internal void _003CAddStrips_003Eb__1()
		{
			g.SetActive(value: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass141_0
	{
		public ArcanaMainSelectionPage _003C_003E4__this;

		public List<GameObject> cards;

		public List<ArcanaCardUI> unlocked;

		public Sequence s;

		public List<ArcanaCardUI> pickableCards;

		public int random;

		public Transform t;

		internal void _003CRandom_003Eb__0()
		{
			ArcanaMainSelectionPage arcanaMainSelectionPage = _003C_003E4__this;
			Button component = arcanaMainSelectionPage._CollectRandomButton.GetComponent<Button>();
			component.Select();
		}

		internal unsafe void _003CRandom_003Eb__1()
		{
			//IL_006c: Expected O, but got I4
			//IL_0076: Expected O, but got I4
			//IL_026a: Expected O, but got Ref
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			//IL_00f8->IL01ea: Incompatible stack heights: 1 vs 0
			//IL_012f->IL01ea: Incompatible stack heights: 1 vs 0
			//IL_01cf->IL01ea: Incompatible stack heights: 2 vs 0
			//IL_0174->IL01ea: Incompatible stack heights: 2 vs 0
			//IL_01e9->IL028b: Incompatible stack heights: 2 vs 0
			if (cards != null)
			{
				((List<object>)(object)cards).Reverse();
				if (unlocked != null)
				{
					((List<object>)(object)unlocked).Reverse();
					List<GameObject> list = cards;
					if (cards != null)
					{
						object obj = 0;
						object obj2 = 0;
						object obj3 = default(object);
						object obj4 = default(object);
						while (true)
						{
							if ((nint)obj2 >= list._size)
							{
								return;
							}
							List<GameObject> list2 = cards;
							Sequence sequence = s;
							if (cards == null)
							{
								break;
							}
							bool flag = (nint)obj >= list2._size;
							GameObject[] items = list2._items;
							if (list2._items == null)
							{
								break;
							}
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)(object)items[obj];
							if ((object)items[obj] == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbp_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbp_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
							IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
							Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj3), 0.2f);
							if (TweenSettingsExtensions.ValidateAddToSequence(s, (Tween)tweenerCore2, false))
							{
								if (s == null)
								{
									break;
								}
								Sequence sequence2 = Sequence.DoInsert(s, (Tween)tweenerCore2, sequence.lastTweenInsertTime);
							}
							list = cards;
							obj++;
							if (cards == null)
							{
								break;
							}
							obj3 = obj4;
							obj2 = obj;
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal unsafe void _003CRandom_003Eb__2()
		{
			//IL_047c: Expected O, but got Ref
			//IL_00a2: Expected O, but got I
			//IL_0247: Expected O, but got I
			//IL_05fc: Expected O, but got Ref
			//IL_02f4: Expected O, but got I
			//IL_0351: Expected O, but got I
			//IL_038e: Expected O, but got I
			//IL_05de: Expected O, but got Ref
			//IL_0232->IL03bd: Incompatible stack heights: 1 vs 0
			//IL_026c->IL03bd: Incompatible stack heights: 1 vs 0
			//IL_029f->IL03bd: Incompatible stack heights: 2 vs 0
			//IL_0555->IL03bd: Incompatible stack heights: 2 vs 0
			//IL_062e->IL03bd: Incompatible stack heights: 3 vs 0
			//IL_0311->IL03bd: Incompatible stack heights: 4 vs 0
			//IL_0336->IL03bd: Incompatible stack heights: 4 vs 0
			//IL_0379->IL03bd: Incompatible stack heights: 4 vs 0
			//IL_03ae->IL03bd: Incompatible stack heights: 4 vs 0
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F2D1]");
			bool flag = (nint)0 != 0;
			List<ArcanaCardUI> list = unlocked;
			bool flag2 = unlocked == null;
			Component component = (Component)(object)this;
			if (!flag2)
			{
				List<ArcanaCardUI> list2 = unlocked;
				List<ArcanaCardUI>.Enumerator enumerator = default(List<ArcanaCardUI>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = null;
					GameManager core = GM.Core;
					bool flag3 = (object)GM.Core == null;
					component = GM.Core;
					if (!flag3)
					{
						component = (Component)(object)core._arcanaManager;
						if (core._arcanaManager != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v25 (UnityEngine.Component)+B0]");
							component = (Component)0;
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				List<ArcanaCardUI> list3 = pickableCards;
				bool flag4 = pickableCards == null;
				component = (Component)(&enumerator);
				if (!flag4)
				{
					int num = (random = UnityEngine.Random.RandomRangeInt(0, list3._size));
					List<ArcanaCardUI> list4 = pickableCards;
					bool flag5 = pickableCards == null;
					component = null;
					if (!flag5)
					{
						bool flag6 = num >= list4._size;
						object items = list4._items;
						bool flag7 = list4._items == null;
						component = null;
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v19 (System.Object)+20+v149 @ rax_v46 (System.Int32)*8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v19 (System.Object)+20+v149 @ rax_v46 (System.Int32)*8]");
							bool flag8 = (nint)0 == 0;
							component = null;
							if (!flag8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdi_v20 (System.Object)+10]");
								bool flag9 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdi_v20 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								t = transform;
								component = t;
								if ((object)t != null)
								{
									RectTransform component2 = t.GetComponent<RectTransform>();
									bool flag10 = (object)component2 == null;
									component = (Component)(object)typeof(Vector2);
									if (!flag10)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1326 @ rax_v54 (UnityEngine.RectTransform)+10]");
										bool flag11 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1326 @ rax_v54 (UnityEngine.RectTransform)+10]");
										Vector2 value = default(Vector2);
										RectTransform.set_pivot_Injected((IntPtr)0, ref value);
										Vector3 ret = default(Vector3);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(t, (Vector3)(&ret), 0.2f);
										component = (Component)(object)pickableCards;
										int num2 = random;
										if (pickableCards != null)
										{
											int num3 = random;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v25 (UnityEngine.Component)+18]");
											bool flag12 = (nint)num3 >= (nint)0;
											component = (Component)(nint)((UnityEngine.Object)component).m_CachedPtr;
											if (((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v25 (UnityEngine.Component)+20+v152 @ rax_v65 (System.Int32)*8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v25 (UnityEngine.Component)+20+v152 @ rax_v65 (System.Int32)*8]");
													Tween tween = ((ArcanaCardUI)0).Reveal();
													Transform transform2 = (Transform)(object)_003C_003E4__this;
													if ((object)_003C_003E4__this != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v19 (UnityEngine.Transform)+138]");
														Transform transform3 = (Transform)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v19 (UnityEngine.Transform)+138]");
														if ((nint)0 != 0)
														{
															bool flag13 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
															Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
															TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOMove(t, (Vector3)(&list2), 0.2f);
															return;
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
			throw new NullReferenceException();
		}

		internal void _003CRandom_003Eb__3()
		{
			List<ArcanaCardUI> list = pickableCards;
			int num = random;
			if (random < list._size)
			{
				ArcanaCardUI[] items = list._items;
				ArcanaCardUI arcanaCardUI = items[num];
				int num2 = random;
				ArcanaCardUI[] items2 = list._items;
				int num3 = random;
				ArcanaCardUI arcanaCardUI2 = items2[num2];
				if (random < list._size)
				{
					ArcanaCardUI[] items3 = list._items;
					_003C_003E4__this.SetInfo(arcanaCardUI._data, arcanaCardUI2._type, items3[num3]);
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}

		internal void _003CRandom_003Eb__4()
		{
			ArcanaMainSelectionPage arcanaMainSelectionPage = _003C_003E4__this;
			Button component = arcanaMainSelectionPage._CollectRandomButton.GetComponent<Button>();
			component.enabled = true;
		}
	}

	private sealed class _003C_003Ec__DisplayClass141_1
	{
		public int cell;

		public _003C_003Ec__DisplayClass141_0 CS_0024_003C_003E8__locals1;

		internal void _003CRandom_003Eb__5(float value)
		{
			_003C_003Ec__DisplayClass141_0 obj = CS_0024_003C_003E8__locals1;
			List<GameObject> cards = obj.cards;
			int num = cell;
			if (cell < cards._size)
			{
				GameObject[] items = cards._items;
				RectTransform component = items[num].GetComponent<RectTransform>();
				Vector2 pivot = default(Vector2);
				component.pivot = pivot;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private sealed class _003CSpawnContent_003Ed__94(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ArcanaMainSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00e8: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.InitializeNormalArcanaParticles();
				_003C_003E4__this.InitializeTicklers();
				_003C_003E4__this.InitializeRingsOfCards();
				_003C_003E4__this.InitializeDarkanaParticles();
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
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitAndConfigureRandomButton_003Ed__117(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ArcanaMainSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00b7: Expected O, but got I
			//IL_00e1: Expected O, but got I4
			//IL_00eb: Expected O, but got I4
			//IL_00f4: Expected O, but got I4
			//IL_036e: Expected O, but got I
			//IL_012a: Expected O, but got I
			//IL_0239: Expected O, but got I
			//IL_043f: Expected O, but got I
			//IL_0224: Expected O, but got I
			//IL_01ea: Expected O, but got I
			//IL_01b2: Expected O, but got I
			//IL_046e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0473: Expected O, but got Unknown
			//IL_029a: Expected O, but got I
			//IL_02cd: Expected O, but got I
			//IL_0328: Expected O, but got I
			//IL_0358: Expected O, but got I4
			BaseUIPage baseUIPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (VampireSurvivors.UI.BaseUIPage)+F8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (VampireSurvivors.UI.BaseUIPage)+F8]");
						ArcanaCardUI[] componentsInChildren = ((Component)0).GetComponentsInChildren<ArcanaCardUI>();
						if (componentsInChildren != null)
						{
							object obj = 0;
							object obj2 = 0;
							object obj3 = 0;
							while (true)
							{
								if ((nint)obj3 < componentsInChildren.Length)
								{
									if ((nint)obj2 < componentsInChildren.Length)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (VampireSurvivors.UI.BaseUIPage)+2C8]");
										_003CWaitAndConfigureRandomButton_003Ed__117 obj4 = (_003CWaitAndConfigureRandomButton_003Ed__117)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (VampireSurvivors.UI.BaseUIPage)+2C8]");
										if ((nint)0 == 0)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rbx_v10 (VampireSurvivors.UI.ArcanaMainSelectionPage+<WaitAndConfigureRandomButton>d__117)+68]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rbx_v10 (VampireSurvivors.UI.ArcanaMainSelectionPage+<WaitAndConfigureRandomButton>d__117)+58]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rbx_v10 (VampireSurvivors.UI.ArcanaMainSelectionPage+<WaitAndConfigureRandomButton>d__117)+78]");
												object obj5;
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rbx_v10 (VampireSurvivors.UI.ArcanaMainSelectionPage+<WaitAndConfigureRandomButton>d__117)+78]");
													obj5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v26+2CC]");
													if ((nint)0 != 0)
													{
														goto IL_042f;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rbx_v10 (VampireSurvivors.UI.ArcanaMainSelectionPage+<WaitAndConfigureRandomButton>d__117)+50]");
												obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rbx_v10 (VampireSurvivors.UI.ArcanaMainSelectionPage+<WaitAndConfigureRandomButton>d__117)+50]");
												if ((nint)0 == 0)
												{
													break;
												}
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rbx_v10 (VampireSurvivors.UI.ArcanaMainSelectionPage+<WaitAndConfigureRandomButton>d__117)+58]");
												object obj5 = 0;
											}
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rbx_v10 (VampireSurvivors.UI.ArcanaMainSelectionPage+<WaitAndConfigureRandomButton>d__117)+68]");
											object obj5 = 0;
										}
										goto IL_042f;
									}
									throw new IndexOutOfRangeException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (VampireSurvivors.UI.BaseUIPage)+110]");
								_003CWaitAndConfigureRandomButton_003Ed__117 obj6 = (_003CWaitAndConfigureRandomButton_003Ed__117)0;
								bool value;
								if (obj == null)
								{
									value = false;
								}
								else
								{
									bool flag = _003C_003E4__this.IsLocalPlayerControllingUi();
									value = flag;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (VampireSurvivors.UI.BaseUIPage)+110]");
								if ((nint)0 == 0)
								{
									break;
								}
								bool flag2 = obj6._003C_003E1__state == 0;
								GameObject.SetActive_Injected((IntPtr)obj6._003C_003E1__state, value);
								return false;
								IL_042f:
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v26+1B8]");
								object obj7 = 0;
								if ((object)componentsInChildren[obj2] == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v26+1B8]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rcx_v20+18]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rcx_v20+10]");
									ArcanaCardUI[] componentsInChildren2 = ((Component)0).GetComponentsInChildren<ArcanaCardUI>();
									if ((nint)componentsInChildren2 != -1)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (VampireSurvivors.UI.BaseUIPage)+2D8]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (VampireSurvivors.UI.BaseUIPage)+2D8]");
										if ((nint)0 == 0)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v33+B0]");
										if ((nint)0 == 0)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v33+B0]");
										ArcanaCardUI[] componentsInChildren3 = ((Component)0).GetComponentsInChildren<ArcanaCardUI>();
										if (componentsInChildren3 == null)
										{
											obj = 1;
										}
									}
								}
								obj2++;
								obj3 = obj2;
							}
						}
					}
				}
				throw new NullReferenceException();
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
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitAndForceSelect_003Ed__119(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameObject cardToSelect;

		public ArcanaMainSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_023e: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 0.01f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)cardToSelect != null)
				{
					ArcanaCardUI component = cardToSelect.GetComponent<ArcanaCardUI>();
					if ((object)component != null)
					{
						component.OnClick();
						if ((object)cardToSelect != null)
						{
							Selectable component2 = cardToSelect.GetComponent<Selectable>();
							if ((object)component2 != null)
							{
								component2.Select();
								if ((object)cardToSelect != null)
								{
									ArcanaCardUI component3 = cardToSelect.GetComponent<ArcanaCardUI>();
									if ((object)component3 != null && (object)cardToSelect != null)
									{
										ArcanaCardUI component4 = cardToSelect.GetComponent<ArcanaCardUI>();
										if ((object)component4 != null && (object)cardToSelect != null)
										{
											ArcanaCardUI component5 = cardToSelect.GetComponent<ArcanaCardUI>();
											if ((object)_003C_003E4__this != null)
											{
												_003C_003E4__this.SetInfo(component3._data, component4._type, component5);
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
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitAndSelect_003Ed__118(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ArcanaMainSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_05e5: Expected I4, but got O
			//IL_0197: Expected I4, but got I8
			//IL_01a4: Expected I4, but got I8
			ArcanaMainSelectionPage arcanaMainSelectionPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 0.5f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)arcanaMainSelectionPage._CardContainer != null)
				{
					GameObject gameObject = arcanaMainSelectionPage._CardContainer.gameObject;
					if ((object)gameObject != null)
					{
						ArcanaCardUI[] componentsInChildren = gameObject.GetComponentsInChildren<ArcanaCardUI>(includeInactive: true);
						if ((object)arcanaMainSelectionPage._CardContainer != null)
						{
							Transform transform = arcanaMainSelectionPage._CardContainer.transform;
							if ((object)transform != null)
							{
								int childCount = transform.childCount;
								int num = 0;
								int num2 = 0;
								while (true)
								{
									List<GameObject> allSpawnedInOrder = arcanaMainSelectionPage._allSpawnedInOrder;
									if (arcanaMainSelectionPage._allSpawnedInOrder == null)
									{
										break;
									}
									bool flag = num >= allSpawnedInOrder._size;
									int num3 = -1;
									int num4 = -1;
									if (!flag)
									{
										if (num2 >= allSpawnedInOrder._size)
										{
											goto IL_0607;
										}
										GameObject[] items = allSpawnedInOrder._items;
										if (allSpawnedInOrder._items == null || (object)items[num2] == null)
										{
											break;
										}
										ArcanaCardUI component = items[num2].GetComponent<ArcanaCardUI>();
										if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0 || component._data == null)
										{
											goto IL_02cb;
										}
										ArcanaData data = component._data;
										if (!data._003Cunlocked_003Ek__BackingField)
										{
											goto IL_02cb;
										}
										num3 = num2;
										num4 = num2;
									}
									if (arcanaMainSelectionPage._lastSelected != 0)
									{
										num4 = arcanaMainSelectionPage._lastSelected;
										num3 = arcanaMainSelectionPage._lastSelected;
									}
									string text = num3.ToString();
									string message = "First unlocked : " + text;
									Debug.Log(message);
									List<GameObject> allSpawnedInOrder2 = arcanaMainSelectionPage._allSpawnedInOrder;
									if (arcanaMainSelectionPage._allSpawnedInOrder == null)
									{
										break;
									}
									if (num4 < allSpawnedInOrder2._size)
									{
										GameObject[] items2 = allSpawnedInOrder2._items;
										if (allSpawnedInOrder2._items == null)
										{
											break;
										}
										if (num4 >= 0)
										{
											if (componentsInChildren == null)
											{
												break;
											}
											if (num4 < componentsInChildren.Length)
											{
												if ((object)items2[num4] == null)
												{
													break;
												}
												ArcanaCardUI component2 = items2[num4].GetComponent<ArcanaCardUI>();
												if ((object)component2 == null)
												{
													break;
												}
												component2.OnClick();
												Selectable component3 = items2[num4].GetComponent<Selectable>();
												if ((object)component3 == null)
												{
													break;
												}
												component3.Select();
												ArcanaCardUI component4 = items2[num4].GetComponent<ArcanaCardUI>();
												if ((object)component4 == null)
												{
													break;
												}
												ArcanaCardUI component5 = items2[num4].GetComponent<ArcanaCardUI>();
												if ((object)component5 == null)
												{
													break;
												}
												ArcanaCardUI component6 = items2[num4].GetComponent<ArcanaCardUI>();
												_003C_003E4__this.SetInfo(component4._data, component5._type, component6);
											}
										}
										if ((object)arcanaMainSelectionPage._GetButton == null)
										{
											break;
										}
										Selectable component7 = arcanaMainSelectionPage._GetButton.GetComponent<Selectable>();
										if ((object)component7 == null)
										{
											break;
										}
										component7.Select();
										return false;
									}
									goto IL_0607;
									IL_0607:
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									break;
									IL_02cb:
									num2++;
									num = num2;
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
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private ArcanaInfoPanel _ArcanaInfoPanel;

	private Localize _Count;

	private RectTransform _TitleGroup;

	private RectTransform _CardContainer;

	private RectTransform _MinorCardContainer;

	private GameObject _ArcanaCardPrefab;

	private GameObject _RandomButton;

	private GameObject _GetButton;

	private ParticleEmitterManager _TopParticles;

	private ParticleEmitterManager _BottomParticles;

	private RectTransform _CardOrigin;

	private RectTransform _SelectedCardOrigin;

	private Image _BlackFader;

	private Image _CollectRandomButton;

	private GameObject _MajorSelectionGroup;

	private GameObject _MinorSelectionGroup;

	private GameObject _BigArcanaCard;

	private RectTransform _StripContainer;

	private RectTransform _MinorGetButton;

	private RectTransform _SkipButton;

	private RectTransform _RerollButton;

	private TextMeshProUGUI _RerollCountText;

	private TextMeshProUGUI _SkipCountText;

	private PauseEquipmentPanel _EquipmentPanel;

	private GameObject _CharacterStatsPanel;

	private bool _DEBUGPAGE2;

	private RectTransform _RerollAnimContainer;

	private RectTransform _InfoGroup;

	private RectTransform _MinorBackground;

	private RectTransform _MajorBackground;

	private RectTransform _TitleBackground;

	private RectTransform _CharacterPanelBackground;

	private GameObject _CharacterPanel;

	private Image _CharacterImage;

	private List<SpinningRingOfCards> _CardRings;

	private int _MaxWeaponsBeforeCarousel;

	private ArcanaDisplayContainer _DisplayContainer;

	private GameObject _TentaclePrefab;

	private RectTransform _TentacleSpawnRotator;

	private RectTransform _TentacleSpawnAnchor;

	private TextMeshProUGUI _TitleText;

	private GameObject _TitleBloodMask;

	private GameObject _PanelBloodMask;

	private GameObject _InfoBloodMask;

	private GameObject _MinorBloodMask;

	private GameObject _CharacterPanelBloodMask;

	private RectTransform _D20;

	private ParticleEmitterManager _TopDarkanaParticles;

	private ParticleEmitterManager _BottomDarkanaParticles;

	private RectTransform _Skull;

	private GameObject _DarkButton;

	private Image _DarkButtonIcon;

	private Image _TitleIcon;

	private static OnArcanaModeChange m_ArcanaModeChanged;

	private List<GameObject> _darkSpawned;

	private List<GameObject> _spawned;

	private List<GameObject> _weaponSpawned;

	private List<ArcanaCardUI> _unlockedCards;

	private List<ArcanaCardUI> _darkUnlockedCards;

	private List<GameObject> _tentacles;

	private List<GameObject> _allSpawnedInOrder;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private ArcanaManager _arcanaManager;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private Dictionary<ItemType, ItemData> _items;

	private ArcanaType _currentSelected;

	private string _arcanaCacheGroupName;

	private Material _defaultGameRenderMaterial;

	private bool _hasUnlockedDarkanas;

	private int _draftCardCount;

	private Tween _d20Tween;

	private Selectable previouslyHighlightedDraftCard;

	private List<ArcanaType> _draftMajors;

	private List<ArcanaType> _discarded;

	private int _lastSelected;

	private ArcanaCardUI _selected;

	private bool _hasPickedRandom;

	private bool _hasFreeReroll;

	private VampireSurvivors.Objects.Characters.CharacterController _controllingCharacter;

	private bool isShowingMinor;

	private bool _hasFinishedPopulationAnimation;

	private bool _ShowDarkanaFirst;

	private bool _willPlayDarkanaIntro;

	private ArcanaMode _arcanaMode;

	public TentacleMode _tentacleMode;

	public static event OnArcanaModeChange ArcanaModeChanged
	{
		add
		{
			Delegate obj = ArcanaMainSelectionPage.m_ArcanaModeChanged;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnArcanaModeChange);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				bool flag3 = (object)obj == ArcanaMainSelectionPage.m_ArcanaModeChanged;
				Delegate obj4;
				if ((object)obj == ArcanaMainSelectionPage.m_ArcanaModeChanged)
				{
					ArcanaMainSelectionPage.m_ArcanaModeChanged = (OnArcanaModeChange)obj3;
					obj4 = obj;
				}
				else
				{
					obj4 = ArcanaMainSelectionPage.m_ArcanaModeChanged;
				}
				Delegate obj5 = obj;
				if (!flag3)
				{
					obj5 = obj4;
				}
				bool flag4 = (object)obj5 != obj;
				obj = obj5;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			Delegate obj = ArcanaMainSelectionPage.m_ArcanaModeChanged;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnArcanaModeChange);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				bool flag3 = (object)obj == ArcanaMainSelectionPage.m_ArcanaModeChanged;
				Delegate obj4;
				if ((object)obj == ArcanaMainSelectionPage.m_ArcanaModeChanged)
				{
					ArcanaMainSelectionPage.m_ArcanaModeChanged = (OnArcanaModeChange)obj3;
					obj4 = obj;
				}
				else
				{
					obj4 = ArcanaMainSelectionPage.m_ArcanaModeChanged;
				}
				Delegate obj5 = obj;
				if (!flag3)
				{
					obj5 = obj4;
				}
				bool flag4 = (object)obj5 != obj;
				obj = obj5;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private void Construct(DataManager data, PlayerOptions player, ArcanaManager arcana, SignalBus signalBus)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0260: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_029b: Expected O, but got I
		//IL_01f1: Expected O, but got I4
		//IL_01f1: Expected O, but got I
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_02d6: Expected O, but got I
		_data = data;
		PlayerOptions playerOptions = default(PlayerOptions);
		_playerOptions = playerOptions;
		_arcanaManager = arcana;
		SignalBus signalBus2 = default(SignalBus);
		_signalBus = signalBus2;
		Action<OnlineSignals.OnlineSelectedArcana> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97630");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineSelectedArcana>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineSelectedArcana>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v17 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus3.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = OnReRolledArcanasRemotely;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineReRolledArcanas>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineReRolledArcanas>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus4 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v32 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus4.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action action5 = OnTransitionArcanaModeRemotely;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj7 = null;
		Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.ArcanaModeTransition>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.ArcanaModeTransition>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus5 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rax_v47 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus5.SubscribeInternal(signalType3, (object)null, (object)0, (Action<object>)(object)signalBus);
	}

	protected override void Awake()
	{
		base.Awake();
		_AutoSizeAfterParse = true;
		_003CSpawnContent_003Ed__94 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(obj);
	}

	public IEnumerator SpawnContent()
	{
		_003CSpawnContent_003Ed__94 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		Action<OnlineSignals.OnlineSelectedArcana> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97630");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = OnReRolledArcanasRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action token3 = OnTransitionArcanaModeRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_0264: Expected O, but got I
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		base.OnShowStart(g);
		if ((object)_DarkButton != null)
		{
			Button component = _DarkButton.GetComponent<Button>();
			if ((object)component != null)
			{
				component.interactable = false;
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v14 (VampireSurvivors.Data.PlayerOptionsData)+188]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v14 (VampireSurvivors.Data.PlayerOptionsData)+188]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v14+18]");
							bool hasUnlockedDarkanas;
							if ((nint)0 == 0)
							{
								hasUnlockedDarkanas = false;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								object obj3 = default(object);
								object obj2 = obj3 - -1;
								bool flag = obj2 == null;
								hasUnlockedDarkanas = !flag;
							}
							_hasUnlockedDarkanas = hasUnlockedDarkanas;
							GetControllingCharacter();
							EnterMultiplayerControl(_controllingCharacter, 1000f);
							if ((object)GM.Core != null)
							{
								_ = _controllingCharacter;
								ArcanaInfoPanel arcanaInfoPanel = _ArcanaInfoPanel;
								if ((object)_ArcanaInfoPanel != null)
								{
									arcanaInfoPanel._controllingCharacter = _controllingCharacter;
									if ((object)_ArcanaInfoPanel != null)
									{
										_ArcanaInfoPanel.Initialize();
										Vector2 pivot = default(Vector2);
										VampireSurvivors.App.Tools.Extensions.SetPivot(_InfoGroup, pivot);
										if ((object)_InfoGroup != null)
										{
											Transform transform = _InfoGroup.transform;
											bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											Vector3 value = default(Vector3);
											Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
											GameObject gameObject = _CollectRandomButton.gameObject;
											gameObject.SetActive(value: false);
											ClearSpawned();
											TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_BlackFader, 0.5f, 1f);
											GameManager core = GM.Core;
											if (core._003CArcanaUiType_003Ek__BackingField != ArcanaUiType.MAIN)
											{
												PopulateSecondMenu();
											}
											else
											{
												PopulateFirstMenu();
											}
											return;
										}
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

	private unsafe void GetControllingCharacter()
	{
		//IL_04c8: Expected O, but got I
		//IL_0507: Expected O, but got I
		//IL_06cd: Expected O, but got Ref
		//IL_098c: Expected O, but got Ref
		//IL_0896: Expected I, but got O
		//IL_096e->IL0790: Incompatible stack heights: 5 vs 0
		//IL_0861->IL0790: Incompatible stack heights: 1 vs 0
		//IL_06bb->IL0790: Incompatible stack heights: 5 vs 0
		//IL_0527->IL0790: Incompatible stack heights: 1 vs 0
		//IL_09aa->IL0790: Incompatible stack heights: 5 vs 0
		//IL_08af->IL0790: Incompatible stack heights: 2 vs 0
		//IL_055d->IL0790: Incompatible stack heights: 2 vs 0
		//IL_0577->IL0577: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController controllingCharacter;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			int playerCount = core._multiplayer.GetPlayerCount();
			if (playerCount <= 1 && !core._multiplayer.IsOnlineMultiplayer)
			{
				if ((object)_CharacterPanel != null)
				{
					_CharacterPanel.SetActive(value: false);
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						GameSessionData gameSessionData = core2._gameSessionData;
						if (core2._gameSessionData != null)
						{
							_controllingCharacter = gameSessionData._activeCharacter;
							goto IL_0577;
						}
					}
				}
			}
			else if ((object)GM.Core != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterControllerFromType = GM.Core.GetCharacterControllerFromType(CharacterType.SIGMA);
				if ((object)characterControllerFromType != null && ((UnityEngine.Object)characterControllerFromType).m_CachedPtr != (IntPtr)0)
				{
					_controllingCharacter = characterControllerFromType;
					goto IL_02d5;
				}
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					if (core3._003CArcanaUiType_003Ek__BackingField == ArcanaUiType.DRAFT)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = core3._003CChestWinnerPlayer_003Ek__BackingField;
						if ((object)core3._003CChestWinnerPlayer_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
						{
							GameManager core4 = GM.Core;
							if ((object)GM.Core != null)
							{
								controllingCharacter = core4._003CChestWinnerPlayer_003Ek__BackingField;
								goto IL_027e;
							}
							goto IL_0790;
						}
					}
					if ((object)GM.Core != null)
					{
						controllingCharacter = GM.Core.PlayerOne;
						goto IL_027e;
					}
				}
			}
		}
		goto IL_0790;
		IL_02d5:
		GameManager core5 = GM.Core;
		Vector3 value = default(Vector3);
		float ret;
		Vector2 vector = default(Vector2);
		if ((object)GM.Core != null && core5._multiplayer != null)
		{
			int localPlayerCount = core5._multiplayer.GetLocalPlayerCount();
			if (localPlayerCount > 1)
			{
				VampireSurvivors.Objects.Characters.CharacterController controllingCharacter2 = _controllingCharacter;
				if ((object)_controllingCharacter == null || Multiplayer == null)
				{
					goto IL_0790;
				}
				float vibrationMS = default(float);
				Multiplayer.SelectPlayerToControlUI(controllingCharacter2._player, exclusiveUIControl: true, vibrate: true, vibrationMS);
			}
			VampireSurvivors.Objects.Characters.CharacterController controllingCharacter3 = _controllingCharacter;
			if ((object)_controllingCharacter != null)
			{
				CharacterData currentSkinData = controllingCharacter3._currentSkinData;
				if (controllingCharacter3._currentSkinData != null)
				{
					Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField);
					if ((object)_CharacterImage != null)
					{
						_CharacterImage.sprite = sprite;
						if ((object)_CharacterImage != null)
						{
							RectTransform rectTransform = _CharacterImage.rectTransform;
							MultiplayerManager characterImage = (MultiplayerManager)(object)_CharacterImage;
							if ((object)_CharacterImage != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdi_v25 (VampireSurvivors.Framework.MultiplayerManager)+E0]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdi_v25 (VampireSurvivors.Framework.MultiplayerManager)+E0]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdi_v26 (System.Object)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdi_v26 (System.Object)+10]");
									Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&value));
									MultiplayerManager characterImage2 = (MultiplayerManager)(object)_CharacterImage;
									if ((object)_CharacterImage != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdi_v27 (VampireSurvivors.Framework.MultiplayerManager)+E0]");
										MultiplayerManager multiplayerManager = (MultiplayerManager)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdi_v27 (VampireSurvivors.Framework.MultiplayerManager)+E0]");
										if ((nint)0 != 0)
										{
											bool flag2 = multiplayerManager._playerOptions == null;
											Sprite.get_rect_Injected((IntPtr)multiplayerManager._playerOptions, out *(Rect*)(&ret));
											if ((object)rectTransform != null)
											{
												rectTransform.sizeDelta = vector;
												if ((object)_CharacterPanel != null)
												{
													_CharacterPanel.SetActive(value: true);
													goto IL_0577;
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
		goto IL_0790;
		IL_027e:
		if ((object)this != null)
		{
			_controllingCharacter = controllingCharacter;
			if ((object)GM.Core != null)
			{
				GM.Core.ChestWinnerPlayer = null;
				goto IL_02d5;
			}
		}
		goto IL_0790;
		IL_0577:
		GameManager core6 = GM.Core;
		if ((object)GM.Core != null)
		{
			_ = _controllingCharacter;
			ArcanaInfoPanel arcanaInfoPanel = _ArcanaInfoPanel;
			if ((object)_ArcanaInfoPanel != null)
			{
				arcanaInfoPanel._controllingCharacter = _controllingCharacter;
				if ((object)_ArcanaInfoPanel != null)
				{
					_ArcanaInfoPanel.Initialize();
					VampireSurvivors.App.Tools.Extensions.SetPivot(_InfoGroup, vector);
					if ((object)_InfoGroup != null)
					{
						Transform transform = _InfoGroup.transform;
						bool flag3 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1565 @ rax_v43 (UnityEngine.Transform)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1565 @ rax_v43 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						bool flag5 = (object)_TitleBackground == null;
						Transform transform2 = _TitleBackground.transform;
						bool flag6 = (object)transform2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1766 @ rax_v51 (UnityEngine.Transform)+10]");
						bool flag7 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1766 @ rax_v51 (UnityEngine.Transform)+10]");
						Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)(&ret));
						if ((object)_TitleBackground != null)
						{
							Transform transform3 = _TitleBackground.transform;
							if ((object)transform3 != null)
							{
								transform3.localEulerAngles = (Vector3)(&value);
								Vector2 vector2 = default(Vector2);
								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_TitleBackground, (Vector3)(&vector2), 0.2f);
								if ((object)_TitleBackground != null)
								{
									Transform transform4 = _TitleBackground.transform;
									bool flag8 = (object)transform4 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v64 (UnityEngine.Transform)+10]");
									bool flag9 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v64 (UnityEngine.Transform)+10]");
									Transform.set_localScale_Injected((IntPtr)0, ref value);
									bool flag10 = (object)_TitleBackground == null;
									Transform target = _TitleBackground.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, ret, 0.2f);
									bool flag11 = (object)_CollectRandomButton == null;
									GameObject gameObject = _CollectRandomButton.gameObject;
									bool flag12 = (object)gameObject == null;
									gameObject.SetActive(value: false);
									ClearSpawned();
									TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_BlackFader, 0.5f, 1f);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0790;
		IL_0790:
		throw new NullReferenceException();
	}

	protected override void OnShowFinish(GameObject g)
	{
		base.OnShowFinish(g);
		GridLayoutGroup component = _MinorCardContainer.GetComponent<GridLayoutGroup>();
		component.enabled = true;
	}

	private void InitializeRingsOfCards()
	{
		List<SpinningRingOfCards>.Enumerator enumerator = default(List<SpinningRingOfCards>.Enumerator);
		if (enumerator.MoveNext())
		{
			SpinningRingOfCards spinningRingOfCards = null;
			throw new NullReferenceException();
		}
	}

	protected unsafe override void Update()
	{
		//IL_0517: Expected O, but got I4
		//IL_0531: Expected O, but got I4
		//IL_058c: Expected O, but got I4
		//IL_05a6: Expected O, but got I4
		//IL_03e4: Expected O, but got Ref
		//IL_0611: Expected O, but got I4
		//IL_0629->IL04bd: Incompatible stack heights: 1 vs 0
		//IL_0468->IL0491: Incompatible stack heights: 1 vs 0
		//IL_0491->IL04bd: Incompatible stack heights: 1 vs 0
		base.Update();
		if (!isShowingMinor)
		{
			return;
		}
		EventSystem current = EventSystem.current;
		if ((object)current != null)
		{
			GameObject currentSelected = current.m_CurrentSelected;
			if ((object)current.m_CurrentSelected == null || ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			EventSystem current2 = EventSystem.current;
			if ((object)current2 != null && (object)current2.m_CurrentSelected != null)
			{
				ArcanaCardUI component = current2.m_CurrentSelected.GetComponent<ArcanaCardUI>();
				if (!component)
				{
					return;
				}
				EventSystem current3 = EventSystem.current;
				if ((object)current3 != null && (object)current3.m_CurrentSelected != null)
				{
					Transform transform = current3.m_CurrentSelected.transform;
					if ((object)transform != null)
					{
						Transform parent = transform.parent;
						RectTransform minorCardContainer = _MinorCardContainer;
						bool flag = (object)_MinorCardContainer == null;
						bool flag2 = (object)parent == null;
						object obj = flag2 & flag;
						bool flag3 = obj == null;
						object obj2 = !flag3;
						if (obj2 == null)
						{
							bool flag4;
							if ((object)_MinorCardContainer != null)
							{
								if ((object)parent != null)
								{
									object obj3 = (object)parent - (object)_MinorCardContainer;
									flag4 = obj3 == null;
								}
								else
								{
									flag4 = ((UnityEngine.Object)minorCardContainer).m_CachedPtr == (IntPtr)0;
								}
							}
							else
							{
								if ((object)parent == null)
								{
									goto IL_0491;
								}
								flag4 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
							}
							if (!flag4)
							{
								return;
							}
						}
						GameObject gameObject = (GameObject)(object)previouslyHighlightedDraftCard;
						EventSystem current4 = EventSystem.current;
						if ((object)current4 != null && (object)current4.m_CurrentSelected != null)
						{
							Selectable component2 = current4.m_CurrentSelected.GetComponent<Selectable>();
							previouslyHighlightedDraftCard = component2;
							Selectable selectable = previouslyHighlightedDraftCard;
							bool flag5 = (object)previouslyHighlightedDraftCard == null;
							bool flag6 = (object)previouslyHighlightedDraftCard == null;
							object obj4 = flag6 & flag5;
							bool flag7 = obj4 == null;
							object obj5 = !flag7;
							if (obj5 != null)
							{
								return;
							}
							bool flag8;
							if ((object)previouslyHighlightedDraftCard != null)
							{
								if ((object)previouslyHighlightedDraftCard != null)
								{
									object obj6 = (object)previouslyHighlightedDraftCard - (object)previouslyHighlightedDraftCard;
									flag8 = obj6 == null;
								}
								else
								{
									flag8 = ((UnityEngine.Object)selectable).m_CachedPtr == (IntPtr)0;
								}
							}
							else
							{
								if ((object)previouslyHighlightedDraftCard == null)
								{
									goto IL_0491;
								}
								flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							}
							if (flag8)
							{
								return;
							}
							if ((object)_MinorGetButton != null)
							{
								Selectable component3 = _MinorGetButton.GetComponent<Selectable>();
								if ((object)component3 != null)
								{
									object obj7 = default(object);
									component3.navigation = (Navigation)(&obj7);
									SetNavigationUp(component3, previouslyHighlightedDraftCard);
									if ((object)_RerollButton != null)
									{
										GameObject gameObject2 = _RerollButton.gameObject;
										if ((object)gameObject2 != null)
										{
											bool flag9 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
											object obj8 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
											if (obj8 == null)
											{
												return;
											}
											if ((object)_RerollButton != null)
											{
												Selectable component4 = _RerollButton.GetComponent<Selectable>();
												SetNavigationUp(component4, previouslyHighlightedDraftCard);
												return;
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
		goto IL_0491;
		IL_0491:
		throw new NullReferenceException();
	}

	private unsafe void SetMinorGetNavigation()
	{
		//IL_003e: Expected O, but got Ref
		//IL_0142: Expected O, but got I4
		//IL_00c2->IL00ec: Incompatible stack heights: 1 vs 0
		if ((object)_MinorGetButton != null)
		{
			Selectable component = _MinorGetButton.GetComponent<Selectable>();
			if ((object)component != null)
			{
				object obj = default(object);
				component.navigation = (Navigation)(&obj);
				SetNavigationUp(component, previouslyHighlightedDraftCard);
				if ((object)_RerollButton != null)
				{
					GameObject gameObject = _RerollButton.gameObject;
					if ((object)gameObject != null)
					{
						bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj2 == null)
						{
							return;
						}
						if ((object)_RerollButton != null)
						{
							Selectable component2 = _RerollButton.GetComponent<Selectable>();
							SetNavigationUp(component2, previouslyHighlightedDraftCard);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void PopulateSecondMenu()
	{
		//IL_01cc: Expected O, but got I
		//IL_197f: Expected I, but got O
		//IL_19b0: Expected O, but got I
		//IL_029f: Expected O, but got I
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_04ac: Expected I, but got O
		//IL_04dd: Expected O, but got I
		//IL_0514: Expected O, but got I
		//IL_0564: Expected O, but got I4
		//IL_1a3e: Expected O, but got I
		//IL_041c: Expected O, but got I
		//IL_1aa5: Expected O, but got I
		//IL_0626: Expected O, but got I4
		//IL_1b07: Expected O, but got I
		//IL_1b6e: Expected O, but got I
		//IL_06c4: Expected O, but got I4
		//IL_1bd0: Expected O, but got I
		//IL_07e1: Expected O, but got Ref
		//IL_1bf7: Expected O, but got Ref
		//IL_08dc: Expected O, but got I
		//IL_08f1: Expected O, but got I
		//IL_08c7: Expected O, but got I
		//IL_08b2: Expected O, but got I
		//IL_087a: Expected O, but got I
		//IL_0a4e: Expected I4, but got I8
		//IL_0e05: Expected O, but got I
		//IL_0b76: Expected O, but got I
		//IL_0df0: Expected O, but got I
		//IL_0e1a: Expected O, but got I
		//IL_0ddb: Expected O, but got I
		//IL_0da3: Expected O, but got I
		//IL_0c41: Expected O, but got I
		//IL_0f45: Expected O, but got I8
		//IL_200f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2014: Expected O, but got Unknown
		//IL_20ab: Expected O, but got Ref
		//IL_20b9: Expected F4, but got I4
		//IL_20c1: Expected O, but got Ref
		//IL_1113: Expected I4, but got I8
		//IL_112b: Expected O, but got I4
		//IL_1138: Expected O, but got I8
		//IL_140c: Expected O, but got I
		//IL_131d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1322: Expected O, but got Unknown
		//IL_142b: Expected O, but got I
		//IL_144e: Expected O, but got I
		//IL_11b1: Expected O, but got I4
		//IL_11be: Expected O, but got I8
		//IL_12c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c5: Expected O, but got Unknown
		//IL_20d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_20dd: Expected O, but got Unknown
		//IL_12ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f3: Expected O, but got Unknown
		//IL_12fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1301: Expected O, but got Unknown
		//IL_130a: Unknown result type (might be due to invalid IL or missing references)
		//IL_130f: Expected O, but got Unknown
		//IL_1661: Expected O, but got I
		//IL_1680: Expected O, but got I
		//IL_16a3: Expected O, but got I
		//IL_16dc: Expected O, but got I
		//IL_1794: Expected O, but got I
		//IL_1a47->IL17d0: Incompatible stack heights: 1 vs 0
		//IL_1aae->IL17d0: Incompatible stack heights: 2 vs 0
		//IL_1b10->IL17d0: Incompatible stack heights: 3 vs 0
		//IL_1b77->IL17d0: Incompatible stack heights: 4 vs 0
		//IL_1bd9->IL17d0: Incompatible stack heights: 5 vs 0
		//IL_1c29->IL17d0: Incompatible stack heights: 5 vs 0
		//IL_09ba->IL17d0: Incompatible stack heights: 17 vs 0
		//IL_095b->IL17d0: Incompatible stack heights: 17 vs 0
		//IL_1f5c->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_1ebc->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_09fa->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_0991->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_0a72->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_0aaa->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_0ae2->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_0ce9->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0aff->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_0d32->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0b3d->IL17d0: Incompatible stack heights: 18 vs 0
		//IL_0b9e->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_2001->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0e3a->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0bf3->IL17d0: Incompatible stack heights: 20 vs 0
		//IL_0c18->IL17d0: Incompatible stack heights: 20 vs 0
		//IL_0f07->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0e96->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0c65->IL17d0: Incompatible stack heights: 20 vs 0
		//IL_0f2e->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0ec2->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0c91->IL17d0: Incompatible stack heights: 20 vs 0
		//IL_1fbc->IL17d0: Incompatible stack heights: 21 vs 0
		//IL_136c->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_2147->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_0cc5->IL0cc5: Incompatible stack heights: 21 vs 19
		//IL_13bc->IL17d0: Incompatible stack heights: 20 vs 0
		//IL_11f8->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_106c->IL2069: Incompatible stack heights: 22 vs 19
		//IL_1415->IL17d0: Incompatible stack heights: 21 vs 0
		//IL_1256->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_1168->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_10a6->IL2069: Incompatible stack heights: 22 vs 19
		//IL_1457->IL17d0: Incompatible stack heights: 21 vs 0
		//IL_1288->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_119a->IL17d0: Incompatible stack heights: 19 vs 0
		//IL_1491->IL17d0: Incompatible stack heights: 21 vs 0
		//IL_10d5->IL2069: Incompatible stack heights: 23 vs 19
		//IL_14e9->IL17d0: Incompatible stack heights: 22 vs 0
		//IL_1540->IL17d0: Incompatible stack heights: 23 vs 0
		//IL_1586->IL17d0: Incompatible stack heights: 23 vs 0
		//IL_15c1->IL17d0: Incompatible stack heights: 23 vs 0
		//IL_1611->IL17d0: Incompatible stack heights: 24 vs 0
		//IL_166a->IL17d0: Incompatible stack heights: 25 vs 0
		//IL_16ac->IL17d0: Incompatible stack heights: 25 vs 0
		//IL_16e5->IL17d0: Incompatible stack heights: 25 vs 0
		//IL_1735->IL17d0: Incompatible stack heights: 26 vs 0
		//IL_177e->IL17d0: Incompatible stack heights: 27 vs 0
		PlayLightSound();
		_hasFinishedPopulationAnimation = false;
		Component draftMajors = (Component)(object)_draftMajors;
		bool flag5;
		float endValue;
		if (_draftMajors != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			draftMajors = (Component)(object)_discarded;
			if (_discarded != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				draftMajors = _RerollButton;
				if ((object)_RerollButton != null)
				{
					Button component = _RerollButton.GetComponent<Button>();
					if ((object)component != null)
					{
						component.interactable = false;
						draftMajors = _MinorGetButton;
						if ((object)_MinorGetButton != null)
						{
							Button component2 = _MinorGetButton.GetComponent<Button>();
							if ((object)component2 != null)
							{
								component2.interactable = false;
								bool flag = _playerOptions == null;
								draftMajors = (Component)(object)_playerOptions;
								if (!flag)
								{
									PlayerOptionsData config = _playerOptions.Config;
									bool flag2 = config == null;
									draftMajors = (Component)(object)_playerOptions;
									if (!flag2)
									{
										draftMajors = (Component)(object)config._003CCollectedItems_003Ek__BackingField;
										if (config._003CCollectedItems_003Ek__BackingField != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
												object obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
												object obj2 = default(object);
												if ((nint)obj2 != -1)
												{
													bool flag3 = _playerOptions == null;
													draftMajors = (Component)(object)_playerOptions;
													if (!flag3)
													{
														PlayerOptionsData config2 = _playerOptions.Config;
														bool flag4 = config2 == null;
														draftMajors = (Component)(object)_playerOptions;
														if (!flag4)
														{
															draftMajors = (Component)(object)config2._003CCollectedItems_003Ek__BackingField;
															if (config2._003CCollectedItems_003Ek__BackingField != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
																if ((nint)0 == 0)
																{
																	flag5 = true;
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
																	obj = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
																	object obj4 = default(object);
																	object obj3 = obj4 - -1;
																	bool flag6 = obj3 == null;
																	flag5 = flag6;
																}
																if (!flag5)
																{
																	goto IL_217a;
																}
																SetDarkDesign();
																draftMajors = _MinorBackground;
																if ((object)_MinorBackground != null)
																{
																	Image component3 = _MinorBackground.GetComponent<Image>();
																	Sprite sprite = SpriteManager.GetSprite("darkanaFrame", "darkanaFrame");
																	bool flag7 = (object)component3 == null;
																	draftMajors = (Component)(object)"darkanaFrame";
																	if (!flag7)
																	{
																		component3.sprite = sprite;
																		bool flag8 = (object)_MinorBloodMask == null;
																		draftMajors = (Component)(object)_MinorBloodMask;
																		if (!flag8)
																		{
																			CanvasGroup component4 = _MinorBloodMask.GetComponent<CanvasGroup>();
																			bool flag9 = (object)component4 == null;
																			draftMajors = (Component)(object)_MinorBloodMask;
																			if (!flag9)
																			{
																				component4.alpha = 1f;
																				_arcanaMode = ArcanaMode.DARK;
																				draftMajors = (Component)(object)ArcanaMainSelectionPage.m_ArcanaModeChanged;
																				bool flag10 = ArcanaMainSelectionPage.m_ArcanaModeChanged == null;
																				endValue = 1f;
																				if (!flag10)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+40]");
																					draftMajors = (Component)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1717 @ rcx_v84 (UnityEngine.Component)+18] (should have been resolved before IL gen)");
																					endValue = 1f;
																				}
																				goto IL_18d4;
																			}
																		}
																	}
																}
															}
														}
													}
													goto IL_17d0;
												}
											}
											flag5 = false;
											goto IL_217a;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_17d0;
		IL_0ecc:
		_hasFreeReroll = _hasUnlockedDarkanas;
		SetReRollButton();
		DataManager data = _data;
		bool flag11 = _data == null;
		draftMajors = this;
		if (!flag11)
		{
			bool flag12 = data._003CAllArcanas_003Ek__BackingField == null;
			draftMajors = this;
			if (!flag12)
			{
				PlayerOptions playerOptions = (PlayerOptions)6603577472L;
				Dictionary<ArcanaType, ArcanaData>.Enumerator enumerator = default(Dictionary<ArcanaType, ArcanaData>.Enumerator);
				object obj5 = default(object);
				object obj6 = default(object);
				while (enumerator.MoveNext())
				{
					playerOptions = _playerOptions;
					bool flag13 = _playerOptions == null;
					PlayerOptionsData playerOptionsData;
					if (playerOptions._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions._hostGameConfig == null)
						{
							if (playerOptions._currentAdventureSaveData != null)
							{
								playerOptionsData = playerOptions._currentAdventureSaveData;
								if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_2050;
								}
							}
							playerOptionsData = playerOptions._mainGameConfig;
						}
						else
						{
							playerOptionsData = playerOptions._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
					}
					goto IL_2050;
					IL_2050:
					bool flag14 = playerOptionsData == null;
					MissingMethodException ex = (MissingMethodException)(object)playerOptionsData._003CUnlockedArcanas_003Ek__BackingField;
					bool flag15 = playerOptionsData._003CUnlockedArcanas_003Ek__BackingField == null;
					if (((Exception)ex)._message != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController message = (VampireSurvivors.Objects.Characters.CharacterController)(object)((Exception)ex)._message;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag16 = (nint)obj5 == -1;
						TweenCallback tweenCallback = null;
						if (!flag16)
						{
							bool flag17 = obj6 == null;
							_ = 1;
							tweenCallback = null;
						}
					}
				}
				bool flag18 = _draftCardCount <= 0;
				draftMajors = (Component)(&enumerator);
				object obj7 = null;
				float num = 2f;
				Component component5 = (Component)(&enumerator);
				if (flag18)
				{
					goto IL_1348;
				}
				System.Int32Enum int32Enum = default(System.Int32Enum);
				while (true)
				{
					List<ArcanaType> draftMajors2 = _draftMajors;
					bool flag19 = _draftMajors == null;
					draftMajors = component5;
					if (flag19)
					{
						break;
					}
					object obj8 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ rax_v201 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					if ((nint)obj8 >= 0)
					{
						GameObject gameObject = SpawnBigCard(null, ArcanaType.VOID, isDum: true);
						bool flag20 = !flag5;
						VampireSurvivors.Objects.Characters.CharacterController message = (VampireSurvivors.Objects.Characters.CharacterController)1;
						TweenCallback tweenCallback = (TweenCallback)4294967295L;
						draftMajors = this;
						if (!flag20)
						{
							bool flag21 = (object)gameObject == null;
							draftMajors = this;
							if (flag21)
							{
								break;
							}
							ArcanaCardUI component6 = gameObject.GetComponent<ArcanaCardUI>();
							bool flag22 = (object)component6 == null;
							draftMajors = (Component)(object)gameObject;
							if (flag22)
							{
								break;
							}
							component6.SetDarkBack();
							message = (VampireSurvivors.Objects.Characters.CharacterController)1;
							tweenCallback = (TweenCallback)4294967295L;
							draftMajors = component6;
						}
					}
					else
					{
						_003C_003Ec__DisplayClass102_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass102_0();
						draftMajors = (Component)(object)_draftMajors;
						if (_draftMajors == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
						object data2 = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllArcanas_003Ek__BackingField).get_Item(int32Enum);
						GameObject gameObject2 = SpawnBigCard((ArcanaData)data2, (ArcanaType)int32Enum);
						bool flag23 = (object)gameObject2 == null;
						draftMajors = this;
						if (flag23)
						{
							break;
						}
						ArcanaCardUI component7 = gameObject2.GetComponent<ArcanaCardUI>();
						bool flag24 = CS_0024_003C_003E8__locals4 == null;
						draftMajors = (Component)(object)gameObject2;
						if (flag24)
						{
							break;
						}
						CS_0024_003C_003E8__locals4.c = component7;
						TweenCallback onComplete = delegate
						{
							Tween tween3 = CS_0024_003C_003E8__locals4.c.Reveal();
						};
						object obj9 = obj7 & 0x80000003L;
						if ((nint)CS_0024_003C_003E8__locals4 < 0)
						{
							object obj10 = obj9 - 1;
							object obj11 = obj10 | -4;
							obj9 = obj11 + 1;
						}
						draftMajors = (Component)(obj9 + 1);
						float num2 = (float)draftMajors * 50f;
						Tween tween = UITimerHelper.RegisterMillis(num2, onComplete);
						num = num2;
						VampireSurvivors.Objects.Characters.CharacterController message = null;
						TweenCallback tweenCallback = null;
					}
					obj7++;
					bool flag25 = (nint)obj7 < _draftCardCount;
					component5 = draftMajors;
					if (flag25)
					{
						continue;
					}
					goto IL_1348;
				}
			}
		}
		goto IL_17d0;
		IL_217a:
		_arcanaMode = ArcanaMode.LIGHT;
		OnArcanaModeChange arcanaModeChanged = ArcanaMainSelectionPage.m_ArcanaModeChanged;
		if (ArcanaMainSelectionPage.m_ArcanaModeChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1995.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		SetLightDesign();
		endValue = 1f;
		draftMajors = this;
		goto IL_18d4;
		IL_1fe9:
		object obj12;
		if (obj12 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1196 @ rax_v190+1B8]");
			draftMajors = (Component)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1196 @ rax_v190+1B8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
				if ((nint)0 <= (nint)22)
				{
					goto IL_0ecc;
				}
				_draftCardCount = 6;
				draftMajors = _MinorCardContainer;
				if ((object)_MinorCardContainer != null)
				{
					GridLayoutGroup component8 = _MinorCardContainer.GetComponent<GridLayoutGroup>();
					if ((object)component8 != null)
					{
						object obj13 = component8 + 104;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
						TweenCallback tweenCallback2 = default(TweenCallback);
						TweenCallback tweenCallback = tweenCallback2;
						goto IL_0ecc;
					}
				}
			}
		}
		goto IL_17d0;
		IL_1348:
		List<GameObject> spawned = _spawned;
		if (_spawned != null)
		{
			bool flag26 = spawned._size <= 0;
			draftMajors = (Component)(object)spawned._items;
			if (spawned._items != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
				bool flag27 = (nint)0 <= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
				bool flag28 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
				draftMajors = (Component)0;
				if (!flag28)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
					Selectable component9 = ((GameObject)0).GetComponent<Selectable>();
					bool flag29 = (object)component9 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
					draftMajors = (Component)0;
					if (!flag29)
					{
						component9.Select();
						List<GameObject> spawned2 = _spawned;
						bool flag30 = _spawned == null;
						draftMajors = component9;
						if (!flag30)
						{
							bool flag31 = spawned2._size <= 0;
							GameObject[] items = spawned2._items;
							bool flag32 = spawned2._items == null;
							draftMajors = component9;
							if (!flag32)
							{
								bool flag33 = items.Length <= 0;
								bool flag34 = (object)items[0] == null;
								draftMajors = (Component)(object)items[0];
								if (!flag34)
								{
									ArcanaCardUI component10 = items[0].GetComponent<ArcanaCardUI>();
									bool flag35 = (object)component10 == null;
									draftMajors = (Component)(object)items[0];
									if (!flag35)
									{
										List<GameObject> spawned3 = _spawned;
										bool flag36 = _spawned == null;
										draftMajors = (Component)(object)items[0];
										if (!flag36)
										{
											bool flag37 = spawned3._size <= 0;
											draftMajors = (Component)(object)spawned3._items;
											if (spawned3._items != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
												bool flag38 = (nint)0 <= (nint)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
												bool flag39 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
												draftMajors = (Component)0;
												if (!flag39)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
													ArcanaCardUI component11 = ((GameObject)0).GetComponent<ArcanaCardUI>();
													bool flag40 = (object)component11 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
													draftMajors = (Component)0;
													if (!flag40)
													{
														List<GameObject> spawned4 = _spawned;
														bool flag41 = _spawned == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
														draftMajors = (Component)0;
														if (!flag41)
														{
															bool flag42 = spawned4._size <= 0;
															draftMajors = (Component)(object)spawned4._items;
															if (spawned4._items != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
																bool flag43 = (nint)0 <= (nint)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+20]");
																	SetInfo(UI: ((GameObject)0).GetComponent<ArcanaCardUI>(), data: component10._data, type: component11._type);
																	TweenCallback onComplete2 = delegate
																	{
																		Button component14 = _RerollButton.GetComponent<Button>();
																		component14.interactable = true;
																		Button component15 = _MinorGetButton.GetComponent<Button>();
																		component15.interactable = true;
																		_hasFinishedPopulationAnimation = true;
																		Transform target2 = _InfoGroup.transform;
																		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target2, 1f, 0.2f);
																		TweenCallback tweenCallback4 = delegate
																		{
																			Vector2 pivot = default(Vector2);
																			VampireSurvivors.App.Tools.Extensions.SetPivot(_InfoGroup, pivot);
																			Button component16 = _DarkButton.GetComponent<Button>();
																			component16.interactable = true;
																		};
																		if (tweenerCore3 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																			if ((nint)0 == 0)
																			{
																			}
																		}
																	};
																	Tween tween2 = UITimerHelper.RegisterMillis(500f, onComplete2);
																	SetBigCardNavigation();
																	UpdateButtonNavigation();
																	return;
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
		goto IL_17d0;
		IL_17d0:
		throw new NullReferenceException();
		IL_0cc5:
		bool flag44 = (object)_DisplayContainer == null;
		draftMajors = _DisplayContainer;
		if (!flag44)
		{
			_DisplayContainer.SetArcanaDetails();
			_draftCardCount = 4;
			GameObject playerOptions2 = (GameObject)(object)_playerOptions;
			bool flag45 = _playerOptions == null;
			draftMajors = _DisplayContainer;
			if (!flag45)
			{
				draftMajors = _DisplayContainer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rsi_v61 (UnityEngine.GameObject)+68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rsi_v61 (UnityEngine.GameObject)+58]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rsi_v61 (UnityEngine.GameObject)+78]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rsi_v61 (UnityEngine.GameObject)+78]");
							obj12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1196 @ rax_v190+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_1fe9;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rsi_v61 (UnityEngine.GameObject)+50]");
						obj12 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rsi_v61 (UnityEngine.GameObject)+58]");
						obj12 = 0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rsi_v61 (UnityEngine.GameObject)+68]");
					obj12 = 0;
				}
				goto IL_1fe9;
			}
		}
		goto IL_17d0;
		IL_18d4:
		DataManager data3 = _data;
		object obj16;
		if (_data != null && data3._003CAllArcanas_003Ek__BackingField != null)
		{
			Dictionary<ArcanaType, ArcanaData>.Enumerator enumerator2 = default(Dictionary<ArcanaType, ArcanaData>.Enumerator);
			object obj14 = default(object);
			object obj15 = default(object);
			while (enumerator2.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				GameObject gameObject3 = null;
				if (0 > 100)
				{
					continue;
				}
				nint num3 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2661 @ rax_v341 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num4 = 0;
				GameManager core = GM.Core;
				bool flag46 = (object)GM.Core == null;
				draftMajors = (Component)num4;
				if (!flag46)
				{
					ArcanaManager arcanaManager = core._arcanaManager;
					bool flag47 = core._arcanaManager == null;
					draftMajors = (Component)num4;
					if (!flag47)
					{
						draftMajors = (Component)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
						if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
						{
							VampireSurvivors.App.Tools.Extensions.Shuffle(arcanaManager._003CActiveArcanas_003Ek__BackingField, (Unity.Mathematics.Random)0);
							if (obj14 != null)
							{
								continue;
							}
							bool flag48 = _playerOptions == null;
							draftMajors = (Component)(object)_playerOptions;
							if (!flag48)
							{
								PlayerOptionsData config3 = _playerOptions.Config;
								bool flag49 = config3 == null;
								draftMajors = (Component)(object)_playerOptions;
								if (!flag49)
								{
									draftMajors = (Component)(object)config3._003CUnlockedArcanas_003Ek__BackingField;
									if (config3._003CUnlockedArcanas_003Ek__BackingField != null)
									{
										VampireSurvivors.App.Tools.Extensions.Shuffle(config3._003CUnlockedArcanas_003Ek__BackingField, (Unity.Mathematics.Random)0);
										if (obj15 == null)
										{
											continue;
										}
										if (false)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ rsi_v78 (UnityEngine.GameObject)+4B]");
											if ((nint)0 == 0)
											{
												draftMajors = (Component)(object)_draftMajors;
												if (_draftMajors == null)
												{
													throw new NullReferenceException();
												}
												VampireSurvivors.App.Tools.Extensions.Shuffle(_draftMajors, (Unity.Mathematics.Random)0);
											}
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
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			nint num5 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2499 @ rax_v126 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num6 = 0;
			GameManager core2 = GM.Core;
			bool flag50 = (object)GM.Core == null;
			draftMajors = (Component)num6;
			if (!flag50)
			{
				bool flag51 = core2._multiplayer == null;
				draftMajors = (Component)(object)core2._multiplayer;
				if (!flag51)
				{
					if (!core2._multiplayer.IsOnlineMultiplayer)
					{
						VampireSurvivors.App.Tools.Extensions.Shuffle(_draftMajors);
						draftMajors = (Component)(object)_draftMajors;
					}
					else
					{
						draftMajors = (Component)(object)core2._multiplayer;
						OnlineStageManager instance = OnlineStageManager._instance;
						if ((object)OnlineStageManager._instance == null)
						{
							goto IL_17d0;
						}
						VampireSurvivors.App.Tools.Extensions.Shuffle(_draftMajors, instance._minorArcanasRng);
						draftMajors = (Component)(object)_draftMajors;
					}
					isShowingMinor = true;
					GameObject minorSelectionGroup = _MinorSelectionGroup;
					if ((object)_MinorSelectionGroup != null)
					{
						bool flag52 = ((UnityEngine.Object)minorSelectionGroup).m_CachedPtr == (IntPtr)0;
						GameObject.SetActive_Injected(((UnityEngine.Object)minorSelectionGroup).m_CachedPtr, true);
						GameObject majorSelectionGroup = _MajorSelectionGroup;
						bool flag53 = (object)_MajorSelectionGroup == null;
						draftMajors = (Component)(nint)((UnityEngine.Object)minorSelectionGroup).m_CachedPtr;
						if (!flag53)
						{
							bool flag54 = ((UnityEngine.Object)majorSelectionGroup).m_CachedPtr == (IntPtr)0;
							GameObject.SetActive_Injected(((UnityEngine.Object)majorSelectionGroup).m_CachedPtr, false);
							GameObject count = (GameObject)(object)_Count;
							bool flag55 = (object)_Count == null;
							draftMajors = (Component)(nint)((UnityEngine.Object)majorSelectionGroup).m_CachedPtr;
							if (!flag55)
							{
								bool flag56 = ((UnityEngine.Object)count).m_CachedPtr == (IntPtr)0;
								IntPtr intPtr = Component.get_gameObject_Injected(((UnityEngine.Object)count).m_CachedPtr);
								GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(intPtr);
								bool flag57 = (object)gameObject4 == null;
								draftMajors = (Component)(nint)intPtr;
								if (!flag57)
								{
									bool flag58 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
									GameObject.SetActive_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr, false);
									GameObject minorBackground = (GameObject)(object)_MinorBackground;
									bool flag59 = (object)_MinorBackground == null;
									draftMajors = (Component)(nint)((UnityEngine.Object)gameObject4).m_CachedPtr;
									if (!flag59)
									{
										bool flag60 = ((UnityEngine.Object)minorBackground).m_CachedPtr == (IntPtr)0;
										IntPtr intPtr2 = Component.get_transform_Injected(((UnityEngine.Object)minorBackground).m_CachedPtr);
										Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr2);
										bool flag61 = (object)transform == null;
										draftMajors = (Component)(nint)intPtr2;
										if (!flag61)
										{
											TweenCallback tweenCallback3 = default(TweenCallback);
											transform.localEulerAngles = (Vector3)(&tweenCallback3);
											Vector3 vector = default(Vector3);
											TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_MinorBackground, (Vector3)(&vector), 0.2f);
											object minorBackground2 = _MinorBackground;
											bool flag62 = (object)_MinorBackground == null;
											draftMajors = _MinorBackground;
											if (!flag62)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rsi_v53 (System.Object)+10]");
												bool flag63 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rsi_v53 (System.Object)+10]");
												IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
												Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
												bool flag64 = (object)transform2 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4413 @ rax_v162 (UnityEngine.Transform)+10]");
												bool flag65 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4413 @ rax_v162 (UnityEngine.Transform)+10]");
												Vector3 value = default(Vector3);
												Transform.set_localScale_Injected((IntPtr)0, ref value);
												object minorBackground3 = _MinorBackground;
												bool flag66 = (object)_MinorBackground == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2789 @ rsi_v55 (System.Object)+10]");
												bool flag67 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2789 @ rsi_v55 (System.Object)+10]");
												IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
												Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
												TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, endValue, 0.2f);
												object displayContainer = _DisplayContainer;
												bool flag68 = (object)_DisplayContainer == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2995 @ rsi_v56 (System.Object)+10]");
												bool flag69 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2995 @ rsi_v56 (System.Object)+10]");
												IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
												GameObject gameObject5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
												bool flag70 = (object)gameObject5 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4735 @ rax_v180 (UnityEngine.GameObject)+10]");
												bool flag71 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4735 @ rax_v180 (UnityEngine.GameObject)+10]");
												GameObject.SetActive_Injected((IntPtr)0, true);
												object playerOptions3 = _playerOptions;
												bool flag72 = _playerOptions == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4628 @ rsi_v58 (System.Object)+68]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4628 @ rsi_v58 (System.Object)+58]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4628 @ rsi_v58 (System.Object)+78]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4628 @ rsi_v58 (System.Object)+78]");
															obj16 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v186+2CC]");
															if ((nint)0 != 0)
															{
																goto IL_1e48;
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4628 @ rsi_v58 (System.Object)+50]");
														obj16 = 0;
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4628 @ rsi_v58 (System.Object)+58]");
														obj16 = 0;
													}
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4628 @ rsi_v58 (System.Object)+68]");
													obj16 = 0;
												}
												goto IL_1e48;
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
		goto IL_17d0;
		IL_1e48:
		bool flag73 = obj16 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v186+168]");
		draftMajors = (Component)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v186+168]");
		bool flag74 = (nint)0 == 0;
		object characterStatsPanel = _CharacterStatsPanel;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+18]");
		if ((nint)0 <= (nint)21)
		{
			if ((object)_CharacterStatsPanel != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rsi_v59 (System.Object)+10]");
				bool flag75 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rsi_v59 (System.Object)+10]");
				GameObject.SetActive_Injected((IntPtr)0, false);
				draftMajors = _EquipmentPanel;
				if ((object)_EquipmentPanel != null)
				{
					GameObject gameObject6 = _EquipmentPanel.gameObject;
					if ((object)gameObject6 != null)
					{
						bool flag76 = ((UnityEngine.Object)gameObject6).m_CachedPtr == (IntPtr)0;
						GameObject.SetActive_Injected(((UnityEngine.Object)gameObject6).m_CachedPtr, false);
						VampireSurvivors.Objects.Characters.CharacterController message = null;
						TweenCallback tweenCallback = null;
						goto IL_0cc5;
					}
				}
			}
		}
		else if ((object)_CharacterStatsPanel != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rsi_v59 (System.Object)+10]");
			bool flag77 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rsi_v59 (System.Object)+10]");
			GameObject.SetActive_Injected((IntPtr)0, true);
			bool flag78 = (object)_CharacterStatsPanel == null;
			draftMajors = (Component)(object)_CharacterStatsPanel;
			if (!flag78)
			{
				StatsPanelUI component12 = _CharacterStatsPanel.GetComponent<StatsPanelUI>();
				bool flag79 = (object)component12 == null;
				draftMajors = (Component)(object)_CharacterStatsPanel;
				if (!flag79)
				{
					if (!component12._hasLoaded)
					{
						component12.Populate();
					}
					TextAutoSizeHelper.UpdateTextSizes(component12._statTextLines, -1);
					bool flag80 = (object)_CharacterStatsPanel == null;
					draftMajors = (Component)(object)_CharacterStatsPanel;
					if (!flag80)
					{
						StatsPanelUI component13 = _CharacterStatsPanel.GetComponent<StatsPanelUI>();
						bool flag81 = _data == null;
						draftMajors = (Component)(object)_data;
						if (!flag81)
						{
							Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
							draftMajors = _controllingCharacter;
							if ((object)_controllingCharacter != null && convertedCharacterData != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v84 (UnityEngine.Component)+134]");
								object obj17 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
								bool flag82 = obj17 == null;
								draftMajors = (Component)(object)convertedCharacterData;
								if (!flag82)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rax_v272 (System.Object)+18]");
									bool flag83 = (nint)0 <= (nint)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rax_v272 (System.Object)+10]");
									object obj18 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rax_v272 (System.Object)+10]");
									bool flag84 = (nint)0 == 0;
									draftMajors = (Component)(object)convertedCharacterData;
									if (!flag84)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1190 @ rax_v273+18]");
										bool flag85 = (nint)0 <= (nint)0;
										VampireSurvivors.Objects.Characters.CharacterController controllingCharacter = _controllingCharacter;
										bool flag86 = (object)_controllingCharacter == null;
										draftMajors = (Component)(object)convertedCharacterData;
										if (!flag86)
										{
											bool flag87 = (object)component13 == null;
											draftMajors = (Component)(object)convertedCharacterData;
											if (!flag87)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1190 @ rax_v273+20]");
												component13.SetCharacter((CharacterData)0, controllingCharacter._characterType, _controllingCharacter);
												draftMajors = _EquipmentPanel;
												if ((object)_EquipmentPanel != null)
												{
													GameObject gameObject7 = _EquipmentPanel.gameObject;
													if ((object)gameObject7 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1193 @ rax_v276 (UnityEngine.GameObject)+10]");
														bool flag88 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1193 @ rax_v276 (UnityEngine.GameObject)+10]");
														GameObject.SetActive_Injected((IntPtr)0, true);
														bool flag89 = (object)_EquipmentPanel == null;
														draftMajors = _EquipmentPanel;
														if (!flag89)
														{
															_EquipmentPanel.Populate(_controllingCharacter);
															VampireSurvivors.Objects.Characters.CharacterController message = _controllingCharacter;
															TweenCallback tweenCallback = null;
															goto IL_0cc5;
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
		goto IL_17d0;
	}

	private void EnableInputSecondMenu()
	{
		TweenCallback onComplete = delegate
		{
			Button component = _RerollButton.GetComponent<Button>();
			component.interactable = true;
			Button component2 = _MinorGetButton.GetComponent<Button>();
			component2.interactable = true;
			_hasFinishedPopulationAnimation = true;
			Transform target = _InfoGroup.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.2f);
			TweenCallback tweenCallback = delegate
			{
				Vector2 pivot = default(Vector2);
				VampireSurvivors.App.Tools.Extensions.SetPivot(_InfoGroup, pivot);
				Button component3 = _DarkButton.GetComponent<Button>();
				component3.interactable = true;
			};
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		};
		Tween tween = UITimerHelper.RegisterMillis(500f, onComplete);
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		return _controllingCharacter;
	}

	private unsafe void UpdateButtonNavigation()
	{
		//IL_065e: Expected O, but got I4
		//IL_0353: Expected O, but got Ref
		//IL_0171: Expected O, but got Ref
		//IL_053b: Expected O, but got Ref
		//IL_0237->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0055->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0265->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0083->IL0608: Incompatible stack heights: 1 vs 0
		//IL_02a6->IL0608: Incompatible stack heights: 1 vs 0
		//IL_00c4->IL0608: Incompatible stack heights: 1 vs 0
		//IL_02d4->IL0608: Incompatible stack heights: 1 vs 0
		//IL_00f2->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0315->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0133->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0341->IL0608: Incompatible stack heights: 1 vs 0
		//IL_015f->IL0608: Incompatible stack heights: 1 vs 0
		//IL_036d->IL0608: Incompatible stack heights: 1 vs 0
		//IL_018b->IL0608: Incompatible stack heights: 1 vs 0
		//IL_039b->IL0608: Incompatible stack heights: 1 vs 0
		//IL_01b9->IL0608: Incompatible stack heights: 1 vs 0
		//IL_03dc->IL0608: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL0608: Incompatible stack heights: 1 vs 0
		//IL_041f->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0696->IL0608: Incompatible stack heights: 1 vs 0
		//IL_044d->IL0608: Incompatible stack heights: 1 vs 0
		//IL_048e->IL0608: Incompatible stack heights: 1 vs 0
		//IL_04bc->IL0608: Incompatible stack heights: 1 vs 0
		//IL_04fd->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0529->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0555->IL0608: Incompatible stack heights: 1 vs 0
		//IL_0583->IL0608: Incompatible stack heights: 1 vs 0
		//IL_05c4->IL0608: Incompatible stack heights: 1 vs 0
		Selectable component8;
		Component component9;
		if ((object)_RerollButton != null)
		{
			GameObject gameObject = _RerollButton.gameObject;
			if ((object)gameObject != null)
			{
				bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				object obj2 = default(object);
				if (obj == null)
				{
					if ((object)_MinorGetButton != null)
					{
						Selectable component = _MinorGetButton.GetComponent<Selectable>();
						if ((object)_SkipButton != null)
						{
							Selectable component2 = _SkipButton.GetComponent<Selectable>();
							SetNavigationDown(component, component2);
							if ((object)_MinorGetButton != null)
							{
								Selectable component3 = _MinorGetButton.GetComponent<Selectable>();
								if ((object)_SkipButton != null)
								{
									Selectable component4 = _SkipButton.GetComponent<Selectable>();
									SetNavigationRight(component3, component4);
									if ((object)_SkipButton != null)
									{
										Selectable component5 = _SkipButton.GetComponent<Selectable>();
										if ((object)component5 != null)
										{
											component5.navigation = (Navigation)(&obj2);
											if ((object)_SkipButton != null)
											{
												Selectable component6 = _SkipButton.GetComponent<Selectable>();
												if ((object)_MinorGetButton != null)
												{
													Selectable component7 = _MinorGetButton.GetComponent<Selectable>();
													SetNavigationLeft(component6, component7);
													if ((object)_SkipButton != null)
													{
														component8 = _SkipButton.GetComponent<Selectable>();
														component9 = _MinorGetButton;
														goto IL_067e;
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
				else if ((object)_MinorGetButton != null)
				{
					Selectable component10 = _MinorGetButton.GetComponent<Selectable>();
					if ((object)_SkipButton != null)
					{
						Selectable component11 = _SkipButton.GetComponent<Selectable>();
						SetNavigationDown(component10, component11);
						if ((object)_MinorGetButton != null)
						{
							Selectable component12 = _MinorGetButton.GetComponent<Selectable>();
							if ((object)_RerollButton != null)
							{
								Selectable component13 = _RerollButton.GetComponent<Selectable>();
								SetNavigationRight(component12, component13);
								if ((object)_RerollButton != null)
								{
									Selectable component14 = _RerollButton.GetComponent<Selectable>();
									if ((object)component14 != null)
									{
										component14.navigation = (Navigation)(&obj2);
										if ((object)_RerollButton != null)
										{
											Selectable component15 = _RerollButton.GetComponent<Selectable>();
											if ((object)_SkipButton != null)
											{
												Selectable component16 = _SkipButton.GetComponent<Selectable>();
												SetNavigationDown(component15, component16);
												if ((object)_RerollButton != null)
												{
													Selectable component17 = _RerollButton.GetComponent<Selectable>();
													SetNavigationUp(component17, previouslyHighlightedDraftCard);
													if ((object)_RerollButton != null)
													{
														Selectable component18 = _RerollButton.GetComponent<Selectable>();
														if ((object)_SkipButton != null)
														{
															Selectable component19 = _SkipButton.GetComponent<Selectable>();
															SetNavigationRight(component18, component19);
															if ((object)_RerollButton != null)
															{
																Selectable component20 = _RerollButton.GetComponent<Selectable>();
																if ((object)_MinorGetButton != null)
																{
																	Selectable component21 = _MinorGetButton.GetComponent<Selectable>();
																	SetNavigationLeft(component20, component21);
																	if ((object)_SkipButton != null)
																	{
																		Selectable component22 = _SkipButton.GetComponent<Selectable>();
																		if ((object)component22 != null)
																		{
																			component22.navigation = (Navigation)(&obj2);
																			if ((object)_SkipButton != null)
																			{
																				Selectable component23 = _SkipButton.GetComponent<Selectable>();
																				if ((object)_RerollButton != null)
																				{
																					Selectable component24 = _RerollButton.GetComponent<Selectable>();
																					SetNavigationLeft(component23, component24);
																					if ((object)_SkipButton != null)
																					{
																						component8 = _SkipButton.GetComponent<Selectable>();
																						component9 = _RerollButton;
																						goto IL_067e;
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
						}
					}
				}
			}
		}
		goto IL_0608;
		IL_0608:
		throw new NullReferenceException();
		IL_067e:
		if ((object)component9 != null)
		{
			Selectable component25 = component9.GetComponent<Selectable>();
			SetNavigationUp(component8, component25);
			return;
		}
		goto IL_0608;
	}

	public void Skip()
	{
		//IL_00a0: Expected I8, but got O
		//IL_00b8: Expected I8, but got O
		//IL_007f: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97770");
			return;
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).SkipMinorArcanas((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rbx_v3 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private void PerformSkip()
	{
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97770");
	}

	private void SetReRollButton()
	{
		//IL_0427: Expected I4, but got F4
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0450: Invalid comparison between F4 and I4
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_0283: Expected I4, but got F4
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		GameObject gameObject = _MinorGetButton.gameObject;
		bool active = IsLocalPlayerControllingUi();
		gameObject.SetActive(active);
		GameObject gameObject2 = _SkipButton.gameObject;
		bool active2 = IsLocalPlayerControllingUi();
		gameObject2.SetActive(active2);
		List<ArcanaType> draftMajors = _draftMajors;
		Component rerollButton = _RerollButton;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 <= (nint)_draftCardCount)
		{
			goto IL_01fb;
		}
		float num = default(float);
		float num2;
		if (!_hasFreeReroll)
		{
			Button component = _RerollButton.GetComponent<Button>();
			component.interactable = false;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num);
			VampireSurvivors.Objects.Characters.CharacterController controllingCharacter = _controllingCharacter;
			PlayerModifierStats playerStats = controllingCharacter._playerStats;
			EggFloat eggFloat = playerStats._003CReRolls_003Ek__BackingField;
			num2 = eggFloat._eggVal + eggFloat._val;
			object obj = num2 & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num2 & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					bool flag = num2 == -1f / 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186987934h\"");
					if (flag)
					{
						goto IL_01ec;
					}
					goto IL_0447;
				}
			}
			num2 = 3.4028235E+38f;
			goto IL_0447;
		}
		GameObject gameObject3 = _RerollButton.gameObject;
		bool active3 = IsLocalPlayerControllingUi();
		gameObject3.SetActive(active3);
		TextMeshProUGUI rerollCountText = _RerollCountText;
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/free_reroll", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text = translation;
		TextMeshProUGUI textMeshProUGUI = rerollCountText;
		goto IL_0482;
		IL_01ec:
		rerollButton = _RerollButton;
		goto IL_01fb;
		IL_01fb:
		GameObject gameObject4 = rerollButton.gameObject;
		gameObject4.SetActive(value: false);
		return;
		IL_0447:
		TextMeshProUGUI rerollCountText2;
		string translation2;
		float num3;
		if (num2 > 0f)
		{
			GameObject gameObject5 = _RerollButton.gameObject;
			bool active4 = IsLocalPlayerControllingUi();
			gameObject5.SetActive(active4);
			rerollCountText2 = _RerollCountText;
			translation2 = LocalizationManager.GetTranslation("lang/levelup_Xleft", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			VampireSurvivors.Objects.Characters.CharacterController controllingCharacter2 = _controllingCharacter;
			PlayerModifierStats playerStats2 = controllingCharacter2._playerStats;
			EggFloat eggFloat2 = playerStats2._003CReRolls_003Ek__BackingField;
			num3 = eggFloat2._eggVal + eggFloat2._val;
			object obj3 = num3 & -2147483649L;
			if ((nint)obj3 != 2139095040)
			{
				object obj4 = num3 & -2147483649L;
				if ((nint)obj4 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186987A65h\"");
					if (num3 == -1f / 0f)
					{
						num3 = -3.4028235E+38f;
					}
					goto IL_0465;
				}
			}
			num3 = 3.4028235E+38f;
			goto IL_0465;
		}
		goto IL_01ec;
		IL_0465:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string newValue = System.Number.FormatSingle(num3, "F0", currentInfo);
		string text2 = translation2.Replace("%0", newValue);
		text = text2;
		textMeshProUGUI = rerollCountText2;
		goto IL_0482;
		IL_0482:
		textMeshProUGUI.text = text;
	}

	private unsafe void PerformReRoll()
	{
		//IL_1538: Unknown result type (might be due to invalid IL or missing references)
		//IL_153d: Expected O, but got Unknown
		//IL_1550: Expected O, but got I4
		//IL_1559: Expected O, but got I4
		//IL_14f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fe: Expected O, but got Unknown
		//IL_1511: Expected O, but got I4
		//IL_151a: Expected O, but got I4
		//IL_03a8: Expected O, but got I
		//IL_0433: Expected O, but got I
		//IL_04c6: Expected O, but got I
		//IL_15a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a5: Expected O, but got Unknown
		//IL_1629: Expected I, but got O
		//IL_165a: Expected O, but got I
		//IL_05a0: Expected I, but got O
		//IL_05d1: Expected O, but got I
		//IL_0608: Expected O, but got I
		//IL_08f2: Expected F4, but got I4
		//IL_0905: Expected F4, but got I4
		//IL_0bfa: Expected I4, but got O
		//IL_0c27: Expected O, but got I
		//IL_0c3d: Expected O, but got I
		//IL_09b1: Expected O, but got I
		//IL_0c8f: Expected I4, but got I8
		//IL_0a31: Expected O, but got I
		//IL_0a77: Expected O, but got I
		//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Expected O, but got Unknown
		//IL_0a0b: Expected O, but got Ref
		//IL_0d9c: Expected O, but got I
		//IL_0cfd: Expected F4, but got O
		//IL_0dbf: Expected O, but got I
		//IL_1754: Expected O, but got Ref
		//IL_0aef: Expected O, but got I
		//IL_0e6b: Expected I4, but got I8
		//IL_176f: Expected I, but got O
		//IL_1785: Expected O, but got I
		//IL_178e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1793: Expected O, but got Unknown
		//IL_1885: Expected O, but got I4
		//IL_0b40: Expected I, but got O
		//IL_0e99: Expected O, but got I4
		//IL_0ea2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea7: Expected O, but got Unknown
		//IL_0eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb5: Expected I4, but got Unknown
		//IL_0fd8: Expected O, but got Ref
		//IL_17d0: Expected I, but got I8
		//IL_0b29: Expected I, but got I8
		//IL_1117: Expected O, but got I
		//IL_1136: Expected O, but got I
		//IL_1159: Expected O, but got I
		//IL_11d5: Expected O, but got I
		//IL_12da: Expected O, but got I
		//IL_1332: Expected O, but got I
		//IL_13a0: Expected I, but got O
		//IL_13b6: Expected O, but got I
		//IL_13bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c4: Expected O, but got Unknown
		//IL_142d: Expected I, but got O
		//IL_18f9: Expected O, but got I4
		//IL_1910: Expected I, but got I8
		//IL_1919: Expected O, but got I4
		//IL_1416: Expected I, but got I8
		//IL_03d2->IL146f: Incompatible stack heights: 1 vs 0
		//IL_03fb->IL146f: Incompatible stack heights: 1 vs 0
		//IL_045d->IL146f: Incompatible stack heights: 1 vs 0
		//IL_15bc->IL191e: Incompatible stack heights: 1 vs 0
		//IL_0506->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0548->IL146f: Incompatible stack heights: 1 vs 0
		//IL_056a->IL146f: Incompatible stack heights: 1 vs 0
		//IL_1663->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0842->IL146f: Incompatible stack heights: 1 vs 0
		//IL_168a->IL146f: Incompatible stack heights: 1 vs 0
		//IL_08df->IL146f: Incompatible stack heights: 1 vs 0
		//IL_1849->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0c66->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0d3d->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0cb0->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0d70->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0ce2->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0a1b->IL16de: Incompatible stack heights: 7 vs 8
		//IL_0da5->IL146f: Incompatible stack heights: 1 vs 0
		//IL_1872->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0dfc->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0f46->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0e2e->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0f78->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0faa->IL146f: Incompatible stack heights: 1 vs 0
		//IL_17fa->IL17ff: Incompatible stack heights: 10 vs 1
		//IL_0b84->IL17ff: Incompatible stack heights: 10 vs 1
		//IL_109b->IL146f: Incompatible stack heights: 1 vs 0
		//IL_0ba5->IL17ff: Incompatible stack heights: 10 vs 1
		//IL_10eb->IL146f: Incompatible stack heights: 2 vs 0
		//IL_1120->IL146f: Incompatible stack heights: 2 vs 0
		//IL_1162->IL146f: Incompatible stack heights: 2 vs 0
		//IL_119c->IL146f: Incompatible stack heights: 2 vs 0
		//IL_11fd->IL146f: Incompatible stack heights: 3 vs 0
		//IL_122e->IL146f: Incompatible stack heights: 3 vs 0
		//IL_125d->IL146f: Incompatible stack heights: 3 vs 0
		//IL_12a4->IL146f: Incompatible stack heights: 3 vs 0
		//IL_12f7->IL146f: Incompatible stack heights: 4 vs 0
		//IL_131c->IL146f: Incompatible stack heights: 4 vs 0
		//IL_19cc->IL146f: Incompatible stack heights: 4 vs 0
		//IL_146e->IL146e: Incompatible stack heights: 4 vs 0
		Component minorCardContainer = _MinorCardContainer;
		object obj2;
		object obj3;
		List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
		if ((object)_MinorCardContainer != null)
		{
			GridLayoutGroup component = _MinorCardContainer.GetComponent<GridLayoutGroup>();
			if ((object)component != null)
			{
				component.enabled = true;
				bool flag = _playerOptions == null;
				minorCardContainer = (Component)(object)_playerOptions;
				if (!flag)
				{
					PlayerOptionsData config = _playerOptions.Config;
					bool flag2 = config == null;
					minorCardContainer = (Component)(object)_playerOptions;
					if (!flag2)
					{
						List<ArcanaType> list = config._003CUnlockedArcanas_003Ek__BackingField;
						bool flag3 = config._003CUnlockedArcanas_003Ek__BackingField == null;
						minorCardContainer = (Component)(object)_playerOptions;
						if (!flag3)
						{
							minorCardContainer = _MinorCardContainer;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ rax_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
							if ((nint)0 <= (nint)22)
							{
								if ((object)minorCardContainer != null)
								{
									GridLayoutGroup component2 = minorCardContainer.GetComponent<GridLayoutGroup>();
									if ((object)component2 != null)
									{
										object obj = component2 + 104;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
										obj2 = 4;
										obj3 = 4;
										List<GameObject>.Enumerator enumerator = enumerator2;
										minorCardContainer = component2;
										goto IL_01c7;
									}
								}
							}
							else if ((object)_MinorCardContainer != null)
							{
								GridLayoutGroup component3 = _MinorCardContainer.GetComponent<GridLayoutGroup>();
								if ((object)component3 != null)
								{
									object obj4 = component3 + 104;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
									obj2 = 6;
									obj3 = 6;
									List<GameObject>.Enumerator enumerator = enumerator2;
									minorCardContainer = component3;
									goto IL_01c7;
								}
							}
						}
					}
				}
			}
		}
		goto IL_146f;
		IL_156e:
		minorCardContainer = _MinorCardContainer;
		if ((object)_MinorCardContainer != null)
		{
			CanvasGroup component4 = _MinorCardContainer.GetComponent<CanvasGroup>();
			if ((object)component4 != null)
			{
				component4.interactable = false;
				GridLayoutGroup gridLayoutGroup = null;
				Dictionary<ArcanaType, ArcanaData>.Enumerator enumerator3 = default(Dictionary<ArcanaType, ArcanaData>.Enumerator);
				object obj8 = default(object);
				object obj9 = default(object);
				object obj10 = default(object);
				List<GameObject>.Enumerator enumerator5 = default(List<GameObject>.Enumerator);
				object obj12 = default(object);
				object obj16 = default(object);
				List<GameObject>.Enumerator enumerator6 = default(List<GameObject>.Enumerator);
				System.Int32Enum int32Enum = default(System.Int32Enum);
				GameObject gameObject3 = default(GameObject);
				object obj22 = default(object);
				while (true)
				{
					List<System.Int32Enum> discarded = (List<System.Int32Enum>)(object)_discarded;
					List<ArcanaType> draftMajors = _draftMajors;
					bool flag4 = _draftMajors == null;
					minorCardContainer = (Component)(object)_discarded;
					if (flag4)
					{
						break;
					}
					GridLayoutGroup gridLayoutGroup2 = gridLayoutGroup;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rax_v72 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					bool flag5 = (nint)gridLayoutGroup2 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rax_v72 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rax_v72 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
					bool flag6 = (nint)0 == 0;
					minorCardContainer = (Component)(object)_discarded;
					if (flag6)
					{
						break;
					}
					bool flag7 = _discarded == null;
					minorCardContainer = (Component)(object)_discarded;
					if (flag7)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
					bool flag8 = (nint)0 == 0;
					minorCardContainer = (Component)(object)_discarded;
					if (flag8)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v989 @ r8_v89 (Il2CppMethodInfo)+18]");
					if (num2 >= 0)
					{
						List<ArcanaType> discarded2 = _discarded;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v42+20+v257 @ rbx_v31 (UnityEngine.UI.GridLayoutGroup)*4]");
						((List<System.Int32Enum>)(object)discarded2).AddWithResize((System.Int32Enum)0);
						num = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						object obj7 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v42+20+v257 @ rbx_v31 (UnityEngine.UI.GridLayoutGroup)*4]");
						_ = 0;
					}
					gridLayoutGroup = (GridLayoutGroup)(gridLayoutGroup + 1);
					if (System.Runtime.CompilerServices.Unsafe.As<GridLayoutGroup, UIntPtr>(ref gridLayoutGroup) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
					{
						continue;
					}
					minorCardContainer = (Component)(object)_draftMajors;
					if (_draftMajors == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					DataManager data = _data;
					if (_data == null || data._003CAllArcanas_003Ek__BackingField == null)
					{
						break;
					}
					while (enumerator3.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
						GridLayoutGroup gridLayoutGroup3 = null;
						if (0 > 100)
						{
							continue;
						}
						nint num3 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3595 @ rax_v220 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num4 = 0;
						GameManager core = GM.Core;
						bool flag9 = (object)GM.Core == null;
						minorCardContainer = (Component)num4;
						if (!flag9)
						{
							ArcanaManager arcanaManager = core._arcanaManager;
							bool flag10 = core._arcanaManager == null;
							minorCardContainer = (Component)num4;
							if (!flag10)
							{
								minorCardContainer = (Component)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
								if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
								{
									arcanaManager._003CActiveArcanas_003Ek__BackingField.AddWithResize(ArcanaType.T00_KILLER);
									if (obj8 != null)
									{
										continue;
									}
									bool flag11 = _playerOptions == null;
									minorCardContainer = (Component)(object)_playerOptions;
									if (!flag11)
									{
										PlayerOptionsData config2 = _playerOptions.Config;
										bool flag12 = config2 == null;
										minorCardContainer = (Component)(object)_playerOptions;
										if (!flag12)
										{
											minorCardContainer = (Component)(object)config2._003CUnlockedArcanas_003Ek__BackingField;
											if (config2._003CUnlockedArcanas_003Ek__BackingField != null)
											{
												config2._003CUnlockedArcanas_003Ek__BackingField.AddWithResize(ArcanaType.T00_KILLER);
												if (obj9 == null)
												{
													continue;
												}
												if (false)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ rsi_v38 (UnityEngine.UI.GridLayoutGroup)+4B]");
													if ((nint)0 != 0)
													{
														continue;
													}
													minorCardContainer = (Component)(object)_discarded;
													if (_discarded != null)
													{
														_discarded.AddWithResize(ArcanaType.T00_KILLER);
														if (obj10 == null)
														{
															minorCardContainer = (Component)(object)_draftMajors;
															if (_draftMajors == null)
															{
																throw new NullReferenceException();
															}
															_draftMajors.AddWithResize(ArcanaType.T00_KILLER);
														}
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
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					nint num5 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3525 @ rax_v79 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num6 = 0;
					GameManager core2 = GM.Core;
					bool flag13 = (object)GM.Core == null;
					minorCardContainer = (Component)num6;
					if (flag13)
					{
						break;
					}
					bool flag14 = core2._multiplayer == null;
					minorCardContainer = (Component)(object)core2._multiplayer;
					if (flag14)
					{
						break;
					}
					if (!core2._multiplayer.IsOnlineMultiplayer)
					{
						VampireSurvivors.App.Tools.Extensions.Shuffle(_draftMajors);
					}
					else
					{
						minorCardContainer = (Component)(object)core2._multiplayer;
						OnlineStageManager instance = OnlineStageManager._instance;
						if ((object)OnlineStageManager._instance == null)
						{
							break;
						}
						VampireSurvivors.App.Tools.Extensions.Shuffle(_draftMajors, instance._minorArcanasRng);
					}
					List<Vector3> list2 = new List<Vector3>();
					List<GameObject> list3 = _spawned;
					bool flag15 = _spawned == null;
					minorCardContainer = (Component)(object)list2;
					if (flag15)
					{
						break;
					}
					float num7 = 0f;
					List<GameObject>.Enumerator enumerator4 = (List<GameObject>.Enumerator)_spawned;
					float num8 = 0f;
					while (enumerator5.MoveNext())
					{
						_003C_003Ec__DisplayClass109_0 obj11 = new _003C_003Ec__DisplayClass109_0();
						bool flag16 = obj11 == null;
						obj11.v = null;
						bool flag17 = (object)obj11.v == null;
						RectTransform component5 = obj11.v.GetComponent<RectTransform>();
						bool flag18 = (object)component5 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2871 @ rax_v157 (UnityEngine.RectTransform)+10]");
						bool flag19 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2871 @ rax_v157 (UnityEngine.RectTransform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
						bool flag20 = list2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ rax_v83 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ rax_v83 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						Vector3 vector = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ rax_v83 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						bool flag21 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ rax_v83 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1886 @ rdx_v97 (UnityEngine.Vector3)+18]");
						if (num9 >= 0)
						{
							list2.AddWithResize((Vector3)(&obj12));
							obj12 = ret;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ rax_v83 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj13 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ rax_v83 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1886 @ rdx_v97 (UnityEngine.Vector3)+18]");
							bool flag22 = num10 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ rax_v83 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj14 = (nint)0 * (nint)2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ rax_v83 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj15 = 0 + obj14;
							_ = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2871 @ rax_v157 (UnityEngine.RectTransform)+10]");
						bool flag23 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2871 @ rax_v157 (UnityEngine.RectTransform)+10]");
						RectTransform.get_sizeDelta_Injected((IntPtr)0, out Vector2 _);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2871 @ rax_v157 (UnityEngine.RectTransform)+10]");
						bool flag24 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2871 @ rax_v157 (UnityEngine.RectTransform)+10]");
						RectTransform.get_sizeDelta_Injected((IntPtr)0, out Vector2 _);
						num7 = -1000f - (float)obj16;
						TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(component5, (Vector2)enumerator2, 0.24f);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(component5, (Vector3)(&enumerator6), 0.24f);
						TweenCallback tweenCallback = null;
						nint num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3726 @ r10_v31 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass109_0._003CPerformReRoll_003Eb__1);
						((Delegate)tweenCallback).m_target = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
						list3 = (List<GameObject>)0;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3726 @ r10_v31 (Il2CppMethodInfo)+4C]");
						object obj17 = (nint)0 >> 4;
						object obj18 = obj17 & 1;
						nint num12;
						if (obj18 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3726 @ r10_v31 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num12 = unchecked((nint)6447293664L);
								goto IL_17b0;
							}
						}
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						num12 = ((Delegate)tweenCallback).method_ptr;
						goto IL_17b0;
						IL_17b0:
						nint num13 = 24;
						((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
						bool flag25 = tweenerCore2 == null;
						enumerator4 = enumerator2;
						num8 = 0.24f;
						if (!flag25)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4165 @ rax_v175 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							bool flag26 = (nint)0 == 0;
							enumerator4 = enumerator2;
							num8 = 0.24f;
							if (!flag26)
							{
								enumerator4 = enumerator2;
								num8 = 0.24f;
							}
						}
					}
					minorCardContainer = (Component)(object)_spawned;
					if (_spawned == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+18]");
					int num14 = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+18]");
					bool flag27 = (nint)0 <= (nint)0;
					bool flag28 = (byte)(int)list3 != 0;
					if (!flag27)
					{
						IntPtr cachedPtr = ((UnityEngine.Object)minorCardContainer).m_CachedPtr;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+18]");
						Array.Clear((Array)(nint)cachedPtr, 0, 0);
						flag28 = false;
						minorCardContainer = (Component)(nint)((UnityEngine.Object)minorCardContainer).m_CachedPtr;
					}
					List<ArcanaType> draftMajors2 = _draftMajors;
					if (_draftMajors == null)
					{
						break;
					}
					int num15 = 0;
					while (true)
					{
						int num16 = num15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rax_v92 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
						if ((nint)num16 >= (nint)0)
						{
							GameObject gameObject = SpawnBigCard(null, ArcanaType.VOID, isDum: true);
							bool flag29 = (object)gameObject == null;
							minorCardContainer = this;
							if (flag29)
							{
								break;
							}
							Button component6 = gameObject.GetComponent<Button>();
							bool flag30 = (object)component6 == null;
							minorCardContainer = (Component)(object)gameObject;
							if (flag30)
							{
								break;
							}
							component6.enabled = false;
							float num17 = (float)enumerator4;
							bool flag31 = true;
							TweenCallback tweenCallback2 = null;
						}
						else
						{
							_003C_003Ec__DisplayClass109_1 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass109_1();
							minorCardContainer = (Component)(object)_draftMajors;
							if (_draftMajors == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
							minorCardContainer = (Component)(object)_data;
							if (_data == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+188]");
							bool flag32 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+188]");
							minorCardContainer = (Component)0;
							if (flag32)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+188]");
							object data2 = ((Dictionary<System.Int32Enum, object>)0).get_Item(int32Enum);
							GameObject gameObject2 = SpawnBigCard((ArcanaData)data2, (ArcanaType)int32Enum);
							bool flag33 = (object)gameObject2 == null;
							minorCardContainer = this;
							if (flag33)
							{
								break;
							}
							ArcanaCardUI component7 = gameObject2.GetComponent<ArcanaCardUI>();
							bool flag34 = CS_0024_003C_003E8__locals5 == null;
							minorCardContainer = (Component)(object)gameObject2;
							if (flag34)
							{
								break;
							}
							CS_0024_003C_003E8__locals5.c = component7;
							TweenCallback onComplete = delegate
							{
								Tween tween4 = CS_0024_003C_003E8__locals5.c.Reveal();
							};
							int num18 = (int)(num15 & 0x80000003L);
							if ((nint)CS_0024_003C_003E8__locals5 < 0)
							{
								object obj19 = num18 - 1;
								object obj20 = obj19 | -4;
								num18 = obj20 + 1;
							}
							object obj21 = num18 + 1;
							float num19 = (float)obj21 * 50f;
							Tween tween = UITimerHelper.RegisterMillis(num19, onComplete);
							if (num15 == 0)
							{
								TweenCallback onComplete2 = delegate
								{
									Selectable component12 = CS_0024_003C_003E8__locals5.c.GetComponent<Selectable>();
									component12.Select();
								};
								Tween tween2 = UITimerHelper.RegisterMillis(50f, onComplete2);
								float num17 = 50f;
								bool flag31 = false;
								TweenCallback tweenCallback2 = null;
							}
							else
							{
								float num17 = num19;
								bool flag31 = false;
								TweenCallback tweenCallback2 = null;
							}
						}
						minorCardContainer = (Component)(object)_spawned;
						if (_spawned == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if ((object)gameObject3 == null)
						{
							break;
						}
						RectTransform component8 = gameObject3.GetComponent<RectTransform>();
						bool flag35 = (object)component8 == null;
						minorCardContainer = (Component)(object)gameObject3;
						if (flag35)
						{
							break;
						}
						component8.anchoredPosition = (Vector2)enumerator2;
						bool flag36 = list2 == null;
						minorCardContainer = component8;
						if (flag36)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049EB60");
						enumerator4 = (List<GameObject>.Enumerator)obj22;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOMove(component8, (Vector3)(&enumerator6), 0.24f);
						bool flag37 = !_hasUnlockedDarkanas;
						num14 = num15;
						minorCardContainer = component8;
						if (!flag37)
						{
							component8.sizeDelta = (Vector2)enumerator2;
							enumerator4 = enumerator2;
							num14 = 0;
							minorCardContainer = component8;
						}
						num15++;
						bool flag38 = num15 < (nint)obj2;
						num8 = 0.24f;
						flag28 = false;
						if (flag38)
						{
							continue;
						}
						List<GameObject> spawned = _spawned;
						if (_spawned == null)
						{
							break;
						}
						bool flag39 = spawned._size <= 0;
						minorCardContainer = (Component)(object)spawned._items;
						if (spawned._items == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+20]");
						bool flag40 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+20]");
						minorCardContainer = (Component)0;
						if (flag40)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+20]");
						Selectable component9 = ((GameObject)0).GetComponent<Selectable>();
						bool flag41 = (object)component9 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+20]");
						minorCardContainer = (Component)0;
						if (flag41)
						{
							break;
						}
						component9.Select();
						List<ArcanaType> draftMajors3 = _draftMajors;
						bool flag42 = _draftMajors == null;
						minorCardContainer = component9;
						if (flag42)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v105 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
						bool flag43 = (nint)0 <= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v105 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
						object obj23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v105 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
						bool flag44 = (nint)0 == 0;
						minorCardContainer = component9;
						if (flag44)
						{
							break;
						}
						DataManager data3 = _data;
						bool flag45 = _data == null;
						minorCardContainer = component9;
						if (flag45)
						{
							break;
						}
						bool flag46 = data3._003CAllArcanas_003Ek__BackingField == null;
						minorCardContainer = (Component)(object)data3._003CAllArcanas_003Ek__BackingField;
						if (flag46)
						{
							break;
						}
						Dictionary<ArcanaType, ArcanaData> dictionary = data3._003CAllArcanas_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v927 @ rax_v106+20]");
						object data4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
						minorCardContainer = (Component)(object)_spawned;
						if (_spawned == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+18]");
						bool flag47 = (nint)0 <= (nint)0;
						minorCardContainer = (Component)(nint)((UnityEngine.Object)minorCardContainer).m_CachedPtr;
						if (((UnityEngine.Object)minorCardContainer).m_CachedPtr == (IntPtr)0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+20]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v64 (UnityEngine.Component)+20]");
						ArcanaCardUI component10 = ((GameObject)0).GetComponent<ArcanaCardUI>();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v927 @ rax_v106+20]");
						SetInfo((ArcanaData)data4, ArcanaType.T00_KILLER, component10);
						TweenCallback tweenCallback3 = null;
						nint num20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4363 @ r9_v39 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback3).method = (nint)__ldftn(ArcanaMainSelectionPage._003CPerformReRoll_003Eb__109_0);
						((Delegate)tweenCallback3).m_target = this;
						((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4363 @ r9_v39 (Il2CppMethodInfo)+4C]");
						object obj24 = (nint)0 >> 4;
						object obj25 = obj24 & 1;
						nint num21;
						if (obj25 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4363 @ r9_v39 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num21 = unchecked((nint)6447293664L);
								goto IL_18f0;
							}
						}
						((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
						num21 = ((Delegate)tweenCallback3).method_ptr;
						goto IL_18f0;
						IL_18f0:
						Component component11 = (Component)24;
						((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
						minorCardContainer = (Component)24;
						Tween tween3 = DOVirtual.DelayedCall(0.24000001f, tweenCallback3);
						if (tween3 == null)
						{
							break;
						}
						tween3.stringId = "UI_CUSTOM_TIMER";
						SetBigCardNavigation();
						SetReRollButton();
						UpdateButtonNavigation();
						return;
					}
					break;
				}
			}
		}
		goto IL_146f;
		IL_146f:
		throw new NullReferenceException();
		IL_01c7:
		List<ArcanaType> draftMajors4 = _draftMajors;
		if (_draftMajors != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			if (0 < (nint)obj3)
			{
				return;
			}
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			if (_hasFreeReroll)
			{
				_hasFreeReroll = false;
				goto IL_156e;
			}
			float value = UnityEngine.Random.value;
			VampireSurvivors.Objects.Characters.CharacterController controllingCharacter = _controllingCharacter;
			bool flag48 = (object)_controllingCharacter == null;
			minorCardContainer = null;
			if (!flag48)
			{
				PlayerModifierStats playerStats = controllingCharacter._playerStats;
				bool flag49 = controllingCharacter._playerStats == null;
				minorCardContainer = null;
				if (!flag49)
				{
					if (!(value < playerStats._003CRecycle_003Ek__BackingField))
					{
						VampireSurvivors.Objects.Characters.CharacterController controllingCharacter2 = _controllingCharacter;
						GridLayoutGroup playerStats2 = (GridLayoutGroup)(object)controllingCharacter2._playerStats;
						EggFloat spacing = (EggFloat)playerStats2.m_Spacing;
						--spacing;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A8E780");
					}
					goto IL_156e;
				}
			}
		}
		goto IL_146f;
	}

	public void Reroll()
	{
		//IL_005a: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0118: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<ArcanaType> list = config._003CUnlockedArcanas_003Ek__BackingField;
		List<ArcanaType> draftMajors = _draftMajors;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		bool flag = (nint)0 > (nint)22;
		object obj = 6;
		if (!flag)
		{
			obj = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if (0 >= (nint)obj)
		{
			Button component = _RerollButton.GetComponent<Button>();
			component.interactable = false;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				PerformReRoll();
				return;
			}
			object instance = OnlineStageManager._instance;
			Action action = OnlineStageManager._instance.ReRollMinorArcanas;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v4 (System.Object)+78]");
			bool flag2 = ((CoherenceSync)0).SendCommand(action, MessageTarget.All);
		}
	}

	private unsafe void SetBigCardNavigation()
	{
		//IL_0218: Expected O, but got I4
		//IL_0226: Expected O, but got I4
		//IL_0096: Expected O, but got Ref
		//IL_012b: Expected O, but got I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_00fc: Expected O, but got I4
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_01d9: Expected O, but got I4
		//IL_01e2: Expected O, but got I4
		List<GameObject> spawned = _spawned;
		object obj = 0;
		Selectable left = null;
		object obj2 = 0;
		object obj3 = default(object);
		GameObject gameObject = default(GameObject);
		GameObject gameObject2 = default(GameObject);
		Selectable up = default(Selectable);
		while (true)
		{
			if ((nint)obj2 < spawned._size)
			{
				List<GameObject> spawned2 = _spawned;
				if ((nint)obj >= spawned2._size)
				{
					break;
				}
				GameObject[] items = spawned2._items;
				Selectable component = items[obj].GetComponent<Selectable>();
				component.navigation = (Navigation)(&obj3);
				bool flag = (nint)obj <= 0;
				Selectable selectable = null;
				object obj5;
				if (!flag)
				{
					object obj4 = obj - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component2 = gameObject.GetComponent<Selectable>();
					SetNavigationLeft(component, component2);
					obj5 = 0;
					selectable = component2;
				}
				List<GameObject> spawned3 = _spawned;
				object obj6 = spawned3._size - 1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
				{
					left = component;
				}
				else
				{
					object obj7 = obj + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component3 = gameObject2.GetComponent<Selectable>();
					SetNavigationRight(component, component3);
				}
				Selectable component4 = _MinorGetButton.GetComponent<Selectable>();
				SetNavigationDown(component, component4);
				spawned = _spawned;
				obj++;
				obj5 = 0;
				obj3 = 4;
				obj2 = obj;
				continue;
			}
			_DisplayContainer.ConfigureNavigationForArcanaCards(null, left, null, up);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected unsafe override void OnHideFinish(GameObject g)
	{
		//IL_0122->IL0122: Incompatible stack heights: 3 vs 0
		base.OnHideFinish(g);
		AddressableCache.ReleaseCustomOperationHandleGroup(_arcanaCacheGroupName);
		isShowingMinor = false;
		if (_d20Tween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_d20Tween);
		}
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		List<GameObject>.Enumerator value = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rbx_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rbx_v5 (System.Object)+10]");
			IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		}
	}

	private GameObject SpawnBigCard(ArcanaData data, ArcanaType type, bool isDum = false)
	{
		//IL_008b: Expected O, but got I4
		GameObject gameObject = UnityEngine.Object.Instantiate(_BigArcanaCard, _MinorCardContainer);
		if ((object)gameObject != null)
		{
			ArcanaCardUI component = gameObject.GetComponent<ArcanaCardUI>();
			if ((object)component != null)
			{
				if (isDum)
				{
					component.SetBackOnly();
					ISetArcanaInfo setArcanaInfo = (ISetArcanaInfo)isDum;
				}
				else
				{
					ArcanaType type2 = default(ArcanaType);
					bool isShowing = default(bool);
					component.SetData(data, type2, (ISetArcanaInfo)this, isShowing);
					ISetArcanaInfo setArcanaInfo = this;
				}
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					return gameObject;
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private unsafe void PopulateFirstMenu()
	{
		//IL_0290: Expected O, but got I4
		//IL_03f2: Expected O, but got I
		//IL_030e: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		//IL_03a5: Expected O, but got I4
		//IL_0524: Expected O, but got I
		//IL_08c4: Expected O, but got Ref
		//IL_1d6e: Expected O, but got Ref
		//IL_08ea: Expected O, but got Ref
		//IL_0a0a: Expected O, but got Ref
		//IL_0a30: Expected O, but got Ref
		//IL_0ac1: Expected F4, but got I4
		//IL_0b17: Expected O, but got I4
		//IL_0bac: Expected I4, but got I8
		//IL_1e0c: Expected O, but got I4
		//IL_0df7: Expected I, but got O
		//IL_0dde: Expected I, but got O
		//IL_0ea7: Expected O, but got Ref
		//IL_1ec7: Expected O, but got Ref
		//IL_0ecb: Expected O, but got Ref
		//IL_0faa: Expected I4, but got O
		//IL_0faa: Expected O, but got Ref
		//IL_0eef: Expected O, but got I
		//IL_0f00: Expected O, but got I
		//IL_1f59: Expected O, but got Ref
		//IL_1014: Expected O, but got I
		//IL_104a: Expected O, but got I
		//IL_1f75: Expected I, but got O
		//IL_1f79: Expected O, but got I4
		//IL_1088: Expected O, but got I
		//IL_10be: Expected O, but got I
		//IL_1fb6: Expected I, but got O
		//IL_1fba: Expected O, but got I4
		//IL_1fcf: Expected I4, but got O
		//IL_1fdd: Expected I4, but got O
		//IL_1fdd: Expected O, but got Ref
		//IL_10f4: Expected O, but got Ref
		//IL_1104: Expected O, but got I
		//IL_12a2: Expected O, but got I
		//IL_12d4: Expected O, but got I
		//IL_113a: Expected O, but got I
		//IL_132a: Expected O, but got I
		//IL_1186: Expected O, but got I
		//IL_11a1: Expected O, but got Ref
		//IL_1370: Unknown result type (might be due to invalid IL or missing references)
		//IL_1375: Expected I4, but got Unknown
		//IL_154c: Expected I, but got O
		//IL_1555: Expected O, but got I4
		//IL_1525: Expected I, but got O
		//IL_152e: Expected O, but got I4
		//IL_1575: Expected O, but got I4
		//IL_207c: Expected O, but got Ref
		//IL_159b: Expected I, but got O
		//IL_20c0: Expected I4, but got O
		//IL_210a: Expected I, but got O
		//IL_23e0: Expected O, but got I
		//IL_1950: Expected I, but got O
		//IL_1760: Expected I, but got O
		//IL_2411: Expected O, but got I
		//IL_1fa3->IL1c76: Incompatible stack heights: 1 vs 0
		//IL_13df->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_1415->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_13b6->IL1fed: Incompatible stack heights: 5 vs 2
		//IL_1447->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_147d->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_14af->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_14e5->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_2037->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_2085->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_15cf->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_1605->IL1c76: Incompatible stack heights: 2 vs 0
		//IL_20c5->IL23aa: Incompatible stack heights: 3 vs 2
		//IL_16de->IL214d: Incompatible stack heights: 5 vs 4
		//IL_1890->IL1946: Incompatible stack heights: 7 vs 5
		//IL_1c5e->IL237b: Incompatible stack heights: 9 vs 7
		//IL_18b9->IL1946: Incompatible stack heights: 7 vs 5
		//IL_1845->IL217a: Incompatible stack heights: 7 vs 6
		//IL_1946->IL217f: Incompatible stack heights: 8 vs 7
		//IL_190d->IL217f: Incompatible stack heights: 8 vs 7
		//IL_2359->IL2432: Incompatible stack heights: 30 vs 7
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				_lastSelected = config._003CSelectedArcana_003Ek__BackingField;
				PlayJingle();
				_ShowDarkanaFirst = false;
				PlayerOptions playerOptions2 = _playerOptions;
				bool flag = _playerOptions == null;
				playerOptions = (PlayerOptions)(object)this;
				if (!flag)
				{
					PlayerOptionsData mainGameConfig = playerOptions2._mainGameConfig;
					bool flag2 = playerOptions2._mainGameConfig == null;
					playerOptions = (PlayerOptions)(object)this;
					if (!flag2)
					{
						playerOptions = _playerOptions;
						PlayerOptionsData config2 = _playerOptions.Config;
						if (config2 != null)
						{
							if (!config2.HasCollectedItem(ItemType.RELIC_DARKASSO) || mainGameConfig._003CHasSeenDarkanaTransition_003Ek__BackingField)
							{
								goto IL_0215;
							}
							playerOptions = _playerOptions;
							if (_playerOptions != null)
							{
								PlayerOptionsData config3 = _playerOptions.Config;
								if (config3 != null)
								{
									if (!config3.HasCollectedItem(ItemType.RELIC_RANDOMAZZO))
									{
										goto IL_0215;
									}
									CanvasGroup component = GetComponent<CanvasGroup>();
									bool flag3 = (object)component == null;
									playerOptions = (PlayerOptions)(object)this;
									if (!flag3)
									{
										component.interactable = false;
										_willPlayDarkanaIntro = true;
										object obj = 0;
										goto IL_1cfe;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1c76;
		IL_1cfe:
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		IntPtr intPtr = default(IntPtr);
		object arg2 = default(object);
		string text = $"Darkana Status - ShowDarkanaFirst: {arg}, WillPlayDarkanaIntro: {(nint)intPtr}, LastSelected: {arg2}, ";
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			if (config4 != null)
			{
				bool flag4 = config4.HasCollectedItem(ItemType.RELIC_RANDOMAZZO);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
				playerOptions = _playerOptions;
				if (_playerOptions != null)
				{
					PlayerOptionsData config5 = _playerOptions.Config;
					if (config5 != null)
					{
						bool flag5 = config5.HasCollectedItem(ItemType.RELIC_DARKASSO);
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
						string text2 = default(string);
						IntPtr intPtr2 = default(IntPtr);
						string text3 = default(string);
						string message = text + text2 + (string)(nint)intPtr2 + text3;
						Debug.Log(message);
						if (!_ShowDarkanaFirst)
						{
							SetLightDesign();
						}
						else
						{
							SetDarkDesign();
							_arcanaMode = ArcanaMode.DARK;
							OnArcanaModeChange arcanaModeChanged = ArcanaMainSelectionPage.m_ArcanaModeChanged;
							if (ArcanaMainSelectionPage.m_ArcanaModeChanged != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3507.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							}
						}
						_hasFinishedPopulationAnimation = false;
						bool flag6 = (object)_RandomButton == null;
						playerOptions = (PlayerOptions)(object)_RandomButton;
						if (!flag6)
						{
							Button component2 = _RandomButton.GetComponent<Button>();
							bool flag7 = (object)component2 == null;
							playerOptions = (PlayerOptions)(object)_RandomButton;
							if (!flag7)
							{
								component2.interactable = false;
								bool flag8 = (object)_GetButton == null;
								playerOptions = (PlayerOptions)(object)_GetButton;
								if (!flag8)
								{
									Button component3 = _GetButton.GetComponent<Button>();
									bool flag9 = (object)component3 == null;
									playerOptions = (PlayerOptions)(object)_GetButton;
									if (!flag9)
									{
										component3.interactable = false;
										_hasPickedRandom = false;
										bool flag10 = (object)_CharacterStatsPanel == null;
										playerOptions = (PlayerOptions)(object)_CharacterStatsPanel;
										if (!flag10)
										{
											_CharacterStatsPanel.SetActive(value: false);
											bool flag11 = (object)_EquipmentPanel == null;
											playerOptions = (PlayerOptions)(object)_EquipmentPanel;
											if (!flag11)
											{
												GameObject gameObject = _EquipmentPanel.gameObject;
												bool flag12 = (object)gameObject == null;
												playerOptions = (PlayerOptions)(object)_EquipmentPanel;
												if (!flag12)
												{
													gameObject.SetActive(value: false);
													bool flag13 = (object)_RandomButton == null;
													playerOptions = (PlayerOptions)(object)_RandomButton;
													if (!flag13)
													{
														Button component4 = _RandomButton.GetComponent<Button>();
														bool flag14 = (object)component4 == null;
														playerOptions = (PlayerOptions)(object)_RandomButton;
														if (!flag14)
														{
															component4.enabled = true;
															bool flag15 = (object)_GetButton == null;
															playerOptions = (PlayerOptions)(object)_GetButton;
															if (!flag15)
															{
																Button component5 = _GetButton.GetComponent<Button>();
																bool flag16 = (object)component5 == null;
																playerOptions = (PlayerOptions)(object)_GetButton;
																if (!flag16)
																{
																	component5.enabled = true;
																	bool flag17 = (object)_CollectRandomButton == null;
																	playerOptions = (PlayerOptions)(object)_CollectRandomButton;
																	if (!flag17)
																	{
																		Button component6 = _CollectRandomButton.GetComponent<Button>();
																		bool flag18 = (object)component6 == null;
																		playerOptions = (PlayerOptions)(object)_CollectRandomButton;
																		if (!flag18)
																		{
																			component6.enabled = true;
																			bool flag19 = (object)_MajorBackground == null;
																			playerOptions = (PlayerOptions)(object)_MajorBackground;
																			if (!flag19)
																			{
																				Transform transform = _MajorBackground.transform;
																				bool flag20 = (object)transform == null;
																				playerOptions = (PlayerOptions)(object)_MajorBackground;
																				if (!flag20)
																				{
																					List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
																					transform.localEulerAngles = (Vector3)(&enumerator);
																					Vector3 vector = default(Vector3);
																					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_MajorBackground, (Vector3)(&vector), 0.2f);
																					bool flag21 = (object)_MajorBackground == null;
																					playerOptions = (PlayerOptions)(object)_MajorBackground;
																					if (!flag21)
																					{
																						Transform transform2 = _MajorBackground.transform;
																						Vector3 vector2 = default(Vector3);
																						transform2.localScale = (Vector3)(&vector2);
																						Transform target = _MajorBackground.transform;
																						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 1f, 0.2f);
																						Transform transform3 = _DisplayContainer.transform;
																						GameObject gameObject2 = transform3.gameObject;
																						gameObject2.SetActive(value: false);
																						_MajorSelectionGroup.SetActive(value: true);
																						_MinorSelectionGroup.SetActive(value: false);
																						GameObject gameObject3 = _Count.gameObject;
																						gameObject3.SetActive(value: true);
																						GridLayoutGroup component7 = _CardContainer.GetComponent<GridLayoutGroup>();
																						component7.enabled = true;
																						bool active = IsLocalPlayerControllingUi();
																						_GetButton.SetActive(active);
																						Transform transform4 = _GetButton.transform;
																						Vector3 vector3 = default(Vector3);
																						transform4.localScale = (Vector3)(&vector3);
																						Transform transform5 = _RandomButton.transform;
																						Vector3 vector4 = default(Vector3);
																						transform5.localScale = (Vector3)(&vector4);
																						bool active2 = IsLocalPlayerControllingUi();
																						_RandomButton.SetActive(active2);
																						CanvasGroup component8 = _RandomButton.GetComponent<CanvasGroup>();
																						bool interactable = !_willPlayDarkanaIntro;
																						component8.interactable = interactable;
																						CanvasGroup component9 = _RandomButton.GetComponent<CanvasGroup>();
																						float alpha = ((!_willPlayDarkanaIntro) ? 1f : 0f);
																						bool flag22 = (object)component9 == null;
																						playerOptions = (PlayerOptions)(object)_RandomButton;
																						if (!flag22)
																						{
																							component9.alpha = alpha;
																							if (!_willPlayDarkanaIntro)
																							{
																								SetRandomButton();
																							}
																							object obj2 = 0;
																							int num = 0;
																							ArcanaType arcanaType = ArcanaType.T00_KILLER;
																							int num2 = 0;
																							object obj4 = default(object);
																							object obj6 = default(object);
																							int num8 = default(int);
																							List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
																							List<GameObject>.Enumerator enumerator4 = default(List<GameObject>.Enumerator);
																							float delay = default(float);
																							bool isWorldPos = default(bool);
																							List<GameObject>.Enumerator anchoredPosition = default(List<GameObject>.Enumerator);
																							float num9 = default(float);
																							List<GameObject>.Enumerator enumerator5 = default(List<GameObject>.Enumerator);
																							object obj11 = default(object);
																							List<GameObject>.Enumerator enumerator6 = default(List<GameObject>.Enumerator);
																							List<GameObject>.Enumerator enumerator7 = default(List<GameObject>.Enumerator);
																							List<GameObject>.Enumerator value2 = default(List<GameObject>.Enumerator);
																							while (true)
																							{
																								string text4 = num.ToString();
																								nint num3 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rbx_v51 (Il2CppMethodInfo)+38]");
																								if ((nint)0 == 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																								}
																								bool flag23 = Enum.TryParse<ArcanaType>(text4, ignoreCase: false, out var result);
																								bool flag24 = !flag23;
																								object value = null;
																								System.Int32Enum int32Enum = (System.Int32Enum)(-1);
																								ArcanaType arcanaType2;
																								ArcanaData data2;
																								if (!flag24)
																								{
																									DataManager data = _data;
																									bool flag25 = _data == null;
																									playerOptions = (PlayerOptions)(object)text4;
																									if (flag25)
																									{
																										break;
																									}
																									bool flag26 = data._003CAllArcanas_003Ek__BackingField == null;
																									playerOptions = (PlayerOptions)(object)data._003CAllArcanas_003Ek__BackingField;
																									if (flag26)
																									{
																										break;
																									}
																									bool flag27 = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllArcanas_003Ek__BackingField).TryGetValue((System.Int32Enum)result, out value);
																									bool flag28 = 0 == 0;
																									arcanaType2 = result;
																									data2 = null;
																									if (flag28)
																									{
																										goto IL_1dd4;
																									}
																									playerOptions = _playerOptions;
																									if (_playerOptions == null)
																									{
																										break;
																									}
																									PlayerOptionsData config6 = _playerOptions.Config;
																									if (config6 == null)
																									{
																										break;
																									}
																									bool flag29 = config6._003CUnlockedArcanas_003Ek__BackingField == null;
																									playerOptions = (PlayerOptions)(object)config6._003CUnlockedArcanas_003Ek__BackingField;
																									if (flag29)
																									{
																										break;
																									}
																									if (!((Dictionary<ArcanaType, ArcanaData>)(object)config6._003CUnlockedArcanas_003Ek__BackingField).TryGetValue(result, out *(ArcanaData*)(&value)))
																									{
																										bool flag30 = 0 == 0;
																										playerOptions = (PlayerOptions)(object)config6._003CUnlockedArcanas_003Ek__BackingField;
																										if (flag30)
																										{
																											break;
																										}
																										bool flag31 = !((ArcanaData)value)._003Cunlocked_003Ek__BackingField;
																										arcanaType2 = result;
																										data2 = null;
																										if (flag31)
																										{
																											goto IL_1dd4;
																										}
																									}
																									bool flag32 = 0 == 0;
																									playerOptions = (PlayerOptions)(object)config6._003CUnlockedArcanas_003Ek__BackingField;
																									if (flag32)
																									{
																										break;
																									}
																									((ArcanaData)value)._003Cunlocked_003Ek__BackingField = true;
																									int32Enum = (System.Int32Enum)result;
																								}
																								arcanaType2 = (ArcanaType)int32Enum;
																								data2 = null;
																								goto IL_1dd4;
																								IL_23d0:
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2974 @ rbx_v64 (Il2CppMethodInfo)+188]");
																								object obj3 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2974 @ rbx_v64 (Il2CppMethodInfo)+188]");
																								bool flag33 = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3047 @ rcx_v194+18]");
																								if ((nint)0 != 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
																									if ((nint)obj4 != -1)
																									{
																										nint num4 = (nint)_playerOptions;
																										bool flag34 = _playerOptions == null;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2975 @ rbx_v76 (Il2CppMethodInfo)+68]");
																										if ((nint)0 == 0)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2975 @ rbx_v76 (Il2CppMethodInfo)+58]");
																											if ((nint)0 == 0)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2975 @ rbx_v76 (Il2CppMethodInfo)+78]");
																												nint num6;
																												if ((nint)0 != 0)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2975 @ rbx_v76 (Il2CppMethodInfo)+78]");
																													nint num5 = 0;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6329 @ rax_v338 (Il2CppMethodInfo)+2CC]");
																													if ((nint)0 != 0)
																													{
																														num6 = num5;
																														goto IL_2401;
																													}
																												}
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2975 @ rbx_v76 (Il2CppMethodInfo)+50]");
																												num6 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2975 @ rbx_v76 (Il2CppMethodInfo)+50]");
																												bool flag35 = (nint)0 == 0;
																											}
																											else
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2975 @ rbx_v76 (Il2CppMethodInfo)+58]");
																												nint num6 = 0;
																											}
																										}
																										else
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2975 @ rbx_v76 (Il2CppMethodInfo)+68]");
																											nint num6 = 0;
																										}
																										goto IL_2401;
																									}
																								}
																								goto IL_1946;
																								IL_2401:
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2977 @ rbx_v77 (Il2CppMethodInfo)+188]");
																								object obj5 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2977 @ rbx_v77 (Il2CppMethodInfo)+188]");
																								bool flag36 = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3050 @ rcx_v260+18]");
																								if ((nint)0 != 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
																									if ((nint)obj6 != -1)
																									{
																										if (_willPlayDarkanaIntro)
																										{
																											bool flag37 = (object)_DarkButton == null;
																											_DarkButton.SetActive(value: false);
																										}
																										else
																										{
																											bool active3 = IsLocalPlayerControllingUi();
																											bool flag38 = (object)_DarkButton == null;
																											_DarkButton.SetActive(active3);
																										}
																										goto IL_217f;
																									}
																								}
																								goto IL_1946;
																								IL_1dd4:
																								ArcanaCardUI arcanaCardUI = SpawnArcanaCard(data2, arcanaType2);
																								num2++;
																								bool flag39 = num2 < 44;
																								obj2 = 0;
																								num = num2;
																								arcanaType = arcanaType2;
																								if (flag39)
																								{
																									continue;
																								}
																								List<GameObject> list;
																								nint num7;
																								if (_ShowDarkanaFirst)
																								{
																									list = _darkSpawned;
																									num7 = (nint)_spawned;
																								}
																								else
																								{
																									list = _spawned;
																									num7 = (nint)_darkSpawned;
																								}
																								List<object> allSpawnedInOrder = (List<object>)(object)_allSpawnedInOrder;
																								bool flag40 = _allSpawnedInOrder == null;
																								playerOptions = (PlayerOptions)(object)_allSpawnedInOrder;
																								if (flag40)
																								{
																									break;
																								}
																								((List<object>)(object)_allSpawnedInOrder).InsertRange(allSpawnedInOrder._size, (IEnumerable<object>)_spawned);
																								List<object> allSpawnedInOrder2 = (List<object>)(object)_allSpawnedInOrder;
																								bool flag41 = _allSpawnedInOrder == null;
																								playerOptions = (PlayerOptions)(object)_allSpawnedInOrder;
																								if (flag41)
																								{
																									break;
																								}
																								IEnumerable<object> collection = _darkSpawned;
																								((List<object>)(object)_allSpawnedInOrder).InsertRange(allSpawnedInOrder2._size, (IEnumerable<object>)_darkSpawned);
																								bool flag42 = num7 == 0;
																								playerOptions = (PlayerOptions)(object)_allSpawnedInOrder;
																								if (flag42)
																								{
																									break;
																								}
																								((List<GameObject>)(&num8)).InsertRange((int)num7, _darkSpawned);
																								while (enumerator2.MoveNext())
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5499 @ rax_v194+10]");
																									bool flag43 = (nint)0 == 0;
																									List<GameObject>.Enumerator enumerator3 = (List<GameObject>.Enumerator)(&enumerator2);
																									if (!flag43)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5499 @ rax_v194+10]");
																										((GameObject)0).SetActive(value: false);
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5499 @ rax_v194+10]");
																										ArcanaCardUI component10 = ((GameObject)0).GetComponent<ArcanaCardUI>();
																										if ((object)component10 != null)
																										{
																											bool flag44 = component10._data == null;
																											collection = null;
																											if (!flag44)
																											{
																												ArcanaData data3 = component10._data;
																												bool flag45 = !data3._003Cunlocked_003Ek__BackingField;
																												collection = null;
																												if (!flag45)
																												{
																													component10.SetOpen();
																													collection = null;
																												}
																											}
																											continue;
																										}
																										throw new NullReferenceException();
																									}
																									throw new NullReferenceException();
																								}
																								bool flag46 = list == null;
																								playerOptions = (PlayerOptions)(&enumerator2);
																								if (flag46)
																								{
																									break;
																								}
																								((List<GameObject>)(&num8)).InsertRange((int)list, (IEnumerable<GameObject>)collection);
																								while (enumerator4.MoveNext())
																								{
																									_003C_003Ec__DisplayClass114_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass114_0();
																									bool flag47 = CS_0024_003C_003E8__locals12 == null;
																									GameObject typeFromHandle = (GameObject)(object)typeof(_003C_003Ec__DisplayClass114_0);
																									if (!flag47)
																									{
																										CS_0024_003C_003E8__locals12._003C_003E4__this = this;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5552 @ rax_v198+10]");
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																										typeFromHandle = (GameObject)0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																										if ((nint)0 != 0)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																											Transform transform6 = ((GameObject)0).transform;
																											if ((object)transform6 != null)
																											{
																												Vector3 position = transform6.position;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																												typeFromHandle = (GameObject)0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																												if ((nint)0 != 0)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																													TweenToLayoutGroup tweenToLayoutGroup = ((GameObject)0).AddComponent<TweenToLayoutGroup>();
																													Transform sender = base.transform;
																													if ((object)tweenToLayoutGroup != null)
																													{
																														tweenToLayoutGroup.TweenFromLocationToLayoutSpot(sender, (Vector3)(&vector4), 0.24f, delay, isWorldPos);
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																														typeFromHandle = (GameObject)0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																														if ((nint)0 != 0)
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																															RectTransform component11 = ((GameObject)0).GetComponent<RectTransform>();
																															if ((object)component11 != null)
																															{
																																component11.anchoredPosition = (Vector2)anchoredPosition;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																																if ((nint)0 != 0)
																																{
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v367 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_0)+10]");
																																	Transform target2 = ((GameObject)0).transform;
																																	TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMove(target2, (Vector3)(&num9), 0.24f);
																																	TweenCallback action = delegate
																																	{
																																		//IL_01c4->IL0154: Incompatible stack heights: 1 vs 0
																																		//IL_0098->IL0154: Incompatible stack heights: 1 vs 0
																																		//IL_00b5->IL0154: Incompatible stack heights: 1 vs 0
																																		//IL_00eb->IL0154: Incompatible stack heights: 1 vs 0
																																		//IL_0117->IL0154: Incompatible stack heights: 1 vs 0
																																		if ((object)CS_0024_003C_003E8__locals12.v != null)
																																		{
																																			Transform transform10 = CS_0024_003C_003E8__locals12.v.transform;
																																			if ((object)transform10 != null)
																																			{
																																				Transform parent = transform10.parent;
																																				if ((object)parent != null)
																																				{
																																					bool flag100 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
																																					int siblingIndex_Injected = Transform.GetSiblingIndex_Injected(((UnityEngine.Object)parent).m_CachedPtr);
																																					if ((object)CS_0024_003C_003E8__locals12.v != null)
																																					{
																																						Transform transform11 = CS_0024_003C_003E8__locals12.v.transform;
																																						ArcanaMainSelectionPage arcanaMainSelectionPage = CS_0024_003C_003E8__locals12._003C_003E4__this;
																																						if ((object)CS_0024_003C_003E8__locals12._003C_003E4__this != null && (object)transform11 != null)
																																						{
																																							transform11.SetParent(arcanaMainSelectionPage._CardContainer, worldPositionStays: true);
																																							if ((object)CS_0024_003C_003E8__locals12.v != null)
																																							{
																																								Transform transform12 = CS_0024_003C_003E8__locals12.v.transform;
																																								if ((object)transform12 != null)
																																								{
																																									transform12.SetSiblingIndex(siblingIndex_Injected);
																																									GameObject obj14 = parent.gameObject;
																																									UnityEngine.Object.Destroy(obj14, 0f);
																																									return;
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																		throw new NullReferenceException();
																																	};
																																	TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = TweenSettingsExtensions.OnComplete(t, action);
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
																												throw new NullReferenceException();
																											}
																											throw new NullReferenceException();
																										}
																										throw new NullReferenceException();
																									}
																									throw new NullReferenceException();
																								}
																								bool flag48 = (object)_CardContainer == null;
																								playerOptions = (PlayerOptions)(&enumerator4);
																								if (flag48)
																								{
																									break;
																								}
																								Rect rect = _CardContainer.rect;
																								playerOptions = (PlayerOptions)(object)((LayoutGroup)component7).m_Padding;
																								if (((LayoutGroup)component7).m_Padding == null)
																								{
																									break;
																								}
																								bool flag49 = playerOptions.RunGoldUpdated == null;
																								object obj7 = RectOffset.get_left_Injected((IntPtr)playerOptions.RunGoldUpdated);
																								playerOptions = (PlayerOptions)(object)((LayoutGroup)component7).m_Padding;
																								if (((LayoutGroup)component7).m_Padding == null)
																								{
																									break;
																								}
																								bool flag50 = playerOptions.RunGoldUpdated == null;
																								object obj8 = RectOffset.get_right_Injected((IntPtr)playerOptions.RunGoldUpdated);
																								((List<GameObject>)(object)playerOptions.RunGoldUpdated).InsertRange((int)_CardContainer, (IEnumerable<GameObject>)null);
																								((List<GameObject>)(&num8)).InsertRange((int)list, null);
																								int num10 = 0;
																								while (enumerator5.MoveNext())
																								{
																									_003C_003Ec__DisplayClass114_1 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass114_1();
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5661 @ rax_v210+10]");
																									bool flag51 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5661 @ rax_v210+10]");
																									ArcanaCardUI component12 = ((GameObject)0).GetComponent<ArcanaCardUI>();
																									bool flag52 = CS_0024_003C_003E8__locals13 == null;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2423 @ rax_v356 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_1)+10]");
																									object obj9 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2423 @ rax_v356 (VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass114_1)+10]");
																									bool flag53 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2231 @ r9_v69+118]");
																									if ((nint)0 != 0)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2231 @ r9_v69+118]");
																										object obj10 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5791 @ rcx_v283+49]");
																										if ((nint)0 != 0)
																										{
																											TweenCallback onComplete = delegate
																											{
																												Tween tween3 = CS_0024_003C_003E8__locals13.card.Reveal();
																											};
																											int num11 = num10 % obj11;
																											float duration = (float)num11 * 30f;
																											Tween tween = UITimerHelper.RegisterMillis(duration, onComplete);
																										}
																									}
																									num10++;
																								}
																								TweenCallback onComplete2 = delegate
																								{
																									SynchronizationContext.CurrentNoFlow?.OperationStarted();
																									AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
																									_003C_003CEnableInputFirstMenu_003Eb__115_0_003Ed stateMachine = default(_003C_003CEnableInputFirstMenu_003Eb__115_0_003Ed);
																									asyncVoidMethodBuilder.Start(ref stateMachine);
																								};
																								Tween tween2 = UITimerHelper.RegisterMillis(500f, onComplete2);
																								bool flag54 = (object)_RandomButton == null;
																								playerOptions = (PlayerOptions)(object)_RandomButton;
																								if (flag54)
																								{
																									break;
																								}
																								Transform transform7 = _RandomButton.transform;
																								bool flag55 = (object)transform7 == null;
																								playerOptions = (PlayerOptions)(object)_RandomButton;
																								if (flag55)
																								{
																									break;
																								}
																								transform7.SetAsLastSibling();
																								bool flag56 = (object)_GetButton == null;
																								playerOptions = (PlayerOptions)(object)_GetButton;
																								if (flag56)
																								{
																									break;
																								}
																								Transform transform8 = _GetButton.transform;
																								bool flag57 = (object)transform8 == null;
																								playerOptions = (PlayerOptions)(object)_GetButton;
																								if (flag57)
																								{
																									break;
																								}
																								transform8.SetAsLastSibling();
																								bool flag58 = (object)_DarkButton == null;
																								playerOptions = (PlayerOptions)(object)_DarkButton;
																								if (flag58)
																								{
																									break;
																								}
																								Transform transform9 = _DarkButton.transform;
																								bool flag59 = (object)transform9 == null;
																								playerOptions = (PlayerOptions)(object)_DarkButton;
																								if (flag59)
																								{
																									break;
																								}
																								transform9.SetAsLastSibling();
																								SetCount();
																								nint num12;
																								object obj12;
																								if (_arcanaMode == ArcanaMode.LIGHT)
																								{
																									num12 = unchecked((nint)null);
																									obj12 = 1;
																								}
																								else
																								{
																									bool flag60 = _arcanaMode != ArcanaMode.DARK;
																									num12 = unchecked((nint)null);
																									obj12 = 0;
																									if (!flag60)
																									{
																										num12 = 1;
																										obj12 = 0;
																									}
																								}
																								bool flag61 = _darkSpawned == null;
																								playerOptions = (PlayerOptions)(object)this;
																								if (flag61)
																								{
																									break;
																								}
																								while (enumerator6.MoveNext())
																								{
																									((GameObject)null).SetActive((byte)num12 != 0);
																								}
																								bool flag62 = _spawned == null;
																								playerOptions = (PlayerOptions)(&enumerator6);
																								if (flag62)
																								{
																									break;
																								}
																								while (enumerator7.MoveNext())
																								{
																									nint num13 = unchecked((nint)null);
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2559 @ rbx_v87 (Il2CppMethodInfo)+10]");
																									bool flag63 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2559 @ rbx_v87 (Il2CppMethodInfo)+10]");
																									GameObject.SetActive_Injected((IntPtr)0, (byte)(int)obj12 != 0);
																								}
																								bool flag64 = (object)_CollectRandomButton == null;
																								playerOptions = (PlayerOptions)(object)_CollectRandomButton;
																								if (flag64)
																								{
																									break;
																								}
																								RectTransform component13 = _CollectRandomButton.GetComponent<RectTransform>();
																								bool flag65 = (object)component13 == null;
																								playerOptions = (PlayerOptions)(object)_CollectRandomButton;
																								if (flag65)
																								{
																									break;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1059 @ rax_v240 (UnityEngine.RectTransform)+10]");
																								bool flag66 = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1059 @ rax_v240 (UnityEngine.RectTransform)+10]");
																								RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref *(Vector2*)(&value2));
																								nint num14 = (nint)_playerOptions;
																								bool flag67 = _playerOptions == null;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2987 @ rbx_v63 (Il2CppMethodInfo)+68]");
																								if ((nint)0 == 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2987 @ rbx_v63 (Il2CppMethodInfo)+58]");
																									if ((nint)0 == 0)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2987 @ rbx_v63 (Il2CppMethodInfo)+78]");
																										nint num16;
																										if ((nint)0 != 0)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2987 @ rbx_v63 (Il2CppMethodInfo)+78]");
																											nint num15 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6102 @ rax_v342 (Il2CppMethodInfo)+2CC]");
																											if ((nint)0 != 0)
																											{
																												num16 = num15;
																												goto IL_23d0;
																											}
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2987 @ rbx_v63 (Il2CppMethodInfo)+50]");
																										num16 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2987 @ rbx_v63 (Il2CppMethodInfo)+50]");
																										bool flag68 = (nint)0 == 0;
																									}
																									else
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2987 @ rbx_v63 (Il2CppMethodInfo)+58]");
																										nint num16 = 0;
																									}
																								}
																								else
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2987 @ rbx_v63 (Il2CppMethodInfo)+68]");
																									nint num16 = 0;
																								}
																								goto IL_23d0;
																								IL_1946:
																								nint num17 = (nint)_DarkButton;
																								bool flag69 = (object)_DarkButton == null;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2979 @ rbx_v75 (Il2CppMethodInfo)+10]");
																								bool flag70 = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2979 @ rbx_v75 (Il2CppMethodInfo)+10]");
																								GameObject.SetActive_Injected((IntPtr)0, false);
																								goto IL_217f;
																								IL_217f:
																								if (_hasUnlockedDarkanas)
																								{
																									LayoutRebuilder.ForceRebuildLayoutImmediate(_CardContainer);
																									bool flag71 = (object)_RandomButton == null;
																									LayoutElement component14 = _RandomButton.GetComponent<LayoutElement>();
																									bool flag72 = (object)component14 == null;
																									component14.ignoreLayout = true;
																									bool flag73 = (object)_GetButton == null;
																									LayoutElement component15 = _GetButton.GetComponent<LayoutElement>();
																									bool flag74 = (object)component15 == null;
																									component15.ignoreLayout = true;
																									bool flag75 = (object)_DarkButton == null;
																									LayoutElement component16 = _DarkButton.GetComponent<LayoutElement>();
																									bool flag76 = (object)component16 == null;
																									component16.ignoreLayout = true;
																									bool flag77 = (object)_RandomButton == null;
																									RectTransform component17 = _RandomButton.GetComponent<RectTransform>();
																									bool flag78 = (object)component17 == null;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3393 @ rax_v273 (UnityEngine.RectTransform)+10]");
																									bool flag79 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3393 @ rax_v273 (UnityEngine.RectTransform)+10]");
																									RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref *(Vector2*)(&value2));
																									bool flag80 = (object)_GetButton == null;
																									RectTransform component18 = _GetButton.GetComponent<RectTransform>();
																									bool flag81 = (object)component18 == null;
																									component18.anchoredPosition = (Vector2)anchoredPosition;
																									bool flag82 = (object)_DarkButton == null;
																									RectTransform component19 = _DarkButton.GetComponent<RectTransform>();
																									bool flag83 = (object)component19 == null;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3396 @ rax_v280 (UnityEngine.RectTransform)+10]");
																									bool flag84 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3396 @ rax_v280 (UnityEngine.RectTransform)+10]");
																									RectTransform.set_anchorMax_Injected((IntPtr)0, ref *(Vector2*)(&value2));
																									bool flag85 = (object)_DarkButton == null;
																									RectTransform component20 = _DarkButton.GetComponent<RectTransform>();
																									bool flag86 = (object)component20 == null;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3397 @ rax_v285 (UnityEngine.RectTransform)+10]");
																									bool flag87 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3397 @ rax_v285 (UnityEngine.RectTransform)+10]");
																									RectTransform.set_anchorMin_Injected((IntPtr)0, ref *(Vector2*)(&value2));
																									bool flag88 = (object)_DarkButton == null;
																									RectTransform component21 = _DarkButton.GetComponent<RectTransform>();
																									bool flag89 = (object)component21 == null;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3398 @ rax_v290 (UnityEngine.RectTransform)+10]");
																									bool flag90 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3398 @ rax_v290 (UnityEngine.RectTransform)+10]");
																									RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref *(Vector2*)(&value2));
																									bool flag91 = (object)_DarkButton == null;
																									RectTransform component22 = _DarkButton.GetComponent<RectTransform>();
																									bool flag92 = (object)component22 == null;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3399 @ rax_v295 (UnityEngine.RectTransform)+10]");
																									bool flag93 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3399 @ rax_v295 (UnityEngine.RectTransform)+10]");
																									RectTransform.set_sizeDelta_Injected((IntPtr)0, ref *(Vector2*)(&value2));
																								}
																								if (obj12 != null)
																								{
																									AddStrips();
																								}
																								if (_willPlayDarkanaIntro)
																								{
																									bool flag94 = (object)_GetButton == null;
																									Selectable component23 = _GetButton.GetComponent<Selectable>();
																									bool flag95 = (object)component23 == null;
																									component23.Select();
																								}
																								else
																								{
																									_003CWaitAndSelect_003Ed__118 obj13 = null;
																									obj13._003C_003E1__state = 0;
																									obj13._003C_003E4__this = this;
																									Coroutine coroutine = StartCoroutine(obj13);
																								}
																								return;
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
								}
							}
						}
					}
				}
			}
		}
		goto IL_1c76;
		IL_0215:
		playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData config7 = _playerOptions.Config;
			if (config7 != null)
			{
				bool flag96 = config7.HasCollectedItem(ItemType.RELIC_DARKASSO);
				bool flag97 = !flag96;
				object obj = 0;
				if (flag97)
				{
					goto IL_03aa;
				}
				playerOptions = _playerOptions;
				if (_playerOptions != null)
				{
					PlayerOptionsData config8 = _playerOptions.Config;
					if (config8 != null)
					{
						bool flag98 = config8.HasCollectedItem(ItemType.RELIC_RANDOMAZZO);
						obj = 0;
						if (flag98)
						{
							goto IL_03aa;
						}
						_ShowDarkanaFirst = true;
						PlayerOptions playerOptions3 = _playerOptions;
						bool flag99 = _playerOptions == null;
						playerOptions = (PlayerOptions)(object)config8;
						if (!flag99)
						{
							playerOptions = (PlayerOptions)(object)playerOptions3._mainGameConfig;
							if (playerOptions3._mainGameConfig != null)
							{
								_ = 1;
								Debug.Log("DARKANA TRANSITION SEEN");
								obj = 0;
								goto IL_1cfe;
							}
						}
					}
				}
			}
		}
		goto IL_1c76;
		IL_03aa:
		if (_lastSelected > 22)
		{
			_ShowDarkanaFirst = true;
		}
		goto IL_1cfe;
		IL_1c76:
		throw new NullReferenceException();
	}

	private void EnableInputFirstMenu()
	{
		TweenCallback onComplete = delegate
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CEnableInputFirstMenu_003Eb__115_0_003Ed stateMachine = default(_003C_003CEnableInputFirstMenu_003Eb__115_0_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		};
		Tween tween = UITimerHelper.RegisterMillis(500f, onComplete);
	}

	private void SetRandomButton()
	{
		_003CWaitAndConfigureRandomButton_003Ed__117 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitAndConfigureRandomButton()
	{
		_003CWaitAndConfigureRandomButton_003Ed__117 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator WaitAndSelect(GameObject forcedSelect = null)
	{
		_003CWaitAndSelect_003Ed__118 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator WaitAndForceSelect(GameObject cardToSelect)
	{
		_003CWaitAndForceSelect_003Ed__119 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.cardToSelect = cardToSelect;
		return obj;
	}

	private unsafe void InitializeNormalArcanaParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0968: Expected O, but got Ref
		//IL_018c: Expected O, but got I
		//IL_0208: Expected O, but got Ref
		//IL_0221: Expected native int or pointer, but got O
		//IL_0240: Expected O, but got I
		//IL_0260: Expected O, but got Ref
		//IL_027a: Expected native int or pointer, but got O
		//IL_0294: Expected O, but got I
		//IL_02c2: Expected O, but got I4
		//IL_02db: Expected O, but got Ref
		//IL_0313: Expected native int or pointer, but got O
		//IL_0a01: Expected O, but got I
		//IL_034b: Expected O, but got Ref
		//IL_0365: Expected native int or pointer, but got O
		//IL_0a3b: Expected O, but got I
		//IL_03bc: Expected O, but got I
		//IL_03dd: Expected O, but got I
		//IL_0531: Expected O, but got Ref
		//IL_054a: Expected native int or pointer, but got O
		//IL_0584: Expected O, but got Ref
		//IL_059e: Expected native int or pointer, but got O
		//IL_05ef: Expected O, but got Ref
		//IL_0627: Expected native int or pointer, but got O
		//IL_065f: Expected O, but got Ref
		//IL_0679: Expected native int or pointer, but got O
		//IL_0ae2: Expected O, but got Ref
		//IL_0994->IL08d1: Incompatible stack heights: 1 vs 0
		//IL_00c0->IL08d1: Incompatible stack heights: 1 vs 0
		//IL_00f0->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_0132->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_01b8->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_0418->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_0467->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_04e9->IL08d1: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Camera main = Camera.main;
		bool flag = (object)main == null;
		float num = 1f;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
			num = 1f;
			if (!flag2)
			{
				Camera main2 = Camera.main;
				num = 0.666875f;
			}
		}
		if ((object)_BottomParticles != null)
		{
			Transform transform = _BottomParticles.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				if ((object)_TopParticles != null)
				{
					Transform transform2 = _TopParticles.transform;
					if ((object)transform2 != null)
					{
						bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("randomazzo");
						List<string> list = new List<string>();
						list._002Ector();
						if (list != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
							if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v47 (System.IntPtr)+18]");
								if (num2 >= 0)
								{
									((List<object>)(object)list).AddWithResize((object)"back");
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+18]");
									object obj4 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									Camera main3 = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBoundsIgnoringBorders(main3);
									object obj5 = default(object);
									float max = (float)obj5 * 2f;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
									particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(4000f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
									float max2 = num * 200f;
									float min = num * 100f;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(min, max2));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
									particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
									_ = 0;
									_ = 0;
									_ = 1;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 4473924;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
									particleSystemConfig._tint = (uint?)(object)0;
									ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("randomazzo");
									List<string> list2 = new List<string>();
									if (list2 != null)
									{
										int version = list2._version + 1;
										list2._version = version;
										string[] items = list2._items;
										if (list2._items != null)
										{
											if (list2._size >= items.Length)
											{
												((List<object>)(object)list2).AddWithResize((object)"back");
											}
											else
											{
												int size = list2._size + 1;
												list2._size = size;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											if (particleSystemConfig2 != null)
											{
												Camera main4 = Camera.main;
												Bounds bounds2 = CameraExtensions.OrthographicBoundsIgnoringBorders(main4);
												float max3 = (float)obj5 * 2f;
												ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, max3));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
												((UnityEngine.Object)(object)particleSystemConfig2).m_CachedPtr = (IntPtr)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
												_ = 0;
												minMaxCurve3 = new ParticleSystem.MinMaxCurve(4000f);
												_ = 0;
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
												float min2 = num * -100f;
												float max4 = num * -200f;
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(min2, max4));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(2f, 0f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
												_ = 0;
												_ = 0;
												_ = 1;
												_ = 1;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
												_ = 0;
												_ = 4473924;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
												_ = 0;
												bool flag5 = (object)_TopParticles == null;
												Transform transform3 = _TopParticles.transform;
												Transform parent = default(Transform);
												string psName = default(string);
												bool isAdditive = default(bool);
												bool requiresMasking = default(bool);
												ParticleSystem particleSystem = _TopParticles.CreateUIEmitter(particleSystemConfig, "UI", 6, parent, psName, isAdditive, requiresMasking);
												bool flag6 = (object)particleSystem == null;
												particleSystem.Play(withChildren: true);
												bool flag7 = (object)_TopParticles == null;
												Transform transform4 = _TopParticles.transform;
												bool flag8 = (object)transform4 == null;
												Transform child = transform4.GetChild(0);
												bool flag9 = (object)child == null;
												_ = 0;
												bool flag10 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
												object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
												Transform.set_position_Injected(((UnityEngine.Object)child).m_CachedPtr, ref *(Vector3*)obj6);
												bool flag11 = (object)_BottomParticles == null;
												Transform transform5 = _BottomParticles.transform;
												ParticleSystem particleSystem2 = _BottomParticles.CreateUIEmitter(particleSystemConfig2, "UI", 6, parent, psName, isAdditive, requiresMasking);
												bool flag12 = (object)particleSystem2 == null;
												particleSystem2.Play(withChildren: true);
												bool flag13 = (object)_BottomParticles == null;
												Transform transform6 = _BottomParticles.transform;
												bool flag14 = (object)transform6 == null;
												Transform child2 = transform6.GetChild(0);
												bool flag15 = (object)child2 == null;
												bool flag16 = ((UnityEngine.Object)child2).m_CachedPtr == (IntPtr)0;
												Transform.set_position_Injected(((UnityEngine.Object)child2).m_CachedPtr, ref *(Vector3*)(&minMaxCurve3));
												Renderer component = particleSystem2.GetComponent<Renderer>();
												bool flag17 = (object)component == null;
												bool flag18 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
												Renderer.set_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr, 8);
												return;
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
		throw new NullReferenceException();
	}

	private unsafe void InitializeDarkanaParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_098c: Expected O, but got Ref
		//IL_018c: Expected O, but got I
		//IL_0210: Expected O, but got Ref
		//IL_0229: Expected native int or pointer, but got O
		//IL_0248: Expected O, but got I
		//IL_0268: Expected O, but got Ref
		//IL_0282: Expected native int or pointer, but got O
		//IL_029c: Expected O, but got I
		//IL_02ca: Expected O, but got I4
		//IL_02e3: Expected O, but got Ref
		//IL_031b: Expected native int or pointer, but got O
		//IL_0a25: Expected O, but got I
		//IL_0353: Expected O, but got Ref
		//IL_036d: Expected native int or pointer, but got O
		//IL_0a5f: Expected O, but got I
		//IL_03c4: Expected O, but got I
		//IL_03f3: Expected O, but got I
		//IL_0551: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Expected F4, but got Unknown
		//IL_0564: Expected O, but got Ref
		//IL_057d: Expected native int or pointer, but got O
		//IL_05af: Expected O, but got Ref
		//IL_05c9: Expected native int or pointer, but got O
		//IL_061a: Expected O, but got Ref
		//IL_0652: Expected native int or pointer, but got O
		//IL_0660: Expected O, but got I4
		//IL_0a87: Expected O, but got I4
		//IL_068d: Expected O, but got Ref
		//IL_06a7: Expected native int or pointer, but got O
		//IL_0b09: Expected O, but got Ref
		//IL_09b8->IL08f5: Incompatible stack heights: 1 vs 0
		//IL_00c0->IL08f5: Incompatible stack heights: 1 vs 0
		//IL_00f0->IL08f5: Incompatible stack heights: 2 vs 0
		//IL_0132->IL08f5: Incompatible stack heights: 2 vs 0
		//IL_01b8->IL08f5: Incompatible stack heights: 2 vs 0
		//IL_042e->IL08f5: Incompatible stack heights: 2 vs 0
		//IL_047d->IL08f5: Incompatible stack heights: 2 vs 0
		//IL_04ff->IL08f5: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Camera main = Camera.main;
		bool flag = (object)main == null;
		float num = 1f;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
			num = 1f;
			if (!flag2)
			{
				Camera main2 = Camera.main;
				num = 0.666875f;
			}
		}
		if ((object)_BottomDarkanaParticles != null)
		{
			Transform transform = _BottomDarkanaParticles.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				if ((object)_TopDarkanaParticles != null)
				{
					Transform transform2 = _TopDarkanaParticles.transform;
					if ((object)transform2 != null)
					{
						bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("darkana_card");
						List<string> list = new List<string>();
						list._002Ector();
						if (list != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
							if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rcx_v47 (System.IntPtr)+18]");
								if (num2 >= 0)
								{
									((List<object>)(object)list).AddWithResize((object)"darkana_card");
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+18]");
									object obj4 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									Camera main3 = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBoundsIgnoringBorders(main3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ rax_v58 (UnityEngine.Bounds)+10]");
									float max = 0f * 2f;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
									particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(4000f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
									float max2 = num * 200f;
									float min = num * 100f;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(min, max2));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
									particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
									_ = 0;
									_ = 0;
									_ = 1;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
									particleSystemConfig._quantity = (int?)(object)0;
									particleSystemConfig._scaleEase = Easing.OutCubic;
									_ = 4473924;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
									particleSystemConfig._tint = (uint?)(object)0;
									ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("darkana_card");
									List<string> list2 = new List<string>();
									if (list2 != null)
									{
										int version = list2._version + 1;
										list2._version = version;
										string[] items = list2._items;
										if (list2._items != null)
										{
											if (list2._size >= items.Length)
											{
												((List<object>)(object)list2).AddWithResize((object)"darkana_card");
											}
											else
											{
												int size = list2._size + 1;
												list2._size = size;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											if (particleSystemConfig2 != null)
											{
												Camera main4 = Camera.main;
												Bounds bounds2 = CameraExtensions.OrthographicBoundsIgnoringBorders(main4);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1991 @ rax_v83 (UnityEngine.Bounds)+10]");
												float num3 = 0f * 2f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
												float max3 = num3 ^ 0;
												ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, max3));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
												_ = 0;
												minMaxCurve3 = new ParticleSystem.MinMaxCurve(4000f);
												_ = 0;
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
												float min2 = num * -100f;
												float max4 = num * -200f;
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(min2, max4));
												obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
												_ = 0;
												obj = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(2f, 0f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
												_ = 0;
												_ = 0;
												_ = 1;
												_ = 1;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
												_ = 0;
												_ = 4473924;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
												_ = 0;
												_ = 12;
												bool flag5 = (object)_TopDarkanaParticles == null;
												Transform transform3 = _TopDarkanaParticles.transform;
												Transform parent = default(Transform);
												string psName = default(string);
												bool isAdditive = default(bool);
												bool requiresMasking = default(bool);
												ParticleSystem particleSystem = _TopDarkanaParticles.CreateUIEmitter(particleSystemConfig, "UI", 6, parent, psName, isAdditive, requiresMasking);
												bool flag6 = (object)_TopDarkanaParticles == null;
												Transform transform4 = _TopDarkanaParticles.transform;
												bool flag7 = (object)transform4 == null;
												Transform child = transform4.GetChild(0);
												bool flag8 = (object)child == null;
												_ = 0;
												bool flag9 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
												object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
												Transform.set_position_Injected(((UnityEngine.Object)child).m_CachedPtr, ref *(Vector3*)obj5);
												bool flag10 = (object)_BottomDarkanaParticles == null;
												Transform transform5 = _BottomDarkanaParticles.transform;
												ParticleSystem particleSystem2 = _BottomDarkanaParticles.CreateUIEmitter(particleSystemConfig2, "UI", 6, parent, psName, isAdditive, requiresMasking);
												bool flag11 = (object)_BottomDarkanaParticles == null;
												Transform transform6 = _BottomDarkanaParticles.transform;
												bool flag12 = (object)transform6 == null;
												Transform child2 = transform6.GetChild(0);
												bool flag13 = (object)child2 == null;
												bool flag14 = ((UnityEngine.Object)child2).m_CachedPtr == (IntPtr)0;
												Transform.set_position_Injected(((UnityEngine.Object)child2).m_CachedPtr, ref *(Vector3*)(&minMaxCurve3));
												bool flag15 = (object)particleSystem2 == null;
												Renderer component = particleSystem2.GetComponent<Renderer>();
												bool flag16 = (object)component == null;
												bool flag17 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
												Renderer.set_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr, 8);
												bool flag18 = (object)particleSystem == null;
												particleSystem.Stop();
												particleSystem2.Stop();
												return;
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
		throw new NullReferenceException();
	}

	private unsafe void InitializeTicklers()
	{
		//IL_042e: Expected O, but got I4
		//IL_0136: Expected O, but got F4
		//IL_015b: Expected O, but got Ref
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_038c: Expected O, but got Ref
		//IL_021a: Expected O, but got Ref
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Expected O, but got Unknown
		//IL_053e->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_0084->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_00c6->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_0254->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_01ab->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_0124->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_0284->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_01d7->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_034d->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_02ef->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_037a->IL03ae: Incompatible stack heights: 2 vs 0
		//IL_022d->IL022d: Incompatible stack heights: 5 vs 2
		//IL_0501->IL0524: Incompatible stack heights: 4 vs 2
		//IL_0506->IL03ad: Incompatible stack heights: 4 vs 0
		List<GameObject> tentacles = _tentacles;
		if (_tentacles != null)
		{
			if (tentacles._size > 0)
			{
				return;
			}
			RectTransform component = GetComponent<RectTransform>();
			if ((object)component != null)
			{
				bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect _);
				bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				float ret2;
				RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out *(Rect*)(&ret2));
				object obj = 0;
				float num = default(float);
				float num3 = default(float);
				float value = default(float);
				float num4 = default(float);
				float num6 = default(float);
				while ((object)_TentacleSpawnRotator != null)
				{
					Transform transform = _TentacleSpawnRotator.transform;
					if ((object)transform == null)
					{
						break;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate(parent: transform.parent, original: _TentaclePrefab);
					if ((object)gameObject == null)
					{
						break;
					}
					if (_tentacleMode == TentacleMode.TOP)
					{
						RectTransform component2 = gameObject.GetComponent<RectTransform>();
						Rect rect = component.rect;
						if ((object)component2 == null)
						{
							break;
						}
						component2.anchoredPosition = (Vector2)num;
						float num2 = UnityEngine.Random.Range(240f, 300f);
						component2.localEulerAngles = (Vector3)(&num3);
					}
					else if (_tentacleMode == TentacleMode.ENCIRCLING)
					{
						Transform transform2 = gameObject.transform;
						if ((object)_TentacleSpawnAnchor == null)
						{
							break;
						}
						Transform transform3 = _TentacleSpawnAnchor.transform;
						if ((object)transform3 == null)
						{
							break;
						}
						Vector3 position = transform3.position;
						bool flag3 = (object)transform2 == null;
						bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
						Transform transform4 = gameObject.transform;
						bool flag5 = (object)transform4 == null;
						transform4.eulerAngles = (Vector3)(&num4);
						value = position.x;
					}
					TentacleUI component3 = gameObject.GetComponent<TentacleUI>();
					if (_tentacles == null)
					{
						break;
					}
					GameObject gameObject2 = UnityEngine.Object.Instantiate((GameObject)(object)_tentacles, (Transform)(object)gameObject);
					if ((object)component3 == null)
					{
						break;
					}
					component3.Initialize();
					int num5 = UnityEngine.Random.Range(3, 9);
					bool flag6 = num5 <= 0;
					GameObject gameObject3 = null;
					TentacleUI tentacleUI = component3;
					if (!flag6)
					{
						while ((object)tentacleUI != null)
						{
							TentacleUI tentacleUI2 = tentacleUI.AddSegment();
							gameObject3 = (GameObject)(gameObject3 + 1);
							bool flag7 = (nint)gameObject3 < num5;
							tentacleUI = tentacleUI2;
							if (flag7)
							{
								continue;
							}
							goto IL_0333;
						}
						break;
					}
					goto IL_0333;
					IL_0333:
					if ((object)_TentacleSpawnRotator == null)
					{
						break;
					}
					Transform transform5 = _TentacleSpawnRotator.transform;
					if ((object)transform5 == null)
					{
						break;
					}
					transform5.eulerAngles = (Vector3)(&num6);
					Transform transform6 = gameObject.transform;
					bool flag8 = (object)transform6 == null;
					bool flag9 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)(&ret2));
					obj++;
					bool flag10 = (nint)obj < 17;
					num6 = num;
					if (!flag10)
					{
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe ArcanaCardUI SpawnArcanaCard(ArcanaData data, ArcanaType type)
	{
		//IL_005c: Expected O, but got Ref
		//IL_0069: Expected O, but got Ref
		GameObject gameObject = UnityEngine.Object.Instantiate(_ArcanaCardPrefab, _CardContainer);
		ArcanaCardUI component;
		if ((object)gameObject != null)
		{
			component = gameObject.GetComponent<ArcanaCardUI>();
			IntPtr intPtr = default(IntPtr);
			string text = System.Number.FormatInt32((int)type, (ReadOnlySpan<char>)(&intPtr), null);
			string text2 = ((Enum)(&intPtr)).ToString();
			string text3 = text + ": " + text2;
			((UnityEngine.Object)gameObject).SetName(text3);
			string text4 = ((UnityEngine.Object)gameObject).GetName();
			string message = "Spawned : " + text4;
			Debug.Log(message);
			if ((object)component != null)
			{
				bool isShowing = default(bool);
				component.SetData(data, type, (ISetArcanaInfo)this, isShowing);
				List<ArcanaCardUI> list;
				if (type >= ArcanaType.D00_STAKE_TO_YOUR_HEART)
				{
					if (_darkSpawned == null)
					{
						goto IL_0358;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					component.SetDarkBack();
					if (data == null || !data._003Cunlocked_003Ek__BackingField)
					{
						goto IL_0227;
					}
					list = _darkUnlockedCards;
				}
				else
				{
					if (_spawned == null)
					{
						goto IL_0358;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					if (data == null || !data._003Cunlocked_003Ek__BackingField)
					{
						goto IL_0227;
					}
					list = _unlockedCards;
				}
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97530");
					goto IL_0227;
				}
			}
		}
		goto IL_0358;
		IL_0353:
		return component;
		IL_0227:
		Button component2 = gameObject.GetComponent<Button>();
		if ((object)component2 != null)
		{
			component2.enabled = true;
			component2.interactable = true;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				ArcanaManager arcanaManager = core._arcanaManager;
				if (core._arcanaManager != null && arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
					object obj = default(object);
					if (obj == null)
					{
						goto IL_0353;
					}
					if ((object)component._Icon != null)
					{
						UICornersGradient component3 = component._Icon.GetComponent<UICornersGradient>();
						if ((object)component3 != null)
						{
							component3.enabled = true;
							goto IL_0353;
						}
					}
				}
			}
		}
		goto IL_0358;
		IL_0358:
		return (ArcanaCardUI)(object)new NullReferenceException();
	}

	private unsafe void AddStrips()
	{
		//IL_0008: Expected O, but got Ref
		//IL_008b: Expected O, but got I4
		//IL_09d6: Expected O, but got Ref
		//IL_0a35: Expected O, but got Ref
		//IL_0a7e: Expected O, but got I4
		//IL_0196: Expected O, but got I
		//IL_0248: Expected I, but got O
		//IL_0b1a: Expected O, but got Ref
		//IL_0be9: Expected I, but got O
		//IL_0bff: Expected O, but got I
		//IL_0c08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0d: Expected O, but got Unknown
		//IL_041c: Expected I, but got O
		//IL_0c33: Expected O, but got I4
		//IL_0c4a: Expected I, but got I8
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_0405: Expected I, but got I8
		//IL_0507: Expected O, but got I4
		//IL_0510: Expected O, but got I4
		//IL_0324: Expected O, but got I
		//IL_0e72: Expected O, but got I
		//IL_04f0: Expected O, but got I
		//IL_03c6: Expected O, but got I
		//IL_0caa: Expected O, but got Ref
		//IL_0547: Expected O, but got I
		//IL_0547: Expected O, but got I
		//IL_0575: Expected I, but got O
		//IL_05aa: Expected O, but got I
		//IL_05de: Expected O, but got I
		//IL_0f0e: Expected O, but got I4
		//IL_060b: Expected O, but got I
		//IL_0713: Expected O, but got I
		//IL_074d: Expected O, but got Ref
		//IL_0902: Unknown result type (might be due to invalid IL or missing references)
		//IL_0907: Expected O, but got Unknown
		//IL_0910: Unknown result type (might be due to invalid IL or missing references)
		//IL_0915: Expected O, but got Unknown
		//IL_082b: Expected O, but got I
		//IL_08cd: Expected O, but got I
		//IL_0a5f->IL0984: Incompatible stack heights: 3 vs 0
		//IL_01b6->IL0984: Incompatible stack heights: 4 vs 0
		//IL_0214->IL0984: Incompatible stack heights: 5 vs 0
		//IL_0265->IL0984: Incompatible stack heights: 5 vs 0
		//IL_0ea2->IL0984: Incompatible stack heights: 6 vs 0
		//IL_04fd->IL0c67: Incompatible stack heights: 6 vs 0
		//IL_0cef->IL0984: Incompatible stack heights: 7 vs 0
		//IL_0563->IL0984: Incompatible stack heights: 8 vs 0
		//IL_0597->IL0984: Incompatible stack heights: 8 vs 0
		//IL_05cb->IL0984: Incompatible stack heights: 8 vs 0
		//IL_0d49->IL0984: Incompatible stack heights: 8 vs 0
		//IL_062b->IL0984: Incompatible stack heights: 12 vs 0
		//IL_0689->IL0984: Incompatible stack heights: 13 vs 0
		//IL_0700->IL0984: Incompatible stack heights: 13 vs 0
		//IL_0937->IL0e59: Incompatible stack heights: 13 vs 6
		object obj2 = default(object);
		object obj = (object)(&obj2);
		DataManager data = _data;
		if (_data != null && data._003CAllArcanas_003Ek__BackingField != null)
		{
			Dictionary<ArcanaType, ArcanaData>.KeyCollection keys = data._003CAllArcanas_003Ek__BackingField.Keys;
			if (keys == null)
			{
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
			List<System.Int32Enum> list = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)(object)keys);
			_ = _ShowDarkanaFirst;
			object obj3 = 0;
			ArcanaMainSelectionPage arcanaMainSelectionPage = this;
			Vector2 value = default(Vector2);
			bool isInteractable = default(bool);
			Vector2 value2 = default(Vector2);
			object obj10 = default(object);
			Vector2 value3 = default(Vector2);
			object obj20 = default(object);
			while (true)
			{
				_003C_003Ec__DisplayClass124_0 obj4 = new _003C_003Ec__DisplayClass124_0();
				float screenWidth = UIHelper.ScreenWidth;
				float screenHeight = UIHelper.ScreenHeight;
				GameObject g = UnityEngine.Object.Instantiate(arcanaMainSelectionPage._ArcanaCardPrefab, arcanaMainSelectionPage._StripContainer);
				if (obj4 == null)
				{
					break;
				}
				obj4.g = g;
				if ((object)obj4.g == null)
				{
					break;
				}
				ArcanaCardUI component = obj4.g.GetComponent<ArcanaCardUI>();
				if ((object)obj4.g == null)
				{
					break;
				}
				RectTransform component2 = obj4.g.GetComponent<RectTransform>();
				if ((object)component2 == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
				RectTransform.set_anchorMin_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref *(Vector2*)obj5);
				bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				RectTransform.set_anchorMax_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
				bool flag3 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
				RectTransform.set_anchoredPosition_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref *(Vector2*)obj6);
				if (list == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v68 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj7 = UnityEngine.Random.RandomRangeInt(0, 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v68 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				bool flag4 = (nint)obj7 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v68 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v68 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rcx_v91+18]");
				bool flag5 = (nint)obj7 >= 0;
				Dictionary<ArcanaType, ArcanaData> dictionary = data._003CAllArcanas_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rcx_v91+20+v279 @ rax_v96*4]");
				object data2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
				if ((object)component == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rcx_v91+20+v279 @ rax_v96*4]");
				component.SetData((ArcanaData)data2, ArcanaType.T00_KILLER, isOpen: false, isInteractable);
				nint num = (nint)obj4.g;
				if ((object)obj4.g == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbx_v32 (Il2CppMethodInfo)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbx_v32 (Il2CppMethodInfo)+10]");
				IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
				Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				float num2 = (float)obj3 * 0.05f;
				float duration = num2 + 0.5f;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&value2), duration, RotateMode.LocalAxisAdd);
				bool flag7 = tweenerCore == null;
				object obj9 = obj10;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v105 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					bool flag8 = (nint)0 == 0;
					obj9 = obj10;
					if (!flag8)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v105 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
						bool flag9 = (nint)0 != 0;
						obj9 = obj10;
						if (!flag9)
						{
							_ = 2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v105 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
							bool flag10 = (nint)0 != 0;
							obj9 = obj10;
							if (!flag10)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v105 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v105 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
								obj9 = num3 + 0;
							}
						}
					}
				}
				float num4 = (float)obj3 * 0.05f;
				float duration2 = num4 + 0.5f;
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTweenModuleUI.DOAnchorPosY(component2, -100f, duration2);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
								obj9 = num5 + 0;
							}
						}
					}
				}
				TweenCallback tweenCallback = null;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v25 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass124_0._003CAddStrips_003Eb__0);
				((Delegate)tweenCallback).m_target = obj4;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v25 (Il2CppMethodInfo)+4C]");
				object obj11 = (nint)0 >> 4;
				object obj12 = obj11 & 1;
				nint num7;
				if (obj12 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v25 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num7 = unchecked((nint)6447293664L);
						goto IL_0c2a;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num7 = ((Delegate)tweenCallback).method_ptr;
				goto IL_0c2a;
				IL_0c2a:
				object obj13 = 24;
				((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
				if ((nint)0 != 0)
				{
					component.SetDarkBack();
				}
				float delay = (float)obj3 * 0.05f;
				component.SpinDelay(delay, 12);
				obj3++;
				if ((nint)obj3 < 22)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
					arcanaMainSelectionPage = (ArcanaMainSelectionPage)0;
					value2 = (Vector2)obj10;
					continue;
				}
				object obj14 = 0;
				object obj15 = 22;
				while (true)
				{
					_003C_003Ec__DisplayClass124_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass124_1();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r14_v27+168]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r14_v27+168]");
					if ((nint)0 == 0)
					{
						break;
					}
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rbx_v36 (Il2CppMethodInfo)+10]");
					bool flag11 = (nint)0 == 0;
					object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rbx_v36 (Il2CppMethodInfo)+10]");
					RectTransform.get_sizeDelta_Injected((IntPtr)0, out *(Vector2*)obj17);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r14_v27+168]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r14_v27+168]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rbx_v37 (Il2CppMethodInfo)+10]");
					bool flag12 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rbx_v37 (Il2CppMethodInfo)+10]");
					RectTransform.get_sizeDelta_Injected((IntPtr)0, out value);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r14_v27+108]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r14_v27+168]");
					GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)num10, (Transform)0);
					if (CS_0024_003C_003E8__locals9 == null)
					{
						break;
					}
					((UnityEngine.Object)(object)CS_0024_003C_003E8__locals9).m_CachedPtr = (IntPtr)gameObject;
					if (((UnityEngine.Object)(object)CS_0024_003C_003E8__locals9).m_CachedPtr == (IntPtr)0)
					{
						break;
					}
					ArcanaCardUI component3 = ((GameObject)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals9).m_CachedPtr).GetComponent<ArcanaCardUI>();
					if (((UnityEngine.Object)(object)CS_0024_003C_003E8__locals9).m_CachedPtr == (IntPtr)0)
					{
						break;
					}
					RectTransform component4 = ((GameObject)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals9).m_CachedPtr).GetComponent<RectTransform>();
					if ((object)component4 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3136 @ rax_v132 (UnityEngine.RectTransform)+10]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3136 @ rax_v132 (UnityEngine.RectTransform)+10]");
					RectTransform.set_anchorMin_Injected((IntPtr)0, ref value3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3136 @ rax_v132 (UnityEngine.RectTransform)+10]");
					bool flag14 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3136 @ rax_v132 (UnityEngine.RectTransform)+10]");
					RectTransform.set_anchorMax_Injected((IntPtr)0, ref value2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3136 @ rax_v132 (UnityEngine.RectTransform)+10]");
					bool flag15 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3136 @ rax_v132 (UnityEngine.RectTransform)+10]");
					RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref value3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v68 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					object obj18 = UnityEngine.Random.RandomRangeInt(0, 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v68 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					bool flag16 = (nint)obj18 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v68 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v68 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rcx_v136+18]");
					bool flag17 = (nint)obj18 >= 0;
					Dictionary<ArcanaType, ArcanaData> dictionary2 = data._003CAllArcanas_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rcx_v136+20+v286 @ rax_v150*4]");
					object data3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
					if ((object)component3 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rcx_v136+20+v286 @ rax_v150*4]");
					component3.SetData((ArcanaData)data3, ArcanaType.T00_KILLER, isOpen: false, isInteractable);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
					if ((nint)0 != 0)
					{
						component3.SetDarkBack();
					}
					if (((UnityEngine.Object)(object)CS_0024_003C_003E8__locals9).m_CachedPtr == (IntPtr)0)
					{
						break;
					}
					Transform target2 = ((GameObject)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals9).m_CachedPtr).transform;
					float num11 = (float)obj14 * 0.05f;
					float duration3 = num11 + 0.5f;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj20), duration3, RotateMode.LocalAxisAdd);
					bool flag18 = tweenerCore3 == null;
					obj9 = obj10;
					if (!flag18)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3341 @ rax_v156 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						bool flag19 = (nint)0 == 0;
						obj9 = obj10;
						if (!flag19)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3341 @ rax_v156 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
							bool flag20 = (nint)0 != 0;
							obj9 = obj10;
							if (!flag20)
							{
								_ = 2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3341 @ rax_v156 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
								bool flag21 = (nint)0 != 0;
								obj9 = obj10;
								if (!flag21)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3341 @ rax_v156 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
									nint num12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3341 @ rax_v156 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
									obj9 = num12 + 0;
								}
							}
						}
					}
					float num13 = (float)obj14 * 0.05f;
					duration2 = num13 + 0.5f;
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore4 = DOTweenModuleUI.DOAnchorPosY(component4, -100f, duration2);
					if (tweenerCore4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3403 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3403 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3403 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3403 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
									nint num14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3403 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
									obj9 = num14 + 0;
								}
							}
						}
					}
					TweenCallback tweenCallback2 = delegate
					{
						CS_0024_003C_003E8__locals9.g.SetActive(value: false);
					};
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B5D0");
					delay = (float)obj14 * 0.05f;
					component3.SpinDelay(delay, 12);
					obj14++;
					obj15--;
					bool flag22 = (nint)obj15 > 0;
					obj20 = obj10;
					if (!flag22)
					{
						return;
					}
				}
				break;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void ClearSpawned()
	{
		//IL_0355: Expected O, but got Ref
		//IL_00ab: Expected I4, but got O
		//IL_00ab: Expected O, but got I
		//IL_0137: Expected I4, but got O
		//IL_0137: Expected O, but got I
		//IL_01c3: Expected I4, but got O
		//IL_01c3: Expected O, but got I
		//IL_024f: Expected I4, but got O
		//IL_024f: Expected O, but got I
		//IL_02db: Expected I4, but got O
		//IL_02db: Expected O, but got I
		bool flag = _spawned == null;
		ArcanaMainSelectionPage arcanaMainSelectionPage = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			bool flag2 = _darkSpawned == null;
			arcanaMainSelectionPage = (ArcanaMainSelectionPage)(&enumerator);
			if (!flag2)
			{
				List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
				while (enumerator2.MoveNext())
				{
					UnityEngine.Object.Destroy(null, 0f);
				}
				arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_unlockedCards;
				if (_unlockedCards != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v2 (VampireSurvivors.UI.ArcanaMainSelectionPage)+1C]");
					_ = (nint)0 + (nint)1;
					((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource = null;
					if ((nint)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource > 0)
					{
						Array.Clear((Array)(nint)((UnityEngine.Object)arcanaMainSelectionPage).m_CachedPtr, 0, (int)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource);
					}
					arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_darkUnlockedCards;
					if (_darkUnlockedCards != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v2 (VampireSurvivors.UI.ArcanaMainSelectionPage)+1C]");
						_ = (nint)0 + (nint)1;
						((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource = null;
						if ((nint)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource > 0)
						{
							Array.Clear((Array)(nint)((UnityEngine.Object)arcanaMainSelectionPage).m_CachedPtr, 0, (int)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource);
						}
						arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_allSpawnedInOrder;
						if (_allSpawnedInOrder != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v2 (VampireSurvivors.UI.ArcanaMainSelectionPage)+1C]");
							_ = (nint)0 + (nint)1;
							((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource = null;
							if ((nint)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource > 0)
							{
								Array.Clear((Array)(nint)((UnityEngine.Object)arcanaMainSelectionPage).m_CachedPtr, 0, (int)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource);
							}
							arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_darkSpawned;
							if (_darkSpawned != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v2 (VampireSurvivors.UI.ArcanaMainSelectionPage)+1C]");
								_ = (nint)0 + (nint)1;
								((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource = null;
								if ((nint)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource > 0)
								{
									Array.Clear((Array)(nint)((UnityEngine.Object)arcanaMainSelectionPage).m_CachedPtr, 0, (int)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource);
								}
								arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_spawned;
								if (_spawned != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v2 (VampireSurvivors.UI.ArcanaMainSelectionPage)+1C]");
									_ = (nint)0 + (nint)1;
									((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource = null;
									if ((nint)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource > 0)
									{
										Array.Clear((Array)(nint)((UnityEngine.Object)arcanaMainSelectionPage).m_CachedPtr, 0, (int)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource);
									}
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SelectArcana()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_00a7: Expected I, but got O
		//IL_00c3: Expected O, but got I
		//IL_0066: Expected F4, but got I4
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool flag = default(bool);
		SignalBus.InternalFire((Type)num, signal, (object)null, flag);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, flag ? 1 : 0);
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedArcana_003Ek__BackingField = (int)_currentSelected;
	}

	private void OnSelectedArcanaRemotely(OnlineSignals.OnlineSelectedArcana arcana)
	{
		//IL_000a: Expected I4, but got O
		_currentSelected = (ArcanaType)arcana;
		SelectArcana();
	}

	private void OnReRolledArcanasRemotely()
	{
		PerformReRoll();
	}

	private void OnTransitionArcanaModeRemotely()
	{
		SwitchArcanaMode();
	}

	public void GoToDarkana()
	{
		//IL_009e: Expected I8, but got O
		//IL_0082: Expected I8, but got O
		//IL_0057: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x1869904A0\"");
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).ArcanaModeTransition((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v4 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private unsafe void SwitchArcanaMode()
	{
		//IL_0044: Expected O, but got I4
		//IL_026c: Expected O, but got Ref
		//IL_02ba: Expected O, but got Ref
		//IL_0308: Expected O, but got Ref
		//IL_0356: Expected O, but got Ref
		//IL_017d: Expected O, but got Ref
		//IL_01e3->IL0227: Incompatible stack heights: 1 vs 0
		//IL_0210->IL0227: Incompatible stack heights: 1 vs 0
		//IL_0227->IL0227: Incompatible stack heights: 1 vs 0
		bool arcanaMode = _arcanaMode == ArcanaMode.LIGHT;
		_arcanaMode = (arcanaMode ? ArcanaMode.DARK : ArcanaMode.LIGHT);
		if (_arcanaMode != ArcanaMode.DARK)
		{
			PlayLightSound();
		}
		else
		{
			Action onComplete = PlayDarkSound;
			AudioLoader.LoadSFXAsync(SfxType.Darkasso_Open, _arcanaCacheGroupName, (DlcType?)(object)0, onComplete);
		}
		CanvasGroup component = GetComponent<CanvasGroup>();
		if ((object)component != null)
		{
			component.interactable = false;
			Vector2 value = default(Vector2);
			if (_arcanaMode == ArcanaMode.DARK)
			{
				if ((object)_Skull == null)
				{
					goto IL_03c2;
				}
				Vector2 vector = default(Vector2);
				_Skull.anchoredPosition = vector;
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(_Skull, vector, 0.5f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 7;
						_ = 0;
					}
				}
				Action skull = (Action)(object)_Skull;
				bool flag = ((Delegate)skull).method_ptr == (IntPtr)0;
				Transform.set_localScale_Injected(((Delegate)skull).method_ptr, ref *(Vector3*)(&value));
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_Skull, 3f, 1.2f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v931 @ rax_v46 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 22;
						_ = 0;
					}
				}
				Image component2 = _Skull.GetComponent<Image>();
				object obj = default(object);
				component2.color = (Color)(&obj);
				Image component3 = _Skull.GetComponent<Image>();
				TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(component3, 0.7f, 0.3f);
				TweenCallback tweenCallback = delegate
				{
					Image component4 = _Skull.GetComponent<Image>();
					TweenerCore<Color, Color, ColorOptions> tweenerCore8 = DOTweenModuleUI.DOFade(component4, 0f, 0.3f);
				};
				bool flag2 = tweenerCore3 == null;
				value = vector;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1077 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					bool flag3 = (nint)0 == 0;
					value = vector;
					if (!flag3)
					{
						value = vector;
					}
				}
			}
			if ((object)_TitleGroup != null)
			{
				Transform target = _TitleGroup.transform;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DORotate(target, (Vector3)(&value), 0.3f, RotateMode.LocalAxisAdd);
				if ((object)_InfoGroup != null)
				{
					Transform target2 = _InfoGroup.transform;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore5 = ShortcutExtensions.DORotate(target2, (Vector3)(&value), 0.3f, RotateMode.LocalAxisAdd);
					if ((object)_CardContainer != null)
					{
						Transform target3 = _CardContainer.transform;
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = ShortcutExtensions.DORotate(target3, (Vector3)(&value), 0.3f, RotateMode.LocalAxisAdd);
						if ((object)_MajorBackground != null)
						{
							Transform target4 = _MajorBackground.transform;
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore7 = ShortcutExtensions.DORotate(target4, (Vector3)(&value), 0.3f, RotateMode.LocalAxisAdd);
							TweenCallback tweenCallback2 = delegate
							{
								//IL_0373: Expected O, but got Ref
								//IL_03b3: Expected O, but got Ref
								//IL_03f3: Expected O, but got Ref
								//IL_0433: Expected O, but got Ref
								//IL_0b73: Expected O, but got Ref
								//IL_0bef: Expected O, but got Ref
								//IL_0c6a: Expected O, but got Ref
								//IL_0ce6: Expected O, but got Ref
								//IL_0d14: Expected I, but got O
								//IL_0d2a: Expected O, but got I
								//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
								//IL_0d38: Expected O, but got Unknown
								//IL_0674: Expected I, but got O
								//IL_0d5e: Expected O, but got I4
								//IL_0d75: Expected I, but got I8
								//IL_0650: Expected I, but got I8
								//IL_09f5->IL06a9: Incompatible stack heights: 1 vs 0
								//IL_0397->IL06a9: Incompatible stack heights: 1 vs 0
								//IL_0737->IL0db4: Incompatible stack heights: 1 vs 0
								//IL_0873->IL0e00: Incompatible stack heights: 1 vs 0
								//IL_0a55->IL06a9: Incompatible stack heights: 2 vs 0
								//IL_010e->IL06a9: Incompatible stack heights: 1 vs 0
								//IL_079c->IL0dda: Incompatible stack heights: 1 vs 0
								//IL_03d7->IL06a9: Incompatible stack heights: 2 vs 0
								//IL_02d1->IL06a9: Incompatible stack heights: 1 vs 0
								//IL_08d8->IL0e26: Incompatible stack heights: 1 vs 0
								//IL_0165->IL06a9: Incompatible stack heights: 2 vs 0
								//IL_0ab5->IL06a9: Incompatible stack heights: 3 vs 0
								//IL_0328->IL06a9: Incompatible stack heights: 2 vs 0
								//IL_0417->IL06a9: Incompatible stack heights: 3 vs 0
								//IL_0180->IL0829: Incompatible stack heights: 3 vs 0
								//IL_0351->IL0965: Incompatible stack heights: 3 vs 0
								//IL_0b15->IL06a9: Incompatible stack heights: 4 vs 0
								//IL_0457->IL06a9: Incompatible stack heights: 4 vs 0
								//IL_04c3->IL06a9: Incompatible stack heights: 5 vs 0
								//IL_052d->IL06a9: Incompatible stack heights: 6 vs 0
								//IL_0599->IL06a9: Incompatible stack heights: 7 vs 0
								OnArcanaModeChange arcanaModeChanged = ArcanaMainSelectionPage.m_ArcanaModeChanged;
								if (ArcanaMainSelectionPage.m_ArcanaModeChanged != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v48.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								}
								List<GameObject> list = default(List<GameObject>);
								float duration;
								if (_arcanaMode == ArcanaMode.LIGHT)
								{
									if (_d20Tween != null)
									{
										DG.Tweening.TweenExtensions.Kill(_d20Tween);
										_d20Tween = null;
										Tween tween = null;
									}
									else
									{
										Tween tween = null;
									}
									SetLightDesign();
									if (_spawned != null)
									{
										list = _spawned;
										List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
										while (enumerator.MoveNext())
										{
											object obj2 = null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rsi_v57 (System.Object)+10]");
											bool flag4 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rsi_v57 (System.Object)+10]");
											GameObject.SetActive_Injected((IntPtr)0, true);
										}
										List<GameObject> darkSpawned = _darkSpawned;
										if (_darkSpawned != null)
										{
											list = _darkSpawned;
											List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
											while (enumerator2.MoveNext())
											{
												object obj3 = null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rsi_v56 (System.Object)+10]");
												bool flag5 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rsi_v56 (System.Object)+10]");
												GameObject.SetActive_Injected((IntPtr)0, false);
											}
											List<ArcanaCardUI> unlockedCards = _unlockedCards;
											if (_unlockedCards != null)
											{
												bool flag6 = unlockedCards._size <= 0;
												ArcanaCardUI[] items = unlockedCards._items;
												if (unlockedCards._items != null)
												{
													bool flag7 = items.Length <= 0;
													object obj4 = items[0];
													if ((object)items[0] != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rsi_v55 (System.Object)+10]");
														bool flag8 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rsi_v55 (System.Object)+10]");
														IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
														GameObject cardToSelect = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
														IEnumerator routine = WaitAndForceSelect(cardToSelect);
														Coroutine coroutine = StartCoroutine(routine);
														object obj5 = null;
														goto IL_0829;
													}
												}
											}
										}
									}
								}
								else
								{
									if (_arcanaMode != ArcanaMode.DARK)
									{
										Tween tween = null;
										goto IL_0829;
									}
									if (_d20Tween == null)
									{
										RandomD20Fall();
									}
									if ((object)_D20 != null)
									{
										RawImage component4 = _D20.GetComponent<RawImage>();
										TweenerCore<Color, Color, ColorOptions> tweenerCore8 = DOTweenModuleUI.DOFade(component4, 1f, 0.3f);
										SetDarkDesign();
										if (_spawned != null)
										{
											list = _spawned;
											List<GameObject>.Enumerator enumerator3 = default(List<GameObject>.Enumerator);
											while (enumerator3.MoveNext())
											{
												object obj6 = null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1293 @ rsi_v52 (System.Object)+10]");
												bool flag9 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1293 @ rsi_v52 (System.Object)+10]");
												GameObject.SetActive_Injected((IntPtr)0, false);
											}
											List<GameObject> darkSpawned = _darkSpawned;
											if (_darkSpawned != null)
											{
												list = _darkSpawned;
												List<GameObject>.Enumerator enumerator4 = default(List<GameObject>.Enumerator);
												while (enumerator4.MoveNext())
												{
													object obj7 = null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2018 @ rsi_v51 (System.Object)+10]");
													bool flag10 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2018 @ rsi_v51 (System.Object)+10]");
													GameObject.SetActive_Injected((IntPtr)0, true);
												}
												List<ArcanaCardUI> darkUnlockedCards = _darkUnlockedCards;
												if (_darkUnlockedCards != null)
												{
													bool flag11 = darkUnlockedCards._size <= 0;
													ArcanaCardUI[] items2 = darkUnlockedCards._items;
													if (darkUnlockedCards._items != null)
													{
														bool flag12 = items2.Length <= 0;
														object obj8 = items2[0];
														if ((object)items2[0] != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rsi_v50 (System.Object)+10]");
															bool flag13 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rsi_v50 (System.Object)+10]");
															IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
															GameObject cardToSelect2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
															IEnumerator routine2 = WaitAndForceSelect(cardToSelect2);
															Coroutine coroutine2 = StartCoroutine(routine2);
															duration = 0.3f;
															object obj5 = null;
															Tween tween = null;
															goto IL_0965;
														}
													}
												}
											}
										}
									}
								}
								goto IL_06a9;
								IL_0965:
								SetCount();
								SetRandomButton();
								object titleGroup = _TitleGroup;
								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore12;
								TweenCallback tweenCallback3;
								if ((object)_TitleGroup != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rsi_v20 (System.Object)+10]");
									bool flag14 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rsi_v20 (System.Object)+10]");
									IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
									if ((object)transform != null)
									{
										transform.localEulerAngles = (Vector3)(&list);
										object infoGroup = _InfoGroup;
										if ((object)_InfoGroup != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rsi_v21 (System.Object)+10]");
											bool flag15 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rsi_v21 (System.Object)+10]");
											IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
											Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
											if ((object)transform2 != null)
											{
												transform2.localEulerAngles = (Vector3)(&list);
												object majorBackground = _MajorBackground;
												if ((object)_MajorBackground != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rsi_v22 (System.Object)+10]");
													bool flag16 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rsi_v22 (System.Object)+10]");
													IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
													Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
													if ((object)transform3 != null)
													{
														transform3.localEulerAngles = (Vector3)(&list);
														object cardContainer = _CardContainer;
														if ((object)_CardContainer != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rsi_v23 (System.Object)+10]");
															bool flag17 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rsi_v23 (System.Object)+10]");
															IntPtr gcHandlePtr6 = Component.get_transform_Injected((IntPtr)0);
															Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
															if ((object)transform4 != null)
															{
																transform4.localEulerAngles = (Vector3)(&list);
																object cardContainer2 = _CardContainer;
																if ((object)_CardContainer != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rsi_v24 (System.Object)+10]");
																	bool flag18 = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rsi_v24 (System.Object)+10]");
																	IntPtr gcHandlePtr7 = Component.get_transform_Injected((IntPtr)0);
																	Transform target5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
																	TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore9 = ShortcutExtensions.DORotate(target5, (Vector3)(&list), duration);
																	if (tweenerCore9 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3596 @ rax_v83 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
																		if ((nint)0 != 0)
																		{
																			_ = 27;
																		}
																	}
																	object titleGroup2 = _TitleGroup;
																	if ((object)_TitleGroup != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rsi_v25 (System.Object)+10]");
																		bool flag19 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rsi_v25 (System.Object)+10]");
																		IntPtr gcHandlePtr8 = Component.get_transform_Injected((IntPtr)0);
																		Transform target6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr8);
																		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore10 = ShortcutExtensions.DORotate(target6, (Vector3)(&list), duration);
																		if (tweenerCore10 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3740 @ rax_v90 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
																			if ((nint)0 != 0)
																			{
																				_ = 27;
																			}
																		}
																		object infoGroup2 = _InfoGroup;
																		if ((object)_InfoGroup != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rsi_v26 (System.Object)+10]");
																			bool flag20 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rsi_v26 (System.Object)+10]");
																			IntPtr gcHandlePtr9 = Component.get_transform_Injected((IntPtr)0);
																			Transform target7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr9);
																			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore11 = ShortcutExtensions.DORotate(target7, (Vector3)(&list), duration);
																			if (tweenerCore11 != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3867 @ rax_v97 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
																				if ((nint)0 != 0)
																				{
																					_ = 27;
																				}
																			}
																			object majorBackground2 = _MajorBackground;
																			if ((object)_MajorBackground != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rsi_v27 (System.Object)+10]");
																				bool flag21 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rsi_v27 (System.Object)+10]");
																				IntPtr gcHandlePtr10 = Component.get_transform_Injected((IntPtr)0);
																				Transform target8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr10);
																				tweenerCore12 = ShortcutExtensions.DORotate(target8, (Vector3)(&list), duration);
																				if (tweenerCore12 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3995 @ rax_v104 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
																					if ((nint)0 != 0)
																					{
																						_ = 27;
																					}
																				}
																				tweenCallback3 = null;
																				nint num = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ r10_v1 (Il2CppMethodInfo)+8]");
																				((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
																				((Delegate)tweenCallback3).method = (nint)__ldftn(ArcanaMainSelectionPage._003CSwitchArcanaMode_003Eb__131_2);
																				((Delegate)tweenCallback3).m_target = this;
																				((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ r10_v1 (Il2CppMethodInfo)+4C]");
																				object obj9 = (nint)0 >> 4;
																				object obj10 = obj9 & 1;
																				nint num2;
																				if (obj10 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ r10_v1 (Il2CppMethodInfo)+52]");
																					if ((nint)0 == 0)
																					{
																						num2 = unchecked((nint)6447293664L);
																						goto IL_0d55;
																					}
																				}
																				num2 = ((Delegate)tweenCallback3).method_ptr;
																				((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
																				goto IL_0d55;
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
								goto IL_06a9;
								IL_0829:
								duration = 0.3f;
								goto IL_0965;
								IL_0d55:
								object obj11 = 24;
								((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
								if (tweenerCore12 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3995 @ rax_v104 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								}
								return;
								IL_06a9:
								throw new NullReferenceException();
							};
							if (tweenerCore7 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v948 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							return;
						}
					}
				}
			}
		}
		goto IL_03c2;
		IL_03c2:
		throw new NullReferenceException();
	}

	private void PlayJingle()
	{
		//IL_0040: Expected O, but got I4
		if (_arcanaMode != ArcanaMode.DARK)
		{
			PlayLightSound();
			return;
		}
		Action onComplete = PlayDarkSound;
		AudioLoader.LoadSFXAsync(SfxType.Darkasso_Open, _arcanaCacheGroupName, (DlcType?)(object)0, onComplete);
	}

	private void PlayDarkSound()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Darkasso_Open, soundConfig, 0f, 10, time);
	}

	private void PlayLightSound()
	{
		//IL_0109: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -500f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = -400f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig2, 0f, 10, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Detune = -400f;
		soundConfig3.Rate = 0.7f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig3, 0f, 10, time);
	}

	private void SetDarkDesign()
	{
		Debug.Log("SETTING DARK DESIGN");
		Image component = _MajorBackground.GetComponent<Image>();
		Sprite sprite = SpriteManager.GetSprite("darkanaFrame", "darkanaFrame");
		component.sprite = sprite;
		Image component2 = _InfoGroup.GetComponent<Image>();
		Sprite sprite2 = SpriteManager.GetSprite("darkanaFrame", "darkanaFrame");
		component2.sprite = sprite2;
		Image component3 = _TitleBackground.GetComponent<Image>();
		Sprite sprite3 = SpriteManager.GetSprite("darkanaFrame", "darkanaFrame");
		component3.sprite = sprite3;
		Image component4 = _MinorBackground.GetComponent<Image>();
		Sprite sprite4 = SpriteManager.GetSprite("darkanaFrame", "darkanaFrame");
		component4.sprite = sprite4;
		Image component5 = _CharacterPanelBackground.GetComponent<Image>();
		Sprite sprite5 = SpriteManager.GetSprite("darkanaFrame", "darkanaFrame");
		component5.sprite = sprite5;
		_TitleText.text = "DARKASSO";
		Sprite sprite6 = SpriteManager.GetSprite("Tarots", "items");
		_DarkButtonIcon.sprite = sprite6;
		Sprite sprite7 = SpriteManager.GetSprite("Tarots2", "items");
		_TitleIcon.sprite = sprite7;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_BlackFader, 1f, 1f);
		_TitleBloodMask.SetActive(value: true);
		_PanelBloodMask.SetActive(value: true);
		_InfoBloodMask.SetActive(value: true);
		_CharacterPanelBloodMask.SetActive(value: true);
		_TopParticles.StopAllEmitters();
		_BottomParticles.StopAllEmitters();
		_TopDarkanaParticles.StartAllEmitters();
		_BottomDarkanaParticles.StartAllEmitters();
		CanvasGroup component6 = _TitleBloodMask.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleUI.DOFade(component6, 1f, 0.01f);
		CanvasGroup component7 = _PanelBloodMask.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTweenModuleUI.DOFade(component7, 1f, 0.01f);
		CanvasGroup component8 = _InfoBloodMask.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore4 = DOTweenModuleUI.DOFade(component8, 1f, 0.01f);
		CanvasGroup component9 = _MinorBloodMask.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore5 = DOTweenModuleUI.DOFade(component9, 1f, 0.01f);
		CanvasGroup component10 = _CharacterPanelBloodMask.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore6 = DOTweenModuleUI.DOFade(component10, 1f, 0.01f);
	}

	public void SetLightDesign()
	{
		Debug.Log("SETTING LIGHT DESIGN");
		Image component = _MinorBackground.GetComponent<Image>();
		Sprite sprite = SpriteManager.GetSprite("frame_purple", "UI");
		component.sprite = sprite;
		Image component2 = _MajorBackground.GetComponent<Image>();
		Sprite sprite2 = SpriteManager.GetSprite("frame_purple", "UI");
		component2.sprite = sprite2;
		Image component3 = _TitleBackground.GetComponent<Image>();
		Sprite sprite3 = SpriteManager.GetSprite("frame_purple", "UI");
		component3.sprite = sprite3;
		Image component4 = _InfoGroup.GetComponent<Image>();
		Sprite sprite4 = SpriteManager.GetSprite("frame_purple", "UI");
		component4.sprite = sprite4;
		Image component5 = _CharacterPanelBackground.GetComponent<Image>();
		Sprite sprite5 = SpriteManager.GetSprite("frame_purple", "UI");
		component5.sprite = sprite5;
		CanvasGroup component6 = _TitleBloodMask.GetComponent<CanvasGroup>();
		component6.alpha = 0f;
		CanvasGroup component7 = _InfoBloodMask.GetComponent<CanvasGroup>();
		component7.alpha = 0f;
		CanvasGroup component8 = _MinorBloodMask.GetComponent<CanvasGroup>();
		component8.alpha = 0f;
		CanvasGroup component9 = _PanelBloodMask.GetComponent<CanvasGroup>();
		component9.alpha = 0f;
		CanvasGroup component10 = _CharacterPanelBloodMask.GetComponent<CanvasGroup>();
		component10.alpha = 0f;
		Sprite sprite6 = SpriteManager.GetSprite("tarots2", "items");
		_DarkButtonIcon.sprite = sprite6;
		Sprite sprite7 = SpriteManager.GetSprite("Tarots", "items");
		_TitleIcon.sprite = sprite7;
		_BottomDarkanaParticles.StopAllEmitters();
		_TopDarkanaParticles.StopAllEmitters();
		RawImage component11 = _D20.GetComponent<RawImage>();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(component11, 0f, 0.01f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_BlackFader, 0.5f, 1f);
		_TopParticles.StartAllEmitters();
		_BottomParticles.StartAllEmitters();
		_TitleText.text = "RANDOMAZZO";
	}

	private unsafe void SetCount()
	{
		//IL_01b1: Expected O, but got Ref
		//IL_01b1: Expected I4, but got O
		string text4;
		TextMeshProUGUI textMeshProUGUI;
		if (_arcanaMode != ArcanaMode.LIGHT)
		{
			DataManager data = _data;
			bool flag = _data == null;
			ArcanaMainSelectionPage arcanaMainSelectionPage = this;
			if (!flag)
			{
				bool flag2 = data._003CAllArcanas_003Ek__BackingField == null;
				arcanaMainSelectionPage = this;
				if (!flag2)
				{
					Dictionary<ArcanaType, ArcanaData>.Enumerator enumerator = default(Dictionary<ArcanaType, ArcanaData>.Enumerator);
					while (enumerator.MoveNext() && 0 < 100)
					{
					}
					bool flag3 = (object)_Count == null;
					arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_Count;
					if (!flag3)
					{
						TextMeshProUGUI component = _Count.GetComponent<TextMeshProUGUI>();
						arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_darkUnlockedCards;
						if (_darkUnlockedCards != null)
						{
							int num = default(int);
							string text = num.ToString();
							int num2 = default(int);
							string text2 = num2.ToString();
							string text3 = text + "/" + text2;
							if ((object)component != null)
							{
								text4 = text3;
								textMeshProUGUI = component;
								goto IL_0286;
							}
						}
					}
				}
			}
		}
		else
		{
			bool flag4 = (object)_Count == null;
			ArcanaMainSelectionPage arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_Count;
			if (!flag4)
			{
				TextMeshProUGUI component2 = _Count.GetComponent<TextMeshProUGUI>();
				arcanaMainSelectionPage = (ArcanaMainSelectionPage)(object)_unlockedCards;
				if (_unlockedCards != null)
				{
					object obj = default(object);
					string text5 = System.Number.FormatInt32((int)((MonoBehaviour)arcanaMainSelectionPage).m_CancellationTokenSource, (ReadOnlySpan<char>)(&obj), null);
					string text6 = text5 + "/22";
					if ((object)component2 != null)
					{
						text4 = text6;
						textMeshProUGUI = component2;
						goto IL_0286;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0286:
		textMeshProUGUI.text = text4;
	}

	private void RandomD20Fall()
	{
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_0076: Expected O, but got F4
		//IL_00c7: Expected O, but got I
		//IL_012e: Expected O, but got I8
		//IL_024d->IL018f: Incompatible stack heights: 2 vs 0
		//IL_004a->IL018f: Incompatible stack heights: 2 vs 0
		//IL_029c->IL018f: Incompatible stack heights: 3 vs 0
		//IL_0133->IL02a1: Incompatible stack heights: 4 vs 3
		RectTransform component = GetComponent<RectTransform>();
		if ((object)component != null)
		{
			bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect _);
			bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect ret2);
			object obj2 = default(object);
			object obj = obj2 ^ -0f;
			float minInclusive = (float)obj * 0.5f;
			float num2 = default(float);
			float num = UnityEngine.Random.Range(minInclusive, num2);
			if ((object)_D20 != null)
			{
				Vector2 anchoredPosition = default(Vector2);
				_D20.anchoredPosition = anchoredPosition;
				RectTransform component2 = GetComponent<RectTransform>();
				if ((object)component2 != null)
				{
					bool flag3 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)component2).m_CachedPtr, out ret2);
					if ((object)_D20 != null)
					{
						Vector2 sizeDelta = _D20.sizeDelta;
						object obj3 = num2 ^ -0f;
						object obj4 = default(object);
						float num3 = (float)obj4 * 2f;
						float endValue = (float)obj3 - num3;
						TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPosY(_D20, endValue, 1.6f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						bool flag4 = (nint)0 != 0;
						RectTransform d = _D20;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag5 = obj5 == null;
							d = (RectTransform)6573110936L;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v710 @ rax_v40 (should have been resolved before IL gen)");
						TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 3f);
						TweenCallback tweenCallback = delegate
						{
							RandomD20Fall();
						};
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
						_d20Tween = tweenerCore;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SetInfo(ArcanaData data, ArcanaType type, ArcanaCardUI UI)
	{
		//IL_0245: Expected O, but got I4
		//IL_025f: Expected O, but got I4
		//IL_00d3: Expected O, but got Ref
		ArcanaCardUI selected = _selected;
		bool flag = (object)_selected == null;
		bool flag2 = (object)UI == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 != null)
		{
			return;
		}
		bool flag4;
		if ((object)UI != null)
		{
			if ((object)_selected != null)
			{
				object obj3 = (object)_selected - (object)UI;
				flag4 = obj3 == null;
			}
			else
			{
				flag4 = ((UnityEngine.Object)UI).m_CachedPtr == (IntPtr)0;
			}
		}
		else
		{
			flag4 = ((UnityEngine.Object)selected).m_CachedPtr == (IntPtr)0;
		}
		if (!flag4)
		{
			if (data == null)
			{
				object obj4 = default(object);
				string text = ((Enum)(&obj4)).ToString();
				string message = "Missing data for : " + text;
				Debug.Log(message);
				GameObject gameObject = UI.gameObject;
				string text2 = ((UnityEngine.Object)gameObject).GetName();
				string message2 = "Missing data for : " + text2;
				Debug.Log(message2);
			}
			ArcanaCardUI selected2 = _selected;
			if ((object)_selected != null && ((UnityEngine.Object)selected2).m_CachedPtr != (IntPtr)0)
			{
				ArcanaCardUI selected3 = _selected;
				selected3._Selected.SetActive(value: false);
			}
			_selected = UI;
			ArcanaCardUI selected4 = _selected;
			selected4._Selected.SetActive(value: true);
			_ArcanaInfoPanel.SetInfo(data, type);
			_currentSelected = type;
		}
	}

	public void Select()
	{
		//IL_0106: Expected I4, but got F4
		Debug.Log("Selecting arcana");
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj = default(object);
		float num = default(float);
		if (obj != null)
		{
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				GameManager core2 = GM.Core;
				if (!core2._multiplayer.IsOnlineMultiplayer)
				{
					SelectArcana();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				Action<long, int> action = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
				OnlineStageManager onlineStageManager = default(OnlineStageManager);
				long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
				bool flag = onlineStageManager._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, (int)num);
				return;
			}
		}
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, num);
	}

	public unsafe void Random()
	{
		//IL_11c9: Expected I, but got O
		//IL_0128: Expected I, but got O
		//IL_00c5: Expected I, but got O
		//IL_015e: Expected I, but got O
		//IL_0195: Expected I, but got O
		//IL_01cb: Expected I, but got O
		//IL_0202: Expected I, but got O
		//IL_0238: Expected I, but got O
		//IL_026f: Expected I, but got O
		//IL_02a8: Expected I, but got O
		//IL_02e1: Expected I, but got O
		//IL_031a: Expected I, but got O
		//IL_0350: Expected I, but got O
		//IL_0387: Expected I, but got O
		//IL_03db: Expected I, but got O
		//IL_042f: Expected I, but got O
		//IL_0465: Expected I, but got O
		//IL_049c: Expected I, but got O
		//IL_11fe: Expected I, but got O
		//IL_0638: Expected O, but got Ref
		//IL_071a: Expected I, but got O
		//IL_1287: Expected I, but got O
		//IL_12be: Expected O, but got I4
		//IL_12cb: Expected I, but got O
		//IL_1302: Expected O, but got I4
		//IL_133b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1340: Expected O, but got Unknown
		//IL_13c6: Expected I, but got O
		//IL_13fd: Expected O, but got I4
		//IL_140a: Expected I, but got O
		//IL_1441: Expected O, but got I4
		//IL_145e: Expected O, but got I
		//IL_1487: Unknown result type (might be due to invalid IL or missing references)
		//IL_148c: Expected I4, but got Unknown
		//IL_07fc: Expected F4, but got I4
		//IL_0823: Expected F4, but got I4
		//IL_082b: Expected O, but got Ref
		//IL_0b42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b47: Expected O, but got Unknown
		//IL_084b: Expected O, but got I4
		//IL_164d: Expected I, but got O
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Expected I, but got Unknown
		//IL_08ca: Expected I4, but got O
		//IL_14bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c4: Expected O, but got Unknown
		//IL_097b: Expected I, but got O
		//IL_09cb: Expected I, but got O
		//IL_0a02: Expected O, but got Ref
		//IL_0a72: Expected I, but got O
		//IL_0adc: Expected O, but got I
		//IL_0b1c: Expected F4, but got I4
		//IL_0b2c: Expected I, but got O
		//IL_12a4->IL1187: Incompatible stack heights: 1 vs 0
		//IL_12e8->IL1187: Incompatible stack heights: 2 vs 0
		//IL_137e->IL1187: Incompatible stack heights: 3 vs 0
		//IL_13e3->IL1187: Incompatible stack heights: 4 vs 0
		//IL_1427->IL1187: Incompatible stack heights: 5 vs 0
		//IL_1656->IL1187: Incompatible stack heights: 6 vs 0
		//IL_08f4->IL1187: Incompatible stack heights: 6 vs 0
		//IL_0923->IL1187: Incompatible stack heights: 6 vs 0
		//IL_099d->IL1187: Incompatible stack heights: 6 vs 0
		//IL_09d4->IL1187: Incompatible stack heights: 6 vs 0
		//IL_0a7b->IL1187: Incompatible stack heights: 6 vs 0
		//IL_169a->IL10df: Incompatible stack heights: 6 vs 0
		//IL_10f8->IL10df: Incompatible stack heights: 6 vs 0
		//IL_1121->IL10df: Incompatible stack heights: 6 vs 0
		_003C_003Ec__DisplayClass141_0 CS_0024_003C_003E8__locals70 = new _003C_003Ec__DisplayClass141_0();
		bool flag = CS_0024_003C_003E8__locals70 == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass141_0);
		if (!flag)
		{
			CS_0024_003C_003E8__locals70._003C_003E4__this = this;
			if (!_hasFinishedPopulationAnimation || _hasPickedRandom)
			{
				return;
			}
			_hasPickedRandom = true;
			ArcanaCardUI selected = _selected;
			if ((object)_selected != null)
			{
				bool flag2 = (object)selected._Selected == null;
				num = (nint)selected._Selected;
				if (flag2)
				{
					goto IL_1187;
				}
				selected._Selected.SetActive(value: false);
			}
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			bool flag3 = (object)_RandomButton == null;
			num = (nint)_RandomButton;
			if (!flag3)
			{
				Button component = _RandomButton.GetComponent<Button>();
				bool flag4 = (object)component == null;
				num = (nint)_RandomButton;
				if (!flag4)
				{
					component.enabled = false;
					bool flag5 = (object)_GetButton == null;
					num = (nint)_GetButton;
					if (!flag5)
					{
						Button component2 = _GetButton.GetComponent<Button>();
						bool flag6 = (object)component2 == null;
						num = (nint)_GetButton;
						if (!flag6)
						{
							component2.enabled = false;
							bool flag7 = (object)_CollectRandomButton == null;
							num = (nint)_CollectRandomButton;
							if (!flag7)
							{
								Button component3 = _CollectRandomButton.GetComponent<Button>();
								bool flag8 = (object)component3 == null;
								num = (nint)_CollectRandomButton;
								if (!flag8)
								{
									component3.enabled = false;
									bool flag9 = (object)_RandomButton == null;
									num = (nint)_RandomButton;
									if (!flag9)
									{
										_RandomButton.SetActive(value: false);
										bool flag10 = (object)_GetButton == null;
										num = (nint)_GetButton;
										if (!flag10)
										{
											_GetButton.SetActive(value: false);
											bool flag11 = (object)_DarkButton == null;
											num = (nint)_DarkButton;
											if (!flag11)
											{
												_DarkButton.SetActive(value: false);
												bool flag12 = (object)_CardContainer == null;
												num = (nint)_CardContainer;
												if (!flag12)
												{
													GridLayoutGroup component4 = _CardContainer.GetComponent<GridLayoutGroup>();
													bool flag13 = (object)component4 == null;
													num = (nint)_CardContainer;
													if (!flag13)
													{
														component4.enabled = false;
														bool flag14 = (object)_RandomButton == null;
														num = (nint)_RandomButton;
														if (!flag14)
														{
															Transform target = _RandomButton.transform;
															TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.2f);
															bool flag15 = (object)_GetButton == null;
															num = (nint)_GetButton;
															if (!flag15)
															{
																Transform target2 = _GetButton.transform;
																TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 0f, 0.2f);
																bool flag16 = (object)_CollectRandomButton == null;
																num = (nint)_CollectRandomButton;
																if (!flag16)
																{
																	GameObject gameObject = _CollectRandomButton.gameObject;
																	bool flag17 = (object)gameObject == null;
																	num = (nint)_CollectRandomButton;
																	if (!flag17)
																	{
																		gameObject.SetActive(value: true);
																		bool flag18 = (object)_CollectRandomButton == null;
																		num = (nint)_CollectRandomButton;
																		if (!flag18)
																		{
																			Transform target3 = _CollectRandomButton.transform;
																			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target3, 1f, 0.2f);
																			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(t, 0.2f);
																			TweenCallback tweenCallback = delegate
																			{
																				ArcanaMainSelectionPage arcanaMainSelectionPage4 = CS_0024_003C_003E8__locals70._003C_003E4__this;
																				Button component6 = arcanaMainSelectionPage4._CollectRandomButton.GetComponent<Button>();
																				component6.Select();
																			};
																			bool flag19 = tweenerCore3 == null;
																			nint num2 = 0;
																			TweenCallback tweenCallback2 = tweenCallback;
																			if (!flag19)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1923 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																				bool flag20 = (nint)0 == 0;
																				num2 = 0;
																				tweenCallback2 = tweenCallback;
																				if (!flag20)
																				{
																					num2 = 0;
																					tweenCallback2 = tweenCallback;
																				}
																			}
																			List<GameObject> cards = ((_arcanaMode != ArcanaMode.DARK) ? _spawned : _darkSpawned);
																			CS_0024_003C_003E8__locals70.cards = cards;
																			List<ArcanaCardUI> unlocked = ((_arcanaMode != ArcanaMode.DARK) ? _unlockedCards : _darkUnlockedCards);
																			CS_0024_003C_003E8__locals70.unlocked = unlocked;
																			num = (nint)tweenCallback2;
																			List<GameObject> list = CS_0024_003C_003E8__locals70.cards;
																			if (CS_0024_003C_003E8__locals70.cards != null)
																			{
																				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
																				if (enumerator.MoveNext())
																				{
																					GameObject gameObject2 = (GameObject)(&enumerator);
																					throw new NullReferenceException();
																				}
																				Sequence s = DOTween.Sequence();
																				CS_0024_003C_003E8__locals70.s = s;
																				num = unchecked((nint)null);
																				object cardContainer = _CardContainer;
																				if ((object)_CardContainer != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdi_v21 (System.Object)+10]");
																					bool flag21 = (nint)0 == 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdi_v21 (System.Object)+10]");
																					RectTransform.get_rect_Injected((IntPtr)0, out Rect ret);
																					num = (nint)((LayoutGroup)component4).m_Padding;
																					if (((LayoutGroup)component4).m_Padding != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																						bool flag22 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																						object obj = RectOffset.get_left_Injected((IntPtr)0);
																						num = (nint)((LayoutGroup)component4).m_Padding;
																						if (((LayoutGroup)component4).m_Padding != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																							bool flag23 = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																							object obj2 = RectOffset.get_right_Injected((IntPtr)0);
																							object obj3 = component4.m_CellSize + component4.m_Spacing;
																							object obj4 = obj3 + obj;
																							object obj5 = obj2 + obj4;
																							object obj6 = &enumerator / obj5;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
																							TweenerCore<Vector3, Vector3, VectorOptions> cardContainer2 = (TweenerCore<Vector3, Vector3, VectorOptions>)(object)_CardContainer;
																							bool flag24 = (object)_CardContainer == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																							num = 0;
																							if (!flag24)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v24 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
																								bool flag25 = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v24 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
																								RectTransform.get_rect_Injected((IntPtr)0, out ret);
																								num = (nint)((LayoutGroup)component4).m_Padding;
																								if (((LayoutGroup)component4).m_Padding != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																									bool flag26 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																									object obj7 = RectOffset.get_top_Injected((IntPtr)0);
																									num = (nint)((LayoutGroup)component4).m_Padding;
																									if (((LayoutGroup)component4).m_Padding != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																										bool flag27 = (nint)0 == 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v32 (Il2CppClass<VampireSurvivors.UI.ArcanaMainSelectionPage+<>c__DisplayClass141_0>)+10]");
																										object obj8 = RectOffset.get_bottom_Injected((IntPtr)0);
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v58 (UnityEngine.UI.GridLayoutGroup)+6C]");
																										nint num3 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v58 (UnityEngine.UI.GridLayoutGroup)+74]");
																										object obj9 = num3 + 0;
																										object obj10 = obj9 + obj7;
																										float num4 = (float)obj8 + (float)obj10;
																										int num5 = (int)(list._version / num4);
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
																										object obj11 = default(object);
																										if ((nint)obj11 <= 0)
																										{
																											goto IL_0b6b;
																										}
																										float num6 = num5;
																										object obj12 = obj11;
																										GridLayoutGroup gridLayoutGroup = null;
																										GridLayoutGroup gridLayoutGroup2 = component4;
																										float num7 = 0.2f;
																										float num8 = 0f;
																										_003C_003Ec__DisplayClass141_1 obj13 = (_003C_003Ec__DisplayClass141_1)(&ret);
																										GridLayoutGroup gridLayoutGroup3 = null;
																										ArcanaMainSelectionPage arcanaMainSelectionPage = this;
																										object obj15 = default(object);
																										object obj14 = obj15;
																										GameObject gameObject3 = default(GameObject);
																										float x = default(float);
																										Tween t2 = default(Tween);
																										ArcanaMainSelectionPage arcanaMainSelectionPage3 = default(ArcanaMainSelectionPage);
																										while (true)
																										{
																											if ((nint)obj14 > 0)
																											{
																												object obj16 = 0;
																												float num9 = num6;
																												TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = (TweenerCore<Vector3, Vector3, VectorOptions>)(object)gridLayoutGroup;
																												float num10 = num4;
																												GridLayoutGroup gridLayoutGroup4 = gridLayoutGroup;
																												float num11 = num7;
																												List<GameObject> list2 = list;
																												float num12 = num8;
																												_003C_003Ec__DisplayClass141_1 obj17 = obj13;
																												nint num13 = num2;
																												ArcanaMainSelectionPage arcanaMainSelectionPage2 = arcanaMainSelectionPage;
																												while (true)
																												{
																													_003C_003Ec__DisplayClass141_1 obj18 = new _003C_003Ec__DisplayClass141_1();
																													bool flag28 = obj18 == null;
																													num = (nint)typeof(_003C_003Ec__DisplayClass141_1);
																													if (flag28)
																													{
																														break;
																													}
																													obj18.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals70;
																													num = (nint)(obj18 + 24);
																													obj18.cell = (int)gridLayoutGroup4;
																													_003C_003Ec__DisplayClass141_0 obj19 = obj18.CS_0024_003C_003E8__locals1;
																													if (obj18.CS_0024_003C_003E8__locals1 == null)
																													{
																														break;
																													}
																													List<GameObject> cards2 = obj19.cards;
																													if (obj19.cards == null)
																													{
																														break;
																													}
																													bool flag29 = (nint)gridLayoutGroup4 >= cards2._size;
																													gridLayoutGroup = (GridLayoutGroup)(object)tweenerCore4;
																													if (!flag29)
																													{
																														_003C_003Ec__DisplayClass141_0 obj20 = obj18.CS_0024_003C_003E8__locals1;
																														_003C_003Ec__DisplayClass141_0 obj21 = obj18.CS_0024_003C_003E8__locals1;
																														num = (nint)obj21.cards;
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
																														if ((object)gameObject3 == null)
																														{
																															break;
																														}
																														RectTransform component5 = gameObject3.GetComponent<RectTransform>();
																														bool flag30 = (object)arcanaMainSelectionPage2._CardOrigin == null;
																														num = (nint)gameObject3;
																														if (flag30)
																														{
																															break;
																														}
																														Vector3 position = arcanaMainSelectionPage2._CardOrigin.position;
																														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOMove(component5, (Vector3)(&x), 0.1f);
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
																														float num14 = (float)tweenerCore4 * 0.04f;
																														Sequence sequence = TweenSettingsExtensions.Insert(obj20.s, num14, t2);
																														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = (TweenerCore<Vector3, Vector3, VectorOptions>)(object)obj18.CS_0024_003C_003E8__locals1;
																														bool flag31 = obj18.CS_0024_003C_003E8__locals1 == null;
																														num = (nint)obj20.s;
																														if (flag31)
																														{
																															break;
																														}
																														TweenCallback<float> tweenCallback3 = null;
																														((_003C_003Ec__DisplayClass141_1)(object)tweenCallback3)._003CRandom_003Eb__5(num14);
																														Tweener tweener = DOVirtual.Float(0.5f, 0f, 0.1f, tweenCallback3);
																														num10 = (float)gridLayoutGroup3 * 0.04f;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdi_v38 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+28]");
																														Sequence sequence2 = TweenSettingsExtensions.Insert((Sequence)0, num10, tweener);
																														x = position.x;
																														num9 = 0.5f;
																														gridLayoutGroup = gridLayoutGroup3;
																														num11 = 0.1f;
																														list2 = null;
																														num12 = 0f;
																														obj17 = obj18;
																														num13 = (nint)tweener;
																														arcanaMainSelectionPage2 = arcanaMainSelectionPage3;
																													}
																													obj16++;
																													gridLayoutGroup2 = (GridLayoutGroup)(object)((object)gridLayoutGroup4 + obj11);
																													bool flag32 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15);
																													num6 = num9;
																													obj12 = obj11;
																													num4 = num10;
																													num7 = num11;
																													list = list2;
																													num8 = num12;
																													obj13 = obj17;
																													num2 = num13;
																													arcanaMainSelectionPage = arcanaMainSelectionPage2;
																													obj14 = obj15;
																													tweenerCore4 = (TweenerCore<Vector3, Vector3, VectorOptions>)(object)gridLayoutGroup;
																													gridLayoutGroup4 = gridLayoutGroup2;
																													if (flag32)
																													{
																														continue;
																													}
																													goto IL_0b39;
																												}
																												break;
																											}
																											goto IL_0b39;
																											IL_0b39:
																											gridLayoutGroup = (GridLayoutGroup)(gridLayoutGroup + 1);
																											bool flag33 = System.Runtime.CompilerServices.Unsafe.As<GridLayoutGroup, UIntPtr>(ref gridLayoutGroup) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12);
																											gridLayoutGroup3 = gridLayoutGroup;
																											if (flag33)
																											{
																												continue;
																											}
																											goto IL_0b6b;
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
		goto IL_1187;
		IL_1020:
		Sequence s2 = CS_0024_003C_003E8__locals70.s;
		TweenCallback tweenCallback4 = delegate
		{
			ArcanaMainSelectionPage arcanaMainSelectionPage4 = CS_0024_003C_003E8__locals70._003C_003E4__this;
			Button component6 = arcanaMainSelectionPage4._CollectRandomButton.GetComponent<Button>();
			component6.enabled = true;
		};
		Tween t3;
		object message;
		if (CS_0024_003C_003E8__locals70.s != null)
		{
			if (((Tween)s2)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)s2).creationLocked)
				{
					if (tweenCallback4 != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(CS_0024_003C_003E8__locals70.s, tweenCallback4, ((Tween)s2).duration);
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t3 = null;
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t3 = null;
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t3 = null;
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message, t3);
		return;
		IL_1187:
		throw new NullReferenceException();
		IL_0b6b:
		Sequence sequence4 = TweenSettingsExtensions.AppendInterval(CS_0024_003C_003E8__locals70.s, 0.32f);
		Sequence s3 = CS_0024_003C_003E8__locals70.s;
		TweenCallback tweenCallback5 = delegate
		{
			//IL_006c: Expected O, but got I4
			//IL_0076: Expected O, but got I4
			//IL_026a: Expected O, but got Ref
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			//IL_00f8->IL01ea: Incompatible stack heights: 1 vs 0
			//IL_012f->IL01ea: Incompatible stack heights: 1 vs 0
			//IL_01cf->IL01ea: Incompatible stack heights: 2 vs 0
			//IL_0174->IL01ea: Incompatible stack heights: 2 vs 0
			//IL_01e9->IL028b: Incompatible stack heights: 2 vs 0
			if (CS_0024_003C_003E8__locals70.cards != null)
			{
				((List<object>)(object)CS_0024_003C_003E8__locals70.cards).Reverse();
				if (CS_0024_003C_003E8__locals70.unlocked != null)
				{
					((List<object>)(object)CS_0024_003C_003E8__locals70.unlocked).Reverse();
					List<GameObject> cards3 = CS_0024_003C_003E8__locals70.cards;
					if (CS_0024_003C_003E8__locals70.cards != null)
					{
						object obj22 = 0;
						object obj23 = 0;
						object obj24 = default(object);
						object obj25 = default(object);
						while (true)
						{
							if ((nint)obj23 >= cards3._size)
							{
								return;
							}
							List<GameObject> cards4 = CS_0024_003C_003E8__locals70.cards;
							Sequence s6 = CS_0024_003C_003E8__locals70.s;
							if (CS_0024_003C_003E8__locals70.cards == null)
							{
								break;
							}
							bool flag34 = (nint)obj22 >= cards4._size;
							GameObject[] items = cards4._items;
							if (cards4._items == null)
							{
								break;
							}
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore7 = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)(object)items[obj22];
							if ((object)items[obj22] == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbp_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
							bool flag35 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbp_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
							IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
							Transform target4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							TweenerCore<Quaternion, Vector3, QuaternionOptions> t4 = ShortcutExtensions.DOLocalRotate(target4, (Vector3)(&obj24), 0.2f);
							if (TweenSettingsExtensions.ValidateAddToSequence(CS_0024_003C_003E8__locals70.s, (Tween)t4, false))
							{
								if (CS_0024_003C_003E8__locals70.s == null)
								{
									break;
								}
								Sequence sequence10 = Sequence.DoInsert(CS_0024_003C_003E8__locals70.s, (Tween)t4, s6.lastTweenInsertTime);
							}
							cards3 = CS_0024_003C_003E8__locals70.cards;
							obj22++;
							if (CS_0024_003C_003E8__locals70.cards == null)
							{
								break;
							}
							obj24 = obj25;
							obj23 = obj22;
						}
					}
				}
			}
			throw new NullReferenceException();
		};
		object message2;
		if (CS_0024_003C_003E8__locals70.s != null)
		{
			if (((Tween)s3)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)s3).creationLocked)
				{
					if (tweenCallback5 != null)
					{
						Sequence sequence5 = Sequence.DoInsertCallback(CS_0024_003C_003E8__locals70.s, tweenCallback5, ((Tween)s3).duration);
					}
					goto IL_0ce8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message2);
		goto IL_0ce8;
		IL_0ea3:
		Sequence sequence6 = TweenSettingsExtensions.AppendInterval(CS_0024_003C_003E8__locals70.s, 0.2f);
		Sequence s4 = CS_0024_003C_003E8__locals70.s;
		TweenCallback tweenCallback6 = delegate
		{
			List<ArcanaCardUI> pickableCards2 = CS_0024_003C_003E8__locals70.pickableCards;
			int random = CS_0024_003C_003E8__locals70.random;
			if (CS_0024_003C_003E8__locals70.random < pickableCards2._size)
			{
				ArcanaCardUI[] items = pickableCards2._items;
				ArcanaCardUI arcanaCardUI = items[random];
				int random2 = CS_0024_003C_003E8__locals70.random;
				ArcanaCardUI[] items2 = pickableCards2._items;
				int random3 = CS_0024_003C_003E8__locals70.random;
				ArcanaCardUI arcanaCardUI2 = items2[random2];
				if (CS_0024_003C_003E8__locals70.random < pickableCards2._size)
				{
					ArcanaCardUI[] items3 = pickableCards2._items;
					CS_0024_003C_003E8__locals70._003C_003E4__this.SetInfo(arcanaCardUI._data, arcanaCardUI2._type, items3[random3]);
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		};
		object message3;
		if (CS_0024_003C_003E8__locals70.s != null)
		{
			if (((Tween)s4)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)s4).creationLocked)
				{
					if (tweenCallback6 != null)
					{
						Sequence sequence7 = Sequence.DoInsertCallback(CS_0024_003C_003E8__locals70.s, tweenCallback6, ((Tween)s4).duration);
					}
					goto IL_1020;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message3 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message3);
		goto IL_1020;
		IL_0ce8:
		Sequence sequence8 = TweenSettingsExtensions.AppendInterval(CS_0024_003C_003E8__locals70.s, 0.25f);
		CS_0024_003C_003E8__locals70.random = 0;
		CS_0024_003C_003E8__locals70.t = null;
		List<ArcanaCardUI> pickableCards = new List<ArcanaCardUI>();
		CS_0024_003C_003E8__locals70.pickableCards = pickableCards;
		Sequence s5 = CS_0024_003C_003E8__locals70.s;
		TweenCallback tweenCallback7 = delegate
		{
			//IL_047c: Expected O, but got Ref
			//IL_00a2: Expected O, but got I
			//IL_0247: Expected O, but got I
			//IL_05fc: Expected O, but got Ref
			//IL_02f4: Expected O, but got I
			//IL_0351: Expected O, but got I
			//IL_038e: Expected O, but got I
			//IL_05de: Expected O, but got Ref
			//IL_0232->IL03bd: Incompatible stack heights: 1 vs 0
			//IL_026c->IL03bd: Incompatible stack heights: 1 vs 0
			//IL_029f->IL03bd: Incompatible stack heights: 2 vs 0
			//IL_0555->IL03bd: Incompatible stack heights: 2 vs 0
			//IL_062e->IL03bd: Incompatible stack heights: 3 vs 0
			//IL_0311->IL03bd: Incompatible stack heights: 4 vs 0
			//IL_0336->IL03bd: Incompatible stack heights: 4 vs 0
			//IL_0379->IL03bd: Incompatible stack heights: 4 vs 0
			//IL_03ae->IL03bd: Incompatible stack heights: 4 vs 0
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F2D1]");
			bool flag34 = (nint)0 != 0;
			List<ArcanaCardUI> unlocked2 = CS_0024_003C_003E8__locals70.unlocked;
			bool flag35 = CS_0024_003C_003E8__locals70.unlocked == null;
			Component component6 = (Component)(object)CS_0024_003C_003E8__locals70;
			if (!flag35)
			{
				List<ArcanaCardUI> unlocked3 = CS_0024_003C_003E8__locals70.unlocked;
				List<ArcanaCardUI>.Enumerator enumerator2 = default(List<ArcanaCardUI>.Enumerator);
				if (enumerator2.MoveNext())
				{
					object obj22 = null;
					GameManager core = GM.Core;
					bool flag36 = (object)GM.Core == null;
					component6 = GM.Core;
					if (!flag36)
					{
						component6 = (Component)(object)core._arcanaManager;
						if (core._arcanaManager != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v25 (UnityEngine.Component)+B0]");
							component6 = (Component)0;
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				List<ArcanaCardUI> pickableCards2 = CS_0024_003C_003E8__locals70.pickableCards;
				bool flag37 = CS_0024_003C_003E8__locals70.pickableCards == null;
				component6 = (Component)(&enumerator2);
				if (!flag37)
				{
					int num15 = (CS_0024_003C_003E8__locals70.random = UnityEngine.Random.RandomRangeInt(0, pickableCards2._size));
					List<ArcanaCardUI> pickableCards3 = CS_0024_003C_003E8__locals70.pickableCards;
					bool flag38 = CS_0024_003C_003E8__locals70.pickableCards == null;
					component6 = null;
					if (!flag38)
					{
						bool flag39 = num15 >= pickableCards3._size;
						object items = pickableCards3._items;
						bool flag40 = pickableCards3._items == null;
						component6 = null;
						if (!flag40)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v19 (System.Object)+20+v149 @ rax_v46 (System.Int32)*8]");
							object obj23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v19 (System.Object)+20+v149 @ rax_v46 (System.Int32)*8]");
							bool flag41 = (nint)0 == 0;
							component6 = null;
							if (!flag41)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdi_v20 (System.Object)+10]");
								bool flag42 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdi_v20 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform t4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								CS_0024_003C_003E8__locals70.t = t4;
								component6 = CS_0024_003C_003E8__locals70.t;
								if ((object)CS_0024_003C_003E8__locals70.t != null)
								{
									RectTransform component7 = CS_0024_003C_003E8__locals70.t.GetComponent<RectTransform>();
									bool flag43 = (object)component7 == null;
									component6 = (Component)(object)typeof(Vector2);
									if (!flag43)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1326 @ rax_v54 (UnityEngine.RectTransform)+10]");
										bool flag44 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1326 @ rax_v54 (UnityEngine.RectTransform)+10]");
										Vector2 value = default(Vector2);
										RectTransform.set_pivot_Injected((IntPtr)0, ref value);
										Vector3 ret2 = default(Vector3);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore7 = ShortcutExtensions.DOLocalRotate(CS_0024_003C_003E8__locals70.t, (Vector3)(&ret2), 0.2f);
										component6 = (Component)(object)CS_0024_003C_003E8__locals70.pickableCards;
										int random = CS_0024_003C_003E8__locals70.random;
										if (CS_0024_003C_003E8__locals70.pickableCards != null)
										{
											int random2 = CS_0024_003C_003E8__locals70.random;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v25 (UnityEngine.Component)+18]");
											bool flag45 = (nint)random2 >= (nint)0;
											component6 = (Component)(nint)((UnityEngine.Object)component6).m_CachedPtr;
											if (((UnityEngine.Object)component6).m_CachedPtr != (IntPtr)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v25 (UnityEngine.Component)+20+v152 @ rax_v65 (System.Int32)*8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v25 (UnityEngine.Component)+20+v152 @ rax_v65 (System.Int32)*8]");
													Tween tween = ((ArcanaCardUI)0).Reveal();
													Transform transform = (Transform)(object)CS_0024_003C_003E8__locals70._003C_003E4__this;
													if ((object)CS_0024_003C_003E8__locals70._003C_003E4__this != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v19 (UnityEngine.Transform)+138]");
														Transform transform2 = (Transform)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v19 (UnityEngine.Transform)+138]");
														if ((nint)0 != 0)
														{
															bool flag46 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
															Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret2);
															TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore8 = ShortcutExtensions.DOMove(CS_0024_003C_003E8__locals70.t, (Vector3)(&unlocked3), 0.2f);
															return;
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
			throw new NullReferenceException();
		};
		object message4;
		if (CS_0024_003C_003E8__locals70.s != null)
		{
			if (((Tween)s5)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)s5).creationLocked)
				{
					if (tweenCallback7 != null)
					{
						Sequence sequence9 = Sequence.DoInsertCallback(CS_0024_003C_003E8__locals70.s, tweenCallback7, ((Tween)s5).duration);
					}
					goto IL_0ea3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message4 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message4);
		goto IL_0ea3;
	}

	public ArcanaMainSelectionPage()
	{
		List<SpinningRingOfCards> cardRings = new List<SpinningRingOfCards>();
		_CardRings = cardRings;
		_darkSpawned = new List<GameObject>();
		_spawned = new List<GameObject>();
		_weaponSpawned = new List<GameObject>();
		_unlockedCards = new List<ArcanaCardUI>();
		_darkUnlockedCards = new List<ArcanaCardUI>();
		_tentacles = new List<GameObject>();
		_allSpawnedInOrder = new List<GameObject>();
		_arcanaCacheGroupName = "ArcanaAudio";
		_draftCardCount = 4;
		_draftMajors = new List<ArcanaType>();
		_discarded = new List<ArcanaType>();
		base._002Ector();
	}

	private void _003CEnableInputSecondMenu_003Eb__103_0()
	{
		Button component = _RerollButton.GetComponent<Button>();
		component.interactable = true;
		Button component2 = _MinorGetButton.GetComponent<Button>();
		component2.interactable = true;
		_hasFinishedPopulationAnimation = true;
		Transform target = _InfoGroup.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.2f);
		TweenCallback tweenCallback = delegate
		{
			Vector2 pivot = default(Vector2);
			VampireSurvivors.App.Tools.Extensions.SetPivot(_InfoGroup, pivot);
			Button component3 = _DarkButton.GetComponent<Button>();
			component3.interactable = true;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void _003CEnableInputSecondMenu_003Eb__103_1()
	{
		Vector2 pivot = default(Vector2);
		VampireSurvivors.App.Tools.Extensions.SetPivot(_InfoGroup, pivot);
		Button component = _DarkButton.GetComponent<Button>();
		component.interactable = true;
	}

	private void _003CPerformReRoll_003Eb__109_0()
	{
		CanvasGroup component = _MinorCardContainer.GetComponent<CanvasGroup>();
		component.interactable = true;
		Button component2 = _RerollButton.GetComponent<Button>();
		component2.interactable = true;
	}

	private void _003CEnableInputFirstMenu_003Eb__115_0()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003C_003CEnableInputFirstMenu_003Eb__115_0_003Ed stateMachine = default(_003C_003CEnableInputFirstMenu_003Eb__115_0_003Ed);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void _003CEnableInputFirstMenu_003Eb__115_1()
	{
		Vector2 pivot = default(Vector2);
		VampireSurvivors.App.Tools.Extensions.SetPivot(_InfoGroup, pivot);
		Button component = _DarkButton.GetComponent<Button>();
		component.interactable = true;
		if (_willPlayDarkanaIntro)
		{
			SwitchArcanaMode();
			_willPlayDarkanaIntro = false;
		}
	}

	private void _003CSwitchArcanaMode_003Eb__131_0()
	{
		Image component = _Skull.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 0f, 0.3f);
	}

	private unsafe void _003CSwitchArcanaMode_003Eb__131_1()
	{
		//IL_0373: Expected O, but got Ref
		//IL_03b3: Expected O, but got Ref
		//IL_03f3: Expected O, but got Ref
		//IL_0433: Expected O, but got Ref
		//IL_0b73: Expected O, but got Ref
		//IL_0bef: Expected O, but got Ref
		//IL_0c6a: Expected O, but got Ref
		//IL_0ce6: Expected O, but got Ref
		//IL_0d14: Expected I, but got O
		//IL_0d2a: Expected O, but got I
		//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d38: Expected O, but got Unknown
		//IL_0674: Expected I, but got O
		//IL_0d5e: Expected O, but got I4
		//IL_0d75: Expected I, but got I8
		//IL_0650: Expected I, but got I8
		//IL_09f5->IL06a9: Incompatible stack heights: 1 vs 0
		//IL_0397->IL06a9: Incompatible stack heights: 1 vs 0
		//IL_0737->IL0db4: Incompatible stack heights: 1 vs 0
		//IL_0873->IL0e00: Incompatible stack heights: 1 vs 0
		//IL_0a55->IL06a9: Incompatible stack heights: 2 vs 0
		//IL_010e->IL06a9: Incompatible stack heights: 1 vs 0
		//IL_079c->IL0dda: Incompatible stack heights: 1 vs 0
		//IL_03d7->IL06a9: Incompatible stack heights: 2 vs 0
		//IL_02d1->IL06a9: Incompatible stack heights: 1 vs 0
		//IL_08d8->IL0e26: Incompatible stack heights: 1 vs 0
		//IL_0165->IL06a9: Incompatible stack heights: 2 vs 0
		//IL_0ab5->IL06a9: Incompatible stack heights: 3 vs 0
		//IL_0328->IL06a9: Incompatible stack heights: 2 vs 0
		//IL_0417->IL06a9: Incompatible stack heights: 3 vs 0
		//IL_0180->IL0829: Incompatible stack heights: 3 vs 0
		//IL_0351->IL0965: Incompatible stack heights: 3 vs 0
		//IL_0b15->IL06a9: Incompatible stack heights: 4 vs 0
		//IL_0457->IL06a9: Incompatible stack heights: 4 vs 0
		//IL_04c3->IL06a9: Incompatible stack heights: 5 vs 0
		//IL_052d->IL06a9: Incompatible stack heights: 6 vs 0
		//IL_0599->IL06a9: Incompatible stack heights: 7 vs 0
		OnArcanaModeChange arcanaModeChanged = ArcanaMainSelectionPage.m_ArcanaModeChanged;
		if (ArcanaMainSelectionPage.m_ArcanaModeChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v48.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		List<GameObject> list = default(List<GameObject>);
		float duration;
		if (_arcanaMode == ArcanaMode.LIGHT)
		{
			if (_d20Tween != null)
			{
				DG.Tweening.TweenExtensions.Kill(_d20Tween);
				_d20Tween = null;
				Tween tween = null;
			}
			else
			{
				Tween tween = null;
			}
			SetLightDesign();
			if (_spawned != null)
			{
				list = _spawned;
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rsi_v57 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rsi_v57 (System.Object)+10]");
					GameObject.SetActive_Injected((IntPtr)0, true);
				}
				List<GameObject> darkSpawned = _darkSpawned;
				if (_darkSpawned != null)
				{
					list = _darkSpawned;
					List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
					while (enumerator2.MoveNext())
					{
						object obj2 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rsi_v56 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rsi_v56 (System.Object)+10]");
						GameObject.SetActive_Injected((IntPtr)0, false);
					}
					List<ArcanaCardUI> unlockedCards = _unlockedCards;
					if (_unlockedCards != null)
					{
						bool flag3 = unlockedCards._size <= 0;
						ArcanaCardUI[] items = unlockedCards._items;
						if (unlockedCards._items != null)
						{
							bool flag4 = items.Length <= 0;
							object obj3 = items[0];
							if ((object)items[0] != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rsi_v55 (System.Object)+10]");
								bool flag5 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rsi_v55 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
								GameObject cardToSelect = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
								IEnumerator routine = WaitAndForceSelect(cardToSelect);
								Coroutine coroutine = StartCoroutine(routine);
								object obj4 = null;
								goto IL_0829;
							}
						}
					}
				}
			}
		}
		else
		{
			if (_arcanaMode != ArcanaMode.DARK)
			{
				Tween tween = null;
				goto IL_0829;
			}
			if (_d20Tween == null)
			{
				RandomD20Fall();
			}
			if ((object)_D20 != null)
			{
				RawImage component = _D20.GetComponent<RawImage>();
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 1f, 0.3f);
				SetDarkDesign();
				if (_spawned != null)
				{
					list = _spawned;
					List<GameObject>.Enumerator enumerator3 = default(List<GameObject>.Enumerator);
					while (enumerator3.MoveNext())
					{
						object obj5 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1293 @ rsi_v52 (System.Object)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1293 @ rsi_v52 (System.Object)+10]");
						GameObject.SetActive_Injected((IntPtr)0, false);
					}
					List<GameObject> darkSpawned = _darkSpawned;
					if (_darkSpawned != null)
					{
						list = _darkSpawned;
						List<GameObject>.Enumerator enumerator4 = default(List<GameObject>.Enumerator);
						while (enumerator4.MoveNext())
						{
							object obj6 = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2018 @ rsi_v51 (System.Object)+10]");
							bool flag7 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2018 @ rsi_v51 (System.Object)+10]");
							GameObject.SetActive_Injected((IntPtr)0, true);
						}
						List<ArcanaCardUI> darkUnlockedCards = _darkUnlockedCards;
						if (_darkUnlockedCards != null)
						{
							bool flag8 = darkUnlockedCards._size <= 0;
							ArcanaCardUI[] items2 = darkUnlockedCards._items;
							if (darkUnlockedCards._items != null)
							{
								bool flag9 = items2.Length <= 0;
								object obj7 = items2[0];
								if ((object)items2[0] != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rsi_v50 (System.Object)+10]");
									bool flag10 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rsi_v50 (System.Object)+10]");
									IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
									GameObject cardToSelect2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
									IEnumerator routine2 = WaitAndForceSelect(cardToSelect2);
									Coroutine coroutine2 = StartCoroutine(routine2);
									duration = 0.3f;
									object obj4 = null;
									Tween tween = null;
									goto IL_0965;
								}
							}
						}
					}
				}
			}
		}
		goto IL_06a9;
		IL_0965:
		SetCount();
		SetRandomButton();
		object titleGroup = _TitleGroup;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore5;
		TweenCallback tweenCallback;
		if ((object)_TitleGroup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rsi_v20 (System.Object)+10]");
			bool flag11 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rsi_v20 (System.Object)+10]");
			IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			if ((object)transform != null)
			{
				transform.localEulerAngles = (Vector3)(&list);
				object infoGroup = _InfoGroup;
				if ((object)_InfoGroup != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rsi_v21 (System.Object)+10]");
					bool flag12 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rsi_v21 (System.Object)+10]");
					IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
					if ((object)transform2 != null)
					{
						transform2.localEulerAngles = (Vector3)(&list);
						object majorBackground = _MajorBackground;
						if ((object)_MajorBackground != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rsi_v22 (System.Object)+10]");
							bool flag13 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rsi_v22 (System.Object)+10]");
							IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
							Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
							if ((object)transform3 != null)
							{
								transform3.localEulerAngles = (Vector3)(&list);
								object cardContainer = _CardContainer;
								if ((object)_CardContainer != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rsi_v23 (System.Object)+10]");
									bool flag14 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rsi_v23 (System.Object)+10]");
									IntPtr gcHandlePtr6 = Component.get_transform_Injected((IntPtr)0);
									Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
									if ((object)transform4 != null)
									{
										transform4.localEulerAngles = (Vector3)(&list);
										object cardContainer2 = _CardContainer;
										if ((object)_CardContainer != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rsi_v24 (System.Object)+10]");
											bool flag15 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rsi_v24 (System.Object)+10]");
											IntPtr gcHandlePtr7 = Component.get_transform_Injected((IntPtr)0);
											Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
											TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target, (Vector3)(&list), duration);
											if (tweenerCore2 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3596 @ rax_v83 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 27;
												}
											}
											object titleGroup2 = _TitleGroup;
											if ((object)_TitleGroup != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rsi_v25 (System.Object)+10]");
												bool flag16 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rsi_v25 (System.Object)+10]");
												IntPtr gcHandlePtr8 = Component.get_transform_Injected((IntPtr)0);
												Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr8);
												TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DORotate(target2, (Vector3)(&list), duration);
												if (tweenerCore3 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3740 @ rax_v90 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
													if ((nint)0 != 0)
													{
														_ = 27;
													}
												}
												object infoGroup2 = _InfoGroup;
												if ((object)_InfoGroup != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rsi_v26 (System.Object)+10]");
													bool flag17 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rsi_v26 (System.Object)+10]");
													IntPtr gcHandlePtr9 = Component.get_transform_Injected((IntPtr)0);
													Transform target3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr9);
													TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DORotate(target3, (Vector3)(&list), duration);
													if (tweenerCore4 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3867 @ rax_v97 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
														if ((nint)0 != 0)
														{
															_ = 27;
														}
													}
													object majorBackground2 = _MajorBackground;
													if ((object)_MajorBackground != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rsi_v27 (System.Object)+10]");
														bool flag18 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rsi_v27 (System.Object)+10]");
														IntPtr gcHandlePtr10 = Component.get_transform_Injected((IntPtr)0);
														Transform target4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr10);
														tweenerCore5 = ShortcutExtensions.DORotate(target4, (Vector3)(&list), duration);
														if (tweenerCore5 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3995 @ rax_v104 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 27;
															}
														}
														tweenCallback = null;
														nint num = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ r10_v1 (Il2CppMethodInfo)+8]");
														((Delegate)tweenCallback).method_ptr = (IntPtr)0;
														((Delegate)tweenCallback).method = (nint)__ldftn(ArcanaMainSelectionPage._003CSwitchArcanaMode_003Eb__131_2);
														((Delegate)tweenCallback).m_target = this;
														((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ r10_v1 (Il2CppMethodInfo)+4C]");
														object obj8 = (nint)0 >> 4;
														object obj9 = obj8 & 1;
														nint num2;
														if (obj9 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ r10_v1 (Il2CppMethodInfo)+52]");
															if ((nint)0 == 0)
															{
																num2 = unchecked((nint)6447293664L);
																goto IL_0d55;
															}
														}
														num2 = ((Delegate)tweenCallback).method_ptr;
														((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
														goto IL_0d55;
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
		goto IL_06a9;
		IL_0829:
		duration = 0.3f;
		goto IL_0965;
		IL_0d55:
		object obj10 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		if (tweenerCore5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3995 @ rax_v104 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		return;
		IL_06a9:
		throw new NullReferenceException();
	}

	private void _003CSwitchArcanaMode_003Eb__131_2()
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		component.interactable = true;
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		if (!mainGameConfig._003CHasSeenDarkanaTransition_003Ek__BackingField)
		{
			PlayerOptions playerOptions2 = _playerOptions;
			PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
			mainGameConfig2._003CHasSeenDarkanaTransition_003Ek__BackingField = true;
			_playerOptions.Save();
		}
	}

	private void _003CRandomD20Fall_003Eb__138_0()
	{
		RandomD20Fall();
	}
}
