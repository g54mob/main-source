using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework.Loading
{
	public class GameplayLoader
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitAndRunCallback_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action callback;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		public const string CACHE_GROUP_NAME = "Gameplay";

		private GameManager _gameManager;

		private DataManager _dataManager;

		private PlayerOptions _playerOptions;

		private TilesetFactory _tilesetFactory;

		[Inject]
		private void Construct(GameManager gameManager, DataManager dataManager, PlayerOptions playerOptions, TilesetFactory tilesetFactory)
		{
		}

		private Dictionary<StageType, StageData> GetAllUsedStageData()
		{
			return null;
		}

		public void Preload(Action onComplete)
		{
		}

		private void PreloadTilesets(AsyncLoader loader, StageType stageType)
		{
		}

		private void PreloadCharacters(AsyncLoader loader)
		{
		}

		private void PreloadEnemies(AsyncLoader loader, StageType stageType)
		{
		}

		public void Load(Action onComplete)
		{
		}

		[AsyncStateMachine(typeof(_003CWaitAndRunCallback_003Ed__12))]
		private void WaitAndRunCallback(Action callback)
		{
		}

		private void LoadTextures(AsyncLoader loader, PreloadData preloadData, DlcType? stageDlcType)
		{
		}

		private void LoadBgm(AsyncLoader loader, PreloadData preloadData)
		{
		}

		private void LoadCharacters(AsyncLoader loader, List<CharacterType> chars)
		{
		}

		private void LoadVideos(AsyncLoader loader, PreloadData preloadData, DlcType? stageDlcType)
		{
		}

		private List<CharacterType> GetTilesetCharacters(StageData stageData)
		{
			return null;
		}

		public static void LoadCoffinCharactersOnline()
		{
		}

		public void Release()
		{
		}
	}
}
