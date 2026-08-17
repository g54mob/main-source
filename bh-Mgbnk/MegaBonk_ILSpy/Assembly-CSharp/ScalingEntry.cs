using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScalingEntry : MonoBehaviour
{
	public TextMeshProUGUI t_text;

	public RawImage parentSquare;

	public RawImage timeSquare;

	public RawImage stageSquare;

	public RawImage finalSwarmSquare;

	public void Set(string text, float timeM, float stageM, float finalM)
	{
		t_text.text = text;
		RectTransform rectTransform = parentSquare.rectTransform;
		Vector2 sizeDelta = rectTransform.sizeDelta;
		RectTransform rectTransform2 = timeSquare.rectTransform;
		RectTransform rectTransform3 = parentSquare.rectTransform;
		Vector2 sizeDelta2 = rectTransform3.sizeDelta;
		Vector2 vector = default(Vector2);
		rectTransform2.sizeDelta = vector;
		RectTransform rectTransform4 = timeSquare.rectTransform;
		Vector2 sizeDelta3 = rectTransform4.sizeDelta;
		RectTransform rectTransform5 = stageSquare.rectTransform;
		RectTransform rectTransform6 = parentSquare.rectTransform;
		Vector2 sizeDelta4 = rectTransform6.sizeDelta;
		rectTransform5.sizeDelta = vector;
		RectTransform rectTransform7 = stageSquare.rectTransform;
		RectTransform rectTransform8 = stageSquare.rectTransform;
		Vector2 anchoredPosition = rectTransform8.anchoredPosition;
		rectTransform7.anchoredPosition = vector;
		RectTransform rectTransform9 = stageSquare.rectTransform;
		Vector2 sizeDelta5 = rectTransform9.sizeDelta;
		RectTransform rectTransform10 = finalSwarmSquare.rectTransform;
		RectTransform rectTransform11 = parentSquare.rectTransform;
		Vector2 sizeDelta6 = rectTransform11.sizeDelta;
		rectTransform10.sizeDelta = vector;
		RectTransform rectTransform12 = finalSwarmSquare.rectTransform;
		RectTransform rectTransform13 = finalSwarmSquare.rectTransform;
		Vector2 anchoredPosition2 = rectTransform13.anchoredPosition;
		rectTransform12.anchoredPosition = vector;
	}
}
