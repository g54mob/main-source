using UnityEngine;

public class ConversationSystem : MonoBehaviour
{
	private ConvoController controllerRef;

	public void StartNewConversation(TextAsset newConvoAsset, GameObject existingTemplate = null)
	{
		controllerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConvoController>(GlobalObject.CONVO_CONTROLLER);
		controllerRef.InitializeConversation(newConvoAsset, this, existingTemplate);
	}

	public void SetTemplateUnloadCallback(ConvoController.TemplateUnloadCallback callback)
	{
		controllerRef.SetTemplateUnloadCallback(callback);
	}
}
