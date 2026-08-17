using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class MerchantUIPage : GameWindowedUIPage
{
	private sealed class _003C_003Ec__DisplayClass62_0
	{
		public GameObject result;

		internal void _003CShowEggResult_003Eb__0()
		{
			UnityEngine.Object.Destroy(result, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass63_0
	{
		public GameObject result;

		internal void _003CShowEggResultSprite_003Eb__0()
		{
			UnityEngine.Object.Destroy(result, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass65_0
	{
		public WeaponType t;

		internal bool _003CDoesPlayerAlreadyHaveWeapon_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - t;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CBuyAllRoutine_003Ed__54(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public MerchantUIPage _003C_003E4__this;

		public RectTransform sender;

		public float count;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0056: Expected I4, but got I8
			//IL_01a3: Invalid comparison between F4 and I4
			//IL_01c8: Expected I4, but got O
			MerchantUIPage merchantUIPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003Ci_003E5__2 = _003C_003E1__state;
				goto IL_0197;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					_003C_003E4__this.ShowEggResultSprite(sender);
					int[] goldenEggSFXDetune = merchantUIPage._goldenEggSFXDetune;
					int goldenEggSoundIndex = merchantUIPage._goldenEggSoundIndex + 1;
					merchantUIPage._goldenEggSoundIndex = goldenEggSoundIndex;
					if (merchantUIPage._goldenEggSFXDetune != null)
					{
						int num = merchantUIPage._goldenEggSoundIndex % goldenEggSFXDetune.Length;
						int sfxIndex = goldenEggSFXDetune[num] * 100;
						MakeEggNoise(sfxIndex, 307);
						int num2 = _003Ci_003E5__2 + 1;
						_003Ci_003E5__2 = num2;
						goto IL_0197;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_0165;
			IL_0197:
			if (count > (float)_003Ci_003E5__2)
			{
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 0.01f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_0165;
			IL_0165:
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

	private sealed class _003CWaitAndTween_003Ed__72(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public MerchantUIPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_001c: Expected I4, but got I8
			//IL_018e: Expected I4, but got I8
			//IL_08f6: Expected F4, but got I
			//IL_08ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0904: Expected O, but got Unknown
			//IL_0a92: Expected O, but got Ref
			//IL_0b05: Expected O, but got Ref
			//IL_094b: Expected O, but got Ref
			//IL_034c: Expected O, but got I
			//IL_03e0: Expected O, but got I
			//IL_0426: Expected O, but got I
			//IL_0436: Unknown result type (might be due to invalid IL or missing references)
			//IL_043b: Expected O, but got Unknown
			//IL_03ab: Expected O, but got Ref
			//IL_0b6b: Expected O, but got Ref
			//IL_0990: Expected O, but got Ref
			//IL_0f95: Expected O, but got I4
			//IL_0c34: Expected O, but got Ref
			//IL_09d9: Expected O, but got Ref
			//IL_0467: Expected O, but got I
			//IL_0caa: Expected O, but got Ref
			//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bd: Expected O, but got Unknown
			//IL_0d83: Expected O, but got I4
			//IL_0a45: Expected F4, but got I
			//IL_0a4e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a53: Expected O, but got Unknown
			//IL_0dda: Expected O, but got Ref
			//IL_0e38: Expected O, but got Ref
			//IL_0f03: Expected O, but got Ref
			//IL_00b3->IL0895: Incompatible stack heights: 1 vs 0
			//IL_00f6->IL0895: Incompatible stack heights: 2 vs 0
			//IL_0129->IL0895: Incompatible stack heights: 2 vs 0
			//IL_02a4->IL0895: Incompatible stack heights: 1 vs 0
			//IL_02e7->IL0895: Incompatible stack heights: 2 vs 0
			//IL_0911->IL0f36: Incompatible stack heights: 3 vs 0
			//IL_0ace->IL0895: Incompatible stack heights: 1 vs 0
			//IL_031a->IL0895: Incompatible stack heights: 2 vs 0
			//IL_0b34->IL0895: Incompatible stack heights: 2 vs 0
			//IL_0978->IL0895: Incompatible stack heights: 3 vs 0
			//IL_06ae->IL0895: Incompatible stack heights: 2 vs 0
			//IL_036c->IL0895: Incompatible stack heights: 3 vs 0
			//IL_03ca->IL097d: Incompatible stack heights: 3 vs 4
			//IL_0bfd->IL0895: Incompatible stack heights: 3 vs 0
			//IL_0c70->IL0895: Incompatible stack heights: 4 vs 0
			//IL_0487->IL0895: Incompatible stack heights: 7 vs 0
			//IL_0cea->IL0895: Incompatible stack heights: 5 vs 0
			//IL_0548->IL0895: Incompatible stack heights: 8 vs 0
			//IL_0597->IL0895: Incompatible stack heights: 9 vs 0
			//IL_0d43->IL0895: Incompatible stack heights: 6 vs 0
			//IL_05da->IL0895: Incompatible stack heights: 10 vs 0
			//IL_0ffc->IL0895: Incompatible stack heights: 6 vs 0
			//IL_060d->IL0895: Incompatible stack heights: 10 vs 0
			//IL_0da0->IL0895: Incompatible stack heights: 7 vs 0
			//IL_0a60->IL0f9f: Incompatible stack heights: 11 vs 0
			//IL_0726->IL0895: Incompatible stack heights: 7 vs 0
			//IL_084c->IL0887: Incompatible stack heights: 16 vs 0
			//IL_0871->IL0887: Incompatible stack heights: 16 vs 0
			//IL_0887->IL0887: Incompatible stack heights: 16 vs 0
			object obj2 = default(object);
			object obj = (object)(&obj2);
			MerchantUIPage merchantUIPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				RectTransform rectTransform = null;
				RectTransform rectTransform2 = null;
				if (!flag)
				{
					while (true)
					{
						List<GameObject> spawned = merchantUIPage._spawned;
						if (merchantUIPage._spawned == null)
						{
							break;
						}
						if ((nint)rectTransform2 < spawned._size)
						{
							bool flag2 = (nint)rectTransform >= spawned._size;
							GameObject[] items = spawned._items;
							if (spawned._items == null)
							{
								break;
							}
							bool flag3 = (nint)rectTransform >= items.Length;
							if ((object)items[(object)rectTransform] == null)
							{
								break;
							}
							CanvasGroup component = items[(object)rectTransform].GetComponent<CanvasGroup>();
							if ((object)component == null)
							{
								break;
							}
							bool flag4 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
							CanvasGroup.set_alpha_Injected(((UnityEngine.Object)component).m_CachedPtr, 0f);
							rectTransform = (RectTransform)(rectTransform + 1);
							rectTransform2 = rectTransform;
							continue;
						}
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0887;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)merchantUIPage._Grid != null)
				{
					merchantUIPage._Grid.enabled = false;
					if ((object)merchantUIPage._GridFitter != null)
					{
						merchantUIPage._GridFitter.enabled = false;
						List<Vector3> list = new List<Vector3>();
						RectTransform rectTransform3 = null;
						RectTransform rectTransform4 = null;
						Vector2 endValue = default(Vector2);
						while (true)
						{
							List<GameObject> spawned2 = merchantUIPage._spawned;
							if (merchantUIPage._spawned == null)
							{
								break;
							}
							if ((nint)rectTransform4 < spawned2._size)
							{
								bool flag5 = (nint)rectTransform3 >= spawned2._size;
								GameObject[] items2 = spawned2._items;
								if (spawned2._items == null)
								{
									break;
								}
								bool flag6 = (nint)rectTransform3 >= items2.Length;
								if ((object)items2[(object)rectTransform3] == null)
								{
									break;
								}
								RectTransform component2 = items2[(object)rectTransform3].GetComponent<RectTransform>();
								if ((object)component2 == null)
								{
									break;
								}
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v202 (UnityEngine.RectTransform)+10]");
								bool flag7 = (nint)0 == 0;
								object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v202 (UnityEngine.RectTransform)+10]");
								RectTransform.get_anchoredPosition_Injected((IntPtr)0, out *(Vector2*)obj3);
								if (list == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
								Vector3 vector = (Vector3)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v102 (UnityEngine.Vector3)+18]");
								if (num >= 0)
								{
									Vector3 item = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
									_ = 0;
									list.AddWithResize(item);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
									object obj4 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v102 (UnityEngine.Vector3)+18]");
									bool flag8 = num2 >= 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
									object obj5 = (nint)0 * (nint)2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
									object obj6 = 0 + obj5;
									_ = 0;
								}
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v202 (UnityEngine.RectTransform)+10]");
								bool flag9 = (nint)0 == 0;
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v202 (UnityEngine.RectTransform)+10]");
								RectTransform.get_anchoredPosition_Injected((IntPtr)0, out *(Vector2*)obj7);
								object obj8 = Screen.width;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v202 (UnityEngine.RectTransform)+10]");
								bool flag10 = (nint)0 == 0;
								object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v202 (UnityEngine.RectTransform)+10]");
								RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref *(Vector2*)obj9);
								RectTransform rectTransform5 = rectTransform3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
								bool flag11 = (nint)rectTransform5 >= 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rax_v102 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
								if ((nint)0 == 0)
								{
									break;
								}
								RectTransform rectTransform6 = rectTransform3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v191+18]");
								bool flag12 = (nint)rectTransform6 >= 0;
								object obj11 = rectTransform3 * 2;
								object obj12 = (object)rectTransform3 + obj11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v191+28+v2905 @ rax_v222*4]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v191+20+v2905 @ rax_v222*4]");
								_ = 0;
								float num3 = (float)rectTransform3 * 0.03f;
								float duration = num3 + 0.15f;
								TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(component2, endValue, duration);
								List<GameObject> spawned3 = merchantUIPage._spawned;
								if (merchantUIPage._spawned == null)
								{
									break;
								}
								bool flag13 = (nint)rectTransform3 >= spawned3._size;
								GameObject[] items3 = spawned3._items;
								if (spawned3._items == null)
								{
									break;
								}
								bool flag14 = (nint)rectTransform3 >= items3.Length;
								if ((object)items3[(object)rectTransform3] == null)
								{
									break;
								}
								CanvasGroup component3 = items3[(object)rectTransform3].GetComponent<CanvasGroup>();
								if ((object)component3 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v226 (UnityEngine.CanvasGroup)+10]");
								bool flag15 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v226 (UnityEngine.CanvasGroup)+10]");
								CanvasGroup.set_alpha_Injected((IntPtr)0, 0f);
								rectTransform3 = (RectTransform)(rectTransform3 + 1);
								rectTransform4 = rectTransform3;
								continue;
							}
							goto IL_061c;
						}
					}
				}
			}
			goto IL_0895;
			IL_0887:
			return false;
			IL_0895:
			throw new NullReferenceException();
			IL_061c:
			if (merchantUIPage.hideBackgroundMask)
			{
				goto IL_0887;
			}
			RectTransform panel = merchantUIPage._Panel;
			if ((object)merchantUIPage._Panel != null)
			{
				_ = 0;
				bool flag16 = ((UnityEngine.Object)panel).m_CachedPtr == (IntPtr)0;
				object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				RectTransform.get_anchoredPosition_Injected(((UnityEngine.Object)panel).m_CachedPtr, out *(Vector2*)obj13);
				RectTransform panel2 = merchantUIPage._Panel;
				if ((object)merchantUIPage._Panel != null)
				{
					_ = 0;
					bool flag17 = ((UnityEngine.Object)panel2).m_CachedPtr == (IntPtr)0;
					object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					RectTransform.get_rect_Injected(((UnityEngine.Object)panel2).m_CachedPtr, out *(Rect*)obj14);
					if ((object)merchantUIPage._Mask != null)
					{
						RectTransform rectTransform7 = merchantUIPage._Mask.rectTransform;
						if ((object)rectTransform7 != null)
						{
							_ = 0;
							bool flag18 = ((UnityEngine.Object)rectTransform7).m_CachedPtr == (IntPtr)0;
							object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
							RectTransform.get_sizeDelta_Injected(((UnityEngine.Object)rectTransform7).m_CachedPtr, out *(Vector2*)obj15);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
							float num4 = 0f * 0.35f;
							RectTransform panel3 = merchantUIPage._Panel;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-1D]");
							float num5 = 0f * 0.5f;
							float num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
							float num7 = num6 + 0f;
							float endValue2 = num7 - num4;
							if ((object)merchantUIPage._Panel != null)
							{
								_ = 0;
								bool flag19 = ((UnityEngine.Object)panel3).m_CachedPtr == (IntPtr)0;
								object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
								RectTransform.get_anchoredPosition_Injected(((UnityEngine.Object)panel3).m_CachedPtr, out *(Vector2*)obj16);
								object panel4 = merchantUIPage._Panel;
								if ((object)merchantUIPage._Panel != null)
								{
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v48 (System.Object)+10]");
									bool flag20 = (nint)0 == 0;
									object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v48 (System.Object)+10]");
									RectTransform.get_rect_Injected((IntPtr)0, out *(Rect*)obj17);
									object mask = merchantUIPage._Mask;
									if ((object)merchantUIPage._Mask != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rbx_v49 (System.Object)+10]");
										bool flag21 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rbx_v49 (System.Object)+10]");
										Behaviour.set_enabled_Injected((IntPtr)0, true);
										if ((object)merchantUIPage._Mask != null)
										{
											RectTransform rectTransform8 = merchantUIPage._Mask.rectTransform;
											IntPtr main_Injected = Camera.get_main_Injected();
											Camera camera = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Camera>(main_Injected);
											if ((object)camera != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v139 (UnityEngine.Camera)+10]");
												bool flag22 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v139 (UnityEngine.Camera)+10]");
												object obj18 = Camera.get_pixelHeight_Injected((IntPtr)0);
												if ((object)merchantUIPage._Mask != null)
												{
													RectTransform rectTransform9 = merchantUIPage._Mask.rectTransform;
													if ((object)rectTransform9 != null)
													{
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v144 (UnityEngine.RectTransform)+10]");
														bool flag23 = (nint)0 == 0;
														object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v144 (UnityEngine.RectTransform)+10]");
														RectTransform.get_sizeDelta_Injected((IntPtr)0, out *(Vector2*)obj19);
														bool flag24 = (object)rectTransform8 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3111 @ rax_v134 (UnityEngine.RectTransform)+10]");
														bool flag25 = (nint)0 == 0;
														object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3111 @ rax_v134 (UnityEngine.RectTransform)+10]");
														RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref *(Vector2*)obj20);
														object mask2 = merchantUIPage._Mask;
														bool flag26 = (object)merchantUIPage._Mask == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rbx_v53 (System.Object)+10]");
														bool flag27 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rbx_v53 (System.Object)+10]");
														IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
														Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
														bool flag28 = (object)transform == null;
														_ = 1f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3445 @ rax_v158 (UnityEngine.Transform)+10]");
														bool flag29 = (nint)0 == 0;
														object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3445 @ rax_v158 (UnityEngine.Transform)+10]");
														Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj21);
														bool flag30 = (object)merchantUIPage._Mask == null;
														RectTransform rectTransform10 = merchantUIPage._Mask.rectTransform;
														TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTweenModuleUI.DOAnchorPosY(rectTransform10, endValue2, 2f);
														if (tweenerCore2 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3695 @ rax_v164 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 4;
																_ = 0;
															}
														}
														bool flag31 = (object)merchantUIPage._Mask == null;
														RectTransform rectTransform11 = merchantUIPage._Mask.rectTransform;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(rectTransform11, 1f, 2f);
														if (tweenerCore3 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ rax_v167 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 4;
																_ = 0;
															}
														}
														goto IL_0887;
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
			goto IL_0895;
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

	private ShopItemUI _ShopItemPrefab;

	private RectTransform _ItemContainer;

	private GameObject _EggResultPrefab;

	private RectTransform _Panel;

	private UISpriteAnimation _BurstVFX;

	private GridLayoutGroup _Grid;

	private ContentSizeFitter _GridFitter;

	private RectTransform _CurrencyPanel;

	private Image _Mask;

	private SignalBus _signalBus;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private EggManager _egg;

	private AdventureManager _adventureManager;

	private ShopFactory _shopFactory;

	private Dictionary<ItemType, ItemData> _items;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private Dictionary<PowerUpType, List<PowerUpData>> _powerUps;

	private Coroutine _maxEggsPurchasedRoutine;

	private string[] _textColors;

	private float _SpamPressTimer;

	private bool _SpamPressFirst;

	protected bool hideBackgroundMask;

	private List<string> _itemSprites;

	private int _goldenEggSoundIndex;

	private int[] _goldenEggSFXDetune;

	private ShopItemUI _selected;

	private VampireSurvivors.Objects.Characters.CharacterController _currentCharacter;

	private TutorialPopup _spawnedTutorialPopup;

	private List<ItemType> ForbiddenItemsInMultiplayer;

	private void Construct(SignalBus signalBus, DataManager data, PlayerOptions playerOptions, GameSessionData session, EggManager egg, AdventureManager adventureManager, ShopFactory shopFactory)
	{
		//IL_009b: Expected O, but got I4
		//IL_009b: Expected O, but got I
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_01c5: Expected O, but got I
		//IL_0147: Expected O, but got I4
		//IL_0147: Expected O, but got I
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_01fe: Expected O, but got I
		_signalBus = signalBus;
		_data = data;
		_playerOptions = playerOptions;
		EggManager egg2 = default(EggManager);
		_egg = egg2;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
		ShopFactory shopFactory2 = default(ShopFactory);
		_shopFactory = shopFactory2;
		Action<UISignals.OpenMerchantSignal> action = SetCurrentCharacter;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.OpenMerchantSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.OpenMerchantSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v21 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action<OnlineSignals.OnlinePurchase> action3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FF60");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlinePurchase>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlinePurchase>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v36 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus3.SubscribeInternal(signalType2, (object)null, (object)0, (Action<object>)(object)session);
	}

	protected override void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3305]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	private void OnRemotePurchase(OnlineSignals.OnlinePurchase purchase)
	{
		//IL_0279: Expected O, but got I
		//IL_0291: Expected O, but got I4
		_currentCharacter = purchase.PurchasingPlayer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		GameObject gameObject = (GameObject)0;
		if (purchase.Weapon != WeaponType.VOID)
		{
			if (_spawned != null)
			{
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				if (enumerator.MoveNext())
				{
					gameObject = null;
					throw new NullReferenceException();
				}
				return;
			}
		}
		else
		{
			object obj = (int)purchase.Weapon >> 32;
			if (obj != null)
			{
				if (_spawned != null)
				{
					List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
					if (enumerator2.MoveNext())
					{
						gameObject = null;
						throw new NullReferenceException();
					}
					return;
				}
			}
			else
			{
				if (purchase.Index < 0)
				{
					return;
				}
				gameObject = (GameObject)(object)_spawned;
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
					WeaponType weapon = purchase.Weapon;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rcx_v19 (UnityEngine.GameObject)+18]");
					if ((nint)weapon >= (nint)0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					GameObject gameObject2 = default(GameObject);
					if ((object)gameObject2 != null)
					{
						ShopItemUI component = gameObject2.GetComponent<ShopItemUI>();
						InvokeCustomPurchaseActionAndClose(component);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		//IL_0025: Expected O, but got I4
		//IL_0025: Expected O, but got I
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		Action<UISignals.OpenMerchantSignal> token = SetCurrentCharacter;
		((MerchantUIPage)0).SetCurrentCharacter((UISignals.OpenMerchantSignal)1);
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action<OnlineSignals.OnlinePurchase> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FF60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	public void Close()
	{
		//IL_0074: Expected I8, but got O
		//IL_008c: Expected I8, but got O
		//IL_0058: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0040");
			return;
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).CloseMerchant((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbx_v3 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public override float GetCurrency()
	{
		PlayerOptionsData config = _playerOptions.Config;
		return config._003CCoins_003Ek__BackingField;
	}

	public override void SetSelected(ShopItemUI item)
	{
		_selected = item;
		Button component = _BackButton.GetComponent<Button>();
		Button component2 = item.GetComponent<Button>();
		SetNavigationUp(component, component2);
	}

	public override void Purchase(WeaponType t, WeaponData d, float price, ShopItemUI shopItemUI)
	{
		//IL_00b9: Expected I4, but got I8
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
			_playerOptions.RemoveCoins(0, removeFromLifetime: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm6\"");
			ShopItemUI shopItemUI2 = default(ShopItemUI);
			ProcessWeaponPurchase(t, 1, shopItemUI2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
			_playerOptions.RemoveCoins(0, removeFromLifetime: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
			int price2 = default(int);
			VampireSurvivors.Objects.Characters.CharacterController purchasingPlayer = default(VampireSurvivors.Objects.Characters.CharacterController);
			OnlineStageManager._instance.SendMerchantPurchase(t, ItemType.VOID, -1, price2, purchasingPlayer);
		}
	}

	public override void OnUserConfirmInput()
	{
		OnMerchantEnterPressed();
	}

	public override void Purchase(ItemType t, ItemData d, ShopItemUI item, float price, RectTransform sender)
	{
		//IL_0157: Expected I4, but got I8
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			if (t != ItemType.DUMMY_GOLDENEGG_MAX)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rsp+70h]\"");
				_playerOptions.RemoveCoins(0, removeFromLifetime: true);
			}
			else
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptionsData config2 = _playerOptions.Config;
				float valueToSubtract = default(float);
				float num = MathUtils.SubtractValueCapped(config2._003CCoins_003Ek__BackingField, valueToSubtract);
				config._003CCoins_003Ek__BackingField = num;
				PlayerOptionsData config3 = _playerOptions.Config;
				PlayerOptionsData config4 = _playerOptions.Config;
				float num2 = MathUtils.SubtractValueCapped(config4._003CLifetimeCoins_003Ek__BackingField, valueToSubtract);
				config3._003CLifetimeCoins_003Ek__BackingField = num2;
				PlayerOptions.OnValueChanged goldUpdated = PlayerOptions.GoldUpdated;
				if (PlayerOptions.GoldUpdated != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v383.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				_playerOptions.Save();
			}
			RectTransform sender2 = default(RectTransform);
			ProcessItemPurchase(t, item, sender2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rsp+70h]\"");
			_playerOptions.RemoveCoins(0, removeFromLifetime: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rsp+70h]\"");
			int price2 = default(int);
			VampireSurvivors.Objects.Characters.CharacterController purchasingPlayer = default(VampireSurvivors.Objects.Characters.CharacterController);
			OnlineStageManager._instance.SendMerchantPurchase(WeaponType.VOID, t, -1, price2, purchasingPlayer);
		}
	}

	public void PurchaseSelected()
	{
		//IL_0972: Expected I4, but got I8
		//IL_0300: Expected O, but got I4
		//IL_027c: Expected I, but got O
		//IL_028c: Expected O, but got I
		//IL_02b1: Expected O, but got I
		//IL_07f5: Expected I, but got O
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_03a5: Expected O, but got I4
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Expected O, but got Unknown
		//IL_0bb4: Expected O, but got I4
		//IL_0bce: Expected O, but got I4
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0722: Expected O, but got Unknown
		//IL_0406: Expected O, but got I4
		//IL_0765: Expected I, but got O
		//IL_0785: Expected I4, but got O
		//IL_04f0: Expected I, but got O
		//IL_050a: Expected I4, but got O
		//IL_0448: Expected I, but got O
		//IL_0455: Expected O, but got I4
		//IL_045a: Expected I4, but got O
		//IL_07af: Expected I, but got O
		//IL_07cf: Expected I4, but got O
		//IL_0475: Expected O, but got I4
		ShopItemUI selected = _selected;
		if ((object)_selected == null || ((UnityEngine.Object)selected).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ShopItemUI selected2 = _selected;
		if (!((SelectableUI)selected2).isSelected || selected2._isSoldOut)
		{
			return;
		}
		float currency = selected2._page.GetCurrency();
		double num = default(double);
		if (num < (double)selected2._price)
		{
			return;
		}
		ShopItemUI selected3 = _selected;
		float num3;
		if (selected3._itemType == ItemType.DUMMY_GOLDENEGG_MAX)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			float num2 = config._003CCoins_003Ek__BackingField / 10000f;
			num3 = config2._003CCoins_003Ek__BackingField;
			num = Math.Floor(num2);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			float num4 = 0f * 10000f;
			if (!(config2._003CCoins_003Ek__BackingField > num4))
			{
				object obj = num4 & -2147483649L;
				if ((nint)obj <= 2139095040)
				{
					goto IL_0202;
				}
			}
			num3 = num4;
			goto IL_0202;
		}
		goto IL_021e;
		IL_0202:
		_selected.SetPrice(num3);
		float num5 = num3;
		goto IL_021e;
		IL_021e:
		ShopItemUI selected4 = _selected;
		WeaponData weaponData2;
		float num7;
		double num8;
		nint num6;
		WeaponData weaponData;
		WeaponType weaponType2;
		if (!selected4._003CIsCustomActionItem_003Ek__BackingField)
		{
			if (selected4._itemType == ItemType.VOID)
			{
				num6 = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v19 (VampireSurvivors.ShopItemUI)+E0]");
				weaponData = (WeaponData)0;
				WeaponType weaponType = selected4._weaponType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v19 (VampireSurvivors.ShopItemUI)+E0]");
				Purchase(weaponType, (WeaponData)0, selected4._price, null);
				weaponType2 = selected4._weaponType;
				goto IL_0820;
			}
			RectTransform component = selected4.GetComponent<RectTransform>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA00F0");
			bool flag = selected4._itemType == ItemType.RELIC_GLASSMASK;
			weaponData2 = (WeaponData)selected4._itemType;
			num7 = num5;
			num8 = num;
			if (!flag)
			{
				EggFloat eggFloat3;
				EggFloat eggFloat4;
				if (selected4._itemType != ItemType.DUMMY_BANISH)
				{
					if (selected4._itemType != ItemType.DUMMY_REROLL)
					{
						if (selected4._itemType != ItemType.DUMMY_SKIP)
						{
							bool flag2 = selected4._itemType == ItemType.DUMMY_ARC;
							weaponData2 = (WeaponData)selected4._itemType;
							num7 = num5;
							num8 = num;
							if (!flag2)
							{
								if (selected4._itemType == ItemType.DUMMY_REVIVAL)
								{
									_selected.SoldOut();
									VampireSurvivors.Objects.Characters.CharacterController currentCharacter = _currentCharacter;
									PlayerModifierStats playerStats = currentCharacter._playerStats;
									EggDouble eggDouble = (playerStats.Revivals = playerStats._003CRevivals_003Ek__BackingField + 1.0);
									num6 = (nint)selected4._itemData;
									weaponData = null;
									num5 = 1f;
									weaponType2 = (WeaponType)eggDouble;
									goto IL_0820;
								}
								bool flag3 = selected4._itemType == ItemType.RELIC_EME_DISK;
								weaponData2 = (WeaponData)selected4._itemType;
								num7 = num5;
								num8 = num;
								if (!flag3)
								{
									bool flag4 = selected4._itemType != ItemType.RELIC_LEM_DISK;
									num6 = (nint)selected4._itemData;
									weaponData = (WeaponData)selected4._itemType;
									weaponType2 = (WeaponType)this;
									if (flag4)
									{
										goto IL_0820;
									}
									weaponData2 = (WeaponData)selected4._itemType;
									num7 = num5;
									num8 = num;
								}
							}
							goto IL_07dd;
						}
						VampireSurvivors.Objects.Characters.CharacterController currentCharacter2 = _currentCharacter;
						PlayerModifierStats playerStats2 = currentCharacter2._playerStats;
						EggFloat eggFloat = (playerStats2.Skips = playerStats2._003CSkips_003Ek__BackingField + 1f);
						VampireSurvivors.Objects.Characters.CharacterController currentCharacter3 = _currentCharacter;
						PlayerModifierStats playerStats3 = currentCharacter3._playerStats;
						eggFloat3 = playerStats3._003CSkips_003Ek__BackingField;
						weaponData2 = null;
						num7 = 1f;
						eggFloat4 = eggFloat;
					}
					else
					{
						VampireSurvivors.Objects.Characters.CharacterController currentCharacter4 = _currentCharacter;
						PlayerModifierStats playerStats4 = currentCharacter4._playerStats;
						EggFloat eggFloat5 = (playerStats4.ReRolls = playerStats4._003CReRolls_003Ek__BackingField + 1f);
						VampireSurvivors.Objects.Characters.CharacterController currentCharacter5 = _currentCharacter;
						PlayerModifierStats playerStats5 = currentCharacter5._playerStats;
						eggFloat3 = playerStats5._003CReRolls_003Ek__BackingField;
						weaponData2 = null;
						num7 = 1f;
						eggFloat4 = eggFloat5;
					}
				}
				else
				{
					VampireSurvivors.Objects.Characters.CharacterController currentCharacter6 = _currentCharacter;
					PlayerModifierStats playerStats6 = currentCharacter6._playerStats;
					EggFloat eggFloat7 = (playerStats6.Banish = playerStats6._003CBanish_003Ek__BackingField + 1f);
					VampireSurvivors.Objects.Characters.CharacterController currentCharacter7 = _currentCharacter;
					PlayerModifierStats playerStats7 = currentCharacter7._playerStats;
					eggFloat3 = playerStats7._003CBanish_003Ek__BackingField;
					weaponData2 = null;
					num7 = 1f;
					eggFloat4 = eggFloat7;
				}
				num8 = (double)eggFloat3._eggVal + (double)eggFloat3._val;
				object obj2 = num8 & -2147483649L;
				if ((nint)obj2 != 2139095040)
				{
					object obj3 = num8 & -2147483649L;
					if ((nint)obj3 <= 2139095040)
					{
						bool flag5 = num8 == -1.0 / 0.0;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D1CA3Ch\"");
						num6 = (nint)selected4._itemData;
						weaponData = weaponData2;
						num5 = num7;
						num = num8;
						weaponType2 = (WeaponType)eggFloat4;
						if (!flag5)
						{
							bool flag6 = num8 < 20.0;
							num6 = (nint)selected4._itemData;
							weaponData = weaponData2;
							num5 = num7;
							num = num8;
							weaponType2 = (WeaponType)eggFloat4;
							if (!flag6)
							{
								goto IL_07dd;
							}
						}
						goto IL_0820;
					}
				}
			}
			goto IL_07dd;
		}
		GameManager core3 = GM.Core;
		if (!core3._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
			_playerOptions.RemoveCoins(0, removeFromLifetime: true);
			InvokeCustomPurchaseActionAndClose(_selected);
			return;
		}
		List<GameObject> spawned = _spawned;
		int num9 = 0;
		int value = 0;
		int num10 = 0;
		OnlineStageManager onlineStageManager = default(OnlineStageManager);
		int price = default(int);
		VampireSurvivors.Objects.Characters.CharacterController purchasingPlayer = default(VampireSurvivors.Objects.Characters.CharacterController);
		while (true)
		{
			bool flag7 = num10 >= spawned._size;
			int index = -1;
			if (!flag7)
			{
				GameObject gameObject = _selected.gameObject;
				List<GameObject> spawned2 = _spawned;
				if (num9 >= spawned2._size)
				{
					break;
				}
				GameObject[] items = spawned2._items;
				GameObject gameObject2 = items[num9];
				bool flag8 = (object)items[num9] == null;
				bool flag9 = (object)gameObject == null;
				object obj4 = flag9 & flag8;
				bool flag10 = obj4 == null;
				object obj5 = !flag10;
				if (obj5 == null)
				{
					bool flag11;
					if ((object)items[num9] != null)
					{
						if ((object)gameObject != null)
						{
							object obj6 = (object)gameObject - (object)items[num9];
							flag11 = obj6 == null;
						}
						else
						{
							flag11 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						flag11 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					}
					if (!flag11)
					{
						spawned = _spawned;
						num9++;
						value = 0;
						num10 = num9;
						continue;
					}
				}
				index = num9;
				value = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
			_playerOptions.RemoveCoins(value, removeFromLifetime: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
			onlineStageManager.SendMerchantPurchase(WeaponType.VOID, ItemType.VOID, index, price, purchasingPlayer);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0820:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		object obj7 = default(object);
		if (obj7 != null)
		{
			PlayerOptions playerOptions = _playerOptions;
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj8 = default(object);
			if (obj8 == null)
			{
				PlayerOptions playerOptions2 = _playerOptions;
				PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		return;
		IL_07dd:
		_selected.SoldOut();
		num6 = (nint)selected4._itemData;
		weaponData = weaponData2;
		num5 = num7;
		num = num8;
		weaponType2 = WeaponType.VOID;
		goto IL_0820;
	}

	private void InvokeCustomPurchaseActionAndClose(ShopItemUI item)
	{
		ShopItemUI shopItemUI = default(ShopItemUI);
		Action onPurchased = shopItemUI.OnPurchased;
		if (shopItemUI.OnPurchased != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v43.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0040");
	}

	protected override void OnHideStart(GameObject g)
	{
		//IL_012a: Expected I, but got O
		//IL_0078: Expected I, but got O
		//IL_0161: Expected O, but got I
		HelpButton.Clear();
		GameManager core = GM.Core;
		Pickup pickup = core._003CCurrentCustomMerchant_003Ek__BackingField;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField && (object)core._003CCurrentCustomMerchant_003Ek__BackingField != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
		{
			nint num = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v435 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+478] (should have been resolved before IL gen)");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v3 (VampireSurvivors.Objects.Pickups.Pickup)+160]");
				if ((nint)0 == 0)
				{
					((Pickup)core._003CCurrentCustomMerchant_003Ek__BackingField).GetTaken();
					_ = 1;
				}
			}
			GM.Core.ClearCurrentCustomMerchant();
		}
		else
		{
			if ((object)core._003CCurrentCustomMerchant_003Ek__BackingField == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			nint num2 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v450 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+478] (should have been resolved before IL gen)");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v3 (VampireSurvivors.Objects.Pickups.Pickup)+190]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v26+10]");
				if ((nint)0 != 42)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v3 (VampireSurvivors.Objects.Pickups.Pickup)+160]");
					if ((nint)0 == 0)
					{
						((Pickup)core._003CCurrentCustomMerchant_003Ek__BackingField).GetTaken();
						_ = 1;
					}
				}
			}
			GameManager core2 = GM.Core;
			core2._003CCurrentCustomMerchant_003Ek__BackingField = null;
		}
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_06b5: Expected F4, but got I4
		//IL_0a5f: Expected O, but got I4
		//IL_0abc: Expected O, but got I4
		//IL_0c3f: Expected F4, but got I4
		//IL_070e: Expected F4, but got I4
		//IL_0765: Expected F4, but got I4
		//IL_0a13: Expected F4, but got I4
		hideBackgroundMask = false;
		hideBackgroundParticles = false;
		GameManager core = GM.Core;
		PickupCustomMerchant pickupCustomMerchant = core._003CCurrentCustomMerchant_003Ek__BackingField;
		if ((object)core._003CCurrentCustomMerchant_003Ek__BackingField != null && ((UnityEngine.Object)pickupCustomMerchant).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			PickupCustomMerchant pickupCustomMerchant2 = core2._003CCurrentCustomMerchant_003Ek__BackingField;
			if (pickupCustomMerchant2._customMerchantData != null)
			{
				GameManager core3 = GM.Core;
				PickupCustomMerchant pickupCustomMerchant3 = core3._003CCurrentCustomMerchant_003Ek__BackingField;
				CustomMerchantData customMerchantData = pickupCustomMerchant3._customMerchantData;
				hideBackgroundMask = customMerchantData._003CHideBackgroundMask_003Ek__BackingField;
				GameManager core4 = GM.Core;
				PickupCustomMerchant pickupCustomMerchant4 = core4._003CCurrentCustomMerchant_003Ek__BackingField;
				CustomMerchantData customMerchantData2 = pickupCustomMerchant4._customMerchantData;
				hideBackgroundParticles = customMerchantData2._003CHideBackgroundParticles_003Ek__BackingField;
				GameManager core5 = GM.Core;
				PickupCustomMerchant pickupCustomMerchant5 = core5._003CCurrentCustomMerchant_003Ek__BackingField;
				CustomMerchantData customMerchantData3 = pickupCustomMerchant5._customMerchantData;
				hideBackgroundWindows = customMerchantData3._003CHideBackgroundWindows_003Ek__BackingField;
				if (~(customMerchantData2._003CHideBackgroundParticles_003Ek__BackingField ? 1u : 0u) == 0)
				{
					ParticleSystem pfx = _pfx1;
					if ((object)_pfx1 != null && ((UnityEngine.Object)pfx).m_CachedPtr != (IntPtr)0)
					{
						_pfx1.Stop();
						_pfx1.Clear(withChildren: true);
					}
					ParticleSystem pfx2 = _pfx2;
					if ((object)_pfx2 != null && ((UnityEngine.Object)pfx2).m_CachedPtr != (IntPtr)0)
					{
						_pfx2.Stop();
						_pfx2.Clear(withChildren: true);
					}
				}
			}
		}
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			GameManager core6 = GM.Core;
			PickupCustomMerchant pickupCustomMerchant6 = core6._003CCurrentCustomMerchant_003Ek__BackingField;
			if ((object)core6._003CCurrentCustomMerchant_003Ek__BackingField != null && ((UnityEngine.Object)pickupCustomMerchant6).m_CachedPtr != (IntPtr)0)
			{
				List<string> particleFrames = _ParticleFrames;
				int version = particleFrames._version + 1;
				particleFrames._version = version;
				particleFrames._size = 0;
				if (particleFrames._size > 0)
				{
					Array.Clear(particleFrames._items, 0, particleFrames._size);
				}
				_ParticleFrames.Add("colours9");
				_ParticleFrames.Add("colours10");
				goto IL_0519;
			}
		}
		List<string> particleFrames2 = _ParticleFrames;
		int version2 = particleFrames2._version + 1;
		particleFrames2._version = version2;
		particleFrames2._size = 0;
		if (particleFrames2._size > 0)
		{
			Array.Clear(particleFrames2._items, 0, particleFrames2._size);
		}
		List<object> particleFrames3 = (List<object>)(object)_ParticleFrames;
		int version3 = particleFrames3._version + 1;
		particleFrames3._version = version3;
		object[] items = particleFrames3._items;
		if (particleFrames3._size >= items.Length)
		{
			particleFrames3.AddWithResize((object)"colours3");
		}
		else
		{
			int size = particleFrames3._size + 1;
			particleFrames3._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> particleFrames4 = (List<object>)(object)_ParticleFrames;
		int version4 = particleFrames4._version + 1;
		particleFrames4._version = version4;
		object[] items2 = particleFrames4._items;
		if (particleFrames4._size >= items2.Length)
		{
			particleFrames4.AddWithResize((object)"colours4");
		}
		else
		{
			int size2 = particleFrames4._size + 1;
			particleFrames4._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		goto IL_0519;
		IL_0519:
		((BaseUIPage)this).OnShowStart(g);
		if (!_particlesCreated && !hideBackgroundParticles)
		{
			base.CreateParticles();
		}
		ClearWindows();
		if (!hideBackgroundWindows)
		{
			base.CreateWindows();
		}
		if (!hideBackgroundParticles)
		{
			_pfx1.Play(withChildren: true);
			_pfx2.Play(withChildren: true);
		}
		EnterMultiplayerControl(_currentCharacter);
		Populate();
		DisableWeaponPanels();
		IntroAnimation();
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		string term;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			bool flag = (nint)obj != -1;
			term = "lang/shop_header2";
			if (flag)
			{
				goto IL_0653;
			}
		}
		term = "lang/shop_header1";
		goto IL_0653;
		IL_09fc:
		Selectable up;
		Selectable down;
		HelpButton.SetNavigation(null, null, up, down);
		bool flag2 = default(bool);
		float time = (flag2 ? 1 : 0);
		goto IL_0a18;
		IL_0a18:
		GameObject gameObject = _BackButton.gameObject;
		bool active = IsLocalPlayerControllingUi();
		gameObject.SetActive(active);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = -200f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = -1500f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig2, 0f, 10, time);
		return;
		IL_0653:
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, flag2, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_Title.text = translation;
		bool flag3 = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
		time = (flag2 ? 1 : 0);
		if (!flag3)
		{
			GameManager core7 = GM.Core;
			PickupCustomMerchant pickupCustomMerchant7 = core7._003CCurrentCustomMerchant_003Ek__BackingField;
			bool flag4 = (object)core7._003CCurrentCustomMerchant_003Ek__BackingField == null;
			time = (flag2 ? 1 : 0);
			if (!flag4)
			{
				bool flag5 = ((UnityEngine.Object)pickupCustomMerchant7).m_CachedPtr == (IntPtr)0;
				time = (flag2 ? 1 : 0);
				if (!flag5)
				{
					GameManager core8 = GM.Core;
					PickupCustomMerchant pickupCustomMerchant8 = core8._003CCurrentCustomMerchant_003Ek__BackingField;
					CustomMerchantData customMerchantData4 = pickupCustomMerchant8._customMerchantData;
					bool flag6 = pickupCustomMerchant8._customMerchantData == null;
					time = (flag2 ? 1 : 0);
					if (!flag6)
					{
						string text = customMerchantData4._003CTextLocKey_003Ek__BackingField;
						if (customMerchantData4._003CTextLocKey_003Ek__BackingField != null && text._stringLength > 0)
						{
							string term2 = "adventureLang/" + customMerchantData4._003CTextLocKey_003Ek__BackingField;
							string translation2 = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, flag2, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003420");
						}
						PlayerOptionsData config2 = _playerOptions.Config;
						if (!config2._003CHasSeenMerchantTutorial_003Ek__BackingField)
						{
							GameManager core9 = GM.Core;
							if (!core9._multiplayer.IsOnlineMultiplayer)
							{
								TutorialPopup spawnedTutorialPopup = PopupManager.CreateTutorialPopup("Adventure-Merchant-Tutorial", "adventureLang/adv_adventureMerchantsPopup_title", "adventureLang/adv_adventureMerchantsPopup", "lang/postGame_done");
								_spawnedTutorialPopup = spawnedTutorialPopup;
								TutorialPopup.OnOkButtonClicked value = OnMerchantTutorialClosed;
								_spawnedTutorialPopup.OKButtonClicked += value;
							}
						}
						Action cb = EditorShowTutorial;
						HelpButton.AddCallback(cb);
						if (_spawned != null)
						{
							IEnumerable<object> spawned = _spawned;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2015 @ rax_v68 (System.Collections.Generic.IEnumerable`1<System.Object>)+18]");
							if ((nint)0 > (nint)0)
							{
								object obj2 = Enumerable.Last(spawned);
								Selectable component = ((GameObject)obj2).GetComponent<Selectable>();
								GameObject gameObject2 = Enumerable.First(_spawned);
								Selectable component2 = gameObject2.GetComponent<Selectable>();
								up = component;
								down = component2;
								goto IL_09fc;
							}
						}
						GameObject gameObject3 = _BackButton.gameObject;
						Selectable component3 = gameObject3.GetComponent<Selectable>();
						Selectable component4 = HelpButton.Instance.GetComponent<Selectable>();
						SetNavigationUp(component3, component4);
						up = component3;
						down = component3;
						goto IL_09fc;
					}
				}
			}
		}
		goto IL_0a18;
	}

	protected unsafe override void OnHideFinish(GameObject g)
	{
		//IL_01f2: Expected O, but got Ref
		//IL_020e: Expected O, but got Ref
		//IL_00ec: Expected O, but got I4
		//IL_0396: Expected I, but got O
		//IL_0099: Expected O, but got I
		//IL_00a2: Expected O, but got I4
		//IL_0121: Expected O, but got I
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0157: Expected I, but got O
		//IL_0167: Expected O, but got I
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_019f: Expected O, but got I
		//IL_0292->IL0317: Incompatible stack heights: 1 vs 0
		//IL_01ea->IL0400: Incompatible stack heights: 5 vs 0
		//IL_0301->IL0317: Incompatible stack heights: 1 vs 0
		if ((object)_content != null)
		{
			IEnumerator enumerator = _content.GetEnumerator();
			object obj = default(object);
			object obj2 = default(object);
			object obj13 = default(object);
			object obj14 = default(object);
			while (true)
			{
				bool flag = obj == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj2 == null)
				{
					break;
				}
				bool flag2 = obj == null;
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r10_v9+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_00d9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r10_v9+B0]");
				object obj4 = 0;
				object obj5 = 0;
				while (true)
				{
					object obj6 = obj5 + obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v12+v547 @ rax_v79*8]");
					if (0 == (nint)typeof(IEnumerator))
					{
						break;
					}
					obj5++;
					object obj7 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r10_v9+12E]");
					if ((nint)obj7 < 0)
					{
						continue;
					}
					goto IL_00d9;
				}
				object obj8 = obj5 + obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v12+8+v620 @ rcx_v60*8]");
				object obj9 = (nint)0 + (nint)1;
				object obj10 = obj9 << 4;
				object obj11 = obj10 + 312;
				object obj12 = obj11 + obj3;
				goto IL_037e;
				IL_00d9:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj4 = 1;
				obj12 = obj13;
				goto IL_037e;
				IL_037e:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v627 @ rdx_v22] (should have been resolved before IL gen)");
				nint num = (nint)typeof(Transform);
				if (obj14 != null)
				{
					nint num2 = (nint)obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v24 (Il2CppClass<UnityEngine.Transform>)+130]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r8_v13 (Il2CppClass<System.Object>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v24 (Il2CppClass<UnityEngine.Transform>)+130]");
					bool flag3 = num3 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r8_v13 (Il2CppClass<System.Object>)+C8]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v59+FFFFFFF8+v429 @ rax_v58*8]");
					bool flag4 = 0 != (nint)typeof(Transform);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v57 (System.Object)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v57 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
					GameObject obj17 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj17, 0f);
					continue;
				}
				throw new NullReferenceException();
			}
			object obj18 = (object)(&obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			object obj19 = (object)(&obj);
			object obj20 = default(object);
			obj19 = obj20;
			if (obj20 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			((BaseUIPage)this).OnHideFinish(g);
			ParticleSystem pfx = _pfx1;
			if ((object)_pfx1 != null && ((UnityEngine.Object)pfx).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_pfx1 == null)
				{
					goto IL_0317;
				}
				_pfx1.Stop();
			}
			ParticleSystem pfx2 = _pfx2;
			if ((object)_pfx2 == null || ((UnityEngine.Object)pfx2).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if ((object)_pfx2 != null)
			{
				_pfx2.Stop();
				return;
			}
		}
		goto IL_0317;
		IL_0317:
		throw new NullReferenceException();
	}

	private void EditorShowTutorial()
	{
		TutorialPopup spawnedTutorialPopup = PopupManager.CreateTutorialPopup("Adventure-Merchant-Tutorial", "adventureLang/adv_adventureMerchantsPopup_title", "adventureLang/adv_adventureMerchantsPopup", "lang/postGame_done");
		_spawnedTutorialPopup = spawnedTutorialPopup;
		TutorialPopup.OnOkButtonClicked value = OnMerchantTutorialClosed;
		_spawnedTutorialPopup.OKButtonClicked += value;
	}

	private void OnMerchantTutorialClosed()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CHasSeenMerchantTutorial_003Ek__BackingField = true;
		_playerOptions.Save();
		TutorialPopup.OnOkButtonClicked value = OnMerchantTutorialClosed;
		_spawnedTutorialPopup.OKButtonClicked -= value;
	}

	protected override void Update()
	{
		//IL_02e8: Expected I, but got O
		TutorialPopup spawnedTutorialPopup = _spawnedTutorialPopup;
		if ((object)_spawnedTutorialPopup != null && ((UnityEngine.Object)spawnedTutorialPopup).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		base.Update();
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			nint num = (nint)typeof(OnlineStageManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rcx_v28 (Il2CppClass<VampireSurvivors.OnlineStageManager>)+B8]");
			nint num2 = 0;
			OnlineStageManager instance = OnlineStageManager._instance;
			if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				OnlineStageManager onlineStageManager = default(OnlineStageManager);
				if (!onlineStageManager.AreAllPlayersInsideGameplayUi(myPlayerInfo._003CUiPageId_003Ek__BackingField))
				{
					return;
				}
			}
		}
		if (Player.GetButtonDown(6))
		{
			OnCancelPressed();
		}
		if (Player.GetButtonDown(5))
		{
			_SpamPressTimer = 0f;
			_SpamPressFirst = true;
		}
		if (!Player.GetButton(5) || Player.GetButtonDown(5))
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
		object obj = default(object);
		float num3 = (_SpamPressTimer = (float)obj + _SpamPressTimer);
		if (_SpamPressFirst)
		{
			if (num3 > 0.5f)
			{
				goto IL_0276;
			}
			if (_SpamPressFirst)
			{
				return;
			}
		}
		if (num3 > 0.16f)
		{
			goto IL_0276;
		}
		return;
		IL_0276:
		Debug.Log("Spam press purchase");
		OnMerchantEnterPressed();
		_SpamPressTimer = 0f;
		_SpamPressFirst = false;
	}

	protected void OnMerchantEnterPressed()
	{
		TutorialPopup spawnedTutorialPopup = _spawnedTutorialPopup;
		if ((object)_spawnedTutorialPopup == null || ((UnityEngine.Object)spawnedTutorialPopup).m_CachedPtr == (IntPtr)0)
		{
			PurchaseSelected();
		}
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		return _currentCharacter;
	}

	protected override void OnCancelPressed()
	{
		//IL_00e5: Expected I8, but got O
		//IL_00fd: Expected I8, but got O
		//IL_0095: Expected O, but got I
		TutorialPopup spawnedTutorialPopup = _spawnedTutorialPopup;
		if ((object)_spawnedTutorialPopup == null || ((UnityEngine.Object)spawnedTutorialPopup).m_CachedPtr == (IntPtr)0)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0040");
				return;
			}
			long num = (long)OnlineStageManager._instance;
			Action<long> action = null;
			((OnlineStageManager)(object)action).CloseMerchant((long)OnlineStageManager._instance);
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v4 (System.Int64)+78]");
			bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	private void ProcessWeaponPurchase(WeaponType t, int price, ShopItemUI shopItemUI)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B720");
		if (_adventureManager != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			object obj = default(object);
			if (obj != null)
			{
				GameManager core = GM.Core;
				PickupCustomMerchant pickupCustomMerchant = core._003CCurrentCustomMerchant_003Ek__BackingField;
				if ((object)core._003CCurrentCustomMerchant_003Ek__BackingField != null && ((UnityEngine.Object)pickupCustomMerchant).m_CachedPtr != (IntPtr)0)
				{
					_playerOptions.UnlockWeapon(t);
					GameManager core2 = GM.Core;
					core2._levelUpFactory.RemoveFromExcluded(t);
				}
			}
		}
		GameManager core3 = GM.Core;
		PickupCustomMerchant pickupCustomMerchant2 = core3._003CCurrentCustomMerchant_003Ek__BackingField;
		if ((object)core3._003CCurrentCustomMerchant_003Ek__BackingField != null)
		{
			CustomMerchantData customMerchantData = pickupCustomMerchant2._customMerchantData;
			if (customMerchantData._003CMerchantCharacter_003Ek__BackingField == CharacterType.TP_LIBRARIAN)
			{
				_playerOptions.UnlockWeapon(t);
				PlayerOptionsData config = _playerOptions.Config;
				int num2 = default(int);
				int num = config._003CLibraryMerchantGoldSpent_003Ek__BackingField + num2;
				config._003CLibraryMerchantGoldSpent_003Ek__BackingField = num;
			}
		}
		ShopItemUI shopItemUI2 = default(ShopItemUI);
		shopItemUI2.SoldOut();
		DisableWeaponPanels();
	}

	private void ProcessItemPurchase(ItemType t, ShopItemUI item, RectTransform sender)
	{
		//IL_0209: Expected O, but got I4
		//IL_0233: Expected O, but got I8
		//IL_024d: Expected O, but got I8
		//IL_013c: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		if (t > ItemType.DUMMY_REVIVAL)
		{
			if (t == ItemType.DUMMY_GOLDENEGG_MAX)
			{
				item.SoldOut();
				GameManager core = GM.Core;
				float num = item._price / 10000f;
				core._eggManager.LightEgg(num);
				_003CBuyAllRoutine_003Ed__54 obj = null;
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				obj.count = num;
				obj.sender = sender;
				Coroutine maxEggsPurchasedRoutine = StartCoroutine(obj);
				_maxEggsPurchasedRoutine = maxEggsPurchasedRoutine;
				goto IL_0085;
			}
			if (t == ItemType.RELIC_EME_DISK)
			{
				PlayerOptionsData config = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				}
				PlayerOptionsData config3 = _playerOptions.Config;
				List<ItemType> list = config3._003CRunPickups_003Ek__BackingField;
				object obj3 = 100;
			}
			else
			{
				if (t != ItemType.RELIC_LEM_DISK)
				{
					goto IL_0085;
				}
				PlayerOptionsData config4 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					PlayerOptionsData config5 = _playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				}
				PlayerOptionsData config6 = _playerOptions.Config;
				List<ItemType> list = config6._003CRunPickups_003Ek__BackingField;
				object obj3 = 400;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
		}
		else
		{
			object obj5 = t - 26;
			if ((nint)obj5 > 8)
			{
				if (t == ItemType.DUMMY_ARC)
				{
					item.SoldOut();
					GM.Core.QueueOpenArcana(ArcanaUiType.MAIN);
					GameManager core2 = GM.Core;
					ArcanaManager arcanaManager = core2._arcanaManager;
					int num2 = arcanaManager._003CMaxArcanasPerRun_003Ek__BackingField + 1;
					arcanaManager._003CMaxArcanasPerRun_003Ek__BackingField = num2;
				}
				else if (t == ItemType.DUMMY_REVIVAL)
				{
					item.SoldOut();
					VampireSurvivors.Objects.Characters.CharacterController currentCharacter = _currentCharacter;
					PlayerModifierStats playerStats = currentCharacter._playerStats;
					EggDouble revivals = playerStats._003CRevivals_003Ek__BackingField + 1.0;
					playerStats.Revivals = revivals;
				}
				goto IL_0085;
			}
			object obj6 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rbx_v4+6D1F864+v70 @ rax_v4*4]");
			object obj7 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v111 @ rax_v14 (should have been resolved before IL gen)");
		}
		item.SoldOut();
		goto IL_0085;
		IL_0085:
		DisableWeaponPanels();
	}

	private void SetCurrentCharacter(UISignals.OpenMerchantSignal sig)
	{
		_currentCharacter = sig._003CCharacter_003Ek__BackingField;
	}

	private IEnumerator BuyAllRoutine(float count, RectTransform sender)
	{
		_003CBuyAllRoutine_003Ed__54 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.count = count;
		obj.sender = sender;
		return obj;
	}

	private static void MakeEggNoise(int sfxIndex, int delay)
	{
		//IL_0116: Expected O, but got I4
		//IL_0020: Expected F4, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0086: Expected F4, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_00ec: Expected F4, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)sfxIndex + 200f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, delay, 5, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		float detune2 = (float)sfxIndex + 400f;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = detune2;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Roast, soundConfig2, delay, 5, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		float detune3 = (float)sfxIndex + 600f;
		soundConfig3.Rate = 1f;
		soundConfig3.Detune = detune3;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Roast, soundConfig3, delay, 5, time);
	}

	private string RandomFrame()
	{
		//IL_0050: Expected O, but got I4
		List<string> itemSprites = _itemSprites;
		object obj = UnityEngine.Random.RandomRangeInt(0, itemSprites._size);
		bool flag = (nint)obj >= itemSprites._size;
		string[] items = itemSprites._items;
		return items[obj];
	}

	private unsafe void Populate()
	{
		//IL_01dd: Expected O, but got I
		//IL_02cc: Expected O, but got I
		//IL_07dc: Expected O, but got I
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Expected O, but got Unknown
		//IL_048f: Expected O, but got Ref
		_Grid.enabled = true;
		_GridFitter.enabled = true;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		_weapons = convertedWeapons;
		DataManager data = _data;
		_items = data._003CAllItems_003Ek__BackingField;
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _data.GetConvertedPowerUpData();
		_powerUps = convertedPowerUpData;
		ClearSpawned();
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			PickupCustomMerchant pickupCustomMerchant = core2._003CCurrentCustomMerchant_003Ek__BackingField;
			if ((object)core2._003CCurrentCustomMerchant_003Ek__BackingField == null || ((UnityEngine.Object)pickupCustomMerchant).m_CachedPtr == (IntPtr)0)
			{
				goto IL_013d;
			}
		}
		_shopFactory.GenerateShopInventory(_currentCharacter);
		goto IL_013d;
		IL_013d:
		ShopFactory shopFactory = _shopFactory;
		int num = 0;
		int num2 = 0;
		ShopFactory shopFactory2 = _shopFactory;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		object obj8 = default(object);
		int num9 = default(int);
		while (true)
		{
			List<ItemType> availableItems = shopFactory._availableItems;
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)num3 < (nint)0)
			{
				List<ItemType> availableItems2 = shopFactory2._availableItems;
				int num4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v123 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v123 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rcx_v89+20+v152 @ rsi_v14 (System.Int32)*4]");
				AddItem(ItemType.VOID, num);
				num++;
				shopFactory2 = _shopFactory;
				num2 = num;
				shopFactory = _shopFactory;
				continue;
			}
			ShopFactory shopFactory3 = _shopFactory;
			int num5 = 0;
			int num6 = 0;
			while (true)
			{
				List<WeaponType> availableWeapons = shopFactory3._availableWeapons;
				int num7 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)num7 < (nint)0)
				{
					ShopFactory shopFactory4 = _shopFactory;
					List<WeaponType> availableWeapons2 = shopFactory4._availableWeapons;
					int num8 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v106 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)num8 >= (nint)0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v106 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj2 = 0;
					GameManager core3 = GM.Core;
					PickupCustomMerchant pickupCustomMerchant2 = core3._003CCurrentCustomMerchant_003Ek__BackingField;
					bool useWeaponDataPrice;
					if ((object)core3._003CCurrentCustomMerchant_003Ek__BackingField != null)
					{
						bool flag = ((UnityEngine.Object)pickupCustomMerchant2).m_CachedPtr == (IntPtr)0;
						useWeaponDataPrice = !flag;
					}
					else
					{
						useWeaponDataPrice = false;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v77+20+v155 @ rsi_v16 (System.Int32)*4]");
					GameObject gameObject = AddWeapon(WeaponType.VOID, num5, useWeaponDataPrice);
					num5++;
					shopFactory3 = _shopFactory;
					bool flag2 = _shopFactory != null;
					num6 = num5;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				GameManager core4 = GM.Core;
				PickupCustomMerchant pickupCustomMerchant3 = core4._003CCurrentCustomMerchant_003Ek__BackingField;
				if ((object)core4._003CCurrentCustomMerchant_003Ek__BackingField != null && ((UnityEngine.Object)pickupCustomMerchant3).m_CachedPtr != (IntPtr)0)
				{
					GameManager core5 = GM.Core;
					PickupCustomMerchant pickupCustomMerchant4 = core5._003CCurrentCustomMerchant_003Ek__BackingField;
					List<CustomActionInventoryItem> customActionInventoryItems = pickupCustomMerchant4.CustomActionInventoryItems;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v47 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Items.CustomActionInventoryItem>)+18]");
					if ((nint)0 > (nint)0)
					{
						GameManager core6 = GM.Core;
						PickupCustomMerchant pickupCustomMerchant5 = core6._003CCurrentCustomMerchant_003Ek__BackingField;
						while (true)
						{
							if (obj3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ stack_-118_v15+1C]");
								if (obj4 == null)
								{
									object obj5 = obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ stack_-118_v15+18]");
									if ((nint)obj5 >= 0)
									{
										break;
									}
									object obj7 = obj6 + 1;
									ShopItemUI shopItemUI = UnityEngine.Object.Instantiate(_ShopItemPrefab, _ItemContainer);
									float adventureMerchantPriceMarkupMultiplier = GetAdventureMerchantPriceMarkupMultiplier();
									shopItemUI.SetCustomAction((CustomActionInventoryItem)(&obj8), this, adventureMerchantPriceMarkupMultiplier);
									GameObject gameObject2 = shopItemUI.gameObject;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
									bool flag3 = num9 <= -1;
									obj6 = obj7;
									if (!flag3)
									{
										Transform transform = shopItemUI.transform;
										transform.SetSiblingIndex(num9);
										obj6 = obj7;
									}
									continue;
								}
								break;
							}
							throw new NullReferenceException();
						}
						bool flag4 = obj3 == null;
						Transform transform2 = (Transform)0;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ stack_-118_v15+1C]");
							if (obj4 == null)
							{
								goto IL_0762;
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							transform2 = null;
						}
						throw new NullReferenceException();
					}
				}
				goto IL_0762;
				IL_05c6:
				Selectable component;
				component.Select();
				_scrollEnhancer.ForceScrollAlignment();
				RecenterGridGroup();
				return;
				IL_0762:
				if (_spawned != null)
				{
					List<GameObject> spawned = _spawned;
					if (spawned._size > 0)
					{
						if (spawned._size <= 0)
						{
							break;
						}
						GameObject[] items = spawned._items;
						component = items[0].GetComponent<Selectable>();
						goto IL_05c6;
					}
				}
				component = _BackButton.GetComponent<Selectable>();
				goto IL_05c6;
			}
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void RecenterGridGroup()
	{
		//IL_003a: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_012e: Invalid comparison between F4 and O
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_03ea->IL026b: Incompatible stack heights: 1 vs 0
		//IL_0378->IL026b: Incompatible stack heights: 2 vs 0
		if ((object)_content != null)
		{
			Transform[] componentsInChildren = _content.GetComponentsInChildren<Transform>();
			if (componentsInChildren != null)
			{
				object obj = 0;
				object obj2 = 0;
				object obj3 = 1;
				object obj4 = 1;
				object obj6 = default(object);
				Vector2 value = default(Vector2);
				while (true)
				{
					if ((nint)obj4 < componentsInChildren.Length)
					{
						if ((nint)obj3 < componentsInChildren.Length)
						{
							if ((object)componentsInChildren[obj3] == null)
							{
								break;
							}
							RectTransform component = componentsInChildren[obj3].GetComponent<RectTransform>();
							if ((nint)obj3 != 1)
							{
								if ((object)component == null)
								{
									break;
								}
								Vector2 anchoredPosition = component.anchoredPosition;
								object obj5 = obj6 - obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								object obj7 = obj5 & 0;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
								{
									GridLayoutGroup grid = _Grid;
									if ((object)_Grid == null)
									{
										break;
									}
									obj3++;
									obj7 = (object)grid.m_Spacing + obj2;
									obj2 = obj7 + (object)grid.m_CellSize;
									obj4 = obj3;
									continue;
								}
							}
							else
							{
								if ((object)component == null)
								{
									break;
								}
								Vector2 anchoredPosition2 = component.anchoredPosition;
								GridLayoutGroup grid2 = _Grid;
								if ((object)_Grid == null)
								{
									break;
								}
								obj2 += (object)grid2.m_CellSize;
								obj = obj6;
							}
							obj3++;
							obj4 = obj3;
							continue;
						}
						throw new IndexOutOfRangeException();
					}
					object scroll = _scroll;
					if ((object)_scroll == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v13 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v13 (System.Object)+10]");
					RectTransform.get_rect_Injected((IntPtr)0, out Rect _);
					object content = _content;
					if ((object)_content == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v14 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v14 (System.Object)+10]");
					RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref value);
					object content2 = _content;
					if ((object)_content == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v15 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v15 (System.Object)+10]");
					RectTransform.get_anchoredPosition_Injected((IntPtr)0, out Vector2 _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v15 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v15 (System.Object)+10]");
					RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public static List<WeaponType> GetValidAdventureWeaponsForMerchant(List<WeaponType> merchantInventory, PlayerOptions playerOptions)
	{
		//IL_0068: Expected O, but got I
		//IL_014e: Expected O, but got I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		List<WeaponType> result = new List<WeaponType>();
		object obj2 = default(object);
		object obj3 = default(object);
		object obj4 = default(object);
		object obj8 = default(object);
		while (true)
		{
			object obj = obj2;
			while (true)
			{
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_-28_v11+1C]");
					if (obj4 == null)
					{
						object obj5 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_-28_v11+18]");
						if ((nint)obj5 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_-28_v11+10]");
							object obj6 = 0;
							obj++;
							PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
							List<WeaponType> list = mainGameConfig._003CUnlockedWeapons_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r10_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							if ((nint)0 != 0)
							{
								break;
							}
							continue;
						}
					}
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_-28_v11+1C]");
						if (obj4 == null)
						{
							return result;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						object obj7 = 0;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			bool flag = (nint)obj8 == -1;
			obj2 = obj;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				obj2 = obj;
			}
		}
	}

	public static List<WeaponType> GetValidCustomMerchantWeapons(List<WeaponType> merchantInventory, PlayerOptions playerOptions)
	{
		//IL_020a: Expected O, but got I
		//IL_0072: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_011e: Expected I4, but got O
		List<WeaponType> result = new List<WeaponType>();
		if (merchantInventory != null)
		{
			object obj = null;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			object obj8 = default(object);
			object obj10 = default(object);
			object message = default(object);
			while (true)
			{
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+1C]");
					if (obj3 != null)
					{
						break;
					}
					object obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+18]");
					if ((nint)obj4 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+10]");
					object obj6 = 0;
					object obj7 = obj5 + 1;
					PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
					List<WeaponType> list = mainGameConfig._003CUnlockedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						if ((nint)obj8 != -1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
							obj5 = obj7;
							continue;
						}
					}
					object obj9 = (WeaponType)obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					Debug.LogWarning(message);
					obj5 = obj7;
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag = obj2 == null;
			obj = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+1C]");
				if (obj3 == null)
				{
					goto IL_01d3;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj = null;
			}
			throw new NullReferenceException();
		}
		goto IL_01d3;
		IL_01d3:
		return result;
	}

	public static List<ItemType> GetValidCustomMerchantItems(List<ItemType> merchantInventoryItems, PlayerOptions playerOptions)
	{
		//IL_01d4: Expected O, but got I
		//IL_0072: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_00e8: Expected I4, but got O
		List<ItemType> result = new List<ItemType>();
		if (merchantInventoryItems != null)
		{
			object obj = null;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			object obj8 = default(object);
			object obj10 = default(object);
			object message = default(object);
			while (true)
			{
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-38_v3+1C]");
					if (obj3 == null)
					{
						object obj4 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-38_v3+18]");
						if ((nint)obj4 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-38_v3+10]");
							object obj6 = 0;
							object obj7 = obj5 + 1;
							PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
							if (obj8 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
								obj5 = obj7;
								continue;
							}
							object obj9 = (ItemType)obj10;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
							Debug.LogWarning(message);
							obj5 = obj7;
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag = obj2 == null;
			obj = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-38_v3+1C]");
				if (obj3 == null)
				{
					goto IL_019d;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj = null;
			}
			throw new NullReferenceException();
		}
		goto IL_019d;
		IL_019d:
		return result;
	}

	private unsafe void ShowEggResult(RectTransform sender, string att, float val)
	{
		//IL_04c1: Expected O, but got I
		//IL_04e9: Expected I, but got O
		//IL_0511: Expected O, but got I
		//IL_003e: Expected I, but got I8
		//IL_007c: Expected I, but got I8
		//IL_0170: Invalid comparison between F4 and I4
		//IL_020c: Expected I, but got O
		//IL_0629: Expected O, but got I4
		//IL_049b: Expected O, but got Ref
		//IL_03ef->IL049c: Incompatible stack heights: 1 vs 0
		//IL_0646->IL049c: Incompatible stack heights: 1 vs 0
		//IL_0439->IL049c: Incompatible stack heights: 1 vs 0
		//IL_0489->IL049c: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass62_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass62_0();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass62_0);
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v66 @ rax_v20 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			num = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v111 @ rax_v23 (should have been resolved before IL gen)");
		if ((object)sender != null)
		{
			Transform parent = sender.transform;
			GameObject result = UnityEngine.Object.Instantiate(_EggResultPrefab, parent);
			if (CS_0024_003C_003E8__locals20 != null)
			{
				CS_0024_003C_003E8__locals20.result = result;
				string spriteName = LookUpFrame(att);
				if ((object)CS_0024_003C_003E8__locals20.result != null)
				{
					RectTransform componentInChildren = (RectTransform)(object)CS_0024_003C_003E8__locals20.result.GetComponentInChildren<Image>(includeInactive: false);
					Sprite sprite = SpriteManager.GetSprite(spriteName, "items");
					if ((object)componentInChildren != null)
					{
						((Image)(object)componentInChildren).sprite = sprite;
						bool flag2 = !(val > 0f);
						string text = "";
						if (!flag2)
						{
							text = "+";
						}
						if ((object)CS_0024_003C_003E8__locals20.result != null)
						{
							RectTransform componentInChildren2 = (RectTransform)(object)CS_0024_003C_003E8__locals20.result.GetComponentInChildren<TextMeshProUGUI>(includeInactive: false);
							NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
							string text2 = System.Number.FormatSingle(val, null, currentInfo);
							string text3 = text + text2;
							if ((object)componentInChildren2 != null)
							{
								nint num2 = (nint)componentInChildren2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v267 @ r9_v10 (Il2CppClass<UnityEngine.RectTransform>)+558] (should have been resolved before IL gen)");
								if ((object)CS_0024_003C_003E8__locals20.result != null)
								{
									RectTransform component = CS_0024_003C_003E8__locals20.result.GetComponent<RectTransform>();
									if ((object)component != null)
									{
										Vector2 anchoredPosition = default(Vector2);
										component.anchoredPosition = anchoredPosition;
										if ((object)CS_0024_003C_003E8__locals20.result != null)
										{
											CanvasGroup component2 = CS_0024_003C_003E8__locals20.result.GetComponent<CanvasGroup>();
											TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(component2, 0f, 2f);
											TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetLink(t, CS_0024_003C_003E8__locals20.result);
											if ((object)CS_0024_003C_003E8__locals20.result != null)
											{
												Transform target = CS_0024_003C_003E8__locals20.result.transform;
												if ((object)CS_0024_003C_003E8__locals20.result != null)
												{
													Transform transform = CS_0024_003C_003E8__locals20.result.transform;
													if ((object)transform != null)
													{
														bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
														Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
														object obj3 = default(object);
														float endValue = (float)obj3 + 60f;
														TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOLocalMoveY(target, endValue, 2f);
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetLink(t2, CS_0024_003C_003E8__locals20.result);
														TweenCallback tweenCallback = delegate
														{
															UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals20.result, 0f);
														};
														tweenCallback._002Ector(CS_0024_003C_003E8__locals20, (nint)__ldftn(_003C_003Ec__DisplayClass62_0._003CShowEggResult_003Eb__0));
														if (tweenerCore2 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1110 @ rax_v59 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 == 0)
															{
															}
														}
														string[] textColors = _textColors;
														if (_textColors != null)
														{
															RectTransform rectTransform = (RectTransform)UnityEngine.Random.RandomRangeInt(0, textColors.Length);
															if ((object)CS_0024_003C_003E8__locals20.result != null)
															{
																TextMeshProUGUI componentInChildren3 = CS_0024_003C_003E8__locals20.result.GetComponentInChildren<TextMeshProUGUI>(includeInactive: false);
																string[] textColors2 = _textColors;
																if (_textColors != null)
																{
																	bool flag4 = (nint)rectTransform >= textColors2.Length;
																	Color color = ColourHelper.HexToColor(textColors2[(object)rectTransform]);
																	if ((object)componentInChildren3 != null)
																	{
																		componentInChildren3.color = (Color)(&ret);
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
		throw new NullReferenceException();
	}

	private unsafe void ShowEggResultSprite(RectTransform sender)
	{
		//IL_0504: Expected O, but got I
		//IL_052c: Expected I, but got O
		//IL_0554: Expected O, but got I
		//IL_003e: Expected I, but got I8
		//IL_007c: Expected I, but got I8
		//IL_05e2: Expected O, but got I4
		//IL_018f: Expected O, but got I
		//IL_0242: Expected I, but got O
		//IL_06c4: Expected O, but got I4
		//IL_0109->IL04df: Incompatible stack heights: 1 vs 0
		//IL_014e->IL04df: Incompatible stack heights: 2 vs 0
		//IL_01ab->IL04df: Incompatible stack heights: 2 vs 0
		//IL_01da->IL04df: Incompatible stack heights: 2 vs 0
		//IL_0213->IL04df: Incompatible stack heights: 2 vs 0
		//IL_0622->IL04df: Incompatible stack heights: 2 vs 0
		//IL_02a1->IL04df: Incompatible stack heights: 2 vs 0
		//IL_02d1->IL04df: Incompatible stack heights: 2 vs 0
		//IL_0300->IL04df: Incompatible stack heights: 2 vs 0
		//IL_032f->IL04df: Incompatible stack heights: 2 vs 0
		//IL_0395->IL04df: Incompatible stack heights: 2 vs 0
		//IL_03c9->IL04df: Incompatible stack heights: 2 vs 0
		//IL_03f8->IL04df: Incompatible stack heights: 2 vs 0
		//IL_048d->IL04df: Incompatible stack heights: 3 vs 0
		//IL_06e1->IL04df: Incompatible stack heights: 3 vs 0
		//IL_04cb->IL04df: Incompatible stack heights: 3 vs 0
		_003C_003Ec__DisplayClass63_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass63_0();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass63_0);
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v60 @ rax_v25 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			num = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v105 @ rax_v28 (should have been resolved before IL gen)");
		if ((object)sender != null)
		{
			Transform parent = sender.transform;
			GameObject result = UnityEngine.Object.Instantiate(_EggResultPrefab, parent);
			if (CS_0024_003C_003E8__locals22 != null)
			{
				CS_0024_003C_003E8__locals22.result = result;
				RectTransform itemSprites = (RectTransform)(object)_itemSprites;
				if (_itemSprites != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdi_v12 (UnityEngine.RectTransform)+18]");
					Transform transform = (Transform)UnityEngine.Random.RandomRangeInt(0, 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdi_v12 (UnityEngine.RectTransform)+18]");
					bool flag2 = (nint)transform >= 0;
					IntPtr cachedPtr = ((UnityEngine.Object)itemSprites).m_CachedPtr;
					if (((UnityEngine.Object)itemSprites).m_CachedPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v33 (System.IntPtr)+18]");
						bool flag3 = (nint)transform >= 0;
						if ((object)CS_0024_003C_003E8__locals22.result != null)
						{
							RectTransform componentInChildren = (RectTransform)(object)CS_0024_003C_003E8__locals22.result.GetComponentInChildren<Image>(includeInactive: false);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v33 (System.IntPtr)+20+v300 @ rax_v39 (UnityEngine.Transform)*8]");
							Sprite sprite = SpriteManager.GetSprite((string)0, "items");
							if ((object)componentInChildren != null)
							{
								((Image)(object)componentInChildren).sprite = sprite;
								if ((object)CS_0024_003C_003E8__locals22.result != null)
								{
									Image componentInChildren2 = CS_0024_003C_003E8__locals22.result.GetComponentInChildren<Image>(includeInactive: false);
									if ((object)componentInChildren2 != null)
									{
										if (((MaskableGraphic)componentInChildren2).m_Maskable)
										{
											nint num2 = (nint)componentInChildren2;
											((MaskableGraphic)componentInChildren2).m_Maskable = false;
											((MaskableGraphic)componentInChildren2).m_ShouldRecalculateStencil = true;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1157 @ r8_v30 (Il2CppMethodInfo)+308] (should have been resolved before IL gen)");
										}
										if ((object)CS_0024_003C_003E8__locals22.result != null)
										{
											Behaviour componentInChildren3 = CS_0024_003C_003E8__locals22.result.GetComponentInChildren<TextMeshProUGUI>(includeInactive: false);
											if ((object)componentInChildren3 != null)
											{
												componentInChildren3.enabled = false;
												if ((object)CS_0024_003C_003E8__locals22.result != null)
												{
													RectTransform component = CS_0024_003C_003E8__locals22.result.GetComponent<RectTransform>();
													if ((object)component != null)
													{
														Vector2 anchoredPosition = default(Vector2);
														component.anchoredPosition = anchoredPosition;
														if ((object)CS_0024_003C_003E8__locals22.result != null)
														{
															CanvasGroup component2 = CS_0024_003C_003E8__locals22.result.GetComponent<CanvasGroup>();
															TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(component2, 0f, 2f);
															TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetLink(t, CS_0024_003C_003E8__locals22.result);
															if ((object)CS_0024_003C_003E8__locals22.result != null)
															{
																Transform target = CS_0024_003C_003E8__locals22.result.transform;
																if ((object)CS_0024_003C_003E8__locals22.result != null)
																{
																	Transform transform2 = CS_0024_003C_003E8__locals22.result.transform;
																	if ((object)transform2 != null)
																	{
																		bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																		Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
																		object obj3 = default(object);
																		float endValue = (float)obj3 + 60f;
																		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOLocalMoveY(target, endValue, 2f);
																		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetLink(t2, CS_0024_003C_003E8__locals22.result);
																		TweenCallback tweenCallback = delegate
																		{
																			UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals22.result, 0f);
																		};
																		tweenCallback._002Ector(CS_0024_003C_003E8__locals22, (nint)__ldftn(_003C_003Ec__DisplayClass63_0._003CShowEggResultSprite_003Eb__0));
																		if (tweenerCore2 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1237 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																			if ((nint)0 == 0)
																			{
																			}
																		}
																		string[] textColors = _textColors;
																		if (_textColors != null)
																		{
																			object obj4 = UnityEngine.Random.RandomRangeInt(0, textColors.Length);
																			if ((object)CS_0024_003C_003E8__locals22.result != null)
																			{
																				Behaviour componentInChildren4 = CS_0024_003C_003E8__locals22.result.GetComponentInChildren<TextMeshProUGUI>(includeInactive: false);
																				if ((object)componentInChildren4 != null)
																				{
																					componentInChildren4.enabled = false;
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
		throw new NullReferenceException();
	}

	private unsafe string LookUpFrame(string name)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004a: Expected O, but got I4
		//IL_0057: Expected O, but got I8
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_12d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12da: Expected Ref, but got Unknown
		//IL_12f1: Expected I8, but got I4
		//IL_12fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1300: Expected Ref, but got Unknown
		//IL_13cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d2: Expected Ref, but got Unknown
		//IL_13e9: Expected I8, but got I4
		//IL_13f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f8: Expected Ref, but got Unknown
		//IL_10e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ea: Expected Ref, but got Unknown
		//IL_1101: Expected I8, but got I4
		//IL_110b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1110: Expected Ref, but got Unknown
		//IL_0ed5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eda: Expected Ref, but got Unknown
		//IL_0ef1: Expected I8, but got I4
		//IL_0efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f00: Expected Ref, but got Unknown
		//IL_09bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c2: Expected Ref, but got Unknown
		//IL_09d9: Expected I8, but got I4
		//IL_09e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Expected Ref, but got Unknown
		//IL_11dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e2: Expected Ref, but got Unknown
		//IL_11f9: Expected I8, but got I4
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_1208: Expected Ref, but got Unknown
		//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd2: Expected Ref, but got Unknown
		//IL_0fe9: Expected I8, but got I4
		//IL_0ff3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff8: Expected Ref, but got Unknown
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf2: Expected Ref, but got Unknown
		//IL_0c09: Expected I8, but got I4
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c18: Expected Ref, but got Unknown
		//IL_0ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aba: Expected Ref, but got Unknown
		//IL_0ad1: Expected I8, but got I4
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Expected Ref, but got Unknown
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Expected Ref, but got Unknown
		//IL_06e9: Expected I8, but got I4
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected Ref, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected Ref, but got Unknown
		//IL_04d1: Expected I8, but got I4
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected Ref, but got Unknown
		//IL_0ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cea: Expected Ref, but got Unknown
		//IL_0d01: Expected I8, but got I4
		//IL_0d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d10: Expected Ref, but got Unknown
		//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Expected Ref, but got Unknown
		//IL_07e5: Expected I8, but got I4
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Expected Ref, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Expected Ref, but got Unknown
		//IL_05cd: Expected I8, but got I4
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected Ref, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected Ref, but got Unknown
		//IL_01dd: Expected I8, but got I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected Ref, but got Unknown
		//IL_0ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de2: Expected Ref, but got Unknown
		//IL_0df9: Expected I8, but got I4
		//IL_0e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e08: Expected Ref, but got Unknown
		//IL_08c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected Ref, but got Unknown
		//IL_08e1: Expected I8, but got I4
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Expected Ref, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected Ref, but got Unknown
		//IL_02d9: Expected I8, but got I4
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected Ref, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected Ref, but got Unknown
		//IL_03d5: Expected I8, but got I4
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3322]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (name != null)
		{
			object obj = name + 20;
			object obj2 = 0;
			object obj3 = 2166136261L;
			string result = default(string);
			while ((nint)obj2 < name._stringLength)
			{
				if ((nint)obj2 < name._stringLength)
				{
					obj2++;
					object obj4 = obj ^ obj3;
					obj3 = obj4 * 16777619;
					obj += 2;
					continue;
				}
				System.ThrowHelper.ThrowIndexOutOfRangeException();
				return result;
			}
			if ((nint)obj3 > 1478134073)
			{
				if ((long)obj3 > 2601460036L)
				{
					if ((long)obj3 > 4115604294L)
					{
						if ((long)obj3 == 4145017712L)
						{
							object obj5 = "luck";
							if ((object)name == "luck")
							{
								goto IL_021a;
							}
							if ("luck" != null)
							{
								int stringLength = name._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v58+10]");
								if ((nint)stringLength == 0)
								{
									ref byte first = ref *(byte*)(name + 20);
									ulong length = (ulong)(name._stringLength + name._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("luck" + 20), length))
									{
										goto IL_021a;
									}
								}
							}
						}
						else if ((long)obj3 == 4152741449L)
						{
							object obj6 = "amount";
							if ((object)name == "amount")
							{
								goto IL_0316;
							}
							if ("amount" != null)
							{
								int stringLength2 = name._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v55+10]");
								if ((nint)stringLength2 == 0)
								{
									ref byte first2 = ref *(byte*)(name + 20);
									ulong length2 = (ulong)(name._stringLength + name._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("amount" + 20), length2))
									{
										goto IL_0316;
									}
								}
							}
						}
						else if ((long)obj3 == 4165567700L)
						{
							object obj7 = "armor";
							if ((object)name == "armor")
							{
								goto IL_0412;
							}
							if ("armor" != null)
							{
								int stringLength3 = name._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v52+10]");
								if ((nint)stringLength3 == 0)
								{
									ref byte first3 = ref *(byte*)(name + 20);
									ulong length3 = (ulong)(name._stringLength + name._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("armor" + 20), length3))
									{
										goto IL_0412;
									}
								}
							}
						}
					}
					else if ((long)obj3 == 2905847715L)
					{
						object obj8 = "skips";
						if ((object)name == "skips")
						{
							goto IL_050e;
						}
						if ("skips" != null)
						{
							int stringLength4 = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v49+10]");
							if ((nint)stringLength4 == 0)
							{
								ref byte first4 = ref *(byte*)(name + 20);
								ulong length4 = (ulong)(name._stringLength + name._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("skips" + 20), length4))
								{
									goto IL_050e;
								}
							}
						}
					}
					else if ((long)obj3 == 4115604294L)
					{
						object obj9 = "power";
						if ((object)name == "power")
						{
							goto IL_060a;
						}
						if ("power" != null)
						{
							int stringLength5 = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v46+10]");
							if ((nint)stringLength5 == 0)
							{
								ref byte first5 = ref *(byte*)(name + 20);
								ulong length5 = (ulong)(name._stringLength + name._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("power" + 20), length5))
								{
									goto IL_060a;
								}
							}
						}
					}
				}
				else if ((nint)obj3 > 2072037248)
				{
					if ((long)obj3 == 2245568488L)
					{
						object obj10 = "cooldown";
						if ((object)name == "cooldown")
						{
							goto IL_0726;
						}
						if ("cooldown" != null)
						{
							int stringLength6 = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v43+10]");
							if ((nint)stringLength6 == 0)
							{
								ref byte first6 = ref *(byte*)(name + 20);
								ulong length6 = (ulong)(name._stringLength + name._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("cooldown" + 20), length6))
								{
									goto IL_0726;
								}
							}
						}
					}
					else if ((long)obj3 == 2369798645L)
					{
						object obj11 = "curse";
						if ((object)name == "curse")
						{
							goto IL_0822;
						}
						if ("curse" != null)
						{
							int stringLength7 = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v40+10]");
							if ((nint)stringLength7 == 0)
							{
								ref byte first7 = ref *(byte*)(name + 20);
								ulong length7 = (ulong)(name._stringLength + name._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("curse" + 20), length7))
								{
									goto IL_0822;
								}
							}
						}
					}
					else if ((long)obj3 == 2601460036L)
					{
						object obj12 = "area";
						if ((object)name == "area")
						{
							goto IL_091e;
						}
						if ("area" != null)
						{
							int stringLength8 = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v37+10]");
							if ((nint)stringLength8 == 0)
							{
								ref byte first8 = ref *(byte*)(name + 20);
								ulong length8 = (ulong)(name._stringLength + name._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first8, ref *(byte*)("area" + 20), length8))
								{
									goto IL_091e;
								}
							}
						}
					}
				}
				else if ((nint)obj3 == 1772300454)
				{
					object obj13 = "growth";
					if ((object)name == "growth")
					{
						goto IL_0a16;
					}
					if ("growth" != null)
					{
						int stringLength9 = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v34+10]");
						if ((nint)stringLength9 == 0)
						{
							ref byte first9 = ref *(byte*)(name + 20);
							ulong length9 = (ulong)(name._stringLength + name._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first9, ref *(byte*)("growth" + 20), length9))
							{
								goto IL_0a16;
							}
						}
					}
				}
				else if ((nint)obj3 == 2072037248)
				{
					object obj14 = "speed";
					if ((object)name == "speed")
					{
						goto IL_0b0e;
					}
					if ("speed" != null)
					{
						int stringLength10 = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v31+10]");
						if ((nint)stringLength10 == 0)
						{
							ref byte first10 = ref *(byte*)(name + 20);
							ulong length10 = (ulong)(name._stringLength + name._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first10, ref *(byte*)("speed" + 20), length10))
							{
								goto IL_0b0e;
							}
						}
					}
				}
			}
			else if ((nint)obj3 > 382147848)
			{
				if ((nint)obj3 > 799079693)
				{
					if ((nint)obj3 == 1157950271)
					{
						object obj15 = "moveSpeed";
						if ((object)name == "moveSpeed")
						{
							goto IL_0c46;
						}
						if ("moveSpeed" != null)
						{
							int stringLength11 = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v28+10]");
							if ((nint)stringLength11 == 0)
							{
								ref byte first11 = ref *(byte*)(name + 20);
								ulong length11 = (ulong)(name._stringLength + name._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first11, ref *(byte*)("moveSpeed" + 20), length11))
								{
									goto IL_0c46;
								}
							}
						}
					}
					else if ((nint)obj3 == 1321633417)
					{
						object obj16 = "maxHp";
						if ((object)name == "maxHp")
						{
							goto IL_0d3e;
						}
						if ("maxHp" != null)
						{
							int stringLength12 = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v25+10]");
							if ((nint)stringLength12 == 0)
							{
								ref byte first12 = ref *(byte*)(name + 20);
								ulong length12 = (ulong)(name._stringLength + name._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first12, ref *(byte*)("maxHp" + 20), length12))
								{
									goto IL_0d3e;
								}
							}
						}
					}
					else if ((nint)obj3 == 1478134073)
					{
						object obj17 = "revivals";
						if ((object)name == "revivals")
						{
							goto IL_0e36;
						}
						if ("revivals" != null)
						{
							int stringLength13 = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v22+10]");
							if ((nint)stringLength13 == 0)
							{
								ref byte first13 = ref *(byte*)(name + 20);
								ulong length13 = (ulong)(name._stringLength + name._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first13, ref *(byte*)("revivals" + 20), length13))
								{
									goto IL_0e36;
								}
							}
						}
					}
				}
				else if ((nint)obj3 == 730421894)
				{
					object obj18 = "banish";
					if ((object)name == "banish")
					{
						goto IL_0f2e;
					}
					if ("banish" != null)
					{
						int stringLength14 = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v19+10]");
						if ((nint)stringLength14 == 0)
						{
							ref byte first14 = ref *(byte*)(name + 20);
							ulong length14 = (ulong)(name._stringLength + name._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first14, ref *(byte*)("banish" + 20), length14))
							{
								goto IL_0f2e;
							}
						}
					}
				}
				else if ((nint)obj3 == 799079693)
				{
					object obj19 = "duration";
					if ((object)name == "duration")
					{
						goto IL_1026;
					}
					if ("duration" != null)
					{
						int stringLength15 = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v16+10]");
						if ((nint)stringLength15 == 0)
						{
							ref byte first15 = ref *(byte*)(name + 20);
							ulong length15 = (ulong)(name._stringLength + name._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first15, ref *(byte*)("duration" + 20), length15))
							{
								goto IL_1026;
							}
						}
					}
				}
			}
			else if ((nint)obj3 > 16724762)
			{
				if ((nint)obj3 == 186514554)
				{
					object obj20 = "greed";
					if ((object)name == "greed")
					{
						goto IL_113e;
					}
					if ("greed" != null)
					{
						int stringLength16 = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v13+10]");
						if ((nint)stringLength16 == 0)
						{
							ref byte first16 = ref *(byte*)(name + 20);
							ulong length16 = (ulong)(name._stringLength + name._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first16, ref *(byte*)("greed" + 20), length16))
							{
								goto IL_113e;
							}
						}
					}
				}
				else if ((nint)obj3 == 382147848)
				{
					object obj21 = "rerolls";
					if ((object)name == "rerolls")
					{
						goto IL_1236;
					}
					if ("rerolls" != null)
					{
						int stringLength17 = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v10+10]");
						if ((nint)stringLength17 == 0)
						{
							ref byte first17 = ref *(byte*)(name + 20);
							ulong length17 = (ulong)(name._stringLength + name._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first17, ref *(byte*)("rerolls" + 20), length17))
							{
								goto IL_1236;
							}
						}
					}
				}
			}
			else if ((nint)obj3 == 3835839)
			{
				object obj22 = "magnet";
				if ((object)name == "magnet")
				{
					goto IL_132e;
				}
				if ("magnet" != null)
				{
					int stringLength18 = name._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v7+10]");
					if ((nint)stringLength18 == 0)
					{
						ref byte first18 = ref *(byte*)(name + 20);
						ulong length18 = (ulong)(name._stringLength + name._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first18, ref *(byte*)("magnet" + 20), length18))
						{
							goto IL_132e;
						}
					}
				}
			}
			else if ((nint)obj3 == 16724762)
			{
				object obj23 = "regen";
				if ((object)name == "regen")
				{
					goto IL_1426;
				}
				if ("regen" != null)
				{
					int stringLength19 = name._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v4+10]");
					if ((nint)stringLength19 == 0)
					{
						ref byte first19 = ref *(byte*)(name + 20);
						ulong length19 = (ulong)(name._stringLength + name._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first19, ref *(byte*)("regen" + 20), length19))
						{
							goto IL_1426;
						}
					}
				}
			}
		}
		return "";
		IL_113e:
		return "Mask.png";
		IL_050e:
		return "Skip.png";
		IL_0412:
		return "ArmorIron.png";
		IL_060a:
		return "Leaf.png";
		IL_1026:
		return "EmblemEye.png";
		IL_1236:
		return "Dice.png";
		IL_0b0e:
		return "Gauntlet.png";
		IL_0f2e:
		return "Banish.png";
		IL_0822:
		return "Curse.png";
		IL_0c46:
		return "Wing.png";
		IL_0726:
		return "Book2.png";
		IL_091e:
		return "Candelabra.png";
		IL_021a:
		return "Clover.png";
		IL_1426:
		return "HeartRuby.png";
		IL_0d3e:
		return "HeartBlack.png";
		IL_0316:
		return "Ring.png";
		IL_0a16:
		return "Crown.png";
		IL_0e36:
		return "Tiramisu.png";
		IL_132e:
		return "OrbGlow.png";
	}

	private unsafe bool DoesPlayerAlreadyHaveWeapon(WeaponType t)
	{
		//IL_007a: Expected O, but got I4
		//IL_0082: Expected O, but got Ref
		_003C_003Ec__DisplayClass65_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass65_0();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.t = t;
			List<Equipment> source = new List<Equipment>();
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._mainCharacters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<object> list = (List<object>)(&enumerator);
					throw new NullReferenceException();
				}
				Func<Equipment, bool> predicate = delegate(Equipment x)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj2 = x._equipmentType - CS_0024_003C_003E8__locals3.t;
					return obj2 == null;
				};
				return Enumerable.Any(source, predicate);
			}
		}
		throw new NullReferenceException();
	}

	private GameObject AddWeapon(WeaponType t, int index, bool useWeaponDataPrice = false)
	{
		//IL_00b8: Expected O, but got I
		//IL_0150: Expected F4, but got O
		//IL_0150: Expected O, but got I
		GameObject gameObject;
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_weapons).FindEntry((System.Int32Enum)t);
			if (num < 0)
			{
				gameObject = null;
				goto IL_0236;
			}
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_weapons).get_Item((System.Int32Enum)t);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v14 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v14 (System.Object)+10]");
			object obj2 = 0;
			GameObject original = _ShopItemPrefab.gameObject;
			gameObject = UnityEngine.Object.Instantiate(original, _ItemContainer);
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)_items).get_Item((System.Int32Enum)13);
			ShopItemUI component = gameObject.GetComponent<ShopItemUI>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v15+20]");
			nint num2 = 0;
			PlayerOptions playerOptions = _playerOptions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v19 (System.Object)+4C]");
			PlayerOptions po = default(PlayerOptions);
			float price = default(float);
			int index2 = default(int);
			int quantity = default(int);
			component.SetWeaponData((WeaponData)num2, t, this, po, price, index2, quantity, (float)playerOptions, useWeaponDataPrice: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			object obj4 = default(object);
			WeaponType weaponType;
			if (obj4 == null)
			{
				GameManager core = GM.Core;
				bool flag = core._003CMerchantInventory_003Ek__BackingField != MerchantInventoryType.CUSTOM;
				weaponType = t;
				if (flag)
				{
					goto IL_0213;
				}
			}
			bool flag2 = DoesPlayerAlreadyHaveWeapon(t);
			bool flag3 = !flag2;
			weaponType = WeaponType.VOID;
			if (!flag3)
			{
				ShopItemUI component2 = gameObject.GetComponent<ShopItemUI>();
				component2.SoldOut();
				weaponType = WeaponType.VOID;
			}
			goto IL_0213;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
		IL_0213:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
		goto IL_0236;
		IL_0236:
		return gameObject;
	}

	private unsafe void AddItem(ItemType t, int index)
	{
		//IL_0265: Expected I4, but got O
		//IL_028a: Expected O, but got Ref
		ItemType itemType = default(ItemType);
		GameObject gameObject;
		if (((Dictionary<System.Int32Enum, object>)(object)_items).TryGetValue((System.Int32Enum)itemType, out object value))
		{
			GameObject original = _ShopItemPrefab.gameObject;
			gameObject = UnityEngine.Object.Instantiate(original, _ItemContainer);
			ShopItemUI component = gameObject.GetComponent<ShopItemUI>();
			float adventureMerchantPriceMarkupMultiplier = GetAdventureMerchantPriceMarkupMultiplier();
			float price = default(float);
			int index2 = default(int);
			int quantity = default(int);
			float priceMarkupMultiplier = default(float);
			component.SetItemData((ItemData)value, itemType, this, price, index2, quantity, priceMarkupMultiplier);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj = default(object);
			if (obj != null)
			{
				int playerCount = Multiplayer.GetPlayerCount();
				if (playerCount <= 1 && !Multiplayer.IsOnlineMultiplayer)
				{
					GameManager core = GM.Core;
					if (!core._multiplayer.IsOnlineMultiplayer)
					{
						goto IL_0172;
					}
				}
				ShopItemUI component2 = gameObject.GetComponent<ShopItemUI>();
				component2.SoldOut();
			}
			goto IL_0172;
		}
		object obj2 = default(object);
		object arg = (ItemType)obj2;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj3 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Couldn't find item with type {0} in items dictionary, is the relevant DLC installed?", (System.ParamsArray)(&obj3));
		Debug.LogWarning(message);
		return;
		IL_0172:
		PlayerOptionsData mainGameConfig;
		ItemType itemType2;
		if (itemType == ItemType.RELIC_EME_DISK)
		{
			GameManager core2 = GM.Core;
			PlayerOptions playerOptions = core2._playerOptions;
			mainGameConfig = playerOptions._mainGameConfig;
		}
		else
		{
			bool flag = itemType != ItemType.RELIC_LEM_DISK;
			itemType2 = itemType;
			if (flag)
			{
				goto IL_024c;
			}
			GameManager core3 = GM.Core;
			PlayerOptions playerOptions2 = core3._playerOptions;
			mainGameConfig = playerOptions2._mainGameConfig;
		}
		bool flag2 = mainGameConfig.HasCollectedItem(itemType);
		bool flag3 = !flag2;
		itemType2 = ItemType.VOID;
		if (!flag3)
		{
			ShopItemUI component3 = gameObject.GetComponent<ShopItemUI>();
			component3.SoldOut();
			itemType2 = ItemType.VOID;
		}
		goto IL_024c;
		IL_024c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private unsafe ShopItemUI AddCustomActionShopItem(CustomActionInventoryItem inventoryItem)
	{
		//IL_0058: Expected O, but got Ref
		ShopItemUI shopItemUI = UnityEngine.Object.Instantiate(_ShopItemPrefab, _ItemContainer);
		float adventureMerchantPriceMarkupMultiplier = GetAdventureMerchantPriceMarkupMultiplier();
		if ((object)shopItemUI != null)
		{
			object obj = default(object);
			shopItemUI.SetCustomAction((CustomActionInventoryItem)(&obj), this, adventureMerchantPriceMarkupMultiplier);
			GameObject gameObject = shopItemUI.gameObject;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
				return shopItemUI;
			}
		}
		return (ShopItemUI)(object)new NullReferenceException();
	}

	private unsafe float GetAdventureMerchantPriceMarkupMultiplier()
	{
		bool flag = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
		float result = 1f;
		if (!flag)
		{
			DataManager data = _data;
			GameManager core = GM.Core;
			Stage stage = core._stage;
			bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)data._adventureStageData).TryGetValue((System.Int32Enum)stage._stageType, out object value);
			bool flag3 = !flag2;
			result = 1f;
			if (!flag3)
			{
				bool flag4 = value == null;
				result = 1f;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_18_v4 (System.Object)+18]");
					bool flag5 = (nint)0 <= (nint)0;
					result = 1f;
					if (!flag5)
					{
						bool flag6 = ((Dictionary<StageType, List<StageData>>)value).TryGetValue(stage._stageType, out *(List<StageData>*)(&value));
						bool flag7 = !flag6;
						result = 1f;
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v14 (System.Boolean)+1C8]");
							bool flag8 = (nint)0 == 0;
							result = 1f;
							if (!flag8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v14 (System.Boolean)+1C8]");
								if ((nint)0 == 0)
								{
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
									float result2 = default(float);
									return result2;
								}
								float num = default(float);
								result = num;
							}
						}
					}
				}
			}
		}
		return result;
	}

	private void ClearSpawned()
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		bool flag = _spawned == null;
		MerchantUIPage merchantUIPage = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			merchantUIPage = (MerchantUIPage)(object)_spawned;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v2 (VampireSurvivors.UI.MerchantUIPage)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)merchantUIPage).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)merchantUIPage).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)merchantUIPage).m_CachedPtr, 0, (int)((MonoBehaviour)merchantUIPage).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void IntroAnimation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_036f: Expected I, but got O
		//IL_03b0: Expected O, but got Ref
		//IL_0066: Expected O, but got Ref
		//IL_00ea: Expected I, but got O
		//IL_00f8: Expected O, but got Ref
		//IL_0110: Expected O, but got Ref
		//IL_0118: Expected I, but got O
		//IL_03f3: Expected O, but got Ref
		//IL_01f0: Expected O, but got Ref
		//IL_042e: Expected I, but got O
		//IL_043c: Expected O, but got Ref
		//IL_0261: Expected O, but got Ref
		//IL_04c3: Expected O, but got Ref
		//IL_050a: Expected I, but got O
		//IL_0518: Expected O, but got Ref
		//IL_0312->IL033b: Incompatible stack heights: 13 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)_BackButton != null)
		{
			Transform transform = _BackButton.transform;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v23 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			_ = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v27 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
			Transform transform2 = _BackButton.transform;
			_ = -90f;
			Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			transform2.localEulerAngles = localEulerAngles;
			Image componentInParent = _BurstVFX.GetComponentInParent<Image>();
			PlayerOptionsData config = _playerOptions.Config;
			bool flag2 = !config._003CFlashingVFXEnabled_003Ek__BackingField;
			bool flag3 = !flag2;
			bool flag4 = (object)componentInParent == null;
			nint num3 = (nint)componentInParent;
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v848 @ r8_v12 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			nint num4 = (nint)componentInParent;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v859 @ rax_v40 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
			bool flag5 = (object)_BurstVFX == null;
			_BurstVFX.Play();
			bool flag6 = (object)_Panel == null;
			Transform transform3 = _Panel.transform;
			bool flag7 = (object)transform3 == null;
			_ = 0;
			bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj6);
			bool flag9 = (object)_Panel == null;
			Transform transform4 = _Panel.transform;
			bool flag10 = (object)transform4 == null;
			_ = 180f;
			Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			transform4.localEulerAngles = localEulerAngles2;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_Panel, 1f, 0.15f);
			nint num5 = (nint)typeof(Vector3);
			Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rax_v52 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num6 = 0;
			_ = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rax_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_Panel, endValue, 0.15f);
			bool flag11 = (object)_CurrencyPanel == null;
			Transform transform5 = _CurrencyPanel.transform;
			bool flag12 = (object)transform5 == null;
			_ = -45f;
			Vector3 localEulerAngles3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			transform5.localEulerAngles = localEulerAngles3;
			bool flag13 = (object)_CurrencyPanel == null;
			Transform transform6 = _CurrencyPanel.transform;
			bool flag14 = (object)transform6 == null;
			_ = 0;
			bool flag15 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj7);
			nint num7 = (nint)typeof(Vector3);
			Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rax_v64 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num8 = 0;
			_ = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ rax_v65 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(_CurrencyPanel, endValue2, 0.5f);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(_CurrencyPanel, 1f, 0.5f);
			TweenCallback tweenCallback = delegate
			{
				//IL_0056: Expected O, but got Ref
				Transform target = _BackButton.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(target, 1f, 0.15f);
				Transform target2 = _BackButton.transform;
				object obj9 = default(object);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj9), 0.15f);
			};
			tweenCallback._002Ector(this, (nint)__ldftn(MerchantUIPage._003CIntroAnimation_003Eb__71_0));
			Tween tween = UITimerHelper.RegisterMillis(500f, tweenCallback);
			if ((object)_Mask != null)
			{
				_Mask.enabled = false;
				_003CWaitAndTween_003Ed__72 obj8 = null;
				obj8._003C_003E1__state = 0;
				obj8._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj8);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator WaitAndTween()
	{
		_003CWaitAndTween_003Ed__72 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void DisableWeaponPanels()
	{
		//IL_006a: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_01c3: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController currentCharacter = _currentCharacter;
		CharacterWeaponsManager weaponsManager = currentCharacter._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController currentCharacter2 = _currentCharacter;
		CharacterAccessoriesManager accessoriesManager = currentCharacter2._accessoriesManager;
		List<Equipment> list2 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
		List<GameObject> spawned = _spawned;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= spawned._size)
			{
				return;
			}
			List<GameObject> spawned2 = _spawned;
			if ((nint)obj >= spawned2._size)
			{
				break;
			}
			GameObject[] items = spawned2._items;
			ShopItemUI component = items[obj].GetComponent<ShopItemUI>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && component._weaponType != WeaponType.VOID)
			{
				WeaponData weaponData = component._weaponData;
				VampireSurvivors.Objects.Characters.CharacterController currentCharacter3 = _currentCharacter;
				if (!weaponData._003CisPowerUp_003Ek__BackingField)
				{
					object obj3 = currentCharacter3._maxWeaponBonus + currentCharacter3._maxWeaponCount;
					if (list._size < (nint)obj3)
					{
						goto IL_01f2;
					}
				}
				else
				{
					object obj4 = currentCharacter3._maxAccessoryBonus + currentCharacter3._maxAccessoryCount;
					if (list2._size < (nint)obj4)
					{
						goto IL_01f2;
					}
				}
				component.SoldOut();
			}
			goto IL_01f2;
			IL_01f2:
			spawned = _spawned;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public MerchantUIPage()
	{
		//IL_0bc7: Expected O, but got I
		//IL_0c21: Expected O, but got I
		//IL_0ce7: Expected O, but got I
		//IL_0c8b: Expected O, but got I
		string[] textColors = new string[3];
		_textColors = textColors;
		_SpamPressFirst = true;
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HeartBlack.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"ArmorIron.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HeartRuby.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Wing.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Leaf.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Book2.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Candelabra.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gauntlet.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"EmblemEye.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Ring.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Clover.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items12 = list._items;
		if (list._size >= items12.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Crown.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items13 = list._items;
		if (list._size >= items13.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Mask.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items14 = list._items;
		if (list._size >= items14.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Curse.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items15 = list._items;
		if (list._size >= items15.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"OrbGlow.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items16 = list._items;
		if (list._size >= items16.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Tiramisu.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items17 = list._items;
		if (list._size >= items17.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Dice.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items18 = list._items;
		if (list._size >= items18.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Skip.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items19 = list._items;
		if (list._size >= items19.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Banish.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_itemSprites = list;
		_goldenEggSFXDetune = new int[21]
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
			21
		};
		List<ItemType> list2 = new List<ItemType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdx_v49+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)27);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 27;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdx_v51+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)55);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 55;
		}
		ForbiddenItemsInMultiplayer = list2;
		base._002Ector();
	}

	private unsafe void _003CIntroAnimation_003Eb__71_0()
	{
		//IL_0056: Expected O, but got Ref
		Transform target = _BackButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.15f);
		Transform target2 = _BackButton.transform;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj), 0.15f);
	}
}
