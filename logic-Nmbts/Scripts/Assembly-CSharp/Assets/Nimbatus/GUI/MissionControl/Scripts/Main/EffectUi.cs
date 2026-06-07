using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class EffectUi : MonoBehaviour
	{
		public UITexture Icon;

		private DroneEffect _effect;

		private bool _active;

		public void Init(DroneEffect effect, bool active)
		{
			_effect = effect;
			_active = active;
			Icon.mainTexture = _effect.GetIcon();
		}

		public void OnTooltip(bool show)
		{
			if (_effect != null)
			{
				NimbatusToolTip.Show(show ? _effect.GetDescription() : null);
			}
		}

		public void OnClick()
		{
			if (RuntimeGlobals.GameMode == EGameMode.Creative)
			{
				_active = !_active;
				if (_active)
				{
					SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.AddEffect(_effect);
				}
				else
				{
					SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.RemoveEffectOfType(_effect.EffectType);
				}
			}
		}

		public void Update()
		{
			Color color = Icon.color;
			color.a = (_active ? 1f : 0.3f);
			Icon.color = color;
		}
	}
}
