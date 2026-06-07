using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh
{
	public class MaterialBank : MonoBehaviour
	{
		[Serializable]
		public class BankEntry
		{
			public Material originalMaterial;

			public Material replaceMaterial;
		}

		public const string Dissolve = "dissolve";

		public const string Dissolve3Box = "dissolve3box";

		public string bankName;

		public Material meshRendererMaterialTemplate;

		public Material spriteRendererMaterialTemplate;

		public List<BankEntry> bankEntries;

		public List<Material> generatedMaterials;

		public List<string> ignoreShadersWithKeywords;

		private static readonly int Color;

		private static readonly int MainTex;

		private static readonly int Glossiness;

		private static readonly int Metallic;

		public static Dictionary<string, MaterialBank> AllBanks { get; private set; }

		private void Awake()
		{
		}

		public List<Material> ReplaceMaterials(GameObject obj, bool revert = false)
		{
			return null;
		}

		public Material ReplaceMaterial(Renderer rend, Material materialTemplate, bool revert)
		{
			return null;
		}

		public Material GenerateMaterial(Material baseMaterial, Material templateMaterial)
		{
			return null;
		}
	}
}
