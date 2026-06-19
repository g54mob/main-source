using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MateoRyhr
{
	[RequireComponent(typeof(InputEnabler))]
	public class BasicInput : MonoBehaviour, IBaseInputActions
	{
		[SerializeField]
		protected InputActionAsset _actionAsset;

		[SerializeField]
		protected int _actionMapNumber;

		[SerializeField]
		protected int _actionNumber;

		public UnityEvent OnStarted;

		public UnityEvent OnCanceled;

		public UnityEvent OnPerformed;

		public void OnInputStarted(InputAction.CallbackContext data)
		{
			OnStarted?.Invoke();
		}

		public void OnInputPerformed(InputAction.CallbackContext data)
		{
			OnPerformed?.Invoke();
		}

		public void OnInputCanceled(InputAction.CallbackContext data)
		{
			OnCanceled?.Invoke();
		}

		public void SuscribeInputs()
		{
			_actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].started += OnInputStarted;
			_actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].performed += OnInputPerformed;
			_actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].canceled += OnInputCanceled;
		}

		public void UnsubscribeInputs()
		{
			_actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].started -= OnInputStarted;
			_actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].performed -= OnInputPerformed;
			_actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].canceled -= OnInputCanceled;
		}
	}
}
