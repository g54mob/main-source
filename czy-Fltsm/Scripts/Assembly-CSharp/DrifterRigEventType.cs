using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Drifter Rig Event Type")]
public class DrifterRigEventType : ScriptableObject
{
	public AnimationTools AnimationTools { get; private set; }

	public void Dispatch(AnimationTools animationTools)
	{
		if (animationTools.DrifterRigEvent != null)
		{
			AnimationTools = animationTools;
			AnimationTools.DrifterRigTypeEvent.Invoke(this);
		}
	}
}
