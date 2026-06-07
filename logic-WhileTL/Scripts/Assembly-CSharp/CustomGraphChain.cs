using UnityEngine;

public class CustomGraphChain : ActiveComponent
{
	private Vector3 defaultScale;

	private bool fake;

	private bool completed;

	private GameObject leftObj;

	private GameObject rightObj;

	public void SetEnds(GameObject inG, GameObject outG)
	{
		Draw(inG, outG);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, 0f);
	}

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		defaultScale = base.gameObject.transform.GetComponent<RectTransform>().localScale;
	}

	private void Draw(GameObject leftObj, GameObject rightObj)
	{
		this.leftObj = leftObj;
		this.rightObj = rightObj;
		Vector3 position = leftObj.transform.position;
		Vector3 position2 = rightObj.transform.position;
		base.transform.position = new Vector3((position2.x + position.x) / 2f, (position2.y + position.y) / 2f, 1f);
		base.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
		base.transform.Rotate(new Vector3(0f, 0f, -57.29578f * Mathf.Atan2(position2.x - position.x, position2.y - position.y)));
		position.z = 0f;
		position2.z = 0f;
		Vector3 localPosition = leftObj.transform.localPosition;
		Vector3 localPosition2 = rightObj.transform.localPosition;
		localPosition.z = 0f;
		localPosition2.z = 0f;
		float magnitude = (localPosition - localPosition2).magnitude;
		magnitude /= 100f;
		base.transform.localScale = new Vector3(1f, magnitude, 1f);
	}
}
