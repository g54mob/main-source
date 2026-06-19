using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyMemberDataUpdate
	{
		public IDictionary<string, string> MemberProperties { get; set; }

		public PFLobbyMemberDataUpdate(IDictionary<string, string> memberProperties)
		{
			MemberProperties = memberProperties;
		}

		internal unsafe PFLobbyMemberDataUpdate(PlayFab.Multiplayer.Interop.PFLobbyMemberDataUpdate interopStruct)
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

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyMemberDataUpdate* ToPointer(DisposableCollection disposableCollection)
		{
			SizeT count;
			return (PlayFab.Multiplayer.Interop.PFLobbyMemberDataUpdate*)(void*)Converters.StructToPtr(new PlayFab.Multiplayer.Interop.PFLobbyMemberDataUpdate
			{
				memberPropertyCount = Convert.ToUInt32(MemberProperties.Count),
				memberPropertyKeys = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(MemberProperties.Keys.ToArray(), disposableCollection, out count),
				memberPropertyValues = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(MemberProperties.Values.ToArray(), disposableCollection, out count)
			}, disposableCollection);
		}
	}
}
