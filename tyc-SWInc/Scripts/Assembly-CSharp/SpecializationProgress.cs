using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpecializationProgress : MonoBehaviour
{
	public GameObject InnerPanel;

	public Dictionary<string, GUIProgressBar[]> Bars = new Dictionary<string, GUIProgressBar[]>();

	public static SpecializationProgress Instance;

	public GameObject ProgressbarPrefab;

	public GameObject DetailButton;

	public RectTransform WorkPanel;

	public RectTransform SubPanel;

	private GUIWorkItem WorkItem;

	[NonSerialized]
	public SoftwareWorkItem Item;

	[NonSerialized]
	public MarketingPlan MItem;

	private RectTransform rect;

	private bool hide;

	private bool _selfCheck;

	private void Start()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		rect = GetComponent<RectTransform>();
		base.gameObject.SetActive(false);
	}

	public void Show(GUIWorkItem workItem)
	{
		_selfCheck = false;
		WorkItem = workItem;
		foreach (KeyValuePair<string, GUIProgressBar[]> bar in Bars)
		{
			UnityEngine.Object.Destroy(bar.Value[0].transform.parent.parent.gameObject);
		}
		Bars.Clear();
		Item = null;
		MItem = null;
		DetailButton.SetActive(false);
		MarketingPlan mItem;
		if (WorkItem.work is SoftwareWorkItem)
		{
			DetailButton.SetActive(true);
			Item = (SoftwareWorkItem)workItem.work;
			IEnumerable<IGrouping<string, SoftwareWorkItem.FeatureProgress>> enumerable = from x in Item.Features
				group x by (!x.OS) ? x.Feature.Spec : "OS support";
			int num = enumerable.Count();
			bool flag = true;
			int num2 = 0;
			if (Item is DesignDocument)
			{
				DesignDocument designDocument = Item as DesignDocument;
				if (designDocument.NeedsLead() || designDocument.LeadDesigner != null)
				{
					flag = false;
					num++;
					num2++;
					GameObject obj = UnityEngine.Object.Instantiate(ProgressbarPrefab);
					GUIProgressBar[] componentsInChildren = obj.GetComponentsInChildren<GUIProgressBar>();
					obj.GetComponentInChildren<Text>().text = ((!designDocument.NeedsLead()) ? designDocument.LeadDesigner.FullName : "Creativity".LocTry());
					obj.transform.SetParent(InnerPanel.transform, false);
					Bars["Creativity"] = componentsInChildren;
					componentsInChildren[0].EndColor = (componentsInChildren[0].StartColor = (componentsInChildren[0].EndExt = SpecializationChart.GetSkillColor(Employee.EmployeeRole.Designer)));
					componentsInChildren[1].gameObject.SetActive(false);
					componentsInChildren[0].MySprite = ObjectDatabase.Instance.GetSprite(true, num == 1, num == 1, true);
				}
			}
			foreach (IGrouping<string, SoftwareWorkItem.FeatureProgress> item in enumerable)
			{
				num2++;
				bool flag2 = flag;
				bool bottomLeft = num2 == num;
				bool bottomRight = num2 == num;
				float num3 = item.Average((SoftwareWorkItem.FeatureProgress x) => x.Feature.CodeArtRatio);
				GameObject obj2 = UnityEngine.Object.Instantiate(ProgressbarPrefab);
				GUIProgressBar[] componentsInChildren2 = obj2.GetComponentsInChildren<GUIProgressBar>();
				obj2.GetComponentInChildren<Text>().text = item.Key.LocTry();
				obj2.transform.SetParent(InnerPanel.transform, false);
				Bars[item.Key] = componentsInChildren2;
				if (Item is DesignDocument)
				{
					componentsInChildren2[0].EndColor = (componentsInChildren2[0].StartColor = (componentsInChildren2[0].EndExt = SpecializationChart.GetSkillColor(Employee.EmployeeRole.Designer)));
					componentsInChildren2[1].gameObject.SetActive(false);
					componentsInChildren2[0].MySprite = ObjectDatabase.Instance.GetSprite(flag2, bottomRight, bottomLeft, flag2);
				}
				else
				{
					int num4 = -1;
					if (num3 == 1f)
					{
						num4 = 0;
						componentsInChildren2[1].gameObject.SetActive(false);
					}
					else
					{
						componentsInChildren2[1].EndColor = (componentsInChildren2[0].StartColor = (componentsInChildren2[1].EndExt = SpecializationChart.GetSkillColor(Employee.EmployeeRole.Artist)));
					}
					if (num3 == 0f)
					{
						num4 = 1;
						componentsInChildren2[0].gameObject.SetActive(false);
					}
					else
					{
						componentsInChildren2[0].EndColor = (componentsInChildren2[0].StartColor = (componentsInChildren2[0].EndExt = SpecializationChart.GetSkillColor(Employee.EmployeeRole.Programmer)));
					}
					if (num4 == -1)
					{
						componentsInChildren2[0].MySprite = ObjectDatabase.Instance.GetSprite(false, false, bottomLeft, flag2);
						componentsInChildren2[1].MySprite = ObjectDatabase.Instance.GetSprite(flag2, bottomRight, false, false);
					}
					else
					{
						componentsInChildren2[num4].MySprite = ObjectDatabase.Instance.GetSprite(flag2, bottomRight, bottomLeft, flag2);
					}
				}
				flag = false;
			}
			DetailButton.transform.SetAsLastSibling();
		}
		else if ((mItem = workItem.work as MarketingPlan) != null)
		{
			MItem = mItem;
			int num5 = 0;
			for (int num6 = 0; num6 < 3; num6++)
			{
				int num7 = 1 << num6;
				if ((int)((uint)MItem.PressOptions & (uint)num7) > 0)
				{
					GameObject obj3 = UnityEngine.Object.Instantiate(ProgressbarPrefab);
					GUIProgressBar[] componentsInChildren3 = obj3.GetComponentsInChildren<GUIProgressBar>();
					obj3.GetComponentInChildren<Text>().text = MarketingWindow.PressOptionNames[num6].Loc();
					obj3.transform.SetParent(InnerPanel.transform, false);
					Bars[num6.ToString()] = componentsInChildren3;
					componentsInChildren3[0].EndColor = (componentsInChildren3[0].StartColor = (componentsInChildren3[0].EndExt = SpecializationChart.GetSkillColor(Employee.EmployeeRole.Service)));
					componentsInChildren3[1].gameObject.SetActive(false);
					bool flag3 = num5 == MItem.Progress.Length - 1;
					componentsInChildren3[0].MySprite = ObjectDatabase.Instance.GetSprite(num6 == 0, flag3, flag3, num6 == 0);
					num5++;
				}
			}
		}
		base.gameObject.SetActive(true);
		hide = false;
		rect.sizeDelta = new Vector2(0f, rect.sizeDelta.y);
	}

	public bool CheckSelf()
	{
		if (base.gameObject.activeSelf && RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition, UICamSize.GetUICam()))
		{
			_selfCheck = true;
			return true;
		}
		return false;
	}

	public void Hide()
	{
		hide = true;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Update()
	{
		if (hide)
		{
			rect.sizeDelta = new Vector2(Mathf.Lerp(rect.sizeDelta.x, 0f, Time.deltaTime * 20f), rect.sizeDelta.y);
			if (rect.sizeDelta.x < 0.1f)
			{
				base.gameObject.SetActive(false);
			}
			return;
		}
		float num = Mathf.Round(Mathf.Lerp(rect.sizeDelta.x, 128f, Time.deltaTime * 20f));
		rect.sizeDelta = new Vector2((128f - num < 4f) ? 128f : num, rect.sizeDelta.y);
		if (WorkItem == null || WorkItem.gameObject == null || !WorkItem.gameObject.activeSelf)
		{
			Hide();
			return;
		}
		if (_selfCheck && !RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition, UICamSize.GetUICam()))
		{
			Hide();
			return;
		}
		RectTransform component = WorkItem.GetComponent<RectTransform>();
		rect.anchoredPosition = new Vector2(0f - WorkPanel.rect.width - 1f, Mathf.Clamp(component.anchoredPosition.y - 96f + SubPanel.anchoredPosition.y, 0f - WorkPanel.rect.height - WorkPanel.anchoredPosition.y + 74f, -96f));
		if (Item != null)
		{
			DesignDocument designDocument = Item as DesignDocument;
			if (designDocument != null && (designDocument.NeedsLead() || designDocument.LeadDesigner != null))
			{
				GUIProgressBar[] orNull = Bars.GetOrNull("Creativity");
				if (orNull != null)
				{
					orNull[0].Value = designDocument.LeadProgress;
				}
			}
			{
				foreach (IGrouping<string, SoftwareWorkItem.FeatureProgress> item in from x in Item.Features
					group x by (!x.OS) ? x.Feature.Spec : "OS support")
				{
					GUIProgressBar[] orNull2 = Bars.GetOrNull(item.Key);
					if (orNull2 != null)
					{
						if (designDocument != null)
						{
							orNull2[0].Value = GetAverage(item, false, false, false, designDocument.Iteration);
							continue;
						}
						orNull2[0].Value = GetAverage(item, false, true, false);
						orNull2[1].Value = GetAverage(item, true, false, false);
					}
				}
				return;
			}
		}
		if (MItem == null)
		{
			return;
		}
		int num2 = 0;
		foreach (GUIProgressBar[] value in Bars.Values)
		{
			value[0].Value = MItem.Progress[num2];
			num2++;
		}
	}

	public void ShowDetails()
	{
		HUD.Instance.workerDetailWindow.Show(Item);
	}

	private float GetAverage(IEnumerable<SoftwareWorkItem.FeatureProgress> progs, bool art, bool code, bool qual, int it = 0)
	{
		double num = 0.0;
		double num2 = 0.0;
		foreach (SoftwareWorkItem.FeatureProgress prog in progs)
		{
			if (qual)
			{
				if (art)
				{
					if (prog.ADevTime > 0.0)
					{
						num += prog.Qual2;
						num2 += 1.0;
					}
				}
				else if (prog.CDevTime > 0.0)
				{
					num += prog.Qual;
					num2 += 1.0;
				}
			}
			else
			{
				double num3 = (art ? prog.ArtProgress : prog.Progress);
				double num4 = (art ? prog.ADevTime : (code ? prog.CDevTime : prog.DevTime));
				if (num4 > 0.0)
				{
					num += num3;
					num2 += num4;
				}
			}
		}
		return (float)(((num2 > 0.0) ? (num / num2) : 0.0) - (double)it);
	}
}
