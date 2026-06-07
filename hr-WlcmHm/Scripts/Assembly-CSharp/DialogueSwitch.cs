using UnityEngine;

public class DialogueSwitch : MonoBehaviour
{
	private NPCBaseController[] baseControllers;

	private void Start()
	{
		if (GetComponents<NPCBaseController>() != null)
		{
			baseControllers = GetComponents<NPCBaseController>();
			baseControllers[0].enabled = true;
			baseControllers[1].enabled = false;
		}
	}

	private void Update()
	{
	}

	public void ChangeDialogue()
	{
		if (baseControllers != null)
		{
			baseControllers[0].enabled = false;
			baseControllers[1].enabled = true;
		}
	}
}
