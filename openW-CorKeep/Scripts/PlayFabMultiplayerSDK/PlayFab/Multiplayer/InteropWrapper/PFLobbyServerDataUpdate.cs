using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyServerDataUpdate
	{
		public PFEntityKey NewServer { get; set; }

		public IDictionary<string, string> ServerProperties { get; set; }

		public PFLobbyServerDataUpdate()
		{
			ServerProperties = new Dictionary<string, string>();
		}

		internal unsafe PFLobbyServerDataUpdate(PlayFab.Multiplayer.Interop.PFLobbyServerDataUpdate interopStruct)
		{
			NewServer = new PFEntityKey(interopStruct.newServer);
			string[] serverPropertyKeys = Converters.StringPtrToArray(interopStruct.serverPropertyKeys, interopStruct.serverPropertyCount);
			string[] serverPropertyValues = Converters.StringPtrToArray(interopStruct.serverPropertyValues, interopStruct.serverPropertyCount);
			if (serverPropertyKeys.Length == serverPropertyValues.Length)
			{
				ServerProperties = Enumerable.Range(0, serverPropertyKeys.Length).ToDictionary((int i) => serverPropertyKeys[i], (int i) => serverPropertyValues[i]);
				return;
			}
			throw new IndexOutOfRangeException("serverPropertyKeys and serverPropertyValues don't have same length");
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyServerDataUpdate* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFLobbyServerDataUpdate interopStruct = default(PlayFab.Multiplayer.Interop.PFLobbyServerDataUpdate);
			interopStruct.newServer = ((NewServer != null) ? NewServer.ToPointer(disposableCollection) : null);
			interopStruct.serverPropertyCount = ((ServerProperties != null) ? Convert.ToUInt32(ServerProperties.Count) : 0u);
			interopStruct.serverPropertyKeys = (sbyte**)((interopStruct.serverPropertyCount != 0) ? ((void*)Converters.StringArrayToUTF8StringArray(ServerProperties.Keys.ToArray(), disposableCollection, out var count)) : null);
			interopStruct.serverPropertyValues = (sbyte**)((interopStruct.serverPropertyCount != 0) ? ((void*)Converters.StringArrayToUTF8StringArray(ServerProperties.Values.ToArray(), disposableCollection, out count)) : null);
			return (PlayFab.Multiplayer.Interop.PFLobbyServerDataUpdate*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
