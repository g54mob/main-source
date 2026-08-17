using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.UI;

public class VCDemoScript : MonoBehaviour
{
	private MainMenuPage MainMenu;

	private Image Banner;

	private Sprite Banner1;

	private Sprite Banner2;

	private Sprite Banner3;

	private Sprite Banner4;

	private GameObject Flare;

	private Image FlareImage;

	private GameObject WishlistNow;

	private GameObject DemoNow;

	private Button ButtonToSelect;

	private AnimationCurve FlareAlphaCurve;

	private AnimationCurve NextBannerAlphaCurve;

	private AnimationCurve PrevBannerAlphaCurve;

	private GameObject FlareStartPos;

	private GameObject FlareEndPos;

	private float AnimationTotalTime;

	private float pointInAnimToSwapBanner;

	private float TimeBetweenAnimations;

	private Sprite prevBanner;

	private Sprite NextBanner;

	private float animationTimer;

	private bool runningAnimation;

	private DateTime DemoLiveUTCTime;

	private DateTime CountdownLiveUTCTime;

	private float timeToStartNextAnim;

	private bool notSwappedBanner;

	private void Start()
	{
		MainMenuPage mainMenu = MainMenu;
		PlayerOptionsData config = mainMenu._playerOptions.Config;
		List<StageType> list = config._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				DateTime utcNow = DateTime.UtcNow;
				if (!(utcNow >= CountdownLiveUTCTime))
				{
					DateTime utcNow2 = DateTime.UtcNow;
					GameObject wishlistNow;
					bool active;
					if (!(utcNow2 >= DemoLiveUTCTime))
					{
						int num = PlayerPrefs.GetInt("ClosedWishlistPopup", 0);
						if (num == 1)
						{
							goto IL_01e0;
						}
						DemoNow.SetActive(value: false);
						wishlistNow = WishlistNow;
						active = true;
					}
					else
					{
						int num2 = PlayerPrefs.GetInt("ClosedDemoPopup", 0);
						if (num2 == 1)
						{
							goto IL_01e0;
						}
						DemoNow.SetActive(value: true);
						wishlistNow = WishlistNow;
						active = false;
					}
					wishlistNow.SetActive(active);
					prevBanner = Banner1;
					NextBanner = Banner2;
					GameObject gameObject = base.gameObject;
					if (gameObject.activeInHierarchy)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 305 Invalid \"Jump target not found in method: 0x180B81A60\"");
					}
					return;
				}
			}
		}
		goto IL_01e0;
		IL_01e0:
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: false);
	}

	public void closeCrawlersPopup()
	{
		DateTime today = DateTime.Today;
		DateTime dateTime = default(DateTime);
		int datePart = dateTime.GetDatePart(1);
		bool flag = datePart < 54;
		string key = "ClosedWishlistPopup";
		if (!flag)
		{
			key = "ClosedDemoPopup";
		}
		PlayerPrefs.SetInt(key, 1);
		ButtonToSelect.Select();
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public void OpenCrawlersPopup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA24]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SteamFriends.OpenWebOverlay("https://store.steampowered.com/app/3265700/?utm_source=vampire_survivors&utm_medium=pc_in_game_button&utm_campaign=vc_launch");
	}

	public void StartAnimation()
	{
		//IL_042d: Expected O, but got I4
		//IL_0447: Expected O, but got I4
		//IL_049a: Expected O, but got I4
		//IL_04b4: Expected O, but got I4
		//IL_0507: Expected O, but got I4
		//IL_0521: Expected O, but got I4
		//IL_0574: Expected O, but got I4
		//IL_058e: Expected O, but got I4
		Debug.Log("StartAnimation");
		Image banner = Banner;
		Sprite sprite = banner.m_Sprite;
		Sprite banner2 = Banner1;
		bool flag = (object)Banner1 == null;
		bool flag2 = (object)banner.m_Sprite == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		Sprite nextBanner;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)Banner1 != null)
			{
				if ((object)banner.m_Sprite != null)
				{
					object obj3 = (object)banner.m_Sprite - (object)Banner1;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)banner2).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				Image banner3 = Banner;
				Sprite sprite2 = banner3.m_Sprite;
				Sprite banner4 = Banner2;
				bool flag5 = (object)Banner2 == null;
				bool flag6 = (object)banner3.m_Sprite == null;
				object obj4 = flag6 & flag5;
				bool flag7 = obj4 == null;
				object obj5 = !flag7;
				if (obj5 == null)
				{
					bool flag8;
					if ((object)Banner2 != null)
					{
						if ((object)banner3.m_Sprite != null)
						{
							object obj6 = (object)banner3.m_Sprite - (object)Banner2;
							flag8 = obj6 == null;
						}
						else
						{
							flag8 = ((UnityEngine.Object)banner4).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						flag8 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
					}
					if (!flag8)
					{
						Image banner5 = Banner;
						Sprite sprite3 = banner5.m_Sprite;
						Sprite banner6 = Banner3;
						bool flag9 = (object)Banner3 == null;
						bool flag10 = (object)banner5.m_Sprite == null;
						object obj7 = flag10 & flag9;
						bool flag11 = obj7 == null;
						object obj8 = !flag11;
						if (obj8 == null)
						{
							bool flag12;
							if ((object)Banner3 != null)
							{
								if ((object)banner5.m_Sprite != null)
								{
									object obj9 = (object)banner5.m_Sprite - (object)Banner3;
									flag12 = obj9 == null;
								}
								else
								{
									flag12 = ((UnityEngine.Object)banner6).m_CachedPtr == (IntPtr)0;
								}
							}
							else
							{
								flag12 = ((UnityEngine.Object)sprite3).m_CachedPtr == (IntPtr)0;
							}
							if (!flag12)
							{
								Image banner7 = Banner;
								Sprite sprite4 = banner7.m_Sprite;
								Sprite banner8 = Banner4;
								bool flag13 = (object)Banner4 == null;
								bool flag14 = (object)banner7.m_Sprite == null;
								object obj10 = flag14 & flag13;
								bool flag15 = obj10 == null;
								object obj11 = !flag15;
								if (obj11 == null)
								{
									bool flag16;
									if ((object)Banner4 != null)
									{
										if ((object)banner7.m_Sprite != null)
										{
											object obj12 = (object)banner7.m_Sprite - (object)Banner4;
											flag16 = obj12 == null;
										}
										else
										{
											flag16 = ((UnityEngine.Object)banner8).m_CachedPtr == (IntPtr)0;
										}
									}
									else
									{
										flag16 = ((UnityEngine.Object)sprite4).m_CachedPtr == (IntPtr)0;
									}
									if (!flag16)
									{
										goto IL_03cf;
									}
								}
								prevBanner = Banner4;
								nextBanner = Banner1;
								goto IL_05b5;
							}
						}
						prevBanner = Banner3;
						nextBanner = Banner4;
						goto IL_05b5;
					}
				}
				prevBanner = Banner2;
				NextBanner = Banner3;
				goto IL_03cf;
			}
		}
		prevBanner = Banner1;
		NextBanner = Banner2;
		goto IL_03cf;
		IL_03cf:
		animationTimer = 0f;
		runningAnimation = true;
		notSwappedBanner = true;
		return;
		IL_05b5:
		NextBanner = nextBanner;
		goto IL_03cf;
	}

	private void Update()
	{
		//IL_0254: Expected O, but got F4
		//IL_022d: Expected O, but got F4
		//IL_0237: Invalid comparison between O and F4
		//IL_0296: Expected O, but got F4
		//IL_033e: Invalid comparison between I4 and F4
		//IL_0300->IL021d: Incompatible stack heights: 1 vs 0
		//IL_016b->IL021d: Incompatible stack heights: 1 vs 0
		//IL_036c->IL021d: Incompatible stack heights: 2 vs 0
		//IL_01ce->IL021d: Incompatible stack heights: 2 vs 0
		//IL_03bb->IL021d: Incompatible stack heights: 3 vs 0
		//IL_0204->IL021d: Incompatible stack heights: 3 vs 0
		//IL_043e->IL043e: Incompatible stack heights: 6 vs 0
		object obj2 = default(object);
		if (!runningAnimation)
		{
			object obj = Time.time;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)timeToStartNextAnim))
			{
				StartAnimation();
			}
			return;
		}
		object obj3 = Time.deltaTime;
		float num = (animationTimer = (float)obj2 + animationTimer);
		if (!(num < AnimationTotalTime))
		{
			animationTimer = AnimationTotalTime;
			runningAnimation = false;
			object obj4 = Time.time;
			float num2 = num + TimeBetweenAnimations;
			timeToStartNextAnim = num2;
		}
		if (!(animationTimer < pointInAnimToSwapBanner) && notSwappedBanner)
		{
			notSwappedBanner = false;
			if ((object)Banner == null)
			{
				goto IL_021d;
			}
			Banner.sprite = NextBanner;
		}
		float num3 = animationTimer / AnimationTotalTime;
		if ((object)Flare != null)
		{
			Transform transform = Flare.transform;
			if ((object)FlareStartPos != null)
			{
				Transform transform2 = FlareStartPos.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
					if ((object)FlareEndPos != null)
					{
						Transform transform3 = FlareEndPos.transform;
						if ((object)transform3 != null)
						{
							bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret2);
							if (0f > num3 || num3 > 1f)
							{
							}
							if ((object)Flare != null)
							{
								Transform transform4 = Flare.transform;
								if ((object)transform4 != null)
								{
									bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
									if ((object)Flare != null)
									{
										Transform transform5 = Flare.transform;
										if ((object)transform5 != null)
										{
											bool flag4 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
											Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret2);
											bool flag5 = (object)transform == null;
											bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
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
		goto IL_021d;
		IL_021d:
		throw new NullReferenceException();
	}

	public unsafe VCDemoScript()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_005a: Expected native int or pointer, but got O
		//IL_00a1: Expected O, but got I4
		_ = 0;
		object obj = default(object);
		DateTime dateTime = (DateTime)(obj + 8);
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 18;
		_ = 0;
		int hour = default(int);
		int minute = default(int);
		int second = default(int);
		DateTimeKind kind = default(DateTimeKind);
		*(DateTime*)(nint)dateTime = new DateTime(2026, 2, 23, hour, minute, second, kind);
		DateTime demoLiveUTCTime = default(DateTime);
		DemoLiveUTCTime = demoLiveUTCTime;
		demoLiveUTCTime = new DateTime(2026, 4, 14, hour, minute, second, kind);
		CountdownLiveUTCTime = (DateTime)0;
	}
}
