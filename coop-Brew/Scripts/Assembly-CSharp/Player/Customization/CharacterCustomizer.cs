using System.Collections.Generic;
using BrewGame.SaveSystem.Integration;
using Unity.Netcode;
using UnityEngine;

namespace Player.Customization
{
	public class CharacterCustomizer : NetworkBehaviour, ISaveable
	{
		[Header("Model References")]
		[Tooltip("Male character model (body/mesh)")]
		[SerializeField]
		private GameObject maleModel;

		[Tooltip("Female character model (body/mesh)")]
		[SerializeField]
		private GameObject femaleModel;

		[Header("Head Attachments")]
		[Tooltip("Container holding all hat GameObjects (inactive by default)")]
		[SerializeField]
		private Transform hatsContainer;

		[Tooltip("Container holding all glasses GameObjects (inactive by default)")]
		[SerializeField]
		private Transform glassesContainer;

		[Tooltip("Wheat in mouth GameObject (inactive by default)")]
		[SerializeField]
		private GameObject wheat;

		[Header("Skin Color")]
		[Tooltip("Available skin color materials. Index 0 = default. Applied to all SkinnedMeshRenderers on the character.")]
		[SerializeField]
		private Material[] skinMaterials;

		[Header("Debug")]
		[Tooltip("Show debug logs for customization changes")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<CharacterCustomization> customization;

		private GameObject[] hats;

		private GameObject[] glasses;

		public string SaveableId => null;

		public int SavePriority => 0;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public void SetGender(bool isMale)
		{
		}

		public void SetHat(int hatID)
		{
		}

		public void SetGlasses(int glassesID)
		{
		}

		public void SetWheat(bool enabled)
		{
		}

		public void SetSkinColor(int skinColorID)
		{
		}

		public void SetCustomization(CharacterCustomization custom)
		{
		}

		[ServerRpc]
		private void SetGenderServerRpc(bool isMale)
		{
		}

		[ServerRpc]
		private void SetHatServerRpc(int hatID)
		{
		}

		[ServerRpc]
		private void SetGlassesServerRpc(int glassesID)
		{
		}

		[ServerRpc]
		private void SetWheatServerRpc(bool enabled)
		{
		}

		[ServerRpc]
		private void SetSkinColorServerRpc(int skinColorID)
		{
		}

		[ServerRpc]
		private void SetCustomizationServerRpc(CharacterCustomization custom)
		{
		}

		private void OnCustomizationChanged(CharacterCustomization previous, CharacterCustomization current)
		{
		}

		private void ApplyCustomization(CharacterCustomization custom)
		{
		}

		private void ApplyGender(bool isMale)
		{
		}

		private void ApplyHat(int hatID)
		{
		}

		private void ApplyGlasses(int glassesID)
		{
		}

		private void ApplyWheat(bool enabled)
		{
		}

		private void ApplySkinColor(int skinColorID)
		{
		}

		public CharacterCustomization GetCustomization()
		{
			return default(CharacterCustomization);
		}

		public int GetHatCount()
		{
			return 0;
		}

		public int GetGlassesCount()
		{
			return 0;
		}

		public GameObject GetHat(int hatID)
		{
			return null;
		}

		public GameObject GetGlasses(int glassesID)
		{
			return null;
		}

		public int GetSkinColorCount()
		{
			return 0;
		}

		public void PreviewHat(int hatID)
		{
		}

		public void PreviewGlasses(int glassesID)
		{
		}

		public void PreviewWheat(bool enabled)
		{
		}

		public void PreviewGender(bool isMale)
		{
		}

		public void PreviewSkinColor(int skinColorID)
		{
		}

		public void PreviewCustomization(CharacterCustomization custom)
		{
		}

		public void SaveToPlayerPrefs()
		{
		}

		public void LoadFromPlayerPrefs()
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1975340521(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1019594975(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3388767927(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2372055783(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3940023301(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4274855972(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
