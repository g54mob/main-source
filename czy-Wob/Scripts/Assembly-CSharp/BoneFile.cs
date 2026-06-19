using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoneFile : MonoBehaviour
{
	public GameObject highlightObj;

	public TextMeshProUGUI fileName;

	public Color newFileTextColor;

	public CoreButtonUnityGUI buttonRef;

	public Image mainImage;

	private string associatedFile;

	private bool selected;

	private bool locked;

	private BonesLoader bonesRef;

	private SaveLoadManager saveRef;

	private void Awake()
	{
		highlightObj.SetActive(value: false);
		saveRef = ObjectRegistration.GetRegistrationScript().saveLoadManager;
	}

	private void OnDestroy()
	{
		Object.Destroy(buttonRef);
	}

	public void SetBonesRef(BonesLoader newRef)
	{
		bonesRef = newRef;
	}

	public void SetGraphic(Sprite s)
	{
		mainImage.sprite = s;
	}

	public void Lock()
	{
		if (!locked)
		{
			OnDeselect();
			locked = true;
			buttonRef.interactable = false;
		}
	}

	public void Unlock()
	{
		if (locked)
		{
			locked = false;
			buttonRef.interactable = true;
		}
	}

	public void OnSelect()
	{
		if (!locked && !selected)
		{
			selected = true;
			highlightObj.SetActive(value: true);
		}
	}

	public void OnDeselect()
	{
		if (!locked && selected)
		{
			selected = false;
			highlightObj.SetActive(value: false);
		}
	}

	public void SetAssociatedFile(string filePath)
	{
		associatedFile = filePath;
		string text = "";
		string playTime = "";
		string numberOfDogs = "";
		saveRef.GetFileInfoForSaveFile(associatedFile, ref text, ref numberOfDogs, ref playTime);
		fileName.text = text;
	}

	public void MarkNewFile()
	{
		fileName.text = ScriptLocalization.GUI.GUI_FILE_NEW;
		fileName.color = newFileTextColor;
	}

	public void OnClick()
	{
		if (!locked)
		{
			Lock();
			bonesRef.ShowFileInfo(associatedFile, mainImage.sprite);
		}
	}
}
