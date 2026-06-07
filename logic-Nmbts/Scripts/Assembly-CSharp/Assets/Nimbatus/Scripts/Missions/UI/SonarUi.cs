using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions.UI
{
	public class SonarUi : MonoBehaviour
	{
		public tk2dSprite Sprite;

		private Vector3 _originalScale;

		private Color _orignalColor;

		public void Start()
		{
			_originalScale = Sprite.scale;
			_orignalColor = Sprite.color;
			StartCoroutine(TweenAlphaAndScale());
		}

		private IEnumerator TweenAlphaAndScale()
		{
			while (true)
			{
				Sprite.DOFade(0f, 2f);
				Sprite.DOScale(Vector3.one * 5f, 2f);
				yield return new WaitForSeconds(2.1f);
				Sprite.color = _orignalColor;
				Sprite.scale = _originalScale;
			}
		}
	}
}
