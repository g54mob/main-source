using System;
using System.Collections.Generic;
using Coherence.Common;
using Cpp2ILInjected;

namespace Coherence;

internal static class DocumentationLinks
{
	private static Dictionary<DocumentationKeys, string> documentationLinks;

	public static IEnumerable<DocumentationKeys> ActiveKeys
	{
		get
		{
			if (documentationLinks != null)
			{
				return documentationLinks.Keys;
			}
			return (IEnumerable<DocumentationKeys>)new NullReferenceException();
		}
	}

	public unsafe static string GetDocsUrl(DocumentationKeys key = DocumentationKeys.None)
	{
		//IL_016d: Expected O, but got I
		//IL_017d: Expected O, but got I
		//IL_00e6: Expected O, but got I
		//IL_00f6: Expected O, but got I
		//IL_00b6: Expected I4, but got O
		//IL_00b6: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+B8]");
		object obj2 = 0;
		bool flag = key == DocumentationKeys.None;
		object value = obj2;
		if (!flag)
		{
			if (documentationLinks == null)
			{
				return (string)(object)new NullReferenceException();
			}
			if (!((Dictionary<System.Int32Enum, object>)(object)documentationLinks).TryGetValue((System.Int32Enum)key, out value))
			{
				DocumentationKeys documentationKeys = default(DocumentationKeys);
				object arg = documentationKeys;
				string message = string.Format("Key {0} not registered. Register it in '{1}.{2}'.", arg, "DocumentationLinks", "documentationLinks");
				ArgumentException ex = new ArgumentException(message, "key");
				throw ex;
			}
		}
		RuntimeSettings instance = PreloadedSingleton<RuntimeSettings>.Instance;
		string text2;
		if ((object)instance != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v7 (Coherence.RuntimeSettings)+10]");
			if ((nint)0 != 0 && (object)instance.versionInfo != null)
			{
				string text = (string)((Dictionary<DocumentationKeys, string>)4).TryGetValue((DocumentationKeys)typeof(IVersionInfo), out *(string*)instance.versionInfo);
				text2 = "/v/" + text;
				goto IL_01f0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16+B8]");
		object obj4 = 0;
		text2 = (string)obj4;
		goto IL_01f0;
		IL_01f0:
		string text3 = "https://docs.coherence.io" + text2;
		return text3 + (string)obj2;
	}

	private static string GetDocsBaseUrl()
	{
		//IL_0091: Expected O, but got I
		//IL_00a1: Expected O, but got I
		RuntimeSettings instance = PreloadedSingleton<RuntimeSettings>.Instance;
		string text;
		if ((object)instance != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (Coherence.RuntimeSettings)+10]");
			if ((nint)0 != 0 && (object)instance.versionInfo != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				string text2 = default(string);
				text = "/v/" + text2;
				goto IL_00de;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v10+B8]");
		object obj2 = 0;
		text = (string)obj2;
		goto IL_00de;
		IL_00de:
		return "https://docs.coherence.io" + text;
	}

	private static string GetUnpublishedDocsBaseUrl()
	{
		//IL_0091: Expected O, but got I
		//IL_00a1: Expected O, but got I
		RuntimeSettings instance = PreloadedSingleton<RuntimeSettings>.Instance;
		string text;
		if ((object)instance != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (Coherence.RuntimeSettings)+10]");
			if ((nint)0 != 0 && (object)instance.versionInfo != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				string text2 = default(string);
				text = "/" + text2;
				goto IL_00de;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v10+B8]");
		object obj2 = 0;
		text = (string)obj2;
		goto IL_00de;
		IL_00de:
		return "https://docs-coherence.gitbook.io" + text;
	}

	static DocumentationLinks()
	{
		Dictionary<DocumentationKeys, string> dictionary = new Dictionary<DocumentationKeys, string>();
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)1, (object)"/hosting/coherence-cloud/online-dashboard", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)2, (object)"/getting-started/setup-a-project", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)3, (object)"/getting-started/setup-a-project/test-in-the-cloud/deploy-replication-server#upload-schema", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)4, (object)"/getting-started/setup-a-project/prefab-setup", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)5, (object)"/getting-started/setup-a-project/scene-setup", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)6, (object)"/manual/baking-and-code-generation", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)7, (object)"/manual/simulation-server", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)8, (object)"/getting-started/setup-a-project/local-development", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag9 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)9, (object)"/getting-started/setup-a-project/scene-setup#id-1.-add-a-coherencebridge", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag10 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)10, (object)"/getting-started/setup-a-project/scene-setup#id-2.-add-a-livequery", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag11 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)11, (object)"/manual/advanced-topics/schema-explained", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag12 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)12, (object)"/manual/replication-server/rooms-and-worlds", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag13 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)13, (object)"/manual/components/coherence-bridge", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag14 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)14, (object)"/manual/components/coherence-bridge#onlivequerysynced", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag15 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)15, (object)"/hosting/coherence-cloud", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag16 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)16, (object)"/manual/advanced-topics/competitive-games/simulation-frame", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag17 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)17, (object)"/manual/client-connections", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag18 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)18, (object)"/manual/client-connections#clientconnection-objects", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag19 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)19, (object)"/manual/components/coherence-sync", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag20 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)20, (object)"/manual/authority", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag21 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)21, (object)"/manual/authority/server-authoritative-setup", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag22 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)22, (object)"/manual/components/coherence-sync", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag23 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)23, (object)"/manual/components/coherence-tag-query", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag24 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)24, (object)"/manual/scenes", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag25 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)25, (object)"/manual/replication-server#unlock-token", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag26 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)26, (object)"/support/release-notes", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag27 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)27, (object)"/manual/parenting-network-entities", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag28 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)28, (object)"/getting-started/setup-a-project", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag29 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)29, (object)"/manual/simulation-server/client-vs-simulator-logic#connecting-simulators-automatically-to-rs-autosimulatorconnection-component", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag30 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)30, (object)"/overview", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag31 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)31, (object)"/manual/replication-server#maximum-query-count-per-client", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag32 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)32, (object)"/hosting/coherence-cloud/coherence-cloud-apis", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag33 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)33, (object)"/manual/replication-server/replication-server-api", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag34 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)34, (object)"/manual/components/coherenceglobalquery", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		documentationLinks = dictionary;
	}
}
