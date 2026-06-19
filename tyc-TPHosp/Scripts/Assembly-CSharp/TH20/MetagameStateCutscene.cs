using BehaviorDesigner.Runtime;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class MetagameStateCutscene : MetagameState
	{
		private readonly MetagameCutsceneInstance _cutscene;

		private GameObject _gameObject;

		private MetagameCutsceneBehaviorTree _behaviourTree;

		public MetagameStateCutscene(MetagameMap map, MetagameCutsceneInstance cutsceneInstance)
			: base(map)
		{
			_cutscene = cutsceneInstance;
		}

		public override void Enter()
		{
			_gameObject = new GameObject("MetagameCutscene");
			_behaviourTree = _gameObject.AddComponent<MetagameCutsceneBehaviorTree>();
			_behaviourTree.Metagame = Metagame;
			_behaviourTree.MetagameMap = MetagameMap;
			_behaviourTree.CutsceneCamera = MetagameMap.CameraLogic.CutsceneCamera;
			_behaviourTree.ExternalBehavior = _cutscene.CutsceneBehaviour;
			_behaviourTree.OnBehaviorEnd += delegate
			{
				OnFinished();
			};
			_behaviourTree.Start();
			_cutscene.OnCutsceneSequenceStart(_behaviourTree);
			ConsoleCommandsDatabase.RegisterSimpleCommand("SkipMetagameCutscene", "Skips the current cutscene", Skip);
		}

		public override void Update()
		{
			if (BehaviorManager.instance != null)
			{
				BehaviorManager.instance.Tick(_behaviourTree);
			}
			if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
			{
				Skip();
			}
		}

		public override void Exit()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("SkipMetagameCutscene");
			_cutscene.OnCutsceneSequenceEnd();
			Object.Destroy(_gameObject);
			_behaviourTree = null;
		}

		private void OnFinished()
		{
			PopState();
		}

		private void Skip()
		{
			if (_behaviourTree != null && _cutscene != null)
			{
				_behaviourTree.DisableBehavior();
				_cutscene.OnSkip();
			}
		}
	}
}
