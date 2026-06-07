using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShatterStone
{
	public class ShatterCleanUp : MonoBehaviour
	{
		private struct PieceData
		{
			public Transform transform;

			public Vector3 originalScale;

			public float startDelay;
		}

		[SerializeField]
		private float delayBeforeShrink = 10f;

		[SerializeField]
		private float shrinkDuration = 2f;

		[SerializeField]
		private float randomStartOffset = 0.5f;

		private List<PieceData> pieces = new List<PieceData>();

		private void Start()
		{
			foreach (Transform item in base.transform)
			{
				CollectPiecesRecursive(item);
			}
			StartCoroutine(HandleShrink());
		}

		private void CollectPiecesRecursive(Transform current)
		{
			if (current.GetComponent<ParticleSystem>() != null)
			{
				return;
			}
			float num = Random.Range(0f - randomStartOffset, randomStartOffset);
			pieces.Add(new PieceData
			{
				transform = current,
				originalScale = current.localScale,
				startDelay = delayBeforeShrink + num
			});
			foreach (Transform item in current)
			{
				CollectPiecesRecursive(item);
			}
		}

		private IEnumerator HandleShrink()
		{
			float elapsed = 0f;
			Dictionary<Transform, float> dictionary = new Dictionary<Transform, float>();
			foreach (PieceData piece in pieces)
			{
				dictionary[piece.transform] = 0f;
			}
			float maxDuration = delayBeforeShrink + randomStartOffset + shrinkDuration;
			while (elapsed < maxDuration)
			{
				elapsed += Time.deltaTime;
				foreach (PieceData piece2 in pieces)
				{
					if (!(piece2.transform == null))
					{
						float num = elapsed - piece2.startDelay;
						if (!(num < 0f))
						{
							float num2 = Mathf.Clamp01(num / shrinkDuration);
							piece2.transform.localScale = piece2.originalScale * (1f - num2);
						}
					}
				}
				yield return null;
			}
			Object.Destroy(base.gameObject);
		}
	}
}
