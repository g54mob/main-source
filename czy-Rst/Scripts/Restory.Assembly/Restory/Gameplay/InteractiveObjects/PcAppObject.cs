using Restory.Data.PC;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class PcAppObject : PersonalObjectBase
	{
		[SerializeField]
		private PcAppInfo info;

		public PcAppInfo Info => info;
	}
}
