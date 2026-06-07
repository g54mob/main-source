using Battle;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(Button))]
	public class SceneFocusButton : MonoBehaviour
	{
		[Label("アニメーション秒数")]
		public float transitionDuration;

		[Label("高さ")]
		public float upHeight;

		private void Awake()
		{
		}

		public void OnSwitchScene()
		{
		}
	}
}
