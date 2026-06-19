using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyJoinConfiguration
	{
		public IDictionary<string, string> MemberProperties { get; set; }

		public PFLobbyJoinConfiguration()
		{
			MemberProperties = new Dictionary<string, string>();
		}

		internal unsafe PFLobbyJoinConfiguration(PlayFab.Multiplayer.Interop.PFLobbyJoinConfiguration interopStruct)
		{
			string[] memberPropertyKeys = Converters.StringPtrToArray(interopStruct.memberPropertyKeys, interopStruct.memberPropertyCount);
			string[] memberPropertyValues = Converters.StringPtrToArray(interopStruct.memberPropertyValues, interopStruct.memberPropertyCount);
			if (memberPropertyKeys.Length == memberPropertyValues.Length)
			{
				MemberProperties = Enumerable.Range(0, memberPropertyKeys.Length).ToDictionary((int i) => memberPropertyKeys[i], (int i) => memberPropertyValues[i]);
				return;
			}
			throw new IndexOutOfRangeException("memberPropertyKeys and memberPropertyValues don't have same length");
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyJoinConfiguration* ToPointer(DisposableCollection disposableCollection)
		{
			SizeT count;
			return (PlayFab.Multiplayer.Interop.PFLobbyJoinConfiguration*)(void*)Converters.StructToPtr(new PlayFab.Multiplayer.Interop.PFLobbyJoinConfiguration
			{
				memberPropertyCount = Convert.ToUInt32(MemberProperties.Count),
				memberPropertyKeys = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(MemberProperties.Keys.ToArray(), disposableCollection, out count),
				memberPropertyValues = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(MemberProperties.Values.ToArray(), disposableCollection, out count)
			}, disposableCollection);
		}
	}
}
