using UnityEngine;
using UnityEngine.UI;

public class FakeChain : ActiveComponent
{
	[SceneBind("Hover")]
	public Image hover;

	private Vector3 defaultScale;

	public GameObject inGO;

	public GameObject outGO;

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		defaultScale = base.transform.localScale;
		Draw(inGO.GetComponent<RectTransform>().position, outGO.GetComponent<RectTransform>().position);
	}

	private void Draw(Vector3 left, Vector3 right)
	{
		base.transform.position = new Vector3((right.x + left.x) / 2f, (right.y + left.y) / 2f, 1f);
		base.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
		base.transform.Rotate(new Vector3(0f, 0f, -57.29578f * Mathf.Atan2(right.x - left.x, right.y - left.y)));
		left.z = 0f;
		right.z = 0f;
		float magnitude = (left - right).magnitude;
		magnitude /= 100f;
		base.transform.localScale = new Vector3(1f, defaultScale.y * magnitude / base.transform.lossyScale.y, 1f);
	}
}
