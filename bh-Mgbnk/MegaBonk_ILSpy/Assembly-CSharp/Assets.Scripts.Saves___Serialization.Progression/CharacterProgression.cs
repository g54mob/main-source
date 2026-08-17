using Cpp2ILInjected;
using Inventory__Items__Pickups;

namespace Assets.Scripts.Saves___Serialization.Progression;

public class CharacterProgression
{
	public int xp;

	public int numRuns;

	private float xpModifier = 0.1f;

	public void OnRunFinished(int xp)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected I4, but got Unknown
		object obj = xp * xpModifier;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		object obj2 = default(object);
		int num = obj2 + this.xp;
		int num2 = numRuns + 1;
		numRuns = num2;
		this.xp = num;
	}

	public int GetRank()
	{
		int num = XpUtility.XpToLevel(xp);
		return num + 1;
	}

	public bool HasStar()
	{
		//IL_0022: Expected O, but got I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		int num = XpUtility.XpToLevel(xp);
		object obj = num + 1;
		object obj2 = obj - 100;
		object obj3 = obj ^ 0x64;
		object obj4 = obj ^ obj2;
		object obj5 = obj3 & obj4;
		bool flag = (nint)obj5 < 0;
		bool flag2 = (nint)obj2 < 0;
		return flag2 == flag;
	}
}
