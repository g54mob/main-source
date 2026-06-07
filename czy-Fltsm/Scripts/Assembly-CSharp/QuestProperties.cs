using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Narrative/Quest", order = 2)]
public class QuestProperties : PersistentProperties
{
	[SerializeField]
	private QuestType _type;

	[SerializeField]
	[Tooltip("Main dialogue used while the quest is active")]
	private DialogueTreeProperties _dialogueTree;

	[SerializeField]
	private LocalizedString _questTitle = null;

	[SerializeField]
	private LocalizedString _questDescription = null;

	[SerializeField]
	private Sprite _indexIcon;

	[SerializeField]
	private Sprite _pageIcon;

	[SerializeField]
	private bool _showQuestCompletePanel = true;

	[SerializeReference]
	[SubclassSelector]
	private QuestVariableBase[] _variables;

	[SerializeField]
	private QuestObjectives _objectives = new QuestObjectives();

	[Tooltip("Is this quest hidden and thus not shown in the objectives UI")]
	[SerializeField]
	private bool _isHidden;

	[SerializeField]
	private bool _isRestartable;

	public QuestType QuestType => _type;

	public DialogueTreeProperties DialogueProperties => _dialogueTree;

	public DialogueTreeProperties EndDialogueProperties => null;

	public LocalizedString QuestTitle => _questTitle;

	public LocalizedString QuestDescription => _questDescription;

	public Sprite IndexIcon => _indexIcon;

	public Sprite PageIcon => _pageIcon;

	public bool ShowQuestCompletePanel => _showQuestCompletePanel;

	public QuestVariableBase[] Variables => _variables;

	public QuestObjectives Objectives => _objectives;

	public bool IsHidden => _isHidden;

	public bool IsRestartable => _isRestartable;

	public override Types Type => Types.QuestProperties;

	public bool AreVariableConditionsMet()
	{
		QuestVariableBase[] variables = Variables;
		for (int i = 0; i < variables.Length; i++)
		{
			if (!variables[i].ConditionsAreMet(this))
			{
				return false;
			}
		}
		return true;
	}
}
