using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI
{
	public class SlotMachineController : MonoBehaviour
	{
		[SerializeField]
		private Animator[] _animators;

		[SerializeField]
		private float _nbAnimationTime;

		[SerializeField]
		private Button _btnTurnSlotMachine;

		[SerializeField]
		private Image _imgTurnDownHandle;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void TurnSlotMachine()
		{
		}

		private void StopLeftSlotAnimation()
		{
		}

		private void StopMiddleSlotAnimation()
		{
		}

		private void StopRightSlotAnimation()
		{
		}
	}
}
