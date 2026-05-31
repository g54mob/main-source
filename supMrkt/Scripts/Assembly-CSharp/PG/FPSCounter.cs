using TMPro;
using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class FPSCounter : MonoBehaviour
	{
		[SerializeField]
		private float UpdateTime;

		private TextMeshProUGUI Text;

		private int FpsCount;

		private float Timer;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
