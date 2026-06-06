using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.Onboarding
{
	[CreateAssetMenu(menuName = "Flotsam/TutorialTrigger")]
	public class TutorialTrigger : ScriptableObject
	{
		[SerializeReference]
		[InstantiateSerializeReference]
		private TutorialNotificationTriggerBase[] _triggerActions;

		public void Initialize()
		{
			TutorialNotificationTriggerBase[] triggerActions = _triggerActions;
			foreach (TutorialNotificationTriggerBase obj in triggerActions)
			{
				obj.Initialize(obj.WasTriggered);
			}
		}

		public void Reset()
		{
			TutorialNotificationTriggerBase[] triggerActions = _triggerActions;
			for (int i = 0; i < triggerActions.Length; i++)
			{
				triggerActions[i].SetTriggered(triggered: false);
			}
		}

		public void Update()
		{
			TutorialNotificationTriggerBase[] triggerActions = _triggerActions;
			foreach (TutorialNotificationTriggerBase tutorialNotificationTriggerBase in triggerActions)
			{
				if (!tutorialNotificationTriggerBase.WasTriggered)
				{
					tutorialNotificationTriggerBase.Update();
				}
			}
		}

		public void PopulateTriggeredTutorials(List<int> triggeredTutorialIDs)
		{
			TutorialNotificationTriggerBase[] triggerActions = _triggerActions;
			foreach (TutorialNotificationTriggerBase tutorialNotificationTriggerBase in triggerActions)
			{
				if (tutorialNotificationTriggerBase.WasTriggered)
				{
					triggeredTutorialIDs.Add((int)tutorialNotificationTriggerBase.ID);
				}
			}
		}

		public void RestoreTriggeredTutorials(IReadOnlyList<int> triggeredTutorialsIDs)
		{
			foreach (int triggeredTutorialsID in triggeredTutorialsIDs)
			{
				TutorialNotificationTriggerBase[] triggerActions = _triggerActions;
				foreach (TutorialNotificationTriggerBase tutorialNotificationTriggerBase in triggerActions)
				{
					if (tutorialNotificationTriggerBase.ID == (TutorialID)triggeredTutorialsID)
					{
						tutorialNotificationTriggerBase.SetTriggered(triggered: true);
						break;
					}
				}
			}
		}
	}
}
