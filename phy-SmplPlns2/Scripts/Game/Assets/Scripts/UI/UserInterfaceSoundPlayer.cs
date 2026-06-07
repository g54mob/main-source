using System.Collections.Generic;
using Jundroo.Juicy;
using Jundroo.Juicy.Helpers;
using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class UserInterfaceSoundPlayer
	{
		private WidgetContext _context;

		private Dictionary<UISound, SoundData> _map;

		public void OnRootContextLoaded(WidgetContext context)
		{
			_context = context;
			_map = new Dictionary<UISound, SoundData>();
			_map[UISound.ActivityStart] = GetSoundData("SoundActivityStart");
			_map[UISound.ActivityEnd] = GetSoundData("SoundActivityEnd");
			_map[UISound.ButtonClick] = GetSoundData("SoundButtonClick");
			_map[UISound.ButtonClickBig] = GetSoundData("SoundButtonClickBig");
			_map[UISound.DesignerConnectPart] = GetSoundData("SoundDesignerConnectPart");
			_map[UISound.DesignerDelete] = GetSoundData("SoundDesignerDelete");
			_map[UISound.DesignerDetachPart] = GetSoundData("SoundDesignerDetachPart");
			_map[UISound.DesignerDragPart] = GetSoundData("SoundDesignerDragPart");
			_map[UISound.DesignerDragPartPositionError] = GetSoundData("SoundDesignerDragPartPositionError");
			_map[UISound.DesignerDropPart] = GetSoundData("SoundDesignerDropPart");
			_map[UISound.DesignerGizmoClick] = GetSoundData("SoundDesignerGizmoClick");
			_map[UISound.DesignerGizmoHover] = GetSoundData("SoundDesignerGizmoHover");
			_map[UISound.DesignerGizmoRelease] = GetSoundData("SoundDesignerGizmoRelease");
			_map[UISound.DesignerHoverPart] = GetSoundData("SoundDesignerHoverPart");
			_map[UISound.DesignerPlacePartError] = GetSoundData("SoundDesignerPlacePartError");
			_map[UISound.DesignerResize] = GetSoundData("SoundDesignerResize");
			_map[UISound.DesignerSelectPart] = GetSoundData("SoundDesignerSelectPart");
			_map[UISound.DesignerSprayPaint] = GetSoundData("SoundDesignerSprayPaint");
			_map[UISound.DesignerSprayPaintFailed] = GetSoundData("SoundDesignerSprayPaintFailed");
			_map[UISound.DesignerStartGizmoTool] = GetSoundData("SoundDesignerStartGizmoTool");
			_map[UISound.DesignerStep] = GetSoundData("SoundDesignerStep");
			_map[UISound.DiscoverLocation] = GetSoundData("SoundDiscoverLocation");
			_map[UISound.FlyoutClosed] = GetSoundData("SoundFlyoutClosed");
			_map[UISound.FlyoutOpened] = GetSoundData("SoundFlyoutOpened");
			_map[UISound.Fuselage] = GetSoundData("SoundFuselage");
			_map[UISound.Hover] = GetSoundData("SoundHover");
			_map[UISound.LevelLose] = GetSoundData("SoundLevelLose");
			_map[UISound.LevelWin] = GetSoundData("SoundLevelWin");
			_map[UISound.RingFailed] = GetSoundData("SoundRingFailed");
			_map[UISound.RingPassed] = GetSoundData("SoundRingPassed");
			_map[UISound.SliderChanged] = GetSoundData("SoundSliderChanged");
		}

		public void OnSceneUnloaded()
		{
			_context = null;
		}

		public void PlaySound(UISound sound, float volumeMultiplier = 1f)
		{
			if (_map.TryGetValue(sound, out var value))
			{
				_context.PlaySound(value, volumeMultiplier);
			}
			else
			{
				Debug.LogError($"Could not find sound constant for UI sound '{sound}'");
			}
		}

		private SoundData GetSoundData(string constantName)
		{
			string constant = _context.Root.Stylesheet.GetConstant(constantName);
			if (constant != null)
			{
				return StringParser.ToSoundData(constant);
			}
			Debug.LogError("Could not find sound constant: " + constantName);
			return null;
		}
	}
}
