using Assets.Behaviour.UI;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T2SandSecret : MonoBehaviour
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
				bool flag = _frame.ActiveFrame.IsFullyUpgraded();
				_secretSlider.enabled = flag;
				_secretInteractable.enabled = flag;
			}
		}
	}
}
