using UnityEngine;

public class MultiParticleEmitter : AsciiParticleEmitter
{
	public enum SelectionType
	{
		AllTogether = 0,
		RandomChoice = 1,
		Sequential = 2
	}

	public SelectionType emitterSelection;

	public AsciiParticleEmitter[] multiEmitters;

	private int sequentialEmitterIndex;

	public override void Emit()
	{
		if (multiEmitters.Length == 0)
		{
			return;
		}
		if (emitterSelection == SelectionType.AllTogether)
		{
			for (int i = 0; i < multiEmitters.Length; i++)
			{
				multiEmitters[i].Emit();
			}
		}
		else if (emitterSelection == SelectionType.RandomChoice)
		{
			int num = Random.Range(0, multiEmitters.Length);
			multiEmitters[num].Emit();
		}
		else
		{
			multiEmitters[sequentialEmitterIndex].Emit();
			sequentialEmitterIndex = (sequentialEmitterIndex + 1) % multiEmitters.Length;
		}
	}

	public override void MoveTo(Vector3 pos)
	{
		for (int i = 0; i < multiEmitters.Length; i++)
		{
			multiEmitters[i].MoveTo(pos);
		}
	}
}
