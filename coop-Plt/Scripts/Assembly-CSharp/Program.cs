using System;
using System.Linq;
using System.Text;
using System.Threading;
using Discord;

internal class Program
{
	private static void FetchAvatar(ImageManager imageManager, long userID)
	{
		imageManager.Fetch(ImageHandle.User(userID), delegate(Result result, ImageHandle handle)
		{
			if (result == Result.Ok)
			{
				byte[] data = imageManager.GetData(handle);
				Console.WriteLine("image updated {0} {1}", handle.Id, data.Length);
			}
			else
			{
				Console.WriteLine("image error {0}", handle.Id);
			}
		});
	}

	private static void UpdateActivity(global::Discord.Discord discord, Lobby lobby)
	{
		ActivityManager activityManager = discord.GetActivityManager();
		LobbyManager lobbyManager = discord.GetLobbyManager();
		Activity activity = new Activity
		{
			State = "olleh",
			Details = "foo details",
			Timestamps = 
			{
				Start = 5L,
				End = 6L
			},
			Assets = 
			{
				LargeImage = "foo largeImageKey",
				LargeText = "foo largeImageText",
				SmallImage = "foo smallImageKey",
				SmallText = "foo smallImageText"
			},
			Party = 
			{
				Id = lobby.Id.ToString(),
				Size = 
				{
					CurrentSize = lobbyManager.MemberCount(lobby.Id),
					MaxSize = (int)lobby.Capacity
				}
			},
			Secrets = 
			{
				Join = lobbyManager.GetLobbyActivitySecret(lobby.Id)
			},
			Instance = true
		};
		activityManager.UpdateActivity(activity, delegate(Result result)
		{
			Console.WriteLine("Update Activity {0}", result);
		});
	}

