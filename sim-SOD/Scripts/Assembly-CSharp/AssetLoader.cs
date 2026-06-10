using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetLoader
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CPerformInitialLoadAsync_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AssetLoader _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private int _003CoriginalVSync_003E5__3;

		private AsyncOperationHandle<IList<ScriptableObject>> _003CasyncOperationHandleData_003E5__4;

		private AsyncOperationHandle<IList<TextAsset>> _003CasyncOperationHandleFloorData_003E5__5;

		private TaskAwaiter<IList<ScriptableObject>> _003C_003Eu__1;

		private TaskAwaiter<IList<TextAsset>> _003C_003Eu__2;

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

	public static readonly string DATA_GROUP;

	public static readonly string AMBIENT_ZONES_GROUP;

	public static readonly string MUSIC_CUES_GROUP;

	public static readonly string CHAPTERS_GROUP;

	public static readonly string ACTIONS_GROUP;

	public static readonly string FLOOR_DATA_GROUP;

	public static readonly string BUILDING_DATA_GROUP;

	public static readonly string FURNITURE_GROUP;

	public static readonly string INTERACTABLES_GROUP;

	public static readonly string CLOTHES_GROUP;

	public static readonly string LAYOUT_CONFIG_GROUP;

	public static readonly string ROOM_CONFIG_GROUP;

	public static readonly string ROOM_PRESETS_GROUP;

	public static readonly string DOOR_PAIR_PRESETS_GROUP;

	private static AssetLoader instance;

	private List<ScriptableObject> allPresets;

	private List<AmbientZone> allAmbientZones;

	private List<MusicCue> allMusicCues;

	private List<ChapterPreset> allChapters;

	private List<AIActionPreset> allActions;

	private List<TextAsset> allFloorData;

	private List<BuildingPreset> allBuildingData;

	private List<FurniturePreset> allFurniture;

	private List<InteractablePreset> allInteractables;

	private List<ClothesPreset> allClothes;

	private List<LayoutConfiguration> allLayoutConfigurations;

	private List<RoomConfiguration> allRoomConfigurations;

	private List<RoomTypePreset> allRoomTypePresets;

	private List<DoorPairPreset> allDoorPairPresets;

	public static AssetLoader Instance => null;

	private void SortScriptableObject(ScriptableObject scriptableObject)
	{
	}

	private static float TimeDiff(float time)
	{
		return 0f;
	}

	private static string TimeDiffStr(float time)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CPerformInitialLoadAsync_003Ed__34))]
	public Task PerformInitialLoadAsync()
	{
		return null;
	}

	public List<ScriptableObject> GetAllPresets()
	{
		return null;
	}

	public List<AmbientZone> GetAllAmbientZones()
	{
		return null;
	}

	public List<MusicCue> GetAllMusicCues()
	{
		return null;
	}

	public List<ChapterPreset> GetAllChapters()
	{
		return null;
	}

	public List<AIActionPreset> GetAllActions()
	{
		return null;
	}

	public List<TextAsset> GetAllFloorData()
	{
		return null;
	}

	public List<BuildingPreset> GetAllBuildingPresets()
	{
		return null;
	}

	public List<FurniturePreset> GetAllFurniture()
	{
		return null;
	}

	public List<InteractablePreset> GetAllInteractables()
	{
		return null;
	}

	public List<ClothesPreset> GetAllClothes()
	{
		return null;
	}

	public List<LayoutConfiguration> GetAllLayoutConfigurations()
	{
		return null;
	}

	public List<RoomConfiguration> GetAllRoomConfigurations()
	{
		return null;
	}

	public List<RoomTypePreset> GetAllRoomTypePresets()
	{
		return null;
	}

	public List<DoorPairPreset> GetAllDoorPairPresets()
	{
		return null;
	}
}
