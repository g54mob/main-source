using System;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.API.Requests;

namespace ModIO.Implementation
{
	internal static class ResponseTranslator
	{
		private const int ModProfileNullId = 0;

		private const int ModProfileUnsetFilesize = -1;

		private static readonly DateTime UnixEpoch;

		public static TermsOfUse ConvertTermsObjectToTermsOfUse(TermsObject termsObject)
		{
			return default(TermsOfUse);
		}

		public static TagCategory[] ConvertGameTagOptionsObjectToTagCategories(GameTagOptionObject[] gameTags)
		{
			return null;
		}

		public static ModPage ConvertResponseSchemaToModPage(GetMods.ResponseSchema schema, SearchFilter filter)
		{
			return default(ModPage);
		}

		public static ModPage ConvertResponseSchemaToModPage(PaginatedResponse<ModObject> schema, SearchFilter filter)
		{
			return default(ModPage);
		}

		public static Rating[] ConvertModRatingsObjectToRatings(RatingObject[] ratingObjects)
		{
			return null;
		}

		public static ModDependencies[] ConvertModDependenciesObjectToModDependencies(ModDependenciesObject[] modDependenciesObjects)
		{
			return null;
		}

		public static CommentPage ConvertModCommentObjectsToCommentPage(PaginatedResponse<ModCommentObject> commentObjects)
		{
			return default(CommentPage);
		}

		public static ModComment ConvertModCommentObjectsToModComment(ModCommentObject modCommentObjects)
		{
			return default(ModComment);
		}

		public static ModProfile[] ConvertModObjectsToModProfile(ModObject[] modObjects)
		{
			return null;
		}

		public static ModProfile ConvertModObjectToModProfile(ModObject modObject)
		{
			return default(ModProfile);
		}

		private static DownloadReference CreateDownloadReference(string filename, string url, ModId modId)
		{
			return default(DownloadReference);
		}

		public static UserProfile ConvertUserObjectToUserProfile(UserObject userObject)
		{
			return default(UserProfile);
		}

		public static DateTime GetUTCDateTime(long serverTimeStamp)
		{
			return default(DateTime);
		}
	}
}
