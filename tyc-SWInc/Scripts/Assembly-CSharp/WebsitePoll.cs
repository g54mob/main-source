using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebsitePoll : MonoBehaviour
{
	public class Answer
	{
		public int ID;

		public string Text;

		public int Votes;

		public Button Vote;

		public GUIProgressBar Bar;

		public Answer(int id, string text, int votes)
		{
			ID = id;
			Text = text;
			Votes = votes;
		}
	}

	public CanvasGroup MainGroup;

	public GameObject VotePanel;

	public GameObject ResultPanel;

	public Transform VoteButtonPanel;

	public Transform ResultBarPanel;

	public Text Question;

	public Button VotePrefab;

	public GUIProgressBar ResultPrefab;

	private static bool _loaded = false;

	private static bool _valid = false;

	private static int _questionID;

	private static string _questionText;

	private static List<Answer> _answers = new List<Answer>();

	private IEnumerator Start()
	{
		if (_loaded)
		{
			if (_valid)
			{
				Question.text = _questionText;
				Init();
			}
			else
			{
				base.gameObject.SetActive(false);
			}
			yield break;
		}
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("Query", Versioning.Types[2] + " " + 1 + "." + 8);
		wWWForm.AddField("UserID", SystemInfo.deviceUniqueIdentifier);
		UnityWebRequest web = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/SoftwareIncPoll.php", wWWForm);
		web.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return web.SendWebRequest();
		if (!string.IsNullOrEmpty(web.error))
		{
			yield break;
		}
		_loaded = true;
		string text = web.downloadHandler.text;
		if (string.IsNullOrEmpty(text) || "NoPoll".Equals(text))
		{
			yield break;
		}
		string[] array = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length <= 1)
		{
			yield break;
		}
		_questionID = array[0].ConvertToIntDef(-1);
		_valid = _questionID >= 0;
		if (_valid)
		{
			Question.text = (_questionText = array[1]);
			for (int i = 2; i < array.Length; i += 3)
			{
				int num = array[i].ConvertToIntDef(-1);
				if (num >= 0)
				{
					_answers.Add(new Answer(num, array[i + 1], array[i + 2].ConvertToIntDef(0)));
					continue;
				}
				_valid = false;
				break;
			}
		}
		if (_valid)
		{
			Init();
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	private void Init()
	{
		float num = _answers.SumSafe((Answer x) => x.Votes);
		for (int num2 = 0; num2 < _answers.Count; num2++)
		{
			Answer a = _answers[num2];
			GUIProgressBar gUIProgressBar = UnityEngine.Object.Instantiate(ResultPrefab);
			gUIProgressBar.Animated = true;
			gUIProgressBar.GetComponentInChildren<Text>().text = a.Text + " (" + a.Votes + ")";
			gUIProgressBar.transform.SetParent(ResultBarPanel, false);
			gUIProgressBar.Value = ((num > 0f) ? ((float)a.Votes / num) : 0f);
			a.Bar = gUIProgressBar;
			Button button = UnityEngine.Object.Instantiate(VotePrefab);
			button.GetComponentInChildren<Text>().text = a.Text;
			button.transform.SetParent(VoteButtonPanel, false);
			button.onClick.AddListener(delegate
			{
				StartCoroutine(Vote(a, _answers));
			});
			a.Vote = button;
		}
		VotePanel.SetActive(true);
	}

	private void Update()
	{
		if (_valid && MainGroup.alpha < 1f)
		{
			MainGroup.alpha = Mathf.Clamp01(MainGroup.alpha + Time.deltaTime);
		}
	}

	private IEnumerator Vote(Answer answer, List<Answer> answers)
	{
		_valid = false;
		VotePanel.SetActive(false);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("Vote", SystemInfo.deviceUniqueIdentifier);
		wWWForm.AddField("QuestionID", _questionID);
		wWWForm.AddField("AnswerID", answer.ID);
		UnityWebRequest web = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/SoftwareIncPoll.php", wWWForm);
		web.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return web.SendWebRequest();
		if (string.IsNullOrEmpty(web.error) && "Done".Equals(web.downloadHandler.text))
		{
			ResultPanel.SetActive(true);
			answer.Votes++;
			float num = answers.SumSafe((Answer x) => x.Votes);
			for (int num2 = 0; num2 < answers.Count; num2++)
			{
				Answer answer2 = answers[num2];
				answer2.Bar.Value = (float)answers[num2].Votes / num;
				answer2.Bar.GetComponentInChildren<Text>().text = answer2.Text + " (" + answer2.Votes + ")";
			}
		}
	}
}
