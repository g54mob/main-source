using UnityEngine;

namespace CTS
{
	public class SituationnalBarks_CustomerHuman : SituationnalBarks_Customer
	{
		[SerializeField]
		private SituationlBarkSO _inCell;

		[SerializeField]
		private SituationlBarkSO _moveToToilet;

		[SerializeField]
		private SituationlBarkSO _goOutToilet;

		public void MoveToilet()
		{
			CalLSO(_moveToToilet);
		}

		public void GoOuttoilet()
		{
			CalLSO(_goOutToilet);
		}

		public void Cellule()
		{
			CalLSO(_inCell);
		}
	}
}
