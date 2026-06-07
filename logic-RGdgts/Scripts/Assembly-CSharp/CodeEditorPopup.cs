using UnityEngine;

public abstract class CodeEditorPopup : MonoBehaviour
{
	public abstract bool OnLeft();

	public abstract bool OnRight();

	public abstract bool OnUp();

	public abstract bool OnDown();

	public abstract bool OnSubmit();

	public abstract bool OnTab();

	public abstract bool OnCancel();
}
