using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	public class UIToolkitDemo : MonoBehaviour
	{
		public Texture2D FaceTexture;

		public List<UIToolkitDemoAction> Actions;

		private Button _button;

		private void OnEnable()
		{
			VisualElement rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
			rootVisualElement.Q<VisualElement>("DemoFace").style.backgroundImage = FaceTexture;
			foreach (UIToolkitDemoAction action in Actions)
			{
				_button = rootVisualElement.Q<Button>(action.ButtonName);
				_button.text = _button.text.ToUpper();
				_button.RegisterCallback<ClickEvent>(delegate
				{
					PlayFeedback(action.TargetPlayer);
				});
			}
		}

		private void PlayFeedback(MMF_Player player)
		{
			player.PlayFeedbacks();
		}
	}
}
