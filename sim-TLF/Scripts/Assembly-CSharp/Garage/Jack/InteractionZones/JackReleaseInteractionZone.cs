using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using UI.HUD;
using UnityEngine;

namespace Garage.Jack.InteractionZones
{
	public class JackReleaseInteractionZone : MonoBehaviour
	{
		[SerializeField]
		private EngineJackView _view;

		private InfoCursorsViewModel _infoCursorViewModel;

		private void Start()
		{
			_infoCursorViewModel = Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
		}

		private void OnTriggerEnter(Collider other)
		{
			EngineJackViewModel engineJackViewModel = _view.GetDataContext() as EngineJackViewModel;
			_ = _view.JackedObject != null;
			_infoCursorViewModel.EnableUseHintSeperately(value: true, "To Release");
			_infoCursorViewModel.SetUseExtraText("To Release");
			Debug.Log($"On Trigger Enter; can interact: {engineJackViewModel.CanManipulte.Value}");
			engineJackViewModel.PlayerInReleaseZone.Value = true;
		}

		private void OnTriggerExit(Collider other)
		{
			EngineJackViewModel obj = _view.GetDataContext() as EngineJackViewModel;
			_infoCursorViewModel.SetUseExtraText(string.Empty);
			_infoCursorViewModel.EnableUseHintSeperately(value: false);
			Debug.Log("On Trigger Exit");
			obj.PlayerInReleaseZone.Value = false;
		}
	}
}
