using UnityEngine;

public class DecorationSlot : SceneBehaviour
{
	[SerializeField]
	private SpriteRenderer _outlineRenderer;

	[SerializeField]
	private HierarchicalNodeMarker _hierarchicalNodeMarker;

	[SerializeField]
	private int _populatedPenalty = 1000000;

	[SerializeField]
	private bool _blocked;

	private Color _defaultOutlineColor;

	public DecorationProperties Decoration { get; private set; }

	public DecorationProperties Border { get; private set; }

	public int Visual { get; private set; }

	public Quaternion Rotation { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		if (_outlineRenderer != null)
		{
			_defaultOutlineColor = _outlineRenderer.color;
		}
	}

	public void Populate(DecorationProperties decorationProperties)
	{
		if (decorationProperties.DecorationType == DecorationType.Border)
		{
			Border = decorationProperties;
		}
		else
		{
			Decoration = decorationProperties;
		}
		if (_outlineRenderer != null)
		{
			_outlineRenderer.enabled = false;
		}
		UpdatePenalty();
	}

	public void Clear(DecorationProperties decorationProperties)
	{
		if (decorationProperties.DecorationType == DecorationType.Border)
		{
			Border = null;
		}
		else
		{
			Decoration = null;
		}
		UpdatePenalty();
	}

	public void SetOutlineActive(bool value)
	{
		if (_outlineRenderer != null)
		{
			_outlineRenderer.gameObject.SetActive(value);
			_outlineRenderer.enabled = value;
		}
	}

	public void SetOutlineActive(bool value, Color color)
	{
		if (_outlineRenderer != null)
		{
			_outlineRenderer.color = color;
			_outlineRenderer.gameObject.SetActive(value);
			_outlineRenderer.enabled = value;
		}
	}

	public void EnablePlacementOutline(DecorationProperties decorationProperties)
	{
		if (_outlineRenderer != null)
		{
			_outlineRenderer.gameObject.SetActive(value: true);
			_outlineRenderer.enabled = IsAvailable(decorationProperties);
		}
	}

	public void SetOutlineColor(Color color)
	{
		if (_outlineRenderer != null)
		{
			_outlineRenderer.color = color;
		}
	}

	public void ResetOutlineColor()
	{
		if (_outlineRenderer != null)
		{
			_outlineRenderer.color = _defaultOutlineColor;
		}
	}

	private void UpdatePenalty()
	{
		if (!(_hierarchicalNodeMarker == null))
		{
			if (Border == null && Decoration == null)
			{
				_hierarchicalNodeMarker.ClearPenalty();
			}
			else
			{
				_hierarchicalNodeMarker.SetPenalty(Mathf.Max(ReturnDecorationPropertiesPenalty(Border), ReturnDecorationPropertiesPenalty(Decoration)));
			}
		}
	}

	private int ReturnDecorationPropertiesPenalty(DecorationProperties decorationProperties)
	{
		if (decorationProperties == null)
		{
			return 0;
		}
		if (decorationProperties.OverrideHierarchicalNodePanelty)
		{
			return decorationProperties.HierarchicalNodePanelty;
		}
		return _populatedPenalty;
	}

	public bool IsAvailable(DecorationProperties decorationProperties)
	{
		if (!_blocked)
		{
			if (decorationProperties.DecorationType != DecorationType.Border)
			{
				return Decoration == null;
			}
			return Border == null;
		}
		return false;
	}
}
