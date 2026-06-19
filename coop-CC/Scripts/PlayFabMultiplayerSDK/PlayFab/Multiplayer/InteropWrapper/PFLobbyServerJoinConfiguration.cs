using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyServerJoinConfiguration
	{
		public IDictionary<string, string> ServerProperties { get; set; }

		public PFLobbyServerJoinConfiguration()
		{
			ServerProperties = new Dictionary<string, string>();
		}

		internal unsafe PFLobbyServerJoinConfiguration(PlayFab.Multiplayer.Interop.PFLobbyServerJoinConfiguration interopStruct)
		{
			string[] serverPropertyKeys = Converters.StringPtrToArray(interopStruct.serverPropertyKeys, interopStruct.serverPropertyCount);
			string[] serverPropertyValues = Converters.StringPtrToArray(interopStruct.serverPropertyValues, interopStruct.serverPropertyCount);
			if (serverPropertyKeys.Length == serverPropertyValues.Length)
			{
				ServerProperties = Enumerable.Range(0, serverPropertyKeys.Length).ToDictionary((int i) => serverPropertyKeys[i], (int i) => serverPropertyValues[i]);
				return;
			}
			throw new IndexOutOfRangeException("serverPropertyKeys and serverPropertyValues don't have same length");
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyServerJoinConfiguration* ToPointer(DisposableCollection disposableCollection)
		{
			SizeT count;
			return (PlayFab.Multiplayer.Interop.PFLobbyServerJoinConfiguration*)(void*)Converters.StructToPtr(new PlayFab.Multiplayer.Interop.PFLobbyServerJoinConfiguration
			{
				serverPropertyCount = Convert.ToUInt32(ServerProperties.Count),
				serverPropertyKeys = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(ServerProperties.Keys.ToArray(), disposableCollection, out count),
				serverPropertyValues = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(ServerProperties.Values.ToArray(), disposableCollection, out count)
			}, disposableCollection);
		}
	}
}
