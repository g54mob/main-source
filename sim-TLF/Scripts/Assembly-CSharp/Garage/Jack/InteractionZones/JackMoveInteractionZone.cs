using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using UI.HUD;
using UnityEngine;

namespace Garage.Jack.InteractionZones
{
	public class JackMoveInteractionZone : MonoBehaviour
	{
		[SerializeField]
		private EngineJackView _view;

		private InfoCursorsViewModel _infoCursorsViewModel;

		private void Start()
		{
			_infoCursorsViewModel = Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
		}

		private void OnTriggerEnter(Collider other)
		{
			EngineJackViewModel engineJackViewModel = _view.GetDataContext() as EngineJackViewModel;
			engineJackViewModel.CanManipulte.Value = true;
			Debug.Log($"On Trigger Enter; can interact: {engineJackViewModel.CanManipulte.Value}");
			_infoCursorsViewModel.EnableUseHintSeperately(value: true, "Manipulate Jack");
			_infoCursorsViewModel.SetUseExtraText("Manipulate Jack");
		}

		private void OnTriggerExit(Collider other)
		{
			(_view.GetDataContext() as EngineJackViewModel).CanManipulte.Value = false;
			Debug.Log("On Trigger Exit");
			_infoCursorsViewModel.SetUseExtraText(string.Empty);
			_infoCursorsViewModel.EnableUseHintSeperately(value: false);
		}
	}
}
