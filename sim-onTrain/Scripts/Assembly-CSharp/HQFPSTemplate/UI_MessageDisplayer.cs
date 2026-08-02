using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HQFPSTemplate
{
	public class UI_MessageDisplayer : Singleton<UI_MessageDisplayer>
	{
		[SerializeField]
		private GameObject m_MessageTemplate;

		[SerializeField]
		private Color m_BaseMessageColor = Color.yellow;

		[SerializeField]
		private float m_FadeDelay = 3f;

		[SerializeField]
		private float m_FadeSpeed = 0.3f;

		public void PushMessage(string message, Color color = default(Color), int lineHeight = 16)
		{
			if (color == default(Color))
			{
				color = m_BaseMessageColor;
			}
			GameObject obj = Object.Instantiate(m_MessageTemplate, m_MessageTemplate.transform.parent, worldPositionStays: false);
			obj.SetActive(value: true);
			obj.transform.SetAsLastSibling();
			Text componentInChildren = obj.GetComponentInChildren<Text>();
			CanvasGroup component = obj.GetComponent<CanvasGroup>();
			if ((bool)componentInChildren && (bool)component)
			{
				componentInChildren.text = message.ToUpper();
				componentInChildren.color = new Color(color.r, color.g, color.b, 1f);
				componentInChildren.GetComponent<LayoutElement>().preferredHeight = lineHeight;
				component.alpha = color.a;
				StartCoroutine(FadeMessage(component));
			}
		}

		private void Start()
		{
			m_MessageTemplate.SetActive(value: false);
		}

		private IEnumerator FadeMessage(CanvasGroup group)
		{
			if ((bool)group)
			{
				yield return new WaitForSeconds(m_FadeDelay);
				while (group.alpha > Mathf.Epsilon)
				{
					group.alpha = Mathf.MoveTowards(group.alpha, 0f, Time.deltaTime * m_FadeSpeed);
					yield return null;
				}
				Object.Destroy(group.gameObject);
			}
		}
	}
}
