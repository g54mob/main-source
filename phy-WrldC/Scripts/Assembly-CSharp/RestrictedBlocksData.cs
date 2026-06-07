using UnityEngine;

[CreateAssetMenu(menuName = "Minamolc/Restricted Blocks Data")]
public class RestrictedBlocksData : ScriptableObject
{
	[TextArea(10, 10)]
	[SerializeField]
	private string flyersBlocks;

	private string[] flyersBlocksArray;

	public string[] GetRestrictedBlocks(LevelModel.RestrictedBlocks restrictedBlocks)
	{
		if (restrictedBlocks == LevelModel.RestrictedBlocks.Flyers)
		{
			if (flyersBlocksArray == null || flyersBlocksArray.Length == 0)
			{
				string[] array = flyersBlocks.Split('\n');
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = array[i].Replace("\r", "");
				}
				flyersBlocksArray = array;
			}
			return flyersBlocksArray;
		}
		return null;
	}
}
