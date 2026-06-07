using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactoryBuildButtonAmts : MonoBehaviour
{
	public RawImage blueImage;

	public RawImage redImage;

	public RawImage greenImage;

	public Text blueText;

	public Text redText;

	public Text greenText;

	public TextMeshProUGUI blueProductionText;

	public TextMeshProUGUI redProductionText;

	public TextMeshProUGUI greenProductionText;

	private int lastBlue;

	private int lastRed;

	private int lastGreen;

	private float lastBlueProduction;

	private float lastRedProduction;

	private float lastGreenProduction;

	private int[] storedWareCounts;

	public void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	private void RefreshInventoryTotals()
	{
	}

	private void SetWareImage(int num, RawImage image)
	{
	}
}
