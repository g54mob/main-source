using UnityEngine;

namespace DV.CabControls
{
	public abstract class AReactionOnControlChange : MonoBehaviour
	{
		private ControlImplBase ctrl;

		private void Start()
		{
			ctrl = GetComponent<ControlImplBase>();
			if (ctrl == null)
			{
				Debug.LogError("Unexpected state: " + base.gameObject.GetPath() + " doesn't have ControlImplBase");
			}
			else
			{
				ctrl.ValueChanged += OnValueChanged;
			}
		}

		private void OnDestroy()
		{
			if (ctrl != null)
			{
				ctrl.ValueChanged -= OnValueChanged;
			}
		}

		protected abstract void OnValueChanged(ValueChangedEventArgs obj);
	}
}
