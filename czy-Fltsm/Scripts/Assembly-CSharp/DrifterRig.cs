using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama;
using PajamaLlama.Extensions;
using UnityEngine;

public class DrifterRig : MonoBehaviour
{
	[Header("Gender")]
	public Agent.EGender Gender;

	[Header("Components")]
	public MeshAnimator MeshAnimator;

	public OutlineRenderController OutlineRenderController;

	public DrifterEyesHandler EyesHandler;

	public AnimationTools AnimationTools;

	[Header("Body Parts")]
	[SerializeField]
	private SkinnedMeshRenderer _headRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _earsRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _eyesRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _noseRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _mouthRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _bodyRenderer;

	[Header("Hair")]
	[SerializeField]
	private SkinnedMeshRenderer _haircutRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _eyebrowsRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _moustacheRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _beardRenderer;

	[Header("Clothing")]
	[SerializeField]
	private SkinnedMeshRenderer _topRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _pantsRenderer;

	[SerializeField]
	private SkinnedMeshRenderer _shoesRenderer;

	private int _portraitLayer;

	private Activity _portraitActivity = Activity.None;

	public int AttributeVariation { get; private set; }

	public Activity CurrentActivity => _portraitActivity;

	public DrifterLookMaterialProperties BodyColor { get; set; }

	public DrifterLookPart Head { get; private set; }

	public DrifterLookPart Ears { get; private set; }

	public DrifterLookMaterialProperties EyesLook { get; set; }

	public DrifterLookPart Eyes { get; private set; }

	public DrifterLookPart Nose { get; private set; }

	public DrifterLookMaterialProperties MouthLook { get; set; }

	public DrifterLookPart Mouth { get; private set; }

	public DrifterLookPart Body { get; private set; }

	public DrifterLookMaterialProperties HairColor { get; set; }

	public DrifterLookPart Haircut { get; private set; }

	public DrifterLookPart Eyebrows { get; private set; }

	public DrifterLookPart Moustache { get; private set; }

	public DrifterLookPart Beard { get; private set; }

	public DrifterLookMaterialProperties TopColor { get; set; }

	public DrifterLookPart Top { get; private set; }

	public DrifterLookMaterialProperties PantsColor { get; set; }

	public DrifterLookPart Pants { get; private set; }

	public DrifterLookMaterialProperties ShoesColor { get; set; }

	public DrifterLookPart Shoes { get; private set; }

	public List<ParticleSystem> ParticleSystems { get; private set; }

