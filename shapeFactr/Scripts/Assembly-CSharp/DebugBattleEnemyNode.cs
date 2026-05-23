using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DebugBattleEnemyNode : MonoBehaviour
{
	[SerializeField]
	private Image background;

	[SerializeField]
	private TMP_Text nameText;

	[SerializeField]
	private Image mainIcon;

	[SerializeField]
	private GameObject stageGroup;

	[SerializeField]
	private TMP_Dropdown stageDrop;

	[SerializeField]
	private Slider levelSlider;

	[SerializeField]
	private TMP_InputField levelText;

	[SerializeField]
	private TMP_InputField frequency;

	[SerializeField]
	private TMP_InputField maxEmissionCount;

	[SerializeField]
	private TMP_InputField value;

	[SerializeField]
	private TMP_InputField span;

	[SerializeField]
	private TMP_InputField hp;

	[SerializeField]
	private TMP_InputField attack;

	[SerializeField]
	private TMP_InputField speed;

	[SerializeField]
	private TMP_InputField townAttack;

	[SerializeField]
	private TMP_InputField shield;

	[SerializeField]
	private TMP_Text error;

	private eEnemy _enemyIdCache;

	private eEnemyType _enemyTypeCache;

	private MstEnemyLevelEntities _buffData;

	private MstEnemyLevelEntities _editLevelData;

	private string errorText;

	private readonly Color disableColor;

	public bool IsValidData { get; private set; }

	public event UnityAction<eEnemy, MstEnemyLevelEntities> OnChangeAction
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Init(eEnemy enemy)
	{
	}

	public void UpdateWaveLevel(MstEnemyLevelEntities entity)
	{
	}

	public void SetLevelData(MstEnemyLevelEntities nowLevelData)
	{
	}

	public void OnChangeLevelValue()
	{
	}

	public void ApplyBuff(eEnemyBuff buff, float value, eEnemyType targetType)
	{
	}

	public void ResetBuff()
	{
	}

	public void OnChangeStageValue()
	{
	}

	private eStageDivision ConvertStageDivision(int value)
	{
		return default(eStageDivision);
	}

	public void ApplyData()
	{
	}

	public void OnQuickAdd()
	{
	}

	public void OnQuickDelete()
	{
	}

	private void SetData(MstEnemyLevelEntities entity)
	{
	}

	private void SetData()
	{
	}

	private void SetDivision(int newValue)
	{
	}

	private void SetLevel(int newValue)
	{
	}

	private void SetFrequency(double newValue)
	{
	}

	private void SetMaxEmission(int newValue)
	{
	}

	private void SetBaseValue(int newValue)
	{
	}

	private void SetSpanValue(double newValue)
	{
	}

	private void SetHpValue(int newValue)
	{
	}

	private void SetAttackValue(int newValue)
	{
	}

	private void SetSpeedValue(float newValue)
	{
	}

	private void SetTownAttackValue(int newValue)
	{
	}

	private void SetShieldValue(int newValue)
	{
	}

	public (bool, int) CheckFloatToInt(float newValue, int defaultValue, string errorText = "")
	{
		return default((bool, int));
	}

	public (bool, int) CheckStringToInt(string newValue, int defaultValue, string errorText = "")
	{
		return default((bool, int));
	}

	public (bool, float) CheckStringToFloat(string newValue, float defaultValue, string errorText = "")
	{
		return default((bool, float));
	}

	public (bool, double) CheckStringToDouble(string newValue, double defaultValue, string errorText = "")
	{
		return default((bool, double));
	}

	public void OnSelectLevel()
	{
	}

	public void OnChangeLevel()
	{
	}
}
