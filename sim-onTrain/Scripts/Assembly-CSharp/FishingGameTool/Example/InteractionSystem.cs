using FishingGameTool.CustomAttribute;
using UnityEngine;

namespace FishingGameTool.Example
{
	public class InteractionSystem : MonoBehaviour
	{
		[BetterHeader("Interaction System Settings", 20)]
		public float _interactionRadius = 2f;

		public LayerMask _interactionLayerMask;

		[Space]
		[BetterHeader("Interaction UI Settings", 20)]
		public GameObject _interactionMark;

		private bool _showInteractionMark;

		private CharacterMovement _characterMovement;

		private void Awake()
		{
			_characterMovement = GetComponent<CharacterMovement>();
		}

		private void Update()
		{
			HandleInteractionSystem();
		}

		private void HandleInteractionSystem()
		{
			Collider[] array = Physics.OverlapSphere(base.transform.position, _interactionRadius, _interactionLayerMask);
			if (array.Length == 0)
			{
				_interactionMark.SetActive(value: false);
			}
			for (int i = 0; i < array.Length; i++)
			{
				_showInteractionMark = ShowInteractionMark(array[i].gameObject);
				if (_showInteractionMark)
				{
					if (Input.GetKeyDown(KeyCode.E))
					{
						array[i].gameObject.GetComponent<InteractionHandler>().InvokeEvents();
					}
					HandleInteractionMark(_interactionMark, array[i].gameObject.transform.position, _showInteractionMark);
					break;
				}
				HandleInteractionMark(_interactionMark, array[i].gameObject.transform.position, _showInteractionMark);
			}
		}

		private void HandleInteractionMark(GameObject interactionMark, Vector3 interactionObjectPos, bool showMark)
		{
			if (!showMark)
			{
				interactionMark.SetActive(value: false);
				return;
			}
			interactionMark.transform.position = interactionObjectPos;
			interactionMark.transform.rotation = Quaternion.LookRotation(interactionObjectPos - _characterMovement.GetCurrentCam().position);
			interactionMark.SetActive(value: true);
		}

		private bool ShowInteractionMark(GameObject interactionObject)
		{
			float num = 25f;
			if (Vector3.Angle(interactionObject.transform.position - _characterMovement.GetCurrentCam().position, _characterMovement.GetCurrentCam().forward) < num)
			{
				return true;
			}
			return false;
		}
	}
}