	private void Awake()
	{
		_portraitLayer = LayerMask.NameToLayer("CharacterPortrait");
		if (AnimationTools == null)
		{
			AnimationTools = GetComponentInChildren<AnimationTools>();
		}
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void UpdateActivity(Activity activity, bool forceUpdate = false)
	{
		if (forceUpdate || activity != _portraitActivity)
		{
			_portraitActivity = activity;
			AnimationTools.ClearAnimationTools();
			EyesHandler.UpdateEyestate(activity);
			MeshAnimator.UpdateAnimator(triggerActivity: true, 0);
		}
	}

	public void UpdatePortraitActivity(AgentDescriptor descriptor, Activity activity, bool forceUpdate = false)
	{
		if (forceUpdate || activity != _portraitActivity)
		{
			_portraitActivity = activity;
			AnimationTools.ClearAnimationTools();
			EyesHandler.UpdateEyestate(activity);
			MeshAnimator.UpdatePortraitAnimator(descriptor, activity);
		}
	}

	public void SetAttributeVariation(int variation)
	{
		AttributeVariation = variation;
		MeshAnimator.Animator.SetInteger("Attribute", variation);
	}

	public void CopyTo(DrifterRig rig)
	{
		rig.SetAttributeVariation(AttributeVariation);
		rig.BodyColor = BodyColor;
		rig.EyesLook = EyesLook;
		rig.MouthLook = MouthLook;
		rig.HairColor = HairColor;
		rig.TopColor = TopColor;
		rig.PantsColor = PantsColor;
		rig.ShoesColor = ShoesColor;
		rig.SetHead(Head);
		rig.SetEars(Ears);
		rig.SetEyes(Eyes);
		rig.SetNose(Nose);
		rig.SetMouth(Mouth);
		rig.SetBody(Body);
		rig.SetHaircut(Haircut);
		rig.SetEyebrows(Eyebrows);
		rig.SetMoustache(Moustache);
		rig.SetBeard(Beard);
		rig.SetTop(Top);
		rig.SetPants(Pants);
		rig.SetShoes(Shoes);
	}

	public void SetShadows(bool active)
	{
		_headRenderer.receiveShadows = active;
		_earsRenderer.receiveShadows = active;
		_eyesRenderer.receiveShadows = active;
		_noseRenderer.receiveShadows = active;
		_mouthRenderer.receiveShadows = active;
		_bodyRenderer.receiveShadows = active;
		_haircutRenderer.receiveShadows = active;
		_eyebrowsRenderer.receiveShadows = active;
		_moustacheRenderer.receiveShadows = active;
		_beardRenderer.receiveShadows = active;
		_topRenderer.receiveShadows = active;
		_pantsRenderer.receiveShadows = active;
		_shoesRenderer.receiveShadows = active;
	}

	public void SetHeadPortraitLayer()
	{
		LayerMask.NameToLayer("CharacterPortrait");
		_headRenderer.gameObject.layer = _portraitLayer;
		_earsRenderer.gameObject.layer = _portraitLayer;
		_eyesRenderer.gameObject.layer = _portraitLayer;
		_noseRenderer.gameObject.layer = _portraitLayer;
		_mouthRenderer.gameObject.layer = _portraitLayer;
		_haircutRenderer.gameObject.layer = _portraitLayer;
		_eyebrowsRenderer.gameObject.layer = _portraitLayer;
		_moustacheRenderer.gameObject.layer = _portraitLayer;
		_beardRenderer.gameObject.layer = _portraitLayer;
	}

	public void SetPortraitLayer()
	{
		LayerMask.NameToLayer("CharacterPortrait");
		_headRenderer.gameObject.layer = _portraitLayer;
		_earsRenderer.gameObject.layer = _portraitLayer;
		_eyesRenderer.gameObject.layer = _portraitLayer;
		_noseRenderer.gameObject.layer = _portraitLayer;
		_mouthRenderer.gameObject.layer = _portraitLayer;
		_bodyRenderer.gameObject.layer = _portraitLayer;
		_haircutRenderer.gameObject.layer = _portraitLayer;
		_eyebrowsRenderer.gameObject.layer = _portraitLayer;
		_moustacheRenderer.gameObject.layer = _portraitLayer;
		_beardRenderer.gameObject.layer = _portraitLayer;
		_topRenderer.gameObject.layer = _portraitLayer;
		_pantsRenderer.gameObject.layer = _portraitLayer;
		_shoesRenderer.gameObject.layer = _portraitLayer;
	}

	public void SetPart(SkinnedMeshRenderer renderer, DrifterLookPart part, DrifterLookMaterialProperties material)
	{
		if (part == null)
		{
			Debug.LogException(new Exception("Tried to set part on mesh renderer " + renderer.name + ", but part passed was null"));
		}
		else
		{
			renderer.sharedMesh = part.Mesh;
		}
		if (material == null)
		{
			Debug.LogException(new Exception("Tried to set material on mesh renderer " + renderer.name + ", but material passed was null"));
		}
		else
		{
			renderer.sharedMaterial = material.Material;
		}
	}

	public void SetBodyMaterialProperties(DrifterLookMaterialProperties materialProperties)
	{
		if (!(materialProperties == null))
		{
			BodyColor = materialProperties;
			_headRenderer.sharedMaterial = materialProperties.Material;
			_earsRenderer.sharedMaterial = materialProperties.Material;
			_noseRenderer.sharedMaterial = materialProperties.Material;
			_bodyRenderer.sharedMaterial = materialProperties.Material;
		}
	}

	public void SetEyesMaterialProperties(DrifterLookMaterialProperties materialProperties)
	{
		if (!(materialProperties == null))
		{
			EyesLook = materialProperties;
			_eyesRenderer.sharedMaterial = materialProperties.Material;
		}
	}

	public void SetMouthMaterialProperties(DrifterLookMaterialProperties materialProperties)
	{
		if (!(materialProperties == null))
		{
			MouthLook = materialProperties;
			_mouthRenderer.sharedMaterial = materialProperties.Material;
		}
	}

	public void SetHairMaterialProperties(DrifterLookMaterialProperties materialProperties)
	{
		if (!(materialProperties == null))
		{
			HairColor = materialProperties;
			_haircutRenderer.sharedMaterial = materialProperties.Material;
			_eyebrowsRenderer.sharedMaterial = materialProperties.Material;
			_moustacheRenderer.sharedMaterial = materialProperties.Material;
			_beardRenderer.sharedMaterial = materialProperties.Material;
		}
	}

	public void SetTopMaterialProperties(DrifterLookMaterialProperties materialProperties)
	{
		if (!(materialProperties == null))
		{
			TopColor = materialProperties;
			_topRenderer.sharedMaterial = materialProperties.Material;
		}
	}

	public void SetPantsMaterialProperties(DrifterLookMaterialProperties materialProperties)
	{
		if (!(materialProperties == null))
		{
			PantsColor = materialProperties;
			_pantsRenderer.sharedMaterial = materialProperties.Material;
		}
	}

	public void SetShoesMaterialProperties(DrifterLookMaterialProperties materialProperties)
	{
		if (!(materialProperties == null))
		{
			ShoesColor = materialProperties;
			_shoesRenderer.sharedMaterial = materialProperties.Material;
		}
	}

	public void SetHead(DrifterLookPart part)
	{
		Head = part;
		SetPart(_headRenderer, part, BodyColor);
	}

	public void SetEars(DrifterLookPart part)
	{
		Ears = part;
		SetPart(_earsRenderer, part, BodyColor);
	}

	public void SetEyes(DrifterLookPart part)
	{
		Eyes = part;
		SetPart(_eyesRenderer, part, EyesLook);
	}

	public void SetNose(DrifterLookPart part)
	{
		Nose = part;
		SetPart(_noseRenderer, part, BodyColor);
	}

	public void SetMouth(DrifterLookPart part)
	{
		Mouth = part;
		SetPart(_mouthRenderer, part, MouthLook);
	}

	public void SetBody(DrifterLookPart part)
	{
		Body = part;
		SetPart(_bodyRenderer, part, BodyColor);
	}

	public void SetHaircut(DrifterLookPart part)
	{
		Haircut = part;
		SetPart(_haircutRenderer, part, HairColor);
	}

	public void SetEyebrows(DrifterLookPart part)
	{
		Eyebrows = part;
		SetPart(_eyebrowsRenderer, part, HairColor);
	}

	public void SetMoustache(DrifterLookPart part)
	{
		Moustache = part;
		SetPart(_moustacheRenderer, part, HairColor);
	}

	public void SetBeard(DrifterLookPart part)
	{
		Beard = part;
		SetPart(_beardRenderer, part, HairColor);
	}

	public void SetTop(DrifterLookPart part)
	{
		Top = part;
		SetPart(_topRenderer, part, TopColor);
	}

	public void SetPants(DrifterLookPart part)
	{
		Pants = part;
		SetPart(_pantsRenderer, part, PantsColor);
	}

	public void SetShoes(DrifterLookPart part)
	{
		Shoes = part;
		SetPart(_shoesRenderer, part, ShoesColor);
	}

	public void ClearParticleSystems()
	{
		if (ParticleSystems.IsNullOrEmpty())
		{
			return;
		}
		int count = ParticleSystems.Count;
		while (0 < count--)
		{
			ParticleSystem particleSystem = ParticleSystems[count];
			particleSystem.Stop();
			if (base.gameObject.activeSelf)
			{
				StartCoroutine(RepoolParticleSystemCoroutine(particleSystem));
			}
			else
			{
				RepoolParticleSystem(particleSystem);
			}
		}
	}

	public void SetParticleSystem(ParticleSystem particleSystemPrefab, string particleSystemParent)
	{
		Transform transform = base.transform.Find(particleSystemParent);
		if (transform == null)
		{
			Debug.LogWarningFormat("Unable to attach particle system '{0}' to parent '{1}' because the parent does not exist.", particleSystemPrefab.name, particleSystemParent);
		}
		ParticleSystem instance = PrefabPool.GetInstance(particleSystemPrefab, transform);
		instance.transform.CopyLocalPositionRotationAndScale(particleSystemPrefab.transform);
		instance.Play();
		if (ParticleSystems == null)
		{
			ParticleSystems = new List<ParticleSystem> { instance };
		}
		else
		{
			ParticleSystems.Add(instance);
		}
	}

	private IEnumerator RepoolParticleSystemCoroutine(ParticleSystem particleSystem)
	{
		while (particleSystem.IsAlive())
		{
			yield return null;
		}
		RepoolParticleSystem(particleSystem);
	}

	private void RepoolParticleSystem(ParticleSystem particleSystem)
	{
		PrefabPool.Repool(particleSystem);
		ParticleSystems.Remove(particleSystem);
	}

	public void Randomize(DrifterLookProperties properties)
	{
		properties.SetRandomBodyColor(this);
		properties.SetRandomEyesLook(this);
		properties.SetRandomMouthLook(this);
		properties.SetRandomHairColor(this);
		properties.SetRandomClothingColors(this);
		properties.SetRandomHead(this);
		properties.SetRandomEars(this);
		properties.SetRandomEyes(this);
		properties.SetRandomNose(this);
		properties.SetRandomMouth(this);
		properties.SetRandomBody(this);
		properties.SetRandomHaircut(this);
		properties.SetRandomEyebrows(this);
		properties.SetRandomMoustache(this);
		properties.SetRandomBeard(this);
		properties.SetRandomTop(this);
		properties.SetRandomPants(this);
		properties.SetRandomShoes(this);
	}

	public void Restore(DrifterRigPersistentData data, AgentDescriptor agentDescriptor)
	{
		DrifterLookProperties lookProperties = agentDescriptor.LookProperties;
		SetAttributeVariation(data.AttributeVariation);
		BodyColor = RestoreMaterial(data.BodyColor, lookProperties.BodyMaterialProperties, agentDescriptor);
		EyesLook = RestoreMaterial(data.EyesLook, lookProperties.EyesMaterialProperties, agentDescriptor);
		MouthLook = RestoreMaterial(data.MouthLook, lookProperties.MouthMaterialProperties, agentDescriptor);
		HairColor = RestoreMaterial(data.HairColor, lookProperties.HairMaterialProperties, agentDescriptor);
		TopColor = RestoreMaterial(data.TopColor, lookProperties.ClothingMaterialProperties, agentDescriptor);
		PantsColor = RestoreMaterial(data.PantsColor, lookProperties.ClothingMaterialProperties, agentDescriptor);
		ShoesColor = RestoreMaterial(data.ShoesColor, lookProperties.ClothingMaterialProperties, agentDescriptor);
		SetHead(RestorePart(data.Head, lookProperties.Heads, agentDescriptor));
		SetEars(RestorePart(data.Ears, lookProperties.Ears, agentDescriptor));
		SetEyes(RestorePart(data.Eyes, lookProperties.Eyes, agentDescriptor));
		SetNose(RestorePart(data.Nose, lookProperties.Noses, agentDescriptor));
		SetMouth(RestorePart(data.Mouth, lookProperties.Mouths, agentDescriptor));
		SetBody(RestorePart(data.Body, lookProperties.Bodies, agentDescriptor));
		SetHaircut(RestorePart(data.Haircut, lookProperties.Haircuts, agentDescriptor));
		SetEyebrows(RestorePart(data.Eyebrows, lookProperties.Eyebrows, agentDescriptor));
		SetMoustache(RestorePart(data.Moustache, lookProperties.Moustaches, agentDescriptor));
		SetBeard(RestorePart(data.Beard, lookProperties.Beards, agentDescriptor));
		SetTop(RestorePart(data.Top, lookProperties.Tops, agentDescriptor));
		SetPants(RestorePart(data.Pants, lookProperties.Pants, agentDescriptor));
		SetShoes(RestorePart(data.Shoes, lookProperties.Shoes, agentDescriptor));
	}

	private DrifterLookPart RestorePart(int index, DrifterLookPart[] fallbackParts, AgentDescriptor agentDescriptor)
	{
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterLookPart>(index, out var reference))
		{
			return reference;
		}
		reference = fallbackParts.GetRandom();
		Debug.LogException(new Exception($"Unable to restore body part for '{agentDescriptor.Name}'. It has been replaced by '{reference}'"));
		return reference;
	}

