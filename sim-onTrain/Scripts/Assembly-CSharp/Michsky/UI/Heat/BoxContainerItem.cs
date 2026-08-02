using System.Collections;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(CanvasGroup))]
	public class BoxContainerItem : MonoBehaviour
	{
		[HideInInspector]
		public BoxContainer container;

		private CanvasGroup cg;

		private void Awake()
		{
			cg = GetComponent<CanvasGroup>();
		}

		private void OnDisable()
		{
			if (container.playOnce && container.isPlayedOnce)
			{
				cg.alpha = 1f;
				base.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				cg.alpha = 0f;
				base.transform.localScale = new Vector3(0f, 0f, 0f);
			}
		}

		public void Process(float time)
		{
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine("ProcessBoxScale", time);
			}
		}

		private IEnumerator ProcessBoxScale(float time)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
			if (container.updateMode == BoxContainer.UpdateMode.DeltaTime)
			{
				yield return new WaitForSeconds(time);
			}
			else
			{
				yield return new WaitForSecondsRealtime(time);
			}
			float elapsedTime = 0f;
			float startingPoint = 0f;
			bool fadeStarted = false;
			while (elapsedTime < 1f)
			{
				float num = Mathf.Lerp(startingPoint, 1f, container.animationCurve.Evaluate(elapsedTime));
				base.transform.localScale = new Vector3(num, num, num);
				if (base.transform.localScale.x > container.fadeAfterScale && !fadeStarted)
				{
					fadeStarted = true;
					StartCoroutine("ProcessBoxFade");
				}
				elapsedTime = ((container.updateMode != BoxContainer.UpdateMode.DeltaTime) ? (elapsedTime + Time.unscaledDeltaTime * container.curveSpeed) : (elapsedTime + Time.deltaTime * container.curveSpeed));
				yield return null;
			}
			base.transform.localScale = new Vector3(1f, 1f, 1f);
		}

		private IEnumerator ProcessBoxFade()
		{
			cg.alpha = 0f;
			while (cg.alpha < 0.99f)
			{
				if (container.updateMode == BoxContainer.UpdateMode.DeltaTime)
				{
					cg.alpha += Time.deltaTime * container.fadeSpeed;
				}
				else
				{
					cg.alpha += Time.unscaledDeltaTime * container.fadeSpeed;
				}
				yield return null;
			}
			cg.alpha = 1f;
		}
	}
}
