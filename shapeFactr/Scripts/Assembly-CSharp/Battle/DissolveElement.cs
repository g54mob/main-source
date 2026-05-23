using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	public class DissolveElement : MonoBehaviour
	{
		public bool changeColorAfterDissolve;

		public float blendDuration;

		public bool ignoreCollect;

		public float defaultEdge;

		private Material _material;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void PlayDissolve(ref Sequence sequence, float duration, bool isReverse = false, UnityAction callback = null)
		{
		}

		public void PlayChangeColor(float end, bool reset = false)
		{
		}

		public void PlayChangeColor(ref Sequence sequence)
		{
		}

		public void SetSprite(Sprite sprite)
		{
		}

		public void SetMainTex(Texture texture)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
