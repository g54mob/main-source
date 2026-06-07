using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LeadDesignControl : ComplexListItem, ICursorOverride
{
	public RawImage Thumb;

	public Texture NoDesigner;

	public GUIProgressBar Creativity;

	public GUIProgressBar Inspiration;

	public GUIProgressBar SkillProg;

	public Text Name;

	public Text CreatvityRange1;

	public Text CreatvityRange2;

	public Text ActiveProjects;

	public Text RelevantDemand;

	public Text SkillLabel;

	public GameObject Portfolio;

	public GameObject CheckMark;

	public RectTransform SkillPanel;

	public Color CheckColor;

	public Color NotCheckColor;

	public Color GoodProg = new Color32(161, 219, 133, byte.MaxValue);

	public Color BadProg = new Color32(219, 65, 65, byte.MaxValue);

	public Image Back;

	public bool Checkable;

	public Action<bool, Employee> OnToggle;

	private float[] _lastCrea;

	private float _creaLerp = 1f;

	private float _lastCreateKnown;

	[NonSerialized]
	public Employee CurrentEmployee;

	[NonSerialized]
	private uint _updateCount;

	[NonSerialized]
	private string _spec;

	[NonSerialized]
	private Tweener _activeTween;

	public bool UseInspiration = true;

	public bool UsePortfolio = true;

	public bool UseActiveProjects = true;

	public bool UseRelevantDemands = true;

	public bool UseName = true;

	public bool UseThumb = true;

	public bool IsChecked
	{
		get
		{
			return Checkable & CheckMark.activeSelf;
		}
		set
		{
			CheckNoEvent(value);
			OnToggle(IsChecked, CurrentEmployee);
		}
	}

	public string CursorOverrideName
	{
		get
		{
			if (!Checkable)
			{
				return "Default";
			}
			return "Finger";
		}
	}

	public void CheckNoEvent(bool check)
	{
		bool flag = check && Checkable;
		CheckMark.SetActive(flag);
		Back.color = (flag ? CheckColor : NotCheckColor);
	}

	public void Toggle()
	{
		if (Checkable)
		{
			SelectClick();
		}
	}

	public void SetSpec(string spec)
	{
		_spec = spec;
	}

	public void ShowPortfolio()
	{
		ProductWindow productWindow = HUD.Instance.GetProductWindow("AllRelease");
		GUIWindow gUIWindow = CheckModal();
		productWindow.Show(true, "LeadPortfolio".Loc(CurrentEmployee.FullName), false, gUIWindow != null);
		productWindow.SetFilters(true, true);
		productWindow.SetContent(CurrentEmployee.LeadProjectsFix.SelectNotNull((uint x) => MarketSimulation.Active.GetProduct(x, true, true)));
		if (gUIWindow != null)
		{
			productWindow.Window.SetParentWindow(gUIWindow);
		}
	}

	public void HoverSkill()
	{
		if (_activeTween != null)
		{
			_activeTween.Kill();
		}
		if (SkillPanel.GetChild(0).gameObject.activeSelf)
		{
			SkillPanel.gameObject.SetActive(true);
			_activeTween = SkillPanel.DOSizeDelta(new Vector2(0f, SkillPanel.GetActiveChildCount() * 17 + 4), 0.5f, true).OnComplete(delegate
			{
				_activeTween = null;
			});
		}
	}

	public void UnHoverSkill()
	{
		if (_activeTween != null)
		{
			_activeTween.Kill();
		}
		if (SkillPanel.gameObject.activeSelf)
		{
			_activeTween = SkillPanel.DOSizeDelta(new Vector2(0f, 0f), 0.5f, true).OnComplete(delegate
			{
				SkillPanel.gameObject.SetActive(false);
				_activeTween = null;
			});
		}
	}

	private void SetCreaAlignment(bool left)
	{
		if (left)
		{
			CreatvityRange1.alignment = TextAnchor.MiddleRight;
			CreatvityRange1.rectTransform.pivot = new Vector2(1f, 1f);
			CreatvityRange1.rectTransform.anchorMax = new Vector2(0f, 1f);
			CreatvityRange1.rectTransform.anchorMin = new Vector2(0f, 0f);
		}
		else
		{
			CreatvityRange1.alignment = TextAnchor.MiddleCenter;
			CreatvityRange1.rectTransform.pivot = new Vector2(0.5f, 1f);
			CreatvityRange1.rectTransform.anchorMax = new Vector2(0.5f, 1f);
			CreatvityRange1.rectTransform.anchorMin = new Vector2(0.5f, 0f);
		}
	}

	private void SetPos(RectTransform t, float p, bool rev)
	{
		if (p < 0.17f)
		{
			if (rev)
			{
				t.anchorMax = new Vector2(1f, 1f);
				t.anchorMin = new Vector2(1f, 0f);
				t.anchoredPosition = new Vector2(0f - t.rect.width - 2f, 0f);
			}
			else
			{
				t.anchorMax = new Vector2(0f, 1f);
				t.anchorMin = new Vector2(0f, 0f);
				t.anchoredPosition = new Vector2(t.rect.width, 0f);
			}
		}
		else
		{
			if (rev)
			{
				p = 1f - p;
			}
			t.anchorMax = new Vector2(p, 1f);
			t.anchorMin = new Vector2(p, 0f);
			t.anchoredPosition = new Vector2(0f, 0f);
		}
	}

	private void SetCreaProg(float low, float high)
	{
		if (Mathf.RoundToInt(high * 100f) == Mathf.RoundToInt(low * 100f))
		{
			CreatvityRange1.text = high.ToPercent(false) + " - " + SoftwareType.GetCreativityLabel(high, false);
			SetCreaAlignment(false);
			CreatvityRange1.rectTransform.anchoredPosition = new Vector2(0f, 0f);
			CreatvityRange2.gameObject.SetActive(false);
			Creativity.StartColor = Color.Lerp(BadProg, GoodProg, high);
			Creativity.LerpFull = false;
			Creativity.OnlyUseStart = true;
			Creativity.LowValue = null;
			Creativity.Value = 1f;
		}
		else
		{
			CreatvityRange1.text = low.ToPercent(false);
			CreatvityRange2.gameObject.SetActive(true);
			CreatvityRange2.text = high.ToPercent(false);
			SetCreaAlignment(true);
			SetPos(CreatvityRange1.rectTransform, low, false);
			SetPos(CreatvityRange2.rectTransform, 1f - high, true);
			Creativity.StartColor = BadProg;
			Creativity.EndColor = GoodProg;
			Creativity.LerpFull = true;
			Creativity.OnlyUseStart = false;
			Creativity.LowValue = low;
			Creativity.Value = high;
		}
		Creativity.SetDirty();
	}

	public void InitCrea()
	{
		float[] creativityRange = CurrentEmployee.GetCreativityRange();
		if (CurrentEmployee.LastCreatity != null && (!Mathf.Approximately(CurrentEmployee.LastCreatity[0], creativityRange[0]) || !Mathf.Approximately(CurrentEmployee.LastCreatity[1], creativityRange[1])))
		{
			SetCreaProg(CurrentEmployee.LastCreatity[0], CurrentEmployee.LastCreatity[1]);
			_lastCrea = CurrentEmployee.LastCreatity;
			_creaLerp = 0f;
		}
		else
		{
			SetCreaProg(creativityRange[0], creativityRange[1]);
			_lastCrea = null;
			_creaLerp = 1f;
		}
		CurrentEmployee.LastCreatity = creativityRange;
		_lastCreateKnown = CurrentEmployee.CreativityKnown;
	}

	public void ControlThumbnail(bool none)
	{
		if (none || CurrentEmployee == null)
		{
			Thumb.texture = NoDesigner;
			Thumb.uvRect = new Rect(0f, 0f, 1f, 1f);
		}
		else if (Thumb.texture == null || Thumb.texture == NoDesigner)
		{
			if (CurrentEmployee.MyActor != null)
			{
				KeyValuePair<Texture2D, Rect> keyValuePair = CurrentEmployee.MyActor.Snapshot();
				Thumb.texture = keyValuePair.Key;
				Thumb.uvRect = keyValuePair.Value;
				return;
			}
			ActorGenerator.SetStyleAge(CurrentEmployee.StyleGen, CurrentEmployee.GetAge());
			KeyValuePair<PortraitMaker.PortraitAtlas, Vector2Int> actorTex = HUD.Instance.Portraits.GetActorTex(CurrentEmployee);
			float num = 1f / (float)PortraitMaker.PortraitPerAtlas;
			Rect uvRect = new Rect((float)actorTex.Value.x * num, (float)actorTex.Value.y * num, num, num);
			Thumb.texture = actorTex.Key.Tex;
			Thumb.uvRect = uvRect;
		}
	}

	public void Init(Employee emp, string spec = null)
	{
		_spec = ((spec == "Distribution platform") ? null : spec);
		if (CurrentEmployee == emp && CurrentEmployee != null)
		{
			_updateCount = CurrentEmployee._leadUpdateCount + 1;
			return;
		}
		CurrentEmployee = emp;
		if (emp == null)
		{
			base.enabled = false;
			if (UseThumb)
			{
				Thumb.texture = NoDesigner;
				Thumb.uvRect = new Rect(0f, 0f, 1f, 1f);
			}
			SetCreaProg(0f, 1f);
			CreatvityRange1.text = "NotApplicableAbbr".Loc();
			SetCreaAlignment(false);
			CreatvityRange1.rectTransform.anchoredPosition = new Vector2(0f, 0f);
			CreatvityRange2.gameObject.SetActive(false);
			SkillProg.Value = 0f;
			SkillLabel.text = "NotApplicableAbbr".Loc();
			InitSpecs(null);
			if (UseInspiration)
			{
				Inspiration.Value = 0f;
				Inspiration.IndValue = null;
			}
			if (UsePortfolio)
			{
				Portfolio.SetActive(false);
			}
			if (UseActiveProjects)
			{
				ActiveProjects.gameObject.SetActive(false);
			}
			if (UseRelevantDemands)
			{
				RelevantDemand.gameObject.SetActive(false);
			}
			if (UseName)
			{
				Name.text = "None".Loc();
			}
			return;
		}
		base.enabled = true;
		if (UseName)
		{
			Name.text = emp.FullName;
		}
		InitCrea();
		if (UseActiveProjects)
		{
			int activeProjects = GetActiveProjects();
			ActiveProjects.gameObject.SetActive(activeProjects > 0);
			if (activeProjects > 0)
			{
				ActiveProjects.text = "ActiveProjects".Loc() + ": " + activeProjects;
			}
		}
		if (UseInspiration)
		{
			Inspiration.IndColor = new Color32(50, 50, 50, byte.MaxValue);
			Inspiration.Value = emp.GetActualInspiration() - 1f;
			Inspiration.IndValue = 0.5f;
		}
		if (UseThumb)
		{
			if (emp.MyActor != null)
			{
				KeyValuePair<Texture2D, Rect> keyValuePair = emp.MyActor.Snapshot();
				Thumb.texture = keyValuePair.Key;
				Thumb.uvRect = keyValuePair.Value;
			}
			else
			{
				ActorGenerator.SetStyleAge(emp.StyleGen, emp.GetAge());
				KeyValuePair<PortraitMaker.PortraitAtlas, Vector2Int> actorTex = HUD.Instance.Portraits.GetActorTex(emp);
				float num = 1f / (float)PortraitMaker.PortraitPerAtlas;
				Rect uvRect = new Rect((float)actorTex.Value.x * num, (float)actorTex.Value.y * num, num, num);
				Thumb.texture = actorTex.Key.Tex;
				Thumb.uvRect = uvRect;
			}
		}
		if (UsePortfolio)
		{
			Portfolio.SetActive(CurrentEmployee.LeadProjectsFix.Count > 0);
		}
		if (UseRelevantDemands)
		{
			if (CurrentEmployee.HasDemanded(LeadDesignDemands.Demand.IPOwnership))
			{
				RelevantDemand.text = "LeadDemandIPOwnership".Loc();
				RelevantDemand.GetComponent<GUIToolTipper>().TooltipDescription = "LeadDemandIPOwnershipTip";
				RelevantDemand.gameObject.SetActive(true);
			}
			else if (CurrentEmployee.HasDemanded(LeadDesignDemands.Demand.Royalties))
			{
				RelevantDemand.text = "LeadDemandRoyalties".Loc();
				RelevantDemand.GetComponent<GUIToolTipper>().TooltipDescription = "LeadDemandRoyaltiesTip";
				RelevantDemand.gameObject.SetActive(true);
			}
			else
			{
				RelevantDemand.gameObject.SetActive(false);
			}
		}
		RefreshSpec();
	}

	public void RefreshSpec()
	{
		string text = _spec;
		if (text == null && CurrentEmployee.LeadSpecializationFix.Count > 0)
		{
			text = CurrentEmployee.LeadSpecializationFix.MaxInstance((KeyValuePair<string, float> x) => x.Value).Key;
		}
		SoftwareType value;
		if (text != null && MarketSimulation.Active.SoftwareTypes.TryGetValue(text, out value))
		{
			SkillProg.Value = CurrentEmployee.LeadSpecializationFix.GetOrDefault(text, 0f);
			SkillLabel.text = value.GetActualString();
		}
		else
		{
			SkillProg.Value = 0f;
			SkillLabel.text = "NotApplicableAbbr".Loc();
		}
		InitSpecs(text);
		_updateCount = CurrentEmployee._leadUpdateCount;
	}

	private void Update()
	{
		if (_lastCrea != null && _creaLerp < 1f)
		{
			_creaLerp = Mathf.Min(1f, _creaLerp + Time.deltaTime);
			float t = Mathf.Sqrt(_creaLerp);
			float[] creativityRange = CurrentEmployee.GetCreativityRange();
			SetCreaProg(Mathf.Lerp(_lastCrea[0], creativityRange[0], t), Mathf.Lerp(_lastCrea[1], creativityRange[1], t));
		}
		if (_lastCreateKnown != CurrentEmployee.CreativityKnown)
		{
			InitCrea();
		}
		if (UseInspiration)
		{
			Inspiration.Value = CurrentEmployee.GetActualInspiration() - 1f;
		}
		if (CurrentEmployee != null && _updateCount != CurrentEmployee._leadUpdateCount)
		{
			RefreshSpec();
		}
		if (UseActiveProjects)
		{
			int activeProjects = GetActiveProjects();
			ActiveProjects.gameObject.SetActive(activeProjects > 0);
			if (activeProjects > 0)
			{
				ActiveProjects.text = "ActiveProjects".Loc() + ": " + activeProjects;
			}
		}
	}

	private void InitSpecs(string ignore)
	{
		int num = 0;
		if (CurrentEmployee != null)
		{
			foreach (KeyValuePair<string, float> item in CurrentEmployee.LeadSpecializationFix.OrderByDescending((KeyValuePair<string, float> x) => x.Value))
			{
				if (!(item.Key == ignore))
				{
					Transform transform;
					if (num < SkillPanel.childCount)
					{
						transform = SkillPanel.GetChild(num);
					}
					else
					{
						transform = SkillPanel.GetChild(0);
						transform = UnityEngine.Object.Instantiate(transform);
						transform.SetParent(SkillPanel, false);
					}
					transform.GetComponent<GUIProgressBar>().Value = item.Value;
					transform.GetComponentInChildren<Text>().text = MarketSimulation.Active.SoftwareTypes[item.Key].GetActualString();
					transform.gameObject.SetActive(true);
					num++;
				}
			}
		}
		for (int num2 = num; num2 < SkillPanel.childCount; num2++)
		{
			SkillPanel.GetChild(num2).gameObject.SetActive(false);
		}
	}

	private GUIWindow CheckModal()
	{
		Transform parent = base.transform.parent;
		while (parent != null)
		{
			GUIWindow component = parent.GetComponent<GUIWindow>();
			if (component != null)
			{
				if (!component.Modal)
				{
					return null;
				}
				return component;
			}
			parent = parent.parent;
		}
		return null;
	}

	public int GetActiveProjects()
	{
		if (CurrentEmployee == null || CurrentEmployee.MyActor == null)
		{
			return 0;
		}
		return CurrentEmployee.GetActiveLeadProjects();
	}

	protected override void InitializeContent(object item)
	{
		Init((Employee)item, _spec);
	}

	public override void SetSelectedUI(bool toggle)
	{
		CheckNoEvent(toggle);
	}

	public override float GetHeight(object content, float width)
	{
		return 94.62f;
	}
}
