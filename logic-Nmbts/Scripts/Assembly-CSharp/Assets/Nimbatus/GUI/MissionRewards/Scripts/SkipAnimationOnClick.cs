using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class SkipAnimationOnClick : MonoBehaviour
	{
		public MissionSuccessPanel SuccessPanel;

		public void Click()
		{
			SuccessPanel.SkipAnimation();
		}
	}
}
