using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugMapConnection : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private RectTransform _vector;

	[SerializeField]
	private TextMeshProUGUI _tierText;

	[SerializeField]
	private TextMeshProUGUI _distanceText;

	public void Initialize(TileGeneratorConnection connection)
	{
		Image component = _vector.GetComponent<Image>();
		Vector2 vector = connection.To.Position - connection.From.Position;
		float magnitude = vector.magnitude;
		float z = Vector2.SignedAngle(Vector2.up, vector);
		_vector.localPosition = connection.From.Position + vector * 0.5f;
		_vector.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, magnitude);
		_vector.rotation = Quaternion.Euler(0f, 0f, z);
		_tierText.text = connection.Tier.ToString();
		_distanceText.text = Mathf.FloorToInt(magnitude).ToString();
		if (connection.Tier == 0)
		{
			component.color = Color.red;
		}
		UGUILineHelper.DrawPolygon(connection.Polygon.Polygon2D, 4f, base.transform);
		base.gameObject.SetActive(value: true);
	}
}
