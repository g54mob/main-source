using System.Collections;
using ManagementScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UIScripts
{
	public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public string title;

		[Multiline]
		public string content;

		public bool active;

		[FormerlySerializedAs("UITooltip")]
		public bool isUITooltip = true;

		private bool hovering;

		public bool instant;

		private WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);

		private Coroutine waiting;

		public void Start()
		{
			base.enabled = !string.IsNullOrEmpty(title);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!string.IsNullOrEmpty(title))
			{
				hovering = true;
				if (instant)
				{
					Show();
				}
				else
				{
					waiting = StartCoroutine(WaitForDelay());
				}
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			hovering = false;
			if (waiting != null)
			{
				StopCoroutine(waiting);
			}
			HideTooltip();
		}

		private void OnMouseEnter()
		{
			if (isUITooltip || !EventSystem.current.IsPointerOverGameObject())
			{
				hovering = true;
				if (instant)
				{
					Show();
				}
				else
				{
					waiting = StartCoroutine(WaitForDelay());
				}
			}
		}

		private void OnMouseExit()
		{
			hovering = false;
			if (waiting != null)
			{
				StopCoroutine(waiting);
			}
			HideTooltip();
		}

		private IEnumerator WaitForDelay()
		{
			yield return wait;
			if (hovering && (isUITooltip || !EventSystem.current.IsPointerOverGameObject()))
			{
				Show();
			}
		}

		public void Show()
		{
			if (base.enabled)
			{
				TooltipSystem.Show(title, content);
				active = true;
			}
		}

		private void Update()
		{
			if (active && !isUITooltip && EventSystem.current.IsPointerOverGameObject())
			{
				HideTooltip();
			}
		}

		private void HideTooltip()
		{
			TooltipSystem.Hide();
			active = false;
		}

		public void UpdateText(string newTitle = null, string newContent = null)
		{
			if (newTitle != null)
			{
				title = newTitle;
			}
			if (newContent != null)
			{
				content = newContent;
			}
			base.enabled = !string.IsNullOrEmpty(title);
			if (active)
			{
				TooltipSystem.UpdateTooltip(title, content);
			}
		}

		private void OnDisable()
		{
			if (active)
			{
				HideTooltip();
			}
		}
	}
}
