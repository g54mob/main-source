using UnityEngine;

public class InGameResignUIHelper : MonoBehaviour
{
	public void Resign()
	{
		try
		{
			Debug.Log("Resign");
			UIFrameManager.instance.CloseAllFrames();
			LocalGamestate.Instance.SetState(LocalGamestate.State.AfterMatchDefeat, forceTransition: false, immediate: true);
		}
		catch
		{
			Debug.Log("Error in InGameResignUIHelper: Bro we can not resign here.");
		}
	}
}
