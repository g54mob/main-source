using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ReviewWindow : MonoBehaviour
{
	[Serializable]
	public class ReviewData
	{
		public Dictionary<string, Dictionary<string, float>> Data;

		public Dictionary<string, Dictionary<string, float>> Progress;

		public SDateTime BuildDate;

		public float Score;

		public float Accuracy;

		public float? Creativity;

		public ReviewData()
		{
		}

		public ReviewData(Dictionary<string, Dictionary<string, float>> data, Dictionary<string, Dictionary<string, float>> prog, SDateTime buildDate, float score, float? creativity, float accuracy)
		{
			Data = data;
			Progress = prog;
			BuildDate = buildDate;
			Score = score;
			Accuracy = accuracy;
			Creativity = creativity;
		}

		public float? GetProgress(string role, string spec)
		{
			Dictionary<string, float> value;
			float value2;
			if (Progress != null && Progress.TryGetValue(role, out value) && value.TryGetValue(spec, out value2))
			{
				return value2;
			}
			return null;
		}
	}

	public GUIWindow Window;

	public SmileyReportItem ActualSmileyPrefab;

	public GameObject TextPrefab;

	public GameObject HeaderPrefab;

	public GameObject SmileyPrefab;

	public GameObject GridContent;

	public GameObject ContentPanel;

	public SmileyReportItem CreativitySmiley;

	public ScrollRect scrollRect;

	public Toggle RelativeScore;

	private List<GameObject> _allContent = new List<GameObject>();

	[NonSerialized]
	private List<SmileyReportItem> _progReports = new List<SmileyReportItem>();

	public int MaxPerLine = 20;

	public Text DateLabel;

	private float _finalScore;

	private float _finalAccuracy;

	public Color DefaultColor;

	public Gradient QualityGradient;

	public GameObject IterateButton;

	public GameObject PromoteButton;

	[NonSerialized]
	private SoftwareAlpha _targetWork;

	[NonSerialized]
	private ReviewData _data;

	public void Iterate()
	{
		if (!ValidForIteration())
		{
			return;
		}
		if (_targetWork.DesignTeams == null)
		{
			HUD.Instance.TeamSelectWindow.Show(false, GameSettings.Instance.GetDefaultTeams("Design"), delegate(string[] t)
			{
				if (ValidForIteration())
				{
					_targetWork.DesignTeams = t.ToList();
					_targetWork.DidLastReviewIteration = true;
					DesignDocument designDocument2 = new DesignDocument(_targetWork, _data);
					GameSettings.Instance.MyCompany.AddWorkItem(designDocument2);
					designDocument2.AddDevTeams(t);
				}
			}, "Design", "Iteration", "DesignDocument");
		}
		else
		{
			DesignDocument designDocument = new DesignDocument(_targetWork, _data);
			GameSettings.Instance.MyCompany.AddWorkItem(designDocument);
			designDocument.AddDevTeams(_targetWork.DesignTeams);
			_targetWork.DidLastReviewIteration = true;
		}
		Window.Close();
	}

	public void Promote()
	{
		if (ValidForPromotion())
		{
			_targetWork.UserPromote();
			Window.Close();
		}
		else
		{
			PromoteButton.SetActive(false);
		}
	}

	private bool ValidForIteration()
	{
		if (!_targetWork.DidLastReviewIteration && !_targetWork.Done && !_targetWork.InBeta)
		{
			return _targetWork.Child == null;
		}
		return false;
	}

	private bool ValidForPromotion()
	{
		if (!_targetWork.Done && !_targetWork.InBeta)
		{
			return _targetWork.GetCodeArtProgress() > 0.0;
		}
		return false;
	}

	public void Show(ReviewData data, SoftwareAlpha target)
	{
		_targetWork = target;
		_data = data;
		scrollRect.verticalNormalizedPosition = 1f;
		DateLabel.text = "Builddate".Loc() + ": " + data.BuildDate.ToString();
		for (int i = 0; i < _allContent.Count; i++)
		{
			UnityEngine.Object.Destroy(_allContent[i]);
		}
		_progReports.Clear();
		_allContent.Clear();
		AddText("Overallscore".Loc(), true, DefaultColor, 24, true);
		Text scoreT = AddText("", false, Color.clear, 18);
		_finalScore = 0f;
		DOTween.To(() => _finalScore, delegate(float x)
		{
			_finalScore = x;
			scoreT.text = SmileyChart.ScoreString(_finalScore) + " / 10";
		}, data.Score, 1f);
		AddText("Reviewaccuracy".Loc(), true, DefaultColor, 24, true);
		Text accT = AddText("", false, Color.clear, 18);
		_finalAccuracy = 0f;
		DOTween.To(() => _finalAccuracy, delegate(float x)
		{
			_finalAccuracy = x;
			accT.text = Mathf.RoundToInt(_finalAccuracy * 10f) * 10 + "%";
		}, data.Accuracy, 1f);
		if (!_targetWork.DidLastReviewIteration)
		{
			AddText(string.Format("-{0} {1}", target.GetBugReviewFactor().ToPercent(), "Bugs".Loc().ToLower()), false, DefaultColor, -1, true);
		}
		if (data.Creativity.HasValue)
		{
			CreativitySmiley.gameObject.SetActive(true);
			CreativitySmiley.transform.SetAsLastSibling();
			float value = data.Creativity.Value;
			CreativitySmiley.Init("Creativity", value, null, false);
		}
		else
		{
			CreativitySmiley.gameObject.SetActive(false);
		}
		IterateButton.SetActive(ValidForIteration());
		PromoteButton.SetActive(ValidForPromotion());
		foreach (KeyValuePair<string, Dictionary<string, float>> item in data.Data.OrderBy((KeyValuePair<string, Dictionary<string, float>> x) => x.Key))
		{
			if (item.Value.Count <= 0)
			{
				continue;
			}
			AddText(item.Key, true, DefaultColor);
			GameObject gameObject = UnityEngine.Object.Instantiate(GridContent);
			gameObject.transform.SetParent(ContentPanel.transform, false);
			_allContent.Add(gameObject);
			foreach (KeyValuePair<string, float> item2 in item.Value.OrderBy((KeyValuePair<string, float> x) => x.Key))
			{
				SmileyReportItem smileyReportItem = UnityEngine.Object.Instantiate(ActualSmileyPrefab);
				smileyReportItem.transform.SetParent(gameObject.transform, false);
				float? progress = data.GetProgress(item.Key, item2.Key);
				if (progress.HasValue)
				{
					_progReports.Add(smileyReportItem);
				}
				smileyReportItem.Init(item2.Key, item2.Value, progress, progress.HasValue && RelativeScore.isOn);
				_allContent.Add(smileyReportItem.gameObject);
			}
		}
		RelativeScore.gameObject.SetActive(_progReports.Count > 0);
		Window.Show();
		Window.NonLocTitle = "PeerReviewPrefix".Loc(target.GetSubjectName());
	}

	public void RelativeChange()
	{
		_progReports.ForEach(delegate(SmileyReportItem x)
		{
			x.UpdateScore(RelativeScore.isOn);
		});
	}

	private Text AddText(string value, bool header, Color color, int fontSize = -1, bool center = false)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(header ? HeaderPrefab : TextPrefab);
		gameObject.GetComponent<Image>().color = color;
		Text componentInChildren = gameObject.GetComponentInChildren<Text>();
		componentInChildren.text = value;
		if (fontSize > 0)
		{
			componentInChildren.fontSize = fontSize;
		}
		if (center)
		{
			componentInChildren.alignment = TextAnchor.MiddleCenter;
		}
		gameObject.transform.SetParent(ContentPanel.transform, false);
		_allContent.Add(gameObject);
		return componentInChildren;
	}

	private void AddChartLines(List<SmileyChart.SmileyData> data)
	{
		int num = Mathf.CeilToInt((float)data.Count / (float)MaxPerLine);
		int num2 = Mathf.CeilToInt((float)data.Count / (float)num);
		for (int i = 0; i < num; i++)
		{
			AddChart(data.Skip(i * num2).Take(num2));
		}
	}

	private void AddChart(IEnumerable<SmileyChart.SmileyData> data)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(SmileyPrefab);
		SmileyChart component = gameObject.GetComponent<SmileyChart>();
		component.Scores.Clear();
		component.Scores.AddRange(data);
		component.Scores.Shuffle();
		gameObject.transform.SetParent(ContentPanel.transform, false);
		_allContent.Add(gameObject);
	}
}
