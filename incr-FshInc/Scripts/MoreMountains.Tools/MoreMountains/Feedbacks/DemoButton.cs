using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[ExecuteAlways]
	[AddComponentMenu("")]
	public class DemoButton : MonoBehaviour
	{
		[Header("Behaviour")]
		public bool NotSupportedInWebGL;

		[Header("Bindings")]
		public Button TargetButton;

		public Text ButtonText;

		public Text WebGL;

		public MMF_Player TargetMMF_Player;

		protected Color _disabledColor = new Color(255f, 255f, 255f, 0.5f);

		protected virtual void OnEnable()
		{
			HandleWebGL();
			TargetButton.onClick.AddListener(OnClickEvent);
		}

		protected void OnDisable()
		{
			TargetButton.onClick.RemoveListener(OnClickEvent);
		}

		public void OnClickEvent()
		{
			TargetMMF_Player?.PlayFeedbacks();
		}

		protected virtual void HandleWebGL()
		{
			if (WebGL != null)
			{
				WebGL.gameObject.SetActive(value: false);
				TargetButton.interactable = true;
				ButtonText.color = Color.white;
			}
		}
	}
}
