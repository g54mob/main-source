using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomerCard : MonoBehaviour
{
	[SerializeField]
	private Image customerLogo;

	[SerializeField]
	private TextMeshProUGUI customerName;

	[SerializeField]
	private TextMeshProUGUI txtReputationRequirement;

	[SerializeField]
	private GameObject appTypesImage1;

	[SerializeField]
	private GameObject appTypesImage2;

	[SerializeField]
	private GameObject appTypesImage3;

	[SerializeField]
	private GameObject appTypesImage4;

	[SerializeField]
	private TextMeshProUGUI textAppRequirements1;

	[SerializeField]
	private TextMeshProUGUI textAppRequirements2;

	[SerializeField]
	private TextMeshProUGUI textAppRequirements3;

	[SerializeField]
	private TextMeshProUGUI textAppRequirements4;

	public void SetCustomer(CustomerItem _customerItem)
	{
	}
}
