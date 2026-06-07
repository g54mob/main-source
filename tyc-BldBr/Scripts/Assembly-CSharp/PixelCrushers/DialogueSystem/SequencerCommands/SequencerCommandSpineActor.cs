using System;
using PixelCrushers.DialogueSystem.SpineSupport;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	public class SequencerCommandSpineActor : SequencerCommand
	{
		private void Awake()
		{
			string parameter = GetParameter(0);
			bool flag = string.Equals("hide", GetParameter(1), StringComparison.OrdinalIgnoreCase);
			int panelIndex = (flag ? (-1) : GetParameterAsInt(1));
			SpineDialogueActor component = CharacterInfo.GetRegisteredActorTransform(parameter).GetComponent<SpineDialogueActor>();
			if (component == null)
			{
				if (DialogueDebug.logWarnings)
				{
					Debug.LogWarning("Dialogue System: SpineActor(" + GetParameters() + "): Can't find SpineDialogueActor.");
				}
			}
			else
			{
				if (DialogueDebug.logInfo)
				{
					Debug.Log("Dialogue System: Sequencer: SpineActor(" + component?.ToString() + ", " + (flag ? "hide" : panelIndex.ToString()) + ")", component);
				}
				if (flag)
				{
					SpinePortraitManager.instance.HideSpineActor(component);
				}
				else
				{
					SpinePortraitManager.instance.ShowSpineActor(component, panelIndex);
				}
			}
			Stop();
		}
	}
}
