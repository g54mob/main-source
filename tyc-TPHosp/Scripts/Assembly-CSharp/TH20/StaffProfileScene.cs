using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffProfileScene : MonoBehaviour
	{
		[SerializeField]
		private Transform _characterPosition;

		[SerializeField]
		private RuntimeAnimatorController[] _characterAnimationGraph;

		private GameObject _mesh;

		private AdvisorLighting _lighting;

		private List<CharModule.ModuleInstance> _charModuleInstances;

		public void SetCharacter(StaffDefinition definition, List<CharModule.CharModuleAssets> charModuleAssets, Character.Sex sex, AdvisorLighting lighting, CustomisationOption customisationOption)
		{
			DestroyMesh();
			if (definition != null)
			{
				_lighting = lighting;
				_mesh = new GameObject("Staff Profile");
				_mesh.transform.SetParent(_characterPosition, worldPositionStays: false);
				GameObject gameObject = Object.Instantiate(definition.RigPrefab, _mesh.transform, worldPositionStays: false);
				gameObject.name = definition.RigPrefab.name;
				Animator[] componentsInChildren = gameObject.GetComponentsInChildren<Animator>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Object.Destroy(componentsInChildren[i]);
				}
				_charModuleInstances = new List<CharModule.ModuleInstance>();
				CharModuleUtils.BuildModularCharacterGameObject(charModuleAssets, _mesh.transform, gameObject.GetComponentsInChildren<Transform>(), instantiateMaterials: true, customisationOption?.MeshMaterialBinding, _charModuleInstances);
				_mesh.SetLayerRecursively(LayerMask.NameToLayer("Metagame"));
				Animator animator = _mesh.AddComponent<Animator>();
				if (animator != null)
				{
					animator.avatar = definition._avatar;
					animator.updateMode = AnimatorUpdateMode.UnscaledTime;
					animator.runtimeAnimatorController = _characterAnimationGraph[(int)sex];
				}
				UpdateLighting();
			}
		}

		private void UpdateLighting()
		{
			if (!(_lighting != null) || _charModuleInstances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance charModuleInstance in _charModuleInstances)
			{
				charModuleInstance.Renderer.allowOcclusionWhenDynamic = false;
				Material[] originalMaterials = charModuleInstance.OriginalMaterials;
				foreach (Material material in originalMaterials)
				{
					TH20Standard.EnableRoomLighting(material);
					_lighting.Apply(material);
				}
			}
		}

		private void DestroyMesh()
		{
			if (_mesh != null)
			{
				Object.DestroyImmediate(_mesh);
				_mesh = null;
			}
		}

		private void OnDestroy()
		{
			DestroyMesh();
		}
	}
}
