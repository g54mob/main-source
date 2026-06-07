using DV.CabControls;
using UnityEngine;

namespace DV.Interaction
{
	public class PageFlippingHelper : MonoBehaviour
	{
		[SerializeField]
		private GameObject previousPageButtonGameObject;

		[SerializeField]
		private GameObject nextPageButtonGameObject;

		private PageBook pageBook;

		private ButtonBase previousPageButton;

		private ButtonBase nextPageButton;

		private void Start()
		{
			pageBook = GetComponentInParent<PageBook>();
			if (pageBook == null)
			{
				Debug.LogError("Parent is missing PageBook component. PageFlippingHelper destroying self.", base.transform.parent);
				Object.Destroy(base.gameObject);
				return;
			}
			previousPageButton = ((previousPageButtonGameObject != null) ? previousPageButtonGameObject.GetComponent<ButtonBase>() : null);
			nextPageButton = ((nextPageButtonGameObject != null) ? nextPageButtonGameObject.GetComponent<ButtonBase>() : null);
			bool flag = false;
			if (previousPageButton == null)
			{
				Debug.LogError("Missing ButtonBase component on previousPageButtonGameObject. PageFlippingHelper destroying self.", base.transform.parent);
				flag = true;
			}
			if (nextPageButton == null)
			{
				Debug.LogError("Missing ButtonBase component on nextPageButtonGameObject. PageFlippingHelper destroying self.", base.transform.parent);
				flag = true;
			}
			if (flag)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				SetupListeners(on: true);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				previousPageButton.Used += OnPreviousPageButtonUsed;
				nextPageButton.Used += OnNextPageButtonUsed;
				return;
			}
			if (previousPageButton != null)
			{
				previousPageButton.Used -= OnPreviousPageButtonUsed;
			}
			if (nextPageButton != null)
			{
				nextPageButton.Used -= OnNextPageButtonUsed;
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void OnPreviousPageButtonUsed()
		{
			pageBook.FlipBy(-1);
		}

		private void OnNextPageButtonUsed()
		{
			pageBook.FlipBy(1);
		}
	}
}
