using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MainMenu : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__39_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CExitGame_003Eb__39_0()
		{
			Application.Quit(0);
		}
	}

	private sealed class _003CAnimateNewButtons_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenu _003C_003E4__this;

		public List<GameObject> objects;

		private List<GameObject>.Enumerator _003C_003E7__wrap1;

		private GameObject _003Co_003E5__3;

		private float _003CscaleTime_003E5__4;

		private float _003Ctimer_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CAnimateNewButtons_003Ed__15(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		unsafe void IDisposable.Dispose()
		{
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_002f: Expected O, but got I4
			if (_003C_003E1__state != -3)
			{
				object obj = _003C_003E1__state + -2;
				if ((nint)obj > 1)
				{
					return;
				}
			}
			_ = 4294967295L;
			object obj2 = default(object);
			List<GameObject>.Enumerator enumerator = (List<GameObject>.Enumerator)(obj2 + 48);
			((List<GameObject>.Enumerator*)enumerator)->Dispose();
		}

		private unsafe bool MoveNext()
		{
			//IL_002c: Expected O, but got I
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0539: Expected O, but got I
			//IL_0727: Expected O, but got I
			//IL_03c0: Invalid comparison between I4 and F4
			//IL_07a3: Expected I, but got I8
			//IL_07a3: Expected O, but got I
			//IL_07b1: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_040b: Expected F4, but got I4
			//IL_083c: Expected O, but got I
			//IL_058e: Expected O, but got Ref
			//IL_0156: Expected O, but got I
			//IL_0178: Expected O, but got I
			//IL_0421: Expected O, but got I
			//IL_04c4: Expected O, but got I
			//IL_04db: Expected O, but got I
			//IL_01af: Expected O, but got I
			//IL_0437: Expected O, but got Ref
			//IL_05cf: Expected O, but got Ref
			//IL_01f8: Expected O, but got I
			//IL_025e: Expected O, but got I
			//IL_02a5: Expected O, but got Ref
			//IL_02c1: Expected O, but got Ref
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+10]");
			bool flag = (nint)0 == 0;
			float num4 = default(float);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+10]");
				GameObject gameObject = (GameObject)(-1);
				if (!flag)
				{
					object obj = gameObject - 1;
					if (flag)
					{
						_ = 4294967293L;
						goto IL_034c;
					}
					if ((nint)obj != 1)
					{
						return false;
					}
					_ = 4294967293L;
					_ = 0;
				}
				else
				{
					_ = 4294967295L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+28]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					_ = 4294967293L;
				}
				nint num2 = default(nint);
				List<object>.Enumerator enumerator = (List<object>.Enumerator)(num2 + 48);
				if (((List<object>.Enumerator*)enumerator)->MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+48]");
					gameObject = (GameObject)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+48]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+48]");
						((GameObject)0).SetActive(value: true);
						_ = 1048576000;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+68]");
						gameObject = (GameObject)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+68]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+68]");
							Transform transform = ((GameObject)0).transform;
							if ((object)transform != null)
							{
								Transform parent = transform.parent;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+68]");
								GameObject gameObject2 = UnityEngine.Object.Instantiate((GameObject)0, parent);
								if ((object)gameObject2 != null)
								{
									Transform transform2 = gameObject2.transform;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+48]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+48]");
										Transform transform3 = ((GameObject)0).transform;
										if ((object)transform3 != null)
										{
											Vector3 position = transform3.position;
											bool flag2 = (object)transform2 == null;
											float num3 = default(float);
											gameObject = (GameObject)(&num3);
											if (!flag2)
											{
												transform2.position = (Vector3)(&num4);
												gameObject2.SetActive(value: true);
												DestroyObject destroyObject = gameObject2.AddComponent<DestroyObject>();
												bool flag3 = (object)destroyObject == null;
												gameObject = gameObject2;
												if (!flag3)
												{
													destroyObject.time = 0.8f;
													bool flag4 = (object)AudioManager.Instance == null;
													gameObject = (GameObject)(object)AudioManager.Instance;
													if (!flag4)
													{
														AudioManager.Instance.PlayNewMenuButton();
														goto IL_034c;
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
					throw new NullReferenceException();
				}
				((UnityEngine.Object)num2).m_CachedPtr = unchecked((nint)4294967295L);
				List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(num2 + 48);
				((List<GameObject>.Enumerator*)enumerator2)->Dispose();
				_ = 0;
				_ = 0;
				gameObject = null;
				ButtonManager.enabled = true;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+60]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+60]");
					((GameObject)0).SetActive(value: false);
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+50]");
					ButtonManager.ForceHoverButton((MyButton)0);
					return false;
				}
				throw new NullReferenceException();
			}
			_ = 4294967295L;
			ButtonManager.enabled = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+60]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rsi_v1 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>>)+60]");
				((GameObject)0).SetActive(value: true);
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+28]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
					GameObject gameObject3 = default(GameObject);
					List<object>.Enumerator enumerator5 = default(List<object>.Enumerator);
					while (true)
					{
						if (enumerator3.MoveNext())
						{
							bool flag5 = (object)gameObject3 == null;
							List<object>.Enumerator enumerator4 = (List<object>.Enumerator)(&enumerator3);
							if (!flag5)
							{
								gameObject3.SetActive(value: true);
								Transform transform4 = gameObject3.transform;
								if ((object)transform4 == null)
								{
									break;
								}
								transform4.localScale = (Vector3)(&enumerator5);
								continue;
							}
							throw new NullReferenceException();
						}
						((List<GameObject>.Enumerator*)(&enumerator3))->Dispose();
						Transform transform5 = ((Component)0).transform;
						UiUtility.RebuildUi(transform5);
						WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(1f);
						waitForSecondsRealtime._002Ector(1f);
						_ = 1;
						return true;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_034c:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+50]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+54]");
			if (num5 > 0)
			{
				float deltaTime = Time.deltaTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+54]");
				float num6 = 0f + deltaTime;
				float num7 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+50]");
				float num8 = num7 / 0f;
				if (!(0f > num8))
				{
					if (num8 > 1f)
					{
						num8 = 1f;
					}
				}
				else
				{
					num8 = 0f;
				}
				float num9 = Easing.InOutQuad(num8);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+48]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v1 (Il2CppMethodInfo)+48]");
					Transform transform6 = ((GameObject)0).transform;
					transform6.localScale = (Vector3)(&num4);
					_ = 0;
					_ = 2;
					return true;
				}
				throw new NullReferenceException();
			}
			WaitForSecondsRealtime waitForSecondsRealtime2 = new WaitForSecondsRealtime(0.6f);
			_ = 3;
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
			List<GameObject>.Enumerator enumerator = (List<GameObject>.Enumerator)(this + 48);
			((List<GameObject>.Enumerator*)enumerator)->Dispose();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public static Action A_MenuOpened;

	public MenuCamera menuCamera;

	public GameObject btnUnlocks;

	public GameObject btnQuests;

	public GameObject btnShop;

	public GameObject leaderboards;

	public GameObject quickQuests;

	public MyButton btnPlay;

	private bool isAnimating;

	public GameObject blockRaycastOverlay;

	public GameObject newButtonParticles;

	public MapSelectionUi mapSelectionUi;

	public GameObject tabMenu;

	public GameObject tabCharacters;

	public GameObject tabMaps;

	public GameObject tabShop;

	public GameObject tabUnlocks;

	public GameObject tabLogs;

	public GameObject settings;

	public GameObject credits;

	public GameObject quests;

	public GameObject leaderboardsFull;

	private GameObject currentTab;

	private void Awake()
	{
		//IL_013f: Expected I, but got O
		currentTab = tabMenu;
		MyTime.Unpause();
		Action b = RefreshButtons;
		Delegate obj = Delegate.Combine(SaveManager.A_SavesLoaded, b);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = RefreshButtons;
		Delegate obj = Delegate.Remove(SaveManager.A_SavesLoaded, value);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Start()
	{
		if (SaveManager.loaded)
		{
			SaveManager._003CInstance_003Ek__BackingField.SaveProgression();
			SaveManager._003CInstance_003Ek__BackingField.SaveStats();
		}
		RefreshButtons();
		mapSelectionUi.Init();
		SteamLeaderboardsManagerNew.MenuOpened();
		MyInputManager.RefreshHorizontalNavigationForChests(isChestWindowOpen: false);
		Action a_MenuOpened = A_MenuOpened;
		if (A_MenuOpened != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v199.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void RefreshButtons()
	{
		//IL_00ea: Expected O, but got I
		//IL_0100: Expected O, but got I
		//IL_0152: Expected O, but got I4
		//IL_0167: Expected O, but got I
		//IL_017c: Expected O, but got I
		//IL_01a4: Expected O, but got I4
		//IL_0240: Expected O, but got I
		//IL_0256: Expected O, but got I
		//IL_01c3: Expected O, but got I4
		//IL_01d8: Expected O, but got I
		//IL_02a8: Expected O, but got I4
		//IL_01ed: Expected O, but got I
		//IL_02bd: Expected O, but got I
		//IL_02d2: Expected O, but got I
		//IL_02fa: Expected O, but got I4
		//IL_0396: Expected O, but got I
		//IL_03ac: Expected O, but got I
		//IL_0319: Expected O, but got I4
		//IL_032e: Expected O, but got I
		//IL_03fe: Expected O, but got I4
		//IL_0343: Expected O, but got I
		//IL_0413: Expected O, but got I
		//IL_0428: Expected O, but got I
		//IL_0450: Expected O, but got I4
		//IL_04ec: Expected O, but got I
		//IL_0502: Expected O, but got I
		//IL_046f: Expected O, but got I4
		//IL_0484: Expected O, but got I
		//IL_0554: Expected O, but got I4
		//IL_0499: Expected O, but got I
		//IL_0569: Expected O, but got I
		//IL_057e: Expected O, but got I
		//IL_05a6: Expected O, but got I4
		//IL_0642: Expected O, but got I
		//IL_0658: Expected O, but got I
		//IL_05c5: Expected O, but got I4
		//IL_05da: Expected O, but got I
		//IL_0716: Expected O, but got I4
		//IL_05ef: Expected O, but got I
		//IL_072b: Expected O, but got I
		//IL_0740: Expected O, but got I
		//IL_077d: Expected O, but got I4
		//IL_0792: Expected O, but got I
		//IL_07a7: Expected O, but got I
		if ((SaveManager.loaded && !(SaveManager._003CInstance_003Ek__BackingField != null)) || !SaveManager.loaded || !(SaveManager._003CInstance_003Ek__BackingField != null))
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v15+30]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rax_v20+20]");
		if ((nint)0 == 0)
		{
			return;
		}
		List<GameObject> list = new List<GameObject>();
		((List<GameObject>)null)._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.GameObject>)+30]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v25+50]");
		GameObject item;
		if (!((MenuMeta)0).HasMenuUnlocks())
		{
			btnUnlocks.SetActive(value: false);
			item = null;
		}
		else
		{
			btnUnlocks.SetActive(value: true);
			((List<GameObject>)null).Add((GameObject)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v114+20]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v115+50]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v116+24]");
			bool flag = (nint)0 != 0;
			item = (GameObject)1;
			if (!flag)
			{
				((List<GameObject>)null).Add((GameObject)1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v118+20]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v119+50]");
				object obj5 = 0;
				_ = 1;
				item = btnUnlocks;
				list.Add(btnUnlocks);
			}
		}
		((List<GameObject>)null).Add(item);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v29+30]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v30+50]");
		GameObject item2;
		if (!((MenuMeta)0).HasMenuQuests())
		{
			btnQuests.SetActive(value: false);
			item2 = null;
		}
		else
		{
			btnQuests.SetActive(value: true);
			((List<GameObject>)null).Add((GameObject)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v100+20]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v101+50]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v102+25]");
			bool flag2 = (nint)0 != 0;
			item2 = (GameObject)1;
			if (!flag2)
			{
				((List<GameObject>)null).Add((GameObject)1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rax_v104+20]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v105+50]");
				object obj10 = 0;
				_ = 1;
				item2 = btnQuests;
				list.Add(btnQuests);
			}
		}
		((List<GameObject>)null).Add(item2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v34+30]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rax_v35+50]");
		GameObject item3;
		if (!((MenuMeta)0).HasMenuShop())
		{
			btnShop.SetActive(value: false);
			item3 = null;
		}
		else
		{
			btnShop.SetActive(value: true);
			((List<GameObject>)null).Add((GameObject)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v86+20]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v87+50]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v88+26]");
			bool flag3 = (nint)0 != 0;
			item3 = (GameObject)1;
			if (!flag3)
			{
				((List<GameObject>)null).Add((GameObject)1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v90+20]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v91+50]");
				object obj15 = 0;
				_ = 1;
				item3 = btnShop;
				list.Add(btnShop);
			}
		}
		((List<GameObject>)null).Add(item3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v39+30]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v40+50]");
		GameObject item4;
		if (!((MenuMeta)0).HasLeaderboards())
		{
			leaderboards.SetActive(value: false);
			item4 = null;
		}
		else
		{
			leaderboards.SetActive(value: true);
			((List<GameObject>)null).Add((GameObject)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v72+20]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v73+50]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v74+27]");
			bool flag4 = (nint)0 != 0;
			item4 = (GameObject)1;
			if (!flag4)
			{
				((List<GameObject>)null).Add((GameObject)1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rax_v76+20]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v77+50]");
				object obj20 = 0;
				_ = 1;
				item4 = leaderboards;
				list.Add(leaderboards);
			}
		}
		((List<GameObject>)null).Add(item4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v44+30]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rax_v45+50]");
		if (!((MenuMeta)0).HasQuickQuests())
		{
			quickQuests.SetActive(value: false);
		}
		else
		{
			quickQuests.SetActive(value: true);
			((List<GameObject>)null).Add((GameObject)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v49+20]");
			object obj22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rax_v50+50]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v51+28]");
			if ((nint)0 == 0)
			{
				((List<GameObject>)null).Add((GameObject)1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v53+20]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v54+50]");
				object obj25 = 0;
				_ = 1;
				list.Add(quickQuests);
			}
		}
		if (list._size > 0 && !isAnimating)
		{
			_003CAnimateNewButtons_003Ed__15 obj26 = new _003CAnimateNewButtons_003Ed__15(0);
			obj26._003C_003E1__state = 0;
			obj26._003C_003E4__this = this;
			obj26.objects = list;
			Coroutine coroutine = StartCoroutine(obj26);
		}
	}

	private IEnumerator AnimateNewButtons(List<GameObject> objects)
	{
		_003CAnimateNewButtons_003Ed__15 obj = new _003CAnimateNewButtons_003Ed__15(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.objects = objects;
		return obj;
	}

	public void GoToMenu()
	{
		tabMenu.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = tabMenu;
		menuCamera.GoToMain();
		RefreshButtons();
	}

	public void GoToCharacterSelection()
	{
		tabCharacters.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = tabCharacters;
		menuCamera.GoToCharacters();
	}

	public void GoToMapSelection()
	{
		tabMaps.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = tabMaps;
	}

	public void GoToShop()
	{
		tabShop.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = tabShop;
	}

	public void GoToCredits()
	{
		credits.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = credits;
	}

	public void GoToUnlocks()
	{
		tabUnlocks.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = tabUnlocks;
	}

	public void GoToQuests()
	{
		quests.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = quests;
	}

	public void GoToLogs()
	{
		tabLogs.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = tabLogs;
	}

	public void GoToSettings()
	{
		settings.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = settings;
	}

	public void GoToLeaderboards()
	{
		leaderboardsFull.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = leaderboardsFull;
	}

	public void SetWindow(GameObject tabWindow)
	{
		tabWindow.SetActive(value: true);
		if ((object)currentTab != null)
		{
			currentTab.SetActive(value: false);
		}
		currentTab = tabWindow;
	}

	public void ExitGame()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("Main Menu", "MENU_BUTTON_EXIT_GAME");
		string localizedString2 = LocalizationUtility.GetLocalizedString("DynamicWindows", "EXIT_GAME");
		Action a_Accept = _003C_003Ec._003C_003E9__39_0;
		if (_003C_003Ec._003C_003E9__39_0 == null)
		{
			a_Accept = (_003C_003Ec._003C_003E9__39_0 = delegate
			{
				Application.Quit(0);
			});
		}
		instance.dynamicWindows.NewWindowPrompt(localizedString, localizedString2, a_Accept);
	}
}
