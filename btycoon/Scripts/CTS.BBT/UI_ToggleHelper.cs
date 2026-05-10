using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ToggleHelper : MonoBehaviour
{
	[Foldout("Dev")]
	[SerializeField]
	private TMP_Text _toggleNameDisplay;

	[Foldout("Dev")]
	[SerializeField]
	private Toggle _toggle;

	[Foldout("Dev")]
	[InfoBox("The ID should be exactly the name of the variable that's changed by this element. CASE SENSITIVE", EInfoBoxType.Error)]
	[SerializeField]
	private string _toggleID;

	[Foldout("Dev")]
	[SerializeField]
	private Image _backgroundImage;

	[Foldout("Dev")]
	[SerializeField]
	private Image _checkmarkImage;

	[BoxGroup("Background")]
	[SerializeField]
	private Color _backGroundColor;

	[BoxGroup("Background")]
	[ShowAssetPreview(64, 64)]
	[SerializeField]
	private Sprite _newBackgroundImage;

	[BoxGroup("Toggle")]
	[SerializeField]
	private Color _toggleColor;

	[BoxGroup("Toggle")]
	[ShowAssetPreview(64, 64)]
	[SerializeField]
	private Sprite _newToggleImage;

	[BoxGroup("Slider Values")]
	[SerializeField]
	private string _toggleName;

	private void Start()
	{
	}

	public void OnToggleActivated()
	{
	}
}
