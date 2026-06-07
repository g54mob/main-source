using System;

[Serializable]
public class Mana
{
	public float progress;

	public int amount;

	public bool running;

	public Mana()
	{
		progress = 0f;
		amount = 0;
		running = false;
	}
}
