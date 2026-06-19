using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ModMenu : AnimatedMenuBase
	{
		public interface ILocalModProvider
		{
			string CategoryNameTag { get; }
		}

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private DynamicButton _closeButton;

		private InputManager _inputManager;

		private ILocalModProvider[] _localModProviders;

		public void Initialise(App app)
		{
			_inputManager = app.InputManager;
			_inputManager.AddGraphicRayCaster(_graphicRaycaster);
			_closeButton.onPrimaryDown.AddListener(CloseMenu);
		}

		public override void Destroy()
		{
			_inputManager.RemoveGraphicRayCaster(_graphicRaycaster);
		}
	}
}
