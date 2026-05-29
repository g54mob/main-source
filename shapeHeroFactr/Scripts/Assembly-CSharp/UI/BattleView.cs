using Libs;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class BattleView : SingletonMonoBehaviour<BattleView>
	{
		[SerializeField]
		private RenderTexture _battleViewTexture;

		[SerializeField]
		private RawImage _viewImage;

		[SerializeField]
		private Canvas _canvas;

		private Camera _battleCamera;

		private bool _isDisplay;

		private bool _isRedy;

		private bool _debugToggle;

		public bool IsDisplay
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool DebugToggle
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void Init()
		{
		}

		public void RenderBattleView()
		{
		}

		public void SwitchDisplay(bool on)
		{
		}
	}
}
