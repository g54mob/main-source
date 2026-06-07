using System;
using DeepTraffic;
using UnityEngine.UI;

public class CarMedalController : ActiveComponent
{
	[SceneBind("Medal1")]
	private MedalSystem Medal1;

	[SceneBind("Medal2")]
	private MedalSystem Medal2;

	[SceneBind("Medal3")]
	private MedalSystem Medal3;

	[SceneBind("LockImage")]
	private Image lockImage;

	private MedalSystem[] medals = new MedalSystem[3];

	private CarConstraint[] constraints = new CarConstraint[3];

	private bool[] activeMask = new bool[3];

	private CarQuest carQuest;

	private QuestLine.Quest quest;

	private Action<int> chooseMedalAction;

	public int LastChosenMedal { get; private set; }

	public bool Locked
	{
		get
		{
			return lockImage.gameObject.activeSelf;
		}
		set
		{
			lockImage.gameObject.SetActive(value);
			if (value)
			{
				ChooseComplexity(ChooseBestMedal(), setCurrentCondition: false, lockGreater: true);
			}
			else
			{
				ChooseComplexity(quest.currentCondition, setCurrentCondition: false);
			}
		}
	}

	public void ChooseComplexity(int val, bool setCurrentCondition = true, bool lockGreater = false)
	{
		LastChosenMedal = val;
		if (setCurrentCondition)
		{
			quest.currentCondition = val;
			ActiveComponent.Model.construction.ResetConditions();
		}
		for (int i = 0; i < medals.Length; i++)
		{
			medals[i].SetChosen(val == i);
			if (lockGreater && val < i)
			{
				medals[i].SetLocked(locked: true);
			}
			else
			{
				medals[i].SetLocked(locked: false);
			}
		}
		if (chooseMedalAction != null)
		{
			chooseMedalAction(val);
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		medals[0] = Medal1;
		medals[1] = Medal2;
		medals[2] = Medal3;
		for (int i = 0; i < medals.Length; i++)
		{
			medals[i].Init();
			int iCopy = i;
			medals[i].GetComponent<Button>().onClick.AddListener(delegate
			{
				if (LastChosenMedal != iCopy)
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				}
				ChooseComplexity(iCopy);
			});
		}
	}

	private void TryAddMedal(string condition, int id)
	{
		if (condition != "-")
		{
			constraints[id] = carQuest.GetCarCondition(id).CarConstraint;
			medals[id].gameObject.SetActive(value: true);
			medals[id].SetState(chosen: false, locked: false);
			activeMask[id] = true;
		}
		else
		{
			constraints[id] = null;
			medals[id].gameObject.SetActive(value: false);
			activeMask[id] = false;
		}
	}

	private int ChooseBestMedal()
	{
		for (int num = medals.Length - 1; num >= 0; num--)
		{
			if (constraints[num].Check(carQuest.SuperEpochData.superEpochNumber - 1))
			{
				return num;
			}
		}
		return -1;
	}

	public void Init(CarQuest cq, Action<int> chooseMedalAction)
	{
		base.Init();
		this.chooseMedalAction = chooseMedalAction;
		carQuest = cq;
		quest = QuestLine.GetQuest(cq.KeyName);
		lockImage.gameObject.SetActive(value: false);
		TryAddMedal(cq.ConditionBronze, 0);
		TryAddMedal(cq.ConditionSilver, 1);
		TryAddMedal(cq.ConditionGold, 2);
		int num = Math.Min(2, quest.currentCondition);
		if (quest.currentCondition != -1 && activeMask[num])
		{
			medals[num].SetChosen(chosen: true);
			LastChosenMedal = num;
		}
		else
		{
			ChooseComplexity(ChooseBestMedal());
		}
		chooseMedalAction(LastChosenMedal);
	}
}
