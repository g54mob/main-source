using System.Collections;
using UnityEngine;

namespace MalbersAnimations
{
	public class PlayTransformAnimation : MonoBehaviour
	{
		[ExposeScriptableAsset]
		public TransformAnimation anim;

		public Transform m_transform;

		public bool PlayOnStart = true;

		public bool PlayForever;

		internal IEnumerator ICoroutine;

		[SerializeField]
		[ContextMenuItem("Store starting value", "StoreDefault")]
		private TransformOffset DefaultValue;

		private void Awake()
		{
			StoreDefault();
		}

		[ContextMenu("Store starting value")]
		private void StoreDefault()
		{
			DefaultValue = new TransformOffset(m_transform);
		}

		private void OnEnable()
		{
			StopAllCoroutines();
			anim.CleanCoroutine();
			DefaultValue.RestoreTransform(m_transform);
			if (PlayOnStart)
			{
				Play();
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
			anim.CleanCoroutine();
		}

		public void Play()
		{
			if (base.isActiveAndEnabled)
			{
				if (ICoroutine != null)
				{
					DefaultValue.RestoreTransform(m_transform);
					StopCoroutine(ICoroutine);
				}
				if (PlayForever)
				{
					ICoroutine = anim.PlayTransformAnimationForever(m_transform);
				}
				else
				{
					ICoroutine = anim.PlayTransformAnimation(m_transform);
				}
				StartCoroutine(ICoroutine);
			}
		}
	}
}
