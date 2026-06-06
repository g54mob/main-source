using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildableOverviewListItem : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private ChildBehaviourCache<Image> _malfunctionsIconCache;

	[Header("Animation")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	[ConditionalHide("_animator", true)]
	private string _currentParameter = "Current";

	private UnityAction<BuildableOverviewListItem> _selectCallback;

	public Buildable Buildable { get; private set; }

	public Selectable Selectable { get; private set; }

	private void Awake()
	{
		Selectable = GetComponent<Selectable>();
	}

	public void Initialize(Buildable buildable, bool current, UnityAction<BuildableOverviewListItem> selectCallback)
	{
		Buildable = buildable;
		_selectCallback = selectCallback;
		_icon.overrideSprite = buildable.Properties.Icon;
		_label.text = buildable.Name;
		using ListPool<PlaceableAlertProperties>.List list = ListPool<PlaceableAlertProperties>.Get();
		buildable.PopulateMalfunctions(list);
		_malfunctionsIconCache.Reset();
		foreach (PlaceableAlertProperties item in list)
		{
			_malfunctionsIconCache.Get(active: true).overrideSprite = item.UIIconProperties.Sprite;
		}
		_malfunctionsIconCache.Trim();
		if ((bool)_animator)
		{
			_animator.SetBool(_currentParameter, current);
		}
	}

	public void Select()
	{
		_selectCallback?.Invoke(this);
	}
}
