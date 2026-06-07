using System.Linq;
using StatementParser;
using Tyd;

public class RewardTask
{
	public class Goal
	{
		public string IDName;

		public string Description;

		public string Tip;

		public LineParse.TreeNode Eval;

		public int ReachGoal;

		public float FloatGoal;

		public bool IsCountable;

		public bool IsAmount;

		public bool Money;

		public bool Hidden;

		public int[] CompletedBy;

		public Goal(string parentName, int i, TydTable root)
		{
			IDName = parentName + i;
			Eval = LineParse.Parse(root.GetChildValue("Evaluate"));
			Description = root.GetChildValue("Description", false);
			Tip = root.GetChildValue("Tip", false);
			Money = root.GetChildValue("Money", false, false);
			Hidden = root.GetChildValue("Hidden", false, false);
			string childValue = root.GetChildValue("Goal", false);
			IsCountable = childValue != null;
			if (IsCountable)
			{
				ReachGoal = childValue.ConvertToInt("Task goal");
			}
			else
			{
				string childValue2 = root.GetChildValue("Amount", false);
				IsAmount = childValue2 != null;
				if (IsAmount)
				{
					FloatGoal = childValue2.ConvertToFloat("Task amount");
				}
			}
			TydList child = root.GetChild<TydList>("CompletedBy");
			if (child != null)
			{
				CompletedBy = child.GetChildValues<int>().ToArray();
			}
		}
	}

	public string Name;

	public string DependsOn;

	public string Description;

	public string Tutorial;

	public string Tip;

	public Goal[] Goals;

	public string IDName
	{
		get
		{
			return Name + "RewardTask";
		}
	}

	public RewardTask(TydTable root)
	{
		Name = root.Name;
		DependsOn = root.GetChildValue("DependsOn", false);
		Description = root.GetChildValue("Description", false);
		Tutorial = root.GetChildValue("Tutorial", false);
		Tip = root.GetChildValue("Tip", false);
		Goals = root.GetChild<TydList>("Goals", true).Nodes.SelectInPlace((TydNode x, int i) => new Goal(IDName, i, x as TydTable));
	}
}
