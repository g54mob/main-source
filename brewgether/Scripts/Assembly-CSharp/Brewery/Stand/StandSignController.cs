using HighlightPlus;
using UnityEngine;

namespace Brewery.Stand
{
	public class StandSignController : MonoBehaviour
	{
		[Header("Sign Letters")]
		[SerializeField]
		private HighlightEffect[] signLetters;

		[Header("Sign Light")]
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
