using System.Collections.Generic;
using DG.Tweening;
using Mandragora.PWS;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class ShineEffectApplierToMaterialInstances : MonoBehaviour
	{
		[SerializeField]
		private string shinePropertyName = "_Shine";

		[SerializeField]
		private string positionShinePropertyName = "_Position_Shine";

		[SerializeField]
		private float initialShinePosition;

		[SerializeField]
		private float targetShinePosition = 1.5f;

		[SerializeField]
		private float effectDuration = 1f;

		private TweenSequencesService tweenSequences;

		private int shinePropertyId;

		private int positionShinePropertyId;

		private Sequence effectSequence;

		private readonly List<Material> materials = new List<Material>();

		public bool IsActive => effectSequence?.active ?? false;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void Awake()
		{
			shinePropertyId = Shader.PropertyToID(shinePropertyName);
			positionShinePropertyId = Shader.PropertyToID(positionShinePropertyName);
		}

		private void OnDisable()
		{
			if (effectSequence.IsActive() && tweenSequences != null)
			{
				tweenSequences.Kill(effectSequence);
				effectSequence = null;
			}
		}

		public void Apply(MeshRendererMaterialsInstantiator rendererMaterials)
		{
			if (effectSequence.IsActive())
			{
				effectSequence.Kill();
			}
			if ((bool)rendererMaterials)
			{
				materials.AddRange(rendererMaterials.MaterialInstances);
				PlayShineEffect();
			}
		}

		public void Apply(IEnumerable<MeshRendererMaterialsInstantiator> renderersMaterials)
		{
			if (effectSequence.IsActive())
			{
				effectSequence.Kill();
			}
			foreach (MeshRendererMaterialsInstantiator renderersMaterial in renderersMaterials)
			{
				foreach (Material materialInstance in renderersMaterial.MaterialInstances)
				{
					if ((bool)materialInstance && !materials.Contains(materialInstance))
					{
						materials.Add(materialInstance);
					}
				}
			}
			PlayShineEffect();
		}

		private void PlayShineEffect()
		{
			if (materials.Count == 0)
			{
				return;
			}
			foreach (Material material in materials)
			{
				material.SetFloat(positionShinePropertyId, initialShinePosition);
				material.SetInt(shinePropertyId, 1);
			}
			effectSequence = tweenSequences.Create();
			foreach (Material material2 in materials)
			{
				effectSequence.Join(material2.DOFloat(targetShinePosition, positionShinePropertyId, effectDuration));
			}
			effectSequence.SetEase(Ease.InQuad).OnKill(FinalizeAndResetMaterials);
		}

		private void FinalizeAndResetMaterials()
		{
			foreach (Material material in materials)
			{
				if ((bool)material)
				{
					material.SetInt(shinePropertyId, 0);
				}
			}
			materials.Clear();
		}
	}
}
