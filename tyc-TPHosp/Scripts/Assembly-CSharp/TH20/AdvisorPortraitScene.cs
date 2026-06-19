using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdvisorPortraitScene : MonoBehaviour
	{
		[SerializeField]
		private Transform _advisorTransform;

		[SerializeField]
		private GameObject _rigPrefab;

		[SerializeField]
		private Avatar _advisorAvatar;

		[SerializeField]
		private CharModule _charModule;

		[SerializeField]
		private RuntimeAnimatorController _advisorAnimationGraph;

		[SerializeField]
		private Camera _advisorCamera;

		[SerializeField]
		private Material _eyeMaterial;

		[SerializeField]
		private Material _eyeLidMaterial;

		[SerializeField]
		private AdvisorLighting _lightingValues;

		private GameObject _mesh;

		private GameObject _rig;

		private Animator _animator;

		private Material _eyeMaterialInstance;

		private readonly List<CharModule.CharModuleAssets> _charModuleAssets = new List<CharModule.CharModuleAssets>();

		private readonly List<CharModule.ModuleInstance> _charModuleInstances = new List<CharModule.ModuleInstance>();

		public void Setup()
		{
			BuildMeshFromCharModule();
		}

		public void Activate(bool bActive)
		{
			_advisorCamera.gameObject.SetActive(bActive);
			_mesh.SetActive(bActive);
		}

		public void ShowAdvisorModel(RuntimeAnimatorController animGraph = null)
		{
			_advisorCamera.gameObject.SetActive(value: true);
			SetAdvisorAnimationGraph((animGraph != null) ? animGraph : _advisorAnimationGraph);
			if (_mesh != null && _animator != null)
			{
				_mesh.gameObject.SetActive(value: true);
				_animator.SetBool("Hide", value: false);
			}
		}

		public void PopDownAdvisor()
		{
			if (_animator != null)
			{
				_animator.SetBool("Hide", value: true);
			}
		}

		public void HideAdvisorModel()
		{
			_advisorCamera.gameObject.SetActive(value: false);
			if (_mesh != null)
			{
				_mesh.gameObject.SetActive(value: false);
			}
		}

		public void SetAnimGraphParameter(string ParamName, float Value)
		{
			_animator.SetParameter(ParamName, Value);
		}

		public void SetAnimGraphParameter(string ParamName, int Value)
		{
			_animator.SetParameter(ParamName, Value);
		}

		public void SetAnimGraphParameter(string ParamName)
		{
			_animator.SetParameter(ParamName);
		}

		private void Update()
		{
		}

		private void CreateAdvisorMeshAndAnimator()
		{
			if (_mesh == null)
			{
				_mesh = new GameObject("Advisor Portrait");
				_mesh.transform.SetParent(_advisorTransform, worldPositionStays: false);
			}
			if (_rig == null)
			{
				_rig = Object.Instantiate(_rigPrefab, _mesh.transform, worldPositionStays: false);
				_rig.name = _rigPrefab.name;
			}
			Animator[] componentsInChildren = _rig.GetComponentsInChildren<Animator>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Object.Destroy(componentsInChildren[i]);
			}
			_animator = _mesh.AddComponent<Animator>();
			if (_animator != null)
			{
				_animator.avatar = _advisorAvatar;
				_animator.updateMode = AnimatorUpdateMode.UnscaledTime;
			}
		}

		private void BuildMeshFromCharModule()
		{
			if (_mesh == null || _animator == null)
			{
				CreateAdvisorMeshAndAnimator();
			}
			_eyeMaterialInstance = new Material(_eyeMaterial);
			TH20Standard.EnableRoomLighting(_eyeMaterialInstance);
			_charModule.GetRandomCharacterData((CharModule.Category)0, _eyeMaterialInstance, null, null, _charModuleAssets);
			CharModuleUtils.BuildModularCharacterGameObject(_charModuleAssets, _mesh.transform, _rig.GetComponentsInChildren<Transform>(), instantiateMaterials: true, null, _charModuleInstances);
			_mesh.SetLayerRecursively(LayerMask.NameToLayer("Metagame"));
			foreach (CharModule.ModuleInstance charModuleInstance in _charModuleInstances)
			{
				charModuleInstance.Renderer.allowOcclusionWhenDynamic = false;
				charModuleInstance.Renderer.gameObject.layer = LayerMask.NameToLayer("Metagame");
				Material[] originalMaterials = charModuleInstance.OriginalMaterials;
				foreach (Material material in originalMaterials)
				{
					TH20Standard.EnableRoomLighting(material);
					if (_lightingValues != null)
					{
						_lightingValues.Apply(material);
					}
				}
			}
			Transform transform = _mesh.transform.FindChildRecursively("BASE_RIG:CHR_M_Head_BS_Neutral_V1");
			if (transform != null)
			{
				transform.name = "BASE_RIG:Head_BS_Neutral_V1";
			}
		}

		private void SetAdvisorAnimationGraph(RuntimeAnimatorController advisorAnimationGraph)
		{
			if (_animator != null)
			{
				_animator.runtimeAnimatorController = advisorAnimationGraph;
				_animator.Rebind();
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
			if (_eyeMaterialInstance != null)
			{
				Object.Destroy(_eyeMaterialInstance);
			}
			DestroyMesh();
		}
	}
}
