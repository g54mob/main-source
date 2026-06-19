using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IllnessLightHeadedComponent : EntityTickComponent
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		private class Config
		{
			public RuntimeAnimatorController _animatorController;

			public string _headMeshFilter;

			public Vector3 _headMeshPosition;

			public Vector3 _headMeshRotation;

			public Vector3 _headMeshScale = Vector3.one;

			public bool _endWhenBulbDestroyed;
		}

		[SerializeField]
		private Config _config;

		[DontSave]
		private List<GameObject> _bulbGameObjects;

		[DontSave]
		private List<GameObject> _headGameObjects;

		[DontSave]
		private Material[] _bulbMaterials;

		[DontSave]
		private Material _lightBulbMaterial;

		[DontSave]
		private LightHeadedBulb _lightHeadedBulb;

		private bool _moveBulbToLightHeadedMachineCalled;

		private bool _destroyBulbCalled;

		private bool _lightHeadedMachinePickUpNewHeadCalled;

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			SetupVisualBits();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			SetupVisualBits();
			if (_moveBulbToLightHeadedMachineCalled)
			{
				MoveBulbToLightHeadedMachine(null);
			}
			if (_destroyBulbCalled)
			{
				DestroyBulb(null);
			}
			if (_lightHeadedMachinePickUpNewHeadCalled)
			{
				LightHeadedMachinePickUpNewHead(null);
			}
		}

		private void SetupVisualBits()
		{
			Patient owner = GetOwner<Patient>();
			AnimationEventListener animationEventListener = owner.AnimationEventListener;
			_bulbGameObjects = new List<GameObject>();
			_headGameObjects = new List<GameObject>();
			animationEventListener.RegisterEvent("MoveBulbToLightHeadedMachine", MoveBulbToLightHeadedMachine);
			animationEventListener.RegisterEvent("DestroyBulb", DestroyBulb);
			animationEventListener.RegisterEvent("LightHeadedMachinePickUpNewHead", LightHeadedMachinePickUpNewHead);
			animationEventListener.RegisterEvent("MoveHeadFromLightHeadedMachine", MoveHeadFromLightHeadedMachine);
			GameObject gameObject = new GameObject("Light Headed Bulb");
			gameObject.transform.SetParent(owner.GameObject.transform, worldPositionStays: false);
			if (!_config._endWhenBulbDestroyed)
			{
				_lightHeadedBulb = gameObject.AddComponent<LightHeadedBulb>();
				_lightHeadedBulb.RuntimeAnimatorController = _config._animatorController;
			}
		}

		private void MoveBulbToLightHeadedMachine(AnimationEvent animationEvent)
		{
			Patient owner = GetOwner<Patient>();
			if (owner.Visual.PfxGameObject != null)
			{
				owner.Visual.PfxGameObject.SetActive(value: false);
			}
			if (owner.Interaction == null)
			{
				return;
			}
			AnimationHeadClinicSockets component = owner.Interaction.ParentRoomItem.Visual.GameObject.GetComponent<AnimationHeadClinicSockets>();
			if (component != null && owner.Visual.MaskInstances != null)
			{
				foreach (CharModule.ModuleInstance maskInstance in owner.Visual.MaskInstances)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = maskInstance.Renderer as SkinnedMeshRenderer;
					if (!(skinnedMeshRenderer != null) || (!string.IsNullOrEmpty(_config._headMeshFilter) && !skinnedMeshRenderer.name.Contains(_config._headMeshFilter)))
					{
						continue;
					}
					maskInstance.Renderer.gameObject.SetActive(value: false);
					GameObject gameObject = new GameObject("New Face Module");
					MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
					MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
					if (!_config._endWhenBulbDestroyed)
					{
						meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;
					}
					else
					{
						_bulbMaterials = new Material[skinnedMeshRenderer.sharedMaterials.Length];
						for (int i = 0; i < skinnedMeshRenderer.sharedMaterials.Length; i++)
						{
							Material source = skinnedMeshRenderer.sharedMaterials[i];
							_bulbMaterials[i] = new Material(source);
						}
						meshRenderer.sharedMaterials = _bulbMaterials;
					}
					meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
					gameObject.transform.SetParent(component.HeadSocket, worldPositionStays: false);
					gameObject.transform.localPosition = _config._headMeshPosition;
					gameObject.transform.localRotation = Quaternion.Euler(_config._headMeshRotation);
					gameObject.transform.localScale = _config._headMeshScale;
					_bulbGameObjects.Add(gameObject);
				}
				if (_lightHeadedBulb != null)
				{
					_lightHeadedBulb.LightBulbTransform = component.HeadSocket;
					_lightHeadedBulb.TurnOffBulb();
				}
			}
			_moveBulbToLightHeadedMachineCalled = true;
			if (_config._endWhenBulbDestroyed)
			{
				owner.Visual.SetModularMask(null);
			}
		}

		private void DestroyBulb(AnimationEvent animationEvent)
		{
			foreach (GameObject bulbGameObject in _bulbGameObjects)
			{
				UnityEngine.Object.Destroy(bulbGameObject);
			}
			_bulbGameObjects.Clear();
			if (_lightHeadedBulb != null)
			{
				_lightHeadedBulb.DestroyBulb();
			}
			_destroyBulbCalled = true;
		}

		private void LightHeadedMachinePickUpNewHead(AnimationEvent animationEvent)
		{
			Patient owner = GetOwner<Patient>();
			if (owner.Interaction == null)
			{
				return;
			}
			AnimationHeadClinicSockets component = owner.Interaction.ParentRoomItem.Visual.GameObject.GetComponent<AnimationHeadClinicSockets>();
			if (component == null)
			{
				return;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(owner.Definition.RigPrefab, component.HeadSocket, worldPositionStays: false);
			_headGameObjects.Add(gameObject);
			foreach (CharModule.ModuleInstance moduleInstance in owner.Visual.ModuleInstances)
			{
				if ((moduleInstance.Tags & CharModule.Tags.Face) == 0)
				{
					continue;
				}
				SkinnedMeshRenderer skinnedMeshRenderer = moduleInstance.Renderer as SkinnedMeshRenderer;
				if (!(skinnedMeshRenderer != null))
				{
					continue;
				}
				GameObject gameObject2 = new GameObject("New Face Module");
				_headGameObjects.Add(gameObject2);
				gameObject2.transform.SetParent(component.HeadSocket, worldPositionStays: false);
				SkinnedMeshRenderer skinnedMeshRenderer2 = gameObject2.AddComponent<SkinnedMeshRenderer>();
				skinnedMeshRenderer2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				skinnedMeshRenderer2.sharedMaterials = skinnedMeshRenderer.sharedMaterials;
				skinnedMeshRenderer2.rootBone = gameObject.transform.FindChildRecursively(skinnedMeshRenderer.rootBone.name);
				Transform[] bones = skinnedMeshRenderer.bones;
				for (int i = 0; i < bones.Length; i++)
				{
					if (bones[i] != null)
					{
						bones[i] = gameObject.transform.FindChildRecursively(bones[i].name);
					}
				}
				skinnedMeshRenderer2.bones = bones;
			}
			_lightHeadedMachinePickUpNewHeadCalled = true;
		}

		private void MoveHeadFromLightHeadedMachine(AnimationEvent animationEvent)
		{
			foreach (GameObject headGameObject in _headGameObjects)
			{
				UnityEngine.Object.Destroy(headGameObject);
			}
			_headGameObjects.Clear();
			GetOwner<Patient>().Visual.SetModularMask(null);
			Destroy();
		}

		public override void Tick()
		{
			if (_lightHeadedBulb != null)
			{
				Patient owner = GetOwner<Patient>();
				if (_lightBulbMaterial == null && owner.Visual.MaskInstances != null && owner.Visual.MaskInstances.Count > 0)
				{
					CharModule.ModuleInstance moduleInstance = owner.Visual.MaskInstances[0];
					_lightBulbMaterial = moduleInstance.Renderer.material;
					moduleInstance.Renderer.material = _lightBulbMaterial;
					_lightHeadedBulb.LightBulbMaterial = _lightBulbMaterial;
					_lightHeadedBulb.LightBulbTransform = owner.Visual.HeadSocket;
				}
			}
		}

		public override void Destroy()
		{
			if (_lightBulbMaterial != null)
			{
				UnityEngine.Object.Destroy(_lightBulbMaterial);
			}
			if (_bulbMaterials != null)
			{
				Material[] bulbMaterials = _bulbMaterials;
				for (int i = 0; i < bulbMaterials.Length; i++)
				{
					UnityEngine.Object.Destroy(bulbMaterials[i]);
				}
				_bulbMaterials = null;
			}
			AnimationEventListener animationEventListener = GetOwner<Patient>().AnimationEventListener;
			animationEventListener.UnregisterEvent("MoveBulbToLightHeadedMachine", MoveBulbToLightHeadedMachine);
			animationEventListener.UnregisterEvent("DestroyBulb", DestroyBulb);
			animationEventListener.UnregisterEvent("LightHeadedMachinePickUpNewHead", LightHeadedMachinePickUpNewHead);
			animationEventListener.UnregisterEvent("MoveHeadFromLightHeadedMachine", MoveHeadFromLightHeadedMachine);
			if (_lightHeadedBulb != null)
			{
				UnityEngine.Object.Destroy(_lightHeadedBulb.gameObject);
			}
			base.Destroy();
		}
	}
}
