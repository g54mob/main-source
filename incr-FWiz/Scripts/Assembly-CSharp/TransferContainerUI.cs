using OUSystems.Basics.UI;
using UnityEngine;

public class TransferContainerUI : MonoBehaviour
{
	public StorageStackUI StorageStackUI;

	public HoverListener HoverListener;

	public GameObject PipeUI;

	public GameObject ActivateOnHover;

	public ItemStack Stack { get; private set; }

	public void Set(ItemStack itemStack, int capacity)
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void ShowPipe()
	{
	}

	public void HidePipe()
	{
	}
}
