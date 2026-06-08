using System.Collections.Generic;

public class EventObjectiveDefeatBossWithUnmake : EventObjectiveBase
{
	private List<string> uniqueBossIDs { get; set; }

	public EventObjectiveDefeatBossWithUnmake(int goal)
		: base("unmake_boss", goal)
	{
		description = Te.xt("tid_q_basic_unmake_boss");
	}

	public override void Init()
	{
		Character.OnCharacterDied += HandleCharacterDied;
	}

	public override void End()
	{
		Character.OnCharacterDied -= HandleCharacterDied;
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (reason == Character.DeathReason.Unmake && c.HasTag("boss"))
		{
			if (uniqueBossIDs == null)
			{
				uniqueBossIDs = new List<string>();
			}
			if (!uniqueBossIDs.Contains(c.id))
			{
				uniqueBossIDs.Add(c.id);
				AddProgress();
			}
		}
	}

	public override void ClearProgress()
	{
		base.ClearProgress();
		if (uniqueBossIDs == null)
		{
			uniqueBossIDs = new List<string>();
		}
		else
		{
			uniqueBossIDs.Clear();
		}
	}

	protected override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		string[] array = SlimJson.ParseArray(sjson, "uIDs");
		if (array != null)
		{
			uniqueBossIDs = new List<string>(array);
		}
	}

	protected override void SerializeMore()
	{
		base.SerializeMore();
		SlimJson.AddProperty("uIDs", uniqueBossIDs.ToArray());
	}
}
