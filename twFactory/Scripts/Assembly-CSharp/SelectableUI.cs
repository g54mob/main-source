using UnityEngine;

public class SelectableUI : MonoBehaviour
{
	private ISelectable selectedObject;

	public virtual ISelectable SelectedObject
	{
		get
		{
			return selectedObject;
		}
		set
		{
			selectedObject = value;
		}
	}

	public virtual void Awake()
	{
	}

	public virtual void Start()
	{
	}
}
