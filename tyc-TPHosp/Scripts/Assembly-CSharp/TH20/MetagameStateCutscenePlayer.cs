using System.Collections.Generic;
using System.Linq;

namespace TH20
{
	public class MetagameStateCutscenePlayer : MetagameState
	{
		private List<MetagameCutsceneInstance> _cutsceneList = new List<MetagameCutsceneInstance>();

		private bool _needToPlayCutscene;

		private bool _resettingCamera;

		public MetagameStateCutscenePlayer(MetagameMap map)
			: base(map)
		{
		}

		public override void Enter()
		{
			_resettingCamera = false;
			Metagame.CutsceneEvents.CheckForPendingCutsceneEvents();
			Metagame.CutsceneEvents.FlushCutsceneEvents(ref _cutsceneList);
			_needToPlayCutscene = _cutsceneList.Count > 0;
			if (!_needToPlayCutscene)
			{
				return;
			}
			MetagameMap.CameraLogic.CutsceneCamera.CacheCurrentTransform();
			MetagameMap.CameraLogic.CutsceneCamera.EnableCutsceneCamera(enable: true);
			MetagameMap.MapUI.CinematicBarsMenu.Show();
			foreach (MetagameCutsceneInstance cutscene in _cutsceneList)
			{
				cutscene.OnCutsceneStart();
			}
		}

		public override void Update()
		{
			if (_resettingCamera)
			{
				if (!MetagameMap.CameraLogic.CutsceneCamera.HasActiveCutsceneLogic)
				{
					PopState();
				}
				return;
			}
			if (_cutsceneList.Count <= 0)
			{
				if (_needToPlayCutscene)
				{
					MetagameMap.CameraLogic.CutsceneCamera.SetModeResetToCachedCamera(600f);
					_resettingCamera = true;
				}
				else
				{
					PopState();
				}
				return;
			}
			MetagameCutsceneInstance metagameCutsceneInstance = _cutsceneList.First();
			if (metagameCutsceneInstance != null)
			{
				_cutsceneList.Remove(metagameCutsceneInstance);
				PushState(new MetagameStateCutscene(MetagameMap, metagameCutsceneInstance));
			}
		}

		public override void Exit()
		{
			if (_needToPlayCutscene)
			{
				MetagameMap.MapUI.CinematicBarsMenu.Hide();
				MetagameMap.CameraLogic.CutsceneCamera.EnableCutsceneCamera(enable: false);
			}
		}
	}
}
