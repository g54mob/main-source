using AssembleSystem.FSM.Plane;
using UnityEngine;
using Zenject;

namespace Services.Save.Plane
{
	public class ScenePlaneSaveHandler : MonoBehaviour
	{
		[SerializeField]
		private PlaneStateMachine _planeFSM;

		[SerializeField]
		private AirplaneController _airplaneController;

		[Inject]
		private PlaneSaveRegistry _registry;

		public string SaveKey => "Plane";

		public int Priority => 30;

		private void Awake()
		{
			_registry.OnSaveStarted += OnSave;
			_registry.OnLoadCompleted += OnLoad;
		}

		private void OnDestroy()
		{
			_registry.OnSaveStarted -= OnSave;
			_registry.OnLoadCompleted -= OnLoad;
		}

		public void OnSave()
		{
			_registry.Save(PlaneSaveHelper.BuildSaveData(_planeFSM, _airplaneController));
		}

		public void OnLoad()
		{
			if (_registry.TryGet(out var data))
			{
				PlaneSaveHelper.ApplySaveData(_planeFSM, _airplaneController, data);
			}
		}
	}
}
