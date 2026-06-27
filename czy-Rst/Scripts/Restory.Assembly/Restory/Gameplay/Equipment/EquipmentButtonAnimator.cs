using Restory.SimpleTweeners;
using UnityEngine;

namespace Restory.Gameplay.Equipment
{
	public class EquipmentButtonAnimator : MonoBehaviour
	{
		[SerializeField]
		private ClickableTrigger clickableTrigger;

		[SerializeField]
		private SimpleTweenerBase buttonTweener;

		private void OnEnable()
		{
			clickableTrigger.OnClick += ResolveButtonClick;
		}

		private void OnDisable()
		{
			clickableTrigger.OnClick -= ResolveButtonClick;
		}

		private void ResolveButtonClick()
		{
			buttonTweener.Play();
		}
	}
}
