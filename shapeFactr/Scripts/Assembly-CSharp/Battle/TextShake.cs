using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Battle
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TextShake : MonoBehaviour
	{
		private DOTweenTMPAnimator _animator;

		private TextMeshProUGUI _textMesh;

		public bool PlayShake { get; private set; }

		public void StartShake()
		{
		}

		private void OnDisable()
		{
		}
	}
}
