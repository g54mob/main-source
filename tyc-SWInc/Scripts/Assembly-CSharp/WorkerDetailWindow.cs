using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WorkerDetailWindow : MonoBehaviour
{
	public class SpecDetail
	{
		public double CodeProg;

		public double ArtProg;

		public double CodeSum;

		public double ArtSum;

		public float Ratio;

		public bool CodeDone;

		public bool ArtDone;

		public SpecDetail(float codeProg, float artProg, float codeSum, float artSum)
		{
			CodeProg = codeProg;
			ArtProg = artProg;
			CodeSum = codeSum;
			ArtSum = artSum;
		}

		public SpecDetail(SoftwareWorkItem.FeatureProgress p, bool design)
		{
			CodeProg = p.Progress;
			ArtProg = p.ArtProgress;
			CodeSum = (design ? p.DevTime : p.CDevTime);
			ArtSum = p.ADevTime;
			CodeDone = p.CodeDone;
			ArtDone = p.ArtDone;
		}

		public void CalculateRatio()
		{
			Ratio = (float)(CodeSum / (CodeSum + ArtSum));
		}

		public void ResetProgress()
		{
			CodeProg = 0.0;
			ArtProg = 0.0;
			ArtDone = true;
			CodeDone = true;
		}
	}

	public GUIWindow Window;

	public WorkerDetailPanel PanelPrefab;

	public RectTransform ContentTransform;

	public FlexibleColumnLayout ContentPanel;

	public DevelopmentSpecChart DSpecChart;

	public Text UnqualifiedLabel;

	public Toggle GroupBySpec;

	[NonSerialized]
	private SoftwareWorkItem _work;

	[NonSerialized]
	private Dictionary<SoftwareWorkItem.FeatureProgress, WorkerDetailPanel> _panels = new Dictionary<SoftwareWorkItem.FeatureProgress, WorkerDetailPanel>();

	[NonSerialized]
	private Dictionary<ValueTuple<string, int>, ValueTuple<WorkerDetailPanel, SpecDetail>> _specPanels = new Dictionary<ValueTuple<string, int>, ValueTuple<WorkerDetailPanel, SpecDetail>>();

	[NonSerialized]
	private HashSet<Employee> _wasWorking = new HashSet<Employee>();

	[NonSerialized]
	private HashSet<Employee> _wasWorking2 = new HashSet<Employee>();

	private float _specRefresh = 1f;

	public void Show(SoftwareWorkItem item)
	{
		Window.NonLocTitle = "ProductDetailTitle".Loc(item.GetTitle());
		_work = item;
		Window.Show();
		_panels.Values.ForEachEnum(delegate(WorkerDetailPanel x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		_panels.Clear();
		_specPanels.Values.ForEachEnum(delegate(ValueTuple<WorkerDetailPanel, SpecDetail> x)
		{
			UnityEngine.Object.Destroy(x.Item1.gameObject);
		});
		_specPanels.Clear();
		_wasWorking.Clear();
		_wasWorking2.Clear();
		RefreshReq();
		_specRefresh = 1f;
		OnSizeChange();
	}

	public void ToggleSpecGroup()
	{
		_panels.Values.ForEachEnum(delegate(WorkerDetailPanel x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		_panels.Clear();
		_specPanels.Values.ForEachEnum(delegate(ValueTuple<WorkerDetailPanel, SpecDetail> x)
		{
			UnityEngine.Object.Destroy(x.Item1.gameObject);
		});
		_specPanels.Clear();
	}

	public void OnSizeChange()
	{
		float width = Window.rectTransform.rect.width;
		ContentPanel.Columns = Mathf.Max(1, Mathf.FloorToInt(width / ContentPanel.ColumnWidth));
		ContentPanel.SetLayoutHorizontal();
	}

	private IEnumerator UpdateTransform()
	{
		yield return new WaitForEndOfFrame();
		LayoutRebuilder.MarkLayoutForRebuild(ContentTransform);
	}

	private bool ValidRole(Actor a, SoftwareWorkItem w)
	{
		SoftwareAlpha softwareAlpha;
		if ((softwareAlpha = w as SoftwareAlpha) != null)
		{
			if (softwareAlpha.HasFinishedCode || !a.employee.IsRole(Employee.EmployeeRole.Programmer, a.SecondaryWork))
			{
				if (!softwareAlpha.HasFinishedArt)
				{
					return a.employee.IsRole(Employee.EmployeeRole.Artist, a.SecondaryWork);
				}
				return false;
			}
			return true;
		}
		SoftwareUpdate softwareUpdate;
		if ((softwareUpdate = w as SoftwareUpdate) != null)
		{
			if (softwareUpdate.HasFinishedCode || !a.employee.IsRole(Employee.EmployeeRole.Programmer, a.SecondaryWork))
			{
				if (!softwareUpdate.HasFinishedArt)
				{
					return a.employee.IsRole(Employee.EmployeeRole.Artist, a.SecondaryWork);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private void RefreshReq()
	{
		List<Team> list = _work.DevTeams.SelectNotNull(GameSettings.GetTeam).ToList();
		DSpecChart.Refresh(_work.Features, list, _work is DesignDocument);
		int num = 0;
		int num2 = 0;
		bool flag = _work is DesignDocument;
		for (int i = 0; i < list.Count; i++)
		{
			List<Actor> employeesDirect = list[i].GetEmployeesDirect();
			for (int j = 0; j < employeesDirect.Count; j++)
			{
				Actor actor = employeesDirect[j];
				if ((flag && !actor.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead) && actor.employee.IsRole(Employee.EmployeeRole.Designer, actor.SecondaryWork)) || (!flag && ValidRole(actor, _work)))
				{
					if (_work.HasWork(actor, actor.SecondaryWork, false) == WorkItem.HasWorkReturn.NotApplicable)
					{
						num++;
					}
					num2++;
				}
			}
		}
		UnqualifiedLabel.text = "UnqualifiedEmployees".Loc(num, num2);
	}

	private void UpdateSpecProg()
	{
		foreach (KeyValuePair<ValueTuple<string, int>, ValueTuple<WorkerDetailPanel, SpecDetail>> specPanel in _specPanels)
		{
			WorkerDetailPanel item = specPanel.Value.Item1;
			if (_work is SoftwareAlpha || _work is SoftwareUpdate)
			{
				item.SetProgress((float)(specPanel.Value.Item2.CodeProg / specPanel.Value.Item2.CodeSum), (float)(specPanel.Value.Item2.ArtProg / specPanel.Value.Item2.ArtSum), specPanel.Value.Item2.Ratio);
			}
			else
			{
				item.SetProgress((float)(specPanel.Value.Item2.CodeProg / specPanel.Value.Item2.CodeSum) % 1.0001f);
			}
		}
	}

	private void Update()
	{
		SoftwareAlpha softwareAlpha;
		if (_work == null || _work.Done || ((softwareAlpha = _work as SoftwareAlpha) != null && softwareAlpha.InBeta))
		{
			Window.Close();
			return;
		}
		_specRefresh -= Time.deltaTime;
		if (_specRefresh < 0f)
		{
			RefreshReq();
			_specRefresh = 1f;
		}
		bool flag = false;
		if (GroupBySpec.isOn)
		{
			bool flag2 = _work is DesignDocument;
			if (_specPanels.Count == 0)
			{
				foreach (SoftwareWorkItem.FeatureProgress item in from x in _work.Features
					orderby x.Feature.Spec, x.Feature.Level
					select x)
				{
					ValueTuple<string, int> key = new ValueTuple<string, int>(item.Feature.Spec, item.Feature.Level);
					ValueTuple<WorkerDetailPanel, SpecDetail> value;
					if (_specPanels.TryGetValue(key, out value))
					{
						value.Item2.CodeProg += item.Progress;
						value.Item2.ArtProg += item.ArtProgress;
						value.Item2.CodeSum += (flag2 ? item.DevTime : item.CDevTime);
						value.Item2.ArtSum += item.ADevTime;
						continue;
					}
					WorkerDetailPanel workerDetailPanel = UnityEngine.Object.Instantiate(PanelPrefab);
					workerDetailPanel.Header.text = item.Feature.Spec.LocTry();
					for (int num = 0; num < 3; num++)
					{
						workerDetailPanel.Stars[num].SetActive(num < item.Feature.Level);
					}
					workerDetailPanel.transform.SetParent(ContentTransform, false);
					_specPanels[key] = new ValueTuple<WorkerDetailPanel, SpecDetail>(workerDetailPanel, new SpecDetail(item, flag2));
					flag = true;
				}
				_specPanels.Values.ForEachEnum(delegate(ValueTuple<WorkerDetailPanel, SpecDetail> x)
				{
					x.Item2.CalculateRatio();
				});
				UpdateSpecProg();
			}
			else
			{
				_specPanels.Values.ForEachEnum(delegate(ValueTuple<WorkerDetailPanel, SpecDetail> x)
				{
					x.Item2.ResetProgress();
				});
				for (int num2 = 0; num2 < _work.Features.Length; num2++)
				{
					SoftwareWorkItem.FeatureProgress featureProgress = _work.Features[num2];
					ValueTuple<string, int> key2 = new ValueTuple<string, int>(featureProgress.Feature.Spec, featureProgress.Feature.Level);
					ValueTuple<WorkerDetailPanel, SpecDetail> value2;
					if (_specPanels.TryGetValue(key2, out value2))
					{
						value2.Item2.CodeProg += featureProgress.Progress;
						value2.Item2.ArtProg += featureProgress.ArtProgress;
						value2.Item2.CodeDone &= featureProgress.CodeDone;
						value2.Item2.ArtDone &= featureProgress.ArtDone;
					}
				}
				UpdateSpecProg();
			}
			_wasWorking2.Clear();
			DesignDocument designDocument;
			if ((designDocument = _work as DesignDocument) != null)
			{
				int iteration = designDocument.Iteration;
			}
			foreach (KeyValuePair<Employee, SoftwareWorkItem.FeatureProgress> item2 in _work.NewWorking)
			{
				_wasWorking.Remove(item2.Key);
				_wasWorking2.Add(item2.Key);
				if (item2.Value == null || _work.NewWorking.Count < _work.Features.Length)
				{
					foreach (KeyValuePair<ValueTuple<string, int>, ValueTuple<WorkerDetailPanel, SpecDetail>> specPanel in _specPanels)
					{
						flag = ((!(item2.Key.MyActor != null) || !item2.Key.CanWorkOnFeature(specPanel.Key.Item1, specPanel.Key.Item2, specPanel.Value.Item2.CodeDone, specPanel.Value.Item2.ArtDone, specPanel.Value.Item2.Ratio, item2.Key.MyActor.SecondaryWork, _work is DesignDocument)) ? (flag | specPanel.Value.Item1.RemoveWorker(item2.Key.MyActor)) : (flag | specPanel.Value.Item1.AddWorker(item2.Key.MyActor)));
					}
					continue;
				}
				ValueTuple<WorkerDetailPanel, SpecDetail> value3;
				WorkerDetailPanel workerDetailPanel2;
				if (_specPanels.TryGetValue(new ValueTuple<string, int>(item2.Value.Feature.Spec, item2.Value.Feature.Level), out value3))
				{
					workerDetailPanel2 = value3.Item1;
					flag |= workerDetailPanel2.AddWorker(item2.Key.MyActor);
				}
				else
				{
					workerDetailPanel2 = null;
				}
				foreach (var value6 in _specPanels.Values)
				{
					if (workerDetailPanel2 != value6.Item1)
					{
						flag |= value6.Item1.RemoveWorker(item2.Key.MyActor);
					}
				}
			}
			foreach (Employee item3 in _wasWorking)
			{
				foreach (var value7 in _specPanels.Values)
				{
					flag |= value7.Item1.RemoveWorker(item3.MyActor);
				}
			}
		}
		else
		{
			for (int num3 = 0; num3 < _work.Features.Length; num3++)
			{
				SoftwareWorkItem.FeatureProgress featureProgress2 = _work.Features[num3];
				WorkerDetailPanel value4;
				if (!_panels.TryGetValue(featureProgress2, out value4))
				{
					value4 = UnityEngine.Object.Instantiate(PanelPrefab);
					value4.Header.text = featureProgress2.Feature.GetLocalizedName();
					value4.Tipper.ToolTipValue = featureProgress2.Feature.Spec;
					for (int num4 = 0; num4 < 3; num4++)
					{
						value4.Stars[num4].SetActive(num4 < featureProgress2.Feature.Level);
					}
					value4.transform.SetParent(ContentTransform, false);
					_panels[featureProgress2] = value4;
					flag = true;
				}
				if (_work is SoftwareAlpha || _work is SoftwareUpdate)
				{
					value4.SetProgress((float)(featureProgress2.Progress / featureProgress2.CDevTime), (float)(featureProgress2.ArtProgress / featureProgress2.ADevTime), featureProgress2.Feature.CodeArtRatio);
				}
				else
				{
					value4.SetProgress((float)featureProgress2.GetOverallProgress() % 1.0001f);
				}
			}
			_wasWorking2.Clear();
			foreach (KeyValuePair<Employee, SoftwareWorkItem.FeatureProgress> item4 in _work.NewWorking)
			{
				_wasWorking.Remove(item4.Key);
				_wasWorking2.Add(item4.Key);
				if (item4.Value == null || _work.NewWorking.Count < _work.Features.Length)
				{
					foreach (KeyValuePair<SoftwareWorkItem.FeatureProgress, WorkerDetailPanel> panel in _panels)
					{
						flag = ((!(item4.Key.MyActor != null) || !item4.Key.CanWorkOnFeature(panel.Key, item4.Key.MyActor.SecondaryWork, _work is DesignDocument)) ? (flag | panel.Value.RemoveWorker(item4.Key.MyActor)) : (flag | panel.Value.AddWorker(item4.Key.MyActor)));
					}
					continue;
				}
				WorkerDetailPanel value5;
				if (_panels.TryGetValue(item4.Value, out value5))
				{
					flag |= value5.AddWorker(item4.Key.MyActor);
				}
				else
				{
					value5 = null;
				}
				foreach (WorkerDetailPanel value8 in _panels.Values)
				{
					if (value5 != value8)
					{
						flag |= value8.RemoveWorker(item4.Key.MyActor);
					}
				}
			}
			foreach (Employee item5 in _wasWorking)
			{
				foreach (WorkerDetailPanel value9 in _panels.Values)
				{
					flag |= value9.RemoveWorker(item5.MyActor);
				}
			}
		}
		if (flag)
		{
			StartCoroutine(UpdateTransform());
		}
		HashSet<Employee> wasWorking = _wasWorking2;
		HashSet<Employee> wasWorking2 = _wasWorking;
		_wasWorking = wasWorking;
		_wasWorking2 = wasWorking2;
	}
}
