using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class CharacterColorVariator : MonoBehaviour
	{
		[Serializable]
		public class TraitActorEffectConfiguration
		{
			public string type;

			[Header("skin color")]
			public Color skinTint;

			[Header("particle effects")]
			public GameObject particleEffect;

			[Tooltip("where should the particleEffect be parented to? if not set, it will be added to the Actor directly.")]
			public string parentName;
		}

		public Rect sourceRect;

		public Texture2D characterTextures;

		public Texture2D skinPixels;

		public Texture2D secondarySkinPixels;

		public Texture2D hairPixels;

		public Gradient[] orcSkin;

		public Gradient[] orcSecondarySkin;

		public Gradient[] orcHair;

		public Gradient[] halflingSkin;

		public Gradient[] halflingSecondarySkin;

		public Gradient[] halflingHair;

		public Gradient[] dwarfSkin;

		public Gradient[] dwarfSecondarySkin;

		public Gradient[] dwarfHair;

		public Gradient[] elfSkin;

		public Gradient[] elfSecondarySkin;

		public Gradient[] elfHair;

		public Gradient[] skins;

		public Gradient[] secondarySkins;

		public Gradient[] hairs;

		[Header("Trait configuration")]
		public TraitActorEffectConfiguration[] traitConfiguration;

		private void Start()
		{
		}

		private void CheckConfiguration()
		{
		}

		private void RefreshActiveTraits(GameObjectX gox, AiComponent component, bool removed = false)
		{
		}

		private void ToggleTraitEffects(GameObjectX target, TraitActorEffectConfiguration traitConfig, bool active)
		{
		}

		public void ApplyCharacterColors(Actor actor, Texture2D skinPixelsOverride = null, Texture2D characterTextureOverride = null)
		{
		}

		public void ApplyCharacterColors(ActorData actorData, GameObject model)
		{
		}

		private Texture2D GetSkinTexture(ActorData actorData, Actor actor, Texture2D skinPixelsOverride, Texture2D characterTextureOverride)
		{
			return null;
		}

		private static void ApplyColors(Actor actor, Texture2D destTex)
		{
		}

		private static void ApplyColors(SkinnedMeshRenderer characterMesh, IEnumerable<MeshRenderer> lidMeshes, Texture2D destTex, string actorName)
		{
		}

		public CharacterColors GenerateCharacterColors(string race)
		{
			return null;
		}

		private static CharacterColors CreateCharacterColor(Gradient skin, Gradient secondarySkin, Gradient hair, float skinColor, float hairColor)
		{
			return null;
		}
	}
}
