using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DebugBattleHeroNode : MonoBehaviour
{
	[SerializeField]
	private Image mainIcon;

	[SerializeField]
	private Slider levelSlider;

	[SerializeField]
	private TMP_InputField levelText;

	[SerializeField]
	private Slider valueSlider;

	[SerializeField]
	private TMP_InputField valueText;

	[SerializeField]
	private TMP_Text nowLevelText;

	[SerializeField]
	private TMP_Text nowOutputText;

	[SerializeField]
	private Button returnNowButton;

	private eLuggage _unitCache;

	private int? _nowLevelCache;

	private float? _nowOutputCache;

	private bool _isFix;

	private int _lastOpenWave;

	public event UnityAction OnChangeLevelAction
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

	public event UnityAction<eLuggage, double, int> OnChangeValueAction
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

	public void Init(eLuggage luggage)
	{
	}

	public void Open()
	{
	}

	private void SetNowLevelText(int? level)
	{
	}

	private void SetNowOutputText(float? output)
	{
	}

	public void OnChangeSlider()
	{
	}

	private void FetchNowData(eLuggage luggage)
	{
	}

	public void OnChangInput()
	{
	}

	public void OnSelectLevelInput()
	{
	}

	public void OnSelectValueInput()
	{
	}

	public void ResetData()
	{
	}

	public void FetchData()
	{
	}
}
