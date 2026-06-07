public class Spellbook : Module
{
	protected override void CastSpell()
	{
		foreach (Module output in outputs)
		{
			if (output.WAND)
			{
				output.Cast();
			}
		}
	}
}
