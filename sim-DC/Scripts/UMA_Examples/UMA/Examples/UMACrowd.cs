using UnityEngine;

namespace UMA.Examples
{
	public class UMACrowd : MonoBehaviour
	{
		public UMACrowdRandomSet[] randomPool;

		public UMAGeneratorBase generator;

		public UMAData umaData;

		public UMAContextBase UMAContextBase;

		public RuntimeAnimatorController animationController;

		public float atlasResolutionScale;

		public bool generateUMA;

		public bool generateLotsUMA;

		public bool hideWhileGeneratingLots;

		public bool stressTest;

		public Vector2 umaCrowdSize;

		public bool randomDna;

		public bool allAtOnce;

		public UMARecipeBase[] additionalRecipes;

		public float space;

		public Transform zeroPoint;

		private int spawnX;

		private int spawnY;

		public SharedColorTable SkinColors;

		public SharedColorTable HairColors;

		public string[] keywords;

		public UMADataEvent CharacterCreated;

		public UMADataEvent CharacterDestroyed;

		public UMADataEvent CharacterUpdated;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void DefineSlots(UMACrowdRandomSet.CrowdRaceData race)
		{
		}

		private void DefineSlots()
		{
		}

		protected virtual void SetUMAData()
		{
		}

		private void CharacterCreatedCallback(UMAData umaData)
		{
		}

		public static void RandomizeShape(UMAData umaData)
		{
		}

		private static void RandomizeShapeLegacy(UMAData umaData)
		{
		}

		protected virtual void GenerateUMAShapes()
		{
		}

		public void ResetSpawnPos()
		{
		}

		public GameObject GenerateUMA(int sex, Vector3 position)
		{
			return null;
		}

		public GameObject GenerateOneUMA(int sex)
		{
			return null;
		}

		private void AddAdditionalSlots()
		{
		}

		public void ReplaceAll()
		{
		}

		public void RandomizeAllDna()
		{
		}

		public void RandomizeAll()
		{
		}
	}
}
