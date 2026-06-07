using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T4PlasticSecret : MonoBehaviour
	{
		[SerializeField]
		private SecretButton _button;

		[SerializeField]
		private Transform _buttonContainer;

		private ActiveWorldFrame _frame;

		private void Start()
		{
			_frame = GetComponent<ActiveWorldFrame>();
			_button.SetActive(active: false);
		}

		public void ButtonClicked()
		{
			if (((T4Plastic)_frame.ActiveFrame).Charge == 10.1f)
			{
				float num = Mathf.Min(4.32f, _buttonContainer.transform.localPosition.y + 0.1f);
				_buttonContainer.localPosition = new Vector3(_buttonContainer.localPosition.x, num, _buttonContainer.localPosition.z);
				if (num == 4.32f)
				{
					_button.SetActive(active: true);
				}
			}
		}
	}
}
