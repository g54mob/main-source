using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestAtom
{
	[Serializable]
	public class Condition
	{
		public enum Kind
		{
			None = 0,
			Wait = 1,
			Trigger = 2,
			Stat = 3,
			StatEqual = 4,
			HaveInventory = 5,
			LookAt = 6,
			Not = 7,
			Or = 8,
			And = 9,
			InputAny = 10,
			StatGreater = 11,
			Skip = 12,
			StatLess = 13
		}

		public Kind kind;

		public string name;

		public float time;

		public int statValue;

		public QuestLookAt lookAt;

		public QuestTrigger trigger;

		public bool Get(float enterTime)
		{
			if (kind == Kind.Wait)
			{
				return Clock.play.time > enterTime + time;
			}
			if (kind == Kind.Trigger)
			{
				return trigger.containsPlayer;
			}
			if (kind == Kind.Stat)
			{
				return SaveData.it.GetStat(name) != 0;
			}
			if (kind == Kind.HaveInventory)
			{
				return SaveData.it.HaveInventory(name);
			}
			if (kind == Kind.StatEqual)
			{
				return SaveData.it.GetStat(name) == statValue;
			}
			if (kind == Kind.StatGreater)
			{
				return SaveData.it.GetStat(name) > statValue;
			}
			if (kind == Kind.StatLess)
			{
				return SaveData.it.GetStat(name) < statValue;
			}
			if (kind == Kind.LookAt)
			{
				return Clock.play.time > enterTime + 0.01f && lookAt.seenByPlayer;
			}
			if (kind == Kind.InputAny)
			{
				return RInput.anyButton || Mathf.Abs(RInput.GetAxis(0)) > 0.01f || Mathf.Abs(RInput.GetAxis(1)) > 0.01f || Mathf.Abs(RInput.GetAxis(2)) > 0.01f || Mathf.Abs(RInput.GetAxis(3)) > 0.01f || Mathf.Abs(RInput.GetAxis(18)) > 0.01f || Mathf.Abs(RInput.GetAxis(19)) > 0.01f;
			}
			return true;
		}
	}

	[Serializable]
	public class Action
	{
		public enum Kind
		{
			StartAtom = 0,
			StopAtom = 1,
			SoloAtom = 2,
			Dialog = 3,
			IncStat = 4,
			EnableGo = 5,
			DisableGo = 6,
			PhantomGoAfter = 7,
			QuitToTitle = 8
		}

		public Kind kind;

		public string name;

		public AudioSource dialogSource;

		public int statValue;

		public string otherAtomGuid;

		public GameObject otherGo;

		public void Apply()
		{
			if (kind == Kind.Dialog)
			{
				Game.instance.ShowDialog(name, new Dialog.Extra(null, dialogSource));
			}
			else if (kind == Kind.IncStat)
			{
				SaveData.it.IncStat(name);
			}
			else if (kind == Kind.EnableGo)
			{
				if (otherGo != null)
				{
					otherGo.SetActive(true);
				}
			}
			else if (kind == Kind.DisableGo)
			{
				if (otherGo != null)
				{
					otherGo.SetActive(false);
				}
			}
			else if (kind == Kind.QuitToTitle)
			{
				Game.LoadTitle();
			}
			else if (kind == Kind.PhantomGoAfter)
			{
				Phantom component = otherGo.GetComponent<Phantom>();
				if (component != null)
				{
					component.Force(true);
				}
				else
				{
					Debug.LogError("QuestAtom target has no Phantom: " + name);
				}
			}
		}

		private string GetAtomId(Quest quest, string atomGuid)
		{
			if (atomGuid == "*")
			{
				return "All";
			}
			QuestAtom questAtom = quest.FindAtom(atomGuid);
			return (questAtom == null) ? "Unknown" : questAtom.id;
		}

		public string ToString(Quest quest)
		{
			if (kind == Kind.Dialog)
			{
				return "Dialog " + name;
			}
			if (kind == Kind.IncStat)
			{
				return "IncStat " + name;
			}
			if (kind == Kind.StartAtom)
			{
				return "StartAtom " + GetAtomId(quest, otherAtomGuid);
			}
			if (kind == Kind.StopAtom)
			{
				return "StopAtom " + GetAtomId(quest, otherAtomGuid);
			}
			if (kind == Kind.SoloAtom)
			{
				return "SoloAtom " + GetAtomId(quest, otherAtomGuid);
			}
			if (kind == Kind.EnableGo)
			{
				return "EnableGo " + ((!(otherGo != null)) ? "None" : otherGo.name);
			}
			if (kind == Kind.DisableGo)
			{
				return "DisableGo " + ((!(otherGo != null)) ? "None" : otherGo.name);
			}
			if (kind == Kind.QuitToTitle)
			{
				return "QuitToTitle";
			}
			return kind.ToString();
		}
	}

	public string guid;

	public string id;

	public bool runAtBoot;

	public int saveBit = -1;

	public List<Condition> conditions;

	public List<Action> actions;

	private float enterTime;

	private bool running_;

	public bool running
	{
		get
		{
			return running_;
		}
		set
		{
			if (value && !running_)
			{
				enterTime = Clock.play.time;
			}
			running_ = value;
		}
	}

	public QuestAtom()
	{
		guid = Guid.NewGuid().ToString();
	}

	public bool RunChecks(bool[] workStack)
	{
		if (conditions.Count == 0)
		{
			return true;
		}
		int num = 0;
		foreach (Condition condition in conditions)
		{
			if (condition.kind == Condition.Kind.Skip)
			{
				continue;
			}
			if (condition.kind == Condition.Kind.Or)
			{
				bool flag = false;
				for (int i = 0; i < num; i++)
				{
					flag |= workStack[i];
				}
				workStack[0] = flag;
				num = 1;
			}
			else if (condition.kind == Condition.Kind.And)
			{
				bool flag2 = true;
				for (int j = 0; j < num; j++)
				{
					flag2 &= workStack[j];
				}
				workStack[0] = flag2;
				num = 1;
			}
			else if (condition.kind == Condition.Kind.Not)
			{
				workStack[num - 1] = !workStack[num - 1];
			}
			else
			{
				workStack[num] = condition.Get(enterTime);
				num++;
			}
		}
		return workStack[num - 1];
	}

	public void ApplyActions(Quest quest, bool log)
	{
		foreach (Action action in actions)
		{
			if (log)
			{
				Debug.LogFormat("{0} - {1} - {2}", quest.id, id, action.ToString(quest));
			}
			if (action.kind == Action.Kind.StartAtom)
			{
				quest.SetAtomRunning(action.otherAtomGuid, true);
			}
			else if (action.kind == Action.Kind.StopAtom)
			{
				quest.SetAtomRunning(action.otherAtomGuid, false);
			}
			else if (action.kind == Action.Kind.SoloAtom)
			{
				quest.SetAtomRunning("*", false);
				quest.SetAtomRunning(action.otherAtomGuid, true);
			}
			else
			{
				action.Apply();
			}
		}
	}
}
