using Cinemachine;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	public class SequencerCommandCinemachineTarget : SequencerCommand
	{
		public void Awake()
		{
			Transform subject = GetSubject(0);
			CinemachineVirtualCamera cinemachineVirtualCamera = ((subject != null) ? subject.GetComponent<CinemachineVirtualCamera>() : null);
			Transform subject2 = GetSubject(1, base.speaker);
			string parameter = GetParameter(2);
			parameter = (string.IsNullOrEmpty(parameter) ? "both" : parameter.ToLower());
			if (cinemachineVirtualCamera == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: CinemachineTarget(" + GetParameters() + "): Can't find virtual camera '" + GetParameter(0) + ".");
				}
			}
			else if (subject2 == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: CinemachineTarget(" + GetParameters() + "): Can't find target.");
				}
			}
			else if (parameter != "look" && parameter != "follow" && parameter != "both")
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: CinemachineTarget(" + GetParameters() + "): Mode must be 'look', 'follow', or 'both'.");
				}
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: Sequencer: CinemachineTarget(" + cinemachineVirtualCamera?.ToString() + ", " + subject2?.ToString() + ", " + parameter + ")");
				}
				if (parameter == "look" || parameter == "both")
				{
					cinemachineVirtualCamera.LookAt = subject2.transform;
				}
				if (parameter == "follow" || parameter == "both")
				{
					cinemachineVirtualCamera.Follow = subject2.transform;
				}
			}
			Stop();
		}
	}
}
