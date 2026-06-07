using System;
using UnityEngine;

namespace UMA
{
	public abstract class UMARecipeBase : ScriptableObject
	{
		protected UMAData.UMARecipe umaRecipe;

		protected bool cached;

		public string label;

		[Tooltip("This will be skipped when generating Addressable Groups. This can result in duplicate assets.")]
		public bool resourcesOnly;

		[NonSerialized]
		private static Type[] recipeFormats;

		public string AssignedLabel => null;

		public abstract void Load(UMAData.UMARecipe umaRecipe, UMAContextBase context, bool loadSlots = true);

		public abstract void Save(UMAData.UMARecipe umaRecipe, UMAContextBase context);

		public abstract string GetInfo();

		public abstract byte[] GetBytes();

		public abstract void SetBytes(byte[] data);

		public override string ToString()
		{
			return null;
		}

		public virtual int GetTypeNameHash()
		{
			return 0;
		}

		public UMAData.UMARecipe GetCachedRecipe(UMAContextBase context, bool loadSlots = true)
		{
			return null;
		}

		public static Type[] GetRecipeFormats()
		{
			return null;
		}

		public static Type FindRecipeFormat(int typeNameHash)
		{
			return null;
		}
	}
}
