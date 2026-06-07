using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ControllerTooltip : MonoBehaviour
{
	[SerializeField]
	private TMP_Text tooltipText;

	[SerializeField]
	private GameObject tooltipBackground;

	private Transform headsetTransform;

	private Transform pipaTransform;

	private const float VERTICAL_OFFSET = 0.07f;

	private const float HORIZONTAL_OFFSET = -0.075f;

	private bool initialized;

	public void Initialize(Transform pipaTransform)
	{
		if (pipaTransform == null)
		{
			Debug.LogError("ControllerTooltip needs a valid pipa transform reference to display tooltips. Destroying self.");
			Object.Destroy(base.gameObject);
			return;
		}
		if (tooltipText == null)
		{
			Debug.LogError("ControllerTooltip needs a valid TextMeshPro reference to display tooltips. Destroying self.");
			Object.Destroy(base.gameObject);
			return;
		}
		this.pipaTransform = pipaTransform;
		headsetTransform = VRTK_DeviceFinder.HeadsetCamera().transform;
		base.transform.SetParent(VRTK_DeviceFinder.PlayAreaTransform());
		HideTooltip();
		initialized = true;
	}

	private void Start()
	{
		if (!initialized)
		{
			Debug.LogError("ControllerTooltip needs to be properly initialized before being used. Destroying self.");
			Object.Destroy(base.gameObject);
		}
	}

	public void ShowTooltip(string tooltip, bool showBackground)
	{
		if (!string.IsNullOrWhiteSpace(tooltip))
		{
			RecalculatePositionAndRotation();
			base.gameObject.SetActive(value: true);
			tooltipBackground.SetActive(showBackground);
			tooltipText.text = tooltip;
			LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)tooltipBackground.transform);
		}
	}

	public void HideTooltip()
	{
		tooltipText.text = string.Empty;
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		RecalculatePositionAndRotation();
	}

	private void RecalculatePositionAndRotation()
	{
		Vector3 vector = (pipaTransform.position - headsetTransform.position).normalized;
		Vector3 vector2 = vector * -0.075f;
		vector2.y = 0.07f;
		base.transform.position = pipaTransform.position + vector2;
		if (vector == Vector3.zero)
		{
			vector = headsetTransform.forward;
		}
		base.transform.rotation = Quaternion.LookRotation(vector, Vector3.up);
	}
}
