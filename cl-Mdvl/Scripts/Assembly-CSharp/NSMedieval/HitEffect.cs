using System.Collections;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval
{
	public class HitEffect : MonoBehaviour
	{
		[SerializeField]
		private float hitDelay = 0.1f;

		[SerializeField]
		private List<Renderer> hitAffectedMeshes = new List<Renderer>();

		public void Initialize(float hitDelay, IEnumerable<Renderer> hitAffectedMeshes)
		{
			this.hitDelay = hitDelay;
			this.hitAffectedMeshes.Clear();
			foreach (Renderer hitAffectedMesh in hitAffectedMeshes)
			{
				this.hitAffectedMeshes.Add(hitAffectedMesh);
			}
		}

		public void OnHit()
		{
			foreach (Renderer hitAffectedMesh in hitAffectedMeshes)
			{
				if (!(hitAffectedMesh == null) && hitAffectedMesh.gameObject.activeInHierarchy)
				{
					MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(hitAffectedMesh);
					materialPropertyBlock.SetFloat("_HitEffect", 0.1f);
					hitAffectedMesh.SetPropertyBlock(materialPropertyBlock);
				}
			}
			if (base.gameObject.activeSelf)
			{
				StartCoroutine(ResetHit());
			}
		}

		private IEnumerator ResetHit()
		{
			yield return new WaitForSeconds(hitDelay);
			foreach (Renderer hitAffectedMesh in hitAffectedMeshes)
			{
				if (!(hitAffectedMesh == null) && hitAffectedMesh.gameObject.activeInHierarchy)
				{
					MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(hitAffectedMesh);
					materialPropertyBlock.SetFloat("_HitEffect", 0f);
					hitAffectedMesh.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}
	}
}
