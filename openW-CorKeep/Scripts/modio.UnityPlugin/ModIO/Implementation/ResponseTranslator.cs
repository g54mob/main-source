using System;
using System.Collections.Generic;
using ModIO.Implementation.API;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.API.Requests;

namespace ModIO.Implementation
{
	internal static class ResponseTranslator
	{
		private const int ModProfileNullId = 0;

		private const int ModProfileUnsetFilesize = -1;

		private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		public static TermsOfUse ConvertTermsObjectToTermsOfUse(TermsObject termsObject)
		{
			TermsOfUse result = new TermsOfUse
			{
				termsOfUse = termsObject.plaintext,
				links = new TermsOfUseLink[4]
			};
			result.links[0] = default(TermsOfUseLink);
			result.links[0].name = termsObject.links.website.text;
			result.links[0].url = termsObject.links.website.url;
			result.links[0].required = termsObject.links.website.required;
			result.links[1] = default(TermsOfUseLink);
			result.links[1].name = termsObject.links.terms.text;
			result.links[1].url = termsObject.links.terms.url;
			result.links[1].required = termsObject.links.terms.required;
			result.links[2] = default(TermsOfUseLink);
			result.links[2].name = termsObject.links.privacy.text;
			result.links[2].url = termsObject.links.privacy.url;
			result.links[2].required = termsObject.links.privacy.required;
			result.links[3] = default(TermsOfUseLink);
			result.links[3].name = termsObject.links.manage.text;
			result.links[3].url = termsObject.links.manage.url;
			result.links[3].required = termsObject.links.manage.required;
			TermsHash termsHash = new TermsHash
			{
				md5hash = IOUtil.GenerateMD5(result.termsOfUse)
			};
			return result;
		}

		public static TagCategory[] ConvertGameTagOptionsObjectToTagCategories(GameTagOptionObject[] gameTags)
		{
			TagCategory[] array = new TagCategory[gameTags.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = default(TagCategory);
				array[i].name = gameTags[i].name ?? "";
				Tag[] array2 = new Tag[gameTags[i].tags.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					gameTags[i].tag_count_map.TryGetValue(gameTags[i].tags[j], out var value);
					array2[j].name = gameTags[i].tags[j] ?? "";
					array2[j].totalUses = value;
				}
				array[i].tags = array2;
				array[i].multiSelect = gameTags[i].type == "checkboxes";
				array[i].hidden = gameTags[i].hidden;
				array[i].locked = gameTags[i].locked;
			}
			return array;
		}

		public static ModPage ConvertResponseSchemaToModPage(GetMods.ResponseSchema schema, SearchFilter filter)
		{
			ModPage result = default(ModPage);
			if (schema == null)
			{
				return result;
			}
			result.totalSearchResultsFound = schema.result_total;
			List<ModProfile> list = new List<ModProfile>();
			int offset = filter.pageSize * filter.pageIndex;
			for (int i = 0; i < filter.pageSize && i < schema.data.Length; i++)
			{
				list.Add(ConvertModObjectToModProfile(schema.data[i]));
			}
			ModProfile[] modProfiles = ((schema.data == null) ? Array.Empty<ModProfile>() : ConvertModObjectsToModProfile(schema.data));
			result.modProfiles = list.ToArray();
			ResponseCache.AddModsToCache(modPage: new ModPage
			{
				totalSearchResultsFound = schema.result_total,
				modProfiles = modProfiles
			}, url: GetMods.UnpaginatedURL(filter), offset: offset);
			return result;
		}

		public static ModPage ConvertResponseSchemaToModPage(PaginatedResponse<ModObject> schema, SearchFilter filter)
		{
			ModPage result = default(ModPage);
			if (schema == null)
			{
				return result;
			}
			result.totalSearchResultsFound = schema.result_total;
			List<ModProfile> list = new List<ModProfile>();
			int num = filter.pageSize * filter.pageIndex;
			int num2 = num + filter.pageSize;
			for (int i = num; i < num2 && i < schema.data.Length; i++)
			{
				list.Add(ConvertModObjectToModProfile(schema.data[i]));
			}
			result.modProfiles = list.ToArray();
			return result;
		}

