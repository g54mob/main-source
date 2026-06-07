using UnityEngine;
using UnityEngine.UI;

public class FabPane : MonoBehaviour
{
	public GameObject rowPrefab;

	public GameObject storageItemControlPrefab;

	public GameObject rowContainer;

	public GameObject storageContainer;

	public RawImage wareImage;

	public Text wareText;

	private Fab fab;

	private int lastProducedWareCount;

	private int[] storedWareCounts;

	public void SetFab(Fab fab)
	{
	}

	public Fab GetFab()
	{
		return null;
	}

	private void Update()
	{
	}

	private void RefreshStorage()
	{
	}

	public void OnRowSelected(FabProductionRow row)
	{
	}

	private void SetWareImage(int num, RawImage image)
	{
	}

	public void DestroyRows()
	{
	}
}
