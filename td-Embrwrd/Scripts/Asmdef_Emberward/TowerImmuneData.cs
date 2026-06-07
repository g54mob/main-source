using System;

[Serializable]
public class TowerImmuneData
{
	public float timer;

	public int id;

	public TowerImmuneData(float timer, int id)
	{
	}

	public void UpdateTimer(float deltaTime)
	{
	}

	public bool IsExpired()
	{
		return false;
	}
}
