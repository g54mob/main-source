using System.Collections;
using Cinemachine;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	public class SequencerCommandCinemachineZoom : SequencerCommand
	{
		protected virtual IEnumerator Start()
		{
			Transform subject = GetSubject(0);
			CinemachineVirtualCamera vcam = ((subject != null) ? subject.GetComponent<CinemachineVirtualCamera>() : null);
			float zoom = GetParameterAsFloat(1);
			float duration = GetParameterAsFloat(2);
			if (vcam == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: CinemachineZoom(" + GetParameters() + "): Can't find virtual camera '" + GetParameter(0) + ".");
				}
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: Sequencer: CinemachineZoom(" + vcam?.ToString() + ", " + zoom + ", " + duration + ")");
				}
				if (vcam.m_Lens.Orthographic)
				{
					if (duration > 0f)
					{
						float originalSize = vcam.m_Lens.OrthographicSize;
						for (float elapsed = 0f; elapsed < duration; elapsed += DialogueTime.deltaTime)
						{
							vcam.m_Lens.OrthographicSize = Mathf.Lerp(originalSize, zoom, elapsed / duration);
							yield return null;
						}
					}
					vcam.m_Lens.OrthographicSize = zoom;
				}
				else if (DialogueDebug.LogInfo)
				{
					Debug.LogWarning("Dialogue System: Sequencer: CinemachineZoom(" + vcam?.ToString() + ", " + zoom + ", " + duration + ") not supported yet for 3D.");
				}
			}
			Stop();
		}
	}
}
