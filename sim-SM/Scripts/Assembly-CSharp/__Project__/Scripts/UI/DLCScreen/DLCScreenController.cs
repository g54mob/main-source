using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.UI.DLCScreen
{
	public class DLCScreenController : MonoBehaviour
	{
		[SerializeField]
		private Button m_DLCButton;

		[SerializeField]
		private Image m_DLCFadeoutImage;

		[SerializeField]
		private List<Sprite> m_DLCImages;

		[SerializeField]
		private List<int> m_DLCAppIds;

		private int m_CurrentDLCIndex;

		private int m_CurrentDLCAppId;

		private Sprite m_CurrentDLCImage;

		private List<Tween> m_TweenList;

		public void SwitchDLC(bool isLeft)
		{
		}

		public void OpenDLCPage()
		{
		}
	}
}
