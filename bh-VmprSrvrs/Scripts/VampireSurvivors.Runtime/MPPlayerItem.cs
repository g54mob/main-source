using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;

public class MPPlayerItem : MonoBehaviour
{
	public enum PlayerState
	{
		INACTIVE = 0,
		CONNECTED = 1,
		WAITING = 2,
		SELECTING = 3,
		FINISHED = 4,
		LOCKED = 5
	}

	[SerializeField]
	private GameObject _CharacterSelectedGroup;

	[SerializeField]
	private GameObject _AwaitingPlayerGroup;

	[SerializeField]
	private GameObject _AwaitingSelectionGroup;

	[SerializeField]
	private GameObject _AwaitingTurnGroup;

	[SerializeField]
	private GameObject _AwaitingConnect;

	[SerializeField]
	private TextMeshProUGUI _AwaitingConnectText;

	[SerializeField]
	private Image _Frame;

	[SerializeField]
	private Image _OuterFrame;

	[SerializeField]
	private TextMeshProUGUI _CharacterName;

	[SerializeField]
	private TextMeshProUGUI _PlayerName;

	[SerializeField]
	private Image _CharacterIcon;

	[SerializeField]
	private Image _WeaponIcon;

	[SerializeField]
	private Image _WeaponShadow;

	[SerializeField]
	private Image _aiIcon;

	public PlayerState _PlayerState;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private CharacterType _type;

	private CharacterData _data;

	private int _index;

	public Player PotentialPlayer => null;

	public Player Player => null;

	public AIType AITypeValue => default(AIType);

	public bool HasAI => false;

	public CharacterType Type => default(CharacterType);

	public void Initialize(DataManager dataManager, PlayerOptions playerOptions)
	{
	}

	private void Awake()
	{
	}

	public void SetCharacterType(CharacterType characterType)
	{
	}

	private void Update()
	{
	}

	public void SetData()
	{
	}

	private void SetWeaponIconSprite(CharacterData characterData, Skin skinData)
	{
	}

	public void GoToInactive()
	{
	}

	public void SetPartymodeText()
	{
	}

	public void GoToConnected()
	{
	}

	public void LockSelection()
	{
	}

	public void UnlockSelected()
	{
	}

	public void SetPlayerName(int index)
	{
	}

	public void GoToWaiting()
	{
	}

	public void SetIndex(int index)
	{
	}

	private void SetColor(float saturation = 1f)
	{
	}

	public void GoToSelecting()
	{
	}

	public void GoToFinished()
	{
	}

	public void UpdateAIIcon()
	{
	}

	public void RefreshData()
	{
	}
}
