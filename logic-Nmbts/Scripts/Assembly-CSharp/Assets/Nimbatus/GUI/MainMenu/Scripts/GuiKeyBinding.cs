using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class GuiKeyBinding : SerializedMonoBehaviour
	{
		public bool CheckTween;

		[ShowIf("CheckTween", true)]
		public TweenPosition Tween;

		[ShowIf("CheckTween", true)]
		public bool CheckTo;

		public bool DeactivateOnTutorial;

		public KeyCode Key = KeyCode.Escape;

		public void Update()
		{
			if ((DeactivateOnTutorial && RuntimeGlobals.GameModeSettings.InCampaignTutorial) || !Input.GetKeyDown(Key))
			{
				return;
			}
			if (CheckTween)
			{
				if (Tween != null && ((CheckTo && Tween.to == Tween.value) || (!CheckTo && Tween.from == Tween.value)))
				{
					base.gameObject.SendMessage("OnClick", null, SendMessageOptions.DontRequireReceiver);
				}
			}
			else
			{
				base.gameObject.SendMessage("OnClick", null, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
