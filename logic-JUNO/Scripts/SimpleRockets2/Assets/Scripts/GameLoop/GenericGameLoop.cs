using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.GameLoop
{
	public class GenericGameLoop : GameLoopBase, IGenericGameLoop, IGameLoop
	{
		private static FrameData _frameData;

		private IUpdateGroup[] _groupsEndOfFrameUpdate;

		private IUpdateGroup[] _groupsFixedUpdate;

		private IUpdateGroup[] _groupsLateUpdate;

		private IUpdateGroup[] _groupsUpdate;

		private GenericUpdateGroupCollection _scripts;

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
			_scripts = new GenericUpdateGroupCollection(this);
			_groupsFixedUpdate = new IUpdateGroup[3] { _scripts.Start, _scripts.PostStart, _scripts.FixedUpdate };
			_groupsUpdate = new IUpdateGroup[3] { _scripts.Start, _scripts.PostStart, _scripts.Update };
			_groupsLateUpdate = new IUpdateGroup[3] { _scripts.Start, _scripts.PostStart, _scripts.LateUpdate };
			_groupsEndOfFrameUpdate = new IUpdateGroup[3] { _scripts.Start, _scripts.PostStart, _scripts.EndOfFrameUpdate };
		}

		protected override void EndOfFrame()
		{
			BeginUpdates(_groupsEndOfFrameUpdate);
			_scripts.Start.Update(delegate(IStart x)
			{
				x.Start(in _frameData);
			}, "Scripts.Start");
			_scripts.PostStart.Update(delegate(IPostStart x)
			{
				x.PostStart(in _frameData);
			}, "Scripts.PostStart");
			_scripts.EndOfFrameUpdate.Update(delegate(IEndOfFrameUpdate x)
			{
				x.EndOfFrameUpdate(in _frameData);
			}, "Scripts.EndOfFrameUpdate");
			EndUpdates(_groupsEndOfFrameUpdate);
		}

		protected override void FixedUpdate()
		{
			_scripts.FixedUpdate.Update(delegate(IFixedUpdate x)
			{
				x.FixedUpdate(in _frameData);
			}, "Scripts.FixedUpdate");
		}

		protected override void LateUpdate()
		{
			_scripts.LateUpdate.Update(delegate(ILateUpdate x)
			{
				x.LateUpdate(in _frameData);
			}, "Scripts.LateUpdate");
		}

		protected override void PostFixedUpdate()
		{
			EndUpdates(_groupsFixedUpdate);
		}

		protected override void PostLateUpdate()
		{
			EndUpdates(_groupsLateUpdate);
		}

		protected override void PostUpdate()
		{
			EndUpdates(_groupsUpdate);
		}

		protected override void PreFixedUpdate()
		{
			BeginUpdates(_groupsFixedUpdate);
			_scripts.Start.Update(delegate(IStart x)
			{
				x.Start(in _frameData);
			}, "Scripts.Start");
			_scripts.PostStart.Update(delegate(IPostStart x)
			{
				x.PostStart(in _frameData);
			}, "Scripts.PostStart");
		}

		protected override void PreLateUpdate()
		{
			BeginUpdates(_groupsLateUpdate);
			_scripts.Start.Update(delegate(IStart x)
			{
				x.Start(in _frameData);
			}, "Scripts.Start");
			_scripts.PostStart.Update(delegate(IPostStart x)
			{
				x.PostStart(in _frameData);
			}, "Scripts.PostStart");
		}

		protected override void PreUpdate()
		{
			BeginUpdates(_groupsUpdate);
			_scripts.Start.Update(delegate(IStart x)
			{
				x.Start(in _frameData);
			}, "Scripts.Start");
			_scripts.PostStart.Update(delegate(IPostStart x)
			{
				x.PostStart(in _frameData);
			}, "Scripts.PostStart");
		}

		protected override void Update()
		{
			_scripts.Update.Update(delegate(IUpdate x)
			{
				x.Update(in _frameData);
			}, "Scripts.Update");
		}

		private void BeginUpdates(IUpdateGroup[] groups)
		{
			UpdateGroupDebugCallback debugCallback = GetDebugCallback();
			_frameData = new FrameData(Game.Instance.SceneManager);
			for (int i = 0; i < groups.Length; i++)
			{
				groups[i].BeginUpdate(debugCallback);
			}
		}

		private void EndUpdates(IUpdateGroup[] groups)
		{
			_frameData = default(FrameData);
			for (int i = 0; i < groups.Length; i++)
			{
				groups[i].EndUpdate();
			}
		}
	}
}
