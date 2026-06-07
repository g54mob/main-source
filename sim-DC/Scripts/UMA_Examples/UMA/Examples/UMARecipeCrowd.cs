using UnityEngine;

namespace UMA.Examples
{
	public class UMARecipeCrowd : MonoBehaviour
	{
		public UMAContextBase context;

		public UMAGeneratorBase generator;

		public RuntimeAnimatorController animationController;

		public float atlasScale;

		public bool hideWhileGenerating;

		public bool stressTest;

		public Vector2 crowdSize;

		public float space;

		private int spawnX;

		private int spawnY;

		private bool generating;

		public bool saveCrowd;

		private string saveFolderPath;

		public SharedColorTable[] sharedColors;

		public UMARecipeMixer[] recipeMixers;

		public UMADataEvent CharacterCreated;

		public UMADataEvent CharacterDestroyed;

		public UMADataEvent CharacterUpdated;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void CharacterCreatedCallback(UMAData umaData)
		{
		}

		public GameObject GenerateOneCharacter()
		{
			return null;
		}

		public void ReplaceAll()
		{
		}

		public virtual void RandomizeRecipe(UMAData umaData)
		{
		}

		public virtual void RandomizeDNA(UMAData umaData)
		{
		}

		public virtual void RandomizeDNAGaussian(UMAData umaData)
		{
		}

		public void RandomizeAll()
		{
		}
	}
}
