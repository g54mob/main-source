using System;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI
{
	public class ButtonUI : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Button _button;

		private int _id;

		public Action<int> OnSelect;

		public Button Button => null;

		public void Initialize(int id)
		{
		}
	}
}
