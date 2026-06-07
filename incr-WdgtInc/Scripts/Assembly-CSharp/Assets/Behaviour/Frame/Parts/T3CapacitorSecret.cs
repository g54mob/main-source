using Assets.Behaviour.UI;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T3CapacitorSecret : MonoBehaviour
	{
		[SerializeField]
		private SecretButtonSlider _secretSlider;

		[SerializeField]
		private Interactable _secretInteractable;

		[SerializeField]
		private SecretButton _button;

		private ActiveWorldFrame _frame;

		private void Start()
		{
			_frame = GetComponent<ActiveWorldFrame>();
			_button.SetActive(active: false);
		}

		private void Update()
		{
			if (_frame.ActiveFrame != null)
			{
				bool flag = ((T3CapacitorWidget)_frame.ActiveFrame).OutputVoltage == 15;
				_secretSlider.enabled = flag;
				_secretInteractable.enabled = flag;
			}
		}
	}
}
