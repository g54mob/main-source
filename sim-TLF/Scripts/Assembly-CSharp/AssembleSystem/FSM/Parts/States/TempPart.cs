using UnityEngine;

namespace AssembleSystem.FSM.Parts.States
{
	public class TempPart : MonoBehaviour, ITempPart
	{
		[SerializeField]
		private PartObject _mainPart;

		PartObject ITempPart.MainPart => _mainPart;

		public void Init(PartObject mainPart)
		{
			_mainPart = mainPart;
		}
	}
}
