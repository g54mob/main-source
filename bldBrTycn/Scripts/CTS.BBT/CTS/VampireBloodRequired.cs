using CTS.BBT.AI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class VampireBloodRequired : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _bloodLevel;

		public void SetText(Customer agent)
		{
			_bloodLevel.text = agent.BloodQuality.ToString();
		}
	}
}
