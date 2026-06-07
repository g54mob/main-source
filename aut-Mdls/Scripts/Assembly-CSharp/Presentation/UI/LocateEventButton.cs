using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class LocateEventButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private ReferenceFactoryObjectBehaviour _referenceBehaviour;

		[SerializeField]
		private ReferenceObjectDatabase _referenceObjectDatabase;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		private void Awake()
		{
			_button.onClick.AddListener(OnButtonClicked);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		private void OnButtonClicked()
		{
			if (_referenceObjectDatabase.TryGetObjectFromReferenceID(_referenceBehaviour.ManuallySetReferenceID, out var referenceObject))
			{
				_cameraViewLocator.CameraView.LerpToTarget(referenceObject.Position, blockInput: false);
			}
		}

		private void Reset()
		{
			TryGetComponent<Button>(out _button);
		}
	}
}
