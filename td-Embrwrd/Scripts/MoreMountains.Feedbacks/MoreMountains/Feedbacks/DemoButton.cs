using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[ExecuteAlways]
	public class DemoButton : MonoBehaviour
	{
		[Header("Behaviour")]
		public bool NotSupportedInWebGL;

		[Header("Bindings")]
		public Button TargetButton;

		public Text ButtonText;

		public Text WebGL;

		public MMF_Player TargetMMF_Player;

		public MMFeedbacks TargetMMFeedbacks;

		protected Color _disabledColor;

		protected virtual void OnEnable()
		{
		}

		protected virtual void ConvertButtonToMMFPlayerDemo()
		{
		}

		public void OnClickEvent()
		{
		}

		protected virtual void HandleWebGL()
		{
		}
	}
}
