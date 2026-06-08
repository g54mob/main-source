using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class ColorSet : ScriptableObject
{
	public List<ColorOption> colorOptions = new List<ColorOption>();

	public List<TextureOption> textureOptions = new List<TextureOption>();

	public List<FloatOption> floatOptions;

	public SessionQuestReward unlockReward;

	private Color ColorByRewardState()
	{
		if (unlockReward == null)
		{
			return Color.white;
		}
		return unlockReward.state switch
		{
			RewardState.Completed => Color.white, 
			RewardState.InProgress => new Color(1f, 0.9f, 0.3f), 
			_ => new Color(0.9f, 0.2f, 0.2f), 
		};
	}
}
