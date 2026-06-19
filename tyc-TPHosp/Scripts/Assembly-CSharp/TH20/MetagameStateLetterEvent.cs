using System;

namespace TH20
{
	public class MetagameStateLetterEvent : MetagameState
	{
		private OpenLetterMenu.Definition _definition;

		private OpenLetterMenu _menu;

		private Action _extraButtonAction;

		public MetagameStateLetterEvent(MetagameMap map, OpenLetterMenu.Definition definition, Action extraButtonAction = null)
			: base(map)
		{
			_definition = definition;
			_extraButtonAction = extraButtonAction;
		}

		public override void Enter()
		{
			MetagameMap.CameraLogic.SetFixedTransform(MetagameMap.CameraLogic.CameraComponent.transform);
			_menu = MetagameMap.HUD.FindMenu<OpenLetterMenu>();
			if (_menu == null)
			{
				_menu = MetagameMap.HUD.CreateMenu<OpenLetterMenu>();
			}
			_menu.Setup(_definition, _extraButtonAction);
		}

		public override void Update()
		{
			if (_menu.IsClosed())
			{
				PopState();
			}
		}

		public override void Exit()
		{
			MetagameMap.CameraLogic.SetFixedTransform(null);
		}
	}
}
