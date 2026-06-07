using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class TallyInsurance : MonoBehaviour
{
	public class Claim
	{
		public string name;

		public string info;

		public string claim = string.Empty;
	}

	private enum State
	{
		Intro = 0,
		Idle = 1,
		Flipping = 2,
		Signing = 3,
		Done = 4
	}

	public AudioClip musicAudioClip;

	public AudioClip signatureAudioClip0;

	public AudioClip signatureAudioClip1;

	public ShuffleAudioClips flipPageAudioClips;

	[Readonly]
	public Tally tally;

	[Readonly]
	public PageTemplate pageTemplate;

	private int pageIndex;

	private int targetPageIndex;

	private Stater<State> stater;

	private List<Claim> claims;

	private int totalClaimed;

	private float flipSnapX;

	private AudioOneShot musicAudioOneShot;

	private bool signed;

	private bool haveFlippedPage;

	private bool showPageNextGlyphUntilFlipPage;

	private const int kAmountShip = 20000;

	private const int kAmountCargoCompany = 5000;

	private const int kAmountCargoCrown = 3000;

	private const int kAmountCrime = -25;

	private const int kAmountDemerit = -10;

	private const int kAmountMerit = 10;

	private const int kNumClaimsPerPage = 3;

	public const int kPageCount = 23;

	private static CultureInfo enCultureInfo = new CultureInfo("en-US");

	private void Start()
	{
		stater = new Stater<State>("TallyInsurance");
		stater.AddState(State.Intro);
		stater.AddState(State.Idle).AddFunc(StaterFunc.ENTER(delegate
		{
			if (Awards.CheckForKillerCaptain())
			{
				Awards.Give(Awards.Id.KillerCaptain);
			}
			Refresh();
			pageTemplate.interactable = true;
			AudioOneShot.Play(flipPageAudioClips.next);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (musicAudioOneShot == null)
			{
				musicAudioOneShot = AudioOneShot.Play(musicAudioClip, true, 0f);
			}
			if (RInput.GetButtonRepeating(21) || RInput.GetButtonRepeating(51) || RInput.GetAxis(18) < -0.01f)
			{
				FlipPage(-1);
			}
			else if (RInput.GetButtonRepeating(22) || RInput.GetButtonRepeating(52) || RInput.GetAxis(18) > 0.01f)
			{
				FlipPage(1);
			}
			if (DebugMenu.WantSkip())
			{
				stater.Go(State.Signing);
			}
		}))
			.AddFunc(StaterFunc.AT_STEP(2f, delegate
			{
				showPageNextGlyphUntilFlipPage = true;
				Refresh();
			}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				pageTemplate.interactable = false;
			}));
		stater.AddState(State.Flipping).SetDurations(0.25f, 0.001f, State.Idle).AddFunc(StaterFunc.ENTER(delegate
		{
			AudioOneShot.Play(flipPageAudioClips.next);
			flipSnapX = ((targetPageIndex <= pageIndex) ? 1 : (-1)) * 20;
			pageTemplate.interactable = true;
			pageIndex = targetPageIndex;
			Refresh();
		}))
			.AddFunc(StaterFunc.INTERP(delegate(float t)
			{
				RectTransform rectTransform = base.transform as RectTransform;
				Vector2 anchoredPosition = rectTransform.anchoredPosition;
				anchoredPosition.x = flipSnapX * (1f - Util.PowInv(t, 2f));
				rectTransform.anchoredPosition = anchoredPosition;
			}));
		stater.AddState(State.Signing).SetDurations(1f, 6f, State.Done).AddFunc(StaterFunc.ENTER(delegate
		{
			if (musicAudioOneShot != null)
			{
				musicAudioOneShot.Stop(1f);
				musicAudioOneShot = null;
			}
			AudioOneShot.Play(signatureAudioClip0);
			AudioOneShot.Play(signatureAudioClip1);
			signed = true;
			Refresh();
		}))
			.AddFunc(StaterFunc.INTERP(delegate(float t)
			{
				RectTransform rectTransform = base.transform as RectTransform;
				Vector2 anchoredPosition = rectTransform.anchoredPosition;
				anchoredPosition.y = -20f * (1f - Util.PowInv(t, 2f));
				rectTransform.anchoredPosition = anchoredPosition;
			}))
			.AddFunc(StaterFunc.STEP(delegate
			{
			}));
		stater.AddState(State.Done).AddFunc(StaterFunc.ENTER(delegate
		{
			tally.OnInsuranceDone();
		}));
		BuildClaims();
	}

	public void GoIdle()
	{
		stater.Go(State.Idle);
	}

	private void OnEnable()
	{
		Refresh();
	}

	private void Update()
	{
		stater.Step(Clock.play.deltaTime);
		if (musicAudioOneShot != null)
		{
			musicAudioOneShot.volume = Mathf.Min(0.2f, musicAudioOneShot.volume + Clock.play.deltaTime / 20f);
		}
	}

	private void Refresh()
	{
		if (claims == null || pageTemplate == null)
		{
			return;
		}
		pageTemplate.BeginRefresh();
		Dictionary<string, PageItem> pageItemDict = pageTemplate.pageItemDict;
		pageItemDict["page-title"].visible = pageIndex == 0;
		pageItemDict["page-content"].visible = pageIndex > 0 && pageIndex < 22;
		pageItemDict["page-signature"].visible = pageIndex == 22;
		pageItemDict["page-num"].text = string.Format("{0} / {1}", pageIndex + 1, 23);
		pageItemDict["prev-button"].visible = pageIndex > 0;
		pageItemDict["next-button"].visible = pageIndex < 22;
		pageItemDict["signature"].visible = signed;
		if (!haveFlippedPage && showPageNextGlyphUntilFlipPage)
		{
			pageItemDict["glyph-pagenext"].visible = true;
		}
		int num = pageIndex - 1;
		if (num >= 0 && num < claims.Count / 3)
		{
			for (int i = 0; i < 3; i++)
			{
				Claim claim = claims[num * 3 + i];
				string text = string.Format("row{0}-", i);
				pageItemDict[text + "name"].text = claim.name;
				pageItemDict[text + "info"].text = claim.info;
				if (claim.claim.HasValue())
				{
					pageItemDict[text + "claimbox"].visible = true;
					pageItemDict[text + "claim"].text = claim.claim;
				}
			}
		}
		if (pageIndex == 22)
		{
			pageItemDict["claims_total"].text = Lang.Get("tally_total", "$amount", GetAmountStr(totalClaimed));
		}
		pageTemplate.EndRefresh();
	}

	private void FlipPage(int dir)
	{
		targetPageIndex = Mathf.Clamp(pageIndex + dir, 0, 22);
		if (targetPageIndex != pageIndex)
		{
			haveFlippedPage = true;
			stater.Go(State.Flipping);
		}
	}

	public void OnPageButtonClick(PageItem pageItem)
	{
		if (pageItem.buttonSettings.actionId == "go-next")
		{
			FlipPage(1);
		}
		else if (pageItem.buttonSettings.actionId == "go-prev")
		{
			FlipPage(-1);
		}
		else if (pageItem.buttonSettings.actionId == "sign")
		{
			stater.Go(State.Signing);
		}
	}

	public void MoveOffPage(int dir, PageItem sourcePageItem)
	{
	}

	private string BuildClaimStr(int amount)
	{
		string amountStr = GetAmountStr(amount);
		return "<size=10>" + Lang.Get("tally_claim") + "</size>\n" + amountStr;
	}

	private void BuildClaims()
	{
		claims = new List<Claim>();
		claims.Add(new Claim
		{
			name = Lang.Get("tally_ship"),
			info = Lang.Get("tally_ship_info", "$amount", GetAmountStr(20000)),
			claim = BuildClaimStr(20000)
		});
		claims.Add(new Claim
		{
			name = Lang.Get("tally_cargo_company"),
			info = Lang.Get("tally_cargo_company_info", "$amount", GetAmountStr(5000)),
			claim = BuildClaimStr(5000)
		});
		claims.Add(new Claim
		{
			name = Lang.Get("tally_cargo_crown"),
			info = Lang.Get("tally_cargo_crown_info", "$amount", GetAmountStr(3000)),
			claim = BuildClaimStr(3000)
		});
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (Manifest.Crew item in Manifest.it.IterateCrews())
		{
			SaveData.FaceDataRo faceDataRo = SaveData.it.faceRo[item.id];
			if (faceDataRo == null || !item.insuranceKilledIntentionally)
			{
				continue;
			}
			string text = Manifest.FateId_KillerId(faceDataRo.fateId);
			if (text != null)
			{
				if (!dictionary.ContainsKey(text))
				{
					dictionary.Add(text, 0);
				}
				dictionary[text]++;
			}
		}
		string text2 = Lang.Get("tally_join_major").Replace("_", " ");
		string text3 = Lang.Get("tally_join_minor").Replace("_", " ");
		if (Lang.loadedLanguage.isRTL)
		{
			text2 = "←" + text2;
			text3 = "←" + text3;
		}
		totalClaimed = 28000;
		foreach (Manifest.Ent item2 in Manifest.it.IterateEnts(true))
		{
			Manifest.Crew crew = item2.crew;
			if (crew == null)
			{
				continue;
			}
			Claim claim = new Claim();
			claim.name = item2.title.Get(crew.gender);
			List<string> list = new List<string>();
			SaveData.FaceData faceData = SaveData.it.FindFaceDataForNameId(crew.id);
			string text4 = ((faceData == null) ? "unknown" : faceData.fateId);
			list.Add(Lang.Get("tally_fate", "$summary", Manifest.it.GetFateSummary(text4, crew.id, crew.id)));
			int num = (dictionary.ContainsKey(crew.id) ? dictionary[crew.id] : 0);
			bool flag = text4.Contains("suicide");
			if (flag)
			{
				num++;
			}
			Manifest.Crew crew2 = ((faceData == null) ? null : Manifest.it.GetCrew(faceData.id));
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			if (num > 0)
			{
				list4.Add(Lang.Get("tally_crime_murder", "$count", num));
			}
			if (crew2 != null)
			{
				string[] tallies = crew2.tallies;
				foreach (string text5 in tallies)
				{
					if (text5.Contains("demerit"))
					{
						list2.Add(Lang.Get("tally_" + text5));
					}
					else if (text5.Contains("crime"))
					{
						list4.Add(Lang.Get("tally_" + text5));
					}
					else if (text5.Contains("merit"))
					{
						list3.Add(Lang.Get("tally_" + text5));
					}
				}
			}
			if (text4.Contains("alive") && !list2.Contains(Lang.Get("tally_demerit_abandon")))
			{
				list2.Add(Lang.Get("tally_demerit_abandon"));
			}
			if (list4.Count > 0)
			{
				list.Add(Lang.Get("tally_crime", "$findings", string.Join(text3, list4.ToArray())));
			}
			if (list2.Count > 0)
			{
				list.Add(Lang.Get("tally_demerit", "$findings", string.Join(text3, list2.ToArray())));
			}
			if (list3.Count > 0 && list4.Count == 0)
			{
				list.Add(Lang.Get("tally_merit", "$findings", string.Join(text3, list3.ToArray())));
			}
			int num2 = list4.Count + ((num > 1) ? (num - 1) : 0);
			int num3 = list2.Count * -10 + num2 * -25 + list3.Count * 10;
			if (list4.Count == 0 && crew2 != null)
			{
				num3 += crew.pay;
			}
			string empty = string.Empty;
			if (!flag || crew2 == null)
			{
				empty = ((num3 == 0 || crew2 == null) ? "tally_estate_none" : ((num3 < 0) ? ((!crew2.insuranceEstateKnown) ? "tally_estate_unknown_fined" : "tally_estate_fined") : ((list3.Count <= 0) ? ((!crew2.insuranceEstateKnown) ? "tally_estate_unknown_wages" : "tally_estate_wages") : ((!crew2.insuranceEstateKnown) ? "tally_estate_unknown_wages_reward" : "tally_estate_wages_reward"))));
			}
			else
			{
				num3 = 0;
				empty = "tally_estate_forfeit";
			}
			list.Add(Lang.Get(empty, "$amount", GetAmountStr(Mathf.Abs(num3))));
			claim.info = Manifest.ApplyGender(string.Join(text2, list.ToArray()), crew.gender, crew.gender);
			if (num3 > 0)
			{
				totalClaimed += num3;
				claim.claim = BuildClaimStr(num3);
			}
			claims.Add(claim);
		}
	}

	private static string GetAmountStr(int i)
	{
		string val = i.ToString("N0", enCultureInfo).Replace(",", Lang.Get("tally_amount_separator"));
		return Lang.Get("tally_amount", "$number", val);
	}
}
