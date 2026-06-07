using System;

[Serializable]
public class GraphicsPlayerData
{
	public float UIScale = 1f;

	public GraphicsPlayerData()
	{
	}

	public GraphicsPlayerData(GraphicsPlayerData data)
	{
		Copy(data);
	}

	public void ResetSettings()
	{
		UIScale = 1f;
	}

	public bool IsEqual(GraphicsPlayerData data)
	{
		if (data.UIScale != UIScale)
		{
			return false;
		}
		return true;
	}

	public void Copy(GraphicsPlayerData data)
	{
		UIScale = data.UIScale;
	}
}