	private DrifterLookMaterialProperties RestoreMaterial(int index, DrifterLookMaterialProperties[] fallbackMaterials, AgentDescriptor agentDescriptor)
	{
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterLookMaterialProperties>(index, out var reference))
		{
			return reference;
		}
		reference = fallbackMaterials.GetRandom();
		Debug.LogException(new Exception($"Unable to restore body part meterial for '{agentDescriptor.Name}'. It has been replaced by '{reference}'"));
		return reference;
	}

	public static DrifterRig Copy(DrifterRig rig)
	{
		DrifterRig drifterRig = UnityEngine.Object.Instantiate(rig);
		rig.CopyTo(drifterRig);
		return drifterRig;
	}

	public static DrifterRig Instantiate(AgentDescriptor agentDescriptor, Transform parent = null, DrifterRigPersistentData persistentData = null)
	{
		DrifterRig drifterRig = UnityEngine.Object.Instantiate(agentDescriptor.LookProperties.RigPrefab, parent);
		drifterRig.gameObject.AddComponent<OutlineRenderController>().IncludeSubMeshes = true;
		drifterRig.MeshAnimator.Initialize();
		if (persistentData != null)
		{
			drifterRig.Restore(persistentData, agentDescriptor);
		}
		return drifterRig;
	}
}
