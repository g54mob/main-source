using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace Effects
{
	public class OrderMarkAnimationManager : MonoSingleton<OrderMarkAnimationManager>
	{
		[SerializeField]
		private float animationSpeed = 1f;

		private readonly Dictionary<AnimatedRenderMeshes, float> animatedOrderMarkers = new Dictionary<AnimatedRenderMeshes, float>();

		private readonly List<AnimatedRenderMeshes> progressing = new List<AnimatedRenderMeshes>();

		private readonly List<AnimatedRenderMeshes> finished = new List<AnimatedRenderMeshes>();

		private int animationParameterID;

		public void AnimateOrderIcon(AnimatedRenderMeshes animatedRenderMeshes)
		{
			foreach (MeshRenderer animatedMesh in animatedRenderMeshes.AnimatedMeshes)
			{
				animatedRenderMeshes.gameObject.SetActive(value: true);
				animatedMesh.gameObject.SetActive(value: true);
				animatedOrderMarkers.TryAdd(animatedRenderMeshes, 0f);
			}
		}

		public void CancelOngoingAnimation(GameObject orderMarkGameObject)
		{
			AnimatedRenderMeshes animatedRenderMeshes = null;
			foreach (KeyValuePair<AnimatedRenderMeshes, float> animatedOrderMarker in animatedOrderMarkers)
			{
				if (animatedOrderMarker.Key != null && animatedOrderMarker.Key.gameObject == orderMarkGameObject)
				{
					animatedRenderMeshes = animatedOrderMarker.Key;
					break;
				}
			}
			if (animatedRenderMeshes != null)
			{
				animatedOrderMarkers.Remove(animatedRenderMeshes);
				orderMarkGameObject.SetActive(value: false);
			}
		}

		private void Update()
		{
			if (animatedOrderMarkers.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<AnimatedRenderMeshes, float> animatedOrderMarker in animatedOrderMarkers)
			{
				foreach (MeshRenderer animatedMesh in animatedOrderMarker.Key.AnimatedMeshes)
				{
					if (!(animatedMesh == null))
					{
						MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(animatedMesh);
						materialPropertyBlock.SetFloat(animationParameterID, animatedOrderMarker.Value);
						animatedMesh.SetPropertyBlock(materialPropertyBlock);
						if (animatedOrderMarker.Value >= 1f)
						{
							finished.Add(animatedOrderMarker.Key);
							animatedOrderMarker.Key.gameObject.SetActive(value: true);
						}
						else if (!progressing.Contains(animatedOrderMarker.Key))
						{
							progressing.Add(animatedOrderMarker.Key);
						}
					}
				}
			}
			foreach (AnimatedRenderMeshes item in progressing)
			{
				if (animatedOrderMarkers.ContainsKey(item))
				{
					animatedOrderMarkers[item] += Time.unscaledDeltaTime * animationSpeed;
				}
			}
			foreach (AnimatedRenderMeshes item2 in finished)
			{
				foreach (MeshRenderer animatedMesh2 in item2.AnimatedMeshes)
				{
					animatedMesh2.gameObject.SetActive(value: false);
				}
				animatedOrderMarkers.Remove(item2);
				progressing.Remove(item2);
			}
			finished.Clear();
		}

		private void OnEnable()
		{
			animationParameterID = Shader.PropertyToID("_AppearAnim");
		}
	}
}
