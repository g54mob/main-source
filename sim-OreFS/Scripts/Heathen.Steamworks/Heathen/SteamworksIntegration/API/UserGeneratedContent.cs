using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.API
{
	public static class UserGeneratedContent
	{
		public static class Client
		{
			private static WorkshopDownloadedItemResultEvent evtItemDownloaded = new WorkshopDownloadedItemResultEvent();

			private static WorkshopItemInstalledEvent evtItemInstalled = new WorkshopItemInstalledEvent();

			private static CallResult<AddAppDependencyResult_t> m_AddAppDependencyResults;

			private static CallResult<AddUGCDependencyResult_t> m_AddUGCDependencyResults;

			private static CallResult<UserFavoriteItemsListChanged_t> m_UserFavoriteItemsListChanged;

			private static CallResult<CreateItemResult_t> m_CreatedItem;

			private static CallResult<DeleteItemResult_t> m_DeleteItem;

			private static CallResult<GetAppDependenciesResult_t> m_AppDependenciesResult;

			private static CallResult<GetUserItemVoteResult_t> m_GetUserItemVoteResult;

			private static CallResult<RemoveAppDependencyResult_t> m_RemoveAppDependencyResult;

			private static CallResult<RemoveUGCDependencyResult_t> m_RemoveDependencyResult;

			private static CallResult<SteamUGCRequestUGCDetailsResult_t> m_SteamUGCRequestUGCDetailsResult;

			private static CallResult<SteamUGCQueryCompleted_t> m_SteamUGCQueryCompleted;

			private static CallResult<SetUserItemVoteResult_t> m_SetUserItemVoteResult;

			private static CallResult<StartPlaytimeTrackingResult_t> m_StartPlaytimeTrackingResult;

			private static CallResult<StopPlaytimeTrackingResult_t> m_StopPlaytimeTrackingResult;

			private static CallResult<SubmitItemUpdateResult_t> m_SubmitItemUpdateResult;

			private static CallResult<RemoteStorageSubscribePublishedFileResult_t> m_RemoteStorageSubscribePublishedFileResult;

			private static CallResult<RemoteStorageUnsubscribePublishedFileResult_t> m_RemoteStorageUnsubscribePublishedFileResult;

			private static CallResult<WorkshopEULAStatus_t> m_WorkshopEULAStatus;

			private static Callback<DownloadItemResult_t> m_DownloadItem;

			private static Callback<ItemInstalled_t> m_ItemInstalled;

			public static WorkshopDownloadedItemResultEvent EventItemDownloaded
			{
				get
				{
					if (m_DownloadItem == null)
					{
						m_DownloadItem = Callback<DownloadItemResult_t>.Create(evtItemDownloaded.Invoke);
					}
					return evtItemDownloaded;
				}
			}

			public static WorkshopItemInstalledEvent EventWorkshopItemInstalled
			{
				get
				{
					if (m_ItemInstalled == null)
					{
						m_ItemInstalled = Callback<ItemInstalled_t>.Create(evtItemInstalled.Invoke);
					}
					return evtItemInstalled;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				evtItemDownloaded = new WorkshopDownloadedItemResultEvent();
				evtItemInstalled = new WorkshopItemInstalledEvent();
				m_AddAppDependencyResults = null;
				m_AddUGCDependencyResults = null;
				m_UserFavoriteItemsListChanged = null;
				m_CreatedItem = null;
				m_DeleteItem = null;
				m_AppDependenciesResult = null;
				m_GetUserItemVoteResult = null;
				m_RemoveAppDependencyResult = null;
				m_RemoveDependencyResult = null;
				m_SteamUGCRequestUGCDetailsResult = null;
				m_SteamUGCQueryCompleted = null;
				m_SetUserItemVoteResult = null;
				m_StartPlaytimeTrackingResult = null;
				m_StopPlaytimeTrackingResult = null;
				m_SubmitItemUpdateResult = null;
				m_RemoteStorageSubscribePublishedFileResult = null;
				m_RemoteStorageUnsubscribePublishedFileResult = null;
				m_WorkshopEULAStatus = null;
				m_DownloadItem = null;
				m_ItemInstalled = null;
			}

			public static bool CreateItem(WorkshopItemData item, WorkshopItemPreviewFile[] additionalPreviews, string[] additionalYouTubeIds, WorkshopItemKeyValueTag[] additionalKeyValueTags, Action<WorkshopItemDataCreateStatus> completedCallback = null, Action<UGCUpdateHandle_t> uploadStartedCallback = null, Action<CreateItemResult_t> fileCreatedCallback = null)
			{
				if (m_CreatedItem == null)
				{
					m_CreatedItem = CallResult<CreateItemResult_t>.Create();
				}
				if (m_SubmitItemUpdateResult == null)
				{
					m_SubmitItemUpdateResult = CallResult<SubmitItemUpdateResult_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamUGC.CreateItem(item.appId, EWorkshopFileType.k_EWorkshopFileTypeFirst);
				m_CreatedItem.Set(hAPICall, delegate(CreateItemResult_t createResult, bool createIOError)
				{
					if (createIOError || createResult.m_eResult != EResult.k_EResultOK)
					{
						if (createIOError)
						{
							completedCallback?.Invoke(new WorkshopItemDataCreateStatus
							{
								hasError = true,
								errorMessage = "Steamworks Client failed to create UGC item.",
								createItemResult = createResult
							});
						}
						else
						{
							switch (createResult.m_eResult)
							{
							case EResult.k_EResultInsufficientPrivilege:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The user is currently restricted from uploading content due to a hub ban, account lock, or community ban. They would need to contact Steam Support.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultBanned:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The user doesn't have permission to upload content to this hub because they have an active VAC or Game ban.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultTimeout:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The operation took longer than expected. Have the user retry the creation process.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultNotLoggedOn:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The user is not currently logged into Steam.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultServiceUnavailable:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The workshop server hosting the content is having issues - have the user retry.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultInvalidParam:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "One of the submission fields contains something not being accepted by that field.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultAccessDenied:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "There was a problem trying to save the title and description. Access was denied.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultLimitExceeded:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The user has exceeded their Steam Cloud quota. Have them remove some items and try again.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultFileNotFound:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The uploaded file could not be found.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultDuplicateRequest:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The file was already successfully uploaded. The user just needs to refresh.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultDuplicateName:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "The user already has a Steam Workshop item with that name.",
									createItemResult = createResult
								});
								break;
							case EResult.k_EResultServiceReadOnly:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "Due to a recent password or email change, the user is not allowed to upload new content. Usually this restriction will expire in 5 days, but can last up to 30 days if the account has been inactive recently.",
									createItemResult = createResult
								});
								break;
							default:
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = true,
									errorMessage = "Unexpected result please see the createItemResult.m_eResult status for more information.",
									createItemResult = createResult
								});
								break;
							}
						}
					}
					else
					{
						fileCreatedCallback?.Invoke(createResult);
						UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate(item.appId, createResult.m_nPublishedFileId);
						bool hasError = false;
						StringBuilder sb = new StringBuilder();
						if (!string.IsNullOrEmpty(item.title))
						{
							if (!SteamUGC.SetItemTitle(uGCUpdateHandle_t, item.title))
							{
								hasError = true;
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Failed to update item title.");
							}
						}
						else
						{
							Debug.LogWarning("The title was not provided and is required; the update might be rejected by Valve");
						}
						if (!string.IsNullOrEmpty(item.description))
						{
							if (!SteamUGC.SetItemDescription(uGCUpdateHandle_t, item.description))
							{
								hasError = true;
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Failed to update item description.");
							}
						}
						else
						{
							Debug.LogWarning("The description was not provided and is required; the update might be rejected by Valve");
						}
						if (!SteamUGC.SetItemVisibility(uGCUpdateHandle_t, item.visibility))
						{
							hasError = true;
							if (sb.Length > 0)
							{
								sb.Append("\n");
							}
							sb.Append("Failed to update item visibility.");
						}
						if (item.tags != null && item.tags.Count() > 0 && !SteamUGC.SetItemTags(uGCUpdateHandle_t, item.tags.ToList()))
						{
							hasError = true;
							if (sb.Length > 0)
							{
								sb.Append("\n");
							}
							sb.Append("Failed to update item tags.");
						}
						if (item.content != null && item.content.Exists)
						{
							if (!SteamUGC.SetItemContent(uGCUpdateHandle_t, item.content.FullName))
							{
								hasError = true;
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Failed to update item content location.");
							}
						}
						else
						{
							Debug.LogWarning("The content folder does not exist and is required; the update might be rejected by Valve");
						}
						if (item.preview != null && item.preview.Exists)
						{
							if (!SteamUGC.SetItemPreview(uGCUpdateHandle_t, item.preview.FullName))
							{
								hasError = true;
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Failed to update item preview.");
							}
						}
						else
						{
							Debug.LogWarning("The preview image does not exist and is required; the update might be rejected by Valve");
						}
						if (additionalPreviews != null && additionalPreviews.Length != 0)
						{
							WorkshopItemPreviewFile[] array = additionalPreviews;
							for (int i = 0; i < array.Length; i++)
							{
								WorkshopItemPreviewFile workshopItemPreviewFile = array[i];
								if (!SteamUGC.AddItemPreviewFile(uGCUpdateHandle_t, workshopItemPreviewFile.source, workshopItemPreviewFile.type))
								{
									hasError = true;
									if (sb.Length > 0)
									{
										sb.Append("\n");
									}
									sb.Append("Failed to add item preview: " + workshopItemPreviewFile.source + ".");
								}
							}
						}
						if (additionalYouTubeIds != null && additionalYouTubeIds.Length != 0)
						{
							string[] array2 = additionalYouTubeIds;
							foreach (string text in array2)
							{
								if (!SteamUGC.AddItemPreviewVideo(uGCUpdateHandle_t, text))
								{
									hasError = true;
									if (sb.Length > 0)
									{
										sb.Append("\n");
									}
									sb.Append("Failed to add item video: " + text + ".");
								}
							}
						}
						if (additionalKeyValueTags != null && additionalKeyValueTags.Length != 0)
						{
							WorkshopItemKeyValueTag[] array3 = additionalKeyValueTags;
							for (int i = 0; i < array3.Length; i++)
							{
								WorkshopItemKeyValueTag workshopItemKeyValueTag = array3[i];
								if (!SteamUGC.AddItemKeyValueTag(uGCUpdateHandle_t, workshopItemKeyValueTag.key, workshopItemKeyValueTag.value))
								{
									hasError = true;
									if (sb.Length > 0)
									{
										sb.Append("\n");
									}
									sb.Append("Failed to add item key value tag: " + workshopItemKeyValueTag.key + ":" + workshopItemKeyValueTag.value);
								}
							}
						}
						if (!string.IsNullOrEmpty(item.metadata) && !SteamUGC.SetItemMetadata(uGCUpdateHandle_t, item.metadata))
						{
							hasError = true;
							if (sb.Length > 0)
							{
								sb.Append("\n");
							}
							sb.Append("Failed to update item metadata.");
						}
						SteamAPICall_t hAPICall2 = SteamUGC.SubmitItemUpdate(uGCUpdateHandle_t, "Initial Creation");
						m_SubmitItemUpdateResult.Set(hAPICall2, delegate(SubmitItemUpdateResult_t updateResult, bool updateIOError)
						{
							if (updateIOError || updateResult.m_eResult != EResult.k_EResultOK)
							{
								hasError = true;
								if (updateIOError)
								{
									if (sb.Length > 0)
									{
										sb.Append("\n");
									}
									sb.Append("Steamworks Client failed to submit item updates.");
									item.publishedFileId = createResult.m_nPublishedFileId;
									completedCallback?.Invoke(new WorkshopItemDataCreateStatus
									{
										hasError = true,
										errorMessage = sb.ToString(),
										data = item,
										createItemResult = createResult,
										submitItemUpdateResult = updateResult
									});
								}
								else
								{
									switch (updateResult.m_eResult)
									{
									case EResult.k_EResultFail:
										if (sb.Length > 0)
										{
											sb.Append("\n");
										}
										sb.Append("Generic failure.");
										item.publishedFileId = createResult.m_nPublishedFileId;
										completedCallback?.Invoke(new WorkshopItemDataCreateStatus
										{
											hasError = true,
											errorMessage = sb.ToString(),
											data = item,
											createItemResult = createResult,
											submitItemUpdateResult = updateResult
										});
										break;
									case EResult.k_EResultInvalidParam:
										if (sb.Length > 0)
										{
											sb.Append("\n");
										}
										sb.Append("Either the provided app ID is invalid or doesn't match the consumer app ID of the item or, you have not enabled ISteamUGC for the provided app ID on the Steam Workshop Configuration App Admin page.\nThe preview file is smaller than 16 bytes.");
										item.publishedFileId = createResult.m_nPublishedFileId;
										completedCallback?.Invoke(new WorkshopItemDataCreateStatus
										{
											hasError = true,
											errorMessage = sb.ToString(),
											data = item,
											createItemResult = createResult,
											submitItemUpdateResult = updateResult
										});
										break;
									case EResult.k_EResultAccessDenied:
										if (sb.Length > 0)
										{
											sb.Append("\n");
										}
										sb.Append("The user doesn't own a license for the provided app ID.");
										item.publishedFileId = createResult.m_nPublishedFileId;
										completedCallback?.Invoke(new WorkshopItemDataCreateStatus
										{
											hasError = true,
											errorMessage = sb.ToString(),
											data = item,
											createItemResult = createResult,
											submitItemUpdateResult = updateResult
										});
										break;
									case EResult.k_EResultFileNotFound:
										if (sb.Length > 0)
										{
											sb.Append("\n");
										}
										sb.Append("Failed to get the workshop info for the item or failed to read the preview file or the content folder is not valid.");
										item.publishedFileId = createResult.m_nPublishedFileId;
										completedCallback?.Invoke(new WorkshopItemDataCreateStatus
										{
											hasError = true,
											errorMessage = sb.ToString(),
											data = item,
											createItemResult = createResult,
											submitItemUpdateResult = updateResult
										});
										break;
									case EResult.k_EResultLockingFailed:
										if (sb.Length > 0)
										{
											sb.Append("\n");
										}
										sb.Append("Failed to acquire UGC Lock.");
										item.publishedFileId = createResult.m_nPublishedFileId;
										completedCallback?.Invoke(new WorkshopItemDataCreateStatus
										{
											hasError = true,
											errorMessage = sb.ToString(),
											data = item,
											createItemResult = createResult,
											submitItemUpdateResult = updateResult
										});
										break;
									case EResult.k_EResultLimitExceeded:
										if (sb.Length > 0)
										{
											sb.Append("\n");
										}
										sb.Append("The preview image is too large, it must be less than 1 Megabyte; or there is not enough space available on the users Steam Cloud.");
										item.publishedFileId = createResult.m_nPublishedFileId;
										completedCallback?.Invoke(new WorkshopItemDataCreateStatus
										{
											hasError = true,
											errorMessage = sb.ToString(),
											data = item,
											createItemResult = createResult,
											submitItemUpdateResult = updateResult
										});
										break;
									default:
										if (sb.Length > 0)
										{
											sb.Append("\n");
										}
										sb.Append("Unexpected status message from Steam client, please see the submitItemUpdateResult.m_eResult status for more information.");
										item.publishedFileId = createResult.m_nPublishedFileId;
										completedCallback?.Invoke(new WorkshopItemDataCreateStatus
										{
											hasError = true,
											errorMessage = sb.ToString(),
											data = item,
											createItemResult = createResult,
											submitItemUpdateResult = updateResult
										});
										break;
									}
								}
							}
							else
							{
								item.publishedFileId = createResult.m_nPublishedFileId;
								completedCallback?.Invoke(new WorkshopItemDataCreateStatus
								{
									hasError = hasError,
									errorMessage = (hasError ? sb.ToString() : string.Empty),
									data = item,
									createItemResult = createResult,
									submitItemUpdateResult = updateResult
								});
							}
						});
						uploadStartedCallback?.Invoke(uGCUpdateHandle_t);
					}
				});
				return true;
			}

			public static bool UpdateItem(WorkshopItemData item, WorkshopItemPreviewFile[] additionalPreviews, string[] additionalYouTubeIds, WorkshopItemKeyValueTag[] additionalKeyValueTags, Action<WorkshopItemDataUpdateStatus> callback = null, Action<UGCUpdateHandle_t> uploadStartedCallback = null)
			{
				if (m_CreatedItem == null)
				{
					m_CreatedItem = CallResult<CreateItemResult_t>.Create();
				}
				if (m_SubmitItemUpdateResult == null)
				{
					m_SubmitItemUpdateResult = CallResult<SubmitItemUpdateResult_t>.Create();
				}
				if (!item.publishedFileId.HasValue)
				{
					return false;
				}
				UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate(item.appId, item.publishedFileId.Value);
				bool hasError = false;
				StringBuilder sb = new StringBuilder();
				if (!SteamUGC.SetItemTitle(uGCUpdateHandle_t, item.title))
				{
					hasError = true;
					if (sb.Length > 0)
					{
						sb.Append("\n");
					}
					sb.Append("Failed to update item title.");
				}
				if (!string.IsNullOrEmpty(item.description) && !SteamUGC.SetItemDescription(uGCUpdateHandle_t, item.description))
				{
					hasError = true;
					if (sb.Length > 0)
					{
						sb.Append("\n");
					}
					sb.Append("Failed to update item description.");
				}
				if (!SteamUGC.SetItemVisibility(uGCUpdateHandle_t, item.visibility))
				{
					hasError = true;
					if (sb.Length > 0)
					{
						sb.Append("\n");
					}
					sb.Append("Failed to update item visibility.");
				}
				if (item.tags != null && item.tags.Count() > 0 && !SteamUGC.SetItemTags(uGCUpdateHandle_t, item.tags.ToList()))
				{
					hasError = true;
					if (sb.Length > 0)
					{
						sb.Append("\n");
					}
					sb.Append("Failed to update item tags.");
				}
				if (!SteamUGC.SetItemContent(uGCUpdateHandle_t, item.content.FullName))
				{
					hasError = true;
					if (sb.Length > 0)
					{
						sb.Append("\n");
					}
					sb.Append("Failed to update item content location.");
				}
				if (!SteamUGC.SetItemPreview(uGCUpdateHandle_t, item.preview.FullName))
				{
					hasError = true;
					if (sb.Length > 0)
					{
						sb.Append("\n");
					}
					sb.Append("Failed to update item preview.");
				}
				if (additionalPreviews != null && additionalPreviews.Length != 0)
				{
					for (int i = 0; i < additionalPreviews.Length; i++)
					{
						WorkshopItemPreviewFile workshopItemPreviewFile = additionalPreviews[i];
						if (!SteamUGC.AddItemPreviewFile(uGCUpdateHandle_t, workshopItemPreviewFile.source, workshopItemPreviewFile.type))
						{
							hasError = true;
							if (sb.Length > 0)
							{
								sb.Append("\n");
							}
							sb.Append("Failed to add item preview: " + workshopItemPreviewFile.source + ".");
						}
					}
				}
				if (additionalYouTubeIds != null && additionalYouTubeIds.Length != 0)
				{
					foreach (string text in additionalYouTubeIds)
					{
						if (!SteamUGC.AddItemPreviewVideo(uGCUpdateHandle_t, text))
						{
							hasError = true;
							if (sb.Length > 0)
							{
								sb.Append("\n");
							}
							sb.Append("Failed to add item video: " + text + ".");
						}
					}
				}
				if (additionalKeyValueTags != null && additionalKeyValueTags.Length != 0)
				{
					for (int i = 0; i < additionalKeyValueTags.Length; i++)
					{
						WorkshopItemKeyValueTag workshopItemKeyValueTag = additionalKeyValueTags[i];
						if (!SteamUGC.AddItemKeyValueTag(uGCUpdateHandle_t, workshopItemKeyValueTag.key, workshopItemKeyValueTag.value))
						{
							hasError = true;
							if (sb.Length > 0)
							{
								sb.Append("\n");
							}
							sb.Append("Failed to add item key value tag: " + workshopItemKeyValueTag.key + ":" + workshopItemKeyValueTag.value);
						}
					}
				}
				if (!string.IsNullOrEmpty(item.metadata) && !SteamUGC.SetItemMetadata(uGCUpdateHandle_t, item.metadata))
				{
					hasError = true;
					if (sb.Length > 0)
					{
						sb.Append("\n");
					}
					sb.Append("Failed to update item metadata.");
				}
				SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(uGCUpdateHandle_t, "Initial Creation");
				m_SubmitItemUpdateResult.Set(hAPICall, delegate(SubmitItemUpdateResult_t updateResult, bool updateIOError)
				{
					if (updateIOError || updateResult.m_eResult != EResult.k_EResultOK)
					{
						hasError = true;
						if (updateIOError)
						{
							if (sb.Length > 0)
							{
								sb.Append("\n");
							}
							sb.Append("Steamworks Client failed to submit item updates.");
							callback?.Invoke(new WorkshopItemDataUpdateStatus
							{
								hasError = true,
								errorMessage = sb.ToString(),
								data = item,
								submitItemUpdateResult = updateResult
							});
						}
						else
						{
							switch (updateResult.m_eResult)
							{
							case EResult.k_EResultFail:
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Generic failure.");
								callback?.Invoke(new WorkshopItemDataUpdateStatus
								{
									hasError = true,
									errorMessage = sb.ToString(),
									data = item,
									submitItemUpdateResult = updateResult
								});
								break;
							case EResult.k_EResultInvalidParam:
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Either the provided app ID is invalid or doesn't match the consumer app ID of the item or, you have not enabled ISteamUGC for the provided app ID on the Steam Workshop Configuration App Admin page.\nThe preview file is smaller than 16 bytes.");
								callback?.Invoke(new WorkshopItemDataUpdateStatus
								{
									hasError = true,
									errorMessage = sb.ToString(),
									data = item,
									submitItemUpdateResult = updateResult
								});
								break;
							case EResult.k_EResultAccessDenied:
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("The user doesn't own a license for the provided app ID.");
								callback?.Invoke(new WorkshopItemDataUpdateStatus
								{
									hasError = true,
									errorMessage = sb.ToString(),
									data = item,
									submitItemUpdateResult = updateResult
								});
								break;
							case EResult.k_EResultFileNotFound:
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Failed to get the workshop info for the item or failed to read the preview file or the content folder is not valid.");
								callback?.Invoke(new WorkshopItemDataUpdateStatus
								{
									hasError = true,
									errorMessage = sb.ToString(),
									data = item,
									submitItemUpdateResult = updateResult
								});
								break;
							case EResult.k_EResultLockingFailed:
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Failed to acquire UGC Lock.");
								callback?.Invoke(new WorkshopItemDataUpdateStatus
								{
									hasError = true,
									errorMessage = sb.ToString(),
									data = item,
									submitItemUpdateResult = updateResult
								});
								break;
							case EResult.k_EResultLimitExceeded:
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("The preview image is too large, it must be less than 1 Megabyte; or there is not enough space available on the users Steam Cloud.");
								callback?.Invoke(new WorkshopItemDataUpdateStatus
								{
									hasError = true,
									errorMessage = sb.ToString(),
									data = item,
									submitItemUpdateResult = updateResult
								});
								break;
							default:
								if (sb.Length > 0)
								{
									sb.Append("\n");
								}
								sb.Append("Unexpected status message from Steam client, please see the submitItemUpdateResult.m_eResult status for more information.");
								callback?.Invoke(new WorkshopItemDataUpdateStatus
								{
									hasError = true,
									errorMessage = sb.ToString(),
									data = item,
									submitItemUpdateResult = updateResult
								});
								break;
							}
						}
					}
					else
					{
						callback?.Invoke(new WorkshopItemDataUpdateStatus
						{
							hasError = hasError,
							errorMessage = (hasError ? sb.ToString() : string.Empty),
							data = item,
							submitItemUpdateResult = updateResult
						});
					}
				});
				uploadStartedCallback?.Invoke(uGCUpdateHandle_t);
				return true;
			}

			public static void AddAppDependency(PublishedFileId_t fileId, AppId_t appId, Action<AddAppDependencyResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_AddAppDependencyResults == null)
					{
						m_AddAppDependencyResults = CallResult<AddAppDependencyResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.AddAppDependency(fileId, appId);
					m_AddAppDependencyResults.Set(hAPICall, callback.Invoke);
				}
			}

			public static void AddDependency(PublishedFileId_t parentFileId, PublishedFileId_t childFileId, Action<AddUGCDependencyResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_AddUGCDependencyResults == null)
					{
						m_AddUGCDependencyResults = CallResult<AddUGCDependencyResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.AddDependency(parentFileId, childFileId);
					m_AddUGCDependencyResults.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool AddExcludedTag(UGCQueryHandle_t handle, string tagName)
			{
				return SteamUGC.AddExcludedTag(handle, tagName);
			}

			public static bool AddItemKeyValueTag(UGCUpdateHandle_t handle, string key, string value)
			{
				return SteamUGC.AddItemKeyValueTag(handle, key, value);
			}

			public static bool AddItemPreviewFile(UGCUpdateHandle_t handle, string previewFile, EItemPreviewType type)
			{
				return SteamUGC.AddItemPreviewFile(handle, previewFile, type);
			}

			public static bool AddItemPreviewVideo(UGCUpdateHandle_t handle, string videoId)
			{
				return SteamUGC.AddItemPreviewVideo(handle, videoId);
			}

			public static void AddItemToFavorites(AppId_t appId, PublishedFileId_t fileId, Action<UserFavoriteItemsListChanged_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_UserFavoriteItemsListChanged == null)
					{
						m_UserFavoriteItemsListChanged = CallResult<UserFavoriteItemsListChanged_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.AddItemToFavorites(appId, fileId);
					m_UserFavoriteItemsListChanged.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool AddRequiredKeyValueTag(UGCQueryHandle_t handle, string key, string value)
			{
				return SteamUGC.AddRequiredKeyValueTag(handle, key, value);
			}

			public static bool AddRequiredTag(UGCQueryHandle_t handle, string tagName)
			{
				return SteamUGC.AddRequiredTag(handle, tagName);
			}

			public static void CreateItem(AppId_t appId, EWorkshopFileType type, Action<CreateItemResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_CreatedItem == null)
					{
						m_CreatedItem = CallResult<CreateItemResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.CreateItem(appId, type);
					m_CreatedItem.Set(hAPICall, callback.Invoke);
				}
			}

			public static UGCQueryHandle_t CreateQueryAllRequest(EUGCQuery queryType, EUGCMatchingUGCType matchingFileType, AppId_t creatorAppId, AppId_t consumerAppId, uint page)
			{
				return SteamUGC.CreateQueryAllUGCRequest(queryType, matchingFileType, creatorAppId, consumerAppId, page);
			}

			public static UGCQueryHandle_t CreateQueryDetailsRequest(PublishedFileId_t[] fileIds)
			{
				return SteamUGC.CreateQueryUGCDetailsRequest(fileIds, (uint)fileIds.GetLength(0));
			}

			public static UGCQueryHandle_t CreateQueryDetailsRequest(List<PublishedFileId_t> fileIds)
			{
				return SteamUGC.CreateQueryUGCDetailsRequest(fileIds.ToArray(), (uint)fileIds.Count);
			}

			public static UGCQueryHandle_t CreateQueryDetailsRequest(IEnumerable<PublishedFileId_t> fileIds)
			{
				return SteamUGC.CreateQueryUGCDetailsRequest(fileIds.ToArray(), (uint)fileIds.Count());
			}

			public static UGCQueryHandle_t CreateQueryUserRequest(AccountID_t accountId, EUserUGCList listType, EUGCMatchingUGCType matchingType, EUserUGCListSortOrder sortOrder, AppId_t creatorAppId, AppId_t consumerAppId, uint page)
			{
				return SteamUGC.CreateQueryUserUGCRequest(accountId, listType, matchingType, sortOrder, creatorAppId, consumerAppId, page);
			}

			public static bool ReleaseQueryRequest(UGCQueryHandle_t handle)
			{
				return SteamUGC.ReleaseQueryUGCRequest(handle);
			}

			public static void DeleteItem(PublishedFileId_t fileId, Action<DeleteItemResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_DeleteItem == null)
					{
						m_DeleteItem = CallResult<DeleteItemResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.DeleteItem(fileId);
					m_DeleteItem.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool DownloadItem(PublishedFileId_t fileId, bool setHighPriority)
			{
				return SteamUGC.DownloadItem(fileId, setHighPriority);
			}

			public static void GetAppDependencies(PublishedFileId_t fileId, Action<GetAppDependenciesResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_AppDependenciesResult == null)
					{
						m_AppDependenciesResult = CallResult<GetAppDependenciesResult_t>.Create();
					}
					SteamAPICall_t appDependencies = SteamUGC.GetAppDependencies(fileId);
					m_AppDependenciesResult.Set(appDependencies, callback.Invoke);
				}
			}

			public static bool GetItemDownloadInfo(PublishedFileId_t fileId, out float completion)
			{
				ulong punBytesDownloaded;
				ulong punBytesTotal;
				bool itemDownloadInfo = SteamUGC.GetItemDownloadInfo(fileId, out punBytesDownloaded, out punBytesTotal);
				if (itemDownloadInfo)
				{
					completion = ((punBytesTotal != 0) ? Convert.ToSingle(Convert.ToDouble(punBytesDownloaded) / Convert.ToDouble(punBytesTotal)) : 0f);
					return itemDownloadInfo;
				}
				completion = 0f;
				return itemDownloadInfo;
			}

			public static bool GetItemInstallInfo(PublishedFileId_t fileId, out ulong sizeOnDisk, out string folderPath, out DateTime timeStamp)
			{
				uint punTimeStamp;
				bool itemInstallInfo = SteamUGC.GetItemInstallInfo(fileId, out sizeOnDisk, out folderPath, 1024u, out punTimeStamp);
				timeStamp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				timeStamp = timeStamp.AddSeconds(punTimeStamp);
				return itemInstallInfo;
			}

			public static bool GetItemInstallInfo(PublishedFileId_t fileId, out ulong sizeOnDisk, out string folderPath, uint folderSize, out DateTime timeStamp)
			{
				uint punTimeStamp;
				bool itemInstallInfo = SteamUGC.GetItemInstallInfo(fileId, out sizeOnDisk, out folderPath, folderSize, out punTimeStamp);
				timeStamp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				timeStamp = timeStamp.AddSeconds(punTimeStamp);
				return itemInstallInfo;
			}

			public static EItemState GetItemState(PublishedFileId_t fileId)
			{
				return (EItemState)SteamUGC.GetItemState(fileId);
			}

			public static bool ItemStateHasFlag(EItemState value, EItemState checkflag)
			{
				return (value & checkflag) == checkflag;
			}

			public static bool ItemStateHasAllFlags(EItemState value, params EItemState[] checkflags)
			{
				foreach (EItemState eItemState in checkflags)
				{
					if ((value & eItemState) != eItemState)
					{
						return false;
					}
				}
				return true;
			}

			public static EItemUpdateStatus GetItemUpdateProgress(UGCUpdateHandle_t handle, out float completion)
			{
				ulong punBytesProcessed;
				ulong punBytesTotal;
				EItemUpdateStatus itemUpdateProgress = SteamUGC.GetItemUpdateProgress(handle, out punBytesProcessed, out punBytesTotal);
				if (itemUpdateProgress != EItemUpdateStatus.k_EItemUpdateStatusInvalid)
				{
					completion = Convert.ToSingle((double)punBytesProcessed / (double)punBytesTotal);
					return itemUpdateProgress;
				}
				completion = 0f;
				return itemUpdateProgress;
			}

			public static uint GetNumSubscribedItems()
			{
				return SteamUGC.GetNumSubscribedItems();
			}

			public static bool GetQueryAdditionalPreview(UGCQueryHandle_t handle, uint index, uint previewIndex, out string urlOrVideoId, uint urlOrVideoSize, string fileName, uint fileNameSize, out EItemPreviewType type)
			{
				return SteamUGC.GetQueryUGCAdditionalPreview(handle, index, previewIndex, out urlOrVideoId, urlOrVideoSize, out fileName, fileNameSize, out type);
			}

			public static bool GetQueryChildren(UGCQueryHandle_t handle, uint index, PublishedFileId_t[] fileIds, uint maxEntries)
			{
				return SteamUGC.GetQueryUGCChildren(handle, index, fileIds, maxEntries);
			}

			public static bool GetQueryKeyValueTag(UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, out string key, string value)
			{
				bool queryUGCKeyValueTag = SteamUGC.GetQueryUGCKeyValueTag(handle, index, keyValueTagIndex, out key, 2048u, out value, 2048u);
				key = key.Trim();
				value = value.Trim();
				return queryUGCKeyValueTag;
			}

			public static bool GetQueryKeyValueTag(UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, out string key, uint keySize, out string value, uint valueSize)
			{
				return SteamUGC.GetQueryUGCKeyValueTag(handle, index, keyValueTagIndex, out key, keySize, out value, valueSize);
			}

			public static bool GetQueryMetadata(UGCQueryHandle_t handle, uint index, out string metadata, uint size)
			{
				return SteamUGC.GetQueryUGCMetadata(handle, index, out metadata, size);
			}

			public static uint GetQueryNumAdditionalPreviews(UGCQueryHandle_t handle, uint index)
			{
				return SteamUGC.GetQueryUGCNumAdditionalPreviews(handle, index);
			}

			public static uint GetQueryNumKeyValueTags(UGCQueryHandle_t handle, uint index)
			{
				return SteamUGC.GetQueryUGCNumKeyValueTags(handle, index);
			}

			public static bool GetQueryPreviewURL(UGCQueryHandle_t handle, uint index, out string URL, uint urlSize)
			{
				return SteamUGC.GetQueryUGCPreviewURL(handle, index, out URL, urlSize);
			}

			public static bool GetQueryResult(UGCQueryHandle_t handle, uint index, out SteamUGCDetails_t details)
			{
				return SteamUGC.GetQueryUGCResult(handle, index, out details);
			}

			public static bool GetQueryStatistic(UGCQueryHandle_t handle, uint index, EItemStatistic statType, out ulong statValue)
			{
				return SteamUGC.GetQueryUGCStatistic(handle, index, statType, out statValue);
			}

			public static uint GetSubscribedItems(PublishedFileId_t[] fileIDs, uint maxEntries)
			{
				return SteamUGC.GetSubscribedItems(fileIDs, maxEntries);
			}

			public static PublishedFileId_t[] GetSubscribedItems()
			{
				uint numSubscribedItems = GetNumSubscribedItems();
				if (numSubscribedItems != 0)
				{
					PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems];
					if (GetSubscribedItems(array, numSubscribedItems) != 0)
					{
						return array;
					}
					return new PublishedFileId_t[0];
				}
				return null;
			}

			public static void GetSubscribedItems(Action<List<WorkshopItem>> callback)
			{
				UgcQuery query = UgcQuery.GetSubscribed();
				query.Execute(delegate
				{
					callback?.Invoke(query.ResultsList);
					query.Dispose();
				});
			}

			public static void GetSubscribedItems(bool withLongDescription, bool withMetadata, bool withKeyValueTags, bool withAdditionalPreviews, uint withPlayTimeStatsInDays, Action<List<WorkshopItem>> callback)
			{
				UgcQuery query = UgcQuery.GetSubscribed(withLongDescription, withMetadata, withKeyValueTags, withAdditionalPreviews, withPlayTimeStatsInDays);
				query.Execute(delegate
				{
					callback?.Invoke(query.ResultsList);
					query.Dispose();
				});
			}

			public static void GetUserItemVote(PublishedFileId_t fileId, Action<GetUserItemVoteResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_GetUserItemVoteResult == null)
					{
						m_GetUserItemVoteResult = CallResult<GetUserItemVoteResult_t>.Create();
					}
					SteamAPICall_t userItemVote = SteamUGC.GetUserItemVote(fileId);
					m_GetUserItemVoteResult.Set(userItemVote, callback.Invoke);
				}
			}

			public static void GetWorkshopEULAStatus(Action<WorkshopEULAStatus_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_WorkshopEULAStatus == null)
					{
						m_WorkshopEULAStatus = CallResult<WorkshopEULAStatus_t>.Create();
					}
					SteamAPICall_t workshopEULAStatus = SteamUGC.GetWorkshopEULAStatus();
					m_WorkshopEULAStatus.Set(workshopEULAStatus, callback.Invoke);
				}
			}

			public static bool ShowWorkshopEULA()
			{
				return SteamUGC.ShowWorkshopEULA();
			}

			public static void RemoveAppDependency(PublishedFileId_t fileId, AppId_t appId, Action<RemoveAppDependencyResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_RemoveAppDependencyResult == null)
					{
						m_RemoveAppDependencyResult = CallResult<RemoveAppDependencyResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.RemoveAppDependency(fileId, appId);
					m_RemoveAppDependencyResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static void RemoveDependency(PublishedFileId_t parentFileId, PublishedFileId_t childFileId, Action<RemoveUGCDependencyResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_RemoveDependencyResult == null)
					{
						m_RemoveDependencyResult = CallResult<RemoveUGCDependencyResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.RemoveDependency(parentFileId, childFileId);
					m_RemoveDependencyResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static void RemoveItemFromFavorites(AppId_t appId, PublishedFileId_t fileId, Action<UserFavoriteItemsListChanged_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_UserFavoriteItemsListChanged == null)
					{
						m_UserFavoriteItemsListChanged = CallResult<UserFavoriteItemsListChanged_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.RemoveItemFromFavorites(appId, fileId);
					m_UserFavoriteItemsListChanged.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool RemoveItemKeyValueTags(UGCUpdateHandle_t handle, string key)
			{
				return SteamUGC.RemoveItemKeyValueTags(handle, key);
			}

			public static bool RemoveItemPreview(UGCUpdateHandle_t handle, uint index)
			{
				return SteamUGC.RemoveItemPreview(handle, index);
			}

			public static void RequestDetails(PublishedFileId_t fileId, uint maxAgeSeconds, Action<SteamUGCRequestUGCDetailsResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_SteamUGCRequestUGCDetailsResult == null)
					{
						m_SteamUGCRequestUGCDetailsResult = CallResult<SteamUGCRequestUGCDetailsResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.RequestUGCDetails(fileId, maxAgeSeconds);
					m_SteamUGCRequestUGCDetailsResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static void SendQueryUGCRequest(UGCQueryHandle_t handle, Action<SteamUGCQueryCompleted_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_SteamUGCQueryCompleted == null)
					{
						m_SteamUGCQueryCompleted = CallResult<SteamUGCQueryCompleted_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(handle);
					m_SteamUGCQueryCompleted.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool SetAllowCachedResponse(UGCQueryHandle_t handle, uint maxAgeSeconds)
			{
				return SteamUGC.SetAllowCachedResponse(handle, maxAgeSeconds);
			}

			public static bool SetCloudFileNameFilter(UGCQueryHandle_t handle, string fileName)
			{
				return SteamUGC.SetCloudFileNameFilter(handle, fileName);
			}

			public static bool SetItemContent(UGCUpdateHandle_t handle, string folder)
			{
				return SteamUGC.SetItemContent(handle, folder);
			}

			public static bool SetItemDescription(UGCUpdateHandle_t handle, string description)
			{
				return SteamUGC.SetItemDescription(handle, description);
			}

			public static bool SetItemMetadata(UGCUpdateHandle_t handle, string metadata)
			{
				return SteamUGC.SetItemMetadata(handle, metadata);
			}

			public static bool SetItemPreview(UGCUpdateHandle_t handle, string previewFile)
			{
				return SteamUGC.SetItemPreview(handle, previewFile);
			}

			public static bool SetItemTags(UGCUpdateHandle_t handle, List<string> tags)
			{
				return SteamUGC.SetItemTags(handle, tags);
			}

			public static bool SetItemTitle(UGCUpdateHandle_t handle, string title)
			{
				return SteamUGC.SetItemTitle(handle, title);
			}

			public static bool SetItemUpdateLanguage(UGCUpdateHandle_t handle, string language)
			{
				return SteamUGC.SetItemUpdateLanguage(handle, language);
			}

			public static bool SetItemVisibility(UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility visibility)
			{
				return SteamUGC.SetItemVisibility(handle, visibility);
			}

			public static bool SetLanguage(UGCQueryHandle_t handle, string language)
			{
				return SteamUGC.SetLanguage(handle, language);
			}

			public static bool SetMatchAnyTag(UGCQueryHandle_t handle, bool anyTag)
			{
				return SteamUGC.SetMatchAnyTag(handle, anyTag);
			}

			public static bool SetRankedByTrendDays(UGCQueryHandle_t handle, uint days)
			{
				return SteamUGC.SetRankedByTrendDays(handle, days);
			}

			public static bool SetReturnAdditionalPreviews(UGCQueryHandle_t handle, bool additionalPreviews)
			{
				return SteamUGC.SetReturnAdditionalPreviews(handle, additionalPreviews);
			}

			public static bool SetReturnChildren(UGCQueryHandle_t handle, bool returnChildren)
			{
				return SteamUGC.SetReturnChildren(handle, returnChildren);
			}

			public static bool SetReturnKeyValueTags(UGCQueryHandle_t handle, bool tags)
			{
				return SteamUGC.SetReturnKeyValueTags(handle, tags);
			}

			public static bool SetReturnLongDescription(UGCQueryHandle_t handle, bool longDescription)
			{
				return SteamUGC.SetReturnLongDescription(handle, longDescription);
			}

			public static bool SetReturnMetadata(UGCQueryHandle_t handle, bool metadata)
			{
				return SteamUGC.SetReturnMetadata(handle, metadata);
			}

			public static bool SetReturnOnlyIDs(UGCQueryHandle_t handle, bool onlyIds)
			{
				return SteamUGC.SetReturnOnlyIDs(handle, onlyIds);
			}

			public static bool SetReturnPlaytimeStats(UGCQueryHandle_t handle, uint days)
			{
				return SteamUGC.SetReturnPlaytimeStats(handle, days);
			}

			public static bool SetReturnTotalOnly(UGCQueryHandle_t handle, bool totalOnly)
			{
				return SteamUGC.SetReturnTotalOnly(handle, totalOnly);
			}

			public static bool SetSearchText(UGCQueryHandle_t handle, string text)
			{
				return SteamUGC.SetSearchText(handle, text);
			}

			public static void SetUserItemVote(PublishedFileId_t fileID, bool voteUp, Action<SetUserItemVoteResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_SetUserItemVoteResult == null)
					{
						m_SetUserItemVoteResult = CallResult<SetUserItemVoteResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.SetUserItemVote(fileID, voteUp);
					m_SetUserItemVoteResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static UGCUpdateHandle_t StartItemUpdate(AppId_t appId, PublishedFileId_t fileID)
			{
				return SteamUGC.StartItemUpdate(appId, fileID);
			}

			public static void StartPlaytimeTracking(PublishedFileId_t[] fileIds, Action<StartPlaytimeTrackingResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_StartPlaytimeTrackingResult == null)
					{
						m_StartPlaytimeTrackingResult = CallResult<StartPlaytimeTrackingResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.StartPlaytimeTracking(fileIds, (uint)fileIds.Length);
					m_StartPlaytimeTrackingResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static void StopPlaytimeTracking(PublishedFileId_t[] fileIds, Action<StopPlaytimeTrackingResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_StopPlaytimeTrackingResult == null)
					{
						m_StopPlaytimeTrackingResult = CallResult<StopPlaytimeTrackingResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.StopPlaytimeTracking(fileIds, (uint)fileIds.Length);
					m_StopPlaytimeTrackingResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static void StopPlaytimeTrackingForAllItems(Action<StopPlaytimeTrackingResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_StopPlaytimeTrackingResult == null)
					{
						m_StopPlaytimeTrackingResult = CallResult<StopPlaytimeTrackingResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.StopPlaytimeTrackingForAllItems();
					m_StopPlaytimeTrackingResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static void SubmitItemUpdate(UGCUpdateHandle_t handle, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_SubmitItemUpdateResult == null)
					{
						m_SubmitItemUpdateResult = CallResult<SubmitItemUpdateResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(handle, changeNote);
					m_SubmitItemUpdateResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static void SubscribeItem(PublishedFileId_t fileId, Action<RemoteStorageSubscribePublishedFileResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_RemoteStorageSubscribePublishedFileResult == null)
					{
						m_RemoteStorageSubscribePublishedFileResult = CallResult<RemoteStorageSubscribePublishedFileResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.SubscribeItem(fileId);
					m_RemoteStorageSubscribePublishedFileResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static void SuspendDownloads(bool suspend)
			{
				SteamUGC.SuspendDownloads(suspend);
			}

			public static void UnsubscribeItem(PublishedFileId_t fileId, Action<RemoteStorageUnsubscribePublishedFileResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_RemoteStorageUnsubscribePublishedFileResult == null)
					{
						m_RemoteStorageUnsubscribePublishedFileResult = CallResult<RemoteStorageUnsubscribePublishedFileResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamUGC.UnsubscribeItem(fileId);
					m_RemoteStorageUnsubscribePublishedFileResult.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool UpdateItemPreviewFile(UGCUpdateHandle_t handle, uint index, string file)
			{
				return SteamUGC.UpdateItemPreviewFile(handle, index, file);
			}

			public static bool UpdateItemPreviewVideo(UGCUpdateHandle_t handle, uint index, string videoId)
			{
				return SteamUGC.UpdateItemPreviewVideo(handle, index, videoId);
			}
		}

		public static bool ItemStateHasFlag(EItemState value, EItemState checkflag)
		{
			return (value & checkflag) == checkflag;
		}

		public static bool ItemStateHasAllFlags(EItemState value, params EItemState[] checkflags)
		{
			foreach (EItemState eItemState in checkflags)
			{
				if ((value & eItemState) != eItemState)
				{
					return false;
				}
			}
			return true;
		}
	}
}
