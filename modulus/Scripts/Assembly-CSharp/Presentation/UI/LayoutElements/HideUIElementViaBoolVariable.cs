using Data.Variables;
using UnityEngine;

namespace Presentation.UI.LayoutElements
{
	public class HideUIElementViaBoolVariable : MonoBehaviour
	{
		[SerializeField]
		private BoolVariableSO _boolVariable;

		private void Start()
		{
			HandleValueChanged(_boolVariable.Value);
			_boolVariable.ValueChanged += HandleValueChanged;
		}

		private void OnDestroy()
		{
			_boolVariable.ValueChanged -= HandleValueChanged;
		}

		private void HandleValueChanged(bool state)
		{
			base.gameObject.SetActive(state);
		}
	}
}