	private static void Main(string[] args)
	{
		string text = Environment.GetEnvironmentVariable("DISCORD_CLIENT_ID");
		if (text == null)
		{
			text = "418559331265675294";
		}
		global::Discord.Discord discord = new global::Discord.Discord(long.Parse(text), 0uL);
		discord.SetLogHook(LogLevel.Debug, delegate(LogLevel level, string message)
		{
			Console.WriteLine("Log[{0}] {1}", level, message);
		});
		ApplicationManager applicationManager = discord.GetApplicationManager();
		Console.WriteLine("Current Locale: {0}", applicationManager.GetCurrentLocale());
		Console.WriteLine("Current Branch: {0}", applicationManager.GetCurrentBranch());
		ActivityManager activityManager = discord.GetActivityManager();
		LobbyManager lobbyManager = discord.GetLobbyManager();
		activityManager.OnActivityJoin += delegate(string secret)
		{
			Console.WriteLine("OnJoin {0}", secret);
			lobbyManager.ConnectLobbyWithActivitySecret(secret, delegate(Result result, ref Lobby lobby)
			{
				Console.WriteLine("Connected to lobby: {0}", lobby.Id);
				lobbyManager.ConnectNetwork(lobby.Id);
				lobbyManager.OpenNetworkChannel(lobby.Id, 0, reliable: true);
				foreach (User memberUser in lobbyManager.GetMemberUsers(lobby.Id))
				{
					lobbyManager.SendNetworkMessage(lobby.Id, memberUser.Id, 0, Encoding.UTF8.GetBytes($"Hello, {memberUser.Username}!"));
				}
				UpdateActivity(discord, lobby);
			});
		};
		activityManager.OnActivitySpectate += delegate(string secret)
		{
			Console.WriteLine("OnSpectate {0}", secret);
		};
		activityManager.OnActivityJoinRequest += delegate(ref User user)
		{
			Console.WriteLine("OnJoinRequest {0} {1}", user.Id, user.Username);
		};
		activityManager.OnActivityInvite += delegate(ActivityActionType Type, ref User user, ref Activity activity2)
		{
			Console.WriteLine("OnInvite {0} {1} {2}", Type, user.Username, activity2.Name);
		};
		ImageManager imageManager = discord.GetImageManager();
		UserManager userManager = discord.GetUserManager();
		userManager.OnCurrentUserUpdate += delegate
		{
			User currentUser = userManager.GetCurrentUser();
			Console.WriteLine(currentUser.Username);
			Console.WriteLine(currentUser.Id);
		};
		userManager.GetUser(450795363658366976L, delegate(Result result, ref User user)
		{
			if (result == Result.Ok)
			{
				Console.WriteLine("user fetched: {0}", user.Username);
				FetchAvatar(imageManager, user.Id);
			}
			else
			{
				Console.WriteLine("user fetch error: {0}", result);
			}
		});
		RelationshipManager relationshipManager = discord.GetRelationshipManager();
		relationshipManager.OnRefresh += delegate
		{
			relationshipManager.Filter(delegate(ref Relationship relationship)
			{
				return relationship.Type == RelationshipType.Friend;
			});
			Console.WriteLine("relationships updated: {0}", relationshipManager.Count());
			for (int num = 0; num < Math.Min(relationshipManager.Count(), 10); num++)
			{
				Relationship at = relationshipManager.GetAt((uint)num);
				Console.WriteLine("relationships: {0} {1} {2} {3}", at.Type, at.User.Username, at.Presence.Status, at.Presence.Activity.Name);
				FetchAvatar(imageManager, at.User.Id);
			}
		};
		relationshipManager.OnRelationshipUpdate += delegate(ref Relationship r)
		{
			Console.WriteLine("relationship updated: {0} {1} {2} {3}", r.Type, r.User.Username, r.Presence.Status, r.Presence.Activity.Name);
		};
		lobbyManager.OnLobbyMessage += delegate(long lobbyID, long userID, byte[] data)
		{
			Console.WriteLine("lobby message: {0} {1}", lobbyID, Encoding.UTF8.GetString(data));
		};
		lobbyManager.OnNetworkMessage += delegate(long lobbyId, long userId, byte channelId, byte[] data)
		{
			Console.WriteLine("network message: {0} {1} {2} {3}", lobbyId, userId, channelId, Encoding.UTF8.GetString(data));
		};
		lobbyManager.OnSpeaking += delegate(long lobbyID, long userID, bool speaking)
		{
			Console.WriteLine("lobby speaking: {0} {1} {2}", lobbyID, userID, speaking);
		};
		LobbyTransaction lobbyCreateTransaction = lobbyManager.GetLobbyCreateTransaction();
		lobbyCreateTransaction.SetCapacity(6u);
		lobbyCreateTransaction.SetType(LobbyType.Public);
		lobbyCreateTransaction.SetMetadata("a", "123");
		lobbyCreateTransaction.SetMetadata("a", "456");
		lobbyCreateTransaction.SetMetadata("b", "111");
		lobbyCreateTransaction.SetMetadata("c", "222");
		lobbyManager.CreateLobby(lobbyCreateTransaction, delegate(Result result, ref Lobby lobby)
		{
			if (result == Result.Ok)
			{
				Console.WriteLine("lobby {0} with capacity {1} and secret {2}", lobby.Id, lobby.Capacity, lobby.Secret);
				string[] array = new string[3] { "a", "b", "c" };
				foreach (string text2 in array)
				{
					Console.WriteLine("{0} = {1}", text2, lobbyManager.GetLobbyMetadataValue(lobby.Id, text2));
				}
				foreach (User memberUser2 in lobbyManager.GetMemberUsers(lobby.Id))
				{
					Console.WriteLine("lobby member: {0}", memberUser2.Username);
				}
				lobbyManager.SendLobbyMessage(lobby.Id, "Hello from C#!", delegate
				{
					Console.WriteLine("sent message");
				});
				LobbyTransaction lobbyUpdateTransaction = lobbyManager.GetLobbyUpdateTransaction(lobby.Id);
				lobbyUpdateTransaction.SetMetadata("d", "e");
				lobbyUpdateTransaction.SetCapacity(16u);
				lobbyManager.UpdateLobby(lobby.Id, lobbyUpdateTransaction, delegate
				{
					Console.WriteLine("lobby has been updated");
				});
				long lobbyID = lobby.Id;
				long userID = lobby.OwnerId;
				LobbyMemberTransaction memberUpdateTransaction = lobbyManager.GetMemberUpdateTransaction(lobbyID, userID);
				memberUpdateTransaction.SetMetadata("hello", "there");
				lobbyManager.UpdateMember(lobbyID, userID, memberUpdateTransaction, delegate
				{
					Console.WriteLine("lobby member has been updated: {0}", lobbyManager.GetMemberMetadataValue(lobbyID, userID, "hello"));
				});
				LobbySearchQuery searchQuery = lobbyManager.GetSearchQuery();
				searchQuery.Filter("metadata.a", LobbySearchComparison.GreaterThan, LobbySearchCast.Number, "455");
				searchQuery.Sort("metadata.a", LobbySearchCast.Number, "0");
				searchQuery.Limit(1u);
				lobbyManager.Search(searchQuery, delegate
				{
					Console.WriteLine("search returned {0} lobbies", lobbyManager.LobbyCount());
					if (lobbyManager.LobbyCount() == 1)
					{
						Console.WriteLine("first lobby secret: {0}", lobbyManager.GetLobby(lobbyManager.GetLobbyId(0)).Secret);
					}
				});
				lobbyManager.ConnectVoice(lobby.Id, delegate
				{
					Console.WriteLine("Connected to voice chat!");
				});
				lobbyManager.ConnectNetwork(lobby.Id);
				lobbyManager.OpenNetworkChannel(lobby.Id, 0, reliable: true);
				UpdateActivity(discord, lobby);
			}
		});
		StorageManager storageManager = discord.GetStorageManager();
		byte[] contents = new byte[20000];
		new Random().NextBytes(contents);
		Console.WriteLine("storage path: {0}", storageManager.GetPath());
		storageManager.WriteAsync("foo", contents, delegate
		{
			foreach (FileStat item in storageManager.Files())
			{
				Console.WriteLine("file: {0} size: {1} last_modified: {2}", item.Filename, item.Size, item.LastModified);
			}
			storageManager.ReadAsyncPartial("foo", 400uL, 50uL, delegate(Result result, byte[] data)
			{
				Console.WriteLine("partial contents of foo match {0}", data.SequenceEqual(new ArraySegment<byte>(contents, 400, 50)));
			});
			storageManager.ReadAsync("foo", delegate(Result result, byte[] data)
			{
				Console.WriteLine("length of contents {0} data {1}", contents.Length, data.Length);
				Console.WriteLine("contents of foo match {0}", data.SequenceEqual(contents));
				Console.WriteLine("foo exists? {0}", storageManager.Exists("foo"));
				storageManager.Delete("foo");
				Console.WriteLine("post-delete foo exists? {0}", storageManager.Exists("foo"));
			});
		});
		StoreManager storeManager = discord.GetStoreManager();
		storeManager.OnEntitlementCreate += delegate(ref Entitlement entitlement)
		{
			Console.WriteLine("Entitlement Create1: {0}", entitlement.Id);
		};
		storeManager.FetchEntitlements(delegate(Result result)
		{
			if (result == Result.Ok)
			{
				foreach (Entitlement entitlement in storeManager.GetEntitlements())
				{
					Console.WriteLine("entitlement: {0} - {1} {2}", entitlement.Id, entitlement.Type, entitlement.SkuId);
				}
			}
		});
		storeManager.FetchSkus(delegate(Result result)
		{
			if (result == Result.Ok)
			{
				foreach (Sku sku in storeManager.GetSkus())
				{
					Console.WriteLine("sku: {0} - {1} {2}", sku.Name, sku.Price.Amount, sku.Price.Currency);
				}
			}
		});
		try
		{
			while (true)
			{
				discord.RunCallbacks();
				lobbyManager.FlushNetwork();
				Thread.Sleep(16);
			}
		}
		finally
		{
			discord.Dispose();
		}
	}
}
