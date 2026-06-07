using UnityEngine;
using UnityEngine.UI;

public class BuildingHUD : MonoBehaviour
{
	public static BuildingHUD Instance;

	public Image XImg;

	public Image YImg;

	public Image RotImg;

	public Image Extra1Img;

	public Image Extra2Img;

	public Text XText;

	public Text YText;

	public Text RotText;

	public Text Extra1Text;

	public Text Extra2Text;

	public Color DefaultColor;

	private void Start()
	{
		Instance = this;
	}

	public void Enable(bool enable1, bool enable2, bool enable3)
	{
		XImg.gameObject.SetActive(enable1);
		YImg.gameObject.SetActive(enable2);
		RotImg.gameObject.SetActive(enable3);
		Extra1Img.gameObject.SetActive(false);
		Extra2Img.gameObject.SetActive(false);
	}

	public void SetDimension(Vector3 p1, Vector3 p2, bool first = true)
	{
		SetDimension(p1, p2, DefaultColor, first);
	}

	public void SetDimension(Vector3 p1, Vector3 p2, Color c, bool first = true)
	{
		Image image = (first ? XImg : YImg);
		Text text = (first ? XText : YText);
		SetArrow(image, text, p1, p2);
		if (first)
		{
			Vector2 vector = (Quaternion.Euler(0f, BuildController.Instance.GetGridRotation(), 0f) * Vector3.left).FlattenVector3();
			Vector2 vector2 = p1.FlattenVector3();
			Vector2 vector3 = p2.FlattenVector3();
			Vector2 vector4 = Utilities.ProjectToLineEndless(vector2, vector3, vector3 + vector);
			if (vector4.MaxDist(vector2) > 0.0001f && vector4.MaxDist(vector3) > 0.0001f)
			{
				SetArrow(Extra1Img, Extra1Text, p1, vector4.ToVector3(p1.y));
				SetArrow(Extra2Img, Extra2Text, p2, vector4.ToVector3(p1.y));
				Extra1Img.gameObject.SetActive(true);
				Extra2Img.gameObject.SetActive(true);
			}
			else
			{
				Extra1Img.gameObject.SetActive(false);
				Extra2Img.gameObject.SetActive(false);
			}
		}
		else
		{
			Extra1Img.gameObject.SetActive(false);
		}
		image.color = c;
	}

	private void SetArrow(Image img, Text text, Vector3 p1, Vector3 p2)
	{
		Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(p1) / Options.UISize;
		Vector3 vector2 = CameraScript.Instance.SSAScript.WorldToScreenPoint(p2) / Options.UISize;
		float a = new Vector2(Screen.width, Screen.height).magnitude + 128f;
		Vector3 vector3 = (vector + vector2) * 0.5f;
		img.rectTransform.anchoredPosition = new Vector2(vector3.x - (float)Screen.width / Options.UISize / 2f, vector3.y - (float)Screen.height / Options.UISize / 2f);
		img.rectTransform.sizeDelta = new Vector2(Mathf.Min(a, (vector - vector2).magnitude), img.rectTransform.sizeDelta.y);
		float num = Mathf.Atan2(vector2.y - vector.y, vector2.x - vector.x) * 57.29578f;
		num += (float)((num < -90f) ? 180 : 0);
		num -= (float)((num > 90f) ? 180 : 0);
		img.rectTransform.rotation = Quaternion.Euler(0f, 0f, num);
		text.text = (p1 - p2).magnitude.ToString("F1");
	}

	public void SetRot(Vector3 p1, Vector3 p2, Vector3 p3)
	{
		SetRot(p1, p2, p3, DefaultColor);
	}

	public void SetRot(Vector3 p1, Vector3 p2, Vector3 p3, Color c)
	{
		Vector2 a = new Vector2(p1.x, p1.z);
		Vector2 b = new Vector2(p2.x, p2.z);
		Vector2 c2 = new Vector2(p3.x, p3.z);
		Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(p1) / Options.UISize;
		Vector3 vector2 = CameraScript.Instance.SSAScript.WorldToScreenPoint(p2) / Options.UISize;
		Vector3 vector3 = CameraScript.Instance.SSAScript.WorldToScreenPoint(p3) / Options.UISize;
		float num = b.AngleBetween(a, c2);
		RotImg.rectTransform.anchoredPosition = new Vector2(vector2.x, 0f - ((float)Screen.height / Options.UISize - vector2.y));
		RotImg.color = c;
		float num2 = Mathf.Atan2(vector.y - vector2.y, vector.x - vector2.x) * 57.29578f + 90f;
		float num3 = Mathf.Atan2(vector3.y - vector2.y, vector3.x - vector2.x) * 57.29578f + 90f;
		float num4 = Mathf.DeltaAngle(num2, num3) / 360f;
		if (num4 < 0f)
		{
			num4 = Mathf.Abs(num4);
			RotImg.rectTransform.rotation = Quaternion.Euler(0f, 0f, num2);
			RotImg.fillAmount = num4;
			RotText.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f - num2);
		}
		else
		{
			RotImg.rectTransform.rotation = Quaternion.Euler(0f, 0f, num3);
			RotImg.fillAmount = num4;
			RotText.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f - num3);
		}
		RotText.text = num.ToString("F1") + "°";
	}

	public void SetDimension(Rect rect)
	{
		rect = new Rect(rect.x, rect.y, rect.width + 1f, rect.height + 1f);
		Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(new Vector3(rect.xMin, GameSettings.Instance.ActiveFloor * 2, rect.yMin)) / Options.UISize;
		Vector3 vector2 = CameraScript.Instance.SSAScript.WorldToScreenPoint(new Vector3(rect.xMin, GameSettings.Instance.ActiveFloor * 2, rect.yMax)) / Options.UISize;
		Vector3 vector3 = CameraScript.Instance.SSAScript.WorldToScreenPoint(new Vector3(rect.xMax, GameSettings.Instance.ActiveFloor * 2, rect.yMin)) / Options.UISize;
		XImg.color = DefaultColor;
		YImg.color = DefaultColor;
		Vector3 vector4 = (vector + vector2) * 0.5f;
		XImg.rectTransform.anchoredPosition = new Vector2(vector4.x - (float)Screen.width / Options.UISize / 2f, vector4.y - (float)Screen.height / Options.UISize / 2f);
		XImg.rectTransform.sizeDelta = new Vector2((vector - vector2).magnitude, XImg.rectTransform.sizeDelta.y);
		float num = Mathf.Atan2(vector2.y - vector.y, vector2.x - vector.x) * 57.29578f;
		num += (float)((num < -90f) ? 180 : 0);
		num -= (float)((num > 90f) ? 180 : 0);
		XImg.rectTransform.rotation = Quaternion.Euler(0f, 0f, num);
		XText.text = rect.height.ToString();
		vector4 = (vector + vector3) * 0.5f;
		YImg.rectTransform.anchoredPosition = new Vector2(vector4.x - (float)Screen.width / Options.UISize / 2f, vector4.y - (float)Screen.height / Options.UISize / 2f);
		YImg.rectTransform.sizeDelta = new Vector2((vector - vector3).magnitude, YImg.rectTransform.sizeDelta.y);
		num = Mathf.Atan2(vector3.y - vector.y, vector3.x - vector.x) * 57.29578f;
		num += (float)((num < -90f) ? 180 : 0);
		num -= (float)((num > 90f) ? 180 : 0);
		YImg.rectTransform.rotation = Quaternion.Euler(0f, 0f, num);
		YText.text = rect.width.ToString();
	}
}
