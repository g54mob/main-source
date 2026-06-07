using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using NGenerics.Extensions;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class LoadDroneBrowser : MonoBehaviour
	{
		public UILabel Text;

		public UITexture Icon;

		public Color NormalTextColor;

		public Color DisabledTextColor;

		private UIButton[] _buttons;

		private bool _wasConnected;

		public void Start()
		{
			_buttons = GetComponents<UIButton>();
			_wasConnected = true;
		}

		public void OnClick()
		{
			if (SteamManager.Connected)
			{
				NimbatusSceneManager.LoadScene("DroneBrowserScene");
			}
		}

		public void Update()
		{
			if (!SteamManager.Connected && _wasConnected)
			{
				_wasConnected = false;
				_buttons.ForEach(delegate(UIButton b)
				{
					b.enabled = false;
				});
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
				Text.color = DisabledTextColor;
				Icon.color = DisabledTextColor;
			}
			else if (!_wasConnected && SteamManager.Connected)
			{
				_wasConnected = true;
				_buttons.ForEach(delegate(UIButton b)
				{
					b.enabled = true;
				});
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Normal, true);
				});
				Text.color = NormalTextColor;
				Icon.color = NormalTextColor;
			}
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				if (!SteamManager.Connected)
				{
					NimbatusToolTip.Show("Not connected to Steam");
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
