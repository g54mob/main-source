using System;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class EditablePerkItemView : LayoutGroupItemView
	{
		private static readonly int removeButtonIndex = 1;

		public void OnEnable()
		{
			CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
			instance.EditModeEnabledAction = (Action<bool>)Delegate.Combine(instance.EditModeEnabledAction, new Action<bool>(OnEditModeEnabled));
		}

		private void OnDisable()
		{
			if (MonoSingleton<CharacterEditController>.IsInstantiated())
			{
				CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
				instance.EditModeEnabledAction = (Action<bool>)Delegate.Remove(instance.EditModeEnabledAction, new Action<bool>(OnEditModeEnabled));
			}
		}

		private void OnEditModeEnabled(bool enable)
		{
			base.GroupItems[removeButtonIndex].SetActive(enable);
		}

		public void SetData(string imagePath, string perkName, HumanoidInstance humanoid, UnityAction removeButtonCallback)
		{
			SetImageHumanoid(imagePath, perkName, humanoid);
			base.GroupItems[removeButtonIndex].GetComponent<SoundButton>().AddCleanListener(removeButtonCallback.Invoke);
			bool editModeEnabled = MonoSingleton<CharacterEditController>.Instance.EditModeEnabled;
			OnEditModeEnabled(editModeEnabled);
			base.TooltipNew?.SetLines(HumanoidUtils.GetPerkTooltipLines(perkName, MonoSingleton<CharacterEditController>.Instance.SelectedHumanoid, includeDescription: true, includeCreationData: true));
		}
	}
}
