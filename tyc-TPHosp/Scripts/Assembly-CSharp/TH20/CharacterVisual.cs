using System;
using System.Collections.Generic;
using FullInspector;
using FullInspector.Generated.SharedInstance;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	public class CharacterVisual : MustCallDestroy
	{
		private enum Mode
		{
			Normal = 0,
			GreyAnatomy = 1,
			Retro = 2,
			Value = 3,
			Shock = 4,
			XRay = 5,
			Fading = 6,
			Hidden = 7
		}

		[DontSave]
		private bool _greyAnatomyModeEnabled;

		[DontSave]
		private bool _retroModeEnabled;

		[DontSave]
		private bool _valueModeEnabled;

		[DontSave]
		private bool _shockModeEnabled;

		[DontSave]
		private bool _xrayModeEnabled;

		[DontSave]
		private bool _fadingEnabled;

		[DontSave]
		private bool _hiddenEnabled;

		[DontSave]
		private bool _greyAnatomyModeVisible;

		[DontSave]
		private bool _retroModeVisible;

		[DontSave]
		private bool _valueModeVisible;

		[DontSave]
		private bool _shockModeVisible;

		[DontSave]
		private bool _xrayModeVisible;

		[DontSave]
		private bool _fadingVisible;

		[DontSave]
		private bool _hiddenVisible;

		public static readonly string LeftSocketName = "BASE_RIG:left_Socket";

		public static readonly string RightSocketName = "BASE_RIG:right_Socket";

		public static readonly string HeadSocketName = "BASE_RIG:head1_head";

		public static readonly string SpineSocketName = "BASE_RIG:spine1_loResSpine1";

		public Action OnRigRebound;

		[DontSave]
		private GameObject _characterGameObject;

		[DontSave]
		private GameObject _rigGameObject;

		[DontSave]
		private Transform[] _rigBones;

		[DontSave]
		private GameObject _masksGameObject;

		[DontSave]
		private GameObject _overlayGameObject;

		private readonly CharacterDefinition _definition;

		[DontSave]
		private Animator _animator;

		private readonly Character.Sex _sex;

		private GameObject _particleFX;

		private IllnessDefinition.ParticleRoot _particleRoot;

		[DontSave]
		private Level _level;

		[DontSave]
		private VisualManager _visualManager;

		[DontSave]
		private RetroVisualManager _retroVisualManager;

		[DontSave]
		private GameObject _retroGameObject;

		[DontSave]
		private Material _retroMaterial;

		private bool _eyeBlinkingEnabled;

		[DontSave]
		private EyeBlinking _eyeBlinking;

		private readonly List<CharModule.CharModuleAssets> _charModuleAssets = new List<CharModule.CharModuleAssets>(CharModule.CharModuleAssets.InitListCapicity);

		private CharModule.Mask _mask;

		private List<CharModule.CharModuleAssets> _maskModuleAssets;

		private CharModule.Mask _overlay;

		private List<CharModule.CharModuleAssets> _overlayModuleAssets;

		private CustomisationOption _customisationOption;

		private CustomisationOption _customisationOptionOnHold;

		private ModularSkinMaterialSelection _skinMaterialSelectionOverride;

		private CharacterModifierLocoAnimationGraph _currentLocoAnimModifier;

		[DontSave]
		private Material _overrideSkinMaterialInstance;

		[DontSave]
		private List<CharModule.ModuleInstance> _moduleInstances;

		[DontSave]
		private List<CharModule.ModuleInstance> _maskInstances;

		[DontSave]
		private List<CharModule.ModuleInstance> _overlayInstances;

		[DontSave]
		private Material _valueMaterial;

		[DontSave]
		private int _currentLayer;

		private Material _eyeMaterial;

		private Material _eyeLidMaterial;

		private Material _skinToneMaterial;

		private ModularMeshMaterialBindings _hairMeshMaterialBindings;

		private const string _colorPropName = "_Color";

		public bool AnyVisualModesVisible
		{
			get
			{
				if (!_greyAnatomyModeVisible && !_retroModeVisible && !_valueModeVisible && !_shockModeVisible && !_xrayModeVisible && !_fadingVisible)
				{
					return _hiddenVisible;
				}
				return true;
			}
		}

		public bool RetroModeVisible => _retroModeVisible;

		public bool GreyAnatomyModeEnabled
		{
			get
			{
				return _greyAnatomyModeEnabled;
			}
			set
			{
				if (_greyAnatomyModeEnabled != value)
				{
					_greyAnatomyModeEnabled = value;
					RefreshVisualModeVisibility();
				}
			}
		}

		public bool RetroModeEnabled
		{
			get
			{
				return _retroModeEnabled;
			}
			set
			{
				if (_retroModeEnabled != value)
				{
					_retroModeEnabled = value;
					RefreshVisualModeVisibility();
				}
			}
		}

		public bool ValueModeEnabled
		{
			get
			{
				return _valueModeEnabled;
			}
			set
			{
				if (_valueModeEnabled != value)
				{
					_valueModeEnabled = value;
					RefreshVisualModeVisibility();
				}
			}
		}

		public bool ShockModeEnabled
		{
			get
			{
				return _shockModeEnabled;
			}
			set
			{
				if (_shockModeEnabled != value)
				{
					_shockModeEnabled = value;
					RefreshVisualModeVisibility();
				}
			}
		}

		public bool XRayModeEnabled
		{
			get
			{
				return _xrayModeEnabled;
			}
			set
			{
				if (_xrayModeEnabled != value)
				{
					_xrayModeEnabled = value;
					RefreshVisualModeVisibility();
				}
			}
		}

		public bool FadingModeEnable
		{
			get
			{
				return _fadingEnabled;
			}
			set
			{
				if (_fadingEnabled != value)
				{
					_fadingEnabled = value;
					RefreshVisualModeVisibility();
				}
			}
		}

		public bool HiddenModeEnable
		{
			get
			{
				return _hiddenEnabled;
			}
			set
			{
				if (_hiddenEnabled != value)
				{
					_hiddenEnabled = value;
					RefreshVisualModeVisibility();
				}
			}
		}

		public CustomisationOption CustomisationOption
		{
			get
			{
				if (!(_customisationOption != null))
				{
					return _customisationOptionOnHold;
				}
				return _customisationOption;
			}
		}

		public List<CharModule.ModuleInstance> ModuleInstances => _moduleInstances;

		public List<CharModule.ModuleInstance> MaskInstances => _maskInstances;

		public List<CharModule.ModuleInstance> OverlayInstances => _overlayInstances;

		public Material EyeMaterial => _eyeMaterial;

		public Material SkinToneMaterial => _skinToneMaterial;

		public ModularMeshMaterialBindings HairMeshMaterialBindings => _hairMeshMaterialBindings;

		[DontSave]
		public float FadeAlpha { get; private set; }

		[DontSave]
		public Transform LeftSocket { get; private set; }

		[DontSave]
		public Transform RightSocket { get; private set; }

		[DontSave]
		public Transform HeadSocket { get; private set; }

		[DontSave]
		public Transform SpineSocket { get; private set; }

		public GameObject CharacterGameObject => _characterGameObject;

		public GameObject RetroGameObject => _retroGameObject;

		public GameObject RigGameObject => _rigGameObject;

		[DontSave]
		public GameObject PfxGameObject { get; private set; }

		public Transform[] RigBones => _rigBones;

		public CharModule.Mask Mask
		{
			get
			{
				if (_mask != null)
				{
					return _mask;
				}
				if (!(_customisationOption != null) || !(_customisationOption.Mask != null) || _definition.DisallowModularMasks)
				{
					return null;
				}
				return _customisationOption.Mask.Instance;
			}
		}

		public List<CharModule.CharModuleAssets> CharModuleAssets => _charModuleAssets;

		public bool EyeBlinkingEnabled
		{
			get
			{
				return _eyeBlinkingEnabled;
			}
			set
			{
				_eyeBlinkingEnabled = value;
			}
		}

		private void HideValueVisualMode()
		{
			if (_valueModeVisible)
			{
				ResetModuleInstancesToOrginalMaterials(_moduleInstances);
				if (_maskInstances != null)
				{
					ResetModuleInstancesToOrginalMaterials(_maskInstances);
				}
				_valueModeVisible = false;
			}
		}

		private void HideRetroVisualMode()
		{
			if (_retroModeVisible)
			{
				if (_retroGameObject != null)
				{
					_retroGameObject.SetActive(value: false);
				}
				_retroModeVisible = false;
			}
		}

		private void HideGreyAnatomyVisualMode()
		{
			if (_greyAnatomyModeVisible)
			{
				ApplyMaterialKeywords(grayAnatomyEffect: false);
				_greyAnatomyModeVisible = false;
			}
		}

		private void HideShockVisualMode()
		{
			if (_shockModeVisible)
			{
				ResetModuleInstancesToOrginalMaterials(_moduleInstances);
				if (_maskInstances != null)
				{
					ResetModuleInstancesToOrginalMaterials(_maskInstances);
				}
				SetModularOverlay(null);
				_shockModeVisible = false;
			}
		}

		private void HideXRayVisualMode()
		{
			if (_xrayModeVisible)
			{
				SetModularOverlay(null);
				_xrayModeVisible = false;
			}
		}

		private void HideFadingVisualMode()
		{
			if (_fadingVisible)
			{
				ResetModuleInstancesToOrginalMaterials(_moduleInstances);
				if (_maskInstances != null)
				{
					ResetModuleInstancesToOrginalMaterials(_maskInstances);
				}
				if (_overlayInstances != null)
				{
					ResetModuleInstancesToOrginalMaterials(_overlayInstances);
				}
				if (!HiddenModeEnable)
				{
					EnableRendererGameObjects(enable: true);
				}
				_fadingVisible = false;
			}
		}

		private void HideHiddenVisualMode()
		{
			if (_hiddenVisible)
			{
				EnableRendererGameObjects(enable: true);
				_hiddenVisible = false;
			}
		}

		private void RefreshVisualModeVisibility(bool force = false)
		{
			bool anyVisualModesVisible = AnyVisualModesVisible;
			if (!_valueModeEnabled)
			{
				HideValueVisualMode();
			}
			if (!_retroModeEnabled)
			{
				HideRetroVisualMode();
			}
			if (!_greyAnatomyModeEnabled)
			{
				HideGreyAnatomyVisualMode();
			}
			if (!_shockModeEnabled)
			{
				HideShockVisualMode();
			}
			if (!_xrayModeEnabled)
			{
				HideXRayVisualMode();
			}
			if (!_fadingEnabled)
			{
				HideFadingVisualMode();
			}
			if (!_hiddenEnabled)
			{
				HideHiddenVisualMode();
			}
			switch (HighestPriorityEnabledMode())
			{
			case Mode.Normal:
				if (anyVisualModesVisible || force)
				{
					SetRenderersOffscreen(offscreen: false);
				}
				break;
			case Mode.Value:
				if (!_valueModeVisible || force)
				{
					HideRetroVisualMode();
					HideGreyAnatomyVisualMode();
					HideShockVisualMode();
					HideXRayVisualMode();
					SetRenderersOffscreen(offscreen: false);
					SetModuleInstancesToMaterial(_moduleInstances, _valueMaterial);
					if (_maskInstances != null)
					{
						SetModuleInstancesToMaterial(_maskInstances, _valueMaterial);
					}
					_valueModeVisible = true;
				}
				break;
			case Mode.Retro:
				if (!(!_retroModeVisible || force))
				{
					break;
				}
				HideValueVisualMode();
				HideGreyAnatomyVisualMode();
				HideShockVisualMode();
				HideXRayVisualMode();
				SetRenderersOffscreen(offscreen: true);
				if (_retroGameObject == null)
				{
					_retroGameObject = new GameObject("Retro");
					_retroGameObject.transform.SetParent(_characterGameObject.transform, worldPositionStays: false);
					_retroGameObject.transform.localPosition = new Vector3(0f, _retroVisualManager.CameraHeightOffset + HeadSocket.position.y, 0f);
					_retroGameObject.transform.localScale = _retroVisualManager.MeshScale;
					GameObject gameObject = new GameObject("Retro Renderer");
					gameObject.transform.SetParent(_retroGameObject.transform, worldPositionStays: false);
					gameObject.transform.localPosition = new Vector3(0f, 0f, 0f - _retroVisualManager.GetMeshBias(HeadSocket.position.y));
					MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
					meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
					if (_retroMaterial == null)
					{
						_retroMaterial = _retroVisualManager.GetRetroMaterial(this);
					}
					meshRenderer.material = _retroMaterial;
					gameObject.AddComponent<MeshFilter>().sharedMesh = _retroVisualManager.Mesh;
					_retroGameObject.AddComponent<FaceCameraComponent>();
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					_retroVisualManager.Lighting.Apply(materialPropertyBlock);
					foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
					{
						moduleInstance.Renderer.SetPropertyBlock(materialPropertyBlock);
					}
				}
				_retroGameObject.SetActive(value: true);
				_retroModeVisible = true;
				break;
			case Mode.GreyAnatomy:
				if (!_greyAnatomyModeVisible || force)
				{
					HideValueVisualMode();
					HideRetroVisualMode();
					HideShockVisualMode();
					SetRenderersOffscreen(offscreen: false);
					ApplyMaterialKeywords(grayAnatomyEffect: true);
					_greyAnatomyModeVisible = true;
				}
				break;
			case Mode.Shock:
				if (!_shockModeVisible || force)
				{
					HideValueVisualMode();
					HideRetroVisualMode();
					HideGreyAnatomyVisualMode();
					HideXRayVisualMode();
					SetRenderersOffscreen(offscreen: false);
					SetModuleInstancesToMaterial(_moduleInstances, _visualManager.VisualManagerConfig.CharacterShockEffectConfig.BlackMaterial);
					if (_maskInstances != null)
					{
						SetModuleInstancesToMaterial(_maskInstances, _visualManager.VisualManagerConfig.CharacterShockEffectConfig.BlackMaterial);
					}
					SharedInstance_TH20TH20_CharModule_Mask characterElectricShockSkeletonMask = _visualManager.VisualManagerConfig.CharacterShockEffectConfig.CharacterElectricShockSkeletonMask;
					if (characterElectricShockSkeletonMask.NotNull())
					{
						SetModularOverlay(characterElectricShockSkeletonMask.Instance);
					}
					_shockModeVisible = true;
				}
				break;
			case Mode.XRay:
				if (!_xrayModeVisible || force)
				{
					HideValueVisualMode();
					HideRetroVisualMode();
					HideShockVisualMode();
					SetRenderersOffscreen(offscreen: false);
					SharedInstance<CharModule.Mask> characterXRaySkeletonMask = _visualManager.VisualManagerConfig.CharacterXRaySkeletonMask;
					if (characterXRaySkeletonMask.NotNull())
					{
						SetModularOverlay(characterXRaySkeletonMask.Instance);
					}
					_xrayModeVisible = true;
				}
				break;
			case Mode.Fading:
				if (!(!_fadingVisible || force))
				{
					break;
				}
				if (XRayModeEnabled || RetroModeEnabled || GreyAnatomyModeEnabled || ValueModeEnabled)
				{
					HideXRayVisualMode();
					HideRetroVisualMode();
					HideGreyAnatomyVisualMode();
					HideValueVisualMode();
					EnableRendererGameObjects(enable: false);
					_fadingVisible = true;
					break;
				}
				EnableRendererGameObjects(enable: true);
				SetRenderersOffscreen(offscreen: false);
				SetModuleInstancesToFadeMaterial(_moduleInstances);
				if (_maskInstances != null)
				{
					SetModuleInstancesToFadeMaterial(_maskInstances);
				}
				if (_overlayInstances != null)
				{
					SetModuleInstancesToFadeMaterial(_overlayInstances);
				}
				_fadingVisible = true;
				break;
			case Mode.Hidden:
				if (!_hiddenVisible || force)
				{
					HideXRayVisualMode();
					HideRetroVisualMode();
					HideValueVisualMode();
					HideGreyAnatomyVisualMode();
					SetRenderersOffscreen(offscreen: false);
					EnableRendererGameObjects(enable: false);
					_hiddenVisible = true;
				}
				break;
			}
		}

		private Mode HighestPriorityEnabledMode()
		{
			if (FadingModeEnable)
			{
				return Mode.Fading;
			}
			if (HiddenModeEnable)
			{
				return Mode.Hidden;
			}
			if (ValueModeEnabled)
			{
				return Mode.Value;
			}
			if (XRayModeEnabled)
			{
				return Mode.XRay;
			}
			if (ShockModeEnabled)
			{
				return Mode.Shock;
			}
			if (RetroModeEnabled)
			{
				return Mode.Retro;
			}
			if (GreyAnatomyModeEnabled)
			{
				return Mode.GreyAnatomy;
			}
			return Mode.Normal;
		}

		public CharacterVisual(CharacterDefinition definition, Character.Sex sex, GameObject characterGameObject, Animator animator, Level level)
		{
			_valueMaterial = new Material(level.DataViewManager.ValueMaterial);
			_level = level;
			_definition = definition;
			_sex = sex;
			_animator = animator;
			_visualManager = _level.VisualManager;
			_retroVisualManager = _visualManager.RetroVisualManager;
			_eyeBlinkingEnabled = true;
			_currentLayer = 0;
			_characterGameObject = characterGameObject;
			_rigGameObject = UnityEngine.Object.Instantiate(_definition.RigPrefab, _characterGameObject.transform, worldPositionStays: false);
			_rigGameObject.name = _definition.RigPrefab.name;
			_rigBones = _rigGameObject.GetComponentsInChildren<Transform>();
			Animator[] componentsInChildren = _rigGameObject.GetComponentsInChildren<Animator>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.Destroy(componentsInChildren[i]);
			}
			_moduleInstances = new List<CharModule.ModuleInstance>();
		}

		public void RestoreFromSave(GameObject characterGameObject, Animator animator, Level level)
		{
			_level = level;
			_valueMaterial = new Material(_level.DataViewManager.ValueMaterial);
			_animator = animator;
			_characterGameObject = characterGameObject;
			_currentLayer = 0;
			_visualManager = _level.VisualManager;
			_retroVisualManager = _visualManager.RetroVisualManager;
			_rigGameObject = UnityEngine.Object.Instantiate(_definition.RigPrefab, _characterGameObject.transform, worldPositionStays: false);
			_rigGameObject.name = _definition.RigPrefab.name;
			_rigBones = _rigGameObject.GetComponentsInChildren<Transform>();
			Animator[] componentsInChildren = _rigGameObject.GetComponentsInChildren<Animator>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.Destroy(componentsInChildren[i]);
			}
			_moduleInstances = new List<CharModule.ModuleInstance>();
		}

		public void RestoreModules()
		{
			ApplyModularAssets(restoreFromSave: true);
			ApplyModularOverlay(restoreFromSave: true);
			ApplySkinOverride();
			RefreshVisualModeVisibility();
		}

		public void SetCustomisationOptionOnHold(Character character)
		{
			if (_customisationOptionOnHold == null)
			{
				CustomisationOption customisationOption = _customisationOption;
				SetCustomisationOption(null, character, bForce: true);
				_customisationOptionOnHold = customisationOption;
			}
		}

		public void RestoreCustomisationOptionOnHold(Character character)
		{
			if (_customisationOptionOnHold != null)
			{
				CustomisationOption customisationOptionOnHold = _customisationOptionOnHold;
				_customisationOptionOnHold = null;
				SetCustomisationOption(customisationOptionOnHold, character, bForce: true);
			}
		}

		public void SetModularAssets(List<CharModule.CharModuleAssets> charModuleAssets, Material skinMaterial, Material eyeMaterial, ModularMeshMaterialBindings hairMeshMaterialBindings)
		{
			_skinToneMaterial = skinMaterial;
			_eyeMaterial = eyeMaterial;
			_hairMeshMaterialBindings = hairMeshMaterialBindings;
			_charModuleAssets.Clear();
			_charModuleAssets.AddRange(charModuleAssets);
			_eyeLidMaterial = _definition.EyeLidsSkinMaterialSelection.FindMatchingMaterial(_skinToneMaterial);
			ApplyModularAssets(restoreFromSave: false);
			RefreshVisualModeVisibility(force: true);
		}

		public void SetCustomisationOption(CustomisationOption newCustomisationOption, Character character, bool bForce = false)
		{
			RoomDefinition roomDefinition = character.ReservedInteraction?.ParentRoomItem?.FloorPlan?.Definition;
			if (character.RoomUsing != null && !bForce)
			{
				RoomDefinition definition = character.RoomUsing.Definition;
				RoomDefinition roomDefinition2 = newCustomisationOption?.CantChangeWhileInRoom?.Instance;
				RoomDefinition roomDefinition3 = _customisationOption?.CantChangeWhileInRoom?.Instance;
				if ((roomDefinition2 != null && (definition == roomDefinition2 || roomDefinition == roomDefinition2)) || (roomDefinition3 != null && (definition == roomDefinition3 || roomDefinition == roomDefinition3)))
				{
					return;
				}
			}
			if ((character.SatisfyNeedsComponent != null && (object)newCustomisationOption != null && newCustomisationOption.DisallowNauseaFulfilment && character.SatisfyNeedsComponent.CurrentNeedBeingSatisfied == CharacterAttributes.Type.Nausea && character.SatisfyNeedsComponent.SatisfyingNeed) || !(_customisationOption != newCustomisationOption) || !(_customisationOptionOnHold == null))
			{
				return;
			}
			_ = _customisationOption;
			_customisationOption = newCustomisationOption;
			ApplyModularAssets(restoreFromSave: false);
			RefreshVisualModeVisibility(force: true);
			if (_currentLocoAnimModifier != null)
			{
				if (character != null && character.ModifiersComponent != null)
				{
					character.ModifiersComponent.RemoveModifier(_currentLocoAnimModifier);
				}
				_currentLocoAnimModifier = null;
			}
			if (_customisationOption != null && _customisationOption.LocoOverrideGraphs != null && _customisationOption.LocoOverrideGraphs.Length != 0)
			{
				_currentLocoAnimModifier = new CharacterModifierLocoAnimationGraph();
				_currentLocoAnimModifier.Priority = _customisationOption.LocoOverridePriority;
				_currentLocoAnimModifier.LocoGraphs = _customisationOption.LocoOverrideGraphs;
				_currentLocoAnimModifier.SetShowInTooltip(var: false);
				if (character != null && character.ModifiersComponent != null)
				{
					character.ModifiersComponent.AddModifier(_currentLocoAnimModifier);
				}
			}
		}

		public void SetModularMask(CharModule.Mask mask)
		{
			if (_mask != mask)
			{
				_mask = mask;
				ApplyModularMask(restoreFromSave: false);
				RefreshVisualModeVisibility(force: true);
			}
		}

		private void SetModularOverlay(CharModule.Mask overlay)
		{
			if (_overlay != overlay)
			{
				_overlay = overlay;
				ApplyModularOverlay(restoreFromSave: false);
				RefreshVisualModeVisibility(force: true);
			}
		}

		public void SetSkinSelectionOverride(ModularSkinMaterialSelection skinMaterialSelectionOverride)
		{
			_skinMaterialSelectionOverride = skinMaterialSelectionOverride;
			ApplySkinOverride();
		}

		public void SetParticleFX(GameObject characterParticleFX, IllnessDefinition.ParticleRoot illnessParticleRoot)
		{
			_particleFX = characterParticleFX;
			_particleRoot = illnessParticleRoot;
		}

		private void InstantiateParticleFX()
		{
			if (_particleFX != null && PfxGameObject == null)
			{
				PfxGameObject = UnityEngine.Object.Instantiate(_particleFX);
				Transform socket = GetSocket(_particleRoot);
				PfxGameObject.transform.position = socket.position + PfxGameObject.transform.position;
				PfxGameObject.transform.parent = socket;
			}
		}

		public void ReparentParticles(IllnessDefinition.ParticleRoot newParent)
		{
			if (_particleFX != null && PfxGameObject != null)
			{
				Transform socket = GetSocket(newParent);
				PfxGameObject.transform.parent = socket;
			}
		}

		private Transform GetSocket(IllnessDefinition.ParticleRoot root)
		{
			return root switch
			{
				IllnessDefinition.ParticleRoot.Core => _rigGameObject.transform, 
				IllnessDefinition.ParticleRoot.Head => HeadSocket, 
				IllnessDefinition.ParticleRoot.Spine => SpineSocket, 
				_ => HeadSocket, 
			};
		}

		public void SetValueMaterial(Color valueColor)
		{
			_valueMaterial.color = valueColor;
		}

		private void SetModuleInstancesToMaterial(List<CharModule.ModuleInstance> moduleInstances, Material material)
		{
			Material[] sharedMaterials = new Material[2] { material, material };
			foreach (CharModule.ModuleInstance moduleInstance in moduleInstances)
			{
				moduleInstance.Renderer.sharedMaterials = sharedMaterials;
			}
		}

		private void SetModuleInstancesToFadeMaterial(List<CharModule.ModuleInstance> moduleInstances)
		{
			foreach (CharModule.ModuleInstance moduleInstance in moduleInstances)
			{
				moduleInstance.Renderer.sharedMaterials = moduleInstance.FadeMaterials;
			}
		}

		private void ResetModuleInstancesToOrginalMaterials(List<CharModule.ModuleInstance> moduleInstances)
		{
			foreach (CharModule.ModuleInstance moduleInstance in moduleInstances)
			{
				moduleInstance.Renderer.sharedMaterials = moduleInstance.OriginalMaterials;
			}
		}

		private void SetAlphaOnModuleInstances(List<CharModule.ModuleInstance> moduleInstances, float alpha)
		{
			foreach (CharModule.ModuleInstance moduleInstance in moduleInstances)
			{
				Material[] fadeMaterials = moduleInstance.FadeMaterials;
				foreach (Material material in fadeMaterials)
				{
					if (material.HasProperty("_Color"))
					{
						material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
					}
				}
			}
		}

		private void SetRenderersOffscreen(bool offscreen)
		{
			string keyword = "_APPLYROOMLIGHTING_OFF";
			if (offscreen)
			{
				SetLayer(LayerMask.NameToLayer("Metagame"));
			}
			else if (_level != null && _level.WorldState != null && _level.WorldState.IsExterior(_characterGameObject.transform.position))
			{
				SetLayer(LayerMask.NameToLayer("Outdoor"));
			}
			else
			{
				SetLayer(LayerMask.NameToLayer("Default"));
			}
			if (_moduleInstances != null)
			{
				foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
				{
					if (moduleInstance.Renderer != null)
					{
						moduleInstance.Renderer.allowOcclusionWhenDynamic = !offscreen;
					}
					Material[] originalMaterials = moduleInstance.OriginalMaterials;
					foreach (Material material in originalMaterials)
					{
						if (offscreen)
						{
							material.DisableKeyword(keyword);
						}
						else
						{
							material.EnableKeyword(keyword);
						}
					}
				}
			}
			if (_maskInstances != null)
			{
				foreach (CharModule.ModuleInstance maskInstance in _maskInstances)
				{
					if (maskInstance.Renderer != null)
					{
						maskInstance.Renderer.allowOcclusionWhenDynamic = !offscreen;
					}
					Material[] originalMaterials = maskInstance.OriginalMaterials;
					foreach (Material material2 in originalMaterials)
					{
						if (offscreen)
						{
							material2.DisableKeyword(keyword);
						}
						else
						{
							material2.EnableKeyword(keyword);
						}
					}
				}
			}
			if (_overlayInstances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance overlayInstance in _overlayInstances)
			{
				if (overlayInstance.Renderer != null)
				{
					overlayInstance.Renderer.allowOcclusionWhenDynamic = !offscreen;
				}
				Material[] originalMaterials = overlayInstance.OriginalMaterials;
				foreach (Material material3 in originalMaterials)
				{
					if (offscreen)
					{
						material3.DisableKeyword(keyword);
					}
					else
					{
						material3.EnableKeyword(keyword);
					}
				}
			}
		}

		private void EnableRendererGameObjects(bool enable)
		{
			if (_moduleInstances != null)
			{
				foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
				{
					CharModule.Mask mask = Mask;
					if (mask != null && mask.CharacterModule != null && (mask.Tags == (CharModule.Tags)0 || (mask.Tags & moduleInstance.Tags) != 0))
					{
						GameObjectUtils.SetActive(moduleInstance.Renderer.gameObject, isActive: false);
					}
					else
					{
						GameObjectUtils.SetActive(moduleInstance.Renderer.gameObject, enable);
					}
				}
			}
			if (_overlayInstances != null)
			{
				foreach (CharModule.ModuleInstance overlayInstance in _overlayInstances)
				{
					GameObjectUtils.SetActive(overlayInstance.Renderer.gameObject, enable);
				}
			}
			if (_maskInstances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance maskInstance in _maskInstances)
			{
				GameObjectUtils.SetActive(maskInstance.Renderer.gameObject, enable);
			}
		}

		public void SetFadingAlpha(float alpha)
		{
			FadeAlpha = alpha;
			SetAlphaOnModuleInstances(_moduleInstances, FadeAlpha);
			if (_maskInstances != null)
			{
				SetAlphaOnModuleInstances(_maskInstances, FadeAlpha);
			}
			if (_overlayInstances != null)
			{
				SetAlphaOnModuleInstances(_overlayInstances, FadeAlpha);
			}
		}

		public void Update()
		{
			if (_eyeBlinkingEnabled && !AnyVisualModesVisible)
			{
				_eyeBlinking.Update(Time.deltaTime);
			}
			if (RetroModeVisible && _retroGameObject != null)
			{
				_retroGameObject.transform.localPosition = new Vector3(0f, _retroVisualManager.CameraHeightOffset + HeadSocket.position.y, 0f);
				_retroGameObject.transform.GetChild(0).localPosition = new Vector3(0f, 0f, 0f - _retroVisualManager.GetMeshBias(HeadSocket.position.y));
			}
		}

		public void SetRendererActive(bool active)
		{
			foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = moduleInstance.Renderer as SkinnedMeshRenderer;
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.enabled = active;
				}
			}
		}

		public void EnableUpdateWhenOffscreen()
		{
			foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = moduleInstance.Renderer as SkinnedMeshRenderer;
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.updateWhenOffscreen = true;
				}
			}
			if (_maskInstances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance maskInstance in _maskInstances)
			{
				SkinnedMeshRenderer skinnedMeshRenderer2 = maskInstance.Renderer as SkinnedMeshRenderer;
				if (skinnedMeshRenderer2 != null)
				{
					skinnedMeshRenderer2.updateWhenOffscreen = true;
				}
			}
		}

		public void DisableUpdateWhenOffscreen()
		{
			foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = moduleInstance.Renderer as SkinnedMeshRenderer;
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.updateWhenOffscreen = false;
					skinnedMeshRenderer.localBounds = new Bounds(Vector3.zero, Vector3.one * 2f);
				}
			}
			if (_maskInstances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance maskInstance in _maskInstances)
			{
				SkinnedMeshRenderer skinnedMeshRenderer2 = maskInstance.Renderer as SkinnedMeshRenderer;
				if (skinnedMeshRenderer2 != null)
				{
					skinnedMeshRenderer2.updateWhenOffscreen = false;
					skinnedMeshRenderer2.localBounds = new Bounds(Vector3.zero, Vector3.one * 2f);
				}
			}
		}

		public void GenerateDefaultModular()
		{
			CharModuleUtils.GetCoreRandomAssets(_definition.SkinHairMaterialDatabase, _definition.EyeMaterialSelection, out _eyeMaterial, out _skinToneMaterial, out _hairMeshMaterialBindings);
			CharModule.Category category = _definition.GetModularCategory(_sex);
			if (_level.Config.CharactersCanWearSummerClothes)
			{
				category |= CharModule.Category.Summer;
			}
			if (_level.Config.CharactersCanWearWinterClothes)
			{
				category |= CharModule.Category.Winter;
			}
			_definition.RootModule.GetRandomCharacterData(category, _eyeMaterial, _skinToneMaterial, _hairMeshMaterialBindings, _charModuleAssets);
			_eyeLidMaterial = _definition.EyeLidsSkinMaterialSelection.FindMatchingMaterial(_skinToneMaterial);
			ApplyModularAssets(restoreFromSave: false);
			RefreshVisualModeVisibility(force: true);
		}

		private void ApplyMaterialKeywords(bool grayAnatomyEffect)
		{
			foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
			{
				Material[] originalMaterials = moduleInstance.OriginalMaterials;
				for (int i = 0; i < moduleInstance.OriginalMaterials.Length; i++)
				{
					if (TH20Standard.IsTH20Standard(originalMaterials[i]) && TH20Standard.GetGrayAnatomyEffectState(originalMaterials[i]) != grayAnatomyEffect)
					{
						TH20Standard.SetGrayAnatomyEffectState(originalMaterials[i], grayAnatomyEffect);
					}
				}
			}
			if (_maskInstances != null)
			{
				foreach (CharModule.ModuleInstance maskInstance in _maskInstances)
				{
					Material[] originalMaterials2 = maskInstance.OriginalMaterials;
					for (int j = 0; j < maskInstance.OriginalMaterials.Length; j++)
					{
						if (TH20Standard.IsTH20Standard(originalMaterials2[j]) && TH20Standard.GetGrayAnatomyEffectState(originalMaterials2[j]) != grayAnatomyEffect)
						{
							TH20Standard.SetGrayAnatomyEffectState(originalMaterials2[j], grayAnatomyEffect);
						}
					}
				}
			}
			if (_overlayInstances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance overlayInstance in _overlayInstances)
			{
				Material[] originalMaterials3 = overlayInstance.OriginalMaterials;
				for (int k = 0; k < overlayInstance.OriginalMaterials.Length; k++)
				{
					if (TH20Standard.IsTH20Standard(originalMaterials3[k]) && TH20Standard.GetGrayAnatomyEffectState(originalMaterials3[k]) != grayAnatomyEffect)
					{
						TH20Standard.SetGrayAnatomyEffectState(originalMaterials3[k], grayAnatomyEffect);
					}
				}
			}
		}

		private void ApplyModularAssets(bool restoreFromSave)
		{
			CharModuleUtils.DestroyModularInstances(_moduleInstances);
			CharModuleUtils.BuildModularCharacterGameObject(_charModuleAssets, _characterGameObject.transform, _rigBones, instantiateMaterials: true, _customisationOption?.MeshMaterialBinding, _moduleInstances);
			AnimatorRebind(restoreFromSave);
			_eyeBlinking.Reset();
			_eyeBlinking.SetupEyeBlinking(_moduleInstances, _eyeLidMaterial);
			LeftSocket = _rigGameObject.transform.FindChildRecursively(LeftSocketName);
			RightSocket = _rigGameObject.transform.FindChildRecursively(RightSocketName);
			HeadSocket = _rigGameObject.transform.FindChildRecursively(HeadSocketName);
			SpineSocket = _rigGameObject.transform.FindChildRecursively(SpineSocketName);
			ApplyModularMask(restoreFromSave);
		}

		private void ApplyModularOverlay(bool restoreFromSave)
		{
			if (_overlayGameObject == null)
			{
				_overlayGameObject = new GameObject("Modular Overlay");
				_overlayGameObject.transform.SetParent(_characterGameObject.transform, worldPositionStays: false);
			}
			else
			{
				foreach (Transform item in _overlayGameObject.transform)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			CharModuleUtils.DestroyModularInstances(_overlayInstances);
			if (_overlay != null && _overlay.CharacterModule != null)
			{
				if (_overlayModuleAssets == null)
				{
					_overlayModuleAssets = new List<CharModule.CharModuleAssets>();
				}
				_overlayModuleAssets.Clear();
				_overlay.CharacterModule.GetRandomCharacterData(_definition.GetModularCategory(_sex), _eyeMaterial, _skinToneMaterial, _hairMeshMaterialBindings, _overlayModuleAssets);
				if (_overlayInstances == null)
				{
					_overlayInstances = new List<CharModule.ModuleInstance>();
				}
				CharModuleUtils.BuildModularCharacterGameObject(_overlayModuleAssets, _overlayGameObject.transform, _rigBones, instantiateMaterials: true, _customisationOption?.MeshMaterialBinding, _overlayInstances);
				AnimatorRebind(restoreFromSave);
				_eyeBlinking.SetupEyeBlinking(_overlayInstances, _eyeLidMaterial);
			}
			SetLayer(_currentLayer, force: true);
		}

		private void ApplyModularMask(bool restoreFromSave)
		{
			if (_masksGameObject == null)
			{
				_masksGameObject = new GameObject("Modular Mask");
				_masksGameObject.transform.SetParent(_characterGameObject.transform, worldPositionStays: false);
			}
			else
			{
				foreach (Transform item in _masksGameObject.transform)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			CharModuleUtils.DestroyModularInstances(_maskInstances);
			foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
			{
				moduleInstance.Renderer.gameObject.SetActive(value: true);
			}
			CharModule.Mask mask = Mask;
			if (mask != null && mask.CharacterModule != null)
			{
				foreach (CharModule.ModuleInstance moduleInstance2 in _moduleInstances)
				{
					if (mask.Tags == (CharModule.Tags)0 || (mask.Tags & moduleInstance2.Tags) != 0)
					{
						moduleInstance2.Renderer.gameObject.SetActive(value: false);
					}
				}
				if (_maskModuleAssets == null)
				{
					_maskModuleAssets = new List<CharModule.CharModuleAssets>();
				}
				if (!restoreFromSave)
				{
					_maskModuleAssets.Clear();
					mask.CharacterModule.GetRandomCharacterData(_definition.GetModularCategory(_sex), _eyeMaterial, _skinToneMaterial, _hairMeshMaterialBindings, _maskModuleAssets);
				}
				if (_maskInstances == null)
				{
					_maskInstances = new List<CharModule.ModuleInstance>();
				}
				CharModuleUtils.BuildModularCharacterGameObject(_maskModuleAssets, _masksGameObject.transform, _rigBones, instantiateMaterials: true, _customisationOption?.MeshMaterialBinding, _maskInstances);
				AnimatorRebind(restoreFromSave);
				InstantiateParticleFX();
				Material eyeLidMaterial = ((!(mask.EyeLidMaterialSelectionOverride == null)) ? mask.EyeLidMaterialSelectionOverride.FindMatchingMaterial(_skinToneMaterial) : _eyeLidMaterial);
				_eyeBlinking.SetupEyeBlinking(_maskInstances, eyeLidMaterial);
			}
			SetLayer(_currentLayer, force: true);
		}

		private void ApplySkinOverride()
		{
			if (_skinMaterialSelectionOverride != null)
			{
				Material source = _skinMaterialSelectionOverride.FindMatchingMaterial(_skinToneMaterial);
				_overrideSkinMaterialInstance = new Material(source);
				if (_moduleInstances != null)
				{
					foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
					{
						for (int i = 0; i < moduleInstance.OriginalMaterials.Length; i++)
						{
							if (moduleInstance.MaterialModes[i] == CharModule.MaterialMode.Skin)
							{
								Material[] materials = moduleInstance.Renderer.materials;
								materials[i] = _overrideSkinMaterialInstance;
								moduleInstance.Renderer.materials = materials;
							}
						}
					}
				}
				if (_maskInstances != null)
				{
					foreach (CharModule.ModuleInstance maskInstance in _maskInstances)
					{
						for (int j = 0; j < maskInstance.OriginalMaterials.Length; j++)
						{
							if (maskInstance.MaterialModes[j] == CharModule.MaterialMode.Skin)
							{
								Material[] materials2 = maskInstance.Renderer.materials;
								materials2[j] = _overrideSkinMaterialInstance;
								maskInstance.Renderer.materials = materials2;
							}
						}
					}
				}
			}
			else
			{
				if (_moduleInstances != null)
				{
					foreach (CharModule.ModuleInstance moduleInstance2 in _moduleInstances)
					{
						moduleInstance2.Renderer.materials = moduleInstance2.OriginalMaterials;
					}
				}
				if (_maskInstances != null)
				{
					foreach (CharModule.ModuleInstance maskInstance2 in _maskInstances)
					{
						maskInstance2.Renderer.materials = maskInstance2.OriginalMaterials;
					}
				}
			}
			_eyeBlinking.Reset();
			_eyeBlinking.SetupEyeBlinking(_moduleInstances, _eyeLidMaterial);
		}

		private void AnimatorRebind(bool restoreFromSave)
		{
			if (!restoreFromSave)
			{
				AnimatorSavedState animatorSavedState = new AnimatorSavedState(_animator);
				_animator.Rebind();
				animatorSavedState.Restore(_animator);
			}
			else
			{
				_animator.Rebind();
			}
			OnRigRebound.InvokeSafe();
			DisableUpdateWhenOffscreen();
		}

		public void SetLayer(int layer, bool force = false)
		{
			if (!force && _currentLayer == layer)
			{
				return;
			}
			_currentLayer = layer;
			_characterGameObject.layer = layer;
			foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
			{
				moduleInstance.Renderer.gameObject.layer = layer;
			}
			if (_maskInstances != null)
			{
				foreach (CharModule.ModuleInstance maskInstance in _maskInstances)
				{
					maskInstance.Renderer.gameObject.layer = layer;
				}
			}
			if (_overlayInstances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance overlayInstance in _overlayInstances)
			{
				overlayInstance.Renderer.gameObject.layer = layer;
			}
		}

		public override void Destroy()
		{
			CharModuleUtils.DestroyModularInstances(_moduleInstances);
			CharModuleUtils.DestroyModularInstances(_maskInstances);
			if (_valueMaterial != null)
			{
				UnityEngine.Object.Destroy(_valueMaterial);
			}
			if (_overrideSkinMaterialInstance != null)
			{
				UnityEngine.Object.Destroy(_overrideSkinMaterialInstance);
			}
			if (_retroMaterial != null)
			{
				_retroVisualManager.ReleaseMaterial(_retroMaterial);
				_retroMaterial = null;
			}
			base.Destroy();
		}

		public void SetActive(bool active)
		{
			if (_characterGameObject != null)
			{
				GameObjectUtils.SetActive(_characterGameObject, active);
			}
		}

		public bool IsActive()
		{
			if (_characterGameObject != null)
			{
				return _characterGameObject.activeSelf;
			}
			return false;
		}
	}
}
