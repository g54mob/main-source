using UnityEngine;
using UnityEngine.UI;

public class ADABlockRow : MonoBehaviour
{
	public GameObject controlColumn;

	public Dropdown backgroundDropdown;

	public Image rowImage;

	public ADAMessage.ADABlock block;

	private bool _editMode;

	public bool editMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual void Start()
	{
	}

	public virtual void Refresh()
	{
	}

	public void OnSetBackground()
	{
	}

	private void RefreshBackground()
	{
	}

	public void OnUp()
	{
	}

	public void OnDown()
	{
	}

	public void OnDelete()
	{
	}
}
