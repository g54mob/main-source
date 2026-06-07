using System;
using System.Xml.Linq;
using UnityEngine;

[Serializable]
public class LEOptionsModel
{
	private bool shouldSaveValuesOnDisk;

	private float saveOnDiskTimerCounter;

	public LevelEditorToolsModel.SnappingType SnappingType { get; set; }

	public float HandSnapStep { get; set; }

	public float MoveSnapStep { get; set; }

	public float RotationSnapStep { get; set; }

	public float ScaleSnapStep { get; set; }

	public bool IsGridVisible { get; set; }

	public bool IsSnappingOn { get; set; }

	public bool IsAutoFocusActivated { get; set; }

	public bool IsManualIndicatorVisible { get; set; }

	public Color[] ColorPresets { get; set; }

	public LEOptionsModel()
	{
		SnappingType = LevelEditorToolsModel.SnappingType.Surface;
		HandSnapStep = 0.5f;
		MoveSnapStep = 0.5f;
		RotationSnapStep = 15f;
		ScaleSnapStep = 0.5f;
		IsGridVisible = false;
		IsSnappingOn = true;
		IsAutoFocusActivated = true;
		IsManualIndicatorVisible = true;
		ColorPresets = new Color[11]
		{
			new Color(0.9245283f, 0.36196154f, 0.36196154f),
			new Color(0.28435388f, 0.8490566f, 0.28701752f),
			new Color(0.5372549f, 0.59607846f, 0.8745098f),
			new Color(0.96862745f, 0.9254902f, 0.23921569f),
			new Color(0.6784314f, 0.52156866f, 0.35686275f),
			new Color(32f / 51f, 32f / 51f, 32f / 51f),
			new Color(0.8509804f, 0.28627455f, 0.7945096f),
			new Color(0f, 0.7868185f, 1f),
			new Color(1f, 17f / 30f, 0f),
			new Color(0.47843137f, 39f / 85f, 0.5137255f),
			new Color(1f, 1f, 1f)
		};
	}

	public void SetUpdateAuxiliaryEvent(GameManager gameManager)
	{
		gameManager.UpdateAuxiliary += UpdateAuxiliary;
	}

	public void SaveValuesOnDisk()
	{
		shouldSaveValuesOnDisk = true;
		saveOnDiskTimerCounter = 0f;
	}

	private void UpdateAuxiliary()
	{
		if (shouldSaveValuesOnDisk)
		{
			saveOnDiskTimerCounter += Time.deltaTime;
			if (saveOnDiskTimerCounter >= 3f)
			{
				XDocument.Parse(this.XmlSerialize()).Save(PathNames.LEOptions);
				shouldSaveValuesOnDisk = false;
				Debug.Log("LE Options saved on disk!");
			}
		}
	}
}
