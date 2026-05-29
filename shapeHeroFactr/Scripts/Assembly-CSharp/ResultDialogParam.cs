using SaveData;
using UnityEngine;
using UnityEngine.Events;

public class ResultDialogParam : BaseDialogParam
{
	public bool isReference;

	public UnityAction callback;

	public InGameData inGameData;

	public Texture2D screenshot;

	public Texture2D screenshotLarge;

	public ResultDialogParam(bool isReference, InGameData inGameData = null, Texture2D screenshot = null, Texture2D screenshotLarge = null, UnityAction callback = null)
		: base(enableCloseButton: false, enableEscape: false)
	{
	}
}
