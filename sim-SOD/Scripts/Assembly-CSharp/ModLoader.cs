using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NaughtyAttributes;
using Steamworks;
using UnityEngine;

public class ModLoader : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSteamworksModLoadingCheck_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ModLoader _003C_003E4__this;

		private bool _003Cwaiting_003E5__2;

		private bool _003CdoSteamworksCheck_003E5__3;

		private float _003Ctimeout_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CSteamworksModLoadingCheck_003Ed__14(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWaitForLoadingModdedFiles_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ModLoader _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CWaitForLoadingModdedFiles_003Ed__16(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CLoadInModdedFiles_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public ModLoader _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public List<FileInfo> moddedInteractableFiles;

		public ModLoader _003C_003E4__this;

		public List<FileInfo> moddedMenuFiles;

		public List<FileInfo> moddedRetailItems;

		public List<FileInfo> moddedMurderWeapons;

		public List<FileInfo> moddedBooks;

		public List<FileInfo> moddedColourSchemes;

		public List<ModdedInteractable> parsedInteractableFiles;

		public List<ModdedMenu> parsedMenuFiles;

		public List<ModdedRetailItem> parsedRetailItemFiles;

		public List<ModdedMurderWeapon> parsedMurderWeaponFiles;

		public List<ModdedBook> parsedBookFiles;

		public List<ModdedColourScheme> parsedColourSchemeFiles;

		internal void _003CPerformModdedFileLoadAsync_003Eb__0()
		{
		}

		internal void _003CPerformModdedFileLoadAsync_003Eb__1()
		{
		}

		internal void _003CPerformModdedFileLoadAsync_003Eb__2()
		{
		}

		internal void _003CPerformModdedFileLoadAsync_003Eb__3()
		{
		}

		internal void _003CPerformModdedFileLoadAsync_003Eb__4()
		{
		}

		internal void _003CPerformModdedFileLoadAsync_003Eb__5()
		{
		}

		internal void _003CPerformModdedFileLoadAsync_003Eb__6()
		{
		}

		internal void _003CPerformModdedFileLoadAsync_003Eb__7()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_1
	{
		public int i;

		public _003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_2
	{
		public ModdedInteractable moddedInteractable;

		public _003C_003Ec__DisplayClass31_1 CS_0024_003C_003E8__locals2;

		internal void _003CPerformModdedFileLoadAsync_003Eb__8()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_3
	{
		public int i;

		public _003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals3;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_4
	{
		public ModdedMenu moddedMenu;

		public _003C_003Ec__DisplayClass31_3 CS_0024_003C_003E8__locals4;

		internal void _003CPerformModdedFileLoadAsync_003Eb__9()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_5
	{
		public int i;

		public _003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals5;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_6
	{
		public ModdedRetailItem moddedRetailItem;

		public _003C_003Ec__DisplayClass31_5 CS_0024_003C_003E8__locals6;

		internal void _003CPerformModdedFileLoadAsync_003Eb__10()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_7
	{
		public int i;

		public _003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals7;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_8
	{
		public ModdedMurderWeapon moddedMurderWeapon;

		public _003C_003Ec__DisplayClass31_7 CS_0024_003C_003E8__locals8;

		internal void _003CPerformModdedFileLoadAsync_003Eb__11()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_9
	{
		public int i;

		public _003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals9;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_10
	{
		public ModdedBook moddedBook;

		public _003C_003Ec__DisplayClass31_9 CS_0024_003C_003E8__locals10;

		internal void _003CPerformModdedFileLoadAsync_003Eb__12()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_11
	{
		public int i;

		public _003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals11;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_12
	{
		public ModdedColourScheme moddedColourScheme;

		public _003C_003Ec__DisplayClass31_11 CS_0024_003C_003E8__locals12;

		internal void _003CPerformModdedFileLoadAsync_003Eb__13()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CPerformModdedFileLoadAsync_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ModLoader _003C_003E4__this;

		private _003C_003Ec__DisplayClass31_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass31_1 _003C_003E8__2;

		private _003C_003Ec__DisplayClass31_2 _003C_003E8__3;

		private _003C_003Ec__DisplayClass31_3 _003C_003E8__4;

		private _003C_003Ec__DisplayClass31_4 _003C_003E8__5;

		private _003C_003Ec__DisplayClass31_5 _003C_003E8__6;

		private _003C_003Ec__DisplayClass31_6 _003C_003E8__7;

		private _003C_003Ec__DisplayClass31_7 _003C_003E8__8;

		private _003C_003Ec__DisplayClass31_8 _003C_003E8__9;

		private _003C_003Ec__DisplayClass31_9 _003C_003E8__10;

		private _003C_003Ec__DisplayClass31_10 _003C_003E8__11;

		private _003C_003Ec__DisplayClass31_11 _003C_003E8__12;

		private _003C_003Ec__DisplayClass31_12 _003C_003E8__13;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[InfoBox("IMPORTANT: The ModLoader.cs script is present in the ControllerDetect screen, and will not be removed on scene change; so mods are loaded at the beginning but this will behave differently in editor where you aren't first running the ControllerDetect scene.", EInfoBoxType.Normal)]
	[Header("Status")]
	public bool modsLoaded;

	public bool waitingForSteamworksMods;

	public List<ModSettingsData> sortedModsList;

	private List<ModSettingsData> modsListTemp;

	private List<string> latestSteamworksSubscribedList;

	public Dictionary<Type, Dictionary<string, ScriptableObject>> createdModResources;

	public List<string> modStringFiles;

	public bool loadedModdedFiles;

	private bool waitingForModdedFileLoad;

	private static ModLoader _instance;

	public static ModLoader Instance => null;

	private void Awake()
	{
	}

	public void GetMods(bool allowDelayedSteamworksCheck = false)
	{
	}

	[IteratorStateMachine(typeof(_003CSteamworksModLoadingCheck_003Ed__14))]
	private IEnumerator SteamworksModLoadingCheck()
	{
		return null;
	}

	public void GetModsComplete()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForLoadingModdedFiles_003Ed__16))]
	private IEnumerator WaitForLoadingModdedFiles()
	{
		return null;
	}

	public List<ModSettingsData> GetLocalMods()
	{
		return null;
	}

	public List<ModSettingsData> GetModIOMods()
	{
		return null;
	}

	private bool TryGetSteamWorkshopItems()
	{
		return false;
	}

	private void SteamWorkshopContentQueryCompleted(SteamUGCQueryCompleted_t response, bool bIOFailure)
	{
	}

	private ModSettingsData GetOrCreateModSettings(string path, string modName, ModSettingsData.ModSource source, string creator, string summary, string alternatePath = "", bool modEnabled = true, bool disableCreateFile = false, string workshopID = "", List<string> tags = null)
	{
		return null;
	}

	public List<FileInfo> GetFilesWithinActiveMods(string subPath, params string[] fileExtensions)
	{
		return null;
	}

	public List<DirectoryInfo> GetActiveLanguageModDirectories()
	{
		return null;
	}

	public List<FileInfo> GetActiveCities()
	{
		return null;
	}

	public List<FileInfo> GetActiveSaves()
	{
		return null;
	}

	public List<DirectoryInfo> GetActiveDDSModDirectories()
	{
		return null;
	}

	public bool IsConsole()
	{
		return false;
	}

	private void AddSOToModResources(ScriptableObject so)
	{
	}

	public bool GetDataFromModResources<T>(string searchName, out T output) where T : ScriptableObject
	{
		output = null;
		return false;
	}

	[AsyncStateMachine(typeof(_003CLoadInModdedFiles_003Ed__30))]
	public void LoadInModdedFiles()
	{
	}

	[AsyncStateMachine(typeof(_003CPerformModdedFileLoadAsync_003Ed__31))]
	public Task PerformModdedFileLoadAsync()
	{
		return null;
	}

	public void LoadModdedResources()
	{
	}

	public InteractablePreset CreateItemFromModdedItemData(ModdedInteractable modItemData)
	{
		return null;
	}

	public MenuPreset CreateMenuFromModdedItemData(ModdedMenu modMenuData)
	{
		return null;
	}

	public RetailItemPreset CreateRetailItemFromModdedItemData(ModdedRetailItem modRetailItemData)
	{
		return null;
	}

	public MurderWeaponPreset CreateMurderWeaponFromModdedItemData(ModdedMurderWeapon modWeaponData)
	{
		return null;
	}

	public BookPreset CreateBookFromModdedItemData(ModdedBook modBookData)
	{
		return null;
	}

	public ColourSchemePreset CreateColourSchemeModdedItemData(ModdedColourScheme modColourData)
	{
		return null;
	}

	private bool TryFindPrefab(string prefabName, out GameObject prefab)
	{
		prefab = null;
		return false;
	}

	private bool TryFindObjectSprite(string objectName, out Sprite sprite)
	{
		sprite = null;
		return false;
	}

	private bool TryParseTraitPick(ref List<string> input, out InteractablePreset.TraitPick pick)
	{
		pick = null;
		return false;
	}

	private bool TryParseTraitPick(ref List<string> input, out MurderPreset.MurdererModifierRule pick)
	{
		pick = null;
		return false;
	}

	private bool TryParseTraitPick(ref List<string> input, out CharacterTrait.TraitPickRule pick)
	{
		pick = null;
		return false;
	}

	public void CopyItemData(ref InteractablePreset copyTo, ref InteractablePreset copyFrom)
	{
	}

	public void CopyMenuData(ref MenuPreset copyTo, ref MenuPreset copyFrom)
	{
	}

	public void CopyRetailItemData(ref RetailItemPreset copyTo, ref RetailItemPreset copyFrom)
	{
	}

	public void CopyMurderWeaponData(ref MurderWeaponPreset copyTo, ref MurderWeaponPreset copyFrom)
	{
	}

	public void CopyBookData(ref BookPreset copyTo, ref BookPreset copyFrom)
	{
	}

	public void CopyColourSchemeData(ref ColourSchemePreset copyTo, ref ColourSchemePreset copyFrom)
	{
	}

	private void ParseBool(ref string input, ref bool boolRef)
	{
	}

	private void ParseInt(ref string input, ref int intRef)
	{
	}

	private void ParseFloat(ref string input, ref float floatRef)
	{
	}

	private void ParseEnum<T>(ref string input, ref T enumRef)
	{
	}
}
