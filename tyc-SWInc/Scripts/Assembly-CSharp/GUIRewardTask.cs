using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using UnityEngine;
using UnityEngine.UI;

public class GUIRewardTask : MonoBehaviour
{
	public class GUIGoal
	{
		public RewardTask.Goal Goal;

		public GUIProgressBar Bar;

		public Text ProgText;

		public GameObject Self;

		public GUIGoal(RewardTask.Goal goal, GUIProgressBar bar, Text progText, GameObject self)
		{
			Goal = goal;
			Bar = bar;
			Bar.StartColor = HUD.GetThemeColor(0);
			ProgText = progText;
			Self = self;
		}
	}

	public GameObject SubTaskPrefab;

	public Transform SubTaskPanel;

	public Text Description;

	public List<GUIGoal> SubProg = new List<GUIGoal>();

	public GUIProgressBar MainProg;

	public Text MainProgText;

	public Image TopPanel;

	public Color NotActive;

	public GameObject RewardButton;

	public GameObject ClaimText;

	public Button TutorialButton;

	public GUIToolTipper RewardButtonTip;

	[NonSerialized]
	public RewardTask Task;

	public void Init(RewardTask task)
	{
		Task = task;
		Description.text = ("REWARD" + Task.Name).LocColor();
		if (!string.IsNullOrEmpty(Task.Tip))
		{
			TutorialButton.GetComponent<GUIToolTipper>().TooltipDescription = ("REWARD" + task.Name + "Tip").LocColor();
			TutorialButton.gameObject.SetActive(true);
		}
		else if (!string.IsNullOrEmpty(Task.Tutorial))
		{
			TutorialButton.GetComponent<GUIToolTipper>().TooltipDescription = "StartTutorialTip".Loc(Task.Tutorial.LocTry().ToLower());
			TutorialButton.onClick.AddListener(delegate
			{
				TutorialSystem.Instance.StartTutorial(Task.Tutorial, true);
			});
			TutorialButton.gameObject.SetActive(true);
		}
		MainProg.StartColor = HUD.GetThemeColor(0);
		List<RewardTask.Goal> list = task.Goals.Where((RewardTask.Goal x) => !x.Hidden).ToList();
		if (list.Count > 1)
		{
			MainProg.gameObject.SetActive(false);
			for (int num = 0; num < list.Count; num++)
			{
				RewardTask.Goal goal = list[num];
				GameObject gameObject = UnityEngine.Object.Instantiate(SubTaskPrefab);
				gameObject.transform.SetParent(SubTaskPanel, false);
				Text[] componentsInChildren = gameObject.GetComponentsInChildren<Text>();
				componentsInChildren[0].text = ("REWARD" + task.Name + num).LocColor();
				SubProg.Add(new GUIGoal(goal, gameObject.GetComponentInChildren<GUIProgressBar>(), componentsInChildren[1], gameObject));
			}
			RewardButton.transform.SetAsLastSibling();
		}
		RewardButton.GetComponent<Image>().color = HUD.GetWarningColor();
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		bool flag = GameSettings.Instance.HasCompletedTask(Task.Name);
		bool flag2 = GameSettings.Instance.HasClaimedReward(Task.Name);
		RewardButton.SetActive(flag && !flag2);
		ClaimText.SetActive(flag && flag2);
		bool flag3 = (!flag || !flag2) && (Task.DependsOn == null || GameSettings.Instance.HasCompletedTask(Task.DependsOn));
		TopPanel.color = ((!flag3) ? ((flag && flag2) ? HUD.GetThemeColor(5) : NotActive) : (RewardButton.activeSelf ? HUD.GetWarningColor() : HUD.GetAccentColor()));
		if (GameSettings.Instance.ClaimedRewards.Count > 0 && RewardButtonTip.TooltipDescription == "")
		{
			RewardButtonTip.TooltipDescription = "RewardInstaTip";
		}
		if (Task.Goals.Count((RewardTask.Goal x) => !x.Hidden) == 1)
		{
			MainProg.gameObject.SetActive(flag3);
			UpdateProg(Task.Goals.First((RewardTask.Goal x) => !x.Hidden), MainProgText, MainProg);
			return;
		}
		for (int num = 0; num < SubProg.Count; num++)
		{
			GUIGoal gUIGoal = SubProg[num];
			if (flag3)
			{
				gUIGoal.Self.SetActive(true);
				UpdateProg(gUIGoal.Goal, gUIGoal.ProgText, gUIGoal.Bar);
			}
			else
			{
				gUIGoal.Self.SetActive(false);
			}
		}
	}

	public void ClaimReward()
	{
		if (!GameSettings.Instance.HasCompletedTask(Task.Name))
		{
			return;
		}
		AchievementController.SetInteraction(AchievementController.Mechanics.Rewards);
		if (GameSettings.Instance.ClaimedRewards.Count > 0 && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			GameSettings.Instance.ClaimedRewards.Add(Task.Name);
			Options.UnlockReward(Task.Name);
			foreach (Furniture item in from x in ObjectDatabase.Instance.GetAllFurniture()
				select x.GetComponent<Furniture>() into x
				where Task.Name.Equals(x.Unlockable)
				select x)
			{
				HUD.Instance.SetFurnitureNew(item, true);
			}
			HUD.Instance.RefreshBuildButtons();
			HUD.Instance.UpdateFurnitureButtons();
		}
		else
		{
			HUD.Instance.rewardWindow.Show(Task.Name);
		}
	}

	private string GetProgress(RewardTask.Goal goal, int progress)
	{
		if (progress == goal.ReachGoal)
		{
			return "TaskComplete".Loc();
		}
		if (goal.Money)
		{
			return progress.CurrencyInt() + "/" + goal.ReachGoal.CurrencyInt();
		}
		return progress.ToString("N0") + "/" + goal.ReachGoal.ToString("N0");
	}

	private void UpdateProg(RewardTask.Goal goal, Text prog, GUIProgressBar bar)
	{
		int num = ((!GameSettings.Instance.HasCompletedTask(Task.Name)) ? GameSettings.Instance.TaskProgress.GetOrDefault(goal.IDName, 0) : ((!goal.IsCountable) ? 1 : goal.ReachGoal));
		if (goal.IsCountable)
		{
			bar.Value = (float)num / (float)goal.ReachGoal;
			prog.text = GetProgress(goal, num);
		}
		else
		{
			bar.Value = num;
			prog.text = ((num == 0) ? "TaskNotComplete".Loc() : "TaskComplete".Loc());
		}
	}
}
