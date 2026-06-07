using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	public class SequencerCommandCinemachinePriority : SequencerCommand
	{
		private static bool hasRecordedBlendMode;

		public IEnumerator Start()
		{
			bool flag = false;
			string b = string.Empty;
			bool flag2 = false;
			CinemachineVirtualCamera cinemachineVirtualCamera = null;
			string parameter = GetParameter(0);
			if (parameter == "all")
			{
				flag = true;
			}
			else if (parameter.StartsWith("except:"))
			{
				flag = true;
				flag2 = true;
				b = parameter.Substring("except:".Length);
			}
			else
			{
				Transform subject = GetSubject(0);
				cinemachineVirtualCamera = ((subject != null) ? subject.GetComponent<CinemachineVirtualCamera>() : null);
			}
			int parameterAsInt = GetParameterAsInt(1, 999);
			bool flag3 = string.Equals(GetParameter(2), "cut", StringComparison.OrdinalIgnoreCase);
			if (!flag && cinemachineVirtualCamera == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: CinemachinePriority(" + GetParameters() + "): Can't find virtual camera '" + GetParameter(0) + ".");
				}
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: Sequencer: CinemachinePriority(" + parameter + ", " + parameterAsInt + ", cut=" + flag3 + ")");
				}
				bool flag4 = false;
				CinemachineBrain cinemachineBrain = (flag3 ? UnityEngine.Object.FindObjectOfType<CinemachineBrain>() : null);
				CinemachineBlendDefinition.Style previousBlendStyle = CinemachineBlendDefinition.Style.EaseInOut;
				float previousBlendTime = 0f;
				if (flag3 && cinemachineBrain != null)
				{
					flag4 = !hasRecordedBlendMode;
					hasRecordedBlendMode = true;
					previousBlendStyle = cinemachineBrain.m_DefaultBlend.m_Style;
					previousBlendTime = cinemachineBrain.m_DefaultBlend.m_Time;
					cinemachineBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
					cinemachineBrain.m_DefaultBlend.m_Time = 0f;
					cinemachineBrain.enabled = false;
				}
				if (flag)
				{
					CinemachineVirtualCamera[] array = UnityEngine.Object.FindObjectsOfType<CinemachineVirtualCamera>();
					foreach (CinemachineVirtualCamera cinemachineVirtualCamera2 in array)
					{
						if (!flag2 || !string.Equals(cinemachineVirtualCamera2.name, b))
						{
							cinemachineVirtualCamera2.Priority = parameterAsInt;
							if (flag3)
							{
								cinemachineVirtualCamera2.enabled = false;
								cinemachineVirtualCamera2.enabled = true;
							}
						}
					}
				}
				else
				{
					cinemachineVirtualCamera.Priority = parameterAsInt;
					if (flag3)
					{
						cinemachineVirtualCamera.enabled = false;
						cinemachineVirtualCamera.enabled = true;
					}
				}
				if (flag3 && cinemachineBrain != null)
				{
					cinemachineBrain.enabled = true;
					if (flag4)
					{
						yield return null;
						cinemachineBrain.m_DefaultBlend.m_Style = previousBlendStyle;
						cinemachineBrain.m_DefaultBlend.m_Time = previousBlendTime;
						hasRecordedBlendMode = false;
					}
				}
			}
			Stop();
		}
	}
}
