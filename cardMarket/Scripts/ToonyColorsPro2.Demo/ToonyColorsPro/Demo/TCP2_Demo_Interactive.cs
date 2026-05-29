using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ToonyColorsPro.Demo
{
	public class TCP2_Demo_Interactive : MonoBehaviour
	{
		public TCP2_Demo_Camera demoCamera;

		public Camera camera;

		public Canvas canvas;

		public CanvasScaler canvasScaler;

		[Space]
		public HorizontalLayoutGroup layoutGroup;

		public ContentSizeFitter sizeFitter;

		[Space]
		public RectTransform textBox;

		public Text text;

		public Image line;

		[Space]
		public float camAnimDuration = 0.5f;

		public float maxCamAnimDuration = 1f;

		public bool camAnimBasedOnDistance;

		public float uiAnimDuration = 0.5f;

		[Space]
		public Button envButtonTemplate;

		private Button[] envButtons;

		public Text highlightLabel;

		private TCP2_Demo_Interactive_Content[] contents;

		private TCP2_Demo_Interactive_Content currentContent;

		private int index = -1;

		private TCP2_Demo_Interactive_Environment[] lightings;

		private int lightingIndex;

		private Color envButtonColor;

		private Vector3 cameraResetPos;

		private Quaternion cameraResetQuat;

		private Transform resetPivot;

		private bool coroutineActive;

		public GameObject infoBox;

		private void Awake()
		{
			contents = GetComponentsInChildren<TCP2_Demo_Interactive_Content>();
			lightings = GetComponentsInChildren<TCP2_Demo_Interactive_Environment>(includeInactive: true);
			if (QualitySettings.activeColorSpace == ColorSpace.Gamma)
			{
				TCP2_Demo_Interactive_Environment[] array = lightings;
				for (int i = 0; i < array.Length; i++)
				{
					Light[] componentsInChildren = array[i].GetComponentsInChildren<Light>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						componentsInChildren[j].intensity *= 0.6f;
					}
				}
				RenderSettings.ambientIntensity = 0.6f;
				RenderSettings.reflectionIntensity = 0.6f;
			}
			envButtonColor = envButtonTemplate.GetComponent<Image>().color;
			envButtons = new Button[lightings.Length];
			for (int k = 0; k < lightings.Length; k++)
			{
				GameObject obj = Object.Instantiate(envButtonTemplate.gameObject);
				obj.name = envButtonTemplate.name + "_" + k;
				obj.transform.SetParent(envButtonTemplate.transform.parent);
				obj.transform.SetSiblingIndex(envButtonTemplate.transform.GetSiblingIndex());
				obj.GetComponentInChildren<Text>().text = lightings[k].name;
				Button component = obj.GetComponent<Button>();
				int ci = k;
				component.onClick.AddListener(delegate
				{
					OnSelectLightingSettings(ci);
				});
				envButtons[k] = component;
			}
			envButtonTemplate.gameObject.SetActive(value: false);
			OnSelectLightingSettings(0);
			cameraResetPos = camera.transform.position;
			cameraResetQuat = camera.transform.rotation;
			resetPivot = demoCamera.Pivot;
		}

		private void LateUpdate()
		{
			HandleKeyboard();
			if (index >= 0 && !coroutineActive)
			{
				UpdateViewToCurrentContent();
			}
		}

		private void HandleKeyboard()
		{
			if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.H))
			{
				canvas.enabled = !canvas.enabled;
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ResetView();
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				NextHighlight();
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				PrevHighlight();
			}
			if (!Input.GetKeyDown(KeyCode.Tab))
			{
				return;
			}
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				lightingIndex--;
				if (lightingIndex < 0)
				{
					lightingIndex = envButtons.Length - 1;
				}
			}
			else
			{
				lightingIndex++;
				if (lightingIndex >= envButtons.Length)
				{
					lightingIndex = 0;
				}
			}
			OnSelectLightingSettings(lightingIndex);
		}

		public void PrevHighlight()
		{
			index--;
			if (index < 0)
			{
				index = contents.Length - 1;
			}
			StopAllCoroutines();
			StartCoroutine(CR_MoveToContent(contents[index]));
			highlightLabel.text = contents[index].name;
		}

		public void NextHighlight()
		{
			index++;
			if (index >= contents.Length)
			{
				index = 0;
			}
			StopAllCoroutines();
			StartCoroutine(CR_MoveToContent(contents[index]));
			highlightLabel.text = contents[index].name;
		}

		private void UpdateViewToCurrentContent(float lengthPercent = 1f)
		{
			Vector3 vector = camera.WorldToScreenPoint(currentContent.pivot.position);
			Vector3 vector2 = camera.WorldToScreenPoint(currentContent.textBox.position);
			textBox.position = vector2;
			float num = textBox.rect.width / 2f;
			float num2 = textBox.rect.height / 2f;
			if (vector2.x - num < 0f)
			{
				vector2.x = num;
			}
			if (vector2.x + num > (float)Screen.width)
			{
				vector2.x = (float)Screen.width - num;
			}
			if (vector2.y - num2 < 0f)
			{
				vector2.y = num2;
			}
			if (vector2.y + num2 > (float)Screen.height)
			{
				vector2.y = (float)Screen.height - num2;
			}
			textBox.position = vector2;
			PlaceLine(vector2, vector, lengthPercent);
		}

		private void PlaceLine(Vector2 start, Vector2 end, float lengthPercentage)
		{
			line.rectTransform.position = start;
			start.y = 0f - start.y;
			end.y = 0f - end.y;
			float z = Vector2.SignedAngle((start - end).normalized, Vector2.up);
			Vector3 localEulerAngles = line.rectTransform.localEulerAngles;
			localEulerAngles.z = z;
			line.rectTransform.localEulerAngles = localEulerAngles;
			float num = canvasScaler.referenceResolution.x / (float)Screen.width;
			float num2 = Vector2.Distance(start, end) * lengthPercentage;
			num2 *= num;
			Vector2 sizeDelta = line.rectTransform.sizeDelta;
			sizeDelta.y = num2;
			line.rectTransform.sizeDelta = sizeDelta;
		}

		private void ResetView()
		{
			canvas.enabled = false;
			StopAllCoroutines();
			StartCoroutine(CR_ResetCamPos());
			highlightLabel.text = "...";
		}

		private IEnumerator CR_ResetCamPos()
		{
			demoCamera.Pivot = resetPivot;
			demoCamera.pivotOffset = Vector3.zero;
			Vector3 startPos = camera.transform.position;
			Vector3 endPos = cameraResetPos;
			Quaternion startQuat = camera.transform.rotation;
			Quaternion endQuat = cameraResetQuat;
			float duration = (camAnimBasedOnDistance ? (Vector3.Distance(startPos, endPos) * camAnimDuration) : camAnimDuration);
			duration = Mathf.Min(duration, maxCamAnimDuration);
			float time = duration;
			while (time > 0f)
			{
				time -= Time.deltaTime;
				yield return null;
				float t = Mathf.SmoothStep(0f, 1f, 1f - Mathf.Clamp01(time / duration));
				camera.transform.position = Vector3.Lerp(startPos, endPos, t);
				camera.transform.rotation = Quaternion.Slerp(startQuat, endQuat, t);
			}
		}

		private IEnumerator CR_MoveToContent(TCP2_Demo_Interactive_Content content)
		{
			coroutineActive = true;
			canvas.enabled = false;
			Vector3 startPos = camera.transform.position;
			Vector3 endPos = content.transform.position;
			Quaternion startQuat = camera.transform.rotation;
			Quaternion endQuat = content.transform.rotation;
			float duration = (camAnimBasedOnDistance ? (Vector3.Distance(startPos, endPos) * camAnimDuration) : camAnimDuration);
			duration = Mathf.Min(duration, maxCamAnimDuration);
			float time = duration;
			while (time > 0f)
			{
				time -= Time.deltaTime;
				yield return null;
				float t = Mathf.SmoothStep(0f, 1f, 1f - Mathf.Clamp01(time / duration));
				camera.transform.position = Vector3.Lerp(startPos, endPos, t);
				camera.transform.rotation = Quaternion.Slerp(startQuat, endQuat, t);
			}
			currentContent = contents[index];
			camera.transform.position = currentContent.transform.position;
			camera.transform.rotation = currentContent.transform.rotation;
			demoCamera.Pivot = currentContent.pivot;
			demoCamera.pivotOffset = Vector3.zero;
			text.text = currentContent.Text;
			UpdateViewToCurrentContent(0f);
			yield return null;
			UpdateViewToCurrentContent(0f);
			yield return null;
			UpdateViewToCurrentContent(0f);
			layoutGroup.enabled = true;
			sizeFitter.enabled = true;
			yield return null;
			layoutGroup.enabled = false;
			sizeFitter.enabled = false;
			canvas.enabled = true;
			textBox.localScale = Vector3.zero;
			duration = uiAnimDuration;
			time = duration;
			while (time > 0f)
			{
				time -= Time.deltaTime;
				yield return null;
				float num = Mathf.SmoothStep(0f, 1f, 1f - Mathf.Clamp01(time / duration));
				textBox.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, num);
				line.rectTransform.localScale = new Vector3(1f / textBox.localScale.x, 1f / textBox.localScale.y, 1f);
				UpdateViewToCurrentContent(num);
			}
			coroutineActive = false;
		}

		private void OnSelectLightingSettings(int index)
		{
			lightingIndex = index;
			lightings[index].ApplyEnvironment();
			for (int i = 0; i < envButtons.Length; i++)
			{
				envButtons[i].GetComponent<Image>().color = ((i == index) ? new Color(0.6f, 0.2f, 0f) : envButtonColor);
			}
		}

		public void HideInfoBox()
		{
			infoBox.SetActive(value: false);
		}
	}
}
