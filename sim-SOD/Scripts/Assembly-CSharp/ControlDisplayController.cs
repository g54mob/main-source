using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlDisplayController : MonoBehaviour
{
	public enum ControlPositioning
	{
		neutral = 0,
		up = 1,
		down = 2,
		left = 3,
		right = 4
	}

	[Header("Components")]
	public RectTransform rect;

	public TextMeshProUGUI controlText;

	public List<CanvasRenderer> renderers;

	public Image background;

	public SoundIndicatorController soundIndicator;

	public JuiceController juiceController;

	[Header("State")]
	public InteractablePreset.InteractionKey key;

	public InteractionController.InteractionSetting interactionSetting;

	public float fadeIn;

	public bool remove;

	public ControlPositioning positioning;

	public Vector2 desiredPosition;

	public Vector2 spawnPosition;

	public bool assignedSpawnPosition;

	public bool execute;

	public float executeProgress;

	[Header("Debug")]
	public string actionName;

	public bool UpdateDisplay(InteractablePreset.InteractionKey newKey, InteractionController.InteractionSetting newAction)
	{
		return false;
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void RefreshIcon()
	{
	}

	public void Remove()
	{
	}

	public void Execute()
	{
	}

	public bool SetControlText(InteractablePreset.InteractionKey key, string newText, bool useContext = false)
	{
		return false;
	}
}
