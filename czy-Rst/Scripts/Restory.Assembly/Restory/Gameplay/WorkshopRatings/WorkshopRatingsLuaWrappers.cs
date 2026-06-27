using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Gameplay.TimeSystems;
using Zenject;

namespace Restory.Gameplay.WorkshopRatings
{
	public class WorkshopRatingsLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string AddReviewFromNpc = "WorkshopRatings_AddReviewFromNpc";

			public static readonly string SetForcedRating = "WorkshopRatings_SetForcedRating";

			public static readonly string RemoveForcedRating = "WorkshopRatings_RemoveForcedRating";

			public static readonly string GetCurrentRating = "WorkshopRatings_GetCurrentRating";
		}

		private readonly WorkshopRatingsService workshopRatingsService;

		private readonly GameCalendar gameCalendar;

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		public WorkshopRatingsLuaWrappers(WorkshopRatingsService workshopRatingsService, GameCalendar gameCalendar, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
			this.gameCalendar = gameCalendar;
			this.workshopRatingsService = workshopRatingsService;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.AddReviewFromNpc, this, SymbolExtensions.GetMethodInfo(() => AddReviewFromNpc(string.Empty)));
			Lua.RegisterFunction(LuaNames.SetForcedRating, this, SymbolExtensions.GetMethodInfo(() => SetForcedRating(0f)));
			Lua.RegisterFunction(LuaNames.RemoveForcedRating, this, SymbolExtensions.GetMethodInfo(() => RemoveForcedRating()));
			Lua.RegisterFunction(LuaNames.GetCurrentRating, this, SymbolExtensions.GetMethodInfo(() => GetCurrentRating()));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.AddReviewFromNpc);
			Lua.UnregisterFunction(LuaNames.SetForcedRating);
			Lua.UnregisterFunction(LuaNames.RemoveForcedRating);
			Lua.UnregisterFunction(LuaNames.GetCurrentRating);
		}

		private void AddReviewFromNpc(string reviewInfoID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<ReviewInfo>(reviewInfoID, out var entityInfo))
			{
				workshopRatingsService.AddReview(entityInfo.NpcInfo, entityInfo.Comment, entityInfo.Rating, gameCalendar.CurrentDateTime);
			}
		}

		private void SetForcedRating(float ratingValue)
		{
			workshopRatingsService.SetForcedRating(ratingValue);
		}

		private void RemoveForcedRating()
		{
			workshopRatingsService.RemoveForcedRating();
		}

		private float GetCurrentRating()
		{
			return workshopRatingsService.OverallRating;
		}
	}
}
