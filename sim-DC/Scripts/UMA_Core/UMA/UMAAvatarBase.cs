using UnityEngine;

namespace UMA
{
	public abstract class UMAAvatarBase : MonoBehaviour
	{
		public UMAContextBase context;

		public UMAData umaData;

		[Tooltip("The default renderer asset to use for this avatar. This lets you set parameters for the generated SkinnedMeshRenderer")]
		public UMARendererAsset defaultRendererAsset;

		public UMARecipeBase umaRecipe;

		public UMARecipeBase[] umaAdditionalRecipes;

		public UMAGeneratorBase umaGenerator;

		public RuntimeAnimatorController animationController;

		protected RaceData umaRace;

		public UMADataEvent CharacterCreated;

		public UMADataEvent CharacterBegun;

		public UMADataEvent CharacterDestroyed;

		public UMADataEvent CharacterUpdated;

		public UMADataEvent CharacterDnaUpdated;

		public UMADataEvent AnimatorStateSaved;

		public UMADataEvent AnimatorStateRestored;

		public virtual void Start()
		{
		}

		public void Initialize()
		{
		}

		public virtual void Load(UMARecipeBase umaRecipe)
		{
		}

		public virtual void Load(UMARecipeBase umaRecipe, params UMARecipeBase[] umaAdditionalRecipes)
		{
		}

		public void UpdateSameRace()
		{
		}

		public void UpdateNewRace()
		{
		}

		public virtual void Hide()
		{
		}

		public virtual void Hide(bool DestroyRoot = true)
		{
		}

		public virtual void Show()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
