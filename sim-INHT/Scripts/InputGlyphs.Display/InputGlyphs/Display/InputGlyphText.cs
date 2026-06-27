using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputGlyphs.Display
{
	public class InputGlyphText : MonoBehaviour
	{
		public static int PackedTextureSize;

		[SerializeField]
		public TMP_Text Text;

		[SerializeField]
		[HideInInspector]
		public Material Material;

		[SerializeField]
		public PlayerInput PlayerInput;

		[SerializeField]
		public InputActionReference[] InputActionReferences;

		[SerializeField]
		public GlyphsLayoutData GlyphsLayoutData;

		private PlayerInput _lastPlayerInput;

		private List<string> _pathBuffer;

		private List<Texture2D> _actionTextureBuffer;

		private List<Tuple<string, int>> _actionTextureIndexes;

		private List<Texture2D> _copiedTextureBuffer;

		private Texture2D _packedTexture;

		private Material _sharedMaterial;

		private TMP_SpriteAsset _sharedSpriteAsset;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void RegisterPlayerInputEvents(PlayerInput playerInput)
		{
		}

		private void UnregisterPlayerInputEvents(PlayerInput playerInput)
		{
		}

		private void OnControlsChanged(PlayerInput playerInput)
		{
		}

		public void UpdateGlyphs()
		{
		}

		private void UpdateGlyphs(PlayerInput playerInput)
		{
		}

		private void SetGlyphsToSpriteAsset(IReadOnlyList<Texture2D> actionTextures, IReadOnlyList<Tuple<string, int>> actionTextureIndexes)
		{
		}

		private static TMP_SpriteAsset CreateEmptySpriteAsset()
		{
			return null;
		}

		private static void SetSpriteAssetVersion(TMP_SpriteAsset spriteAsset, string version)
		{
		}
	}
}
