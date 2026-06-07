using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.GameLoop
{
	public class DesignerGameLoop : GameLoopBase, IDesignerGameLoop, IGameLoop
	{
		private static FrameData _commonFrameData;

		private static DesignerFrameData _frameData;

		private IUpdateGroup[] _groupsEndOfFrameUpdate;

		private IUpdateGroup[] _groupsFixedUpdate;

		private IUpdateGroup[] _groupsLateUpdate;

		private IUpdateGroup[] _groupsUpdate;

		private DesignerUpdateGroupCollection _scripts;

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
			_scripts = new DesignerUpdateGroupCollection(this);
			_groupsFixedUpdate = new IUpdateGroup[8] { _scripts.StartCommon, _scripts.Start, _scripts.PostStartCommon, _scripts.PostStart, _scripts.PreFixedUpdate, _scripts.FixedUpdateCommon, _scripts.FixedUpdate, _scripts.PostFixedUpdate };
			_groupsUpdate = new IUpdateGroup[8] { _scripts.StartCommon, _scripts.Start, _scripts.PostStartCommon, _scripts.PostStart, _scripts.PreUpdate, _scripts.UpdateCommon, _scripts.Update, _scripts.PostUpdate };
			_groupsLateUpdate = new IUpdateGroup[8] { _scripts.StartCommon, _scripts.Start, _scripts.PostStartCommon, _scripts.PostStart, _scripts.PreLateUpdate, _scripts.LateUpdateCommon, _scripts.LateUpdate, _scripts.PostLateUpdate };
			_groupsEndOfFrameUpdate = new IUpdateGroup[8] { _scripts.StartCommon, _scripts.Start, _scripts.PostStartCommon, _scripts.PostStart, _scripts.EndOfFramePreUpdate, _scripts.EndOfFrameUpdateCommon, _scripts.EndOfFrameUpdate, _scripts.EndOfFramePostUpdate };
		}

		protected override void EndOfFrame()
		{
			BeginUpdates(_groupsEndOfFrameUpdate);
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.StartCommon, delegate(IStart x)
			{
				x.Start(in _commonFrameData);
			}, _scripts.Start, delegate(IDesignerStart x)
			{
				x.DesignerStart(in _frameData);
			}, "Scripts.Start & Scripts.DesignerStart");
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.PostStartCommon, delegate(IPostStart x)
			{
				x.PostStart(in _commonFrameData);
			}, _scripts.PostStart, delegate(IDesignerPostStart x)
			{
				x.DesignerPostStart(in _frameData);
			}, "Scripts.PostStart & Scripts.DesignerPostStart");
			_scripts.EndOfFramePreUpdate.Update(delegate(IDesignerEndOfFramePreUpdate x)
			{
				x.DesignerEndOfFramePreUpdate(in _frameData);
			}, "Scripts.DesignerEndOfFramePreUpdate");
			UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.EndOfFrameUpdateCommon, delegate(IEndOfFrameUpdate x)
			{
				x.EndOfFrameUpdate(in _commonFrameData);
			}, _scripts.EndOfFrameUpdate, delegate(IDesignerEndOfFrameUpdate x)
			{
				x.DesignerEndOfFrameUpdate(in _frameData);
			}, "Scripts.EndOfFrameUpdate & Scripts.DesignerEndOfFrameUpdate");
			_scripts.EndOfFramePostUpdate.Update(delegate(IDesignerEndOfFramePostUpdate x)
			{
				x.DesignerEndOfFramePostUpdate(in _frameData);
			}, "Scripts.DesignerEndOfFramePostUpdate");
			EndUpdates(_groupsEndOfFrameUpdate);
		}

		protected override void FixedUpdate()
		{
			UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.FixedUpdateCommon, delegate(IFixedUpdate x)
			{
				x.FixedUpdate(in _commonFrameData);
			}, _scripts.FixedUpdate, delegate(IDesignerFixedUpdate x)
			{
				x.DesignerFixedUpdate(in _frameData);
			}, "Scripts.FixedUpdate & Scripts.DesignerFixedUpdate");
		}

		protected override void LateUpdate()
		{
			UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.LateUpdateCommon, delegate(ILateUpdate x)
			{
				x.LateUpdate(in _commonFrameData);
			}, _scripts.LateUpdate, delegate(IDesignerLateUpdate x)
			{
				x.DesignerLateUpdate(in _frameData);
			}, "Scripts.LateUpdate & Scripts.DesignerLateUpdate");
		}

		protected override void PostFixedUpdate()
		{
			_scripts.PostFixedUpdate.Update(delegate(IDesignerPostFixedUpdate x)
			{
				x.DesignerPostFixedUpdate(in _frameData);
			}, "Scripts.DesignerPostFixedUpdate");
			EndUpdates(_groupsFixedUpdate);
		}

		protected override void PostLateUpdate()
		{
			_scripts.PostLateUpdate.Update(delegate(IDesignerPostLateUpdate x)
			{
				x.DesignerPostLateUpdate(in _frameData);
			}, "Scripts.DesignerPostLateUpdate");
			EndUpdates(_groupsLateUpdate);
		}

		protected override void PostUpdate()
		{
			_scripts.PostUpdate.Update(delegate(IDesignerPostUpdate x)
			{
				x.DesignerPostUpdate(in _frameData);
			}, "Scripts.DesignerPostUpdate");
			EndUpdates(_groupsUpdate);
		}

		protected override void PreFixedUpdate()
		{
			BeginUpdates(_groupsFixedUpdate);
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.StartCommon, delegate(IStart x)
			{
				x.Start(in _commonFrameData);
			}, _scripts.Start, delegate(IDesignerStart x)
			{
				x.DesignerStart(in _frameData);
			}, "Scripts.Start & Scripts.DesignerStart");
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.PostStartCommon, delegate(IPostStart x)
			{
				x.PostStart(in _commonFrameData);
			}, _scripts.PostStart, delegate(IDesignerPostStart x)
			{
				x.DesignerPostStart(in _frameData);
			}, "Scripts.PostStart & Scripts.DesignerPostStart");
			_scripts.PreFixedUpdate.Update(delegate(IDesignerPreFixedUpdate x)
			{
				x.DesignerPreFixedUpdate(in _frameData);
			}, "Scripts.DesignerPreFixedUpdate");
		}

		protected override void PreLateUpdate()
		{
			BeginUpdates(_groupsLateUpdate);
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.StartCommon, delegate(IStart x)
			{
				x.Start(in _commonFrameData);
			}, _scripts.Start, delegate(IDesignerStart x)
			{
				x.DesignerStart(in _frameData);
			}, "Scripts.Start & Scripts.DesignerStart");
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.PostStartCommon, delegate(IPostStart x)
			{
				x.PostStart(in _commonFrameData);
			}, _scripts.PostStart, delegate(IDesignerPostStart x)
			{
				x.DesignerPostStart(in _frameData);
			}, "Scripts.PostStart & Scripts.DesignerPostStart");
			_scripts.PreLateUpdate.Update(delegate(IDesignerPreLateUpdate x)
			{
				x.DesignerPreLateUpdate(in _frameData);
			}, "Scripts.DesignerPreLateUpdate");
		}

		protected override void PreUpdate()
		{
			BeginUpdates(_groupsUpdate);
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.StartCommon, delegate(IStart x)
			{
				x.Start(in _commonFrameData);
			}, _scripts.Start, delegate(IDesignerStart x)
			{
				x.DesignerStart(in _frameData);
			}, "Scripts.Start & Scripts.DesignerStart");
			StartGroup<IGameLoopItem>.UpdateMultiple(_scripts.PostStartCommon, delegate(IPostStart x)
			{
				x.PostStart(in _commonFrameData);
			}, _scripts.PostStart, delegate(IDesignerPostStart x)
			{
				x.DesignerPostStart(in _frameData);
			}, "Scripts.PostStart & Scripts.DesignerPostStart");
			_scripts.PreUpdate.Update(delegate(IDesignerPreUpdate x)
			{
				x.DesignerPreUpdate(in _frameData);
			}, "Scripts.DesignerPreUpdate");
		}

		protected override void Update()
		{
			UpdateGroup<IGameLoopItem>.UpdateMultiple(_scripts.UpdateCommon, delegate(IUpdate x)
			{
				x.Update(in _commonFrameData);
			}, _scripts.Update, delegate(IDesignerUpdate x)
			{
				x.DesignerUpdate(in _frameData);
			}, "Scripts.Update & Scripts.DesignerUpdate");
		}

		private void BeginUpdates(IUpdateGroup[] groups)
		{
			UpdateGroupDebugCallback debugCallback = GetDebugCallback();
			_commonFrameData = new FrameData(Game.Instance.SceneManager);
			_frameData = new DesignerFrameData(Game.Instance.Designer);
			for (int i = 0; i < groups.Length; i++)
			{
				groups[i].BeginUpdate(debugCallback);
			}
		}

		private void EndUpdates(IUpdateGroup[] groups)
		{
			_commonFrameData = default(FrameData);
			_frameData = default(DesignerFrameData);
			for (int i = 0; i < groups.Length; i++)
			{
				groups[i].EndUpdate();
			}
		}
	}
}
