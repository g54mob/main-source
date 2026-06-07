using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameLoop
{
	public class FlightGameLoop : GameLoopBase, IFlightGameLoop, IGameLoop
	{
		private static FrameData _commonFrameData;

		private static FlightFrameData _frameData;

		private FlightSceneScript _flightSceneScript;

		private IUpdateGroup[] _groupsEndOfFrameUpdate;

		private IUpdateGroup[] _groupsFixedUpdate;

		private IUpdateGroup[] _groupsLateUpdate;

		private IUpdateGroup[] _groupsUpdate;

		private FlightUpdateGroupCollection _scripts;

		private TimeManager _timeManager;

		public void Register(IGameLoopItem script)
		{
			_scripts.Register(script);
		}

		public void Unregister(IGameLoopItem script)
		{
			_scripts.Unregister(script);
		}

		protected override void Awake()
		{
			base.Awake();
			_scripts = new FlightUpdateGroupCollection(this);
			_groupsFixedUpdate = new IUpdateGroup[12]
			{
				_scripts.StartCommon, _scripts.Start, _scripts.PostStartCommon, _scripts.PostStart, _scripts.PreFixedUpdateParallel, _scripts.PreFixedUpdate, _scripts.FixedUpdateParallel, _scripts.FixedUpdateCommon, _scripts.FixedUpdate, _scripts.FixedUpdateWarp,
				_scripts.PostFixedUpdateParallel, _scripts.PostFixedUpdate
			};
			_groupsUpdate = new IUpdateGroup[13]
			{
				_scripts.StartCommon, _scripts.Start, _scripts.PostStartCommon, _scripts.PostStart, _scripts.PreUpdateParallel, _scripts.PreUpdate, _scripts.UpdateParallel, _scripts.UpdateCommon, _scripts.Update, _scripts.UpdatePaused,
				_scripts.BodyScripts, _scripts.PostUpdateParallel, _scripts.PostUpdate
			};
			_groupsLateUpdate = new IUpdateGroup[12]
			{
				_scripts.StartCommon, _scripts.Start, _scripts.PostStartCommon, _scripts.PostStart, _scripts.PreLateUpdateParallel, _scripts.PreLateUpdate, _scripts.LateUpdateParallel, _scripts.LateUpdateCommon, _scripts.LateUpdate, _scripts.LateUpdatePaused,
				_scripts.PostLateUpdateParallel, _scripts.PostLateUpdate
			};
			_groupsEndOfFrameUpdate = new IUpdateGroup[8] { _scripts.StartCommon, _scripts.Start, _scripts.PostStartCommon, _scripts.PostStart, _scripts.EndOfFramePreUpdate, _scripts.EndOfFrameUpdateCommon, _scripts.EndOfFrameUpdate, _scripts.EndOfFramePostUpdate };
		}

		protected override void EndOfFrame()
		{
			BeginUpdates(_groupsEndOfFrameUpdate);
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.StartCommon, delegate(IStart x)
			{
				x.Start(in _commonFrameData);
			}, _scripts.Start, delegate(IFlightStart x)
			{
				x.FlightStart(in _frameData);
			}, "Scripts.Start & Scripts.FlightStart");
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.PostStartCommon, delegate(IPostStart x)
			{
				x.PostStart(in _commonFrameData);
			}, _scripts.PostStart, delegate(IFlightPostStart x)
			{
				x.FlightPostStart(in _frameData);
			}, "Scripts.PostStart & Scripts.FlightPostStart");
			_scripts.EndOfFramePreUpdate.Update(delegate(IFlightEndOfFramePreUpdate x)
			{
				x.FlightEndOfFramePreUpdate(in _frameData);
			}, "Scripts.FlightEndOfFramePreUpdate");
			UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.EndOfFrameUpdateCommon, delegate(IEndOfFrameUpdate x)
			{
				x.EndOfFrameUpdate(in _commonFrameData);
			}, _scripts.EndOfFrameUpdate, delegate(IFlightEndOfFrameUpdate x)
			{
				x.FlightEndOfFrameUpdate(in _frameData);
			}, "Scripts.EndOfFrameUpdate & Scripts.FlightEndOfFrameUpdate");
			_scripts.EndOfFramePostUpdate.Update(delegate(IFlightEndOfFramePostUpdate x)
			{
				x.FlightEndOfFramePostUpdate(in _frameData);
			}, "Scripts.FlightEndOfFramePostUpdate");
			EndUpdates(_groupsEndOfFrameUpdate);
		}

		protected override void FixedUpdate()
		{
			_flightSceneScript.OnFixedUpdate(in _frameData);
			if (!_frameData.IsPaused)
			{
				if (_frameData.IsWarping)
				{
					UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.FixedUpdateCommon, delegate(IFixedUpdate x)
					{
						x.FixedUpdate(in _commonFrameData);
					}, _scripts.FixedUpdateWarp, delegate(IFlightFixedUpdateWarp x)
					{
						x.FlightFixedUpdateWarp(in _frameData);
					}, "Scripts.FixedUpdate & Scripts.FlightFixedUpdateWarp");
					return;
				}
				_scripts.FixedUpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightFixedUpdateParallel x)
				{
					x.FlightFixedUpdateParallel(in _frameData);
				}, "Scripts.FlightFixedUpdateParallel");
				UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.FixedUpdateCommon, delegate(IFixedUpdate x)
				{
					x.FixedUpdate(in _commonFrameData);
				}, _scripts.FixedUpdate, delegate(IFlightFixedUpdate x)
				{
					x.FlightFixedUpdate(in _frameData);
				}, "Scripts.FixedUpdate & Scripts.FlightFixedUpdate");
			}
			else
			{
				_scripts.FixedUpdateCommon.Update(delegate(IFixedUpdate x)
				{
					x.FixedUpdate(in _commonFrameData);
				}, "Scripts.FixedUpdate");
			}
		}

		protected override void LateUpdate()
		{
			_flightSceneScript.OnLateUpdate(in _frameData);
			if (_frameData.IsPaused)
			{
				UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.LateUpdateCommon, delegate(ILateUpdate x)
				{
					x.LateUpdate(in _commonFrameData);
				}, _scripts.LateUpdatePaused, delegate(IFlightLateUpdatePaused x)
				{
					x.FlightLateUpdatePaused(in _frameData);
				}, "Scripts.LateUpdate & Scripts.FlightLateUpdatePaused");
				return;
			}
			_scripts.LateUpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightLateUpdateParallel x)
			{
				x.FlightLateUpdateParallel(in _frameData);
			}, "Scripts.FlightLateUpdateParallel");
			UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.LateUpdateCommon, delegate(ILateUpdate x)
			{
				x.LateUpdate(in _commonFrameData);
			}, _scripts.LateUpdate, delegate(IFlightLateUpdate x)
			{
				x.FlightLateUpdate(in _frameData);
			}, "Scripts.LateUpdate & Scripts.FlightLateUpdate");
		}

		protected override void PostFixedUpdate()
		{
			if (!_frameData.IsPaused && !_frameData.IsWarping)
			{
				_scripts.PostFixedUpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightPostFixedUpdateParallel x)
				{
					x.FlightPostFixedUpdateParallel(in _frameData);
				}, "Scripts.FlightPostFixedUpdateParallel");
				_scripts.PostFixedUpdate.Update(delegate(IFlightPostFixedUpdate x)
				{
					x.FlightPostFixedUpdate(in _frameData);
				}, "Scripts.FlightPostFixedUpdate");
			}
			EndUpdates(_groupsFixedUpdate);
		}

		protected override void PostLateUpdate()
		{
			if (!_frameData.IsPaused)
			{
				_scripts.PostLateUpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightPostLateUpdateParallel x)
				{
					x.FlightPostLateUpdateParallel(in _frameData);
				}, "Scripts.FlightPostLateUpdateParallel");
				_scripts.PostLateUpdate.Update(delegate(IFlightPostLateUpdate x)
				{
					x.FlightPostLateUpdate(in _frameData);
				}, "Scripts.FlightPostLateUpdate");
			}
			EndUpdates(_groupsLateUpdate);
		}

		protected override void PostUpdate()
		{
			if (!_frameData.IsPaused)
			{
				_scripts.PostUpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightPostUpdateParallel x)
				{
					x.FlightPostUpdateParallel(in _frameData);
				}, "Scripts.FlightPostUpdateParallel");
				_scripts.PostUpdate.Update(delegate(IFlightPostUpdate x)
				{
					x.FlightPostUpdate(in _frameData);
				}, "Scripts.FlightPostUpdate");
			}
			EndUpdates(_groupsUpdate);
		}

		protected override void PreFixedUpdate()
		{
			_timeManager.FixedUpdate(Time.deltaTime);
			BeginUpdates(_groupsFixedUpdate);
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.StartCommon, delegate(IStart x)
			{
				x.Start(in _commonFrameData);
			}, _scripts.Start, delegate(IFlightStart x)
			{
				x.FlightStart(in _frameData);
			}, "Scripts.Start & Scripts.FlightStart");
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.PostStartCommon, delegate(IPostStart x)
			{
				x.PostStart(in _commonFrameData);
			}, _scripts.PostStart, delegate(IFlightPostStart x)
			{
				x.FlightPostStart(in _frameData);
			}, "Scripts.PostStart & Scripts.FlightPostStart");
			if (!_frameData.IsPaused && !_frameData.IsWarping)
			{
				_scripts.PreFixedUpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightPreFixedUpdateParallel x)
				{
					x.FlightPreFixedUpdateParallel(in _frameData);
				}, "Scripts.FlightPreFixedUpdateParallel");
				_scripts.PreFixedUpdate.Update(delegate(IFlightPreFixedUpdate x)
				{
					x.FlightPreFixedUpdate(in _frameData);
				}, "Scripts.FlightPreFixedUpdate");
			}
		}

		protected override void PreLateUpdate()
		{
			BeginUpdates(_groupsLateUpdate);
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.StartCommon, delegate(IStart x)
			{
				x.Start(in _commonFrameData);
			}, _scripts.Start, delegate(IFlightStart x)
			{
				x.FlightStart(in _frameData);
			}, "Scripts.Start & Scripts.FlightStart");
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.PostStartCommon, delegate(IPostStart x)
			{
				x.PostStart(in _commonFrameData);
			}, _scripts.PostStart, delegate(IFlightPostStart x)
			{
				x.FlightPostStart(in _frameData);
			}, "Scripts.PostStart & Scripts.FlightPostStart");
			if (!_frameData.IsPaused)
			{
				_scripts.PreLateUpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightPreLateUpdateParallel x)
				{
					x.FlightPreLateUpdateParallel(in _frameData);
				}, "Scripts.FlightPreLateUpdateParallel");
				_scripts.PreLateUpdate.Update(delegate(IFlightPreLateUpdate x)
				{
					x.FlightPreLateUpdate(in _frameData);
				}, "Scripts.FlightPreLateUpdate");
			}
		}

		protected override void PreUpdate()
		{
			_timeManager.Update();
			BeginUpdates(_groupsUpdate);
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.StartCommon, delegate(IStart x)
			{
				x.Start(in _commonFrameData);
			}, _scripts.Start, delegate(IFlightStart x)
			{
				x.FlightStart(in _frameData);
			}, "Scripts.Start & Scripts.FlightStart");
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.PostStartCommon, delegate(IPostStart x)
			{
				x.PostStart(in _commonFrameData);
			}, _scripts.PostStart, delegate(IFlightPostStart x)
			{
				x.FlightPostStart(in _frameData);
			}, "Scripts.PostStart & Scripts.FlightPostStart");
			if (!_frameData.IsPaused)
			{
				_scripts.PreUpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightPreUpdateParallel x)
				{
					x.FlightPreUpdateParallel(in _frameData);
				}, "Scripts.FlightPreUpdateParallel");
				_scripts.PreUpdate.Update(delegate(IFlightPreUpdate x)
				{
					x.FlightPreUpdate(in _frameData);
				}, "Scripts.FlightPreUpdate");
			}
		}

		protected override void Start()
		{
			base.Start();
			_flightSceneScript = FlightSceneScript.Instance;
			_timeManager = (TimeManager)_flightSceneScript.TimeManager;
		}

		protected override void Update()
		{
			_flightSceneScript.OnUpdate(in _frameData);
			if (_frameData.IsPaused)
			{
				UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.UpdateCommon, delegate(IUpdate x)
				{
					x.Update(in _commonFrameData);
				}, _scripts.UpdatePaused, delegate(IFlightUpdatePaused x)
				{
					x.FlightUpdatePaused(in _frameData);
				}, "Scripts.Update & Scripts.FlightUpdatePaused");
				return;
			}
			_scripts.UpdateParallel.ParallelUpdateAndComplete(8, 2, delegate(IFlightUpdateParallel x)
			{
				x.FlightUpdateParallel(in _frameData);
			}, "Scripts.FlightUpdateParallel");
			UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.UpdateCommon, delegate(IUpdate x)
			{
				x.Update(in _commonFrameData);
			}, _scripts.Update, delegate(IFlightUpdate x)
			{
				x.FlightUpdate(in _frameData);
			}, "Scripts.Update & Scripts.FlightUpdate", this, null, delegate(FlightGameLoop loop, IUpdateGroup group, int order)
			{
				if (order == -4900 && group == loop._scripts.Update)
				{
					loop._scripts.BodyScripts.ParallelUpdateAndComplete(8, 2, delegate(BodyScript x)
					{
						x.UpdateHeatAndEffects(in _frameData);
					}, "BodyScripts.UpdateHeatAndEffects");
				}
			});
		}

		private void BeginUpdates(IUpdateGroup[] groups)
		{
			UpdateGroupDebugCallback debugCallback = GetDebugCallback();
			_commonFrameData = new FrameData(Game.Instance.SceneManager);
			_frameData = new FlightFrameData(Game.Instance.FlightScene);
			for (int i = 0; i < groups.Length; i++)
			{
				groups[i].BeginUpdate(debugCallback);
			}
		}

		private void EndUpdates(IUpdateGroup[] groups)
		{
			_commonFrameData = default(FrameData);
			_frameData = default(FlightFrameData);
			for (int i = 0; i < groups.Length; i++)
			{
				groups[i].EndUpdate();
			}
		}
	}
}
