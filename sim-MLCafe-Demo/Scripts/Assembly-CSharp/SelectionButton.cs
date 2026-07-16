using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SelectionButton : MonoBehaviour
{
	[SerializeField]
	private int id;

	[SerializeField]
	private TMP_Text labelName;

	public UnityEvent OnButtonClick;

	public UnityEvent<int> OnButtonClickWithId;

	public void Init(int _id, string _name)
	{
		id = _id;
		if (labelName != null)
		{
			labelName.text = _name;
		}
	}

	public void OnClick()
	{
		OnButtonClick.Invoke();
		OnButtonClickWithId.Invoke(id);
	}
}
