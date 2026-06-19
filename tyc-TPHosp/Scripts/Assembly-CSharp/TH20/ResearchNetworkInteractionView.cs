using System;
using System.Collections.Generic;
using System.Text;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ResearchNetworkInteractionView : MonoBehaviour
	{
		[NonSerialized]
		public Action<CollaborativeNode> OnNodeSelected;

		[NonSerialized]
		public Action<CollaborativeNode> OnNodeDebugCompleted;

		[NonSerialized]
		public Action<CollaborativeNode> OnNodeDebugUncompleted;

		[SerializeField]
		private DynamicButton _debugButtonCompleted;

		[SerializeField]
		private DynamicButton _debugButtonUncompleted;

		[SerializeField]
		private TMP_Text _debugNodeIdText;

		[SerializeField]
		private GameObject _buttonGameObject;

		[SerializeField]
		private GameObject _completedStateGameObject;

		[SerializeField]
		private ButtonAnimator _button;

		[SerializeField]
		private TMP_Text _buttonText;

		[SerializeField]
		private Image _nodeIcon;

		[SerializeField]
		private GameObject _nodeIconVictoryMarker;

		[SerializeField]
		private TMP_Text _nodeTitleLabel;

		[SerializeField]
		private TMP_Text _nodeSubGoalTextLabel;

		[SerializeField]
		private GameObject _nodeVictoryObject;

		[SerializeField]
		private GameObject _nodeTimeLimitObject;

		[SerializeField]
		private TMP_Text _nodeTimeLimitLabel;

		[SerializeField]
		private TMP_Text _nodeRecommendedLevelLabel;

		[SerializeField]
		private TMP_Text _playerCompletedTextLabel;

		[SerializeField]
		private List<ResearchNetworkSteamAvatar> _avatars = new List<ResearchNetworkSteamAvatar>();

		private CollaborativeNode _node;

		private List<OnlinePlayerID> _completedPlayers = new List<OnlinePlayerID>();

		private List<OnlinePlayerID> _inProgressPlayers = new List<OnlinePlayerID>();

		private bool _isActive;

		private IResearchNetworkState _networkState;

		public CollaborativeNode SelectedNode => _node;

		private void Start()
		{
			if (_button != null)
			{
				_button.Button.onPrimaryDown.AddListener(OnButtonClicked);
			}
			if (_debugButtonCompleted != null)
			{
				_debugButtonCompleted.onPrimaryDown.AddListener(OnDebugCompletedClicked);
			}
			if (_debugButtonUncompleted != null)
			{
				_debugButtonUncompleted.onPrimaryDown.AddListener(OnDebugUncompletedClicked);
			}
			_nodeIcon.preserveAspect = true;
		}

		private void OnEnable()
		{
			Refresh();
		}

		private void OnDestroy()
		{
			if (_button != null)
			{
				_button.Button.onPrimaryDown.RemoveListener(OnButtonClicked);
			}
			if (_debugButtonCompleted != null)
			{
				_debugButtonCompleted.onPrimaryDown.RemoveListener(OnDebugCompletedClicked);
			}
			if (_debugButtonUncompleted != null)
			{
				_debugButtonUncompleted.onPrimaryDown.RemoveListener(OnDebugUncompletedClicked);
			}
		}

		public void Show([NotNull] CollaborativeNode node, IResearchNetworkState networkState, List<OnlinePlayerID> completedPlayers, List<OnlinePlayerID> inProgressPlayers, bool nodeIsActive)
		{
			if (node.Definition == null)
			{
				Hide();
				return;
			}
			_node = node;
			_networkState = networkState;
			_completedPlayers = completedPlayers;
			_inProgressPlayers = inProgressPlayers;
			_isActive = nodeIsActive;
			Refresh();
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
		}

		public void Hide()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}

		private void Refresh()
		{
			if (_node == null || _node.Definition == null)
			{
				Hide();
				return;
			}
			ResearchNodeDefinition definition = _node.Definition;
			if (definition == null || definition.Objective == null)
			{
				Hide();
				return;
			}
			int numNodeCompletions = _networkState.GetNumNodeCompletions(_node.NodeID);
			int numCompletionsRequired = _networkState.GetNumCompletionsRequired(_node.NodeID);
			bool flag = _networkState.IsNodeCompleted(_node.NodeID);
			bool flag2 = _networkState.IsNodeCompletedByLocalPlayer(_node.NodeID);
			_nodeIcon.overrideSprite = definition.Icon;
			_nodeTitleLabel.text = definition.Objective.NameLocalised.Translation;
			_nodeSubGoalTextLabel.text = ConstructStringForObjectiveSubGoals(definition.Objective);
			GameObjectUtils.SetActive(_nodeVictoryObject, _node.IsVictoryNode);
			GameObjectUtils.SetActive(_nodeIconVictoryMarker, _node.IsVictoryNode);
			GameObjectUtils.SetActive(_nodeTimeLimitObject, definition.Objective.IsTimed);
			if (definition.Objective.IsTimed)
			{
				string translation = LocalizationManager.GetTranslation("Collaborative/TimedObjective_TimeLimit_CS");
				_nodeTimeLimitLabel.text = translation.Replace("{[DAYS]}", definition.Objective.TimeLength.ToString());
			}
			if (_playerCompletedTextLabel != null)
			{
				string translation2 = LocalizationManager.GetTranslation("Collaborative/PlayersCompleted_Node_Select");
				_playerCompletedTextLabel.text = (flag ? ScriptLocalization.Collaborative_GUI.Completed_CS : string.Format(translation2, numNodeCompletions, numCompletionsRequired));
				_playerCompletedTextLabel.color = (flag ? Color.green : Color.white);
			}
			if (definition.Objective is SuperBugObjectiveDefinition)
			{
				SuperBugObjectiveDefinition superBugObjectiveDefinition = definition.Objective as SuperBugObjectiveDefinition;
				GameObjectUtils.SetActive(_nodeRecommendedLevelLabel.gameObject, isActive: true);
				_nodeRecommendedLevelLabel.text = ConstructStringForRecommendLevels(superBugObjectiveDefinition.RecommendedLevels);
			}
			else if (definition.RecommendedLevels != null && definition.RecommendedLevels.Length != 0)
			{
				GameObjectUtils.SetActive(_nodeRecommendedLevelLabel.gameObject, isActive: true);
				_nodeRecommendedLevelLabel.text = ConstructStringForRecommendLevels(definition.RecommendedLevels);
			}
			else
			{
				GameObjectUtils.SetActive(_nodeRecommendedLevelLabel.gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_buttonGameObject, !(flag2 || flag));
			GameObjectUtils.SetActive(_completedStateGameObject, flag2 || flag);
			if (_button != null)
			{
				_button.CurrentState = ((flag2 || flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				_buttonText.text = ((flag2 || flag) ? ScriptLocalization.Collaborative_GUI.Completed_CS : (_isActive ? ScriptLocalization.Collaborative_GUI.Abandon_CS : ScriptLocalization.Collaborative_GUI.Start_CS));
				_button.Button.image.color = ((flag2 || flag) ? new Color(1f, 1f, 1f, 0.4f) : Color.white);
			}
			if (_debugButtonCompleted != null)
			{
				_debugButtonCompleted.gameObject.SetActive(value: false);
			}
			if (_debugButtonUncompleted != null)
			{
				_debugButtonUncompleted.gameObject.SetActive(value: false);
			}
			if (_debugNodeIdText != null)
			{
				_debugNodeIdText.gameObject.SetActive(value: false);
			}
			int num = 0;
			if (_completedPlayers != null)
			{
				foreach (OnlinePlayerID completedPlayer in _completedPlayers)
				{
					if (num < _avatars.Count)
					{
						_avatars[num].Setup(completedPlayer, completed: true);
						GameObjectUtils.SetActive(_avatars[num].gameObject, isActive: true);
						num++;
					}
				}
			}
			if (_inProgressPlayers != null)
			{
				foreach (OnlinePlayerID inProgressPlayer in _inProgressPlayers)
				{
					if (num < _avatars.Count)
					{
						_avatars[num].Setup(inProgressPlayer, completed: false);
						GameObjectUtils.SetActive(_avatars[num].gameObject, isActive: true);
						num++;
					}
				}
			}
			for (int i = num; i < _avatars.Count; i++)
			{
				if (!(_avatars[i] == null))
				{
					GameObjectUtils.SetActive(_avatars[i].gameObject, isActive: false);
				}
			}
		}

		private void OnButtonClicked()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
			OnNodeSelected.InvokeSafe(_node);
		}

		private void OnDebugUncompletedClicked()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
			OnNodeDebugUncompleted.InvokeSafe(_node);
		}

		private void OnDebugCompletedClicked()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
			OnNodeDebugCompleted.InvokeSafe(_node);
		}

		private string ConstructStringForObjectiveSubGoals(ObjectiveDefinition definition)
		{
			if (definition == null)
			{
				return string.Empty;
			}
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder();
			for (int i = 0; i < definition.SubGoalDefinitions.Count; i++)
			{
				SubGoalDefinition subGoalDefinition = definition.SubGoalDefinitions[i];
				if (subGoalDefinition != null)
				{
					builder.Append(subGoalDefinition.GoalText(null));
					if (i < definition.SubGoalDefinitions.Count - 1)
					{
						builder.AppendLine();
					}
				}
			}
			string result = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return result;
		}

		private string ConstructStringForRecommendLevels(SharedInstance<LevelConfig>[] recommendedLevels)
		{
			if (recommendedLevels == null || recommendedLevels.Length == 0)
			{
				return string.Empty;
			}
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder();
			for (int i = 0; i < recommendedLevels.Length; i++)
			{
				SharedInstance<LevelConfig> sharedInstance = recommendedLevels[i];
				if (!(sharedInstance == null) && sharedInstance.Instance != null)
				{
					builder.Append(sharedInstance.Instance.DisplayNameLocalised.Translation);
					if (i < recommendedLevels.Length - 1)
					{
						builder.Append(", ");
					}
				}
			}
			string result = string.Format(ScriptLocalization.Collaborative_GUI.RecommendedLocation_CS, builder);
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return result;
		}
	}
}
