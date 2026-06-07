using System;
using System.Collections.Generic;
using System.Linq;
using StatementParser;
using Tyd;
using UnityEngine;

public class CampaignMission
{
	public class ArrowData
	{
		public string Element;

		public LineParse.TreeNode Completion;

		public Vector2 Offset;

		public Vector3? TOffset;

		public float? Angle;

		public bool Force;

		public TutorialMessage.HorizontalAnchor HAnchor = TutorialMessage.HorizontalAnchor.Center;

		public TutorialMessage.VerticalAnchor VAnchor = TutorialMessage.VerticalAnchor.Middle;

		public ArrowData(TydTable table)
		{
			Element = table.GetChildValue("Element", false);
			Force = table.GetChildValue("Force", false, false);
			TydList child = table.GetChild<TydList>("Offset");
			float[] array = ((child != null) ? child.GetChildValues<float>().ToArray() : null);
			if (array != null)
			{
				if (array.Length > 2)
				{
					TOffset = new Vector3(array[0], array[1], array[2]);
				}
				else
				{
					Offset = new Vector2(array[0], array[1]);
				}
			}
			TydString child2 = table.GetChild<TydString>("Angle");
			if (child2 != null)
			{
				Angle = child2.GetValue<float>();
			}
			TydList child3 = table.GetChild<TydList>("Anchor");
			string[] array2 = ((child3 != null) ? child3.GetChildValues().ToArray() : null);
			if (array2 != null)
			{
				Enum.TryParse<TutorialMessage.VerticalAnchor>(array2[0], out VAnchor);
				Enum.TryParse<TutorialMessage.HorizontalAnchor>(array2[1], out HAnchor);
			}
			string childValue = table.GetChildValue("Completion", false);
			if (childValue != null)
			{
				Completion = LineParse.Parse(childValue);
			}
		}
	}

	public class FocusData
	{
		public string Element;

		public string Message;

		public LineParse.TreeNode Completion;

		public LineParse.TreeNode Ready;

		public FocusData(TydTable table)
		{
			Element = table.GetChildValue("Element");
			Message = table.GetChildValue("Message");
			string childValue = table.GetChildValue("Completion", false);
			if (childValue != null)
			{
				Completion = LineParse.Parse(childValue);
			}
			childValue = table.GetChildValue("Ready", false);
			if (childValue != null)
			{
				Ready = LineParse.Parse(childValue);
			}
		}
	}

	public string ID;

	public string Name;

	public string NextMission;

	public string OnStartScript;

	public string LaunchCheck;

	public ArrowData[] Arrows;

	public FocusData[] Focus;

	public RewardTask Task;

	public string[] Prompts;

	public string[] Eval;

	public MissionGuide.AnimationStates[] Emotes;

	public string[] Characters;

	private LineParse.TreeNode _launchCheck;

	public bool DoLaunchCheck()
	{
		if (_launchCheck == null)
		{
			if (LaunchCheck == null)
			{
				return false;
			}
			_launchCheck = LineParse.Parse(LaunchCheck);
		}
		return (bool)LineParse.Execute(_launchCheck, ScriptSystem.TaskScope.Scope);
	}

	public IEnumerable<string> GetPrompts()
	{
		for (int i = 0; i < Prompts.Length; i++)
		{
			string text = Eval[i];
			if (string.IsNullOrEmpty(text))
			{
				yield return Prompts[i];
			}
			else if ((bool)LineParse.Execute(LineParse.Parse(text), ScriptSystem.TaskScope.Scope))
			{
				yield return Prompts[i];
			}
		}
	}

	public CampaignMission(string id, TydDocument doc)
	{
		ID = id;
		Name = doc.GetChildValue("Name");
		NextMission = doc.GetChildValue("NextMission", false);
		OnStartScript = doc.GetChildValue("OnStartScript", false);
		LaunchCheck = doc.GetChildValue("LaunchCheck", false);
		TydTable child = doc.GetChild<TydTable>("Task");
		if (child != null)
		{
			Task = new RewardTask(child);
		}
		TydList child2 = doc.GetChild<TydList>("Dialog", true);
		Prompts = new string[child2.Count];
		Eval = new string[child2.Count];
		Emotes = new MissionGuide.AnimationStates[child2.Count];
		Characters = new string[child2.Count];
		for (int i = 0; i < child2.Nodes.Count; i++)
		{
			TydTable tydTable = child2.Nodes[i] as TydTable;
			Prompts[i] = tydTable.GetChildValue("Prompt");
			Eval[i] = tydTable.GetChildValue("Eval", false);
			Emotes[i] = (MissionGuide.AnimationStates)Enum.Parse(typeof(MissionGuide.AnimationStates), tydTable.GetChildValue("Emote"), true);
			Characters[i] = tydTable.GetChildValue("Character", false, "Player");
		}
		TydList child3 = doc.GetChild<TydList>("Arrows");
		Arrows = ((child3 != null) ? (from x in child3.Nodes.OfType<TydTable>()
			select new ArrowData(x)).ToArray() : null);
		TydList child4 = doc.GetChild<TydList>("Focus");
		Focus = ((child4 != null) ? (from x in child4.Nodes.OfType<TydTable>()
			select new FocusData(x)).ToArray() : null);
	}

	public override string ToString()
	{
		return ID;
	}
}
