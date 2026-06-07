using Data.Variables;
using Presentation.Locators;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(fileName = "TriggerTechTreeNodeUnlockMusicBehaviour", menuName = "Tech Tree/Behaviors/Trigger Tech Tree Node Unlock Music")]
	public class TriggerTechTreeNodeUnlockMusicBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private AudioMusicSwapManagerLocator _audioMusicSwapManagerLocator;

		public override void Unlock()
		{
			_audioMusicSwapManagerLocator.MusicSwapManager.TriggerImportantTechTreeNodeUnlocked();
		}

		public override void RefunableReUnlock()
		{
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = null;
			return false;
		}
	}
}
