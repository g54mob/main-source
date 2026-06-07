using System.Collections.Generic;

public class Earth : Module
{
	private Dictionary<Module, Aura> modAuras = new Dictionary<Module, Aura>();

	private List<Module> modTrigs = new List<Module>();

	public override void InitUpgrade(bool loaded)
	{
		Plug.GetOutputs(this);
		foreach (Module output in outputs)
		{
			if (!modTrigs.Contains(output))
			{
				modTrigs.Add(output);
				output.AddTrigger(global::Trigger.Ability.Knockback);
			}
		}
	}

	public override void InitConnection(Module m)
	{
		if (UPGRADED && !modTrigs.Contains(m))
		{
			modTrigs.Add(m);
			m.AddTrigger(global::Trigger.Ability.Knockback);
		}
		if (!modAuras.ContainsKey(m))
		{
			Aura aura = new Aura(Aura.Type.Damage, foreign: false, temp: false, null, 2f);
			modAuras.Add(m, aura);
			m.AddAura(aura);
		}
	}

	public override void EndConnection(Module m)
	{
		if (UPGRADED && modTrigs.Contains(m))
		{
			modTrigs.Remove(m);
			m.RemoveTrigger(global::Trigger.Ability.Knockback);
		}
		if (modAuras.ContainsKey(m))
		{
			m.RemoveAura(modAuras[m]);
			modAuras.Remove(m);
		}
	}
}
