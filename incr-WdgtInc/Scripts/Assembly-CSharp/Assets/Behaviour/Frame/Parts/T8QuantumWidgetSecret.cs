using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T8QuantumWidgetSecret : MonoBehaviour
	{
		[SerializeField]
		private T8QuantumWidgetSecretGem[] gems;

		private ActiveWorldFrame _frame;

		private void Awake()
		{
			_frame = GetComponent<ActiveWorldFrame>();
		}

		private void Update()
		{
			if (_frame.ActiveFrame != null && _frame.ActiveFrame.IsFullyUpgraded())
			{
				T8QuantumWidgetSecretGem[] array = gems;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].gameObject.SetActive(value: true);
				}
				base.enabled = false;
			}
		}
	}
}
