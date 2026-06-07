using System.Collections.Generic;

public class Point : Module
{
	public float angle = 90f;

	public float ratio = 0.5f;

	public float maxAmp = 4f;

	public float t;

	private Dictionary<Module, Aura> modAuras = new Dictionary<Module, Aura>();

	public override void InitUpgrade(bool loaded)
	{
		Plug.GetOutputs(this);
		foreach (Module output in outputs)
		{
			if (!modAuras.ContainsKey(output))
			{
				Aura aura = new Aura(Aura.Type.Damage);
				modAuras.Add(output, aura);
				output.AddAura(aura);
			}
		}
	}

	public override void SetDial(float x)
	{
		angle = 360f * x;
	}

	public override void SetSlider(float x)
	{
		ratio = 1f - x * 0.5f;
		base.amp = maxAmp * x;
	}

	public override void InitConnection(Module m)
	{
		if (UPGRADED && !modAuras.ContainsKey(m))
		{
			Aura aura = new Aura(Aura.Type.Damage);
			modAuras.Add(m, aura);
			m.AddAura(aura);
		}
	}

	public override void EndConnection(Module m)
	{
		if (UPGRADED && modAuras.ContainsKey(m))
		{
			m.RemoveAura(modAuras[m]);
			modAuras.Remove(m);
		}
	}
}
