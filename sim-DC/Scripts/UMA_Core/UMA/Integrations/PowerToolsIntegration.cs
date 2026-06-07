using System;
using UnityEngine;

namespace UMA.Integrations
{
	public static class PowerToolsIntegration
	{
		private static Type powerPackPersistance;

		private static Type umaEditorAvatarType;

		private static Type GetPowerPackPersistanceType()
		{
			return null;
		}

		private static Type GetUMAEditorAvatarType()
		{
			return null;
		}

		private static UnityEngine.Object GetPowerPackPersistanceInstance()
		{
			return null;
		}

		private static void ReleasePowerPackPersistanceInstance(UnityEngine.Object instance)
		{
		}

		public static bool HasPowerTools()
		{
			return false;
		}

		public static GameObject GetPreview(UMARecipeBase recipeBase)
		{
			return null;
		}

		public static bool HasPreview(UMARecipeBase recipeBase)
		{
			return false;
		}

		public static void Show(UMARecipeBase recipeBase)
		{
		}

		private static void SetAvatarDestroyParent(UMADynamicAvatar avatar, bool destroyParent)
		{
		}

		public static void Hide(UMARecipeBase recipeBase)
		{
		}

		public static void Refresh(UMARecipeBase recipeBase)
		{
		}

		public static void HideAll()
		{
		}
	}
}
