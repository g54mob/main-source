using UnityEngine;

namespace __Project__.Scripts.BakeryWorker
{
	[CreateAssetMenu(fileName = "BakerSO", menuName = "Scriptable Objects/Employees/BakerSO")]
	public class BakerSO : ScriptableObject
	{
		public int ID;

		public float DailyWage;

		public float HiringCost;

		public Baker BakerPrefab;
	}
}
