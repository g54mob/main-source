using UnityEngine;
using UnityEngine.UI;

public class ThoughtBubble : MonoBehaviour
{
	public Text text;

	public float Show;

	public Transform trans;

	public RectTransform myself;

	public static ThoughtBubble Instance;

	private void Start()
	{
		if (Instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void SetThought(string thought, Transform obj)
	{
		text.text = thought;
		if (!string.IsNullOrEmpty(thought))
		{
			Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(obj.position + Vector3.up * 0.3f);
			if (!(vector.z < 0f))
			{
				myself.anchoredPosition = new Vector2(vector.x / Options.UISize, (0f - ((float)Screen.height - vector.y)) / Options.UISize);
				myself.sizeDelta = new Vector2(text.preferredWidth / 2f + 68f, text.preferredHeight + 83f);
				Show = 0.1f;
				trans = obj;
				base.gameObject.SetActive(true);
			}
		}
	}

	private void Update()
	{
		if (Show <= 0f || trans == null)
		{
			base.gameObject.SetActive(false);
			return;
		}
		Show -= Time.deltaTime;
		Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(trans.position + Vector3.up * 0.3f);
		if (vector.z < 0f)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			myself.anchoredPosition = new Vector2(vector.x / Options.UISize, (0f - ((float)Screen.height - vector.y)) / Options.UISize);
		}
	}
}
