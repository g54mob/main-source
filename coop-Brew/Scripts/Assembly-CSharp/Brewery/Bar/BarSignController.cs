using HighlightPlus;
using UnityEngine;

namespace Brewery.Bar
{
	public class BarSignController : MonoBehaviour
	{
		[Header("Sign Letters")]
		[Tooltip("HighlightEffect components on the BAR sign letters")]
		[SerializeField]
		private HighlightEffect[] signLetters;

		[Header("Sign Light")]
		[Tooltip("Optional light that illuminates when sign is on")]
		[SerializeField]
		private Light signLight;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void UpdateSign(bool isOpen)
		{
		}
	}
}