		public static Rating[] ConvertModRatingsObjectToRatings(RatingObject[] ratingObjects)
		{
			Rating[] array = new Rating[ratingObjects.Length];
			int num = 0;
			for (int i = 0; i < ratingObjects.Length; i++)
			{
				RatingObject ratingObject = ratingObjects[i];
				array[num++] = new Rating
				{
					modId = new ModId(ratingObject.mod_id),
					rating = (ModRating)ratingObject.rating,
					dateAdded = GetUTCDateTime(ratingObject.date_added)
				};
			}
			return array;
		}

		public static ModDependencies[] ConvertModDependenciesObjectToModDependencies(ModDependenciesObject[] modDependenciesObjects)
		{
			ModDependencies[] array = new ModDependencies[modDependenciesObjects.Length];
			int num = 0;
			for (int i = 0; i < modDependenciesObjects.Length; i++)
			{
				ModDependenciesObject modDependenciesObject = modDependenciesObjects[i];
				array[num] = new ModDependencies
				{
					modId = new ModId(modDependenciesObject.mod_id),
					modName = modDependenciesObject.mod_name,
					dateAdded = GetUTCDateTime(modDependenciesObject.date_added)
				};
				num++;
			}
			return array;
		}

		public static CommentPage ConvertModCommentObjectsToCommentPage(PaginatedResponse<ModCommentObject> commentObjects)
		{
			ModComment[] array = new ModComment[commentObjects.data.Length];
			for (int i = 0; i < commentObjects.data.Length; i++)
			{
				array[i] = ConvertModCommentObjectsToModComment(commentObjects.data[i]);
			}
			return new CommentPage
			{
				CommentObjects = array,
				totalSearchResultsFound = commentObjects.result_total
			};
		}

		public static ModComment ConvertModCommentObjectsToModComment(ModCommentObject modCommentObjects)
		{
			return new ModComment
			{
				dateAdded = modCommentObjects.date_added,
				id = modCommentObjects.id,
				karma = modCommentObjects.karma,
				modId = (ModId)modCommentObjects.mod_id,
				resourceId = modCommentObjects.resource_id,
				submittedBy = modCommentObjects.submitted_by,
				threadPosition = modCommentObjects.thread_position,
				commentDetails = new CommentDetails(modCommentObjects.reply_id, modCommentObjects.content),
				userProfile = ConvertUserObjectToUserProfile(modCommentObjects.user)
			};
		}

		public static ModProfile[] ConvertModObjectsToModProfile(ModObject[] modObjects)
		{
			ModProfile[] array = new ModProfile[modObjects.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ConvertModObjectToModProfile(modObjects[i]);
			}
			return array;
		}

