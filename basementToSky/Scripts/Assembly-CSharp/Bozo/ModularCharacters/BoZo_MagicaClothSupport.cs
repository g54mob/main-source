using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bozo.ModularCharacters
{
	public class BoZo_MagicaClothSupport : MonoBehaviour, IOutfitExtension<Texture2D>, IOutfitExtension
	{
		public enum ClothType
		{
			Mesh = 0,
			Bone = 1,
			Spring = 2
		}

		public const string id = "MagicaClothExtension";

		private bool initalized;

		private OutfitSystem system;

		public ClothType type;

		public SkinnedMeshRenderer skinnedMeshRenderer;

		public string[] disableByTag;

		public bool InitalizeOnStart;

		[Header("Bones")]
		public bool boneReferenceByString;

		public List<Transform> rootBones;

		public List<string> rootBonesString;

		public float collisionSize = 0.025f;

		public AnimationCurve collisionCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));

		[Header("Mesh")]
		public Texture2D influenceMap;

		[Range(0f, 0.2f)]
		public float reductionSetting = 0.065f;

		[Header("Preset")]
		public TextAsset clothPreset;

		public List<Transform> transforms = new List<Transform>();

		public Texture2D GetValue()
		{
			return influenceMap;
		}

		object IOutfitExtension.GetValue()
		{
			return influenceMap;
		}

		public Type GetValueType()
		{
			return typeof(Texture2D);
		}

		private void OnEnable()
		{
			system = GetComponentInParent<OutfitSystem>();
			if ((bool)system)
			{
				OutfitSystem outfitSystem = system;
				outfitSystem.OnRigChanged = (UnityAction<SkinnedMeshRenderer>)Delegate.Combine(outfitSystem.OnRigChanged, new UnityAction<SkinnedMeshRenderer>(OnCharacterMerged));
			}
			if ((bool)system)
			{
				OutfitSystem outfitSystem2 = system;
				outfitSystem2.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Combine(outfitSystem2.OnOutfitChanged, new UnityAction<Outfit>(DisableClothByTag));
			}
		}

		private void OnDisable()
		{
			system = GetComponentInParent<OutfitSystem>();
			if ((bool)system)
			{
				OutfitSystem outfitSystem = system;
				outfitSystem.OnRigChanged = (UnityAction<SkinnedMeshRenderer>)Delegate.Remove(outfitSystem.OnRigChanged, new UnityAction<SkinnedMeshRenderer>(OnCharacterMerged));
			}
			if ((bool)system)
			{
				OutfitSystem outfitSystem2 = system;
				outfitSystem2.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Remove(outfitSystem2.OnOutfitChanged, new UnityAction<Outfit>(DisableClothByTag));
			}
		}

		private void Start()
		{
			if (InitalizeOnStart)
			{
				Initalize(null, null);
				Execute(null, null);
			}
		}

		public void Initalize(OutfitSystem outfitSystem, Outfit outfit)
		{
		}

		private void OnCharacterMerged(SkinnedMeshRenderer rig)
		{
		}

		private void DisableClothByTag(Outfit outfit)
		{
		}

		public void Execute(OutfitSystem outfitSystem, Outfit outfit)
		{
		}

		public string GetID()
		{
			return "MagicaClothExtension";
		}
	}
}
