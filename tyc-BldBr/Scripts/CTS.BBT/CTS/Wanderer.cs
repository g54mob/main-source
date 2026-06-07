using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class Wanderer : MonoBehaviour
	{
		[ShowNonSerializedField]
		private static int _totalInGame;

		public static int TotalInGame => _totalInGame;

		private void OnDisable()
		{
			_totalInGame--;
		}

		private void OnEnable()
		{
			_totalInGame++;
		}
	}
}
