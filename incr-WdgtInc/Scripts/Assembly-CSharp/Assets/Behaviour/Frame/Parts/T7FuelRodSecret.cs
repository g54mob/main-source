using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7FuelRodSecret : MonoBehaviour
	{
		[SerializeField]
		private Transform _buttonTrigger;

		private ActiveWorldFrame _frame;

		private void Start()
		{
			_frame = GetComponent<ActiveWorldFrame>();
		}

		private void Update()
		{
			if (_frame.ActiveFrame != null && _frame.ActiveFrame.IsFullyUpgraded())
			{
				_buttonTrigger.gameObject.SetActive(value: true);
				base.enabled = false;
			}
		}
	}
}
