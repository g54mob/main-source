using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementAlwaysTrueSO", menuName = "Story/StoryElementAlwaysTrueSO")]
	public class StoryElementAlwaysTrueSO : StoryElementSO
	{
		public override void Initialize()
		{
			TryExecute();
		}

		public override void Destroy()
		{
		}
	}
}