		public static ModProfile ConvertModObjectToModProfile(ModObject modObject)
		{
			if (modObject.id == 0L)
			{
				Logger.Log(LogLevel.Error, "The method ConvertModObjectToModProfile(ModObject) was given an invalid ModObject. This is an internal error and should not happen.");
				return default(ModProfile);
			}
			ModProfile result = new ModProfile
			{
				id = new ModId(modObject.id),
				name = (modObject.name ?? ""),
				summary = (modObject.summary ?? ""),
				homePageUrl = modObject.homepage_url,
				profilePageUrl = modObject.profile_url,
				status = (ModStatus)modObject.status,
				visible = (modObject.visible == 1),
				contentWarnings = (ContentWarnings)modObject.maturity_option,
				description = (modObject.description_plaintext ?? ""),
				creator = ConvertUserObjectToUserProfile(modObject.submitted_by),
				metadata = modObject.metadata_blob,
				archiveFileSize = ((modObject.modfile.id == 0L) ? (-1) : modObject.modfile.filesize),
				latestChangelog = modObject.modfile.changelog,
				latestVersion = modObject.modfile.version,
				latestDateFileAdded = GetUTCDateTime(modObject.modfile.date_added),
				dateLive = GetUTCDateTime(modObject.date_live),
				dateAdded = GetUTCDateTime(modObject.date_added),
				dateUpdated = GetUTCDateTime(modObject.date_updated)
			};
			List<string> list = new List<string>();
			if (modObject.tags != null)
			{
				ModTagObject[] tags = modObject.tags;
				for (int i = 0; i < tags.Length; i++)
				{
					ModTagObject modTagObject = tags[i];
					list.Add(modTagObject.name);
				}
			}
			result.tags = list.ToArray();
			if (modObject.metadata_kvp != null)
			{
				result.metadataKeyValuePairs = new KeyValuePair<string, string>[modObject.metadata_kvp.Length];
				for (int j = 0; j < modObject.metadata_kvp.Length; j++)
				{
					result.metadataKeyValuePairs[j] = new KeyValuePair<string, string>(modObject.metadata_kvp[j].metakey, modObject.metadata_kvp[j].metavalue);
				}
			}
			if (modObject.media.images != null)
			{
				result.galleryImages_320x180 = new DownloadReference[modObject.media.images.Length];
				result.galleryImages_640x360 = new DownloadReference[modObject.media.images.Length];
				result.galleryImages_Original = new DownloadReference[modObject.media.images.Length];
				for (int k = 0; k < modObject.media.images.Length; k++)
				{
					result.galleryImages_320x180[k] = CreateDownloadReference(modObject.media.images[k].filename, modObject.media.images[k].thumb_320x180, result.id);
					result.galleryImages_640x360[k] = CreateDownloadReference(modObject.media.images[k].filename, modObject.media.images[k].thumb_320x180.Replace("320x180", "640x360"), result.id);
					result.galleryImages_Original[k] = CreateDownloadReference(modObject.media.images[k].filename, modObject.media.images[k].original, result.id);
				}
			}
			result.logoImage_320x180 = CreateDownloadReference(modObject.logo.filename, modObject.logo.thumb_320x180, result.id);
			result.logoImage_640x360 = CreateDownloadReference(modObject.logo.filename, modObject.logo.thumb_640x360, result.id);
			result.logoImage_1280x720 = CreateDownloadReference(modObject.logo.filename, modObject.logo.thumb_1280x720, result.id);
			result.logoImage_Original = CreateDownloadReference(modObject.logo.filename, modObject.logo.original, result.id);
			result.creatorAvatar_100x100 = CreateDownloadReference(modObject.submitted_by.avatar.filename, modObject.submitted_by.avatar.thumb_100x100, result.id);
			result.creatorAvatar_50x50 = CreateDownloadReference(modObject.submitted_by.avatar.filename, modObject.submitted_by.avatar.thumb_50x50, result.id);
			result.creatorAvatar_Original = CreateDownloadReference(modObject.submitted_by.avatar.filename, modObject.submitted_by.avatar.original, result.id);
			result.stats = new ModStats
			{
				modId = new ModId(modObject.stats.mod_id),
				downloadsToday = modObject.stats.downloads_today,
				downloadsTotal = modObject.stats.downloads_total,
				ratingsTotal = modObject.stats.ratings_total,
				ratingsNegative = modObject.stats.ratings_negative,
				ratingsPositive = modObject.stats.ratings_positive,
				ratingsDisplayText = modObject.stats.ratings_display_text,
				ratingsPercentagePositive = modObject.stats.ratings_percentage_positive,
				ratingsWeightedAggregate = modObject.stats.ratings_weighted_aggregate,
				popularityRankPosition = modObject.stats.popularity_rank_position,
				popularityRankTotalMods = modObject.stats.popularity_rank_total_mods,
				subscriberTotal = modObject.stats.subscribers_total
			};
			return result;
		}

		private static DownloadReference CreateDownloadReference(string filename, string url, ModId modId)
		{
			return new DownloadReference
			{
				filename = filename,
				url = url,
				modId = modId
			};
		}

		public static UserProfile ConvertUserObjectToUserProfile(UserObject userObject)
		{
			return new UserProfile
			{
				avatar_original = CreateDownloadReference(userObject.avatar.filename, userObject.avatar.original, (ModId)0L),
				avatar_50x50 = CreateDownloadReference(userObject.avatar.filename, userObject.avatar.thumb_50x50, (ModId)0L),
				avatar_100x100 = CreateDownloadReference(userObject.avatar.filename, userObject.avatar.thumb_100x100, (ModId)0L),
				username = userObject.username,
				userId = userObject.id,
				portal_username = userObject.display_name_portal,
				language = userObject.language,
				timezone = userObject.timezone
			};
		}

		public static DateTime GetUTCDateTime(long serverTimeStamp)
		{
			return UnixEpoch.AddSeconds(serverTimeStamp);
		}
	}
}
