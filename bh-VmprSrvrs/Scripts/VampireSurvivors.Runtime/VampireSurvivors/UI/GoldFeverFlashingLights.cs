using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class GoldFeverFlashingLights : MonoBehaviour
	{
		[SerializeField]
		private List<Image> _Lights;

		[SerializeField]
		private List<Sprite> _Sprites;

		private List<Tween> _tweens;

		private void Awake()
		{
		}

		public void Show()
		{
		}

		public void Exit()
		{
		}
	}
}
