using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Minamolc/Visual Effects Data")]
public class VisualEffectStylesData : ScriptableObject
{
	[Serializable]
	public struct CustomBlockMaterialModel
	{
		public string id;

		public Material mainNormal;

		public Material mainTransparent;

		public Material placeholderGreen;

		public Material placeholderRed;
	}

	[Header("Rigidbody Visual Effects")]
	[Space(5f)]
	public List<GameObject> rbImpactDecalList;

	public List<GameObject> rbImpactParticlesList;

	public GameObject rbDragSparkParticles;

	[Header("Block Body Visual Effects")]
	[Space(5f)]
	public GameObject bbJointBreakParticlesPrefab;

	[Header("Block Components Visual Effects")]
	[Space(5f)]
	public GameObject cannonFireParticlesPrefab;

	public GameObject multiThrusterParticlesPrefab;

	public GameObject solidRocketParticlesPrefab;

	[Header("Dynamic Objects Visual Effects")]
	[Space(5f)]
	public GameObject landMineExplosionPrefab;

	public GameObject tntCrateExplosionPrefab;

	public GameObject explosionDecalPrefab;

	public GameObject explosionDirtDecalPrefab;

	[Header("Collectables Visual Effects")]
	[Space(5f)]
	public GameObject goldStarParticlesPrefab;

	public GameObject silverStarParticlesPrefab;

	[Header("Custom Block Materials")]
	[Space(5f)]
	public List<CustomBlockMaterialModel> customBlockMaterials;

	public CustomBlockMaterialModel GetCustomBlockMaterialModel(string id)
	{
		for (int i = 0; i < customBlockMaterials.Count; i++)
		{
			if (customBlockMaterials[i].id == id)
			{
				return customBlockMaterials[i];
			}
		}
		return default(CustomBlockMaterialModel);
	}
}
