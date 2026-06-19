using System.Collections.Generic;
using System.Linq;

namespace TH20
{
	public class MetagameStatePostCutscenePlayer : MetagameState
	{
		private List<MetagamePostCutsceneEventDefinition> _postCutsceneList = new List<MetagamePostCutsceneEventDefinition>();

		private bool _needToRunEvent;

		public MetagameStatePostCutscenePlayer(MetagameMap map)
			: base(map)
		{
		}

		public override void Enter()
		{
			Metagame.CutsceneEvents.CheckForPendingPostCutsceneEvents();
			Metagame.CutsceneEvents.FlushPostCutsceneEvents(ref _postCutsceneList);
			_ = _postCutsceneList.Count;
			_ = 0;
		}

		public override void Update()
		{
			if (_postCutsceneList.Count <= 0)
			{
				PopState();
				return;
			}
			MetagamePostCutsceneEventDefinition metagamePostCutsceneEventDefinition = _postCutsceneList.First();
			if (metagamePostCutsceneEventDefinition != null)
			{
				_postCutsceneList.Remove(metagamePostCutsceneEventDefinition);
				if (metagamePostCutsceneEventDefinition is OpenLetterMenu.Definition)
				{
					OpenLetterMenu.Definition definition = (OpenLetterMenu.Definition)metagamePostCutsceneEventDefinition;
					PushState(new MetagameStateLetterEvent(MetagameMap, definition));
				}
				else if (metagamePostCutsceneEventDefinition is PostCutsceneAdvisorEventDefinition)
				{
					PostCutsceneAdvisorEventDefinition definition2 = (PostCutsceneAdvisorEventDefinition)metagamePostCutsceneEventDefinition;
					PushState(new MetagameStateAdvisorEvent(MetagameMap, definition2));
				}
			}
		}

		public override void Exit()
		{
		}
	}
}
