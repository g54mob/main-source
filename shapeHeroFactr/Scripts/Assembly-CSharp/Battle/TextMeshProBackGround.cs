using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TextMeshProBackGround : MonoBehaviour
	{
		private const float Tolerance = 1E-05f;

		[SerializeField]
		private Image image;

		[SerializeField]
		private float paddingWidth;

		[SerializeField]
		private float paddingHeight;

		private TextMeshProUGUI _tmp;

		private float _preWidth;

		private float _preHeight;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateTMProUGUISizeDelta()
		{
		}

		private void UpdateImageSizeDelta()
		{
		}
	}
}
